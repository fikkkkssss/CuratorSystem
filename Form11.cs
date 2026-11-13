using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace CuratorReportSystem
{
    public partial class Form11 : Form
    {
        private string connectionString = "Host=localhost;Port=5433;Database=kp;Username=postgres;Password=\"Q#Rto%g$$$5\"";

        public Form11()
        {
            InitializeComponent();
            LoadLogs();

            // Включаем растягивание таблицы
            this.Load += (s, e) => AdjustTableSize();
            this.Resize += (s, e) => AdjustTableSize();
        }

        // Метод для растягивания таблицы до кнопок
        private void AdjustTableSize()
        {
            int topY = 100; // Отступ от заголовка
            int bottomY = btnRefresh.Top - 20; // Верх кнопки "Обновить" минус отступ
            int newHeight = bottomY - topY;

            if (newHeight < 100) newHeight = 100;

            dgvLogs.Height = newHeight;
        }

        private void LoadLogs()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT log_id, grade_id, student_id, action, 
                                            old_grade, new_grade, changed_by, changed_at
                                     FROM grade_log 
                                     ORDER BY changed_at DESC";

                    using (var adapter = new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvLogs.DataSource = dt;

                        // Растягиваем колонки на всю ширину
                        dgvLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        // Настройка заголовков
                        if (dgvLogs.Columns["log_id"] != null) dgvLogs.Columns["log_id"].HeaderText = "ID лога";
                        if (dgvLogs.Columns["grade_id"] != null) dgvLogs.Columns["grade_id"].HeaderText = "ID оценки";
                        if (dgvLogs.Columns["student_id"] != null) dgvLogs.Columns["student_id"].HeaderText = "ID студента";
                        if (dgvLogs.Columns["action"] != null) dgvLogs.Columns["action"].HeaderText = "Действие";
                        if (dgvLogs.Columns["old_grade"] != null) dgvLogs.Columns["old_grade"].HeaderText = "Старая оценка";
                        if (dgvLogs.Columns["new_grade"] != null) dgvLogs.Columns["new_grade"].HeaderText = "Новая оценка";
                        if (dgvLogs.Columns["changed_by"] != null) dgvLogs.Columns["changed_by"].HeaderText = "Кто изменил";
                        if (dgvLogs.Columns["changed_at"] != null) dgvLogs.Columns["changed_at"].HeaderText = "Дата изменения";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки логов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLogs();
        }

        // ИСПРАВЛЕННЫЙ ВЫХОД
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (Program.MainForm != null)
            {
                Program.MainForm.Close();
            }
        }
    }
}