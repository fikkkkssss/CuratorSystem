using Guna.UI2.WinForms;
using Npgsql;
using System;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CuratorReportSystem
{
    public partial class Form7 : Form
    {
        private string connectionString = "Host=localhost;Port=5433;Database=kp;Username=postgres;Password=\"Q#Rto%g$$$5\"";
        private int currentEditUserId = -1;
        private bool isEditMode = false;

        private Color FieldColor = Color.FromArgb(220, 205, 240);
        private Color ReadOnlyColor = Color.LightGray;

        public Form7()
        {
            InitializeComponent();

            cmbRole.Items.Clear();
            cmbRole.Items.Add("curator");
            cmbRole.Items.Add("student");
            cmbRole.Items.Add("admin");

            SetupButtonStyles();

            LoadUsers();
            LoadGroups();

            dgvUsers.SelectionChanged += dgvUsers_SelectionChanged;
            cmbRole.SelectedIndexChanged += cmbRole_SelectedIndexChanged;

            SetFieldsReadOnly(true);
            btnAddUser.Text = "Добавить";
            btnEditUser.Text = "Изменить";
        }

        private void SetupButtonStyles()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Guna2Button btn)
                {
                    btn.BorderRadius = 25;
                    btn.Animated = false;

                    Color orig = btn.FillColor;
                    btn.HoverState.FillColor = orig;
                    btn.HoverState.ForeColor = Color.Black;
                    btn.MouseEnter += (s, e) => { btn.FillColor = orig; };
                    btn.MouseLeave += (s, e) => { btn.FillColor = orig; };
                }
            }
        }

        private void ApplyFieldColors(Guna2TextBox txt, bool isReadOnly)
        {
            Color c = isReadOnly ? ReadOnlyColor : FieldColor;
            txt.ReadOnly = isReadOnly;
            txt.FillColor = c;
            txt.FocusedState.FillColor = c;
            txt.FocusedState.BorderColor = c;
            txt.HoverState.FillColor = c;
        }

        private void SetFieldsReadOnly(bool readOnly)
        {
            ApplyFieldColors(txtLogin, readOnly);
            ApplyFieldColors(txtEmail, readOnly);
            ApplyFieldColors(txtLastName, readOnly);
            ApplyFieldColors(txtFirstName, readOnly);
            ApplyFieldColors(txtPatronymic, readOnly);
            ApplyFieldColors(txtPhone, readOnly);

            cmbRole.Enabled = !readOnly;
            cmbRole.FillColor = FieldColor;
            cmbRole.FocusedState.FillColor = FieldColor;

            ApplyFieldColors(txtPassword, true);

            if (readOnly)
            {
                cmbGroup.Enabled = false;
                cmbGroup.FillColor = FieldColor;
                btnAddUser.Text = "Добавить";
                btnEditUser.Text = "Изменить";
                btnAddUser.Enabled = true; btnEditUser.Enabled = true;
                btnDeleteUser.Enabled = true; btnChangePassword.Enabled = true;
            }
            else
            {
                cmbGroup.Enabled = (cmbRole.SelectedItem?.ToString() == "student");
                cmbGroup.FillColor = FieldColor;
                cmbGroup.FocusedState.FillColor = FieldColor;
            }
        }

        private void PrepareForAddMode()
        {
            isEditMode = false;
            ClearFields();
            currentEditUserId = -1;

            ApplyFieldColors(txtLogin, false);
            ApplyFieldColors(txtEmail, false);
            ApplyFieldColors(txtLastName, false);
            ApplyFieldColors(txtFirstName, false);
            ApplyFieldColors(txtPatronymic, false);
            ApplyFieldColors(txtPhone, false);

            cmbRole.Enabled = true; cmbRole.FillColor = FieldColor;
            cmbGroup.Enabled = false; cmbGroup.FillColor = FieldColor;

            ApplyFieldColors(txtPassword, false);
            txtPassword.Clear();

            btnAddUser.Text = "Сохранить";
            btnEditUser.Enabled = false; btnDeleteUser.Enabled = false; btnChangePassword.Enabled = false;
        }

        private void ClearFields()
        {
            txtLogin.Clear(); txtPassword.Clear(); txtEmail.Clear();
            txtLastName.Clear(); txtFirstName.Clear(); txtPatronymic.Clear(); txtPhone.Clear();
            cmbRole.SelectedIndex = -1; cmbGroup.SelectedIndex = -1;
            ApplyFieldColors(txtPassword, true);
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (!isEditMode && dgvUsers.CurrentRow != null && btnAddUser.Text != "Сохранить")
                LoadSelectedUser();
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isStudent = cmbRole.SelectedItem?.ToString() == "student";
            cmbGroup.Enabled = isStudent && !txtLogin.ReadOnly;
            if (!isStudent) cmbGroup.SelectedIndex = -1;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (btnAddUser.Text == "Сохранить") SaveNewUser();
            else PrepareForAddMode();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (currentEditUserId == -1) { MessageBox.Show("Выберите пользователя"); return; }

            if (!isEditMode)
            {
                isEditMode = true;
                SetFieldsReadOnly(false);
                btnEditUser.Text = "Сохранить";
                btnAddUser.Enabled = false; btnDeleteUser.Enabled = false; btnChangePassword.Enabled = false;
                ApplyFieldColors(txtPassword, true);
            }
            else SaveUserData();
        }

        private void SaveNewUser()
        {
            string login = txtLogin.Text.Trim(); string password = txtPassword.Text.Trim();
            string email = txtEmail.Text.Trim(); string lastName = txtLastName.Text.Trim();
            string firstName = txtFirstName.Text.Trim(); string patronymic = txtPatronymic.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString(); string phone = txtPhone.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            { MessageBox.Show("Заполните Логин, Пароль и Роль"); return; }

            if (!IsPasswordStrong(password)) return;
            if (!IsValidEmail(email)) return;
            if (!IsLoginUnique(login)) return;
            if (!IsEmailUnique(email)) return;

            int roleId = GetRoleId(role);

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        string userQuery = @"INSERT INTO users (login, password_hash, email, first_name, last_name, patronymic, role_id) 
                                             VALUES (@login, @password, @email, @fname, @lname, @patr, @role_id) RETURNING user_id";
                        int userId;
                        using (var cmd = new NpgsqlCommand(userQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@login", login);
                            cmd.Parameters.AddWithValue("@password", HashPassword(password));
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.Parameters.AddWithValue("@fname", string.IsNullOrEmpty(firstName) ? (object)DBNull.Value : firstName);
                            cmd.Parameters.AddWithValue("@lname", string.IsNullOrEmpty(lastName) ? (object)DBNull.Value : lastName);
                            cmd.Parameters.AddWithValue("@patr", string.IsNullOrEmpty(patronymic) ? (object)DBNull.Value : patronymic);
                            cmd.Parameters.AddWithValue("@role_id", roleId);
                            userId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        if (role == "student")
                        {
                            if (cmbGroup.SelectedValue == null || string.IsNullOrEmpty(phone))
                            { transaction.Rollback(); MessageBox.Show("Для студента обязательны Группа и Телефон"); return; }

                            if (!Regex.IsMatch(phone, @"^\+7[0-9]{10}$"))
                            { transaction.Rollback(); MessageBox.Show("Телефон должен быть в формате +7XXXXXXXXXX"); return; }

                            // Сохранение БЕЗ родителей (так как поля нет в дизайнере)
                            string studentQuery = @"INSERT INTO student (user_id, group_id, phone) 
                                                    VALUES (@user_id, @group_id, @phone)";
                            using (var cmd = new NpgsqlCommand(studentQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@user_id", userId);
                                cmd.Parameters.AddWithValue("@group_id", cmbGroup.SelectedValue);
                                cmd.Parameters.AddWithValue("@phone", phone);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                }
                MessageBox.Show("Пользователь добавлен");
                LoadUsers(); SetFieldsReadOnly(true); ClearFields();
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
        }

        private void SaveUserData()
        {
            string login = txtLogin.Text.Trim(); string email = txtEmail.Text.Trim();
            string lastName = txtLastName.Text.Trim(); string firstName = txtFirstName.Text.Trim();
            string patronymic = txtPatronymic.Text.Trim(); string role = cmbRole.SelectedItem?.ToString();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(role)) return;
            if (!IsValidEmail(email)) return;
            if (!IsLoginUnique(login, currentEditUserId)) return;
            if (!IsEmailUnique(email, currentEditUserId)) return;

            int roleId = GetRoleId(role);

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        string userQuery = @"UPDATE users SET login=@login, email=@email, first_name=@fname, 
                                             last_name=@lname, patronymic=@patr, role_id=@role_id WHERE user_id=@id";
                        using (var cmd = new NpgsqlCommand(userQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@login", login);
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.Parameters.AddWithValue("@fname", string.IsNullOrEmpty(firstName) ? (object)DBNull.Value : firstName);
                            cmd.Parameters.AddWithValue("@lname", string.IsNullOrEmpty(lastName) ? (object)DBNull.Value : lastName);
                            cmd.Parameters.AddWithValue("@patr", string.IsNullOrEmpty(patronymic) ? (object)DBNull.Value : patronymic);
                            cmd.Parameters.AddWithValue("@role_id", roleId);
                            cmd.Parameters.AddWithValue("@id", currentEditUserId);
                            cmd.ExecuteNonQuery();
                        }

                        if (role == "student")
                        {
                            string checkQuery = "SELECT COUNT(*) FROM student WHERE user_id = @id";
                            using (var cmd = new NpgsqlCommand(checkQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", currentEditUserId);
                                long count = (long)cmd.ExecuteScalar();

                                if (count > 0)
                                {
                                    string updateQuery = "UPDATE student SET group_id=@gid, phone=@phone WHERE user_id=@id";
                                    using (var cmdUpd = new NpgsqlCommand(updateQuery, conn, transaction))
                                    {
                                        cmdUpd.Parameters.AddWithValue("@gid", cmbGroup.SelectedValue ?? (object)DBNull.Value);
                                        cmdUpd.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone);
                                        cmdUpd.Parameters.AddWithValue("@id", currentEditUserId);
                                        cmdUpd.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    string insertQuery = "INSERT INTO student (user_id, group_id, phone) VALUES (@id, @gid, @phone)";
                                    using (var cmdIns = new NpgsqlCommand(insertQuery, conn, transaction))
                                    {
                                        cmdIns.Parameters.AddWithValue("@id", currentEditUserId);
                                        cmdIns.Parameters.AddWithValue("@gid", cmbGroup.SelectedValue ?? (object)DBNull.Value);
                                        cmdIns.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone);
                                        cmdIns.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        transaction.Commit();
                    }
                }
                MessageBox.Show("Данные обновлены");
                isEditMode = false; SetFieldsReadOnly(true); LoadUsers();
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
        }

        private void LoadUsers()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT u.user_id, u.login, u.email, u.first_name, u.last_name, u.patronymic, 
                                            r.role_name as role, s.phone FROM users u
                                     JOIN roles r ON u.role_id = r.role_id
                                     LEFT JOIN student s ON u.user_id = s.user_id ORDER BY u.user_id";
                    using (var adapter = new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvUsers.DataSource = dt;

                        dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        if (dgvUsers.Columns["user_id"] != null) dgvUsers.Columns["user_id"].Visible = false;

                        if (dgvUsers.Columns["login"] != null) dgvUsers.Columns["login"].HeaderText = "Логин";
                        if (dgvUsers.Columns["email"] != null) dgvUsers.Columns["email"].HeaderText = "Email";
                        if (dgvUsers.Columns["first_name"] != null) dgvUsers.Columns["first_name"].HeaderText = "Имя";
                        if (dgvUsers.Columns["last_name"] != null) dgvUsers.Columns["last_name"].HeaderText = "Фамилия";
                        if (dgvUsers.Columns["patronymic"] != null) dgvUsers.Columns["patronymic"].HeaderText = "Отчество";
                        if (dgvUsers.Columns["role"] != null) dgvUsers.Columns["role"].HeaderText = "Роль";
                        if (dgvUsers.Columns["phone"] != null) dgvUsers.Columns["phone"].HeaderText = "Телефон";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка загрузки: " + ex.Message); }
        }

        private void LoadSelectedUser()
        {
            if (dgvUsers.CurrentRow == null) return;
            try
            {
                int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["user_id"].Value);
                currentEditUserId = userId;

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT u.login, u.email, u.first_name, u.last_name, u.patronymic, 
                                            r.role_name, s.phone, s.group_id 
                                     FROM users u
                                     JOIN roles r ON u.role_id = r.role_id
                                     LEFT JOIN student s ON u.user_id = s.user_id WHERE u.user_id = @id";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtLogin.Text = reader["login"].ToString();
                                txtEmail.Text = reader["email"].ToString();
                                txtLastName.Text = reader["last_name"].ToString();
                                txtFirstName.Text = reader["first_name"].ToString();
                                txtPatronymic.Text = reader["patronymic"]?.ToString() ?? "";
                                txtPhone.Text = reader["phone"]?.ToString() ?? "";
                                cmbRole.SelectedItem = reader["role_name"].ToString();

                                if (reader["group_id"] != DBNull.Value) cmbGroup.SelectedValue = reader["group_id"];
                                else cmbGroup.SelectedIndex = -1;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void LoadGroups()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT group_id, group_name FROM \"group\" ORDER BY group_name";
                    using (var adapter = new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        cmbGroup.DataSource = dt;
                        cmbGroup.DisplayMember = "group_name";
                        cmbGroup.ValueMember = "group_id";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка групп: " + ex.Message); }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["user_id"].Value);
            string login = dgvUsers.CurrentRow.Cells["login"].Value.ToString();

            if (login == Program.CurrentUserLogin) { MessageBox.Show("Нельзя удалить себя"); return; }

            if (MessageBox.Show($"Удалить {login}?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = new NpgsqlConnection(connectionString))
                    {
                        conn.Open();
                        new NpgsqlCommand($"DELETE FROM student WHERE user_id = {userId}", conn).ExecuteNonQuery();
                        new NpgsqlCommand($"DELETE FROM users WHERE user_id = {userId}", conn).ExecuteNonQuery();
                    }
                    LoadUsers(); ClearFields();
                }
                catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (currentEditUserId == -1) return;

            string login = txtLogin.Text;

            Form passwordForm = new Form();
            passwordForm.Text = $"Смена пароля: {login}";
            passwordForm.Width = 450; passwordForm.Height = 280;
            passwordForm.StartPosition = FormStartPosition.CenterParent;
            passwordForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            passwordForm.MaximizeBox = false; passwordForm.MinimizeBox = false;
            passwordForm.BackColor = Color.LightGray;

            Label lblNewPassword = new Label() { Text = "Новый пароль:", Location = new Point(30, 35), Size = new Size(120, 25), Font = new Font("Segoe UI", 11F) };
            TextBox txtNewPassword = new TextBox() { Location = new Point(160, 35), Size = new Size(230, 25), Font = new Font("Segoe UI", 11F), UseSystemPasswordChar = true };

            Label lblConfirmPassword = new Label() { Text = "Подтверждение:", Location = new Point(30, 75), Size = new Size(120, 25), Font = new Font("Segoe UI", 11F) };
            TextBox txtConfirmPassword = new TextBox() { Location = new Point(160, 75), Size = new Size(230, 25), Font = new Font("Segoe UI", 11F), UseSystemPasswordChar = true };

            Label lblHint = new Label() { Text = "Мин. 6 символов, заглавная, строчная, цифра и спецсимвол", Location = new Point(30, 110), Size = new Size(380, 35), Font = new Font("Segoe UI", 8F), ForeColor = Color.Gray };

            Guna2Button btnSave = new Guna2Button() { Text = "Сохранить", BorderRadius = 15, FillColor = Color.Salmon, ForeColor = Color.Black, Font = new Font("Segoe UI", 11F), Size = new Size(120, 40), Location = new Point(100, 190) };
            btnSave.Click += (s, ev) => {
                string newPassword = txtNewPassword.Text.Trim();
                string confirmPassword = txtConfirmPassword.Text.Trim();

                if (string.IsNullOrEmpty(newPassword)) { MessageBox.Show("Введите пароль"); return; }
                if (!IsPasswordStrong(newPassword)) return;
                if (newPassword != confirmPassword) { MessageBox.Show("Пароли не совпадают"); return; }

                try
                {
                    using (var conn = new NpgsqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "UPDATE users SET password_hash = @password WHERE user_id = @user_id";
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@password", HashPassword(newPassword));
                            cmd.Parameters.AddWithValue("@user_id", currentEditUserId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Пароль изменен");
                    passwordForm.Close();
                }
                catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
            };

            Guna2Button btnCancel = new Guna2Button() { Text = "Отмена", BorderRadius = 15, FillColor = Color.Salmon, ForeColor = Color.Black, Font = new Font("Segoe UI", 11F), Size = new Size(120, 40), Location = new Point(240, 190) };
            btnCancel.Click += (s, ev) => { passwordForm.Close(); };

            passwordForm.Controls.Add(lblNewPassword); passwordForm.Controls.Add(txtNewPassword);
            passwordForm.Controls.Add(lblConfirmPassword); passwordForm.Controls.Add(txtConfirmPassword);
            passwordForm.Controls.Add(lblHint); passwordForm.Controls.Add(btnSave); passwordForm.Controls.Add(btnCancel);

            passwordForm.ShowDialog(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (Program.MainForm != null)
            {
                Program.MainForm.Close();
            }
        }

        // --- УТИЛИТЫ ---
        private bool IsPasswordStrong(string password)
        {
            if (password.Length < 6) { MessageBox.Show("Пароль < 6 символов"); return false; }
            if (!Regex.IsMatch(password, "[A-Z]")) { MessageBox.Show("Нужна заглавная буква"); return false; }
            if (!Regex.IsMatch(password, "[a-z]")) { MessageBox.Show("Нужна строчная буква"); return false; }
            if (!Regex.IsMatch(password, "[0-9]")) { MessageBox.Show("Нужна цифра"); return false; }
            return true;
        }

        private bool IsValidEmail(string email)
        {
            try { var addr = new MailAddress(email); return addr.Address == email; }
            catch { MessageBox.Show("Неверный email"); return false; }
        }

        private bool IsLoginUnique(string login, int excludeId = -1)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string q = "SELECT COUNT(*) FROM users WHERE login = @l";
                if (excludeId > 0) q += " AND user_id != @id";
                using (var cmd = new NpgsqlCommand(q, conn))
                {
                    cmd.Parameters.AddWithValue("@l", login);
                    if (excludeId > 0) cmd.Parameters.AddWithValue("@id", excludeId);
                    if ((long)cmd.ExecuteScalar() > 0) { MessageBox.Show("Логин занят"); return false; }
                }
            }
            return true;
        }

        private bool IsEmailUnique(string email, int excludeId = -1)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string q = "SELECT COUNT(*) FROM users WHERE email = @e";
                if (excludeId > 0) q += " AND user_id != @id";
                using (var cmd = new NpgsqlCommand(q, conn))
                {
                    cmd.Parameters.AddWithValue("@e", email);
                    if (excludeId > 0) cmd.Parameters.AddWithValue("@id", excludeId);
                    if ((long)cmd.ExecuteScalar() > 0) { MessageBox.Show("Email занят"); return false; }
                }
            }
            return true;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        private int GetRoleId(string roleName)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT role_id FROM roles WHERE role_name = @r", conn))
                {
                    cmd.Parameters.AddWithValue("@r", roleName);
                    object res = cmd.ExecuteScalar();
                    return res != null ? Convert.ToInt32(res) : 1;
                }
            }
        }
    }
}