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
          

            dtptonxtnvl.Value = DateTime.Now;
            dtpfromnxtnvl.Value = DateTime.Now.AddDays(-30);
            reportViewer.Dock = DockStyle.Fill;
            tbnambaocaosx.Text = DateTime.Now.Year.ToString();
            tbthangbaocaosx.Text = DateTime.Now.Month.ToString();
            dtgbaocao.Dock = DockStyle.Fill;
            
            

            //getallcomponettext(this);
            //tbMSQQLCTSX.Text = temp;
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
      
       
        void viewreport(string reportname, string datasetname, DataTable dt)
        {
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.LocalReport.ReportPath = reportname;
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource(datasetname, dt));
            reportViewer.RefreshReport();
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
      

        private void pOPassToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
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

        private void cậpNhậtDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void nhậpXuấtTồnToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void kếHoạchSXToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
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
       

        private void button1_Click_1(object sender, EventArgs e)
        {
           
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

       
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            xuatexceldtg(dtgbaocao);
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
            DataTable data = Import_Manager.Instance.Loadcongdoantheomsql(tbmsqltiendo.Text,"");
            cbmacdtiendo.DisplayMember = "MA_CONG_DOAN";
            cbmacdtiendo.DataSource = data;

            DataTable data1 = Import_Manager.Instance.Loadcongdoantheomsql(tbmsqlngaytiendo.Text,"");
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

        private void invoiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void thépNXTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            loaibc = "NVL";
            hidepannelfilter();
            dtgbaocao.Visible = true;
            reportViewer.Visible = false;
            panelbaocaosx.Visible = true;
            if (tbnambaocaosx.Text != "" && tbthangbaocaosx.Text != "") getBaocaosx(loaibc);
        }

        private void theoNgàyToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            nhapxuatgc = "";
            hidepannelfilter();
            tbnamngaytiendo.Text = DateTime.Now.Year.ToString();
            tbthangngaytiendo.Text = DateTime.Now.Month.ToString();
            paneltiendongay.Visible = true;
        }

        private void theoThángToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            nhapxuatgc = "";
            hidepannelfilter();
            tbtunamtiendo.Text = DateTime.Now.Year.ToString();
            tbdennamtiendo.Text = DateTime.Now.Year.ToString();
            paneltiendo.Visible = true;
        }

        private void theoNgàyToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            nhapxuatgc = "N";
            hidepannelfilter();
            tbnamngaytiendo.Text = DateTime.Now.Year.ToString();
            tbthangngaytiendo.Text = DateTime.Now.Month.ToString();
            paneltiendongay.Visible = true;
        }

        private void theoThángToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            nhapxuatgc = "N";
            hidepannelfilter();
            tbtunamtiendo.Text = DateTime.Now.Year.ToString();
            tbdennamtiendo.Text = DateTime.Now.Year.ToString();
            paneltiendo.Visible = true;
        }

        private void theoNgàyToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            nhapxuatgc = "X";
            hidepannelfilter();
            tbnamngaytiendo.Text = DateTime.Now.Year.ToString();
            tbthangngaytiendo.Text = DateTime.Now.Month.ToString();
            paneltiendongay.Visible = true;
        }

        private void theoThángToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            nhapxuatgc = "X";
            hidepannelfilter();
            tbtunamtiendo.Text = DateTime.Now.Year.ToString();
            tbdennamtiendo.Text = DateTime.Now.Year.ToString();
            paneltiendo.Visible = true;
        }

        private void btnbaocaosx_Click(object sender, EventArgs e)
        {

        }

        private void btnbaocaosx_Click_1(object sender, EventArgs e)
        {
            if (tbnambaocaosx.Text != "" && tbthangbaocaosx.Text != "") getBaocaosx(loaibc);
        }
    }
}
