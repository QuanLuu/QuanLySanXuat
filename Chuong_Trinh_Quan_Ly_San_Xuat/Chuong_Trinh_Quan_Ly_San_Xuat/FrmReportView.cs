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
            DataTable dt = Import_Manager.Instance.inCTSX(tbMSQQLCTSX.Text, Int32.Parse(tbYearCTSX.Text), Int32.Parse(tbmonthCTSX.Text));
            viewreport("CTSX.rdlc", "CTSX", dt);
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
            System.Diagnostics.Process.Start("http://sanyo_server/ReportServer/Pages/ReportViewer.aspx?%2fIn+CTSX&rs:Command=Render");
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
            System.Diagnostics.Process.Start("http://sanyo_server/ReportServer/Pages/ReportViewer.aspx?%2fInvoice&rs:Command=Render");
        }
    }
}
