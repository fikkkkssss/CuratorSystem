using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace CuratorReportSystem
{
    public partial class Form14 : Form
    {
        private string connectionString = "Host=localhost;Port=5433;Database=kp;Username=postgres;Password=\"Q#Rto%g$$$5\"";
        private int studentId;

        public Form14(int studentId)
        {
            InitializeComponent();
            this.studentId = studentId;

            this.Load += (s, e) => AdjustLayout();
            this.Resize += (s, e) => AdjustLayout();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            LoadStudentData();
            LoadGrades();
            LoadAttendance();
            LoadAchievements();
        }

        private void AdjustLayout()
        {
            int margin = 40;
            int spacing = 20;

            // ПАНЕЛЬ БОЛЬШЕ НЕ РАСТЯГИВАЕТСЯ (закомментировали строку)
            // pnlInfo.Width = this.ClientSize.Width - (margin * 2);

            int totalWidth = this.ClientSize.Width - (margin * 2) - (spacing * 2);
            int colWidth = totalWidth / 3;

            int topY = 220;
            int bottomY = btnRefresh.Top - 20;
            int tableHeight = bottomY - topY;

            if (tableHeight < 100) tableHeight = 100;

            // Таблица 1 (Оценки)
            dgvGrades.Location = new Point(margin, topY);
            dgvGrades.Size = new Size(colWidth, tableHeight);
            lblGradesTitle.Left = dgvGrades.Left + (dgvGrades.Width - lblGradesTitle.Width) / 2;

            // Таблица 2 (Посещаемость)
            dgvAttendance.Location = new Point(margin + colWidth + spacing, topY);
            dgvAttendance.Size = new Size(colWidth, tableHeight);
            lblAttendanceTitle.Left = dgvAttendance.Left + (dgvAttendance.Width - lblAttendanceTitle.Width) / 2;

            // Таблица 3 (Достижения)
            dgvAchievements.Location = new Point(margin + (colWidth + spacing) * 2, topY);
            dgvAchievements.Size = new Size(colWidth, tableHeight);
            lblAchievementsTitle.Left = dgvAchievements.Left + (dgvAchievements.Width - lblAchievementsTitle.Width) / 2;
        }

        private void LoadStudentData()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT u.last_name || ' ' || u.first_name || ' ' || COALESCE(u.patronymic, '') AS fio,
                               u.email, g.group_name, s.phone, s.parent_info
                        FROM student s
                        JOIN users u ON s.user_id = u.user_id
                        LEFT JOIN ""group"" g ON s.group_id = g.group_id
                        WHERE s.student_id = @student_id";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@student_id", studentId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblFIO.Text = reader["fio"].ToString();
                                lblEmail.Text = "Email: " + reader["email"];

                                lblGroup.Text = "Группа: " + (reader["group_name"] != DBNull.Value ? reader["group_name"].ToString() : "Не назначена");
                                lblPhone.Text = "Телефон: " + (reader["phone"] != DBNull.Value ? reader["phone"].ToString() : "Не указан");

                                if (reader["parent_info"] != DBNull.Value)
                                {
                                    string json = reader["parent_info"].ToString();
                                    string cleanInfo = json.Replace("{", "").Replace("}", "").Replace("\"", "").Replace(",", ", ");
                                    lblParents.Text = "Родители: " + cleanInfo;
                                }
                                else
                                {
                                    lblParents.Text = "Родители: Не указаны";
                                }
                            }
                        }
                    }

                    double avgGrade = 0;
                    int badCount = 0;
                    using (var cmd = new NpgsqlCommand("SELECT COALESCE(AVG(grade_value), 0) FROM grade WHERE student_id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", studentId);
                        avgGrade = Convert.ToDouble(cmd.ExecuteScalar());
                    }
                    using (var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM grade WHERE student_id = @id AND grade_value <= 3", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", studentId);
                        badCount = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    lblAvgGrade.Text = $"Средний балл: {Math.Round(avgGrade, 2)}";

                    string status = (avgGrade < 3.5 || badCount >= 2) ? "риск" : (avgGrade < 4.0 || badCount == 1) ? "внимание" : "норма";
                    lblStatus.Text = $"Статус: {status.ToUpper()}";
                    lblStatus.ForeColor = status == "риск" ? Color.Red : status == "внимание" ? Color.Orange : Color.Green;
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка данных: {ex.Message}"); }
        }

        private void LoadGrades()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT sub.subject_name AS subject, g.grade_value AS grade, g.grade_date AS date
                                     FROM grade g JOIN subject sub ON g.subject_id = sub.subject_id
                                     WHERE g.student_id = @id ORDER BY g.grade_date DESC LIMIT 10";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", studentId);
                        DataTable dt = new DataTable();
                        new NpgsqlDataAdapter(cmd).Fill(dt);
                        dgvGrades.DataSource = dt;
                        if (dgvGrades.Columns["subject"] != null) dgvGrades.Columns["subject"].HeaderText = "Предмет";
                        if (dgvGrades.Columns["grade"] != null) dgvGrades.Columns["grade"].HeaderText = "Оценка";
                        if (dgvGrades.Columns["date"] != null) dgvGrades.Columns["date"].HeaderText = "Дата";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка оценок: {ex.Message}"); }
        }

        private void LoadAttendance()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT sub.subject_name AS subject, a.attendance_date AS date, a.status AS status
                                     FROM attendance a JOIN subject sub ON a.subject_id = sub.subject_id
                                     WHERE a.student_id = @id ORDER BY a.attendance_date DESC LIMIT 10";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", studentId);
                        DataTable dt = new DataTable();
                        new NpgsqlDataAdapter(cmd).Fill(dt);
                        dgvAttendance.DataSource = dt;
                        if (dgvAttendance.Columns["subject"] != null) dgvAttendance.Columns["subject"].HeaderText = "Предмет";
                        if (dgvAttendance.Columns["date"] != null) dgvAttendance.Columns["date"].HeaderText = "Дата";
                        if (dgvAttendance.Columns["status"] != null) dgvAttendance.Columns["status"].HeaderText = "Статус";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка посещаемости: {ex.Message}"); }
        }

        private void LoadAchievements()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT a.description AS achievement, a.date_awerded AS date, e.event_name AS event
                                     FROM achievement a LEFT JOIN event e ON a.event_id = e.event_id
                                     WHERE a.student_id = @id ORDER BY a.date_awerded DESC";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", studentId);
                        DataTable dt = new DataTable();
                        new NpgsqlDataAdapter(cmd).Fill(dt);
                        dgvAchievements.DataSource = dt;
                        if (dgvAchievements.Columns["achievement"] != null) dgvAchievements.Columns["achievement"].HeaderText = "Достижение";
                        if (dgvAchievements.Columns["date"] != null) dgvAchievements.Columns["date"].HeaderText = "Дата";
                        if (dgvAchievements.Columns["event"] != null) dgvAchievements.Columns["event"].HeaderText = "Мероприятие";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка достижений: {ex.Message}"); }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStudentData();
            LoadGrades();
            LoadAttendance();
            LoadAchievements();
            AdjustLayout();
        }

        private void btnClose_Click(object sender, EventArgs e) { this.Close(); }
    }
}