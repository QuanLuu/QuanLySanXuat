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
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Chuong_Trinh_Quan_Ly_San_Xuat
{
    public partial class FrmReportView : Form
    {
        string nxt = "";
        int khsx_idx = 0;
        public FrmReportView()
        {
            InitializeComponent();
            hidepannelfilter();
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgbaocao, new object[] { true });
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
            dtpbaocaosxfrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
            dtpbaocaosxto.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);
            dtgbaocao.Dock = DockStyle.Fill;
            GetKhachHang();
            cbKHinvoice.Text = "NTZC";
        }
        void xuatexceldtg(DataGridView dtg)
        {
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Excel._Worksheet worksheet = null;

            try
            {
                worksheet = (Excel._Worksheet)workbook.ActiveSheet;
                object[,] arr = new object[dtg.Rows.Count + 1, dtg.Columns.Count + 1];
                for (int c = 0; c < dtg.Columns.Count; c++)
                {
                    arr[0, c] = dtg.Columns[c].HeaderText;
                }
                int rowindex = 1;
                int colindex = 0;
                for (int r = 0; r < dtg.Rows.Count; r++)
                {
                    for (int c = 0; c < dtg.Columns.Count; c++)
                    {
                        if (dtg.Rows[r].Cells[c].Value != null) arr[rowindex, colindex] = dtg.Rows[r].Cells[c].Value.ToString();
                        colindex++;
                    }
                    colindex = 0;
                    rowindex++;
                }

                Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 1];
                Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1 + dtg.Rows.Count, dtg.Columns.Count + 1];
                Excel.Range range = worksheet.get_Range(c1, c2);
                range.Value = arr;
                excel.Visible = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook = null;
                excel = null;
                worksheet = null;
            }
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
        void getBaocaosx()
        {

            DataTable baocao = Import_Manager.Instance.getbaocaosx(dtpbaocaosxfrom.Value, dtpbaocaosxto.Value);
            dtgbaocao.DataSource = baocao;
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
            dtgbaocao.Visible = false;
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbNamKHSX.Text != "" && tbThangKHSX.Text != "")
            {
                DataTable dt = Import_Manager.Instance.inCTSX(tbMSQLKHSX.Text, tbMaSPKHSX.Text, Int32.Parse(tbNamKHSX.Text), Int32.Parse(tbThangKHSX.Text));
                if(khsx_idx ==0)
                    viewreport("KHSX_SX.rdlc", "KHSX", dt);
                else if(khsx_idx ==1)
                    viewreport("KHSX_BURRYTAK.rdlc", "KHSX", dt);
                else
                    viewreport("KHSX_KIEM_NQ.rdlc", "KHSX", dt);
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
                        dtgbaocao.Visible = true;
                        dtgbaocao.DataSource = dtExcel;
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
            //getsanphamtheomsql();
        }

        private void tbMSQLKHSX_TextChanged(object sender, EventArgs e)
        {
            //getsanphamtheomsql();
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

        private void sảnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hidepannelfilter();
            dtgbaocao.Visible = true;
            panelbaocaosx.Visible = true;
            getBaocaosx();
        }

        private void btnbaocaosx_Click(object sender, EventArgs e)
        { 
            getBaocaosx();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            xuatexceldtg(dtgbaocao);
        }

        private void sảnXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            hidepannelfilter();
            khsx_idx = 0;
            panelKHSX.Visible = true;
        }

        private void burrytakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hidepannelfilter();
            khsx_idx = 1;
            panelKHSX.Visible = true;
        }

        private void kiểmNgoạiQuangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hidepannelfilter();
            khsx_idx = 2;
            panelKHSX.Visible = true;
        }
    }
}
