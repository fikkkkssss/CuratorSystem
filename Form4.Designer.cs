using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace CuratorReportSystem
{
    partial class Form4
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvGrades;

        private System.Windows.Forms.Label lblStudent;
        private Guna2ComboBox cmbStudent;
        private System.Windows.Forms.Label lblSubject;
        private Guna2ComboBox cmbSubject;
        private System.Windows.Forms.Label lblGrade;
        private Guna2TextBox txtGrade;
        private System.Windows.Forms.Label lblDate;
        private Guna2DateTimePicker dtpGradeDate;
        private Guna2Button btnAdd;

        private Guna2Button btnStatistics;
        private Guna2Button btnRating;
        private Guna2Button btnRefresh;
        private Guna2Button btnAnalysis;
        private Guna2Button btnExit;

        private Guna2ComboBox cmbAnalysisGroup;

        private Guna2Panel pnlAddGrade;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvGrades = new System.Windows.Forms.DataGridView();
            this.pnlAddGrade = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStudent = new System.Windows.Forms.Label();
            this.cmbStudent = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.cmbSubject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.txtGrade = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpGradeDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnStatistics = new Guna.UI2.WinForms.Guna2Button();
            this.btnRating = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnAnalysis = new Guna.UI2.WinForms.Guna2Button();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.cmbAnalysisGroup = new Guna.UI2.WinForms.Guna2ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).BeginInit();
            this.pnlAddGrade.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(292, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Успеваемость";
            // 
            // dgvGrades
            // 
            this.dgvGrades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrades.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.dgvGrades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvGrades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGrades.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGrades.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGrades.Location = new System.Drawing.Point(40, 240);
            this.dgvGrades.Name = "dgvGrades";
            this.dgvGrades.RowHeadersVisible = false;
            this.dgvGrades.RowHeadersWidth = 51;
            this.dgvGrades.RowTemplate.Height = 40;
            this.dgvGrades.Size = new System.Drawing.Size(1198, 414);
            this.dgvGrades.TabIndex = 2;
            // 
            // pnlAddGrade
            // 
            this.pnlAddGrade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAddGrade.BackColor = System.Drawing.Color.Transparent;
            this.pnlAddGrade.BorderRadius = 20;
            this.pnlAddGrade.Controls.Add(this.lblStudent);
            this.pnlAddGrade.Controls.Add(this.cmbStudent);
            this.pnlAddGrade.Controls.Add(this.lblSubject);
            this.pnlAddGrade.Controls.Add(this.cmbSubject);
            this.pnlAddGrade.Controls.Add(this.lblGrade);
            this.pnlAddGrade.Controls.Add(this.txtGrade);
            this.pnlAddGrade.Controls.Add(this.lblDate);
            this.pnlAddGrade.Controls.Add(this.dtpGradeDate);
            this.pnlAddGrade.Controls.Add(this.btnAdd);
            this.pnlAddGrade.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.pnlAddGrade.Location = new System.Drawing.Point(40, 80);
            this.pnlAddGrade.Name = "pnlAddGrade";
            this.pnlAddGrade.Size = new System.Drawing.Size(1198, 130);
            this.pnlAddGrade.TabIndex = 1;
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStudent.Location = new System.Drawing.Point(44, 20);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(87, 28);
            this.lblStudent.TabIndex = 0;
            this.lblStudent.Text = "Студент";
            // 
            // cmbStudent
            // 
            this.cmbStudent.BackColor = System.Drawing.Color.Transparent;
            this.cmbStudent.BorderColor = System.Drawing.Color.Transparent;
            this.cmbStudent.BorderRadius = 25;
            this.cmbStudent.BorderThickness = 0;
            this.cmbStudent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudent.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.cmbStudent.FocusedColor = System.Drawing.Color.Transparent;
            this.cmbStudent.FocusedState.BorderColor = System.Drawing.Color.Transparent;
            this.cmbStudent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.cmbStudent.ForeColor = System.Drawing.Color.Black;
            this.cmbStudent.ItemHeight = 40;
            this.cmbStudent.Location = new System.Drawing.Point(152, 17);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(262, 46);
            this.cmbStudent.TabIndex = 1;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSubject.Location = new System.Drawing.Point(473, 20);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(98, 28);
            this.lblSubject.TabIndex = 2;
            this.lblSubject.Text = "Предмет";
            // 
            // cmbSubject
            // 
            this.cmbSubject.BackColor = System.Drawing.Color.Transparent;
            this.cmbSubject.BorderColor = System.Drawing.Color.Transparent;
            this.cmbSubject.BorderRadius = 25;
            this.cmbSubject.BorderThickness = 0;
            this.cmbSubject.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubject.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.cmbSubject.FocusedColor = System.Drawing.Color.Transparent;
            this.cmbSubject.FocusedState.BorderColor = System.Drawing.Color.Transparent;
            this.cmbSubject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.cmbSubject.ForeColor = System.Drawing.Color.Black;
            this.cmbSubject.ItemHeight = 40;
            this.cmbSubject.Location = new System.Drawing.Point(600, 20);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(254, 46);
            this.cmbSubject.TabIndex = 3;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGrade.Location = new System.Drawing.Point(46, 75);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(85, 28);
            this.lblGrade.TabIndex = 4;
            this.lblGrade.Text = "Оценка";
            // 
            // txtGrade
            // 
            this.txtGrade.BorderColor = System.Drawing.Color.Transparent;
            this.txtGrade.BorderRadius = 25;
            this.txtGrade.BorderThickness = 0;
            this.txtGrade.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGrade.DefaultText = "";
            this.txtGrade.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.txtGrade.FocusedState.BorderColor = System.Drawing.Color.Transparent;
            this.txtGrade.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtGrade.ForeColor = System.Drawing.Color.Black;
            this.txtGrade.Location = new System.Drawing.Point(152, 72);
            this.txtGrade.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.PlaceholderText = "от 1 до 5";
            this.txtGrade.SelectedText = "";
            this.txtGrade.Size = new System.Drawing.Size(130, 50);
            this.txtGrade.TabIndex = 5;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(512, 75);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(59, 28);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Дата";
            // 
            // dtpGradeDate
            // 
            this.dtpGradeDate.BorderColor = System.Drawing.Color.Transparent;
            this.dtpGradeDate.BorderRadius = 25;
            this.dtpGradeDate.Checked = true;
            this.dtpGradeDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.dtpGradeDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.dtpGradeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpGradeDate.Location = new System.Drawing.Point(600, 72);
            this.dtpGradeDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpGradeDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpGradeDate.Name = "dtpGradeDate";
            this.dtpGradeDate.Size = new System.Drawing.Size(168, 50);
            this.dtpGradeDate.TabIndex = 7;
            this.dtpGradeDate.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // btnAdd
            // 
            this.btnAdd.BorderRadius = 25;
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(950, 44);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(200, 50);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStatistics.BorderRadius = 25;
            this.btnStatistics.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.btnStatistics.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnStatistics.ForeColor = System.Drawing.Color.Black;
            this.btnStatistics.Location = new System.Drawing.Point(440, 695);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(180, 50);
            this.btnStatistics.TabIndex = 3;
            this.btnStatistics.Text = "Статистика";
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // btnRating
            // 
            this.btnRating.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRating.BorderRadius = 25;
            this.btnRating.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.btnRating.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnRating.ForeColor = System.Drawing.Color.Black;
            this.btnRating.Location = new System.Drawing.Point(240, 694);
            this.btnRating.Name = "btnRating";
            this.btnRating.Size = new System.Drawing.Size(180, 50);
            this.btnRating.TabIndex = 4;
            this.btnRating.Text = "Рейтинг";
            this.btnRating.Click += new System.EventHandler(this.btnRating_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.BorderRadius = 25;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Location = new System.Drawing.Point(39, 694);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(180, 50);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnalysis.BorderRadius = 25;
            this.btnAnalysis.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.btnAnalysis.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnAnalysis.ForeColor = System.Drawing.Color.Black;
            this.btnAnalysis.Location = new System.Drawing.Point(640, 695);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(180, 50);
            this.btnAnalysis.TabIndex = 6;
            this.btnAnalysis.Text = "Анализ";
            this.btnAnalysis.Click += new System.EventHandler(this.btnAnalysis_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BorderRadius = 25;
            this.btnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(1088, 694);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(150, 50);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Выход";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmbAnalysisGroup
            // 
            this.cmbAnalysisGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbAnalysisGroup.BackColor = System.Drawing.Color.Transparent;
            this.cmbAnalysisGroup.BorderColor = System.Drawing.Color.Transparent;
            this.cmbAnalysisGroup.BorderRadius = 25;
            this.cmbAnalysisGroup.BorderThickness = 0;
            this.cmbAnalysisGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAnalysisGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnalysisGroup.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.cmbAnalysisGroup.FocusedColor = System.Drawing.Color.Transparent;
            this.cmbAnalysisGroup.FocusedState.BorderColor = System.Drawing.Color.Transparent;
            this.cmbAnalysisGroup.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.cmbAnalysisGroup.ForeColor = System.Drawing.Color.Black;
            this.cmbAnalysisGroup.ItemHeight = 45;
            this.cmbAnalysisGroup.Location = new System.Drawing.Point(839, 695);
            this.cmbAnalysisGroup.Name = "cmbAnalysisGroup";
            this.cmbAnalysisGroup.Size = new System.Drawing.Size(180, 51);
            this.cmbAnalysisGroup.TabIndex = 8;
            this.cmbAnalysisGroup.Visible = false;
            // 
            // Form4
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1278, 794);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAnalysis);
            this.Controls.Add(this.cmbAnalysisGroup);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnRating);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.dgvGrades);
            this.Controls.Add(this.pnlAddGrade);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).EndInit();
            this.pnlAddGrade.ResumeLayout(false);
            this.pnlAddGrade.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}