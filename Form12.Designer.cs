using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace CuratorReportSystem
{
    partial class Form12
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvStudents;
        private Guna2ComboBox cmbSubject;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblExcellent;
        private System.Windows.Forms.Label lblGood;
        private System.Windows.Forms.Label lblSatisfactory;
        private System.Windows.Forms.Label lblBad;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;

        private Guna2Button btnAll;
        private Guna2Button btnExcellent;
        private Guna2Button btnGood;
        private Guna2Button btnSatisfactory;
        private Guna2Button btnBad;
        private Guna2Button btnRisk;
        private Guna2Button btnExport;
        private Guna2Button btnRefresh;
        private Guna2Button btnClose;

        private Guna2Panel pnlSubject;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.lblSubject = new System.Windows.Forms.Label();
            this.pnlSubject = new Guna.UI2.WinForms.Guna2Panel();
            this.cmbSubject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblExcellent = new System.Windows.Forms.Label();
            this.lblGood = new System.Windows.Forms.Label();
            this.lblSatisfactory = new System.Windows.Forms.Label();
            this.lblBad = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnAll = new Guna.UI2.WinForms.Guna2Button();
            this.btnExcellent = new Guna.UI2.WinForms.Guna2Button();
            this.btnGood = new Guna.UI2.WinForms.Guna2Button();
            this.btnSatisfactory = new Guna.UI2.WinForms.Guna2Button();
            this.btnBad = new Guna.UI2.WinForms.Guna2Button();
            this.btnRisk = new Guna.UI2.WinForms.Guna2Button();
            this.btnExport = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.pnlSubject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStudents
            // 
            this.dgvStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.dgvStudents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStudents.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStudents.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStudents.Location = new System.Drawing.Point(30, 230);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.RowHeadersWidth = 51;
            this.dgvStudents.RowTemplate.Height = 35;
            this.dgvStudents.Size = new System.Drawing.Size(612, 450);
            this.dgvStudents.TabIndex = 16;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSubject.Location = new System.Drawing.Point(30, 90);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(118, 32);
            this.lblSubject.TabIndex = 1;
            this.lblSubject.Text = "Предмет";
            // 
            // pnlSubject
            // 
            this.pnlSubject.BorderRadius = 20;
            this.pnlSubject.Controls.Add(this.cmbSubject);
            this.pnlSubject.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.pnlSubject.Location = new System.Drawing.Point(160, 85);
            this.pnlSubject.Name = "pnlSubject";
            this.pnlSubject.Size = new System.Drawing.Size(250, 45);
            this.pnlSubject.TabIndex = 2;
            // 
            // cmbSubject
            // 
            this.cmbSubject.BackColor = System.Drawing.Color.Transparent;
            this.cmbSubject.BorderRadius = 20;
            this.cmbSubject.BorderThickness = 0;
            this.cmbSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSubject.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubject.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.cmbSubject.FocusedColor = System.Drawing.Color.Empty;
            this.cmbSubject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.cmbSubject.ForeColor = System.Drawing.Color.Black;
            this.cmbSubject.ItemHeight = 30;
            this.cmbSubject.Location = new System.Drawing.Point(0, 0);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(250, 36);
            this.cmbSubject.TabIndex = 0;
            this.cmbSubject.SelectedIndexChanged += new System.EventHandler(this.cmbSubject_SelectedIndexChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(30, 150);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(89, 28);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "Всего: 0";
            // 
            // lblExcellent
            // 
            this.lblExcellent.AutoSize = true;
            this.lblExcellent.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblExcellent.Location = new System.Drawing.Point(150, 150);
            this.lblExcellent.Name = "lblExcellent";
            this.lblExcellent.Size = new System.Drawing.Size(135, 28);
            this.lblExcellent.TabIndex = 11;
            this.lblExcellent.Text = "Отличники: 0";
            // 
            // lblGood
            // 
            this.lblGood.AutoSize = true;
            this.lblGood.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblGood.Location = new System.Drawing.Point(320, 150);
            this.lblGood.Name = "lblGood";
            this.lblGood.Size = new System.Drawing.Size(139, 28);
            this.lblGood.TabIndex = 12;
            this.lblGood.Text = "Хорошисты: 0";
            // 
            // lblSatisfactory
            // 
            this.lblSatisfactory.AutoSize = true;
            this.lblSatisfactory.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSatisfactory.Location = new System.Drawing.Point(490, 150);
            this.lblSatisfactory.Name = "lblSatisfactory";
            this.lblSatisfactory.Size = new System.Drawing.Size(133, 28);
            this.lblSatisfactory.TabIndex = 13;
            this.lblSatisfactory.Text = "Троечники: 0";
            // 
            // lblBad
            // 
            this.lblBad.AutoSize = true;
            this.lblBad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblBad.Location = new System.Drawing.Point(660, 150);
            this.lblBad.Name = "lblBad";
            this.lblBad.Size = new System.Drawing.Size(136, 28);
            this.lblBad.TabIndex = 14;
            this.lblBad.Text = "Двоечники: 0";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCount.Location = new System.Drawing.Point(30, 190);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(134, 28);
            this.lblCount.TabIndex = 15;
            this.lblCount.Text = "Студентов: 0";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(447, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Анализ успеваемости";
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblFilter.Location = new System.Drawing.Point(440, 90);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(101, 32);
            this.lblFilter.TabIndex = 3;
            this.lblFilter.Text = "Фильтр";
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(662, 230);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(624, 450);
            this.chart.TabIndex = 17;
            this.chart.Text = "chart";
            // 
            // btnAll
            // 
            this.btnAll.BorderRadius = 20;
            this.btnAll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.btnAll.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAll.ForeColor = System.Drawing.Color.Black;
            this.btnAll.Location = new System.Drawing.Point(540, 85);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(90, 45);
            this.btnAll.TabIndex = 4;
            this.btnAll.Text = "Все";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnExcellent
            // 
            this.btnExcellent.BorderRadius = 20;
            this.btnExcellent.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.btnExcellent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnExcellent.ForeColor = System.Drawing.Color.Black;
            this.btnExcellent.Location = new System.Drawing.Point(636, 85);
            this.btnExcellent.Name = "btnExcellent";
            this.btnExcellent.Size = new System.Drawing.Size(142, 45);
            this.btnExcellent.TabIndex = 5;
            this.btnExcellent.Text = "Отличники";
            this.btnExcellent.Click += new System.EventHandler(this.btnExcellent_Click);
            // 
            // btnGood
            // 
            this.btnGood.BorderRadius = 20;
            this.btnGood.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.btnGood.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnGood.ForeColor = System.Drawing.Color.Black;
            this.btnGood.Location = new System.Drawing.Point(784, 85);
            this.btnGood.Name = "btnGood";
            this.btnGood.Size = new System.Drawing.Size(147, 45);
            this.btnGood.TabIndex = 6;
            this.btnGood.Text = "Хорошисты";
            this.btnGood.Click += new System.EventHandler(this.btnGood_Click);
            // 
            // btnSatisfactory
            // 
            this.btnSatisfactory.BorderRadius = 20;
            this.btnSatisfactory.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.btnSatisfactory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSatisfactory.ForeColor = System.Drawing.Color.Black;
            this.btnSatisfactory.Location = new System.Drawing.Point(937, 85);
            this.btnSatisfactory.Name = "btnSatisfactory";
            this.btnSatisfactory.Size = new System.Drawing.Size(145, 45);
            this.btnSatisfactory.TabIndex = 7;
            this.btnSatisfactory.Text = "Троечники";
            this.btnSatisfactory.Click += new System.EventHandler(this.btnSatisfactory_Click);
            // 
            // btnBad
            // 
            this.btnBad.BorderRadius = 20;
            this.btnBad.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.btnBad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBad.ForeColor = System.Drawing.Color.Black;
            this.btnBad.Location = new System.Drawing.Point(1088, 85);
            this.btnBad.Name = "btnBad";
            this.btnBad.Size = new System.Drawing.Size(130, 45);
            this.btnBad.TabIndex = 8;
            this.btnBad.Text = "Двоечники";
            this.btnBad.Click += new System.EventHandler(this.btnBad_Click);
            // 
            // btnRisk
            // 
            this.btnRisk.BorderRadius = 20;
            this.btnRisk.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnRisk.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRisk.ForeColor = System.Drawing.Color.Black;
            this.btnRisk.Location = new System.Drawing.Point(920, 136);
            this.btnRisk.Name = "btnRisk";
            this.btnRisk.Size = new System.Drawing.Size(178, 45);
            this.btnRisk.TabIndex = 9;
            this.btnRisk.Text = "Группа риска";
            this.btnRisk.Click += new System.EventHandler(this.btnRisk_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.BorderRadius = 25;
            this.btnExport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.Black;
            this.btnExport.Location = new System.Drawing.Point(30, 710);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(220, 50);
            this.btnExport.TabIndex = 18;
            this.btnExport.Text = "Сохранить";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.BorderRadius = 25;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(205)))), ((int)(((byte)(240)))));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Location = new System.Drawing.Point(270, 710);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(200, 50);
            this.btnRefresh.TabIndex = 19;
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
            this.btnClose.Location = new System.Drawing.Point(1122, 700);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 50);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "Закрыть";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Form12
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1312, 800);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.dgvStudents);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblBad);
            this.Controls.Add(this.lblSatisfactory);
            this.Controls.Add(this.lblGood);
            this.Controls.Add(this.lblExcellent);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnRisk);
            this.Controls.Add(this.btnBad);
            this.Controls.Add(this.btnSatisfactory);
            this.Controls.Add(this.btnGood);
            this.Controls.Add(this.btnExcellent);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.pnlSubject);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form12";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.pnlSubject.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}