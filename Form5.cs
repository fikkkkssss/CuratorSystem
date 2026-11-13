using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using Newtonsoft.Json.Linq;

namespace CuratorReportSystem
{
    public partial class Form5 : Form
    {
        private string connectionString = "Host=localhost;Port=5433;Database=kp;Username=postgres;Password=\"Q#Rto%g$$$5\"";

        public Form5()
        {
            InitializeComponent();

            if (Program.CurrentUserRole == "student")
            {
                pnlAchievement.Visible = false;
                pnlAddEvent.Visible = false;
                this.Text = "Мероприятия (только просмотр)";
            }
            else
            {
                LoadStudents();
            }

            LoadEvents();
        }

        private void LoadEvents()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT event_id, event_name, event_date, description 
                                     FROM event 
                                     ORDER BY event_date DESC";

                    using (var adapter = new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvEvents.DataSource = dt;

                        if (dgvEvents.Columns["event_id"] != null) dgvEvents.Columns["event_id"].Visible = false;
                        if (dgvEvents.Columns["event_name"] != null) dgvEvents.Columns["event_name"].HeaderText = "Название";
                        if (dgvEvents.Columns["event_date"] != null) dgvEvents.Columns["event_date"].HeaderText = "Дата";
                        if (dgvEvents.Columns["description"] != null) dgvEvents.Columns["description"].HeaderText = "Описание";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки данных: {ex.Message}"); }
        }

        private void LoadStudents()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT s.student_id, u.last_name || ' ' || u.first_name AS student_name
                                     FROM student s
                                     JOIN users u ON s.user_id = u.user_id
                                     ORDER BY u.last_name, u.first_name";

                    using (var adapter = new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        cmbStudent.DataSource = dt;
                        cmbStudent.DisplayMember = "student_name";
                        cmbStudent.ValueMember = "student_id";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки студентов: {ex.Message}"); }
        }

