namespace Chuong_Trinh_Quan_Ly_San_Xuat
{
    partial class FrmReportView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportView));
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panelPO = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMSQLPO = new System.Windows.Forms.TextBox();
            this.dtpDatePO = new System.Windows.Forms.DateTimePicker();
            this.chbngaygiaoorPO = new System.Windows.Forms.CheckBox();
            this.cbKH = new System.Windows.Forms.ComboBox();
            this.btnReportPO = new System.Windows.Forms.Button();
            this.panelCTSX = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbMaSPInCTSX = new System.Windows.Forms.TextBox();
            this.btnReportCTSX = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbmonthCTSX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbYearCTSX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMSQQLCTSX = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpXuấtTồnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nVLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inẤnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pOPassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cTSXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kếHoạchSXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelKHSX = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbMaSPKHSX = new System.Windows.Forms.TextBox();
            this.btnKHSX = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tbThangKHSX = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbNamKHSX = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbMSQLKHSX = new System.Windows.Forms.TextBox();
            this.panelInvoice = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.cbKHinvoice = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.dtpNgayInvoice = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.tbSoInvoice = new System.Windows.Forms.TextBox();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.tbThangInvoice = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbNamInvoice = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panelNXTNVL = new System.Windows.Forms.Panel();
            this.tbquery = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.dtptonxtnvl = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.dtpfromnxtnvl = new System.Windows.Forms.DateTimePicker();
            this.btnNXTNVL = new System.Windows.Forms.Button();
            this.dtgexcel = new System.Windows.Forms.DataGridView();
            this.QUAN_LY_SAN_XUATDataSet = new Chuong_Trinh_Quan_Ly_San_Xuat.QUAN_LY_SAN_XUATDataSet();
            this.panelPO.SuspendLayout();
            this.panelCTSX.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelKHSX.SuspendLayout();
            this.panelInvoice.SuspendLayout();
            this.panelNXTNVL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgexcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUAN_LY_SAN_XUATDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            reportDataSource1.Name = "IN_PO";
            reportDataSource1.Value = null;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "Chuong_Trinh_Quan_Ly_San_Xuat.PO.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 393);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(757, 168);
            this.reportViewer.TabIndex = 0;
            // 
            // panelPO
            // 
            this.panelPO.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelPO.Controls.Add(this.label2);
            this.panelPO.Controls.Add(this.label1);
            this.panelPO.Controls.Add(this.tbMSQLPO);
            this.panelPO.Controls.Add(this.dtpDatePO);
            this.panelPO.Controls.Add(this.chbngaygiaoorPO);
            this.panelPO.Controls.Add(this.cbKH);
            this.panelPO.Controls.Add(this.btnReportPO);
            this.panelPO.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPO.Location = new System.Drawing.Point(0, 35);
            this.panelPO.Name = "panelPO";
            this.panelPO.Size = new System.Drawing.Size(872, 38);
            this.panelPO.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "MSQL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "KH";
            // 
            // tbMSQLPO
            // 
            this.tbMSQLPO.Location = new System.Drawing.Point(442, 8);
            this.tbMSQLPO.Name = "tbMSQLPO";
            this.tbMSQLPO.Size = new System.Drawing.Size(66, 20);
            this.tbMSQLPO.TabIndex = 6;
            // 
            // dtpDatePO
            // 
            this.dtpDatePO.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatePO.Location = new System.Drawing.Point(281, 8);
            this.dtpDatePO.Name = "dtpDatePO";
            this.dtpDatePO.Size = new System.Drawing.Size(104, 20);
            this.dtpDatePO.TabIndex = 5;
            // 
            // chbngaygiaoorPO
            // 
            this.chbngaygiaoorPO.AutoSize = true;
            this.chbngaygiaoorPO.Location = new System.Drawing.Point(166, 10);
            this.chbngaygiaoorPO.Name = "chbngaygiaoorPO";
            this.chbngaygiaoorPO.Size = new System.Drawing.Size(118, 17);
            this.chbngaygiaoorPO.TabIndex = 4;
            this.chbngaygiaoorPO.Text = "Ngày giao dự kiến?";
            this.chbngaygiaoorPO.UseVisualStyleBackColor = true;
            // 
            // cbKH
            // 
            this.cbKH.FormattingEnabled = true;
            this.cbKH.Location = new System.Drawing.Point(40, 8);
            this.cbKH.Name = "cbKH";
            this.cbKH.Size = new System.Drawing.Size(100, 21);
            this.cbKH.TabIndex = 3;
            // 
            // btnReportPO
            // 
            this.btnReportPO.Location = new System.Drawing.Point(541, 7);
            this.btnReportPO.Name = "btnReportPO";
            this.btnReportPO.Size = new System.Drawing.Size(75, 23);
            this.btnReportPO.TabIndex = 2;
            this.btnReportPO.Text = "View Report";
            this.btnReportPO.UseVisualStyleBackColor = true;
            this.btnReportPO.Click += new System.EventHandler(this.btnReportPO_Click);
            // 
            // panelCTSX
            // 
            this.panelCTSX.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelCTSX.Controls.Add(this.label15);
            this.panelCTSX.Controls.Add(this.label6);
            this.panelCTSX.Controls.Add(this.tbMaSPInCTSX);
            this.panelCTSX.Controls.Add(this.btnReportCTSX);
            this.panelCTSX.Controls.Add(this.label5);
            this.panelCTSX.Controls.Add(this.tbmonthCTSX);
            this.panelCTSX.Controls.Add(this.label4);
            this.panelCTSX.Controls.Add(this.tbYearCTSX);
            this.panelCTSX.Controls.Add(this.label3);
            this.panelCTSX.Controls.Add(this.tbMSQQLCTSX);
            this.panelCTSX.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCTSX.Location = new System.Drawing.Point(0, 73);
            this.panelCTSX.Name = "panelCTSX";
            this.panelCTSX.Size = new System.Drawing.Size(872, 32);
            this.panelCTSX.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Right;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(833, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "CTSX";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(121, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Mã SP";
            // 
            // tbMaSPInCTSX
            // 
            this.tbMaSPInCTSX.Location = new System.Drawing.Point(160, 6);
            this.tbMaSPInCTSX.Name = "tbMaSPInCTSX";
            this.tbMaSPInCTSX.Size = new System.Drawing.Size(108, 20);
            this.tbMaSPInCTSX.TabIndex = 16;
            // 
            // btnReportCTSX
            // 
            this.btnReportCTSX.Location = new System.Drawing.Point(541, 4);
            this.btnReportCTSX.Name = "btnReportCTSX";
            this.btnReportCTSX.Size = new System.Drawing.Size(75, 23);
            this.btnReportCTSX.TabIndex = 15;
            this.btnReportCTSX.Text = "View Report";
            this.btnReportCTSX.UseVisualStyleBackColor = true;
            this.btnReportCTSX.Click += new System.EventHandler(this.btnReportCTSX_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(404, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tháng";
            // 
            // tbmonthCTSX
            // 
            this.tbmonthCTSX.Location = new System.Drawing.Point(442, 5);
            this.tbmonthCTSX.Name = "tbmonthCTSX";
            this.tbmonthCTSX.Size = new System.Drawing.Size(66, 20);
            this.tbmonthCTSX.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(280, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Năm";
            // 
            // tbYearCTSX
            // 
            this.tbYearCTSX.Location = new System.Drawing.Point(309, 5);
            this.tbYearCTSX.Name = "tbYearCTSX";
            this.tbYearCTSX.Size = new System.Drawing.Size(66, 20);
            this.tbYearCTSX.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "MSQL";
            // 
            // tbMSQQLCTSX
            // 
            this.tbMSQQLCTSX.Location = new System.Drawing.Point(40, 6);
            this.tbMSQQLCTSX.Name = "tbMSQQLCTSX";
            this.tbMSQQLCTSX.Size = new System.Drawing.Size(66, 20);
            this.tbMSQQLCTSX.TabIndex = 9;
            this.tbMSQQLCTSX.TextChanged += new System.EventHandler(this.tbMSQQLCTSX_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportsToolStripMenuItem,
            this.inẤnToolStripMenuItem,
            this.cậpNhậtDữLiệuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 5, 0, 5);
            this.menuStrip1.Size = new System.Drawing.Size(872, 35);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhậpXuấtTồnToolStripMenuItem,
            this.invoiceToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(82, 25);
            this.reportsToolStripMenuItem.Text = "Báo Cáo";
            // 
            // nhậpXuấtTồnToolStripMenuItem
            // 
            this.nhậpXuấtTồnToolStripMenuItem.Name = "nhậpXuấtTồnToolStripMenuItem";
            this.nhậpXuấtTồnToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.nhậpXuấtTồnToolStripMenuItem.Text = "Invoice";
            this.nhậpXuấtTồnToolStripMenuItem.Click += new System.EventHandler(this.nhậpXuấtTồnToolStripMenuItem_Click);
            // 
            // invoiceToolStripMenuItem
            // 
            this.invoiceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nVLToolStripMenuItem,
            this.sảnPhẩmToolStripMenuItem});
            this.invoiceToolStripMenuItem.Name = "invoiceToolStripMenuItem";
            this.invoiceToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.invoiceToolStripMenuItem.Text = "NXT";
            // 
            // nVLToolStripMenuItem
            // 
            this.nVLToolStripMenuItem.Name = "nVLToolStripMenuItem";
            this.nVLToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.nVLToolStripMenuItem.Text = "NVL";
            this.nVLToolStripMenuItem.Click += new System.EventHandler(this.nVLToolStripMenuItem_Click);
            // 
            // sảnPhẩmToolStripMenuItem
            // 
            this.sảnPhẩmToolStripMenuItem.Name = "sảnPhẩmToolStripMenuItem";
            this.sảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.sảnPhẩmToolStripMenuItem.Text = "Sản Phẩm";
            this.sảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.sảnPhẩmToolStripMenuItem_Click);
            // 
            // inẤnToolStripMenuItem
            // 
            this.inẤnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pOPassToolStripMenuItem,
            this.cTSXToolStripMenuItem,
            this.kếHoạchSXToolStripMenuItem});
            this.inẤnToolStripMenuItem.Name = "inẤnToolStripMenuItem";
            this.inẤnToolStripMenuItem.Size = new System.Drawing.Size(60, 25);
            this.inẤnToolStripMenuItem.Text = "In ấn";
            // 
            // pOPassToolStripMenuItem
            // 
            this.pOPassToolStripMenuItem.Name = "pOPassToolStripMenuItem";
            this.pOPassToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.pOPassToolStripMenuItem.Text = "PO-Pass";
            this.pOPassToolStripMenuItem.Click += new System.EventHandler(this.pOPassToolStripMenuItem_Click);
            // 
            // cTSXToolStripMenuItem
            // 
            this.cTSXToolStripMenuItem.Name = "cTSXToolStripMenuItem";
            this.cTSXToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.cTSXToolStripMenuItem.Text = "CTSX";
            this.cTSXToolStripMenuItem.Click += new System.EventHandler(this.cTSXToolStripMenuItem_Click);
            // 
            // kếHoạchSXToolStripMenuItem
            // 
            this.kếHoạchSXToolStripMenuItem.Name = "kếHoạchSXToolStripMenuItem";
            this.kếHoạchSXToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.kếHoạchSXToolStripMenuItem.Text = "Kế hoạch SX";
            this.kếHoạchSXToolStripMenuItem.Click += new System.EventHandler(this.kếHoạchSXToolStripMenuItem_Click);
            // 
            // cậpNhậtDữLiệuToolStripMenuItem
            // 
            this.cậpNhậtDữLiệuToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cậpNhậtDữLiệuToolStripMenuItem.Image")));
            this.cậpNhậtDữLiệuToolStripMenuItem.Name = "cậpNhậtDữLiệuToolStripMenuItem";
            this.cậpNhậtDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(173, 25);
            this.cậpNhậtDữLiệuToolStripMenuItem.Text = "Cập Nhật Dữ Liệu";
            this.cậpNhậtDữLiệuToolStripMenuItem.Click += new System.EventHandler(this.cậpNhậtDữLiệuToolStripMenuItem_Click);
            // 
            // panelKHSX
            // 
            this.panelKHSX.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelKHSX.Controls.Add(this.label16);
            this.panelKHSX.Controls.Add(this.label7);
            this.panelKHSX.Controls.Add(this.tbMaSPKHSX);
            this.panelKHSX.Controls.Add(this.btnKHSX);
            this.panelKHSX.Controls.Add(this.label8);
            this.panelKHSX.Controls.Add(this.tbThangKHSX);
            this.panelKHSX.Controls.Add(this.label9);
            this.panelKHSX.Controls.Add(this.tbNamKHSX);
            this.panelKHSX.Controls.Add(this.label10);
            this.panelKHSX.Controls.Add(this.tbMSQLKHSX);
            this.panelKHSX.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKHSX.Location = new System.Drawing.Point(0, 105);
            this.panelKHSX.Name = "panelKHSX";
            this.panelKHSX.Size = new System.Drawing.Size(872, 32);
            this.panelKHSX.TabIndex = 5;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Right;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(832, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 13);
            this.label16.TabIndex = 19;
            this.label16.Text = "KHSX";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(121, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Mã SP";
            // 
            // tbMaSPKHSX
            // 
            this.tbMaSPKHSX.Location = new System.Drawing.Point(160, 6);
            this.tbMaSPKHSX.Name = "tbMaSPKHSX";
            this.tbMaSPKHSX.Size = new System.Drawing.Size(108, 20);
            this.tbMaSPKHSX.TabIndex = 16;
            // 
            // btnKHSX
            // 
            this.btnKHSX.Location = new System.Drawing.Point(541, 4);
            this.btnKHSX.Name = "btnKHSX";
            this.btnKHSX.Size = new System.Drawing.Size(75, 23);
            this.btnKHSX.TabIndex = 15;
            this.btnKHSX.Text = "View Report";
            this.btnKHSX.UseVisualStyleBackColor = true;
            this.btnKHSX.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(404, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Tháng";
            // 
            // tbThangKHSX
            // 
            this.tbThangKHSX.Location = new System.Drawing.Point(442, 5);
            this.tbThangKHSX.Name = "tbThangKHSX";
            this.tbThangKHSX.Size = new System.Drawing.Size(66, 20);
            this.tbThangKHSX.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(280, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Năm";
            // 
            // tbNamKHSX
            // 
            this.tbNamKHSX.Location = new System.Drawing.Point(309, 5);
            this.tbNamKHSX.Name = "tbNamKHSX";
            this.tbNamKHSX.Size = new System.Drawing.Size(66, 20);
            this.tbNamKHSX.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "MSQL";
            // 
            // tbMSQLKHSX
            // 
            this.tbMSQLKHSX.Location = new System.Drawing.Point(40, 6);
            this.tbMSQLKHSX.Name = "tbMSQLKHSX";
            this.tbMSQLKHSX.Size = new System.Drawing.Size(66, 20);
            this.tbMSQLKHSX.TabIndex = 9;
            this.tbMSQLKHSX.TextChanged += new System.EventHandler(this.tbMSQLKHSX_TextChanged);
            // 
            // panelInvoice
            // 
            this.panelInvoice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelInvoice.Controls.Add(this.label20);
            this.panelInvoice.Controls.Add(this.cbKHinvoice);
            this.panelInvoice.Controls.Add(this.label17);
            this.panelInvoice.Controls.Add(this.dtpNgayInvoice);
            this.panelInvoice.Controls.Add(this.label11);
            this.panelInvoice.Controls.Add(this.tbSoInvoice);
            this.panelInvoice.Controls.Add(this.btnInvoice);
            this.panelInvoice.Controls.Add(this.label12);
            this.panelInvoice.Controls.Add(this.tbThangInvoice);
            this.panelInvoice.Controls.Add(this.label13);
            this.panelInvoice.Controls.Add(this.tbNamInvoice);
            this.panelInvoice.Controls.Add(this.label14);
            this.panelInvoice.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInvoice.Location = new System.Drawing.Point(0, 137);
            this.panelInvoice.Name = "panelInvoice";
            this.panelInvoice.Size = new System.Drawing.Size(872, 32);
            this.panelInvoice.TabIndex = 6;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Dock = System.Windows.Forms.DockStyle.Right;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(823, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 13);
            this.label20.TabIndex = 21;
            this.label20.Text = "Invoice";
            // 
            // cbKHinvoice
            // 
            this.cbKHinvoice.FormattingEnabled = true;
            this.cbKHinvoice.Location = new System.Drawing.Point(38, 5);
            this.cbKHinvoice.Name = "cbKHinvoice";
            this.cbKHinvoice.Size = new System.Drawing.Size(100, 21);
            this.cbKHinvoice.TabIndex = 20;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(531, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 13);
            this.label17.TabIndex = 19;
            this.label17.Text = "Ngày";
            // 
            // dtpNgayInvoice
            // 
            this.dtpNgayInvoice.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayInvoice.Location = new System.Drawing.Point(569, 6);
            this.dtpNgayInvoice.Name = "dtpNgayInvoice";
            this.dtpNgayInvoice.Size = new System.Drawing.Size(104, 20);
            this.dtpNgayInvoice.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(369, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Số Inv";
            // 
            // tbSoInvoice
            // 
            this.tbSoInvoice.Location = new System.Drawing.Point(408, 5);
            this.tbSoInvoice.Name = "tbSoInvoice";
            this.tbSoInvoice.Size = new System.Drawing.Size(108, 20);
            this.tbSoInvoice.TabIndex = 16;
            // 
            // btnInvoice
            // 
            this.btnInvoice.Location = new System.Drawing.Point(679, 5);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(75, 23);
            this.btnInvoice.TabIndex = 15;
            this.btnInvoice.Text = "View Report";
            this.btnInvoice.UseVisualStyleBackColor = true;
            this.btnInvoice.Click += new System.EventHandler(this.button2_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(255, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Tháng";
            // 
            // tbThangInvoice
            // 
            this.tbThangInvoice.Location = new System.Drawing.Point(293, 5);
            this.tbThangInvoice.Name = "tbThangInvoice";
            this.tbThangInvoice.Size = new System.Drawing.Size(66, 20);
            this.tbThangInvoice.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(148, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Năm";
            // 
            // tbNamInvoice
            // 
            this.tbNamInvoice.Location = new System.Drawing.Point(177, 6);
            this.tbNamInvoice.Name = "tbNamInvoice";
            this.tbNamInvoice.Size = new System.Drawing.Size(66, 20);
            this.tbNamInvoice.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "KH";
            // 
            // panelNXTNVL
            // 
            this.panelNXTNVL.Controls.Add(this.tbquery);
            this.panelNXTNVL.Controls.Add(this.button1);
            this.panelNXTNVL.Controls.Add(this.label19);
            this.panelNXTNVL.Controls.Add(this.dtptonxtnvl);
            this.panelNXTNVL.Controls.Add(this.label18);
            this.panelNXTNVL.Controls.Add(this.dtpfromnxtnvl);
            this.panelNXTNVL.Controls.Add(this.btnNXTNVL);
            this.panelNXTNVL.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNXTNVL.Location = new System.Drawing.Point(0, 169);
            this.panelNXTNVL.Name = "panelNXTNVL";
            this.panelNXTNVL.Size = new System.Drawing.Size(872, 33);
            this.panelNXTNVL.TabIndex = 7;
            // 
            // tbquery
            // 
            this.tbquery.Location = new System.Drawing.Point(514, 6);
            this.tbquery.Name = "tbquery";
            this.tbquery.Size = new System.Drawing.Size(231, 20);
            this.tbquery.TabIndex = 26;
            this.tbquery.Text = "select cats(f1 as int), f2  from [Sheet1$A2:B]";
            this.tbquery.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(433, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(166, 10);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 13);
            this.label19.TabIndex = 24;
            this.label19.Text = "Đến ngày";
            // 
            // dtptonxtnvl
            // 
            this.dtptonxtnvl.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtptonxtnvl.Location = new System.Drawing.Point(219, 6);
            this.dtptonxtnvl.Name = "dtptonxtnvl";
            this.dtptonxtnvl.Size = new System.Drawing.Size(104, 20);
            this.dtptonxtnvl.TabIndex = 23;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 11);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 13);
            this.label18.TabIndex = 22;
            this.label18.Text = "Từ ngày";
            // 
            // dtpfromnxtnvl
            // 
            this.dtpfromnxtnvl.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfromnxtnvl.Location = new System.Drawing.Point(49, 7);
            this.dtpfromnxtnvl.Name = "dtpfromnxtnvl";
            this.dtpfromnxtnvl.Size = new System.Drawing.Size(104, 20);
            this.dtpfromnxtnvl.TabIndex = 21;
            // 
            // btnNXTNVL
            // 
            this.btnNXTNVL.Location = new System.Drawing.Point(344, 4);
            this.btnNXTNVL.Name = "btnNXTNVL";
            this.btnNXTNVL.Size = new System.Drawing.Size(75, 23);
            this.btnNXTNVL.TabIndex = 20;
            this.btnNXTNVL.Text = "View Report";
            this.btnNXTNVL.UseVisualStyleBackColor = true;
            this.btnNXTNVL.Click += new System.EventHandler(this.btnNXTNVL_Click);
            // 
            // dtgexcel
            // 
            this.dtgexcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgexcel.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtgexcel.Location = new System.Drawing.Point(0, 202);
            this.dtgexcel.Name = "dtgexcel";
            this.dtgexcel.Size = new System.Drawing.Size(872, 165);
            this.dtgexcel.TabIndex = 8;
            this.dtgexcel.Visible = false;
            // 
            // QUAN_LY_SAN_XUATDataSet
            // 
            this.QUAN_LY_SAN_XUATDataSet.DataSetName = "QUAN_LY_SAN_XUATDataSet";
            this.QUAN_LY_SAN_XUATDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FrmReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 582);
            this.Controls.Add(this.dtgexcel);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.panelNXTNVL);
            this.Controls.Add(this.panelInvoice);
            this.Controls.Add(this.panelKHSX);
            this.Controls.Add(this.panelCTSX);
            this.Controls.Add(this.panelPO);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmReportView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelPO.ResumeLayout(false);
            this.panelPO.PerformLayout();
            this.panelCTSX.ResumeLayout(false);
            this.panelCTSX.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelKHSX.ResumeLayout(false);
            this.panelKHSX.PerformLayout();
            this.panelInvoice.ResumeLayout(false);
            this.panelInvoice.PerformLayout();
            this.panelNXTNVL.ResumeLayout(false);
            this.panelNXTNVL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgexcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUAN_LY_SAN_XUATDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private QUAN_LY_SAN_XUATDataSet QUAN_LY_SAN_XUATDataSet;
        private System.Windows.Forms.Panel panelPO;
        private System.Windows.Forms.Button btnReportPO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMSQLPO;
        private System.Windows.Forms.DateTimePicker dtpDatePO;
        private System.Windows.Forms.CheckBox chbngaygiaoorPO;
        private System.Windows.Forms.ComboBox cbKH;
        private System.Windows.Forms.Panel panelCTSX;
        private System.Windows.Forms.Button btnReportCTSX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbmonthCTSX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbYearCTSX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMSQQLCTSX;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhậpXuấtTồnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inẤnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pOPassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cTSXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kếHoạchSXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cậpNhậtDữLiệuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invoiceToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbMaSPInCTSX;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panelKHSX;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbMaSPKHSX;
        private System.Windows.Forms.Button btnKHSX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbThangKHSX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbNamKHSX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbMSQLKHSX;
        private System.Windows.Forms.Panel panelInvoice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbSoInvoice;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbThangInvoice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbNamInvoice;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtpNgayInvoice;
        private System.Windows.Forms.Panel panelNXTNVL;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DateTimePicker dtptonxtnvl;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dtpfromnxtnvl;
        private System.Windows.Forms.Button btnNXTNVL;
        private System.Windows.Forms.ToolStripMenuItem nVLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.DataGridView dtgexcel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbquery;
        private System.Windows.Forms.ComboBox cbKHinvoice;
        private System.Windows.Forms.Label label20;
    }
}