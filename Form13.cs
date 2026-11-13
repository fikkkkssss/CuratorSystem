using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace CuratorReportSystem
{
    public partial class Form13 : Form
    {
        private string connectionString = "Host=localhost;Port=5433;Database=kp;Username=postgres;Password=\"Q#Rto%g$$$5\"";

        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            if (Program.CurrentUserRole == "student")
            {
                lblGroup.Visible = false;
                cmbGroup.Visible = false;
                lblSubject.Visible = false;
                cmbSubject.Visible = false;
                lblDate.Visible = false;
                dtpDate.Visible = false;
                btnSave.Visible = false;
                btnRefresh.Visible = false;
                btnExport.Visible = false;

                this.Text = "Моя посещаемость";
                LoadStudentAttendance();
                return;
            }

            LoadGroups();
            LoadSubjects();
            dtpDate.Value = DateTime.Today;

            if (Program.CurrentUserRole == "curator")
            {
                cmbGroup.Enabled = false;
            }
        }

        private int GetSelectedId(ComboBox cmb, string idColumn)
        {
            if (cmb.SelectedItem == null) return 0;
            DataRowView drv = cmb.SelectedItem as DataRowView;
            if (drv != null) return Convert.ToInt32(drv[idColumn]);
            if (cmb.SelectedValue != null && cmb.SelectedValue != DBNull.Value) return Convert.ToInt32(cmb.SelectedValue);
            return 0;
        }

        private void LoadGroups()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query;
                    if (Program.CurrentUserRole == "curator")
                        query = @"SELECT group_id, group_name FROM ""group"" WHERE curator_id = @curator_id ORDER BY group_name";
                    else
                        query = @"SELECT group_id, group_name FROM ""group"" ORDER BY group_name";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        if (Program.CurrentUserRole == "curator")
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

        private void LoadAttendance()
        {
            int groupId = GetSelectedId(cmbGroup, "group_id");
            int subjectId = GetSelectedId(cmbSubject, "subject_id");

            if (groupId == 0 || subjectId == 0) return;

            try
            {
                DateTime date = dtpDate.Value.Date;

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            s.student_id,
                            u.last_name || ' ' || u.first_name AS student_name,
                            COALESCE(a.status, '') AS status,
                            COALESCE(a.comment, '') AS comment
                        FROM student s
                        JOIN users u ON s.user_id = u.user_id
                        LEFT JOIN attendance a ON a.student_id = s.student_id 
                            AND a.subject_id = @subject_id 
                            AND a.attendance_date = @date
                        WHERE s.group_id = @group_id
                        ORDER BY u.last_name, u.first_name";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@group_id", groupId);
                        cmd.Parameters.AddWithValue("@subject_id", subjectId);
                        cmd.Parameters.AddWithValue("@date", date);

                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dgvAttendance.DataSource = null;
                            dgvAttendance.Columns.Clear();
                            dgvAttendance.AutoGenerateColumns = false; // Отключаем авто, собираем вручную

                            // 1. Скрытая колонка ID
                            DataGridViewTextBoxColumn idCol = new DataGridViewTextBoxColumn();
                            idCol.Name = "student_id";
                            idCol.DataPropertyName = "student_id";
                            idCol.Visible = false;
                            dgvAttendance.Columns.Add(idCol);

                            // 2. Колонка ФИО (только для чтения)
                            DataGridViewTextBoxColumn nameCol = new DataGridViewTextBoxColumn();
                            nameCol.Name = "student_name";
                            nameCol.DataPropertyName = "student_name";
                            nameCol.HeaderText = "Студент";
                            nameCol.ReadOnly = true;
                            dgvAttendance.Columns.Add(nameCol);

                            // 3. Колонка Статус (ComboBox)
                            DataGridViewComboBoxColumn statusCol = new DataGridViewComboBoxColumn();
                            statusCol.Name = "status";
                            statusCol.DataPropertyName = "status";
                            statusCol.HeaderText = "Статус";
                            statusCol.FlatStyle = FlatStyle.Flat;
                            statusCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                            statusCol.Items.AddRange(
                                "",
                                "присутствовал",
                                "отсутствовал по уважительной",
                                "отсутствовал по неуважительной",
                                "болел"
                            );
                            dgvAttendance.Columns.Add(statusCol);

                            // 4. Колонка Комментарий
                            DataGridViewTextBoxColumn commentCol = new DataGridViewTextBoxColumn();
                            commentCol.Name = "comment";
                            commentCol.DataPropertyName = "comment";
                            commentCol.HeaderText = "Комментарий";
                            dgvAttendance.Columns.Add(commentCol);

                            dgvAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dgvAttendance.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки посещаемости: {ex.Message}"); }
        }

        private void LoadStudentAttendance()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            sub.subject_name AS subject,
                            a.attendance_date AS date,
                            a.status AS status,
                            COALESCE(a.comment, '') AS comment
                        FROM attendance a
                        JOIN student s ON a.student_id = s.student_id
                        JOIN subject sub ON a.subject_id = sub.subject_id
                        WHERE s.user_id = @user_id
                        ORDER BY a.attendance_date DESC";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user_id", Program.CurrentUserId);
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dgvAttendance.DataSource = null;
                            dgvAttendance.Columns.Clear();
                            dgvAttendance.AutoGenerateColumns = true;
                            dgvAttendance.DataSource = dt;

                            if (dgvAttendance.Columns["subject"] != null) dgvAttendance.Columns["subject"].HeaderText = "Предмет";
                            if (dgvAttendance.Columns["date"] != null) dgvAttendance.Columns["date"].HeaderText = "Дата";
                            if (dgvAttendance.Columns["status"] != null) dgvAttendance.Columns["status"].HeaderText = "Статус";
                            if (dgvAttendance.Columns["comment"] != null) dgvAttendance.Columns["comment"].HeaderText = "Комментарий";
                            dgvAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки: {ex.Message}"); }
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e) { LoadAttendance(); }
        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e) { LoadAttendance(); }
        private void dtpDate_ValueChanged(object sender, EventArgs e) { LoadAttendance(); }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (Program.CurrentUserRole == "student") LoadStudentAttendance();
            else LoadAttendance();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int groupId = GetSelectedId(cmbGroup, "group_id");
            int subjectId = GetSelectedId(cmbSubject, "subject_id");

            if (groupId == 0 || subjectId == 0)
            {
                MessageBox.Show("Выберите группу и предмет", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DateTime date = dtpDate.Value.Date;
                int addedBy = Program.CurrentUserId;

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        foreach (DataGridViewRow row in dgvAttendance.Rows)
                        {
                            if (row.IsNewRow) continue;
                            if (row.Cells["student_id"].Value == null) continue;

                            int studentId = Convert.ToInt32(row.Cells["student_id"].Value);
                            // Важно: берем значение из ячейки, а не из DataPropertyName
                            string status = row.Cells["status"].Value?.ToString() ?? "";
                            string comment = row.Cells["comment"].Value?.ToString() ?? "";

                            if (string.IsNullOrEmpty(status)) continue;

                            string checkQuery = @"SELECT attendance_id FROM attendance 
                                                  WHERE student_id = @student_id AND subject_id = @subject_id AND attendance_date = @date";

                            int? existingId = null;
                            using (var cmd = new NpgsqlCommand(checkQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@student_id", studentId);
                                cmd.Parameters.AddWithValue("@subject_id", subjectId);
                                cmd.Parameters.AddWithValue("@date", date);
                                var result = cmd.ExecuteScalar();
                                if (result != null && result != DBNull.Value) existingId = Convert.ToInt32(result);
                            }

                            if (existingId.HasValue)
                            {
                                string updateQuery = @"UPDATE attendance SET status = @status, comment = @comment WHERE attendance_id = @id";
                                using (var cmd = new NpgsqlCommand(updateQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@status", status);
                                    cmd.Parameters.AddWithValue("@comment", string.IsNullOrEmpty(comment) ? (object)DBNull.Value : comment);
                                    cmd.Parameters.AddWithValue("@id", existingId.Value);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                string insertQuery = @"INSERT INTO attendance (student_id, subject_id, attendance_date, status, comment, added_by)
                                                       VALUES (@student_id, @subject_id, @date, @status, @comment, @added_by)";
                                using (var cmd = new NpgsqlCommand(insertQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@student_id", studentId);
                                    cmd.Parameters.AddWithValue("@subject_id", subjectId);
                                    cmd.Parameters.AddWithValue("@date", date);
                                    cmd.Parameters.AddWithValue("@status", status);
                                    cmd.Parameters.AddWithValue("@comment", string.IsNullOrEmpty(comment) ? (object)DBNull.Value : comment);
                                    cmd.Parameters.AddWithValue("@added_by", addedBy);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        transaction.Commit();
                    }
                }

                MessageBox.Show("Посещаемость сохранена", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAttendance();
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка сохранения: {ex.Message}"); }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvAttendance.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для выгрузки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "HTML файл (*.html)|*.html";
            sfd.FileName = $"Посещаемость_{cmbGroup.Text}_{dtpDate.Value:dd.MM.yyyy}";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string html = "<html><head><meta charset='utf-8'><style>" +
                                  "body { font-family: 'Times New Roman', serif; font-size: 14pt; margin: 20px; }" +
                                  "h2 { text-align: center; }" +
                                  "table { width: 100%; border-collapse: collapse; margin-top: 20px; }" +
                                  "th, td { border: 1px solid black; padding: 8px; text-align: left; }" +
                                  "th { background-color: #f0f0f0; font-weight: bold; }" +
                                  "</style></head><body>" +
                                  "<h2>Посещаемость группы: " + cmbGroup.Text + "</h2>" +
                                  "<p><b>Предмет:</b> " + cmbSubject.Text + "</p>" +
                                  "<p><b>Дата:</b> " + dtpDate.Value.ToString("dd.MM.yyyy") + "</p>" +
                                  "<table><tr><th>Студент</th><th>Статус</th><th>Комментарий</th></tr>";

                    foreach (DataGridViewRow row in dgvAttendance.Rows)
                    {
                        if (row.IsNewRow) continue;
                        // Безопасное чтение ячеек
                        string student = row.Cells["student_name"].Value?.ToString() ?? "";
                        string status = row.Cells["status"].Value?.ToString() ?? "";
                        string comment = row.Cells["comment"].Value?.ToString() ?? "";
                        html += $"<tr><td>{student}</td><td>{status}</td><td>{comment}</td></tr>";
                    }

                    html += "</table></body></html>";

                    System.IO.File.WriteAllText(sfd.FileName, html, System.Text.Encoding.UTF8);
                    MessageBox.Show("Файл сохранен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show($"Ошибка сохранения: {ex.Message}"); }
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            if (Program.MainForm != null) Program.MainForm.Close();
        }
    }
}