using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using Guna.UI2.WinForms;

namespace CuratorReportSystem
{
    public partial class Form3 : Form
    {
        private string connectionString = "Host=localhost;Port=5433;Database=kp;Username=postgres;Password=\"Q#Rto%g$$$5\"";

        public Form3()
        {
            InitializeComponent();
            LoadStudents();

            // Подписываемся на двойной клик по таблице
            dgvStudents.CellDoubleClick += dgvStudents_CellDoubleClick;
        }

        private void LoadStudents()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT s.student_id, u.last_name, u.first_name, u.patronymic, 
                                            g.group_name, s.phone
                                     FROM student s
                                     JOIN users u ON s.user_id = u.user_id
                                     LEFT JOIN ""group"" g ON s.group_id = g.group_id
                                     ORDER BY u.last_name, u.first_name";

                    using (var adapter = new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvStudents.DataSource = dt;

                        // Скрываем ID
                        if (dgvStudents.Columns["student_id"] != null)
                            dgvStudents.Columns["student_id"].Visible = false;

                        // Растягиваем таблицу
                        dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        if (dgvStudents.Columns["last_name"] != null)
                            dgvStudents.Columns["last_name"].HeaderText = "Фамилия";
                        if (dgvStudents.Columns["first_name"] != null)
                            dgvStudents.Columns["first_name"].HeaderText = "Имя";
                        if (dgvStudents.Columns["patronymic"] != null)
                            dgvStudents.Columns["patronymic"].HeaderText = "Отчество";
                        if (dgvStudents.Columns["group_name"] != null)
                            dgvStudents.Columns["group_name"].HeaderText = "Группа";
                        if (dgvStudents.Columns["phone"] != null)
                            dgvStudents.Columns["phone"].HeaderText = "Телефон";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- ИСПРАВЛЕННЫЙ ДВОЙНОЙ КЛИК ---
        private void dgvStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                int studentId = Convert.ToInt32(dgvStudents.Rows[e.RowIndex].Cells["student_id"].Value);

                // Вместо ShowDialog, просим главное меню открыть Form14 внутри себя
                if (Program.MainForm is Form2 mainForm)
                {
                    mainForm.OpenForm(new Form14(studentId), null);
                }
                else
                {
                    // На случай, если MainForm почему-то не Form2
                    Form14 cardForm = new Form14(studentId);
                    cardForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка открытия карточки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для добавления студента используйте раздел 'Пользователи'",
                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null)
            {
                MessageBox.Show("Выберите студента для редактирования", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int studentId = Convert.ToInt32(dgvStudents.CurrentRow.Cells["student_id"].Value);
            string currentPhone = dgvStudents.CurrentRow.Cells["phone"].Value?.ToString() ?? "";
            string currentLastName = dgvStudents.CurrentRow.Cells["last_name"].Value?.ToString() ?? "";
            string currentFirstName = dgvStudents.CurrentRow.Cells["first_name"].Value?.ToString() ?? "";

            // Создаем форму в стиле приложения
            Form editForm = new Form();
            editForm.Text = $"Редактирование: {currentLastName} {currentFirstName}";
            editForm.Width = 500;
            editForm.Height = 250;
            editForm.StartPosition = FormStartPosition.CenterParent;
            editForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            editForm.MaximizeBox = false;
            editForm.MinimizeBox = false;
            editForm.BackColor = System.Drawing.Color.White;

            // Label
            Label lblPhone = new Label();
            lblPhone.Text = "Телефон (+7XXXXXXXXXX):";
            lblPhone.Location = new System.Drawing.Point(30, 50);
            lblPhone.Size = new System.Drawing.Size(220, 30);
            lblPhone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblPhone.ForeColor = System.Drawing.Color.Black;
            lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // TextBox
            TextBox txtPhone = new TextBox();
            txtPhone.Text = currentPhone;
            txtPhone.Location = new System.Drawing.Point(250, 50);
            txtPhone.Size = new System.Drawing.Size(200, 30);
            txtPhone.Font = new System.Drawing.Font("Segoe UI", 12F);
            txtPhone.BorderStyle = BorderStyle.FixedSingle;

            // Кнопка Сохранить
            var btnSave = new Guna.UI2.WinForms.Guna2Button();
            btnSave.Text = "Сохранить";
            btnSave.BorderRadius = 20;
            btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            btnSave.ForeColor = System.Drawing.Color.Black;
            btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnSave.Size = new System.Drawing.Size(160, 45);
            btnSave.Location = new System.Drawing.Point(80, 130);
            btnSave.Click += (sender2, e2) => {
                string newPhone = txtPhone.Text.Trim();
                if (string.IsNullOrEmpty(newPhone))
                {
                    MessageBox.Show("Введите номер телефона", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(newPhone, @"^\+7[0-9]{10}$"))
                {
                    MessageBox.Show("Телефон должен быть в формате +7XXXXXXXXXX (пример: +79001234567)",
                        "Ошибка формата", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                UpdateStudentPhone(studentId, newPhone);
                editForm.Close();
            };

            // Кнопка Отмена
            var btnCancel = new Guna.UI2.WinForms.Guna2Button();
            btnCancel.Text = "Отмена";
            btnCancel.BorderRadius = 20;
            btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            btnCancel.ForeColor = System.Drawing.Color.Black;
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnCancel.Size = new System.Drawing.Size(160, 45);
            btnCancel.Location = new System.Drawing.Point(260, 130);
            btnCancel.Click += (sender2, e2) => { editForm.Close(); };

            editForm.Controls.Add(lblPhone);
            editForm.Controls.Add(txtPhone);
            editForm.Controls.Add(btnSave);
            editForm.Controls.Add(btnCancel);

            editForm.ShowDialog(this);
        }

        private void UpdateStudentPhone(int studentId, string phone)
        {
            if (!string.IsNullOrEmpty(phone))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\+7[0-9]{10}$"))
                {
                    MessageBox.Show("Телефон должен быть в формате +7XXXXXXXXXX (пример: +79001234567)",
                        "Ошибка формата", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE student SET phone = @phone WHERE student_id = @student_id";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@student_id", studentId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Данные обновлены", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null)
            {
                MessageBox.Show("Выберите студента для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int studentId = Convert.ToInt32(dgvStudents.CurrentRow.Cells["student_id"].Value);
            string studentName = dgvStudents.CurrentRow.Cells["last_name"].Value?.ToString() ?? "";

            DialogResult result = MessageBox.Show($"Удалить студента {studentName}?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var conn = new NpgsqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM student WHERE student_id = @student_id";
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@student_id", studentId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Студент удален", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudents();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (Program.MainForm != null)
            {
                Program.MainForm.Close();
            }
        }
    }
}