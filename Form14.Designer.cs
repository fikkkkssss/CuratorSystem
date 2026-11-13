using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace CuratorReportSystem
{
    partial class Form14
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFIO;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblParents;
        private System.Windows.Forms.Label lblAvgGrade;
        private System.Windows.Forms.Label lblStatus;

        private System.Windows.Forms.Label lblGradesTitle;
        private System.Windows.Forms.Label lblAttendanceTitle;
        private System.Windows.Forms.Label lblAchievementsTitle;

        private System.Windows.Forms.DataGridView dgvGrades;
        private System.Windows.Forms.DataGridView dgvAttendance;
        private System.Windows.Forms.DataGridView dgvAchievements;

        private Guna2Button btnRefresh;
        private Guna2Button btnClose;

        private Guna2Panel pnlInfo;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFIO = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblParents = new System.Windows.Forms.Label();
            this.lblAvgGrade = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblGradesTitle = new System.Windows.Forms.Label();
            this.lblAttendanceTitle = new System.Windows.Forms.Label();
            this.lblAchievementsTitle = new System.Windows.Forms.Label();
            this.dgvGrades = new System.Windows.Forms.DataGridView();
            this.dgvAttendance = new System.Windows.Forms.DataGridView();
            this.dgvAchievements = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.pnlInfo = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAchievements)).BeginInit();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(357, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Карточка студента";
            // 
            // lblFIO
            // 
            this.lblFIO.AutoSize = true;
            this.lblFIO.BackColor = System.Drawing.Color.Transparent;
            this.lblFIO.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblFIO.Location = new System.Drawing.Point(20, 10);
            this.lblFIO.Name = "lblFIO";
            this.lblFIO.Size = new System.Drawing.Size(81, 37);
            this.lblFIO.TabIndex = 2;
            this.lblFIO.Text = "ФИО";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.BackColor = System.Drawing.Color.Transparent;
            this.lblGroup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGroup.Location = new System.Drawing.Point(25, 50);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(94, 23);
            this.lblGroup.TabIndex = 3;
            this.lblGroup.Text = "Группа: —";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.BackColor = System.Drawing.Color.Transparent;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPhone.Location = new System.Drawing.Point(25, 75);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(104, 23);
            this.lblPhone.TabIndex = 4;
            this.lblPhone.Text = "Телефон: —";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmail.Location = new System.Drawing.Point(244, 50);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(77, 23);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email: —";
            // 
            // lblParents
            // 
            this.lblParents.AutoSize = true;
            this.lblParents.BackColor = System.Drawing.Color.Transparent;
            this.lblParents.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblParents.Location = new System.Drawing.Point(244, 73);
            this.lblParents.Name = "lblParents";
            this.lblParents.Size = new System.Drawing.Size(110, 23);
            this.lblParents.TabIndex = 6;
            this.lblParents.Text = "Родители: —";
            // 
            // lblAvgGrade
            // 
            this.lblAvgGrade.AutoSize = true;
            this.lblAvgGrade.BackColor = System.Drawing.Color.Transparent;
            this.lblAvgGrade.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAvgGrade.Location = new System.Drawing.Point(439, 15);
            this.lblAvgGrade.Name = "lblAvgGrade";
            this.lblAvgGrade.Size = new System.Drawing.Size(218, 32);
            this.lblAvgGrade.TabIndex = 7;
            this.lblAvgGrade.Text = "Средний балл: —";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(439, 64);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(127, 32);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Статус: —";
            // 
            // lblGradesTitle
            // 
            this.lblGradesTitle.AutoSize = true;
            this.lblGradesTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGradesTitle.Location = new System.Drawing.Point(150, 190);
            this.lblGradesTitle.Name = "lblGradesTitle";
            this.lblGradesTitle.Size = new System.Drawing.Size(189, 25);
            this.lblGradesTitle.TabIndex = 9;
            this.lblGradesTitle.Text = "Последние оценки";
            // 
            // lblAttendanceTitle
            // 
            this.lblAttendanceTitle.AutoSize = true;
            this.lblAttendanceTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAttendanceTitle.Location = new System.Drawing.Point(480, 190);
            this.lblAttendanceTitle.Name = "lblAttendanceTitle";
            this.lblAttendanceTitle.Size = new System.Drawing.Size(151, 25);
            this.lblAttendanceTitle.TabIndex = 11;
            this.lblAttendanceTitle.Text = "Посещаемость";
            // 
            // lblAchievementsTitle
            // 
            this.lblAchievementsTitle.AutoSize = true;
            this.lblAchievementsTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAchievementsTitle.Location = new System.Drawing.Point(850, 190);
            this.lblAchievementsTitle.Name = "lblAchievementsTitle";
            this.lblAchievementsTitle.Size = new System.Drawing.Size(130, 25);
            this.lblAchievementsTitle.TabIndex = 13;
            this.lblAchievementsTitle.Text = "Достижения";
            // 
            // dgvGrades
            // 
            this.dgvGrades.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrades.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.dgvGrades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvGrades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvGrades.ColumnHeadersHeight = 35;
            this.dgvGrades.Location = new System.Drawing.Point(40, 220);
            this.dgvGrades.Name = "dgvGrades";
            this.dgvGrades.RowHeadersVisible = false;
            this.dgvGrades.RowHeadersWidth = 51;
            this.dgvGrades.RowTemplate.Height = 30;
            this.dgvGrades.Size = new System.Drawing.Size(340, 350);
            this.dgvGrades.TabIndex = 10;
            // 
            // dgvAttendance
            // 
            this.dgvAttendance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvAttendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAttendance.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.dgvAttendance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvAttendance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAttendance.ColumnHeadersHeight = 35;
            this.dgvAttendance.Location = new System.Drawing.Point(400, 220);
            this.dgvAttendance.Name = "dgvAttendance";
            this.dgvAttendance.RowHeadersVisible = false;
            this.dgvAttendance.RowHeadersWidth = 51;
            this.dgvAttendance.RowTemplate.Height = 30;
            this.dgvAttendance.Size = new System.Drawing.Size(340, 350);
            this.dgvAttendance.TabIndex = 12;
            // 
            // dgvAchievements
            // 
            this.dgvAchievements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvAchievements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAchievements.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.dgvAchievements.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvAchievements.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvAchievements.ColumnHeadersHeight = 35;
            this.dgvAchievements.Location = new System.Drawing.Point(760, 220);
            this.dgvAchievements.Name = "dgvAchievements";
            this.dgvAchievements.RowHeadersVisible = false;
            this.dgvAchievements.RowHeadersWidth = 51;
            this.dgvAchievements.RowTemplate.Height = 30;
            this.dgvAchievements.Size = new System.Drawing.Size(340, 350);
            this.dgvAchievements.TabIndex = 14;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.BorderRadius = 25;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Location = new System.Drawing.Point(40, 650);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(200, 50);
            this.btnRefresh.TabIndex = 15;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderRadius = 25;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(924, 650);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 50);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Закрыть";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlInfo
            // 
            this.pnlInfo.BorderRadius = 20;
            this.pnlInfo.Controls.Add(this.lblFIO);
            this.pnlInfo.Controls.Add(this.lblGroup);
            this.pnlInfo.Controls.Add(this.lblPhone);
            this.pnlInfo.Controls.Add(this.lblEmail);
            this.pnlInfo.Controls.Add(this.lblParents);
            this.pnlInfo.Controls.Add(this.lblAvgGrade);
            this.pnlInfo.Controls.Add(this.lblStatus);
            this.pnlInfo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.pnlInfo.Location = new System.Drawing.Point(40, 70);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(770, 100);
            this.pnlInfo.TabIndex = 1;
            // 
            // Form14
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 730);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvAchievements);
            this.Controls.Add(this.lblAchievementsTitle);
            this.Controls.Add(this.dgvAttendance);
            this.Controls.Add(this.lblAttendanceTitle);
            this.Controls.Add(this.dgvGrades);
            this.Controls.Add(this.lblGradesTitle);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form14";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form14_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAchievements)).EndInit();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}