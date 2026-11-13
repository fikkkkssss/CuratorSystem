using Guna.UI2.WinForms;

namespace CuratorReportSystem
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblRole;

        // Кнопка btnGroups УДАЛЕНА
        private Guna2Button btnUsers;
        private Guna2Button btnSubjects; // Переименована в "Предметы и Группы"
        private Guna2Button btnAttendance;
        private Guna2Button btnStudents;
        private Guna2Button btnEvents;
        private Guna2Button btnReport;
        private Guna2Button btnGrades;
        private Guna2Button btnLogs;
        private Guna2Button btnAchievements;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnStudents = new Guna.UI2.WinForms.Guna2Button();
            this.btnAchievements = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogs = new Guna.UI2.WinForms.Guna2Button();
            this.btnGrades = new Guna.UI2.WinForms.Guna2Button();
            this.btnReport = new Guna.UI2.WinForms.Guna2Button();
            this.btnEvents = new Guna.UI2.WinForms.Guna2Button();
            this.btnAttendance = new Guna.UI2.WinForms.Guna2Button();
            this.btnSubjects = new Guna.UI2.WinForms.Guna2Button();
            this.btnUsers = new Guna.UI2.WinForms.Guna2Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.lblRole = new System.Windows.Forms.Label();
            this.panelSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.panelSidebar.Controls.Add(this.btnStudents);
            this.panelSidebar.Controls.Add(this.btnAchievements);
            this.panelSidebar.Controls.Add(this.btnLogs);
            this.panelSidebar.Controls.Add(this.btnGrades);
            this.panelSidebar.Controls.Add(this.btnReport);
            this.panelSidebar.Controls.Add(this.btnEvents);
            this.panelSidebar.Controls.Add(this.btnAttendance);
            this.panelSidebar.Controls.Add(this.btnSubjects);
            this.panelSidebar.Controls.Add(this.btnUsers);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(300, 900);
            this.panelSidebar.TabIndex = 0;
            // 
            // btnStudents
            // 
            this.btnStudents.BorderRadius = 20;
            this.btnStudents.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(190)))), ((int)(((byte)(235)))));
            this.btnStudents.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnStudents.ForeColor = System.Drawing.Color.Black;
            this.btnStudents.Location = new System.Drawing.Point(30, 270);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Size = new System.Drawing.Size(240, 50);
            this.btnStudents.TabIndex = 3;
            this.btnStudents.Text = "Студенты";
            this.btnStudents.Click += new System.EventHandler(this.btnStudents_Click);
            // 
            // btnAchievements
            // 
            this.btnAchievements.BorderRadius = 20;
            this.btnAchievements.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(190)))), ((int)(((byte)(235)))));
            this.btnAchievements.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnAchievements.ForeColor = System.Drawing.Color.Black;
            this.btnAchievements.Location = new System.Drawing.Point(30, 525);
            this.btnAchievements.Name = "btnAchievements";
            this.btnAchievements.Size = new System.Drawing.Size(240, 50);
            this.btnAchievements.TabIndex = 8;
            this.btnAchievements.Text = "Достижения";
            this.btnAchievements.Click += new System.EventHandler(this.btnAchievements_Click);
            // 
            // btnLogs
            // 
            this.btnLogs.BorderRadius = 20;
            this.btnLogs.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(190)))), ((int)(((byte)(235)))));
            this.btnLogs.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnLogs.ForeColor = System.Drawing.Color.Black;
            this.btnLogs.Location = new System.Drawing.Point(30, 780);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(240, 50);
            this.btnLogs.TabIndex = 7;
            this.btnLogs.Text = "Логи оценок";
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);
            // 
            // btnGrades
            // 
            this.btnGrades.BorderRadius = 20;
            this.btnGrades.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(190)))), ((int)(((byte)(235)))));
            this.btnGrades.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnGrades.ForeColor = System.Drawing.Color.Black;
            this.btnGrades.Location = new System.Drawing.Point(30, 610);
            this.btnGrades.Name = "btnGrades";
            this.btnGrades.Size = new System.Drawing.Size(240, 50);
            this.btnGrades.TabIndex = 6;
            this.btnGrades.Text = "Успеваемость";
            this.btnGrades.Click += new System.EventHandler(this.btnGrades_Click);
            // 
            // btnReport
            // 
            this.btnReport.BorderRadius = 20;
            this.btnReport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(190)))), ((int)(((byte)(235)))));
            this.btnReport.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnReport.ForeColor = System.Drawing.Color.Black;
            this.btnReport.Location = new System.Drawing.Point(30, 695);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(240, 50);
            this.btnReport.TabIndex = 5;
            this.btnReport.Text = "Отчёты";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnEvents
            // 
            this.btnEvents.BorderRadius = 20;
            this.btnEvents.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(190)))), ((int)(((byte)(235)))));
            this.btnEvents.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnEvents.ForeColor = System.Drawing.Color.Black;
            this.btnEvents.Location = new System.Drawing.Point(30, 440);
            this.btnEvents.Name = "btnEvents";
            this.btnEvents.Size = new System.Drawing.Size(240, 50);
            this.btnEvents.TabIndex = 4;
            this.btnEvents.Text = "Мероприятия";
            this.btnEvents.Click += new System.EventHandler(this.btnEvents_Click);
            // 
            // btnAttendance
            // 
            this.btnAttendance.BorderRadius = 20;
            this.btnAttendance.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(190)))), ((int)(((byte)(235)))));
            this.btnAttendance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnAttendance.ForeColor = System.Drawing.Color.Black;
            this.btnAttendance.Location = new System.Drawing.Point(30, 355);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Size = new System.Drawing.Size(240, 50);
            this.btnAttendance.TabIndex = 2;
            this.btnAttendance.Text = "Посещаемость";
            this.btnAttendance.Click += new System.EventHandler(this.btnAttendance_Click);
            // 
            // btnSubjects
            // 
            this.btnSubjects.BorderRadius = 20;
            this.btnSubjects.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(190)))), ((int)(((byte)(235)))));
            this.btnSubjects.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnSubjects.ForeColor = System.Drawing.Color.Black;
            this.btnSubjects.Location = new System.Drawing.Point(30, 165);
            this.btnSubjects.Name = "btnSubjects";
            this.btnSubjects.Size = new System.Drawing.Size(240, 70);
            this.btnSubjects.TabIndex = 1;
            this.btnSubjects.Text = "Предметы и Группы";
            this.btnSubjects.Click += new System.EventHandler(this.btnSubjects_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.BorderRadius = 20;
            this.btnUsers.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(190)))), ((int)(((byte)(235)))));
            this.btnUsers.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnUsers.ForeColor = System.Drawing.Color.Black;
            this.btnUsers.Location = new System.Drawing.Point(30, 80);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(240, 50);
            this.btnUsers.TabIndex = 0;
            this.btnUsers.Text = "Пользователи";
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Location = new System.Drawing.Point(300, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1100, 900);
            this.panelContent.TabIndex = 1;
            // 
            // lblRole
            // 
            this.lblRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRole.BackColor = System.Drawing.Color.White;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblRole.ForeColor = System.Drawing.Color.Black;
            this.lblRole.Location = new System.Drawing.Point(966, 20);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(400, 46);
            this.lblRole.TabIndex = 2;
            this.lblRole.Text = "Администратор";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 900);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelSidebar);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информационная система куратора";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelSidebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}