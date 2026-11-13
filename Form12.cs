using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CuratorReportSystem
{
    public partial class Form12 : Form
    {
        private string connectionString = "Host=localhost;Port=5433;Database=kp;Username=postgres;Password=\"Q#Rto%g$$$5\"";
        private int groupId = 0;
        private string currentFilter = "all";

        public Form12(int groupId)
        {
            InitializeComponent();
            this.groupId = groupId;

            LoadGroupName();
            LoadSubjects();
            LoadData();
        }

        private void LoadGroupName()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT group_name FROM \"group\" WHERE group_id = @groupId";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@groupId", groupId);
                        object result = cmd.ExecuteScalar();
                        if (result != null) this.Text = $"Анализ успеваемости - {result}";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
        }

        private void LoadSubjects()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT 0 as subject_id, 'Все предметы' as subject_name UNION SELECT subject_id, subject_name FROM subject ORDER BY subject_id";
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

        private void LoadData()
        {
            LoadStatistics();
            LoadStudentList();
            LoadChart();
        }

        private int GetSelectedSubjectId()
        {
            if (cmbSubject.SelectedItem == null) return 0;
            DataRowView drv = cmbSubject.SelectedItem as DataRowView;
            if (drv != null) return Convert.ToInt32(drv["subject_id"]);
            if (cmbSubject.SelectedValue != null) return Convert.ToInt32(cmbSubject.SelectedValue);
            return 0;
        }

        private string GetStudentStatus(double avgGrade, bool hasBadGrade, int skipTotal, int skipInvalid)
        {
            if (hasBadGrade || skipInvalid >= 2 || skipTotal >= 5) return "риск";
            if (avgGrade < 4.0 || skipTotal >= 1) return "внимание";
            return "норма";
        }

        private void LoadStatistics()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    int subjectId = GetSelectedSubjectId();
                    string subjectCondition = subjectId > 0 ? $"AND g.subject_id = {subjectId}" : "";

                    string query = $@"
                        SELECT 
                            s.student_id,
                            COALESCE(ROUND(AVG(g.grade_value), 2), 0) as avg_grade
                        FROM student s
                        LEFT JOIN grade g ON s.student_id = g.student_id
                        WHERE s.group_id = @groupId {subjectCondition}
                        GROUP BY s.student_id";

                    int excellent = 0, good = 0, satisfactory = 0, bad = 0, total = 0;

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@groupId", groupId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                total++;
                                double avgGrade = Convert.ToDouble(reader["avg_grade"]);

                                if (avgGrade >= 4.5) excellent++;
                                else if (avgGrade >= 3.5) good++;
                                else if (avgGrade >= 2.5) satisfactory++;
                                else bad++;
                            }
                        }
                    }

                    lblTotal.Text = $"Всего: {total}";
                    lblExcellent.Text = $"Отличники: {excellent}";
                    lblGood.Text = $"Хорошисты: {good}";
                    lblSatisfactory.Text = $"Троечники: {satisfactory}";
                    lblBad.Text = $"Двоечники: {bad}";
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
        }

        private void LoadStudentList()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    int subjectId = GetSelectedSubjectId();
                    string subjectCondition = subjectId > 0 ? $"AND g.subject_id = {subjectId}" : "";

                    string query = $@"
                        SELECT 
                            s.student_id,
                            u.last_name || ' ' || u.first_name AS student_name,
                            COALESCE(ROUND(AVG(g.grade_value), 2), 0) as avg_grade,
                            COUNT(g.grade_id) as total_grades,
                            CASE WHEN COUNT(CASE WHEN g.grade_value <= 2 THEN 1 END) > 0 THEN 1 ELSE 0 END as has_bad,
                            (SELECT COUNT(*) FROM attendance a WHERE a.student_id = s.student_id) as skip_total,
                            (SELECT COUNT(*) FROM attendance a WHERE a.student_id = s.student_id AND a.status = 'отсутствовал по неуважительной') as skip_invalid
                        FROM student s
                        JOIN users u ON s.user_id = u.user_id
                        LEFT JOIN grade g ON s.student_id = g.student_id
                        WHERE s.group_id = @groupId {subjectCondition}
                        GROUP BY s.student_id, u.last_name, u.first_name
                        ORDER BY avg_grade DESC";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@groupId", groupId);
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            DataTable displayDt = new DataTable();
                            displayDt.Columns.Add("student_id", typeof(int));
                            displayDt.Columns.Add("student_name", typeof(string));
                            displayDt.Columns.Add("avg_grade_display", typeof(string));
                            displayDt.Columns.Add("skip_total", typeof(int));
                            displayDt.Columns.Add("status", typeof(string));

                            foreach (DataRow row in dt.Rows)
                            {
                                double avgGrade = Convert.ToDouble(row["avg_grade"]);
                                int studentId = Convert.ToInt32(row["student_id"]);
                                int totalGrades = Convert.ToInt32(row["total_grades"]);
                                int skipTotal = Convert.ToInt32(row["skip_total"]);
                                bool hasBad = Convert.ToInt32(row["has_bad"]) == 1;
                                int skipInvalid = Convert.ToInt32(row["skip_invalid"]);

                                string status = GetStudentStatus(avgGrade, hasBad, skipTotal, skipInvalid);

                                bool include = false;
                                switch (currentFilter)
                                {
                                    case "excellent": include = avgGrade >= 4.5; break;
                                    case "good": include = avgGrade >= 3.5 && avgGrade < 4.5; break;
                                    case "satisfactory": include = avgGrade >= 2.5 && avgGrade < 3.5; break;
                                    case "bad": include = avgGrade < 2.5; break;
                                    case "risk": include = hasBad || skipInvalid >= 2 || skipTotal >= 5; break;
                                    default: include = true; break;
                                }

                                if (include)
                                {
                                    DataRow newRow = displayDt.NewRow();
                                    newRow["student_id"] = studentId;
                                    newRow["student_name"] = row["student_name"];
                                    newRow["avg_grade_display"] = (totalGrades == 0 || avgGrade == 0) ? "нет оценок" : avgGrade.ToString("F2");
                                    newRow["skip_total"] = skipTotal;
                                    newRow["status"] = status;
                                    displayDt.Rows.Add(newRow);
                                }
                            }

                            dgvStudents.DataSource = displayDt;

                            if (dgvStudents.Columns["student_id"] != null) dgvStudents.Columns["student_id"].Visible = false;
                            if (dgvStudents.Columns["student_name"] != null) dgvStudents.Columns["student_name"].HeaderText = "Студент";
                            if (dgvStudents.Columns["avg_grade_display"] != null) dgvStudents.Columns["avg_grade_display"].HeaderText = "Средний балл";
                            if (dgvStudents.Columns["skip_total"] != null) dgvStudents.Columns["skip_total"].HeaderText = "Пропусков";
                            if (dgvStudents.Columns["status"] != null) dgvStudents.Columns["status"].HeaderText = "Статус";

                            lblCount.Text = $"Студентов: {displayDt.Rows.Count}";
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки: {ex.Message}"); }
        }

        private void LoadChart()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    int subjectId = GetSelectedSubjectId();
                    string subjectCondition = subjectId > 0 ? $"AND g.subject_id = {subjectId}" : "";

                    string query = $@"
                        SELECT 
                            s.student_id,
                            COALESCE(ROUND(AVG(g.grade_value), 2), 0) as avg_grade
                        FROM student s
                        LEFT JOIN grade g ON s.student_id = g.student_id
                        WHERE s.group_id = @groupId {subjectCondition}
                        GROUP BY s.student_id";

                    int excellent = 0, good = 0, satisfactory = 0, bad = 0;

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@groupId", groupId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                double avgGrade = Convert.ToDouble(reader["avg_grade"]);

                                if (avgGrade >= 4.5) excellent++;
                                else if (avgGrade >= 3.5) good++;
                                else if (avgGrade >= 2.5) satisfactory++;
                                else bad++;
                            }
                        }
                    }

                    chart.Series.Clear();
                    Series series = new Series("Успеваемость");
                    series.ChartType = SeriesChartType.Column;
                    series.IsValueShownAsLabel = true;
                    series.Color = Color.FromArgb(200, 190, 235);

                    series.Points.AddXY("Отличники", excellent);
                    series.Points.AddXY("Хорошисты", good);
                    series.Points.AddXY("Троечники", satisfactory);
                    series.Points.AddXY("Двоечники", bad);

                    chart.Series.Add(series);
                    chart.Titles.Clear();
                    chart.Titles.Add("Распределение студентов");
                    chart.ChartAreas[0].AxisX.Title = "Категория";
                    chart.ChartAreas[0].AxisY.Title = "Количество студентов";
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки диаграммы: {ex.Message}"); }
        }

        private void btnAll_Click(object sender, EventArgs e) { currentFilter = "all"; LoadStudentList(); }
        private void btnExcellent_Click(object sender, EventArgs e) { currentFilter = "excellent"; LoadStudentList(); }
        private void btnGood_Click(object sender, EventArgs e) { currentFilter = "good"; LoadStudentList(); }
        private void btnSatisfactory_Click(object sender, EventArgs e) { currentFilter = "satisfactory"; LoadStudentList(); }
        private void btnBad_Click(object sender, EventArgs e) { currentFilter = "bad"; LoadStudentList(); }
        private void btnRisk_Click(object sender, EventArgs e) { currentFilter = "risk"; LoadStudentList(); }
        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e) { LoadData(); }
        private void btnRefresh_Click(object sender, EventArgs e) { LoadData(); }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- ИСПРАВЛЕННАЯ ФУНКЦИЯ ЭКСПОРТА ---
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvStudents.Rows.Count == 0 || dgvStudents.Rows[0].Cells[0].Value == null)
            {
                MessageBox.Show("Нет данных для экспорта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            string title = "";
            switch (currentFilter)
            {
                case "excellent": title = "Отличники"; break;
                case "good": title = "Хорошисты"; break;
                case "satisfactory": title = "Троечники"; break;
                case "bad": title = "Двоечники"; break;
                case "risk": title = "Группа риска"; break;
                default: title = "Все студенты"; break;
            }

            saveFileDialog.Filter = "Word документы (*.doc)|*.doc|Текстовые файлы (*.txt)|*.txt|HTML файлы (*.html)|*.html";
            saveFileDialog.DefaultExt = "doc";
            saveFileDialog.FileName = $"{title}_{DateTime.Now:yyyyMMdd_HHmmss}";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = saveFileDialog.FileName;

                    if (filePath.EndsWith(".doc"))
                    {
                        SaveAsRtf(filePath, title);
                    }
                    else if (filePath.EndsWith(".html"))
                    {
                        SaveAsHtml(filePath, title);
                    }
                    else
                    {
                        SaveAsTextFile(filePath, title);
                    }

                    MessageBox.Show("Список сохранен", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveAsRtf(string filePath, string title)
        {
            string content = GenerateRtfContent(title);
            File.WriteAllText(filePath, content, Encoding.Default);
        }

        private void SaveAsHtml(string filePath, string title)
        {
            string content = GenerateHtmlContent(title);
            File.WriteAllText(filePath, content, Encoding.UTF8);
        }

        private void SaveAsTextFile(string filePath, string title)
        {
            string content = GenerateTextContent(title);
            File.WriteAllText(filePath, content, Encoding.UTF8);
        }

        private string GenerateRtfContent(string title)
        {
            string rtf = @"{\rtf1\ansi\deff0 {\fonttbl {\f0 Times New Roman;}}\f0\fs24
\pard\qc\fs32\b СПИСОК СТУДЕНТОВ - " + EscapeRtf(title.ToUpper()) + @"\b0\fs24\par
\pard\ql\par
\b Группа:\b0 " + EscapeRtf(lblTotal.Text) + @"\par
\b Дата формирования:\b0 " + DateTime.Now.ToString("dd.MM.yyyy") + @"\par\par";

            if (currentFilter == "bad" || currentFilter == "risk")
            {
                rtf += @"\pard\b\fs28 " + EscapeRtf(title) + @"\b0\fs24\par\pard\ql\par
\b\tab №\tab ФИО Студента\tab\tab Средний балл\tab\tab Пропусков\tab\tab Статус\b0\par
\line\par";

                int num = 1;
                foreach (DataGridViewRow row in dgvStudents.Rows)
                {
                    if (row.IsNewRow) continue;
                    string studentName = EscapeRtf(row.Cells[1].Value?.ToString() ?? ""); // Используем индексы
                    string avgGrade = EscapeRtf(row.Cells[2].Value?.ToString() ?? "");
                    string skipTotal = EscapeRtf(row.Cells[3].Value?.ToString() ?? "");
                    string status = EscapeRtf(row.Cells[4].Value?.ToString() ?? "");
                    rtf += $@"\pard\ql\b {num}\b0\tab {studentName}\tab\tab {avgGrade}\tab\tab {skipTotal}\tab\tab {status}\par";
                    num++;
                }
            }
            else
            {
                string category = "";
                switch (currentFilter)
                {
                    case "excellent": category = "Отличники"; break;
                    case "good": category = "Хорошисты"; break;
                    case "satisfactory": category = "Троечники"; break;
                    default: category = "Все студенты"; break;
                }

                rtf += @"\pard\b\fs28 " + EscapeRtf(category) + @"\b0\fs24\par\pard\ql\par
\b\tab №\tab ФИО Студента\tab\tab Средний балл\b0\par
\line\par";

                int num = 1;
                foreach (DataGridViewRow row in dgvStudents.Rows)
                {
                    if (row.IsNewRow) continue;
                    string studentName = EscapeRtf(row.Cells[1].Value?.ToString() ?? "");
                    string avgGrade = EscapeRtf(row.Cells[2].Value?.ToString() ?? "");
                    rtf += $@"\pard\ql\b {num}\b0\tab {studentName}\tab\tab {avgGrade}\par";
                    num++;
                }
            }

            rtf += @"\par\pard\qc Всего: " + dgvStudents.Rows.Count + @" студентов\par";
            rtf += @"}";

            return rtf;
        }

        private string GenerateHtmlContent(string title)
        {
            string html = $@"<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <title>Список студентов - {title}</title>
    <style>
        body {{ font-family: 'Times New Roman', Times, serif; font-size: 14pt; margin: 2cm; }}
        h1 {{ text-align: center; font-size: 20pt; }}
        table {{ border-collapse: collapse; width: 100%; margin-top: 20px; }}
        th, td {{ border: 1px solid black; padding: 8px; text-align: left; }}
        th {{ background-color: #f0f0f0; }}
        .footer {{ text-align: center; margin-top: 30px; }}
    </style>
</head>
<body>
    <h1>СПИСОК СТУДЕНТОВ - {title.ToUpper()}</h1>
    <p><strong>Группа:</strong> {lblTotal.Text}</p>
    <p><strong>Дата формирования:</strong> {DateTime.Now:dd.MM.yyyy}</p>";

            if (currentFilter == "bad" || currentFilter == "risk")
            {
                html += @"
<table>
    <tr><th>№</th><th>ФИО Студента</th><th>Средний балл</th><th>Пропусков</th><th>Статус</th></tr>";
                int num = 1;
                foreach (DataGridViewRow row in dgvStudents.Rows)
                {
                    if (row.IsNewRow) continue;
                    string studentName = EscapeHtml(row.Cells[1].Value?.ToString() ?? "");
                    string avgGrade = EscapeHtml(row.Cells[2].Value?.ToString() ?? "");
                    string skipTotal = EscapeHtml(row.Cells[3].Value?.ToString() ?? "");
                    string status = EscapeHtml(row.Cells[4].Value?.ToString() ?? "");
                    html += $@"
    <tr><td>{num}</td><td>{studentName}</td><td>{avgGrade}</td><td>{skipTotal}</td><td>{status}</td></tr>";
                    num++;
                }
                html += @"
</table>";
            }
            else
            {
                html += @"
<table>
    <tr><th>№</th><th>ФИО Студента</th><th>Средний балл</th></tr>";
                int num = 1;
                foreach (DataGridViewRow row in dgvStudents.Rows)
                {
                    if (row.IsNewRow) continue;
                    string studentName = EscapeHtml(row.Cells[1].Value?.ToString() ?? "");
                    string avgGrade = EscapeHtml(row.Cells[2].Value?.ToString() ?? "");
                    html += $@"
    <tr><td>{num}</td><td>{studentName}</td><td>{avgGrade}</td></tr>";
                    num++;
                }
                html += @"
</table>";
            }

            html += $@"
    <p class='footer'>Всего: {dgvStudents.Rows.Count} студентов</p>
</body>
</html>";
            return html;
        }

        private string GenerateTextContent(string title)
        {
            string content = $"СПИСОК СТУДЕНТОВ - {title.ToUpper()}\n";
            content += $"Группа: {lblTotal.Text}\n";
            content += $"Дата формирования: {DateTime.Now:dd.MM.yyyy}\n";
            content += "═══════════════════════════════════════════════════════════════════════════════════════\n\n";

            if (currentFilter == "bad" || currentFilter == "risk")
            {
                content += "№   ФИО Студента                              Средний балл    Пропусков    Статус\n";
                content += "───────────────────────────────────────────────────────────────────────────────────\n";

                int num = 1;
                foreach (DataGridViewRow row in dgvStudents.Rows)
                {
                    if (row.IsNewRow) continue;
                    string studentName = row.Cells[1].Value?.ToString() ?? "";
                    string avgGrade = row.Cells[2].Value?.ToString() ?? "";
                    string skipTotal = row.Cells[3].Value?.ToString() ?? "";
                    string status = row.Cells[4].Value?.ToString() ?? "";
                    content += $"{num,-3}  {studentName,-35} {avgGrade,-12} {skipTotal,-12} {status}\n";
                    num++;
                }
            }
            else
            {
                content += "№   ФИО Студента                              Средний балл\n";
                content += "───────────────────────────────────────────────────────────\n";

                int num = 1;
                foreach (DataGridViewRow row in dgvStudents.Rows)
                {
                    if (row.IsNewRow) continue;
                    string studentName = row.Cells[1].Value?.ToString() ?? "";
                    string avgGrade = row.Cells[2].Value?.ToString() ?? "";
                    content += $"{num,-3}  {studentName,-35} {avgGrade}\n";
                    num++;
                }
            }

            content += "\n═══════════════════════════════════════════════════════════════════════════════════════\n";
            content += $"Всего: {dgvStudents.Rows.Count} студентов";

            return content;
        }

        private string EscapeRtf(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            return text.Replace(@"\", @"\\")
                       .Replace("{", @"\{")
                       .Replace("}", @"\}")
                       .Replace("_", @"\_");
        }

        private string EscapeHtml(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            return text.Replace("&", "&amp;")
                       .Replace("<", "&lt;")
                       .Replace(">", "&gt;")
                       .Replace("\"", "&quot;");
        }
    }
}