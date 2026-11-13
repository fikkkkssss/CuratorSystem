using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using Microsoft.VisualBasic;

namespace CuratorReportSystem
{
    public partial class Form4 : Form
    {
        private string connectionString = "Host=localhost;Port=5433;Database=kp;Username=postgres;Password=\"Q#Rto%g$$$5\"";
        private int curatorGroupId = 0;

        public Form4()
        {
            InitializeComponent();

            this.Resize += (s, e) => AdjustLayout();

            if (Program.CurrentUserRole == "student")
            {
                LoadStudentGrades();

                // Скрываем всё, что не нужно студенту
                btnAdd.Visible = false;
                btnStatistics.Visible = false;
                btnRating.Visible = false;
                btnAnalysis.Visible = false;
                cmbStudent.Visible = false;
                cmbSubject.Visible = false;
                txtGrade.Visible = false;
                dtpGradeDate.Visible = false;
                lblStudent.Visible = false;
                lblSubject.Visible = false;
                lblGrade.Visible = false;
                lblDate.Visible = false;
                pnlAddGrade.Visible = false;
                this.Text = "Мои оценки";
            }
            else if (Program.CurrentUserRole == "curator")
            {
                GetCuratorGroupId();
                LoadCuratorGrades();
                LoadSubjects();
                LoadStudentsFromCuratorGroup();
                this.Text = "Успеваемость (моя группа)";
            }
            else
            {
                LoadAllGrades();
                LoadSubjects();
                LoadAllStudents();
                LoadGroupsForAnalysis();
                cmbAnalysisGroup.Visible = true;
                this.Text = "Успеваемость (все группы)";
            }
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            int topY = 240;
            int bottomY = btnRefresh.Top - 40;
            int newHeight = bottomY - topY;
            if (newHeight < 100) newHeight = 100;
            dgvGrades.Height = newHeight;
        }

