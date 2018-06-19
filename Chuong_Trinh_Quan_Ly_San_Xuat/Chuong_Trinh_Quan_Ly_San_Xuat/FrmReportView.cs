using Chuong_Trinh_Quan_Ly_San_Xuat.BLL;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chuong_Trinh_Quan_Ly_San_Xuat
{
    public partial class FrmReportView : Form
    {
        public FrmReportView()
        {
            InitializeComponent();
            hidepannelfilter();
            tbYearCTSX.Text = DateTime.Now.Year.ToString();
            tbmonthCTSX.Text = DateTime.Now.Month.ToString();
            tbNamKHSX.Text = DateTime.Now.Year.ToString();
            tbThangKHSX.Text = DateTime.Now.Month.ToString();
            tbNamInvoice.Text = DateTime.Now.Year.ToString();
            tbThangInvoice.Text = DateTime.Now.Month.ToString();
            dtpNgayInvoice.Value = DateTime.Now;
            reportViewer.Dock = DockStyle.Fill;
            tbKHInvoice.Text = "NTZC";
        }

        private void btnReportPO_Click(object sender, EventArgs e)
        {
            int ngaygiao = 0;
            if (chbngaygiaoorPO.Checked) ngaygiao = 1;
            DataTable dt = Import_Manager.Instance.printPO(cbKH.Text, dtpDatePO.Value, tbMSQLPO.Text, ngaygiao);
            viewreport("PO.rdlc", "IN_PO", dt);
            
        }

        void viewreport(string reportname, string datasetname, DataTable dt)
        {
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.LocalReport.ReportPath = reportname;
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource(datasetname, dt));
            reportViewer.RefreshReport();
        }

        private void btnReportCTSX_Click(object sender, EventArgs e)
        {
            if (tbYearCTSX.Text != "" && tbmonthCTSX.Text != "")
            {
                DataTable dt = Import_Manager.Instance.inCTSX(tbMSQQLCTSX.Text, tbMaSPInCTSX.Text , Int32.Parse(tbYearCTSX.Text), Int32.Parse(tbmonthCTSX.Text));
                viewreport("CTSX.rdlc", "CTSX", dt);
            }
        }

        private void pOPassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hidepannelfilter();
            panelPO.Visible = true;
        }
        void hidepannelfilter()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType().Name == "Panel") c.Visible = false;
            }
        }

        private void cTSXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hidepannelfilter();
            panelCTSX.Visible = true;
            //System.Diagnostics.Process.Start("http://sanyo_server/ReportServer/Pages/ReportViewer.aspx?%2fIn+CTSX&rs:Command=Render");
        }

        private void cậpNhậtDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int result = Import_Manager.Instance.UpdateDuLieu();
                MessageBox.Show("Cập nhật dữ liệu xong");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nhậpXuấtTồnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hidepannelfilter();
            panelInvoice.Visible = true;
            //System.Diagnostics.Process.Start("http://sanyo_server/ReportServer/Pages/ReportViewer.aspx?%2fInvoice&rs:Command=Render");
        }

        private void kếHoạchSXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hidepannelfilter();
            panelKHSX.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbNamKHSX.Text != "" && tbThangKHSX.Text != "")
            {
                DataTable dt = Import_Manager.Instance.inCTSX(tbMSQLKHSX.Text, tbMaSPKHSX.Text, Int32.Parse(tbNamKHSX.Text), Int32.Parse(tbThangKHSX.Text));
                viewreport("KHSX.rdlc", "KHSX", dt);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (tbNamInvoice.Text != "" && tbThangInvoice.Text != "")
            {
                DataTable dt = Import_Manager.Instance.reportInvoice(tbKHInvoice.Text, Int32.Parse(tbNamInvoice.Text), Int32.Parse(tbThangInvoice.Text), tbSoInvoice.Text, dtpNgayInvoice.Value);
                viewreport("Invoice.rdlc", "Invoice", dt);
            }
           
        }
    }
}
