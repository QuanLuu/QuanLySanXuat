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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportView));
            this.PP_DS_PRINT_PO_MSQLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QUAN_LY_SAN_XUATDataSet = new Chuong_Trinh_Quan_Ly_San_Xuat.QUAN_LY_SAN_XUATDataSet();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PP_DS_PRINT_PO_MSQLTableAdapter = new Chuong_Trinh_Quan_Ly_San_Xuat.QUAN_LY_SAN_XUATDataSetTableAdapters.PP_DS_PRINT_PO_MSQLTableAdapter();
            this.panelPO = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMSQLPO = new System.Windows.Forms.TextBox();
            this.dtpDatePO = new System.Windows.Forms.DateTimePicker();
            this.chbngaygiaoorPO = new System.Windows.Forms.CheckBox();
            this.cbKH = new System.Windows.Forms.ComboBox();
            this.btnReportPO = new System.Windows.Forms.Button();
            this.panelCTSX = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMSQQLCTSX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbYearCTSX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbmonthCTSX = new System.Windows.Forms.TextBox();
            this.btnReportCTSX = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inẤnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pOPassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cTSXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kếHoạchSXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpXuấtTồnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PP_DS_PRINT_PO_MSQLBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUAN_LY_SAN_XUATDataSet)).BeginInit();
            this.panelPO.SuspendLayout();
            this.panelCTSX.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PP_DS_PRINT_PO_MSQLBindingSource
            // 
            this.PP_DS_PRINT_PO_MSQLBindingSource.DataMember = "PP_DS_PRINT_PO_MSQL";
            this.PP_DS_PRINT_PO_MSQLBindingSource.DataSource = this.QUAN_LY_SAN_XUATDataSet;
            // 
            // QUAN_LY_SAN_XUATDataSet
            // 
            this.QUAN_LY_SAN_XUATDataSet.DataSetName = "QUAN_LY_SAN_XUATDataSet";
            this.QUAN_LY_SAN_XUATDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource5.Name = "IN_PO";
            reportDataSource5.Value = this.PP_DS_PRINT_PO_MSQLBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "Chuong_Trinh_Quan_Ly_San_Xuat.PO.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 105);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(757, 372);
            this.reportViewer.TabIndex = 0;
            // 
            // PP_DS_PRINT_PO_MSQLTableAdapter
            // 
            this.PP_DS_PRINT_PO_MSQLTableAdapter.ClearBeforeFill = true;
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
            this.panelPO.Size = new System.Drawing.Size(757, 38);
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
            this.panelCTSX.Size = new System.Drawing.Size(757, 32);
            this.panelCTSX.TabIndex = 3;
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
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Năm";
            // 
            // tbYearCTSX
            // 
            this.tbYearCTSX.Location = new System.Drawing.Point(158, 6);
            this.tbYearCTSX.Name = "tbYearCTSX";
            this.tbYearCTSX.Size = new System.Drawing.Size(66, 20);
            this.tbYearCTSX.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(253, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tháng";
            // 
            // tbmonthCTSX
            // 
            this.tbmonthCTSX.Location = new System.Drawing.Point(291, 6);
            this.tbmonthCTSX.Name = "tbmonthCTSX";
            this.tbmonthCTSX.Size = new System.Drawing.Size(66, 20);
            this.tbmonthCTSX.TabIndex = 13;
            // 
            // btnReportCTSX
            // 
            this.btnReportCTSX.Location = new System.Drawing.Point(390, 5);
            this.btnReportCTSX.Name = "btnReportCTSX";
            this.btnReportCTSX.Size = new System.Drawing.Size(75, 23);
            this.btnReportCTSX.TabIndex = 15;
            this.btnReportCTSX.Text = "View Report";
            this.btnReportCTSX.UseVisualStyleBackColor = true;
            this.btnReportCTSX.Click += new System.EventHandler(this.btnReportCTSX_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportsToolStripMenuItem,
            this.inẤnToolStripMenuItem,
            this.cậpNhậtDữLiệuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 5, 0, 5);
            this.menuStrip1.Size = new System.Drawing.Size(757, 35);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhậpXuấtTồnToolStripMenuItem,
            this.invoiceToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(156, 25);
            this.reportsToolStripMenuItem.Text = "Báo cáo tổng hợp";
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
            this.pOPassToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.pOPassToolStripMenuItem.Text = "PO-Pass";
            this.pOPassToolStripMenuItem.Click += new System.EventHandler(this.pOPassToolStripMenuItem_Click);
            // 
            // cTSXToolStripMenuItem
            // 
            this.cTSXToolStripMenuItem.Name = "cTSXToolStripMenuItem";
            this.cTSXToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.cTSXToolStripMenuItem.Text = "CTSX";
            this.cTSXToolStripMenuItem.Click += new System.EventHandler(this.cTSXToolStripMenuItem_Click);
            // 
            // kếHoạchSXToolStripMenuItem
            // 
            this.kếHoạchSXToolStripMenuItem.Name = "kếHoạchSXToolStripMenuItem";
            this.kếHoạchSXToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.kếHoạchSXToolStripMenuItem.Text = "Kế hoạch SX";
            // 
            // nhậpXuấtTồnToolStripMenuItem
            // 
            this.nhậpXuấtTồnToolStripMenuItem.Name = "nhậpXuấtTồnToolStripMenuItem";
            this.nhậpXuấtTồnToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.nhậpXuấtTồnToolStripMenuItem.Text = "Invoice";
            this.nhậpXuấtTồnToolStripMenuItem.Click += new System.EventHandler(this.nhậpXuấtTồnToolStripMenuItem_Click);
            // 
            // cậpNhậtDữLiệuToolStripMenuItem
            // 
            this.cậpNhậtDữLiệuToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cậpNhậtDữLiệuToolStripMenuItem.Image")));
            this.cậpNhậtDữLiệuToolStripMenuItem.Name = "cậpNhậtDữLiệuToolStripMenuItem";
            this.cậpNhậtDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(169, 25);
            this.cậpNhậtDữLiệuToolStripMenuItem.Text = "Cập Nhật Dữ Liệu";
            this.cậpNhậtDữLiệuToolStripMenuItem.Click += new System.EventHandler(this.cậpNhậtDữLiệuToolStripMenuItem_Click);
            // 
            // invoiceToolStripMenuItem
            // 
            this.invoiceToolStripMenuItem.Name = "invoiceToolStripMenuItem";
            this.invoiceToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.invoiceToolStripMenuItem.Text = "NXT";
            // 
            // FrmReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 477);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.panelCTSX);
            this.Controls.Add(this.panelPO);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmReportView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.PP_DS_PRINT_PO_MSQLBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUAN_LY_SAN_XUATDataSet)).EndInit();
            this.panelPO.ResumeLayout(false);
            this.panelPO.PerformLayout();
            this.panelCTSX.ResumeLayout(false);
            this.panelCTSX.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource PP_DS_PRINT_PO_MSQLBindingSource;
        private QUAN_LY_SAN_XUATDataSet QUAN_LY_SAN_XUATDataSet;
        private QUAN_LY_SAN_XUATDataSetTableAdapters.PP_DS_PRINT_PO_MSQLTableAdapter PP_DS_PRINT_PO_MSQLTableAdapter;
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
    }
}