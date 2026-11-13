using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace CuratorReportSystem
{
    partial class Form9
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;

        // --- ПРЕДМЕТЫ ---
        private System.Windows.Forms.DataGridView dgvSubjects;
        private Guna2Panel pnlAddSubject;
        private System.Windows.Forms.Label lblSubjectName;
        private Guna2TextBox txtSubjectName;
        private Guna2Button btnAddSubject;
        private Guna2Button btnDeleteSubject;

        // --- ГРУППЫ ---
        private System.Windows.Forms.DataGridView dgvGroups;
        private Guna2Panel pnlAddGroup;
        private System.Windows.Forms.Label lblGroupName;
        private Guna2TextBox txtGroupName;
        private System.Windows.Forms.Label lblKodGroup;
        private Guna2TextBox txtKodGroup;
        private System.Windows.Forms.Label lblCurator;
        private Guna2ComboBox cmbCurator;
        private Guna2Button btnAddGroup;
        private Guna2Button btnDeleteGroup;

        // --- ОБЩИЕ КНОПКИ ---
        private Guna2Button btnRefresh;
        private Guna2Button btnExit;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvSubjects = new System.Windows.Forms.DataGridView();
            this.pnlAddSubject = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSubjectName = new System.Windows.Forms.Label();
            this.txtSubjectName = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAddSubject = new Guna.UI2.WinForms.Guna2Button();
            this.btnDeleteSubject = new Guna.UI2.WinForms.Guna2Button();
            this.dgvGroups = new System.Windows.Forms.DataGridView();
            this.pnlAddGroup = new Guna.UI2.WinForms.Guna2Panel();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.txtGroupName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblKodGroup = new System.Windows.Forms.Label();
            this.txtKodGroup = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCurator = new System.Windows.Forms.Label();
            this.cmbCurator = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAddGroup = new Guna.UI2.WinForms.Guna2Button();
            this.btnDeleteGroup = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).BeginInit();
            this.pnlAddSubject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).BeginInit();
            this.pnlAddGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(422, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Предметы и Группы";
            // 
            // dgvSubjects
            // 
            this.dgvSubjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubjects.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.dgvSubjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvSubjects.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvSubjects.ColumnHeadersHeight = 40;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSubjects.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvSubjects.Location = new System.Drawing.Point(40, 80);
            this.dgvSubjects.Name = "dgvSubjects";
            this.dgvSubjects.RowHeadersVisible = false;
            this.dgvSubjects.RowHeadersWidth = 51;
            this.dgvSubjects.RowTemplate.Height = 40;
            this.dgvSubjects.Size = new System.Drawing.Size(412, 444);
            this.dgvSubjects.TabIndex = 1;
            // 
            // pnlAddSubject
            // 
            this.pnlAddSubject.BackColor = System.Drawing.Color.Transparent;
            this.pnlAddSubject.BorderRadius = 20;
            this.pnlAddSubject.Controls.Add(this.lblSubjectName);
            this.pnlAddSubject.Controls.Add(this.txtSubjectName);
            this.pnlAddSubject.Controls.Add(this.btnAddSubject);
            this.pnlAddSubject.Controls.Add(this.btnDeleteSubject);
            this.pnlAddSubject.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.pnlAddSubject.Location = new System.Drawing.Point(40, 544);
            this.pnlAddSubject.Name = "pnlAddSubject";
            this.pnlAddSubject.Size = new System.Drawing.Size(412, 120);
            this.pnlAddSubject.TabIndex = 2;
            // 
            // lblSubjectName
            // 
            this.lblSubjectName.AutoSize = true;
            this.lblSubjectName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSubjectName.Location = new System.Drawing.Point(20, 20);
            this.lblSubjectName.Name = "lblSubjectName";
            this.lblSubjectName.Size = new System.Drawing.Size(107, 28);
            this.lblSubjectName.TabIndex = 0;
            this.lblSubjectName.Text = "Название";
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.BorderColor = System.Drawing.Color.Black;
            this.txtSubjectName.BorderRadius = 15;
            this.txtSubjectName.BorderThickness = 0;
            this.txtSubjectName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSubjectName.DefaultText = "";
            this.txtSubjectName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.txtSubjectName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtSubjectName.ForeColor = System.Drawing.Color.Black;
            this.txtSubjectName.Location = new System.Drawing.Point(20, 55);
            this.txtSubjectName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.PlaceholderText = "Введите название...";
            this.txtSubjectName.SelectedText = "";
            this.txtSubjectName.Size = new System.Drawing.Size(211, 46);
            this.txtSubjectName.TabIndex = 1;
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.BorderRadius = 20;
            this.btnAddSubject.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAddSubject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddSubject.ForeColor = System.Drawing.Color.Black;
            this.btnAddSubject.Location = new System.Drawing.Point(250, 14);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Size = new System.Drawing.Size(150, 45);
            this.btnAddSubject.TabIndex = 2;
            this.btnAddSubject.Text = "Добавить";
            this.btnAddSubject.Click += new System.EventHandler(this.btnAddSubject_Click);
            // 
            // btnDeleteSubject
            // 
            this.btnDeleteSubject.BorderRadius = 20;
            this.btnDeleteSubject.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDeleteSubject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDeleteSubject.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteSubject.Location = new System.Drawing.Point(250, 65);
            this.btnDeleteSubject.Name = "btnDeleteSubject";
            this.btnDeleteSubject.Size = new System.Drawing.Size(150, 45);
            this.btnDeleteSubject.TabIndex = 3;
            this.btnDeleteSubject.Text = "Удалить";
            this.btnDeleteSubject.Click += new System.EventHandler(this.btnDeleteSubject_Click);
            // 
            // dgvGroups
            // 
            this.dgvGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGroups.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.dgvGroups.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvGroups.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvGroups.ColumnHeadersHeight = 40;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGroups.DefaultCellStyle = dataGridViewCellStyle20;
            this.dgvGroups.Location = new System.Drawing.Point(480, 80);
            this.dgvGroups.Name = "dgvGroups";
            this.dgvGroups.RowHeadersVisible = false;
            this.dgvGroups.RowHeadersWidth = 51;
            this.dgvGroups.RowTemplate.Height = 40;
            this.dgvGroups.Size = new System.Drawing.Size(758, 444);
            this.dgvGroups.TabIndex = 4;
            // 
            // pnlAddGroup
            // 
            this.pnlAddGroup.BackColor = System.Drawing.Color.Transparent;
            this.pnlAddGroup.BorderRadius = 20;
            this.pnlAddGroup.Controls.Add(this.lblGroupName);
            this.pnlAddGroup.Controls.Add(this.txtGroupName);
            this.pnlAddGroup.Controls.Add(this.lblKodGroup);
            this.pnlAddGroup.Controls.Add(this.txtKodGroup);
            this.pnlAddGroup.Controls.Add(this.lblCurator);
            this.pnlAddGroup.Controls.Add(this.cmbCurator);
            this.pnlAddGroup.Controls.Add(this.btnAddGroup);
            this.pnlAddGroup.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.pnlAddGroup.Location = new System.Drawing.Point(480, 544);
            this.pnlAddGroup.Name = "pnlAddGroup";
            this.pnlAddGroup.Size = new System.Drawing.Size(758, 120);
            this.pnlAddGroup.TabIndex = 5;
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGroupName.Location = new System.Drawing.Point(10, 20);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(101, 25);
            this.lblGroupName.TabIndex = 0;
            this.lblGroupName.Text = "Название";
            // 
            // txtGroupName
            // 
            this.txtGroupName.BorderColor = System.Drawing.Color.Black;
            this.txtGroupName.BorderRadius = 15;
            this.txtGroupName.BorderThickness = 0;
            this.txtGroupName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGroupName.DefaultText = "";
            this.txtGroupName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.txtGroupName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtGroupName.ForeColor = System.Drawing.Color.Black;
            this.txtGroupName.Location = new System.Drawing.Point(10, 55);
            this.txtGroupName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.PlaceholderText = "Название...";
            this.txtGroupName.SelectedText = "";
            this.txtGroupName.Size = new System.Drawing.Size(203, 46);
            this.txtGroupName.TabIndex = 1;
            // 
            // lblKodGroup
            // 
            this.lblKodGroup.AutoSize = true;
            this.lblKodGroup.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblKodGroup.Location = new System.Drawing.Point(216, 23);
            this.lblKodGroup.Name = "lblKodGroup";
            this.lblKodGroup.Size = new System.Drawing.Size(48, 25);
            this.lblKodGroup.TabIndex = 2;
            this.lblKodGroup.Text = "Код";
            this.lblKodGroup.Click += new System.EventHandler(this.lblKodGroup_Click);
            // 
            // txtKodGroup
            // 
            this.txtKodGroup.BorderColor = System.Drawing.Color.Black;
            this.txtKodGroup.BorderRadius = 15;
            this.txtKodGroup.BorderThickness = 0;
            this.txtKodGroup.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKodGroup.DefaultText = "";
            this.txtKodGroup.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.txtKodGroup.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtKodGroup.ForeColor = System.Drawing.Color.Black;
            this.txtKodGroup.Location = new System.Drawing.Point(221, 55);
            this.txtKodGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtKodGroup.Name = "txtKodGroup";
            this.txtKodGroup.PlaceholderText = "Код...";
            this.txtKodGroup.SelectedText = "";
            this.txtKodGroup.Size = new System.Drawing.Size(158, 46);
            this.txtKodGroup.TabIndex = 3;
            // 
            // lblCurator
            // 
            this.lblCurator.AutoSize = true;
            this.lblCurator.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCurator.Location = new System.Drawing.Point(381, 20);
            this.lblCurator.Name = "lblCurator";
            this.lblCurator.Size = new System.Drawing.Size(88, 25);
            this.lblCurator.TabIndex = 4;
            this.lblCurator.Text = "Куратор";
            // 
            // cmbCurator
            // 
            this.cmbCurator.BackColor = System.Drawing.Color.Transparent;
            this.cmbCurator.BorderColor = System.Drawing.Color.Transparent;
            this.cmbCurator.BorderRadius = 15;
            this.cmbCurator.BorderThickness = 0;
            this.cmbCurator.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCurator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurator.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.cmbCurator.FocusedColor = System.Drawing.Color.Transparent;
            this.cmbCurator.FocusedState.BorderColor = System.Drawing.Color.Transparent;
            this.cmbCurator.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.cmbCurator.ForeColor = System.Drawing.Color.Black;
            this.cmbCurator.ItemHeight = 40;
            this.cmbCurator.Location = new System.Drawing.Point(386, 55);
            this.cmbCurator.Name = "cmbCurator";
            this.cmbCurator.Size = new System.Drawing.Size(191, 46);
            this.cmbCurator.TabIndex = 5;
            this.cmbCurator.SelectedIndexChanged += new System.EventHandler(this.cmbCurator_SelectedIndexChanged);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.BorderRadius = 20;
            this.btnAddGroup.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAddGroup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddGroup.ForeColor = System.Drawing.Color.Black;
            this.btnAddGroup.Location = new System.Drawing.Point(583, 55);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(150, 45);
            this.btnAddGroup.TabIndex = 6;
            this.btnAddGroup.Text = "Добавить";
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.BorderRadius = 20;
            this.btnDeleteGroup.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDeleteGroup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDeleteGroup.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteGroup.Location = new System.Drawing.Point(430, 20);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(60, 80);
            this.btnDeleteGroup.TabIndex = 7;
            this.btnDeleteGroup.Visible = false;
            this.btnDeleteGroup.Click += new System.EventHandler(this.btnDeleteGroup_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BorderRadius = 25;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Location = new System.Drawing.Point(40, 694);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(200, 50);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExit
            // 
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
            // Form9
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1278, 794);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.pnlAddGroup);
            this.Controls.Add(this.pnlAddSubject);
            this.Controls.Add(this.dgvGroups);
            this.Controls.Add(this.dgvSubjects);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form9";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Предметы и Группы";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).EndInit();
            this.pnlAddSubject.ResumeLayout(false);
            this.pnlAddSubject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).EndInit();
            this.pnlAddGroup.ResumeLayout(false);
            this.pnlAddGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}