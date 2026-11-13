using System;
using System.Drawing;
using System.Windows.Forms;

namespace CuratorReportSystem
{
    public partial class Form2 : Form
    {
        private Color activeColor = Color.FromArgb(240, 128, 128); // Красный (активная)
        private Color normalColor = Color.FromArgb(200, 190, 235); // Фиолетовый (обычная)

        public Form2()
        {
            InitializeComponent();
            Program.MainForm = this; // Запоминаем главное окно
            ConfigureMenuByRole();
            this.Text = $"ИС Куратора - {Program.CurrentUserLogin}";
        }

        private void ConfigureMenuByRole()
        {
            // Сначала скрываем ВСЕ кнопки (btnGroups здесь больше нет)
            Guna.UI2.WinForms.Guna2Button[] allButtons = {
                btnUsers, btnSubjects, btnAttendance, btnStudents,
                btnEvents, btnReport, btnGrades, btnLogs, btnAchievements
            };

            foreach (var btn in allButtons) btn.Visible = false;

            // Настройки в зависимости от роли
            if (Program.CurrentUserRole == "admin" || Program.CurrentUserRole == "administrator")
            {
                lblRole.Text = "Администратор";
                btnUsers.Visible = true;
                btnSubjects.Visible = true;
                btnSubjects.Text = "Предметы и Группы";
                btnAttendance.Visible = true;
                btnStudents.Visible = true;
                btnEvents.Visible = true;
                btnReport.Visible = true;
                btnGrades.Visible = true;
                btnLogs.Visible = true;
                btnAchievements.Visible = true;
            }
            else if (Program.CurrentUserRole == "curator")
            {
                lblRole.Text = "Куратор";
                btnStudents.Visible = true;
                btnAttendance.Visible = true;
                btnEvents.Visible = true;
                btnGrades.Visible = true;
                btnReport.Visible = true;
                btnAchievements.Visible = true;
            }
            else if (Program.CurrentUserRole == "student")
            {
                lblRole.Text = "Студент";

                btnAttendance.Visible = true;
                btnAttendance.Text = "Посещаемость";

                btnGrades.Visible = true;
                btnGrades.Text = "Оценки";

                btnEvents.Visible = true;
                btnEvents.Text = "Мероприятия";

                btnAchievements.Visible = true;
                btnAchievements.Text = "Достижения";
            }

            // Выстраиваем оставшиеся кнопки в ровный столбик
            int startY = 40;
            int spacing = 70;
            int btnWidth = 260;

            foreach (var btn in allButtons)
            {
                if (btn.Visible)
                {
                    btn.Location = new Point(20, startY);
                    btn.Size = new Size(btnWidth, 50);
                    btn.BorderRadius = 25;
                    btn.FillColor = normalColor;
                    startY += spacing;
                }
            }
        }

        // --- МЕТОД ДЛЯ ОТКРЫТИЯ ФОРМ ---
        public void OpenForm(Form form, Guna.UI2.WinForms.Guna2Button activeButton)
        {
            panelContent.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelContent.Controls.Add(form);
            form.Show();

            ResetButtonColors();

            if (activeButton != null)
            {
                activeButton.FillColor = activeColor;
            }
        }

        private void ResetButtonColors()
        {
            // btnGroups здесь тоже больше нет
            Guna.UI2.WinForms.Guna2Button[] allButtons = {
                btnUsers, btnSubjects, btnAttendance, btnStudents,
                btnEvents, btnReport, btnGrades, btnLogs, btnAchievements
            };

            foreach (var btn in allButtons)
            {
                btn.FillColor = normalColor;
            }
        }

        // ==========================================
        // ОТКРЫТИЕ ВСЕХ ФОРМ
        // ==========================================

        private void btnUsers_Click(object sender, EventArgs e) { OpenForm(new Form7(), btnUsers); }
        private void btnStudents_Click(object sender, EventArgs e) { OpenForm(new Form3(), btnStudents); }
        private void btnAttendance_Click(object sender, EventArgs e) { OpenForm(new Form13(), btnAttendance); }
        private void btnLogs_Click(object sender, EventArgs e) { OpenForm(new Form11(), btnLogs); }

        // Предметы и Группы теперь в одной форме Form9
        private void btnSubjects_Click(object sender, EventArgs e) { OpenForm(new Form9(), btnSubjects); }

        private void btnEvents_Click(object sender, EventArgs e) { OpenForm(new Form5(), btnEvents); }
        private void btnReport_Click(object sender, EventArgs e) { OpenForm(new Form6(), btnReport); }
        private void btnGrades_Click(object sender, EventArgs e) { OpenForm(new Form4(), btnGrades); }
        private void btnAchievements_Click(object sender, EventArgs e) { OpenForm(new Form8(), btnAchievements); }

        // --- ВЫХОД ИЗ ГЛАВНОГО МЕНЮ ---
        private void btnExit_Click(object sender, EventArgs e)
        {
            Program.CurrentUserId = 0;
            Program.CurrentUserRole = "";
            Program.CurrentUserLogin = "";
            Program.CurrentUserGroupId = 0;

            this.Close(); // Программа вернется в цикл авторизации
        }
    }
}