        private void dgvEvents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEvents.CurrentRow != null)
            {
                LoadEventDetails();
            }
        }

        // --- ИСПРАВЛЕННЫЙ МЕТОД ЗАГРУЗКИ ДЕТАЛЕЙ ---
        private void LoadEventDetails()
        {
            try
            {
                int eventId = Convert.ToInt32(dgvEvents.CurrentRow.Cells["event_id"].Value);

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    // Берем обычное описание из таблицы event
                    string query = "SELECT description FROM event WHERE event_id = @event_id";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@event_id", eventId);
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value && !string.IsNullOrWhiteSpace(result.ToString()))
                        {
                            txtEventDetails.Text = result.ToString();
                        }
                        else
                        {
                            txtEventDetails.Text = "Описание отсутствует";
                        }
                    }
                }
            }
            catch (Exception ex) { txtEventDetails.Text = $"Ошибка загрузки: {ex.Message}"; }
        }

        // --- ОТМЕТКА ПОСЕЩЕНИЯ ---
        private void btnMarkAttendance_Click(object sender, EventArgs e)
        {
            if (dgvEvents.CurrentRow == null)
            {
                MessageBox.Show("Выберите мероприятие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbStudent.SelectedValue == null)
            {
                MessageBox.Show("Выберите студента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int eventId = Convert.ToInt32(dgvEvents.CurrentRow.Cells["event_id"].Value);
            int studentId = Convert.ToInt32(cmbStudent.SelectedValue);

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM event_attendance WHERE event_id = @eid AND student_id = @sid";
                    using (var cmd = new NpgsqlCommand(checkQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@eid", eventId);
                        cmd.Parameters.AddWithValue("@sid", studentId);
                        long count = (long)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Этот студент уже отмечен на данном мероприятии", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    string query = @"INSERT INTO event_attendance (event_id, student_id, status) 
                                     VALUES (@eid, @sid, 'присутствовал')";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@eid", eventId);
                        cmd.Parameters.AddWithValue("@sid", studentId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Посещение отмечено!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
        }

        // --- ДОБАВЛЕНИЕ ДОСТИЖЕНИЯ С ВСПЛЫВАЮЩИМ ОКНОМ ---
        private void btnAddAchievement_Click(object sender, EventArgs e)
        {
            if (dgvEvents.CurrentRow == null)
            {
                MessageBox.Show("Выберите мероприятие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbStudent.SelectedValue == null)
            {
                MessageBox.Show("Выберите студента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int eventId = Convert.ToInt32(dgvEvents.CurrentRow.Cells["event_id"].Value);
            int studentId = Convert.ToInt32(cmbStudent.SelectedValue);
            string studentName = cmbStudent.Text;
            string eventName = dgvEvents.CurrentRow.Cells["event_name"].Value.ToString();

            // Создаем всплывающее окно для ввода описания
            Form inputForm = new Form();
            inputForm.Text = "Добавление достижения";
            inputForm.Width = 500;
            inputForm.Height = 250;
            inputForm.StartPosition = FormStartPosition.CenterParent;
            inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputForm.MaximizeBox = false;
            inputForm.MinimizeBox = false;
            inputForm.BackColor = System.Drawing.Color.White;

            Label lblInfo = new Label();
            lblInfo.Text = $"Студент: {studentName}\nМероприятие: {eventName}\n\nВведите описание достижения:";
            lblInfo.Location = new System.Drawing.Point(20, 20);
            lblInfo.Size = new System.Drawing.Size(450, 60);
            lblInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);

            TextBox txtAchDesc = new TextBox();
            txtAchDesc.Location = new System.Drawing.Point(20, 85);
            txtAchDesc.Size = new System.Drawing.Size(440, 30);
            txtAchDesc.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtAchDesc.Text = "Участие"; // Значение по умолчанию

            Guna.UI2.WinForms.Guna2Button btnSave = new Guna.UI2.WinForms.Guna2Button();
            btnSave.Text = "Сохранить";
            btnSave.BorderRadius = 20;
            btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            btnSave.ForeColor = System.Drawing.Color.Black;
            btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnSave.Size = new System.Drawing.Size(180, 45);
            btnSave.Location = new System.Drawing.Point(60, 140);
            btnSave.Click += (s, ev) => {
                string desc = txtAchDesc.Text.Trim();
                if (string.IsNullOrEmpty(desc)) desc = "Участие";

                AddAchievement(studentId, eventId, desc);
                inputForm.Close();
            };

            Guna.UI2.WinForms.Guna2Button btnCancel = new Guna.UI2.WinForms.Guna2Button();
            btnCancel.Text = "Отмена";
            btnCancel.BorderRadius = 20;
            btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            btnCancel.ForeColor = System.Drawing.Color.Black;
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnCancel.Size = new System.Drawing.Size(180, 45);
            btnCancel.Location = new System.Drawing.Point(260, 140);
            btnCancel.Click += (s, ev) => { inputForm.Close(); };

            inputForm.Controls.Add(lblInfo);
            inputForm.Controls.Add(txtAchDesc);
            inputForm.Controls.Add(btnSave);
            inputForm.Controls.Add(btnCancel);

            inputForm.ShowDialog(this);
        }

        private bool IsAchievementExists(int studentId, int eventId)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT COUNT(*) FROM achievement 
                                 WHERE student_id = @student_id AND event_id = @event_id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@student_id", studentId);
                    cmd.Parameters.AddWithValue("@event_id", eventId);
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void AddAchievement(int studentId, int eventId, string description)
        {
            if (IsAchievementExists(studentId, eventId))
            {
                MessageBox.Show("Этот студент уже имеет достижение на данном мероприятии!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO achievement (student_id, event_id, description, date_awerded) 
                                     VALUES (@student_id, @event_id, @description, CURRENT_DATE)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@student_id", studentId);
                        cmd.Parameters.AddWithValue("@event_id", eventId);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Достижение добавлено!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            string eventName = txtEventName.Text.Trim();
            string description = txtNewEventDesc.Text.Trim();
            DateTime eventDate = dtpEventDate.Value;

            if (string.IsNullOrEmpty(eventName))
            {
                MessageBox.Show("Введите название мероприятия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO event (event_name, description, event_date, organizer_id) 
                                     VALUES (@event_name, @description, @event_date, @organizer_id)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@event_name", eventName);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@event_date", eventDate);
                        cmd.Parameters.AddWithValue("@organizer_id", Program.CurrentUserId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Мероприятие добавлено", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEventName.Clear();
                txtNewEventDesc.Clear();
                LoadEvents();
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEvents();
            if (Program.CurrentUserRole != "student") LoadStudents();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (Program.MainForm != null) Program.MainForm.Close();
        }
    }
}