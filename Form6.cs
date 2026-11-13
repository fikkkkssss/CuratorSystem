using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace CuratorReportSystem
{
    public partial class Form6 : Form
    {
        private string connectionString = "Host=localhost;Port=5433;Database=kp;Username=postgres;Password=\"Q#Rto%g$$$5\"";
        private int curatorGroupId = 0;

        private decimal ConvertToFiveScale(decimal gradeValue)
        {
            if (gradeValue <= 5) return gradeValue;
            if (gradeValue >= 90) return 5;
            if (gradeValue >= 75) return 4;
            if (gradeValue >= 60) return 3;
            if (gradeValue >= 40) return 2;
            return 1;
        }

        private string FormatGrade(decimal gradeValue)
        {
            return ConvertToFiveScale(gradeValue).ToString("0");
        }

        public Form6()
        {
            InitializeComponent();

            if (Program.CurrentUserRole == "curator")
            {
                GetCuratorGroupId();
                LoadGroupsForCurator();
            }
            else
            {
                LoadAllGroups();
            }
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

        private void LoadGroupsForCurator()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT group_id, group_name FROM ""group"" WHERE curator_id = @curator_id";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@curator_id", Program.CurrentUserId);
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            cmbGroup.DataSource = dt;
                            cmbGroup.DisplayMember = "group_name";
                            cmbGroup.ValueMember = "group_id";
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки групп: {ex.Message}"); }
        }

        private void LoadAllGroups()
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
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки групп: {ex.Message}"); }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cmbGroup.SelectedValue == null)
            {
                MessageBox.Show("Выберите группу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int groupId = Convert.ToInt32(cmbGroup.SelectedValue);
            DateTime startDate = dtpStart.Value;
            DateTime endDate = dtpEnd.Value;

            string report = GenerateReport(groupId, startDate, endDate);
            txtReport.Text = report;
        }

        // --- НОВЫЙ КРАСИВЫЙ ОТЧЕТ БЕЗ ПАЛОЧЕК ---
        private string GenerateReport(int groupId, DateTime startDate, DateTime endDate)
        {
            string report = "";

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    // 1. Шапка
                    string groupQuery = @"SELECT g.group_name, g.student_count, u.last_name || ' ' || u.first_name AS curator_name
                                          FROM ""group"" g
                                          LEFT JOIN users u ON g.curator_id = u.user_id
                                          WHERE g.group_id = @group_id";

                    using (var cmd = new NpgsqlCommand(groupQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@group_id", groupId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                report += "ОТЧЕТ КУРАТОРА\n\n";
                                report += $"Группа: {reader["group_name"]}\n";
                                report += $"Куратор: {reader["curator_name"]}\n";
                                report += $"Количество студентов: {reader["student_count"]}\n";
                                report += $"Период: {startDate:dd.MM.yyyy} - {endDate:dd.MM.yyyy}\n";
                                report += $"Дата формирования: {DateTime.Now:dd.MM.yyyy}\n\n";
                            }
                        }
                    }

                    // 2. Список студентов
                    report += "СПИСОК СТУДЕНТОВ\n\n";
                    string studentsQuery = @"SELECT u.last_name, u.first_name, u.patronymic, s.phone
                                             FROM student s
                                             JOIN users u ON s.user_id = u.user_id
                                             WHERE s.group_id = @group_id
                                             ORDER BY u.last_name, u.first_name";

                    using (var cmd = new NpgsqlCommand(studentsQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@group_id", groupId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            int num = 1;
                            while (reader.Read())
                            {
                                string fio = $"{reader["last_name"]} {reader["first_name"]}";
                                if (reader["patronymic"] != DBNull.Value) fio += $" {reader["patronymic"]}";
                                report += $"{num}. {fio} (тел: {reader["phone"]})\n";
                                num++;
                            }
                        }
                    }
                    report += "\n";

                    // 3. Успеваемость
                    report += "УСПЕВАЕМОСТЬ ГРУППЫ\n\n";
                    string gradesQuery = @"SELECT u.last_name, u.first_name, sub.subject_name, g.grade_value, g.grade_date
                                           FROM grade g
                                           JOIN student s ON g.student_id = s.student_id
                                           JOIN users u ON s.user_id = u.user_id
                                           JOIN subject sub ON g.subject_id = sub.subject_id
                                           WHERE s.group_id = @group_id AND g.grade_date BETWEEN @start_date AND @end_date
                                           ORDER BY u.last_name, u.first_name, g.grade_date DESC";

                    using (var cmd = new NpgsqlCommand(gradesQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@group_id", groupId);
                        cmd.Parameters.AddWithValue("@start_date", startDate);
                        cmd.Parameters.AddWithValue("@end_date", endDate);

                        using (var reader = cmd.ExecuteReader())
                        {
                            string currentStudent = "";
                            while (reader.Read())
                            {
                                string studentName = $"{reader["last_name"]} {reader["first_name"]}";
                                if (studentName != currentStudent)
                                {
                                    if (currentStudent != "") report += "\n";
                                    report += $"{studentName}:\n";
                                    currentStudent = studentName;
                                }
                                decimal originalGrade = reader.GetDecimal(reader.GetOrdinal("grade_value"));
                                string fiveGrade = FormatGrade(originalGrade);
                                string subject = reader["subject_name"].ToString();
                                DateTime date = reader.GetDateTime(reader.GetOrdinal("grade_date"));
                                report += $"   - {subject}: {fiveGrade} ({date:dd.MM.yyyy})\n";
                            }
                            if (currentStudent == "") report += "Нет оценок за указанный период.\n";
                        }
                    }
                    report += "\n";

                    // 4. Статистика успеваемости
                    report += "СТАТИСТИКА УСПЕВАЕМОСТИ\n\n";
                    string statsQuery = @"SELECT g.grade_value FROM grade g
                                          JOIN student s ON g.student_id = s.student_id
                                          WHERE s.group_id = @group_id AND g.grade_date BETWEEN @start_date AND @end_date";

                    using (var cmd = new NpgsqlCommand(statsQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@group_id", groupId);
                        cmd.Parameters.AddWithValue("@start_date", startDate);
                        cmd.Parameters.AddWithValue("@end_date", endDate);

                        using (var reader = cmd.ExecuteReader())
                        {
                            int total = 0, excellent = 0, good = 0, satisfactory = 0, unsatisfactory = 0;
                            double sum = 0;

                            while (reader.Read())
                            {
                                decimal originalGrade = reader.GetDecimal(0);
                                decimal fiveScaleGrade = ConvertToFiveScale(originalGrade);
                                total++;
                                sum += (double)fiveScaleGrade;
                                if (fiveScaleGrade >= 4.5m) excellent++;
                                else if (fiveScaleGrade >= 3.5m) good++;
                                else if (fiveScaleGrade >= 2.5m) satisfactory++;
                                else unsatisfactory++;
                            }

                            double average = total > 0 ? sum / total : 0;
                            report += $"Всего оценок: {total}\n";
                            report += $"Средний балл: {average:F2}\n";
                            report += $"Отлично (5): {excellent}\n";
                            report += $"Хорошо (4): {good}\n";
                            report += $"Удовлетворительно (3): {satisfactory}\n";
                            report += $"Неудовлетворительно (1-2): {unsatisfactory}\n\n";
                        }
                    }

                    // 5. Посещаемость занятий
                    report += "ПОСЕЩАЕМОСТЬ ЗАНЯТИЙ\n\n";
                    string attendanceStatsQuery = @"
                        SELECT 
                            COUNT(*) AS total,
                            COUNT(CASE WHEN a.status = 'присутствовал' THEN 1 END) AS present,
                            COUNT(CASE WHEN a.status = 'отсутствовал по уважительной' THEN 1 END) AS valid_absence,
                            COUNT(CASE WHEN a.status = 'отсутствовал по неуважительной' THEN 1 END) AS invalid_absence,
                            COUNT(CASE WHEN a.status = 'болел' THEN 1 END) AS sick
                        FROM attendance a
                        JOIN student s ON a.student_id = s.student_id
                        WHERE s.group_id = @group_id AND a.attendance_date BETWEEN @start_date AND @end_date";

                    using (var cmd = new NpgsqlCommand(attendanceStatsQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@group_id", groupId);
                        cmd.Parameters.AddWithValue("@start_date", startDate);
                        cmd.Parameters.AddWithValue("@end_date", endDate);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int total = Convert.ToInt32(reader["total"]);
                                int present = Convert.ToInt32(reader["present"]);
                                int validAbsence = Convert.ToInt32(reader["valid_absence"]);
                                int invalidAbsence = Convert.ToInt32(reader["invalid_absence"]);
                                int sick = Convert.ToInt32(reader["sick"]);

                                if (total == 0) report += "Нет данных о посещаемости.\n\n";
                                else
                                {
                                    report += $"Всего отметок: {total}\n";
                                    report += $"Присутствовал: {present}\n";
                                    report += $"Отсутствовал по уважительной: {validAbsence}\n";
                                    report += $"Отсутствовал по неуважительной: {invalidAbsence}\n";
                                    report += $"Болел: {sick}\n\n";
                                }
                            }
                        }
                    }

                    // 6. Посещаемость мероприятий
                    report += "ПОСЕЩАЕМОСТЬ МЕРОПРИЯТИЙ\n\n";
                    string eventAttendanceQuery = @"
                        SELECT e.event_name, e.event_date, u.last_name || ' ' || u.first_name AS student_name, ea.status
                        FROM event_attendance ea
                        JOIN event e ON ea.event_id = e.event_id
                        JOIN student s ON ea.student_id = s.student_id
                        JOIN users u ON s.user_id = u.user_id
                        WHERE s.group_id = @group_id 
                          AND e.event_date BETWEEN @start_date AND @end_date
                        ORDER BY e.event_date DESC, u.last_name";

                    using (var cmd = new NpgsqlCommand(eventAttendanceQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@group_id", groupId);
                        cmd.Parameters.AddWithValue("@start_date", startDate);
                        cmd.Parameters.AddWithValue("@end_date", endDate);

                        using (var reader = cmd.ExecuteReader())
                        {
                            string currentEvent = "";
                            bool hasEvents = false;
                            while (reader.Read())
                            {
                                hasEvents = true;
                                string eventName = reader["event_name"].ToString();
                                DateTime eventDate = Convert.ToDateTime(reader["event_date"]);

                                if (eventName != currentEvent)
                                {
                                    if (currentEvent != "") report += "\n";
                                    report += $"Мероприятие: {eventName} ({eventDate:dd.MM.yyyy})\n";
                                    currentEvent = eventName;
                                }

                                string studentName = reader["student_name"].ToString();
                                string status = reader["status"].ToString();
                                report += $"   - {studentName} ({status})\n";
                            }
                            if (!hasEvents) report += "Нет отмеченных посещений.\n\n";
                            else report += "\n";
                        }
                    }

                    // 7. Достижения
                    report += "ДОСТИЖЕНИЯ СТУДЕНТОВ\n\n";
                    string achievementsQuery = @"SELECT u.last_name, u.first_name, e.event_name, a.description, a.date_awerded
                                                 FROM achievement a
                                                 JOIN student s ON a.student_id = s.student_id
                                                 JOIN users u ON s.user_id = u.user_id
                                                 LEFT JOIN event e ON a.event_id = e.event_id
                                                 WHERE s.group_id = @group_id
                                                 ORDER BY a.date_awerded DESC";

                    using (var cmd = new NpgsqlCommand(achievementsQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@group_id", groupId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            bool hasAchievements = false;
                            while (reader.Read())
                            {
                                hasAchievements = true;
                                string studentName = $"{reader["last_name"]} {reader["first_name"]}";
                                report += $"{studentName}:\n";
                                report += $"   - {reader["description"]}";
                                if (reader["event_name"] != DBNull.Value) report += $" (Мероприятие: {reader["event_name"]})";
                                report += $". Дата: {Convert.ToDateTime(reader["date_awerded"]):dd.MM.yyyy}\n";
                            }
                            if (!hasAchievements) report += "Нет зафиксированных достижений.\n";
                        }
                    }
                }
            }
            catch (Exception ex) { report = $"Ошибка формирования отчета: {ex.Message}"; }

            return report;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtReport.Text))
            {
                MessageBox.Show("Нет данных для сохранения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word документы (*.doc)|*.doc|Текстовые файлы (*.txt)|*.txt|HTML файлы (*.html)|*.html|Все файлы (*.*)|*.*";
            saveFileDialog.DefaultExt = "doc";
            saveFileDialog.FileName = $"Отчет_куратора_{DateTime.Now:yyyyMMdd_HHmmss}";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = saveFileDialog.FileName;

                    if (filePath.EndsWith(".doc")) SaveAsRtf(filePath, txtReport.Text);
                    else if (filePath.EndsWith(".html")) SaveAsHtml(filePath, txtReport.Text);
                    else System.IO.File.WriteAllText(filePath, txtReport.Text, System.Text.Encoding.UTF8);

                    MessageBox.Show("Отчет сохранен", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void SaveAsRtf(string filePath, string reportText)
        {
            string rtfContent = @"{\rtf1\ansi\deff0 {\fonttbl {\f0 Times New Roman;}}\f0\fs24
\pard\qc\fs32\b ОТЧЕТ КУРАТОРА\b0\fs24\par
\pard\ql\par";

            string[] lines = reportText.Split('\n');
            bool inStudents = false, inGrades = false, inStats = false, inAttendance = false, inEventAttendance = false, inAchievements = false;

            foreach (string line in lines)
            {
                string trimmed = line.Trim();
                if (string.IsNullOrEmpty(trimmed)) { rtfContent += @"\par"; continue; }

                if (trimmed.Contains("ОТЧЕТ КУРАТОРА")) continue;
                else if (trimmed.StartsWith("Группа:") || trimmed.StartsWith("Куратор:") || trimmed.StartsWith("Количество студентов:") || trimmed.StartsWith("Период:") || trimmed.StartsWith("Дата формирования:"))
                    rtfContent += $@"{EscapeRtf(trimmed)}\par";
                else if (trimmed == "СПИСОК СТУДЕНТОВ") { rtfContent += @"\pard\fs28\b СПИСОК СТУДЕНТОВ\b0\fs24\par\pard\ql"; inStudents = true; inGrades = false; inStats = false; inAttendance = false; inEventAttendance = false; inAchievements = false; }
                else if (trimmed == "УСПЕВАЕМОСТЬ ГРУППЫ") { rtfContent += @"\pard\fs28\b УСПЕВАЕМОСТЬ ГРУППЫ\b0\fs24\par\pard\ql"; inStudents = false; inGrades = true; inStats = false; inAttendance = false; inEventAttendance = false; inAchievements = false; }
                else if (trimmed.Contains("СТАТИСТИКА УСПЕВАЕМОСТИ")) { rtfContent += @"\pard\fs28\b СТАТИСТИКА УСПЕВАЕМОСТИ (5-балльная шкала)\b0\fs24\par\pard\ql"; inStudents = false; inGrades = false; inStats = true; inAttendance = false; inEventAttendance = false; inAchievements = false; }
                else if (trimmed == "ПОСЕЩАЕМОСТЬ ЗАНЯТИЙ") { rtfContent += @"\pard\fs28\b ПОСЕЩАЕМОСТЬ ЗАНЯТИЙ\b0\fs24\par\pard\ql"; inStudents = false; inGrades = false; inStats = false; inAttendance = true; inEventAttendance = false; inAchievements = false; }
                else if (trimmed == "ПОСЕЩАЕМОСТЬ МЕРОПРИЯТИЙ") { rtfContent += @"\pard\fs28\b ПОСЕЩАЕМОСТЬ МЕРОПРИЯТИЙ\b0\fs24\par\pard\ql"; inStudents = false; inGrades = false; inStats = false; inAttendance = false; inEventAttendance = true; inAchievements = false; }
                else if (trimmed == "ДОСТИЖЕНИЯ СТУДЕНТОВ") { rtfContent += @"\pard\fs28\b ДОСТИЖЕНИЯ СТУДЕНТОВ\b0\fs24\par\pard\ql"; inStudents = false; inGrades = false; inStats = false; inAttendance = false; inEventAttendance = false; inAchievements = true; }
                else if (trimmed.Contains("Отчет сформирован автоматически")) rtfContent += $@"\pard\qc\fs20 {EscapeRtf(trimmed)}\fs24\par\pard\ql";
                else if (System.Text.RegularExpressions.Regex.IsMatch(trimmed, @"^\d+\.")) rtfContent += $@"\b {EscapeRtf(trimmed)}\b0\par";
                else if (trimmed.StartsWith("Телефон:") || trimmed.StartsWith("   -") || trimmed.StartsWith("Мероприятие:")) rtfContent += $@"\pard\li500 {EscapeRtf(trimmed)}\par\pard\ql";
                else rtfContent += $@"{EscapeRtf(trimmed)}\par";
            }

            rtfContent += @"}";
            System.IO.File.WriteAllText(filePath, rtfContent, System.Text.Encoding.Default);
        }

        private string EscapeRtf(string text)
        {
            return text.Replace(@"\", @"\\").Replace("{", @"\{").Replace("}", @"\}").Replace("_", @"\_");
        }

        private void SaveAsHtml(string filePath, string reportText)
        {
            string htmlContent = ConvertReportToHtml(reportText);
            System.IO.File.WriteAllText(filePath, htmlContent, System.Text.Encoding.UTF8);
        }

        private string ConvertReportToHtml(string reportText)
        {
            string html = $@"<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <title>Отчет куратора</title>
    <style>
        body {{ font-family: 'Times New Roman', Times, serif; font-size: 14pt; margin: 2cm; line-height: 1.3; }}
        h1 {{ font-size: 20pt; text-align: center; font-weight: bold; margin-bottom: 20px; }}
        h2 {{ font-size: 16pt; font-weight: bold; margin-top: 20px; margin-bottom: 10px; background-color: #f0f0f0; padding: 5px; }}
        .info {{ margin-bottom: 5px; }}
        .student-list, .grades, .stats, .attendance, .event-attendance, .achievements {{ margin-left: 20px; }}
        hr {{ margin: 15px 0; }}
        .footer {{ text-align: center; margin-top: 30px; font-size: 12pt; }}
        .student-name {{ font-weight: bold; margin-top: 10px; }}
        .bullet {{ margin-left: 20px; }}
    </style>
</head>
<body>
";
            string[] lines = reportText.Split('\n');
            bool inStudents = false, inGrades = false, inStats = false, inAttendance = false, inEventAttendance = false, inAchievements = false;

            foreach (string line in lines)
            {
                string trimmed = line.Trim();
                if (string.IsNullOrEmpty(trimmed)) continue;

                if (trimmed.Contains("ОТЧЕТ КУРАТОРА")) html += "<h1>ОТЧЕТ КУРАТОРА</h1>";
                else if (trimmed.StartsWith("Группа:") || trimmed.StartsWith("Куратор:") || trimmed.StartsWith("Количество студентов:") || trimmed.StartsWith("Период:") || trimmed.StartsWith("Дата формирования:"))
                {
                    html += $"<div class='info'>{EscapeHtml(trimmed)}</div>";
                    if (trimmed.StartsWith("Дата формирования:")) html += "<hr/>";
                }
                else if (trimmed == "СПИСОК СТУДЕНТОВ") { html += "<h2>СПИСОК СТУДЕНТОВ</h2><div class='student-list'>"; inStudents = true; inGrades = false; inStats = false; inAttendance = false; inEventAttendance = false; inAchievements = false; }
                else if (trimmed == "УСПЕВАЕМОСТЬ ГРУППЫ") { if (inStudents) html += "</div>"; html += "<h2>УСПЕВАЕМОСТЬ ГРУППЫ</h2><div class='grades'>"; inStudents = false; inGrades = true; inStats = false; inAttendance = false; inEventAttendance = false; inAchievements = false; }
                else if (trimmed.Contains("СТАТИСТИКА УСПЕВАЕМОСТИ")) { if (inGrades) html += "</div>"; html += "<h2>СТАТИСТИКА УСПЕВАЕМОСТИ (5-балльная шкала)</h2><div class='stats'>"; inGrades = false; inStats = true; inAttendance = false; inEventAttendance = false; inAchievements = false; }
                else if (trimmed == "ПОСЕЩАЕМОСТЬ ЗАНЯТИЙ") { if (inStats) html += "</div>"; html += "<h2>ПОСЕЩАЕМОСТЬ ЗАНЯТИЙ</h2><div class='attendance'>"; inStats = false; inAttendance = true; inEventAttendance = false; inAchievements = false; }
                else if (trimmed == "ПОСЕЩАЕМОСТЬ МЕРОПРИЯТИЙ") { if (inAttendance) html += "</div>"; html += "<h2>ПОСЕЩАЕМОСТЬ МЕРОПРИЯТИЙ</h2><div class='event-attendance'>"; inAttendance = false; inEventAttendance = true; inAchievements = false; }
                else if (trimmed == "ДОСТИЖЕНИЯ СТУДЕНТОВ") { if (inEventAttendance) html += "</div>"; html += "<h2>ДОСТИЖЕНИЯ СТУДЕНТОВ</h2><div class='achievements'>"; inEventAttendance = false; inAchievements = true; }
                else if (trimmed.Contains("Отчет сформирован автоматически")) { if (inAchievements) html += "</div>"; html += $"<div class='footer'>{EscapeHtml(trimmed)}</div>"; }
                else if (System.Text.RegularExpressions.Regex.IsMatch(trimmed, @"^\d+\.")) html += $"<p><strong>{EscapeHtml(trimmed)}</strong></p>";
                else if (trimmed.StartsWith("Телефон:") || trimmed.StartsWith("   -") || trimmed.StartsWith("Мероприятие:")) html += $"<p class='bullet'>{EscapeHtml(trimmed)}</p>";
                else html += $"<p>{EscapeHtml(trimmed)}</p>";
            }

            html += @"
</body>
</html>";
            return html;
        }

        private string EscapeHtml(string text)
        {
            return text.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (Program.MainForm != null) Program.MainForm.Close();
        }
    }
}