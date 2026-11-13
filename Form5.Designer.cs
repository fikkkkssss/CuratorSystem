using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace CuratorReportSystem
{
    partial class Form5
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.DataGridView dgvEvents;

        private System.Windows.Forms.Label lblEventDetails;
        private System.Windows.Forms.TextBox txtEventDetails;
        private Guna2Panel pnlDetails;

        private System.Windows.Forms.Label lblStudent;
        private Guna2ComboBox cmbStudent;
        // Убрали lblDescription и txtDescription
        private Guna2Button btnAddAchievement;
        private Guna2Button btnMarkAttendance;
        private Guna2Panel pnlAchievement;

        private System.Windows.Forms.Label lblEventName;
        private Guna2TextBox txtEventName;
        private System.Windows.Forms.Label lblNewEventDesc;
        private Guna2TextBox txtNewEventDesc;
        private System.Windows.Forms.Label lblEventDate;
        private Guna2DateTimePicker dtpEventDate;
        private Guna2Button btnAddEvent;
        private Guna2Panel pnlAddEvent;

        private Guna2Button btnRefresh;
        private Guna2Button btnExit;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvEvents = new System.Windows.Forms.DataGridView();
            this.pnlDetails = new Guna.UI2.WinForms.Guna2Panel();
            this.lblEventDetails = new System.Windows.Forms.Label();
            this.txtEventDetails = new System.Windows.Forms.TextBox();
            this.pnlAchievement = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStudent = new System.Windows.Forms.Label();
            this.cmbStudent = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAddAchievement = new Guna.UI2.WinForms.Guna2Button();
            this.btnMarkAttendance = new Guna.UI2.WinForms.Guna2Button();
            this.pnlAddEvent = new Guna.UI2.WinForms.Guna2Panel();
            this.lblEventName = new System.Windows.Forms.Label();
            this.txtEventName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNewEventDesc = new System.Windows.Forms.Label();
            this.txtNewEventDesc = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblEventDate = new System.Windows.Forms.Label();
            this.dtpEventDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnAddEvent = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            this.pnlDetails.SuspendLayout();
            this.pnlAchievement.SuspendLayout();
            this.pnlAddEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(295, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Мероприятия";
            // 
            // dgvEvents
            // 
            this.dgvEvents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEvents.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.dgvEvents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvEvents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEvents.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEvents.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEvents.Location = new System.Drawing.Point(40, 80);
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.RowHeadersVisible = false;
            this.dgvEvents.RowHeadersWidth = 51;
            this.dgvEvents.RowTemplate.Height = 40;
            this.dgvEvents.Size = new System.Drawing.Size(774, 458);
            this.dgvEvents.TabIndex = 1;
            this.dgvEvents.SelectionChanged += new System.EventHandler(this.dgvEvents_SelectionChanged);
            // 
            // pnlDetails
            // 
            this.pnlDetails.BackColor = System.Drawing.Color.Transparent;
            this.pnlDetails.BorderRadius = 20;
            this.pnlDetails.Controls.Add(this.lblEventDetails);
            this.pnlDetails.Controls.Add(this.txtEventDetails);
            this.pnlDetails.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.pnlDetails.Location = new System.Drawing.Point(835, 108);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(440, 180);
            this.pnlDetails.TabIndex = 2;
            // 
            // lblEventDetails
            // 
            this.lblEventDetails.AutoSize = true;
            this.lblEventDetails.BackColor = System.Drawing.Color.Transparent;
            this.lblEventDetails.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEventDetails.Location = new System.Drawing.Point(20, 15);
            this.lblEventDetails.Name = "lblEventDetails";
            this.lblEventDetails.Size = new System.Drawing.Size(222, 28);
            this.lblEventDetails.TabIndex = 0;
            this.lblEventDetails.Text = "Детали мероприятия";
            // 
            // txtEventDetails
            // 
            this.txtEventDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.txtEventDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEventDetails.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtEventDetails.Location = new System.Drawing.Point(20, 50);
            this.txtEventDetails.Multiline = true;
            this.txtEventDetails.Name = "txtEventDetails";
            this.txtEventDetails.ReadOnly = true;
            this.txtEventDetails.Size = new System.Drawing.Size(400, 110);
            this.txtEventDetails.TabIndex = 1;
            // 
            // pnlAchievement
            // 
            this.pnlAchievement.BackColor = System.Drawing.Color.Transparent;
            this.pnlAchievement.BorderRadius = 20;
            this.pnlAchievement.Controls.Add(this.lblStudent);
            this.pnlAchievement.Controls.Add(this.cmbStudent);
            this.pnlAchievement.Controls.Add(this.btnAddAchievement);
            this.pnlAchievement.Controls.Add(this.btnMarkAttendance);
            this.pnlAchievement.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.pnlAchievement.Location = new System.Drawing.Point(835, 315);
            this.pnlAchievement.Name = "pnlAchievement";
            this.pnlAchievement.Size = new System.Drawing.Size(440, 200);
            this.pnlAchievement.TabIndex = 3;
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.BackColor = System.Drawing.Color.Transparent;
            this.lblStudent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStudent.Location = new System.Drawing.Point(20, 15);
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
            this.cmbStudent.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.cmbStudent.ForeColor = System.Drawing.Color.Black;
            this.cmbStudent.ItemHeight = 40;
            this.cmbStudent.Location = new System.Drawing.Point(20, 55);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(400, 46);
            this.cmbStudent.TabIndex = 1;
            // 
            // btnAddAchievement
            // 
            this.btnAddAchievement.BorderRadius = 25;
            this.btnAddAchievement.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAddAchievement.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddAchievement.ForeColor = System.Drawing.Color.Black;
            this.btnAddAchievement.Location = new System.Drawing.Point(20, 120);
            this.btnAddAchievement.Name = "btnAddAchievement";
            this.btnAddAchievement.Size = new System.Drawing.Size(200, 50);
            this.btnAddAchievement.TabIndex = 4;
            this.btnAddAchievement.Text = "Достижение";
            this.btnAddAchievement.Click += new System.EventHandler(this.btnAddAchievement_Click);
            // 
            // btnMarkAttendance
            // 
            this.btnMarkAttendance.BorderRadius = 25;
            this.btnMarkAttendance.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.btnMarkAttendance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnMarkAttendance.ForeColor = System.Drawing.Color.Black;
            this.btnMarkAttendance.Location = new System.Drawing.Point(230, 120);
            this.btnMarkAttendance.Name = "btnMarkAttendance";
            this.btnMarkAttendance.Size = new System.Drawing.Size(200, 50);
            this.btnMarkAttendance.TabIndex = 5;
            this.btnMarkAttendance.Text = "Посетил";
            this.btnMarkAttendance.Click += new System.EventHandler(this.btnMarkAttendance_Click);
            // 
            // pnlAddEvent
            // 
            this.pnlAddEvent.BackColor = System.Drawing.Color.Transparent;
            this.pnlAddEvent.BorderRadius = 20;
            this.pnlAddEvent.Controls.Add(this.lblEventName);
            this.pnlAddEvent.Controls.Add(this.txtEventName);
            this.pnlAddEvent.Controls.Add(this.lblNewEventDesc);
            this.pnlAddEvent.Controls.Add(this.txtNewEventDesc);
            this.pnlAddEvent.Controls.Add(this.lblEventDate);
            this.pnlAddEvent.Controls.Add(this.dtpEventDate);
            this.pnlAddEvent.Controls.Add(this.btnAddEvent);
            this.pnlAddEvent.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.pnlAddEvent.Location = new System.Drawing.Point(40, 559);
            this.pnlAddEvent.Name = "pnlAddEvent";
            this.pnlAddEvent.Size = new System.Drawing.Size(1235, 120);
            this.pnlAddEvent.TabIndex = 4;
            // 
            // lblEventName
            // 
            this.lblEventName.AutoSize = true;
            this.lblEventName.BackColor = System.Drawing.Color.Transparent;
            this.lblEventName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEventName.Location = new System.Drawing.Point(16, 50);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(107, 28);
            this.lblEventName.TabIndex = 0;
            this.lblEventName.Text = "Название";
            // 
            // txtEventName
            // 
            this.txtEventName.BorderColor = System.Drawing.Color.Black;
            this.txtEventName.BorderRadius = 25;
            this.txtEventName.BorderThickness = 0;
            this.txtEventName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEventName.DefaultText = "";
            this.txtEventName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.txtEventName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtEventName.ForeColor = System.Drawing.Color.Black;
            this.txtEventName.Location = new System.Drawing.Point(130, 39);
            this.txtEventName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtEventName.Name = "txtEventName";
            this.txtEventName.PlaceholderText = "Название...";
            this.txtEventName.SelectedText = "";
            this.txtEventName.Size = new System.Drawing.Size(250, 50);
            this.txtEventName.TabIndex = 1;
            // 
            // lblNewEventDesc
            // 
            this.lblNewEventDesc.AutoSize = true;
            this.lblNewEventDesc.BackColor = System.Drawing.Color.Transparent;
            this.lblNewEventDesc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNewEventDesc.Location = new System.Drawing.Point(387, 50);
            this.lblNewEventDesc.Name = "lblNewEventDesc";
            this.lblNewEventDesc.Size = new System.Drawing.Size(109, 28);
            this.lblNewEventDesc.TabIndex = 2;
            this.lblNewEventDesc.Text = "Описание";
            // 
            // txtNewEventDesc
            // 
            this.txtNewEventDesc.BorderColor = System.Drawing.Color.Black;
            this.txtNewEventDesc.BorderRadius = 25;
            this.txtNewEventDesc.BorderThickness = 0;
            this.txtNewEventDesc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewEventDesc.DefaultText = "";
            this.txtNewEventDesc.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.txtNewEventDesc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtNewEventDesc.ForeColor = System.Drawing.Color.Black;
            this.txtNewEventDesc.Location = new System.Drawing.Point(503, 39);
            this.txtNewEventDesc.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtNewEventDesc.Name = "txtNewEventDesc";
            this.txtNewEventDesc.PlaceholderText = "Описание...";
            this.txtNewEventDesc.SelectedText = "";
            this.txtNewEventDesc.Size = new System.Drawing.Size(250, 50);
            this.txtNewEventDesc.TabIndex = 3;
            // 
            // lblEventDate
            // 
            this.lblEventDate.AutoSize = true;
            this.lblEventDate.BackColor = System.Drawing.Color.Transparent;
            this.lblEventDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEventDate.Location = new System.Drawing.Point(760, 50);
            this.lblEventDate.Name = "lblEventDate";
            this.lblEventDate.Size = new System.Drawing.Size(59, 28);
            this.lblEventDate.TabIndex = 4;
            this.lblEventDate.Text = "Дата";
            // 
            // dtpEventDate
            // 
            this.dtpEventDate.BorderColor = System.Drawing.Color.Transparent;
            this.dtpEventDate.BorderRadius = 25;
            this.dtpEventDate.Checked = true;
            this.dtpEventDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.dtpEventDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.dtpEventDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEventDate.Location = new System.Drawing.Point(825, 39);
            this.dtpEventDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEventDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEventDate.Name = "dtpEventDate";
            this.dtpEventDate.Size = new System.Drawing.Size(184, 50);
            this.dtpEventDate.TabIndex = 5;
            this.dtpEventDate.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.BorderRadius = 25;
            this.btnAddEvent.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAddEvent.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnAddEvent.ForeColor = System.Drawing.Color.Black;
            this.btnAddEvent.Location = new System.Drawing.Point(1015, 39);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(200, 50);
            this.btnAddEvent.TabIndex = 6;
            this.btnAddEvent.Text = "Добавить";
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BorderRadius = 25;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Location = new System.Drawing.Point(39, 715);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(200, 50);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExit
            // 
            this.btnExit.BorderRadius = 25;
            this.btnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(1125, 715);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(150, 50);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Выход";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form5
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1287, 795);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.pnlAddEvent);
            this.Controls.Add(this.pnlAchievement);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.dgvEvents);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.pnlAchievement.ResumeLayout(false);
            this.pnlAchievement.PerformLayout();
            this.pnlAddEvent.ResumeLayout(false);
            this.pnlAddEvent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}