        private void GetCuratorGroupId()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT group_id FROM ""group"" WHERE curator_id = @curator_id";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@curator_id", Program.CurrentUserId);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            curatorGroupId = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка получения группы: {ex.Message}"); }
        }

        private void LoadCuratorGrades()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT g.grade_id, u.last_name || ' ' || u.first_name AS student_name,
                                            s.subject_name, g.grade_value, g.grade_date
                                     FROM grade g
                                     JOIN student st ON g.student_id = st.student_id
                                     JOIN users u ON st.user_id = u.user_id
                                     JOIN subject s ON g.subject_id = s.subject_id
                                     WHERE st.group_id = @group_id
                                     ORDER BY g.grade_date DESC";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@group_id", curatorGroupId);
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvGrades.DataSource = dt;

                            if (dgvGrades.Columns["grade_id"] != null) dgvGrades.Columns["grade_id"].Visible = false;
                            if (dgvGrades.Columns["student_name"] != null) dgvGrades.Columns["student_name"].HeaderText = "Студент";
                            if (dgvGrades.Columns["subject_name"] != null) dgvGrades.Columns["subject_name"].HeaderText = "Предмет";
                            if (dgvGrades.Columns["grade_value"] != null) dgvGrades.Columns["grade_value"].HeaderText = "Оценка";
                            if (dgvGrades.Columns["grade_date"] != null) dgvGrades.Columns["grade_date"].HeaderText = "Дата";
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки: {ex.Message}"); }
        }

        private void LoadStudentGrades()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT s.subject_name, g.grade_value, g.grade_date
                                     FROM grade g
                                     JOIN student st ON g.student_id = st.student_id
                                     JOIN subject s ON g.subject_id = s.subject_id
                                     WHERE st.user_id = @user_id
                                     ORDER BY g.grade_date DESC";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user_id", Program.CurrentUserId);
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvGrades.DataSource = dt;

                            if (dgvGrades.Columns["subject_name"] != null) dgvGrades.Columns["subject_name"].HeaderText = "Предмет";
                            if (dgvGrades.Columns["grade_value"] != null) dgvGrades.Columns["grade_value"].HeaderText = "Оценка";
                            if (dgvGrades.Columns["grade_date"] != null) dgvGrades.Columns["grade_date"].HeaderText = "Дата";
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки: {ex.Message}"); }
        }

        private void LoadAllGrades()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT g.grade_id, u.last_name || ' ' || u.first_name AS student_name,
                                            s.subject_name, g.grade_value, g.grade_date
                                     FROM grade g
                                     JOIN student st ON g.student_id = st.student_id
                                     JOIN users u ON st.user_id = u.user_id
                                     JOIN subject s ON g.subject_id = s.subject_id
                                     ORDER BY g.grade_date DESC";

                    using (var adapter = new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvGrades.DataSource = dt;

                        if (dgvGrades.Columns["grade_id"] != null) dgvGrades.Columns["grade_id"].Visible = false;
                        if (dgvGrades.Columns["student_name"] != null) dgvGrades.Columns["student_name"].HeaderText = "Студент";
                        if (dgvGrades.Columns["subject_name"] != null) dgvGrades.Columns["subject_name"].HeaderText = "Предмет";
                        if (dgvGrades.Columns["grade_value"] != null) dgvGrades.Columns["grade_value"].HeaderText = "Оценка";
                        if (dgvGrades.Columns["grade_date"] != null) dgvGrades.Columns["grade_date"].HeaderText = "Дата";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки: {ex.Message}"); }
        }

        private void LoadSubjects()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT subject_id, subject_name FROM subject ORDER BY subject_name";
                    using (var adapter = new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        cmbSubject.DataSource = dt;
                        cmbSubject.DisplayMember = "subject_name";
                        cmbSubject.ValueMember = "subject_id";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки предметов: {ex.Message}"); }
        }

        private void LoadStudentsFromCuratorGroup()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT s.student_id, u.last_name || ' ' || u.first_name AS student_name
                                     FROM student s
                                     JOIN users u ON s.user_id = u.user_id
                                     WHERE s.group_id = @group_id
                                     ORDER BY u.last_name, u.first_name";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@group_id", curatorGroupId);
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            cmbStudent.DataSource = dt;
                            cmbStudent.DisplayMember = "student_name";
                            cmbStudent.ValueMember = "student_id";
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки студентов: {ex.Message}"); }
        }

        private void LoadAllStudents()
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

        private void LoadGroupsForAnalysis()
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
                        cmbAnalysisGroup.DataSource = dt;
                        cmbAnalysisGroup.DisplayMember = "group_name";
                        cmbAnalysisGroup.ValueMember = "group_id";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки групп: {ex.Message}"); }
        }

        // --- ИСПРАВЛЕННЫЙ МЕТОД ДОБАВЛЕНИЯ ОЦЕНКИ ---
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbStudent.SelectedValue == null || cmbSubject.SelectedValue == null)
            {
                MessageBox.Show("Выберите студента и предмет", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtGrade.Text, out decimal gradeValue))
            {
                MessageBox.Show("Введите корректную оценку (число)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int studentId = Convert.ToInt32(cmbStudent.SelectedValue);
            int subjectId = Convert.ToInt32(cmbSubject.SelectedValue);
            DateTime gradeDate = dtpGradeDate.Value;

            if (gradeValue < 1 || gradeValue > 5)
            {
                MessageBox.Show("Оценка должна быть от 1 до 5", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmdUser = new NpgsqlCommand("SELECT set_config('app.current_user', @login, false)", conn))
                    {
                        cmdUser.Parameters.AddWithValue("@login", Program.CurrentUserLogin);
                        cmdUser.ExecuteNonQuery();
                    }

                    string query = @"INSERT INTO grade (student_id, subject_id, grade_value, grade_date, added_by) 
                                     VALUES (@student_id, @subject_id, @grade_value, @grade_date, @added_by)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@student_id", studentId);
                        cmd.Parameters.AddWithValue("@subject_id", subjectId);
                        cmd.Parameters.AddWithValue("@grade_value", gradeValue);
                        cmd.Parameters.AddWithValue("@grade_date", gradeDate);
                        cmd.Parameters.AddWithValue("@added_by", Program.CurrentUserId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Оценка добавлена", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGrade.Clear();

                if (Program.CurrentUserRole == "curator") LoadCuratorGrades();
                else LoadAllGrades();
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка добавления: {ex.Message}"); }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = (Program.CurrentUserRole == "curator")
                        ? @"SELECT g.grade_value FROM grade g JOIN student s ON g.student_id = s.student_id WHERE s.group_id = @group_id"
                        : @"SELECT grade_value FROM grade";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        if (Program.CurrentUserRole == "curator") cmd.Parameters.AddWithValue("@group_id", curatorGroupId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            int total = 0, excellent = 0, good = 0, satisfactory = 0, unsatisfactory = 0;
                            double sum = 0;

                            while (reader.Read())
                            {
                                decimal grade = reader.GetDecimal(0);
                                total++; sum += (double)grade;
                                if (grade >= 4.5m) excellent++;
                                else if (grade >= 3.5m) good++;
                                else if (grade >= 2.5m) satisfactory++;
                                else unsatisfactory++;
                            }
                            double average = total > 0 ? sum / total : 0;

                            string stats = $"Всего оценок: {total}\nСредний балл: {average:F2}\n" +
                                           $"Отлично (5): {excellent}\nХорошо (4): {good}\n" +
                                           $"Удовлетворительно (3): {satisfactory}\nНеудовлетворительно (1-2): {unsatisfactory}";
                            MessageBox.Show(stats, "Статистика успеваемости", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
        }

        private void btnRating_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = (Program.CurrentUserRole == "curator")
                        ? @"SELECT u.last_name || ' ' || u.first_name AS student_name, ROUND(AVG(g.grade_value), 2) as avg_grade, COUNT(g.grade_id) as total_grades
                            FROM student s JOIN users u ON s.user_id = u.user_id JOIN grade g ON s.student_id = g.student_id
                            WHERE s.group_id = @group_id GROUP BY u.last_name, u.first_name ORDER BY avg_grade DESC"
                        : @"SELECT u.last_name || ' ' || u.first_name AS student_name, ROUND(AVG(g.grade_value), 2) as avg_grade, COUNT(g.grade_id) as total_grades
                            FROM student s JOIN users u ON s.user_id = u.user_id JOIN grade g ON s.student_id = g.student_id
                            GROUP BY u.last_name, u.first_name ORDER BY avg_grade DESC";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        if (Program.CurrentUserRole == "curator") cmd.Parameters.AddWithValue("@group_id", curatorGroupId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            string rating = "РЕЙТИНГ СТУДЕНТОВ\n========================================\n\n";
                            int place = 1;
                            while (reader.Read())
                            {
                                rating += $"{place}. {reader["student_name"]} - {reader["avg_grade"]} (оценок: {reader["total_grades"]})\n";
                                place++;
                            }
                            if (place == 1) rating += "Нет студентов с оценками\n";
                            MessageBox.Show(rating, "Рейтинг успеваемости", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (Program.CurrentUserRole == "student") LoadStudentGrades();
            else if (Program.CurrentUserRole == "curator") LoadCuratorGrades();
            else
            {
                LoadAllGrades();
                LoadGroupsForAnalysis();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (Program.MainForm != null) Program.MainForm.Close();
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            int groupId = 0;
            if (Program.CurrentUserRole == "curator") groupId = curatorGroupId;
            else if (Program.CurrentUserRole == "admin" || Program.CurrentUserRole == "administrator")
            {
                if (cmbAnalysisGroup.SelectedValue == null)
                {
                    MessageBox.Show("Выберите группу для анализа в выпадающем списке", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                groupId = Convert.ToInt32(cmbAnalysisGroup.SelectedValue);
            }

            if (groupId > 0)
            {
                Form12 analysisForm = new Form12(groupId);
                if (Program.MainForm is Form2 mainForm)
                {
                    mainForm.OpenForm(analysisForm, null);
                }
                else
                {
                    analysisForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Не удалось определить группу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}