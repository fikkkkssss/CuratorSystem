using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace CuratorReportSystem
{
    partial class Form8
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.DataGridView dgvAchievements;

        private System.Windows.Forms.Label lblSelectEvent;
        private Guna2ComboBox cmbFilterEvent;

        private System.Windows.Forms.DataGridView dgvEventAttendance;
        private System.Windows.Forms.Label lblAttendanceTitle;

        private Guna2Panel pnlAdd;
        private System.Windows.Forms.Label lblStudent;
        private Guna2ComboBox cmbStudent;
        private System.Windows.Forms.Label lblEvent;
        private Guna2ComboBox cmbEvent;
        private System.Windows.Forms.Label lblDescription;
        private Guna2TextBox txtAchievementDesc;
        private Guna2Button btnAddAchievement;

        private Guna2Button btnRefresh;
        private Guna2Button btnExit;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvAchievements = new System.Windows.Forms.DataGridView();
            this.lblSelectEvent = new System.Windows.Forms.Label();
            this.cmbFilterEvent = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvEventAttendance = new System.Windows.Forms.DataGridView();
            this.lblAttendanceTitle = new System.Windows.Forms.Label();
            this.pnlAdd = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStudent = new System.Windows.Forms.Label();
            this.cmbStudent = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblEvent = new System.Windows.Forms.Label();
            this.cmbEvent = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtAchievementDesc = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAddAchievement = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAchievements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventAttendance)).BeginInit();
            this.pnlAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(471, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Достижения студентов";
            // 
            // dgvAchievements
            // 
            this.dgvAchievements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAchievements.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.dgvAchievements.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvAchievements.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvAchievements.ColumnHeadersHeight = 40;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAchievements.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvAchievements.Location = new System.Drawing.Point(40, 130);
            this.dgvAchievements.Name = "dgvAchievements";
            this.dgvAchievements.RowHeadersVisible = false;
            this.dgvAchievements.RowHeadersWidth = 51;
            this.dgvAchievements.RowTemplate.Height = 40;
            this.dgvAchievements.Size = new System.Drawing.Size(734, 403);
            this.dgvAchievements.TabIndex = 1;
            // 
            // lblSelectEvent
            // 
            this.lblSelectEvent.AutoSize = true;
            this.lblSelectEvent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSelectEvent.Location = new System.Drawing.Point(40, 80);
            this.lblSelectEvent.Name = "lblSelectEvent";
            this.lblSelectEvent.Size = new System.Drawing.Size(252, 28);
            this.lblSelectEvent.TabIndex = 9;
            this.lblSelectEvent.Text = "Выберите мероприятие:";
            // 
            // cmbFilterEvent
            // 
            this.cmbFilterEvent.BackColor = System.Drawing.Color.Transparent;
            this.cmbFilterEvent.BorderColor = System.Drawing.Color.Transparent;
            this.cmbFilterEvent.BorderRadius = 25;
            this.cmbFilterEvent.BorderThickness = 0;
            this.cmbFilterEvent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFilterEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterEvent.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.cmbFilterEvent.FocusedColor = System.Drawing.Color.Transparent;
            this.cmbFilterEvent.FocusedState.BorderColor = System.Drawing.Color.Transparent;
            this.cmbFilterEvent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.cmbFilterEvent.ForeColor = System.Drawing.Color.Black;
            this.cmbFilterEvent.ItemHeight = 40;
            this.cmbFilterEvent.Location = new System.Drawing.Point(298, 72);
            this.cmbFilterEvent.Name = "cmbFilterEvent";
            this.cmbFilterEvent.Size = new System.Drawing.Size(400, 46);
            this.cmbFilterEvent.TabIndex = 10;
            this.cmbFilterEvent.SelectedIndexChanged += new System.EventHandler(this.cmbFilterEvent_SelectedIndexChanged);
            // 
            // dgvEventAttendance
            // 
            this.dgvEventAttendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEventAttendance.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.dgvEventAttendance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvEventAttendance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvEventAttendance.ColumnHeadersHeight = 40;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEventAttendance.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvEventAttendance.Location = new System.Drawing.Point(802, 170);
            this.dgvEventAttendance.Name = "dgvEventAttendance";
            this.dgvEventAttendance.RowHeadersVisible = false;
            this.dgvEventAttendance.RowHeadersWidth = 51;
            this.dgvEventAttendance.RowTemplate.Height = 40;
            this.dgvEventAttendance.Size = new System.Drawing.Size(440, 363);
            this.dgvEventAttendance.TabIndex = 8;
            // 
            // lblAttendanceTitle
            // 
            this.lblAttendanceTitle.AutoSize = true;
            this.lblAttendanceTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAttendanceTitle.Location = new System.Drawing.Point(805, 130);
            this.lblAttendanceTitle.Name = "lblAttendanceTitle";
            this.lblAttendanceTitle.Size = new System.Drawing.Size(319, 32);
            this.lblAttendanceTitle.TabIndex = 7;
            this.lblAttendanceTitle.Text = "Посещения мероприятия";
            // 
            // pnlAdd
            // 
            this.pnlAdd.BackColor = System.Drawing.Color.Transparent;
            this.pnlAdd.BorderRadius = 20;
            this.pnlAdd.Controls.Add(this.lblStudent);
            this.pnlAdd.Controls.Add(this.cmbStudent);
            this.pnlAdd.Controls.Add(this.lblEvent);
            this.pnlAdd.Controls.Add(this.cmbEvent);
            this.pnlAdd.Controls.Add(this.lblDescription);
            this.pnlAdd.Controls.Add(this.txtAchievementDesc);
            this.pnlAdd.Controls.Add(this.btnAddAchievement);
            this.pnlAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.pnlAdd.Location = new System.Drawing.Point(39, 549);
            this.pnlAdd.Name = "pnlAdd";
            this.pnlAdd.Size = new System.Drawing.Size(1203, 145);
            this.pnlAdd.TabIndex = 2;
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStudent.Location = new System.Drawing.Point(20, 20);
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
            this.cmbStudent.Location = new System.Drawing.Point(113, 15);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(250, 46);
            this.cmbStudent.TabIndex = 1;
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEvent.Location = new System.Drawing.Point(20, 75);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(147, 28);
            this.lblEvent.TabIndex = 2;
            this.lblEvent.Text = "Мероприятие";
            // 
            // cmbEvent
            // 
            this.cmbEvent.BackColor = System.Drawing.Color.Transparent;
            this.cmbEvent.BorderColor = System.Drawing.Color.Transparent;
            this.cmbEvent.BorderRadius = 25;
            this.cmbEvent.BorderThickness = 0;
            this.cmbEvent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEvent.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.cmbEvent.FocusedColor = System.Drawing.Color.Transparent;
            this.cmbEvent.FocusedState.BorderColor = System.Drawing.Color.Transparent;
            this.cmbEvent.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.cmbEvent.ForeColor = System.Drawing.Color.Black;
            this.cmbEvent.ItemHeight = 40;
            this.cmbEvent.Location = new System.Drawing.Point(173, 67);
            this.cmbEvent.Name = "cmbEvent";
            this.cmbEvent.Size = new System.Drawing.Size(250, 46);
            this.cmbEvent.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(426, 15);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(109, 28);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Описание";
            // 
            // txtAchievementDesc
            // 
            this.txtAchievementDesc.BorderColor = System.Drawing.Color.Black;
            this.txtAchievementDesc.BorderRadius = 15;
            this.txtAchievementDesc.BorderThickness = 0;
            this.txtAchievementDesc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAchievementDesc.DefaultText = "";
            this.txtAchievementDesc.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.txtAchievementDesc.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtAchievementDesc.ForeColor = System.Drawing.Color.Black;
            this.txtAchievementDesc.Location = new System.Drawing.Point(431, 53);
            this.txtAchievementDesc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAchievementDesc.Multiline = true;
            this.txtAchievementDesc.Name = "txtAchievementDesc";
            this.txtAchievementDesc.PlaceholderText = "Введите описание достижения...";
            this.txtAchievementDesc.SelectedText = "";
            this.txtAchievementDesc.Size = new System.Drawing.Size(519, 60);
            this.txtAchievementDesc.TabIndex = 5;
            // 
            // btnAddAchievement
            // 
            this.btnAddAchievement.BorderRadius = 25;
            this.btnAddAchievement.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAddAchievement.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnAddAchievement.ForeColor = System.Drawing.Color.Black;
            this.btnAddAchievement.Location = new System.Drawing.Point(985, 38);
            this.btnAddAchievement.Name = "btnAddAchievement";
            this.btnAddAchievement.Size = new System.Drawing.Size(200, 50);
            this.btnAddAchievement.TabIndex = 6;
            this.btnAddAchievement.Text = "Добавить";
            this.btnAddAchievement.Click += new System.EventHandler(this.btnAddAchievement_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BorderRadius = 25;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Location = new System.Drawing.Point(39, 710);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(200, 50);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExit
            // 
            this.btnExit.BorderRadius = 25;
            this.btnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(1092, 710);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(150, 50);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Выход";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form8
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1278, 794);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.pnlAdd);
            this.Controls.Add(this.dgvEventAttendance);
            this.Controls.Add(this.lblAttendanceTitle);
            this.Controls.Add(this.cmbFilterEvent);
            this.Controls.Add(this.lblSelectEvent);
            this.Controls.Add(this.dgvAchievements);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form8";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Достижения";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAchievements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventAttendance)).EndInit();
            this.pnlAdd.ResumeLayout(false);
            this.pnlAdd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}