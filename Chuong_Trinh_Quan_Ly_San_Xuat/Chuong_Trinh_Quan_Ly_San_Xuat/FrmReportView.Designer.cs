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
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.thépNXTToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tiếnĐộToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.theoNgàyToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.theoThángToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.giaCôngToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.theoNgàyToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.theoThángToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.xuấtToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.theoNgàyToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.theoThángToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nVLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelNXTNVL = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.dtptonxtnvl = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.dtpfromnxtnvl = new System.Windows.Forms.DateTimePicker();
            this.btnNXTNVL = new System.Windows.Forms.Button();
            this.dtgbaocao = new System.Windows.Forms.DataGridView();
            this.paneltiendo = new System.Windows.Forms.Panel();
            this.cbmacdtiendo = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.tbdenthangtiendo = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.tbdennamtiendo = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.btreporttiendo = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.tbtuthangtiendo = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tbtunamtiendo = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.tbmsqltiendo = new System.Windows.Forms.TextBox();
            this.paneltiendongay = new System.Windows.Forms.Panel();
            this.cbmacdngaytiendo = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.tbngaytiendo = new System.Windows.Forms.Button();
            this.label33 = new System.Windows.Forms.Label();
            this.tbthangngaytiendo = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.tbnamngaytiendo = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.tbmsqlngaytiendo = new System.Windows.Forms.TextBox();
            this.QUAN_LY_SAN_XUATDataSet = new Chuong_Trinh_Quan_Ly_San_Xuat.QUAN_LY_SAN_XUATDataSet();
            this.panelbaocaosx = new System.Windows.Forms.Panel();
            this.label36 = new System.Windows.Forms.Label();
            this.tbthangbaocaosx = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.tbnambaocaosx = new System.Windows.Forms.TextBox();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnbaocaosx = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.dtpbaocaosxto = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.dtpbaocaosxfrom = new System.Windows.Forms.DateTimePicker();
            this.menuStrip1.SuspendLayout();
            this.panelNXTNVL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgbaocao)).BeginInit();
            this.paneltiendo.SuspendLayout();
            this.paneltiendongay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QUAN_LY_SAN_XUATDataSet)).BeginInit();
            this.panelbaocaosx.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            reportDataSource1.Name = "IN_PO";
            reportDataSource1.Value = null;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "Chuong_Trinh_Quan_Ly_San_Xuat.PO.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(49, 370);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(757, 168);
            this.reportViewer.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thépNXTToolStripMenuItem1,
            this.tiếnĐộToolStripMenuItem1,
            this.giaCôngToolStripMenuItem1,
            this.helpToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 5, 0, 5);
            this.menuStrip1.Size = new System.Drawing.Size(1003, 35);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // thépNXTToolStripMenuItem1
            // 
            this.thépNXTToolStripMenuItem1.Name = "thépNXTToolStripMenuItem1";
            this.thépNXTToolStripMenuItem1.Size = new System.Drawing.Size(94, 25);
            this.thépNXTToolStripMenuItem1.Text = "Thép NXT";
            this.thépNXTToolStripMenuItem1.Click += new System.EventHandler(this.thépNXTToolStripMenuItem1_Click);
            // 
            // tiếnĐộToolStripMenuItem1
            // 
            this.tiếnĐộToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.theoNgàyToolStripMenuItem2,
            this.theoThángToolStripMenuItem3});
            this.tiếnĐộToolStripMenuItem1.Name = "tiếnĐộToolStripMenuItem1";
            this.tiếnĐộToolStripMenuItem1.Size = new System.Drawing.Size(79, 25);
            this.tiếnĐộToolStripMenuItem1.Text = "Tiến Độ";
            // 
            // theoNgàyToolStripMenuItem2
            // 
            this.theoNgàyToolStripMenuItem2.Name = "theoNgàyToolStripMenuItem2";
            this.theoNgàyToolStripMenuItem2.Size = new System.Drawing.Size(167, 26);
            this.theoNgàyToolStripMenuItem2.Text = "Theo Ngày";
            this.theoNgàyToolStripMenuItem2.Click += new System.EventHandler(this.theoNgàyToolStripMenuItem2_Click);
            // 
            // theoThángToolStripMenuItem3
            // 
            this.theoThángToolStripMenuItem3.Name = "theoThángToolStripMenuItem3";
            this.theoThángToolStripMenuItem3.Size = new System.Drawing.Size(167, 26);
            this.theoThángToolStripMenuItem3.Text = "Theo Tháng";
            this.theoThángToolStripMenuItem3.Click += new System.EventHandler(this.theoThángToolStripMenuItem3_Click);
            // 
            // giaCôngToolStripMenuItem1
            // 
            this.giaCôngToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhậpToolStripMenuItem1,
            this.xuấtToolStripMenuItem1});
            this.giaCôngToolStripMenuItem1.Name = "giaCôngToolStripMenuItem1";
            this.giaCôngToolStripMenuItem1.Size = new System.Drawing.Size(89, 25);
            this.giaCôngToolStripMenuItem1.Text = "Gia Công";
            // 
            // nhậpToolStripMenuItem1
            // 
            this.nhậpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.theoNgàyToolStripMenuItem4,
            this.theoThángToolStripMenuItem5});
            this.nhậpToolStripMenuItem1.Name = "nhậpToolStripMenuItem1";
            this.nhậpToolStripMenuItem1.Size = new System.Drawing.Size(121, 26);
            this.nhậpToolStripMenuItem1.Text = "Nhập";
            // 
            // theoNgàyToolStripMenuItem4
            // 
            this.theoNgàyToolStripMenuItem4.Name = "theoNgàyToolStripMenuItem4";
            this.theoNgàyToolStripMenuItem4.Size = new System.Drawing.Size(167, 26);
            this.theoNgàyToolStripMenuItem4.Text = "Theo Ngày";
            this.theoNgàyToolStripMenuItem4.Click += new System.EventHandler(this.theoNgàyToolStripMenuItem4_Click);
            // 
            // theoThángToolStripMenuItem5
            // 
            this.theoThángToolStripMenuItem5.Name = "theoThángToolStripMenuItem5";
            this.theoThángToolStripMenuItem5.Size = new System.Drawing.Size(167, 26);
            this.theoThángToolStripMenuItem5.Text = "Theo Tháng";
            this.theoThángToolStripMenuItem5.Click += new System.EventHandler(this.theoThángToolStripMenuItem5_Click);
            // 
            // xuấtToolStripMenuItem1
            // 
            this.xuấtToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.theoNgàyToolStripMenuItem3,
            this.theoThángToolStripMenuItem4});
            this.xuấtToolStripMenuItem1.Name = "xuấtToolStripMenuItem1";
            this.xuấtToolStripMenuItem1.Size = new System.Drawing.Size(121, 26);
            this.xuấtToolStripMenuItem1.Text = "Xuất";
            // 
            // theoNgàyToolStripMenuItem3
            // 
            this.theoNgàyToolStripMenuItem3.Name = "theoNgàyToolStripMenuItem3";
            this.theoNgàyToolStripMenuItem3.Size = new System.Drawing.Size(167, 26);
            this.theoNgàyToolStripMenuItem3.Text = "Theo Ngày";
            this.theoNgàyToolStripMenuItem3.Click += new System.EventHandler(this.theoNgàyToolStripMenuItem3_Click);
            // 
            // theoThángToolStripMenuItem4
            // 
            this.theoThángToolStripMenuItem4.Name = "theoThángToolStripMenuItem4";
            this.theoThángToolStripMenuItem4.Size = new System.Drawing.Size(167, 26);
            this.theoThángToolStripMenuItem4.Text = "Theo Tháng";
            this.theoThángToolStripMenuItem4.Click += new System.EventHandler(this.theoThángToolStripMenuItem4_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFileToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(56, 25);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // importFileToolStripMenuItem
            // 
            this.importFileToolStripMenuItem.Name = "importFileToolStripMenuItem";
            this.importFileToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.importFileToolStripMenuItem.Text = "Import File";
            this.importFileToolStripMenuItem.Click += new System.EventHandler(this.importFileToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invoiceToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(82, 25);
            this.reportsToolStripMenuItem.Text = "Báo Cáo";
            this.reportsToolStripMenuItem.Visible = false;
            // 
            // invoiceToolStripMenuItem
            // 
            this.invoiceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nVLToolStripMenuItem,
            this.sảnPhẩmToolStripMenuItem});
            this.invoiceToolStripMenuItem.Name = "invoiceToolStripMenuItem";
            this.invoiceToolStripMenuItem.Size = new System.Drawing.Size(112, 26);
            this.invoiceToolStripMenuItem.Text = "NXT";
            this.invoiceToolStripMenuItem.Visible = false;
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
            // panelNXTNVL
            // 
            this.panelNXTNVL.Controls.Add(this.label19);
            this.panelNXTNVL.Controls.Add(this.dtptonxtnvl);
            this.panelNXTNVL.Controls.Add(this.label18);
            this.panelNXTNVL.Controls.Add(this.dtpfromnxtnvl);
            this.panelNXTNVL.Controls.Add(this.btnNXTNVL);
            this.panelNXTNVL.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNXTNVL.Location = new System.Drawing.Point(0, 35);
            this.panelNXTNVL.Name = "panelNXTNVL";
            this.panelNXTNVL.Size = new System.Drawing.Size(1003, 33);
            this.panelNXTNVL.TabIndex = 7;
            this.panelNXTNVL.Visible = false;
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
            // dtgbaocao
            // 
            this.dtgbaocao.AllowUserToResizeRows = false;
            this.dtgbaocao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgbaocao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgbaocao.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtgbaocao.Location = new System.Drawing.Point(0, 68);
            this.dtgbaocao.Name = "dtgbaocao";
            this.dtgbaocao.ReadOnly = true;
            this.dtgbaocao.RowHeadersVisible = false;
            this.dtgbaocao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgbaocao.Size = new System.Drawing.Size(1003, 129);
            this.dtgbaocao.TabIndex = 10;
            this.dtgbaocao.Visible = false;
            // 
            // paneltiendo
            // 
            this.paneltiendo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.paneltiendo.Controls.Add(this.cbmacdtiendo);
            this.paneltiendo.Controls.Add(this.label29);
            this.paneltiendo.Controls.Add(this.tbdenthangtiendo);
            this.paneltiendo.Controls.Add(this.label30);
            this.paneltiendo.Controls.Add(this.tbdennamtiendo);
            this.paneltiendo.Controls.Add(this.label24);
            this.paneltiendo.Controls.Add(this.label25);
            this.paneltiendo.Controls.Add(this.btreporttiendo);
            this.paneltiendo.Controls.Add(this.label26);
            this.paneltiendo.Controls.Add(this.tbtuthangtiendo);
            this.paneltiendo.Controls.Add(this.label27);
            this.paneltiendo.Controls.Add(this.tbtunamtiendo);
            this.paneltiendo.Controls.Add(this.label28);
            this.paneltiendo.Controls.Add(this.tbmsqltiendo);
            this.paneltiendo.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneltiendo.Location = new System.Drawing.Point(0, 197);
            this.paneltiendo.Name = "paneltiendo";
            this.paneltiendo.Size = new System.Drawing.Size(1003, 32);
            this.paneltiendo.TabIndex = 11;
            // 
            // cbmacdtiendo
            // 
            this.cbmacdtiendo.FormattingEnabled = true;
            this.cbmacdtiendo.Location = new System.Drawing.Point(583, 5);
            this.cbmacdtiendo.Name = "cbmacdtiendo";
            this.cbmacdtiendo.Size = new System.Drawing.Size(181, 21);
            this.cbmacdtiendo.TabIndex = 23;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(195, 8);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(61, 13);
            this.label29.TabIndex = 22;
            this.label29.Text = "Đến Tháng";
            // 
            // tbdenthangtiendo
            // 
            this.tbdenthangtiendo.Location = new System.Drawing.Point(256, 4);
            this.tbdenthangtiendo.Name = "tbdenthangtiendo";
            this.tbdenthangtiendo.Size = new System.Drawing.Size(35, 20);
            this.tbdenthangtiendo.TabIndex = 21;
            this.tbdenthangtiendo.Text = "12";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(291, 8);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(29, 13);
            this.label30.TabIndex = 20;
            this.label30.Text = "Năm";
            // 
            // tbdennamtiendo
            // 
            this.tbdennamtiendo.Location = new System.Drawing.Point(320, 4);
            this.tbdennamtiendo.Name = "tbdennamtiendo";
            this.tbdennamtiendo.Size = new System.Drawing.Size(66, 20);
            this.tbdennamtiendo.TabIndex = 19;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Dock = System.Windows.Forms.DockStyle.Right;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(960, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(43, 13);
            this.label24.TabIndex = 18;
            this.label24.Text = "Tháng";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(543, 9);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(40, 13);
            this.label25.TabIndex = 17;
            this.label25.Text = "Mã CĐ";
            // 
            // btreporttiendo
            // 
            this.btreporttiendo.Location = new System.Drawing.Point(788, 5);
            this.btreporttiendo.Name = "btreporttiendo";
            this.btreporttiendo.Size = new System.Drawing.Size(75, 23);
            this.btreporttiendo.TabIndex = 15;
            this.btreporttiendo.Text = "View Report";
            this.btreporttiendo.UseVisualStyleBackColor = true;
            this.btreporttiendo.Click += new System.EventHandler(this.btreporttiendo_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(11, 8);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(54, 13);
            this.label26.TabIndex = 14;
            this.label26.Text = "Từ Tháng";
            // 
            // tbtuthangtiendo
            // 
            this.tbtuthangtiendo.Location = new System.Drawing.Point(65, 4);
            this.tbtuthangtiendo.Name = "tbtuthangtiendo";
            this.tbtuthangtiendo.Size = new System.Drawing.Size(35, 20);
            this.tbtuthangtiendo.TabIndex = 13;
            this.tbtuthangtiendo.Text = "01";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(100, 8);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(29, 13);
            this.label27.TabIndex = 12;
            this.label27.Text = "Năm";
            // 
            // tbtunamtiendo
            // 
            this.tbtunamtiendo.Location = new System.Drawing.Point(129, 4);
            this.tbtunamtiendo.Name = "tbtunamtiendo";
            this.tbtunamtiendo.Size = new System.Drawing.Size(66, 20);
            this.tbtunamtiendo.TabIndex = 11;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(425, 9);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(37, 13);
            this.label28.TabIndex = 10;
            this.label28.Text = "MSQL";
            // 
            // tbmsqltiendo
            // 
            this.tbmsqltiendo.Location = new System.Drawing.Point(462, 5);
            this.tbmsqltiendo.Name = "tbmsqltiendo";
            this.tbmsqltiendo.Size = new System.Drawing.Size(66, 20);
            this.tbmsqltiendo.TabIndex = 9;
            this.tbmsqltiendo.TextChanged += new System.EventHandler(this.tbmsqltiendo_TextChanged);
            // 
            // paneltiendongay
            // 
            this.paneltiendongay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.paneltiendongay.Controls.Add(this.cbmacdngaytiendo);
            this.paneltiendongay.Controls.Add(this.label31);
            this.paneltiendongay.Controls.Add(this.label32);
            this.paneltiendongay.Controls.Add(this.tbngaytiendo);
            this.paneltiendongay.Controls.Add(this.label33);
            this.paneltiendongay.Controls.Add(this.tbthangngaytiendo);
            this.paneltiendongay.Controls.Add(this.label34);
            this.paneltiendongay.Controls.Add(this.tbnamngaytiendo);
            this.paneltiendongay.Controls.Add(this.label35);
            this.paneltiendongay.Controls.Add(this.tbmsqlngaytiendo);
            this.paneltiendongay.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneltiendongay.Location = new System.Drawing.Point(0, 229);
            this.paneltiendongay.Name = "paneltiendongay";
            this.paneltiendongay.Size = new System.Drawing.Size(1003, 32);
            this.paneltiendongay.TabIndex = 12;
            // 
            // cbmacdngaytiendo
            // 
            this.cbmacdngaytiendo.FormattingEnabled = true;
            this.cbmacdngaytiendo.Location = new System.Drawing.Point(160, 5);
            this.cbmacdngaytiendo.Name = "cbmacdngaytiendo";
            this.cbmacdngaytiendo.Size = new System.Drawing.Size(181, 21);
            this.cbmacdngaytiendo.TabIndex = 25;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Dock = System.Windows.Forms.DockStyle.Right;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(967, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(36, 13);
            this.label31.TabIndex = 18;
            this.label31.Text = "Ngày";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(121, 9);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(40, 13);
            this.label32.TabIndex = 17;
            this.label32.Text = "Mã CD";
            // 
            // tbngaytiendo
            // 
            this.tbngaytiendo.Location = new System.Drawing.Point(650, 5);
            this.tbngaytiendo.Name = "tbngaytiendo";
            this.tbngaytiendo.Size = new System.Drawing.Size(75, 23);
            this.tbngaytiendo.TabIndex = 15;
            this.tbngaytiendo.Text = "View Report";
            this.tbngaytiendo.UseVisualStyleBackColor = true;
            this.tbngaytiendo.Click += new System.EventHandler(this.tbngaytiendo_Click);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(513, 10);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(38, 13);
            this.label33.TabIndex = 14;
            this.label33.Text = "Tháng";
            // 
            // tbthangngaytiendo
            // 
            this.tbthangngaytiendo.Location = new System.Drawing.Point(551, 6);
            this.tbthangngaytiendo.Name = "tbthangngaytiendo";
            this.tbthangngaytiendo.Size = new System.Drawing.Size(66, 20);
            this.tbthangngaytiendo.TabIndex = 13;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(389, 10);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(29, 13);
            this.label34.TabIndex = 12;
            this.label34.Text = "Năm";
            // 
            // tbnamngaytiendo
            // 
            this.tbnamngaytiendo.Location = new System.Drawing.Point(418, 6);
            this.tbnamngaytiendo.Name = "tbnamngaytiendo";
            this.tbnamngaytiendo.Size = new System.Drawing.Size(66, 20);
            this.tbnamngaytiendo.TabIndex = 11;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(3, 10);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(37, 13);
            this.label35.TabIndex = 10;
            this.label35.Text = "MSQL";
            // 
            // tbmsqlngaytiendo
            // 
            this.tbmsqlngaytiendo.Location = new System.Drawing.Point(40, 6);
            this.tbmsqlngaytiendo.Name = "tbmsqlngaytiendo";
            this.tbmsqlngaytiendo.Size = new System.Drawing.Size(66, 20);
            this.tbmsqlngaytiendo.TabIndex = 9;
            this.tbmsqlngaytiendo.TextChanged += new System.EventHandler(this.tbmsqlngaytiendo_TextChanged);
            // 
            // QUAN_LY_SAN_XUATDataSet
            // 
            this.QUAN_LY_SAN_XUATDataSet.DataSetName = "QUAN_LY_SAN_XUATDataSet";
            this.QUAN_LY_SAN_XUATDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panelbaocaosx
            // 
            this.panelbaocaosx.Controls.Add(this.label36);
            this.panelbaocaosx.Controls.Add(this.tbthangbaocaosx);
            this.panelbaocaosx.Controls.Add(this.label37);
            this.panelbaocaosx.Controls.Add(this.tbnambaocaosx);
            this.panelbaocaosx.Controls.Add(this.btnXuatExcel);
            this.panelbaocaosx.Controls.Add(this.btnbaocaosx);
            this.panelbaocaosx.Controls.Add(this.label23);
            this.panelbaocaosx.Controls.Add(this.label21);
            this.panelbaocaosx.Controls.Add(this.dtpbaocaosxto);
            this.panelbaocaosx.Controls.Add(this.label22);
            this.panelbaocaosx.Controls.Add(this.dtpbaocaosxfrom);
            this.panelbaocaosx.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelbaocaosx.Location = new System.Drawing.Point(0, 261);
            this.panelbaocaosx.Name = "panelbaocaosx";
            this.panelbaocaosx.Size = new System.Drawing.Size(1003, 33);
            this.panelbaocaosx.TabIndex = 16;
            this.panelbaocaosx.Visible = false;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(144, 10);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(38, 13);
            this.label36.TabIndex = 32;
            this.label36.Text = "Tháng";
            // 
            // tbthangbaocaosx
            // 
            this.tbthangbaocaosx.Location = new System.Drawing.Point(182, 6);
            this.tbthangbaocaosx.Name = "tbthangbaocaosx";
            this.tbthangbaocaosx.Size = new System.Drawing.Size(66, 20);
            this.tbthangbaocaosx.TabIndex = 31;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(20, 10);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(29, 13);
            this.label37.TabIndex = 30;
            this.label37.Text = "Năm";
            // 
            // tbnambaocaosx
            // 
            this.tbnambaocaosx.Location = new System.Drawing.Point(49, 6);
            this.tbnambaocaosx.Name = "tbnambaocaosx";
            this.tbnambaocaosx.Size = new System.Drawing.Size(66, 20);
            this.tbnambaocaosx.TabIndex = 29;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnXuatExcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnXuatExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.Location = new System.Drawing.Point(893, 0);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(78, 33);
            this.btnXuatExcel.TabIndex = 28;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            // 
            // btnbaocaosx
            // 
            this.btnbaocaosx.Location = new System.Drawing.Point(344, 5);
            this.btnbaocaosx.Name = "btnbaocaosx";
            this.btnbaocaosx.Size = new System.Drawing.Size(75, 23);
            this.btnbaocaosx.TabIndex = 26;
            this.btnbaocaosx.Text = "View Report";
            this.btnbaocaosx.UseVisualStyleBackColor = true;
            this.btnbaocaosx.Click += new System.EventHandler(this.btnbaocaosx_Click_1);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Dock = System.Windows.Forms.DockStyle.Right;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(971, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(32, 13);
            this.label23.TabIndex = 25;
            this.label23.Text = "NXT";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(597, 10);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 13);
            this.label21.TabIndex = 24;
            this.label21.Text = "Đến ngày";
            this.label21.Visible = false;
            // 
            // dtpbaocaosxto
            // 
            this.dtpbaocaosxto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpbaocaosxto.Location = new System.Drawing.Point(650, 6);
            this.dtpbaocaosxto.Name = "dtpbaocaosxto";
            this.dtpbaocaosxto.Size = new System.Drawing.Size(104, 20);
            this.dtpbaocaosxto.TabIndex = 23;
            this.dtpbaocaosxto.Visible = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(434, 11);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(46, 13);
            this.label22.TabIndex = 22;
            this.label22.Text = "Từ ngày";
            this.label22.Visible = false;
            // 
            // dtpbaocaosxfrom
            // 
            this.dtpbaocaosxfrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpbaocaosxfrom.Location = new System.Drawing.Point(480, 7);
            this.dtpbaocaosxfrom.Name = "dtpbaocaosxfrom";
            this.dtpbaocaosxfrom.Size = new System.Drawing.Size(104, 20);
            this.dtpbaocaosxfrom.TabIndex = 21;
            this.dtpbaocaosxfrom.Visible = false;
            // 
            // FrmReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 675);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.panelbaocaosx);
            this.Controls.Add(this.paneltiendongay);
            this.Controls.Add(this.paneltiendo);
            this.Controls.Add(this.dtgbaocao);
            this.Controls.Add(this.panelNXTNVL);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmReportView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelNXTNVL.ResumeLayout(false);
            this.panelNXTNVL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgbaocao)).EndInit();
            this.paneltiendo.ResumeLayout(false);
            this.paneltiendo.PerformLayout();
            this.paneltiendongay.ResumeLayout(false);
            this.paneltiendongay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QUAN_LY_SAN_XUATDataSet)).EndInit();
            this.panelbaocaosx.ResumeLayout(false);
            this.panelbaocaosx.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private QUAN_LY_SAN_XUATDataSet QUAN_LY_SAN_XUATDataSet;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invoiceToolStripMenuItem;
        private System.Windows.Forms.Panel panelNXTNVL;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DateTimePicker dtptonxtnvl;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dtpfromnxtnvl;
        private System.Windows.Forms.Button btnNXTNVL;
        private System.Windows.Forms.ToolStripMenuItem nVLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFileToolStripMenuItem;
        private System.Windows.Forms.DataGridView dtgbaocao;
        private System.Windows.Forms.Panel paneltiendo;
        private System.Windows.Forms.ComboBox cbmacdtiendo;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox tbdenthangtiendo;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox tbdennamtiendo;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btreporttiendo;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox tbtuthangtiendo;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox tbtunamtiendo;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox tbmsqltiendo;
        private System.Windows.Forms.Panel paneltiendongay;
        private System.Windows.Forms.ComboBox cbmacdngaytiendo;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button tbngaytiendo;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox tbthangngaytiendo;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox tbnamngaytiendo;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox tbmsqlngaytiendo;
        private System.Windows.Forms.ToolStripMenuItem thépNXTToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tiếnĐộToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem theoNgàyToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem theoThángToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem giaCôngToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nhậpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem theoNgàyToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem theoThángToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem xuấtToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem theoNgàyToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem theoThángToolStripMenuItem4;
        private System.Windows.Forms.Panel panelbaocaosx;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox tbthangbaocaosx;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox tbnambaocaosx;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnbaocaosx;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DateTimePicker dtpbaocaosxto;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dtpbaocaosxfrom;
    }
}