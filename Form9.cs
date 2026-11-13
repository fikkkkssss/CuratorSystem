using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace CuratorReportSystem
{
    public partial class Form9 : Form
    {
        private string connectionString = "Host=localhost;Port=5433;Database=kp;Username=postgres;Password=\"Q#Rto%g$$$5\"";

        public Form9()
        {
            InitializeComponent();
            LoadSubjects();
            LoadGroups();
            LoadCurators();

            // Скрываем ID из таблицы предметов
            if (dgvSubjects.Columns["subject_id"] != null) dgvSubjects.Columns["subject_id"].Visible = false;
            if (dgvGroups.Columns["group_id"] != null) dgvGroups.Columns["group_id"].Visible = false;
        }

        // --- ЗАГРУЗКА ПРЕДМЕТОВ ---
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
                        dgvSubjects.DataSource = dt;

                        if (dgvSubjects.Columns["subject_name"] != null)
                            dgvSubjects.Columns["subject_name"].HeaderText = "Название предмета";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки предметов: {ex.Message}"); }
        }

        // --- ЗАГРУЗКА ГРУПП ---
        private void LoadGroups()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT g.group_id, g.group_name, g.kod_group, 
                                            COALESCE(u.last_name || ' ' || u.first_name, '(без куратора)') as curator_name
                                     FROM ""group"" g
                                     LEFT JOIN users u ON g.curator_id = u.user_id
                                     ORDER BY g.group_name";
                    using (var adapter = new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvGroups.DataSource = dt;

                        if (dgvGroups.Columns["group_name"] != null) dgvGroups.Columns["group_name"].HeaderText = "Название";
                        if (dgvGroups.Columns["kod_group"] != null) dgvGroups.Columns["kod_group"].HeaderText = "Код";
                        if (dgvGroups.Columns["curator_name"] != null) dgvGroups.Columns["curator_name"].HeaderText = "Куратор";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки групп: {ex.Message}"); }
        }

        // --- ЗАГРУЗКА КУРАТОРОВ ДЛЯ ВЫБОРА ---
        private void LoadCurators()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT u.user_id, u.last_name || ' ' || u.first_name as curator_name
                                     FROM users u
                                     JOIN roles r ON u.role_id = r.role_id
                                     WHERE r.role_name = 'curator'
                                     ORDER BY u.last_name, u.first_name";

                    DataTable dt = new DataTable();
                    using (var adapter = new NpgsqlDataAdapter(query, conn)) adapter.Fill(dt);

                    DataRow emptyRow = dt.NewRow();
                    emptyRow["user_id"] = DBNull.Value;
                    emptyRow["curator_name"] = "(без куратора)";
                    dt.Rows.InsertAt(emptyRow, 0);

                    cmbCurator.DataSource = dt;
                    cmbCurator.DisplayMember = "curator_name";
                    cmbCurator.ValueMember = "user_id";
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка загрузки кураторов: {ex.Message}"); }
        }

        // --- ДОБАВЛЕНИЕ ПРЕДМЕТА ---
        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            string subjectName = txtSubjectName.Text.Trim();
            if (string.IsNullOrEmpty(subjectName)) { MessageBox.Show("Введите название предмета"); return; }

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO subject (subject_name) VALUES (@name)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", subjectName);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Предмет добавлен");
                txtSubjectName.Clear();
                LoadSubjects();
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка добавления: {ex.Message}"); }
        }

        // --- УДАЛЕНИЕ ПРЕДМЕТА ---
        private void btnDeleteSubject_Click(object sender, EventArgs e)
        {
            if (dgvSubjects.CurrentRow == null) { MessageBox.Show("Выберите предмет"); return; }

            int subjectId = Convert.ToInt32(dgvSubjects.CurrentRow.Cells["subject_id"].Value);
            string subjectName = dgvSubjects.CurrentRow.Cells["subject_name"].Value.ToString();

            if (MessageBox.Show($"Удалить предмет \"{subjectName}\"?\nОценки по нему также удалятся.", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = new NpgsqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM subject WHERE subject_id = @id";
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", subjectId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Предмет удален");
                    LoadSubjects();
                }
                catch (Exception ex) { MessageBox.Show($"Ошибка удаления: {ex.Message}"); }
            }
        }

        // --- ДОБАВЛЕНИЕ ГРУППЫ ---
        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            string groupName = txtGroupName.Text.Trim();
            string kodGroup = txtKodGroup.Text.Trim();
            object curatorId = cmbCurator.SelectedValue;

            if (string.IsNullOrEmpty(groupName)) { MessageBox.Show("Введите название группы"); return; }

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO ""group"" (group_name, kod_group, curator_id) 
                                     VALUES (@group_name, @kod_group, @curator_id)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@group_name", groupName);
                        cmd.Parameters.AddWithValue("@kod_group", string.IsNullOrEmpty(kodGroup) ? (object)DBNull.Value : kodGroup);
                        cmd.Parameters.AddWithValue("@curator_id", (curatorId != null && curatorId != DBNull.Value) ? curatorId : DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Группа добавлена");
                txtGroupName.Clear();
                txtKodGroup.Clear();
                LoadGroups();
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
        }

        // --- УДАЛЕНИЕ ГРУППЫ (ВЫЗЫВАЕТСЯ ПРИ ДВОЙНОМ КЛИКЕ ИЛИ КНОПКОЙ) ---
        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            if (dgvGroups.CurrentRow == null) return;
            int groupId = Convert.ToInt32(dgvGroups.CurrentRow.Cells["group_id"].Value);
            string groupName = dgvGroups.CurrentRow.Cells["group_name"].Value.ToString();

            if (MessageBox.Show($"Удалить группу \"{groupName}\"?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = new NpgsqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM \"group\" WHERE group_id = @id";
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", groupId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Группа удалена");
                    LoadGroups();
                }
                catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSubjects();
            LoadGroups();
            LoadCurators();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (Program.MainForm != null) Program.MainForm.Close();
        }

        private void cmbCurator_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblKodGroup_Click(object sender, EventArgs e)
        {

        }
    }
}