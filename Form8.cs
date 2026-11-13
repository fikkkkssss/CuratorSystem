using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace CuratorReportSystem
{
    public partial class Form8 : Form
    {
        private string connectionString = "Host=localhost;Port=5433;Database=kp;Username=postgres;Password=\"Q#Rto%g$$$5\"";

        public Form8()
        {
            InitializeComponent();

            LoadAchievements();
            LoadEvents();

            if (Program.CurrentUserRole == "student")
            {
                // Студент видит только свои достижения.
                // Скрываем панель добавления и всё, что связано с посещениями мероприятий.
                pnlAdd.Visible = false;
                cmbFilterEvent.Visible = false;
                lblSelectEvent.Visible = false;
                dgvEventAttendance.Visible = false;
                lblAttendanceTitle.Visible = false;

                this.Text = "Мои достижения";
            }
            else
            {
                LoadStudents();
                LoadEventFilter();
            }
        }

        private void LoadEventFilter()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT event_id, event_name FROM event ORDER BY event_date DESC";
                    using (var adapter = new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        cmbFilterEvent.DataSource = dt;
                        cmbFilterEvent.DisplayMember = "event_name";
                        cmbFilterEvent.ValueMember = "event_id";
                        cmbFilterEvent.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки фильтра: {ex.Message}"); }
        }

        private void LoadEventAttendance(int eventId)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT u.last_name || ' ' || u.first_name AS student_name, ea.status
                        FROM event_attendance ea
                        JOIN student s ON ea.student_id = s.student_id
                        JOIN users u ON s.user_id = u.user_id
                        WHERE ea.event_id = @event_id
                        ORDER BY u.last_name";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@event_id", eventId);
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvEventAttendance.DataSource = dt;

                            if (dgvEventAttendance.Columns["student_name"] != null)
                                dgvEventAttendance.Columns["student_name"].HeaderText = "Студент";
                            if (dgvEventAttendance.Columns["status"] != null)
                                dgvEventAttendance.Columns["status"].HeaderText = "Статус";
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки посещений: {ex.Message}"); }
        }

        private void cmbFilterEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterEvent.SelectedValue != null && cmbFilterEvent.SelectedValue != DBNull.Value)
            {
                try
                {
                    int eventId = Convert.ToInt32(cmbFilterEvent.SelectedValue);
                    LoadEventAttendance(eventId);
                }
                catch { dgvEventAttendance.DataSource = null; }
            }
            else
            {
                dgvEventAttendance.DataSource = null;
            }
        }

        private void LoadAchievements()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = (Program.CurrentUserRole == "student")
                        ? @"SELECT a.description, a.date_awerded, e.event_name
                            FROM achievement a
                            LEFT JOIN event e ON a.event_id = e.event_id
                            JOIN student s ON a.student_id = s.student_id
                            WHERE s.user_id = @user_id
                            ORDER BY a.date_awerded DESC"
                        : @"SELECT u.last_name || ' ' || u.first_name AS student_name,
                                   a.description, a.date_awerded, e.event_name
                            FROM achievement a
                            JOIN student s ON a.student_id = s.student_id
                            JOIN users u ON s.user_id = u.user_id
                            LEFT JOIN event e ON a.event_id = e.event_id
                            ORDER BY a.date_awerded DESC";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        if (Program.CurrentUserRole == "student") cmd.Parameters.AddWithValue("@user_id", Program.CurrentUserId);

                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvAchievements.DataSource = dt;

                            if (dgvAchievements.Columns["student_name"] != null) dgvAchievements.Columns["student_name"].HeaderText = "Студент";
                            if (dgvAchievements.Columns["description"] != null) dgvAchievements.Columns["description"].HeaderText = "Достижение";
                            if (dgvAchievements.Columns["date_awerded"] != null) dgvAchievements.Columns["date_awerded"].HeaderText = "Дата";
                            if (dgvAchievements.Columns["event_name"] != null) dgvAchievements.Columns["event_name"].HeaderText = "Мероприятие";
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки: {ex.Message}"); }
        }

        private void LoadEvents()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT event_id, event_name FROM event ORDER BY event_date DESC";
                    using (var adapter = new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        cmbEvent.DataSource = dt;
                        cmbEvent.DisplayMember = "event_name";
                        cmbEvent.ValueMember = "event_id";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки мероприятий: {ex.Message}"); }
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

        private void btnAddAchievement_Click(object sender, EventArgs e)
        {
            int studentId;

            if (Program.CurrentUserRole == "student")
            {
                try
                {
                    using (var conn = new NpgsqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "SELECT student_id FROM student WHERE user_id = @user_id";
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@user_id", Program.CurrentUserId);
                            studentId = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); return; }
            }
            else
            {
                if (cmbStudent.SelectedValue == null) { MessageBox.Show("Выберите студента"); return; }
                studentId = Convert.ToInt32(cmbStudent.SelectedValue);
            }

            int? eventId = null;
            if (cmbEvent.SelectedValue != null) eventId = Convert.ToInt32(cmbEvent.SelectedValue);

            string description = txtAchievementDesc.Text.Trim();
            if (string.IsNullOrEmpty(description)) { MessageBox.Show("Введите описание"); return; }

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
                        cmd.Parameters.AddWithValue("@event_id", eventId.HasValue ? (object)eventId.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Достижение добавлено");
                txtAchievementDesc.Clear();
                LoadAchievements();
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAchievements();
            LoadEvents();
            if (Program.CurrentUserRole != "student")
            {
                LoadEventFilter();
                LoadStudents();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (Program.MainForm != null) Program.MainForm.Close();
        }
    }
}