using Chuong_Trinh_Quan_Ly_San_Xuat.BLL;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chuong_Trinh_Quan_Ly_San_Xuat
{
    public partial class FrmReportView : Form
    {
        string nxt = "";
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
            dtptonxtnvl.Value = DateTime.Now;
            dtpfromnxtnvl.Value = DateTime.Now.AddDays(-30);
            reportViewer.Dock = DockStyle.Fill;
            GetKhachHang();
            cbKHinvoice.Text = "NTZC";
        }

        private void btnReportPO_Click(object sender, EventArgs e)
        {
            int ngaygiao = 0;
            if (chbngaygiaoorPO.Checked) ngaygiao = 1;
            DataTable dt = Import_Manager.Instance.printPO(cbKH.Text, dtpDatePO.Value, tbMSQLPO.Text, ngaygiao);
            viewreport("PO.rdlc", "IN_PO", dt);
            
        }

        void getsanphamtheomsql()
        {
            DataTable data = Import_Manager.Instance.getmasptheomsql(tbMSQQLCTSX.Text);
            if(data.Rows.Count > 0) tbMaSPInCTSX.Text = data.Rows[0][1].ToString();
            
            DataTable khsx = Import_Manager.Instance.getmasptheomsql(tbMSQLKHSX.Text);
            if (khsx.Rows.Count > 0) tbMaSPKHSX.Text = khsx.Rows[0][1].ToString();
        }
        void viewreport(string reportname, string datasetname, DataTable dt)
        {
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.LocalReport.ReportPath = reportname;
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource(datasetname, dt));
            reportViewer.RefreshReport();
        }

        void GetKhachHang()
        {
        
            DataTable KH = Import_Manager.Instance.LoadKH("");
            cbKH.DisplayMember = "MA_KH";
            cbKH.DataSource = KH;

            cbKHinvoice.DisplayMember = "MA_KH";
            cbKHinvoice.DataSource = KH;
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
                DataTable dt = Import_Manager.Instance.reportInvoice(cbKHinvoice.Text, Int32.Parse(tbNamInvoice.Text), Int32.Parse(tbThangInvoice.Text), tbSoInvoice.Text, dtpNgayInvoice.Value);
                viewreport("Invoice.rdlc", "Invoice", dt);
            }
        }

        private void nVLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hidepannelfilter();
            panelNXTNVL.Visible = true;
            nxt = "nvl";
        }

        private void btnNXTNVL_Click(object sender, EventArgs e)
        {
            if (nxt == "nvl")
            {
                DataTable dt = Import_Manager.Instance.getnxtnvl(dtpfromnxtnvl.Value, dtptonxtnvl.Value);
                viewreport("NXT.rdlc", "NXT_NVL", dt);
            }
            else
            {
                DataTable dt = Import_Manager.Instance.getnxtsp(dtpfromnxtnvl.Value, dtptonxtnvl.Value);
                viewreport("NXT_SP.rdlc", "NXTSanPham", dt);
            }  
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hidepannelfilter();
            panelNXTNVL.Visible = true;
            nxt = "sp";
        }
        public DataTable ReadExcel(string fileName, string fileExt, string query)
        {
            string conn = string.Empty;
            DataTable dtexcel = new DataTable();
            if (fileExt.CompareTo(".xls") == 0)
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=NO';"; //for above excel 2007  
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                try
                {
                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter(query, con); //here we read data from sheet1  
                    oleAdpt.Fill(dtexcel); //fill excel data into dataTable  
                }
                catch { }
            }
            return dtexcel;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
            {
                filePath = file.FileName; //get the path of the file  
                fileExt = Path.GetExtension(filePath); //get the file extension  
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        DataTable dtExcel = new DataTable();
                        dtExcel = ReadExcel(filePath, fileExt, tbquery.Text); //read excel file  
                        dtgexcel.Visible = true;
                        dtgexcel.DataSource = dtExcel;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                }
            }
        }

        private void tbMSQQLCTSX_TextChanged(object sender, EventArgs e)
        {
            getsanphamtheomsql();
        }

        private void tbMSQLKHSX_TextChanged(object sender, EventArgs e)
        {
            getsanphamtheomsql();
        }

        private void importFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string apppath = Application.StartupPath;
                System.Diagnostics.Process.Start(apppath + "\\" + "Import help.docx");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
