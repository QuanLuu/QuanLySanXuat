using Chuong_Trinh_Quan_Ly_San_Xuat.BLL;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace Chuong_Trinh_Quan_Ly_San_Xuat
{
    public partial class FrmKeHoach : Form
    {
        int khsx_idx = 0;
        string loaibc;
        ResourceManager res_man;
        string langue_ge;
        public FrmKeHoach()
        {
            InitializeComponent();
            hidepannelfilter();
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgbaocao, new object[] { true });
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["FrmMain"];
            langue_ge = ((FrmMain)f).languege_set;
            setlangue();

            tbYearCTSX.Text = DateTime.Now.Year.ToString();
            tbmonthCTSX.Text = DateTime.Now.Month.ToString();
            tbNamKHSX.Text = DateTime.Now.Year.ToString();
            tbThangKHSX.Text = DateTime.Now.Month.ToString();
            dtpbaocaosxfrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
            dtpbaocaosxto.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);
            tbnambaocaosx.Text = DateTime.Now.Year.ToString();
            tbthangbaocaosx.Text = DateTime.Now.Month.ToString();
            loadnhanvien();
            dtgbaocao.Dock = DockStyle.Fill;
            reportViewer.Dock = DockStyle.Fill;
            baocaosx();
            GetKhachHang();
            tbNamInvoice.Text = DateTime.Now.Year.ToString();
            tbThangInvoice.Text = DateTime.Now.Month.ToString();
            dtpNgayInvoice.Value = DateTime.Now;
            cbKHinvoice.Text = "NTZC";
            //cleankhsx();
        }
        void GetKhachHang()
        {
            DataTable KH = Import_Manager.Instance.LoadKH("");
            cbKHinvoice.DisplayMember = "MA_KH";
            cbKHinvoice.DataSource = KH;
        }
        void setlangue()
        {
            string res_file = "Chuong_Trinh_Quan_Ly_San_Xuat.lang_vi";
            if (langue_ge == "Japan") res_file = "Chuong_Trinh_Quan_Ly_San_Xuat.lang_ja";
            res_man = new ResourceManager(res_file, Assembly.GetExecutingAssembly());
            setlangforlabel(this);
        }
        void setlangforlabel(Control par)
        {
            foreach (Control c in par.Controls)
            {
                //if(c.GetType().Name =="Label")
                //{
                if (res_man.GetString(c.Text) != null)
                    c.Text = res_man.GetString(c.Text);
                //}
                setlangforlabel(c);
            }
        }
        void setlangforheader(DataGridView dtg)
        {
            string headername = "";
            for (int i = 0; i < dtg.Columns.Count; i++)
            {
                headername = dtg.Columns[i].HeaderText;
                dtg.Columns[i].HeaderText = res_man.GetString(headername);
            }
        }

        void setlangforallgridview()
        {
            if (langue_ge == "Japan")
            {
                setlangforheader(dtgbaocao);     
            }
        }
        void hidepannelfilter()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType().Name == "Panel") c.Visible = false;
            }
            dtgbaocao.Visible = false;
            reportViewer.Visible = true;
        }
        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hidepannelfilter();
            panelCTSX.Visible = true;
        }

        private void invoiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            hidepannelfilter();
            khsx_idx = 0;
            panelKHSX.Visible = true;
        }

        private void thépNXTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            hidepannelfilter();
            khsx_idx = 1;
            panelKHSX.Visible = true;
        }

        private void tiếnĐộToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            hidepannelfilter();
            khsx_idx = 2;
            panelKHSX.Visible = true;
        }

        private void giaCôngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            hidepannelfilter();
            dtpdengayphieuktnl.Value = DateTime.Now;
            dtptungayphieuktnl.Value = DateTime.Now.AddDays(-7);
            panelPhieuktnl.Visible = true;
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
                DataTable dt = Import_Manager.Instance.inCTSX(tbMSQQLCTSX.Text, tbMaSPInCTSX.Text, Int32.Parse(tbYearCTSX.Text), Int32.Parse(tbmonthCTSX.Text));
                viewreport("CTSX.rdlc", "CTSX", dt);
            }
        }
        void getsanphamtheomsql()
        {
            DataTable data = Import_Manager.Instance.getmasptheomsql(tbMSQQLCTSX.Text);
            if (data.Rows.Count > 0) tbMaSPInCTSX.Text = data.Rows[0][1].ToString();

            DataTable khsx = Import_Manager.Instance.getmasptheomsql(tbMSQLKHSX.Text);
            if (khsx.Rows.Count > 0) tbMaSPKHSX.Text = khsx.Rows[0][1].ToString();
        }
        private void btnKHSX_Click(object sender, EventArgs e)
        {
            if (tbNamKHSX.Text != "" && tbThangKHSX.Text != "")
            {
                DataTable dt = Import_Manager.Instance.inCTSX(tbMSQLKHSX.Text, tbMaSPKHSX.Text, Int32.Parse(tbNamKHSX.Text), Int32.Parse(tbThangKHSX.Text));
                if (khsx_idx == 0)
                    viewreport("KHSX_SX.rdlc", "KHSX", dt);
                else if (khsx_idx == 1)
                    viewreport("KHSX_BURRYTAK.rdlc", "KHSX", dt);
                else if(khsx_idx == 2)
                    viewreport("KHSX_KIEM_NQ.rdlc", "KHSX", dt);
                else
                    viewreport("KHSX_TONGVU.rdlc", "KHSX", dt);
            }
        }

        private void btphieuktnl_Click(object sender, EventArgs e)
        {
            DataTable dt = Import_Manager.Instance.phieuktnl(dtptungayphieuktnl.Value, dtpdengayphieuktnl.Value, tbspecphieuktnl.Text, tbsizephieuktnl.Text, cbnhanvienphieuktnl.Text);
            viewreport("PhieuKiemTraNL.rdlc", "PhieuKTNL", dt);
        }

        private void btnbaocaosx_Click(object sender, EventArgs e)
        {
            if (tbnambaocaosx.Text != "" && tbthangbaocaosx.Text != "") getBaocaosx(loaibc);
        }
        void xuatexceldtg(DataGridView dtg)
        {
            Excel._Application excel = new Excel.Application();
            Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Excel._Worksheet worksheet = null;
            string checkdate;
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
                        if (dtg.Rows[r].Cells[c].Value != null)
                        {
                            checkdate = dtg.Rows[r].Cells[c].Value.ToString();
                            if (IsDate(checkdate) == true)
                                arr[rowindex, colindex] = DateTime.Parse(checkdate).ToString("yyyy-MM-dd");
                            else
                                arr[rowindex, colindex] = checkdate;
                        }
                        colindex++;
                    }
                    colindex = 0;
                    rowindex++;
                }

                Excel.Range c1 = (Excel.Range)worksheet.Cells[1, 1];
                Excel.Range c2 = (Excel.Range)worksheet.Cells[1 + dtg.Rows.Count, dtg.Columns.Count + 1];
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
        public bool IsDate(string input)
        {
            DateTime result;
            return DateTime.TryParse(input, out result);
        }
        void cleankhsx()
        {
            int res = Import_Manager.Instance.cleanupkhsx(2);
        }
        void loadnhanvien()
        {
            DataTable data = Import_Manager.Instance.LoadNhanVien();
            cbnhanvienphieuktnl.DisplayMember = "NV";
            cbnhanvienphieuktnl.DataSource = data;
        }
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            xuatexceldtg(dtgbaocao);
        }
        void getBaocaosx(string loaibc)
        {
            if (loaibc == "SX")
            {
                DataTable baocao = Import_Manager.Instance.GetBaoCaoSXThang(Int32.Parse(tbnambaocaosx.Text), Int32.Parse(tbthangbaocaosx.Text));
                dtgbaocao.DataSource = baocao;
            }
            if (loaibc == "NVL")
            {
                DataTable baocao = Import_Manager.Instance.Getthepnxt(Int32.Parse(tbnambaocaosx.Text), Int32.Parse(tbthangbaocaosx.Text));
                dtgbaocao.DataSource = baocao;
            }
            if (loaibc == "DuToanNL")
            {   
                DataTable data = Import_Manager.Instance.dutoannl(Int32.Parse(tbnambaocaosx.Text), Int32.Parse(tbthangbaocaosx.Text));
                dtgbaocao.DataSource = data;
            }
        }
        void baocaosx()
        {
            loaibc = "SX";
            hidepannelfilter();
            dtgbaocao.Visible = true;
            panelbaocaosx.Visible = true;
            reportViewer.Visible = false;
            if (tbnambaocaosx.Text != "" && tbthangbaocaosx.Text != "") getBaocaosx(loaibc);
        }
        
        private void báoCáoSXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baocaosx();
        }

        private void invoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hidepannelfilter();
            panelInvoice.Visible = true;
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {

            if (tbNamInvoice.Text != "" && tbThangInvoice.Text != "")
            {
                DataTable dt = Import_Manager.Instance.reportInvoice(cbKHinvoice.Text, Int32.Parse(tbNamInvoice.Text), Int32.Parse(tbThangInvoice.Text), tbSoInvoice.Text, dtpNgayInvoice.Value);
                viewreport("Invoice.rdlc", "Invoice", dt);
            }
        }

        private void kHTổngVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hidepannelfilter();
            khsx_idx = 3;
            panelKHSX.Visible = true;
        }

        private void dựToánNLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loaibc = "DuToanNL";
            hidepannelfilter();
            dtgbaocao.Visible = true;
            panelbaocaosx.Visible = true;
            reportViewer.Visible = false;
            if (tbnambaocaosx.Text != "" && tbthangbaocaosx.Text != "") getBaocaosx(loaibc);
        }
    }
}
