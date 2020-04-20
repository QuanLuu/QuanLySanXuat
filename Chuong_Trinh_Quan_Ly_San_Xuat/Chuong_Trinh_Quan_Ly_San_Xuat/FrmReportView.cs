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
using System.Resources;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Chuong_Trinh_Quan_Ly_San_Xuat
{
    public partial class FrmReportView : Form
    {
        string nxt = "";
        int khsx_idx = 0;
        string langue_ge;
        ResourceManager res_man;
        string loaibc;
        string nhapxuatgc = "";
        string temp = "";
        public FrmReportView()
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

            tbnambaocaosx.Text = DateTime.Now.Year.ToString();
            tbthangbaocaosx.Text = DateTime.Now.Month.ToString();
            loadnhanvien();

            //getallcomponettext(this);
            //tbMSQQLCTSX.Text = temp;
        }
        void getallcomponettext(Control par)
        {
            foreach (Control c in par.Controls)
            {
                temp += "," + c.Text;
                getallcomponettext(c);
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
        void getBaocaosx(string loaibc)
        {
            if (loaibc == "SX")
            {
                //DataTable baocao = Import_Manager.Instance.getbaocaosx(dtpbaocaosxfrom.Value, dtpbaocaosxto.Value);
                DataTable baocao = Import_Manager.Instance.GetBaoCaoSXThang(Int32.Parse(tbnambaocaosx.Text), Int32.Parse(tbthangbaocaosx.Text));
                dtgbaocao.DataSource = baocao;
            }
            if (loaibc == "NVL")
            {
                //DataTable baocao = Import_Manager.Instance.getbaocaosx(dtpbaocaosxfrom.Value, dtpbaocaosxto.Value);
                DataTable baocao = Import_Manager.Instance.Getthepnxt(Int32.Parse(tbnambaocaosx.Text), Int32.Parse(tbthangbaocaosx.Text));
                dtgbaocao.DataSource = baocao;
            }
            
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
        int getmaxidimport()
        {
            try
            {
                DataTable data = Import_Manager.Instance.GetMAxIDImport();
                return Int32.Parse(data.Rows[0][0].ToString());
            }
            catch
            {
                return -1;
            }
        }
        void importfile()
        {
            try
            {
                int data = Import_Manager.Instance.ImportFile();
                DataTable err = Import_Manager.Instance.GetErrormport();
                if(err.Rows.Count > 0)
                {
                    MessageBox.Show("Error: " + err.Rows[0][0].ToString());
                }
            }
            catch
            {
                MessageBox.Show("error while importing files");
            }
        }
        private void cậpNhậtDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int max_id = getmaxidimport();
                if (max_id == -1) return;
                importfile();
                int result = Import_Manager.Instance.UpdateDuLieu(max_id);
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
            loaibc = "SX";
            hidepannelfilter();
            dtgbaocao.Visible = true;
            panelbaocaosx.Visible = true;
            if(tbnambaocaosx.Text != "" && tbthangbaocaosx.Text != "") getBaocaosx(loaibc);
        }

        private void btnbaocaosx_Click(object sender, EventArgs e)
        {

            if (tbnambaocaosx.Text != "" && tbthangbaocaosx.Text != "") getBaocaosx(loaibc);
            
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

        private void btreporttiendo_Click(object sender, EventArgs e)
        {
            if (tbtunamtiendo.Text != "" && tbtuthangtiendo.Text != "" && tbdennamtiendo.Text != "" && tbdenthangtiendo.Text != "" && tbmsqltiendo.Text != "")
            {
                if (nhapxuatgc == "")
                {
                    DataTable dt = Import_Manager.Instance.baocaotiendo(Int32.Parse(tbtunamtiendo.Text), Int32.Parse(tbtuthangtiendo.Text), Int32.Parse(tbdennamtiendo.Text), Int32.Parse(tbdenthangtiendo.Text), tbmsqltiendo.Text, cbmacdtiendo.Text);
                    viewreport("BaoCaoTienDo.rdlc", "BaoCaoTienDo", dt);
                }
                if (nhapxuatgc != "")
                {
                    DataTable dt = Import_Manager.Instance.GetTienDoGiaCongThang(tbmsqltiendo.Text, Int32.Parse(tbtunamtiendo.Text), Int32.Parse(tbtuthangtiendo.Text), Int32.Parse(tbdennamtiendo.Text), Int32.Parse(tbdenthangtiendo.Text), nhapxuatgc);
                    viewreport("TienDoGCThang.rdlc", "TienDoGCThang", dt);
                }
            }
        }

        private void tiếnĐộToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }
        void getmacongdoantheomsql()
        {
            DataTable data = Import_Manager.Instance.Loadcongdoantheomsql(tbmsqltiendo.Text);
            cbmacdtiendo.DisplayMember = "MA_CONG_DOAN";
            cbmacdtiendo.DataSource = data;

            DataTable data1 = Import_Manager.Instance.Loadcongdoantheomsql(tbmsqlngaytiendo.Text);
            cbmacdngaytiendo.DisplayMember = "MA_CONG_DOAN";
            cbmacdngaytiendo.DataSource = data1;

        }


        private void theoThángToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nhapxuatgc = "N";
            hidepannelfilter();
            tbnamngaytiendo.Text = DateTime.Now.Year.ToString();
            tbthangngaytiendo.Text = DateTime.Now.Month.ToString();
            
            paneltiendongay.Visible = true;

        }

        private void theoNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nhapxuatgc = "";
            hidepannelfilter();
            tbtunamtiendo.Text = DateTime.Now.Year.ToString();
            tbdennamtiendo.Text = DateTime.Now.Year.ToString();          
            paneltiendo.Visible = true;
        }

        private void tbngaytiendo_Click(object sender, EventArgs e)
        {
            if (tbmsqlngaytiendo.Text != "" && tbnamngaytiendo.Text != "" && tbthangngaytiendo.Text != "" )
            {
                if (nhapxuatgc == "")
                {
                    DataTable dt = Import_Manager.Instance.baocaotiendongay(tbmsqlngaytiendo.Text, cbmacdngaytiendo.Text, Int32.Parse(tbnamngaytiendo.Text), Int32.Parse(tbthangngaytiendo.Text));
                    viewreport("TienDoNgay.rdlc", "TienDoNgay", dt);
                }
                if (nhapxuatgc != "")
                {
                    DataTable dt = Import_Manager.Instance.GetTienDoGiaCong(tbmsqlngaytiendo.Text, Int32.Parse(tbnamngaytiendo.Text), Int32.Parse(tbthangngaytiendo.Text), nhapxuatgc);
                    viewreport("TienDoGCNgay.rdlc", "TienDoGCNgay", dt);
                }
            }
        }

        private void tbmsqlngaytiendo_TextChanged(object sender, EventArgs e)
        {
            getmacongdoantheomsql();
        }

        private void tbmsqltiendo_TextChanged(object sender, EventArgs e)
        {
            getmacongdoantheomsql();
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
                //if (c.GetType().Name == "Label")
                //{
                    if (res_man.GetString(c.Text) != null)
                        c.Text = res_man.GetString(c.Text);
                //}
                setlangforlabel(c);
            }
        }

        private void thépNXTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loaibc = "NVL";
            hidepannelfilter();
            dtgbaocao.Visible = true;
            panelbaocaosx.Visible = true;
            if (tbnambaocaosx.Text != "" && tbthangbaocaosx.Text != "") getBaocaosx(loaibc);
        }

        private void ngàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nhapxuatgc = "N";
            hidepannelfilter();
            tbnamngaytiendo.Text = DateTime.Now.Year.ToString();
            tbthangngaytiendo.Text = DateTime.Now.Month.ToString();
            paneltiendongay.Visible = true;
        }

        private void theoNgàyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            nhapxuatgc = "X";
            hidepannelfilter();
            tbnamngaytiendo.Text = DateTime.Now.Year.ToString();
            tbthangngaytiendo.Text = DateTime.Now.Month.ToString();
            paneltiendongay.Visible = true;
        }

        private void theoThángToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            nhapxuatgc = "N";
            hidepannelfilter();
            tbtunamtiendo.Text = DateTime.Now.Year.ToString();
            tbdennamtiendo.Text = DateTime.Now.Year.ToString();
            paneltiendo.Visible = true;
        }

        private void theoThángToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            nhapxuatgc = "X";
            hidepannelfilter();
            tbtunamtiendo.Text = DateTime.Now.Year.ToString();
            tbdennamtiendo.Text = DateTime.Now.Year.ToString();
            paneltiendo.Visible = true;
        }

        private void phiếuKiểmTraNLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hidepannelfilter();
            dtpdengayphieuktnl.Value = DateTime.Now;
            dtptungayphieuktnl.Value = DateTime.Now.AddDays(-7);
            panelPhieuktnl.Visible = true;
        }

        private void btphieuktnl_Click(object sender, EventArgs e)
        {
            DataTable dt = Import_Manager.Instance.phieuktnl(dtptungayphieuktnl.Value, dtpdengayphieuktnl.Value, tbspecphieuktnl.Text, tbsizephieuktnl.Text, cbnhanvienphieuktnl.Text);
            viewreport("PhieuKiemTraNL.rdlc", "PhieuKTNL", dt);
        }
        void loadnhanvien()
        {
            DataTable data = Import_Manager.Instance.LoadNhanVien();
            cbnhanvienphieuktnl.DisplayMember = "NV";
            cbnhanvienphieuktnl.DataSource = data;
        }
    }
}
