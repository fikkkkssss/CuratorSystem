using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace CuratorReportSystem
{
    partial class Form6
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Label lblGroup;
        private Guna2ComboBox cmbGroup;
        private System.Windows.Forms.Label lblStart;
        private Guna2DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblEnd;
        private Guna2DateTimePicker dtpEnd;
        private Guna2Panel pnlFilters;

        private System.Windows.Forms.TextBox txtReport;

        private Guna2Button btnGenerate;
        private Guna2Button btnSave;
        private Guna2Button btnExit;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlFilters = new Guna.UI2.WinForms.Guna2Panel();
            this.lblGroup = new System.Windows.Forms.Label();
            this.cmbGroup = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpStart = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtpEnd = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtReport = new System.Windows.Forms.TextBox();
            this.btnGenerate = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.pnlFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(465, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Формирование отчёта";
            // 
            // pnlFilters
            // 
            this.pnlFilters.BackColor = System.Drawing.Color.Transparent;
            this.pnlFilters.BorderRadius = 20;
            this.pnlFilters.Controls.Add(this.lblGroup);
            this.pnlFilters.Controls.Add(this.cmbGroup);
            this.pnlFilters.Controls.Add(this.lblStart);
            this.pnlFilters.Controls.Add(this.dtpStart);
            this.pnlFilters.Controls.Add(this.lblEnd);
            this.pnlFilters.Controls.Add(this.dtpEnd);
            this.pnlFilters.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.pnlFilters.Location = new System.Drawing.Point(40, 80);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(923, 91);
            this.pnlFilters.TabIndex = 1;
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGroup.Location = new System.Drawing.Point(12, 30);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(79, 28);
            this.lblGroup.TabIndex = 0;
            this.lblGroup.Text = "Группа";
            // 
            // cmbGroup
            // 
            this.cmbGroup.BackColor = System.Drawing.Color.Transparent;
            this.cmbGroup.BorderColor = System.Drawing.Color.Transparent;
            this.cmbGroup.BorderRadius = 25;
            this.cmbGroup.BorderThickness = 0;
            this.cmbGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.cmbGroup.FocusedColor = System.Drawing.Color.Transparent;
            this.cmbGroup.FocusedState.BorderColor = System.Drawing.Color.Transparent;
            this.cmbGroup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.cmbGroup.ForeColor = System.Drawing.Color.Black;
            this.cmbGroup.ItemHeight = 40;
            this.cmbGroup.Location = new System.Drawing.Point(97, 21);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(250, 46);
            this.cmbGroup.TabIndex = 1;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStart.Location = new System.Drawing.Point(353, 30);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(78, 28);
            this.lblStart.TabIndex = 2;
            this.lblStart.Text = "С даты";
            // 
            // dtpStart
            // 
            this.dtpStart.BorderColor = System.Drawing.Color.Transparent;
            this.dtpStart.BorderRadius = 25;
            this.dtpStart.Checked = true;
            this.dtpStart.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.dtpStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(437, 21);
            this.dtpStart.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpStart.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 46);
            this.dtpStart.TabIndex = 3;
            this.dtpStart.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEnd.Location = new System.Drawing.Point(643, 30);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(39, 28);
            this.lblEnd.TabIndex = 4;
            this.lblEnd.Text = "По";
            // 
            // dtpEnd
            // 
            this.dtpEnd.BorderColor = System.Drawing.Color.Transparent;
            this.dtpEnd.BorderRadius = 25;
            this.dtpEnd.Checked = true;
            this.dtpEnd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.dtpEnd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(688, 21);
            this.dtpEnd.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEnd.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 46);
            this.dtpEnd.TabIndex = 5;
            this.dtpEnd.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // txtReport
            // 
            this.txtReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.txtReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReport.Font = new System.Drawing.Font("Courier New", 11F);
            this.txtReport.Location = new System.Drawing.Point(40, 200);
            this.txtReport.Multiline = true;
            this.txtReport.Name = "txtReport";
            this.txtReport.ReadOnly = true;
            this.txtReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReport.Size = new System.Drawing.Size(1205, 453);
            this.txtReport.TabIndex = 2;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BorderRadius = 25;
            this.btnGenerate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnGenerate.ForeColor = System.Drawing.Color.Black;
            this.btnGenerate.Location = new System.Drawing.Point(263, 693);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(214, 50);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Сформировать";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 25;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(43, 693);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 50);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.BorderRadius = 25;
            this.btnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(1095, 693);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(150, 50);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Выход";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form6
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1278, 774);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtReport);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчёты";
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}