using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using Chuong_Trinh_Quan_Ly_San_Xuat.BLL;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using System.Resources;

namespace Chuong_Trinh_Quan_Ly_San_Xuat
{
    public partial class FrmDanhMuc : Form
    {
        int actionNL = 0;
        int actionSP = 0;
        int actionKH = 0;
        int actionDM = 0;
        int actionMM = 0;
        int actionSPCD = 0;
        int actionDongia = 0;
        int actionBox = 0;
        int actionBoxSP = 0;
        int actionKHSP = 0;
        int actionNVLNCC = 0;
        string langue_ge;
        ResourceManager res_man;
        string temp = "";
        public FrmDanhMuc()
        {
            InitializeComponent();
            
            dtgNL.Dock = DockStyle.Fill;
            dtgSP.Dock = DockStyle.Fill;
            dtgSPCD.Dock = DockStyle.Fill;
            dtgKH.Dock = DockStyle.Fill;
            dtgDM.Dock = DockStyle.Fill;
            dtgMayMoc.Dock = DockStyle.Fill;

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
           BindingFlags.Instance | BindingFlags.SetProperty, null,
           dtgNL, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgSP, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgSPCD, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
           BindingFlags.Instance | BindingFlags.SetProperty, null,
           dtgDM, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgDongia, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgBoxSP, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgBox, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgDM, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgKHSP, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgMayMoc, new object[] { true });

            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["FrmMain"];
            langue_ge = ((FrmMain)f).languege_set;
            setlangue();

            GetNguyenLieu();
            enablecontrolNL();
            enablecontrolSP();
            enablecontrolSPCD();
            enablecontrolBox();
            enablecontrolBoxSP();
            GetSanPham();
            GetKhachHang();
            enablecontrolKH();
            enablecontrolKHSP();
            GetDinhMuc();
            GetDongia();
            enablecontrolDM();
            enablecontrolMM();
            getmaymoc();
            getSPCD();
            getmaymoccd();
            loadcomboMSQL();
            getbox();
            getloaithung();
            getsanphamSNP();
            getKHSP();
            loadnvl_ncc();

            setlangforallgridview();
            hiddenidcol();
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
            foreach(Control c in par.Controls)
            {
                //if(c.GetType().Name =="Label")
                //{
                    if(res_man.GetString(c.Text) != null)
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
                setlangforheader(dtgBox);
                setlangforheader(dtgBoxSP);
                setlangforheader(dtgDM);
                setlangforheader(dtgDongia);
                setlangforheader(dtgKH);
                setlangforheader(dtgKHSP);
                setlangforheader(dtgMayMoc);
                setlangforheader(dtgNL);
                setlangforheader(dtgNVLNCC);
                setlangforheader(dtgSP);
                setlangforheader(dtgNL);
                setlangforheader(dtgSPCD);

            }
        }
        void hiddenidcol()
        {
            dtgBox.Columns[0].Width = 0;
            dtgBoxSP.Columns[0].Width = 0;
            dtgDM.Columns[0].Width = 0;
            dtgDongia.Columns[0].Width = 0;
            dtgKH.Columns[0].Width = 0;
            dtgKHSP.Columns[0].Width = 0;
            dtgMayMoc.Columns[0].Width = 0;

            dtgNL.Columns[0].Width = 0;
            dtgNVLNCC.Columns[0].Width = 0;
            dtgSP.Columns[0].Width = 0;
            dtgNL.Columns[0].Width = 0;
            dtgSPCD.Columns[0].Width = 0;
        }
        void GetNguyenLieu()
        {
            DataTable data = Import_Manager.Instance.LoadDM_NL(tbFilterNL.Text);
            dtgNL.DataSource = data;
            cbTenNL.DataSource = data;
            cbTenNL.DisplayMember = "TEN_NL";

            cbTenNLNVLNCC.DataSource = data;
            cbTenNLNVLNCC.DisplayMember = "TEN_NL";
            
        }
        void getKHSP()
        {
            DataTable data = Import_Manager.Instance.GetKhvamasp(tbMaKHKHSPFilter.Text, tbmsqlkhspfil.Text);
            dtgKHSP.DataSource = data;
            
        }
        void xuatexceldtg(DataGridView dtg)
        {
            Excel._Application excel = new Excel.Application();
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
        void getbox()
        {
            DataTable data = Import_Manager.Instance.GetBox("");
            dtgBox.DataSource = data;
            
        }
        void getsanphamSNP()
        {
            DataTable data = Import_Manager.Instance.GetSPSNP(tbMSQLBoxSPFilter.Text, tbMaSPBoxFilter.Text);
            dtgBoxSP.DataSource = data;
            
        }
        void getboxbyboxtype()
        {
            DataTable data = Import_Manager.Instance.GetBox(cbloaithung.Text);
            cbkichthuoc.ValueMember = "ID";
            cbkichthuoc.DisplayMember = "KICH_THUOC";
            cbkichthuoc.DataSource = data;
            cbcase.DisplayMember = "CASE_TYPE";
            cbcase.DataSource = data;
        }
        void getloaithung()
        {
            DataTable data = Import_Manager.Instance.Getloaithung();
            cbloaithung.DisplayMember = "LOAI_THUNG";
            cbloaithung.DataSource = data;
        }
        void GetSanPham()
        {
            DataTable data = Import_Manager.Instance.LoadDM_SP(tbFilterSP.Text, tbMaSPDMSP.Text, tbNVLSP.Text);
            dtgSP.DataSource = data;
            
        }
        void getsanphamtheomsql()
        {
            DataTable data = Import_Manager.Instance.getmasptheomsql(tbMSQLDinhMuc.Text);
            cbMaSPDM.DisplayMember = "MA_SP";
            cbMaSPDM.DataSource = data;
            DataTable dongia = Import_Manager.Instance.getmasptheomsql(tbMSQLDongia.Text);
            cbMaSPDongia.DisplayMember = "MA_SP";
            cbMaSPDongia.DataSource = dongia;
            DataTable boxsp = Import_Manager.Instance.getmasptheomsql(tbMSQLBoxSP.Text);
            cbMaSpBoxSP.DisplayMember = "MA_SP";
            cbMaSpBoxSP.DataSource = boxsp;

            DataTable khsp = Import_Manager.Instance.getmasptheomsql(tbMSQLKHSP.Text);
            cbMaSPKHSP.DisplayMember = "MA_SP";
            cbMaSPKHSP.DataSource = khsp;
        }

        void GetKhachHang()
        {
            DataTable data = Import_Manager.Instance.LoadKH(tbFilterKH.Text);
            dtgKH.DataSource = data;
            

            DataTable KH = Import_Manager.Instance.LoadKH("");
            cbMaKHKHSP.DisplayMember = "MA_KH";
            cbMaKHKHSP.DataSource = KH;

            cbNCCNVLNCC.DisplayMember = "MA_KH";
            cbNCCNVLNCC.DataSource = KH;
        }
        void getKHFromSP()
        {
            DataTable data = Import_Manager.Instance.LoadKHFromSP(tbMSQLDongia.Text, "");
            cbMaKHDonGia.DisplayMember = "MA_KH";
            cbMaKHDonGia.DataSource = data;
        }
        void GetDinhMuc()
        {
            DataTable data = Import_Manager.Instance.LoadDM(tbmsqldinhmucfil.Text, tbfilterMaSPDM.Text);
            dtgDM.DataSource = data;
            
        }
        void GetDongia()
        {
            DataTable data = Import_Manager.Instance.LoadDongia(tbMaSPDongiaFilter.Text, tbMSQLDonGiaFilter.Text);
            dtgDongia.DataSource = data;
            
        }

        void getSPCD()
        {
            DataTable spcd = Import_Manager.Instance.getSPCongDoan(tbSPCD.Text, tbMaSPSPCDFilter.Text);
            dtgSPCD.DataSource = spcd;
            
        }


        void getmaymoc()
        {
            DataTable maymoc = Import_Manager.Instance.GetMayMoc();
            dtgMayMoc.DataSource = maymoc;
            
        }
        void getmaymoccd()
        {
            DataTable data = Import_Manager.Instance.GetMayMocCDSP();
            cbMayMocCD.ValueMember = "ID";
            cbMayMocCD.DisplayMember = "MAY_MOC";
            cbMayMocCD.DataSource = data;
        }
        void loadcomboMSQL()
        {
            DataTable data = Import_Manager.Instance.loadcomboMAQL();
            cbMSQL.ValueMember = "ID";
            cbMSQL.DisplayMember = "MSQL";
            cbMSQL.DataSource = data;
        }
        private void tbFilterNL_TextChanged(object sender, EventArgs e)
        {
            GetNguyenLieu();
        }

 
        private void btnNew_Click(object sender, EventArgs e)
        {
            tbTenNL.Text = "";
            tbKichCo.Text = "";
            numNL.Value = 0;
            actionNL = 1;
            enablecontrolNL();
        }
        void enablecontrolNL()
        {
            if (actionNL ==0)
            {
                btnNew.Enabled = true;
                BtnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                panelNL.Visible = false;
            }
            else
            {
                btnNew.Enabled = false;
                BtnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                panelNL.Visible = true;
            }

        }

        void enablecontrolMM()
        {
            if (actionMM == 0)
            {
                btnNewMM.Enabled = true;
                btnEditMM.Enabled = true;
                btnDeleteMM.Enabled = true;
                btnSaveMM.Enabled = false;
                btnCancelMM.Enabled = false;
                panelMM.Visible = false;
            }
            else
            {
                btnNewMM.Enabled = false;
                btnEditMM.Enabled = false;
                btnDeleteMM.Enabled = false;
                btnSaveMM.Enabled = true;
                btnCancelMM.Enabled = true;
                panelMM.Visible = true;
            }

        }

        void enablecontrolDM()
        {
            if (actionDM == 0)
            {
                btnNewDM.Enabled = true;
                btnEditDM.Enabled = true;
                btnDeleteDM.Enabled = true;
                btnSaveDM.Enabled = false;
                btnCancelDM.Enabled = false;
                panelDM.Visible = false;
            }
            else
            {
                btnNewDM.Enabled = false;
                btnEditDM.Enabled = false;
                btnDeleteDM.Enabled = false;
                btnSaveDM.Enabled = true;
                btnCancelDM.Enabled = true;
                panelDM.Visible = true;
            }

        }
        void enablecontrolKH()
        {
            if (actionKH == 0)
            {
                btnNewKH.Enabled = true;
                btnEditKH.Enabled = true;
                btnDeleteKH.Enabled = true;
                btnSaveKH.Enabled = false;
                btnCancelKH.Enabled = false;
                panelKH.Visible = false;
            }
            else
            {
                btnNewKH.Enabled = false;
                btnEditKH.Enabled = false;
                btnDeleteKH.Enabled = false;
                btnSaveKH.Enabled = true;
                btnCancelKH.Enabled = true;
                panelKH.Visible = true;
            }

        }
        void enablecontrolKHSP()
        {
            if (actionKHSP == 0)
            {
                btnNewKHSP.Enabled = true;
                btnEditKHSP.Enabled = true;
                btnDeleteKHSP.Enabled = true;
                btnSaveKHSP.Enabled = false;
                btnCancelKHSP.Enabled = false;
                panelKHSP.Visible = false;
            }
            else
            {
                btnNewKHSP.Enabled = false;
                btnEditKHSP.Enabled = false;
                btnDeleteKHSP.Enabled = false;
                btnSaveKHSP.Enabled = true;
                btnCancelKHSP.Enabled = true;
                panelKHSP.Visible = true;
            }

        }

        void enablecontrol(int act, Panel pal, Panel palentry)
        {

            if (act == 0)
            {
                palentry.Visible = false;
                foreach (Control c in pal.Controls)
                {
                    if (c.Name.Contains("New") || c.Name.Contains("Edit") || c.Name.Contains("Delete"))
                        c.Enabled = true;
                    else
                        c.Enabled = false;
                }
                }
             else
             {
                palentry.Visible = true;
                foreach (Control c in pal.Controls)
                {
                    if (c.Name.Contains("New") || c.Name.Contains("Edit") || c.Name.Contains("Delete"))
                        c.Enabled = false;
                    else
                        c.Enabled = true;
                }
            }
        }
        void enablecontrolSP()
        {
            if (actionSP == 0)
            {
                btnNewSP.Enabled = true;
                btnEditSP.Enabled = true;
                btnDeleteSP.Enabled = true;
                btnSaveSP.Enabled = false;
                btnCancelSP.Enabled = false;
                panelSP.Visible = false;
            }
            else
            {
                btnNewSP.Enabled = false;
                btnEditSP.Enabled = false;
                btnDeleteSP.Enabled = false;
                btnSaveSP.Enabled = true;
                btnCancelSP.Enabled = true;
                panelSP.Visible = true;
            }

        }
        void enablecontrolSPCD()
        {
            if (actionSPCD == 0)
            {
                btnNewSPCD.Enabled = true;
                btnEditSPCD.Enabled = true;
                btnDeleteSPCD.Enabled = true;
                btnSaveSPCD.Enabled = false;
                btnCancelSPCD.Enabled = false;
                panelSPCD.Visible = false;
            }
            else
            {
                btnNewSPCD.Enabled = false;
                btnEditSPCD.Enabled = false;
                btnDeleteSPCD.Enabled = false;
                btnSaveSPCD.Enabled = true;
                btnCancelSPCD.Enabled = true;
                panelSPCD.Visible = true;
            }

        }
        void enablecontrolDongia()
        {
            if (actionDongia == 0)
            {
                btnNewDongia.Enabled = true;
                btnEditDongia.Enabled = true;
                btnDeleteDongia.Enabled = true;
                btnSaveDongia.Enabled = false;
                btnCancelDongia.Enabled = false;
                panelDongia.Visible = false;
            }
            else
            {
                btnNewDongia.Enabled = false;
                btnEditDongia.Enabled = false;
                btnDeleteDongia.Enabled = false;
                btnSaveDongia.Enabled = true;
                btnCancelDongia.Enabled = true;
                panelDongia.Visible = true;
            }

        }

        void enablecontrolBox()
        {
            if (actionBox == 0)
            {
                btnNewBox.Enabled = true;
                btnEditBox.Enabled = true;
                btnDeleteBox.Enabled = true;
                btnSaveBox.Enabled = false;
                btnCancelBox.Enabled = false;
                panelBox.Visible = false;
            }
            else
            {
                btnNewBox.Enabled = false;
                btnEditBox.Enabled = false;
                btnDeleteBox.Enabled = false;
                btnSaveBox.Enabled = true;
                btnCancelBox.Enabled = true;
                panelBox.Visible = true;
            }

        }

        void enablecontrolBoxSP()
        {
            if (actionBoxSP == 0)
            {
                btnNewBoxSP.Enabled = true;
                btnEditBoxSP.Enabled = true;
                btnDeleteBoxSP.Enabled = true;
                btnSaveBoxSP.Enabled = false;
                btnCancelBoxSP.Enabled = false;
                panelBoxSP.Visible = false;
            }
            else
            {
                btnNewBoxSP.Enabled = false;
                btnEditBoxSP.Enabled = false;
                btnDeleteBoxSP.Enabled = false;
                btnSaveBoxSP.Enabled = true;
                btnCancelBoxSP.Enabled = true;
                panelBoxSP.Visible = true;
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            actionNL = 2;
            if (dtgNL.CurrentRow != null)
            {
                tbTenNL.Text = dtgNL.CurrentRow.Cells[1].Value.ToString();
                tbKichCo.Text = dtgNL.CurrentRow.Cells[2].Value.ToString();
                if (dtgNL.CurrentRow.Cells[3].Value.ToString() != "") numNL.Value = Convert.ToDecimal(dtgNL.CurrentRow.Cells[3].Value.ToString());
                if (dtgNL.CurrentRow.Cells[4].Value.ToString() != "") numtonantoanNL.Value = Convert.ToDecimal(dtgNL.CurrentRow.Cells[4].Value.ToString());
            }
            enablecontrolNL();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int currow = current_row(actionNL, dtgNL); ;
            try
            {

                int results = Import_Manager.Instance.UpdateNL(actionNL, (int)dtgNL.CurrentRow.Cells[0].Value, tbTenNL.Text, tbKichCo.Text, numNL.Value, numtonantoanNL.Value);
                GetNguyenLieu();
                dtgNL.CurrentCell = dtgNL.Rows[currow].Cells[0];
                actionNL = 0;
                enablecontrolNL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            actionNL = 0;
            enablecontrolNL();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            actionNL = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateNL(actionNL, (int)dtgNL.CurrentRow.Cells[0].Value, tbTenNL.Text, tbKichCo.Text, numNL.Value, 0);
                actionNL = 0;
                enablecontrolNL();
                GetNguyenLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnNewSP_Click(object sender, EventArgs e)
        {
            tbMaSP.Text = "";
            tbTenSP.Text = "";
            numSP.Value = 0;
            cbTenNL.Text = "";
            actionSP = 1;
            enablecontrolSP();
        }
        int checkmanl(string manl)
        {
            DataTable data = Import_Manager.Instance.checkmanl(manl);
            if (data.Rows.Count > 0)
                return Int32.Parse(data.Rows[0][0].ToString());
            else
                return 0;
        }
        int checkmasp(string masp)
        {
            DataTable data = Import_Manager.Instance.checkmasp(masp);
            if (data.Rows.Count > 0)
                return Int32.Parse(data.Rows[0][0].ToString());
            else
                return 0;
        }
        private void btnEditSP_Click(object sender, EventArgs e)
        {

            actionSP = 2;
            if (dtgSP.CurrentRow != null)
            {
                tbMSQL.Text = dtgSP.CurrentRow.Cells[1].Value.ToString(); ;
                tbMaSP.Text = dtgSP.CurrentRow.Cells[2].Value.ToString();
                tbTenSP.Text = dtgSP.CurrentRow.Cells[3].Value.ToString();
                cbTenNL.Text = dtgSP.CurrentRow.Cells[4].Value.ToString();
                if (dtgSP.CurrentRow.Cells[5].Value.ToString() != "") numSP.Value = Convert.ToDecimal(dtgSP.CurrentRow.Cells[5].Value.ToString());
                if (dtgSP.CurrentRow.Cells[6].Value.ToString() != "") numtonantoanSP.Value = Convert.ToDecimal(dtgSP.CurrentRow.Cells[6].Value.ToString());
            }
            enablecontrolSP();
        }

        private void btnCancelSP_Click(object sender, EventArgs e)
        {

            actionSP = 0;
            enablecontrolSP();
        }

        private void btnSaveSP_Click(object sender, EventArgs e)
        {
            int currow = current_row(actionSP, dtgSP); ;
            try
            {
                int check_manl = checkmanl(cbTenNL.Text);
                if (check_manl > 0)
                {
                    int results = Import_Manager.Instance.UpdateSP(actionSP, (int)dtgSP.CurrentRow.Cells[0].Value, tbMSQL.Text, tbMaSP.Text, tbTenSP.Text, cbTenNL.Text, numSP.Value, numtonantoanSP.Value);
                    GetSanPham();
                    dtgSP.CurrentCell = dtgSP.Rows[currow].Cells[0];
                    actionSP = 0;
                    enablecontrolSP();
                }
                else
                    MessageBox.Show("Please check Ten NL");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void tbFilterSP_TextChanged(object sender, EventArgs e)
        {
            GetSanPham();
        }


        private void btnDeleteSP_Click(object sender, EventArgs e)
        {
            actionSP = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateSP(actionSP, (int)dtgSP.CurrentRow.Cells[0].Value, tbMSQL.Text,tbMaSP.Text, tbTenSP.Text, cbTenNL.Text, numSP.Value,0);
                actionSP = 0;
                enablecontrolSP();
                GetSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnNewKH_Click(object sender, EventArgs e)
        {
            actionKH = 1;
            enablecontrolKH();
            tbMaKH.Text = "";
            tbKH.Text = "";
            tbNguoiLienHe.Text = "";
            tbBoPhan.Text = "";
            tbDiaChi.Text = "";
            tbEmail.Text = "";
            tbSdt.Text = ""; 
        }



        private void btnEditKH_Click(object sender, EventArgs e)
        {
            actionKH = 2;
            if (dtgKH.CurrentRow != null)
            {
                tbMaKH.Text = dtgKH.CurrentRow.Cells[1].Value.ToString();
                tbKH.Text = dtgKH.CurrentRow.Cells[2].Value.ToString();
                tbNguoiLienHe.Text = dtgKH.CurrentRow.Cells[3].Value.ToString();
                tbBoPhan.Text = dtgKH.CurrentRow.Cells[4].Value.ToString();
                tbDiaChi.Text = dtgKH.CurrentRow.Cells[7].Value.ToString();
                tbEmail.Text = dtgKH.CurrentRow.Cells[6].Value.ToString();
                tbSdt.Text = dtgKH.CurrentRow.Cells[5].Value.ToString();
            }
            enablecontrolKH();
        }

        private void btnCancelKH_Click(object sender, EventArgs e)
        {
            actionKH = 0;
            enablecontrolKH();
        }

        private void btnDeleteKH_Click(object sender, EventArgs e)
        {
            actionKH = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateKH(actionKH, (int)dtgKH.CurrentRow.Cells[0].Value, tbMaKH.Text, tbKH.Text, tbNguoiLienHe.Text, tbBoPhan.Text, tbSdt.Text, tbEmail.Text, tbDiaChi.Text);
                actionKH = 0;
                enablecontrolKH();
                GetKhachHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnSaveKH_Click(object sender, EventArgs e)
        {
            int currow = current_row(actionKH, dtgKH);
            try
            {
                int results = Import_Manager.Instance.UpdateKH(actionKH, (int)dtgKH.CurrentRow.Cells[0].Value, tbMaKH.Text, tbKH.Text, tbNguoiLienHe.Text, tbBoPhan.Text, tbSdt.Text, tbEmail.Text, tbDiaChi.Text);
                GetKhachHang();
                dtgKH.CurrentCell = dtgKH.Rows[currow].Cells[0];
                actionKH = 0;
                enablecontrolKH();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnNewDM_Click(object sender, EventArgs e)
        {
            actionDM = 1;
            cbMaSPDM.Text = "";
            numDinhMuc.Value = 0;
            dtpDateFrom.Value = DateTime.Now;
            enablecontrolDM();
        }

        private void btnNewMM_Click(object sender, EventArgs e)
        {
            actionMM = 1;
            tbTenMay.Text = "";
            tbSoMay.Text = "";
            enablecontrolMM();
        }

        private void btnEditMM_Click(object sender, EventArgs e)
        {
            actionMM = 2;
            if (dtgMayMoc.CurrentRow != null)
            {
                tbTenMay.Text = dtgMayMoc.CurrentRow.Cells[1].Value.ToString();
                tbSoMay.Text = dtgMayMoc.CurrentRow.Cells[2].Value.ToString();
                tbMamay.Text = dtgMayMoc.CurrentRow.Cells[3].Value.ToString(); ;
            }
            enablecontrolMM();
        }

        private void btnDeleteMM_Click(object sender, EventArgs e)
        {
            actionMM = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateMaymoc(actionMM, (int)dtgMayMoc.CurrentRow.Cells[0].Value, tbTenMay.Text, tbSoMay.Text, tbMamay.Text);
                actionMM = 0;
                enablecontrolMM();
                getmaymoc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnCancelMM_Click(object sender, EventArgs e)
        {
            actionMM = 0;
            enablecontrolMM();
        }

        private void btnSaveMM_Click(object sender, EventArgs e)
        {
            int currow = current_row(actionMM, dtgMayMoc);
            try
            {
                int results = Import_Manager.Instance.UpdateMaymoc(actionMM, (int)dtgMayMoc.CurrentRow.Cells[0].Value, tbTenMay.Text, tbSoMay.Text, tbMamay.Text);
                getmaymoc();
                dtgMayMoc.CurrentCell = dtgMayMoc.Rows[currow].Cells[0];
                actionMM = 0;
                enablecontrolMM();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        private void btnEditDM_Click(object sender, EventArgs e)
        {
            actionDM = 2;
            if (dtgDM.CurrentRow.Cells[0].Value.ToString() != "")
            {
                dtpDateFrom.Value = DateTime.Parse(dtgDM.CurrentRow.Cells[1].Value.ToString());
                tbMSQLDinhMuc.Text = dtgDM.CurrentRow.Cells[2].Value.ToString();
                numDinhMuc.Text = dtgDM.CurrentRow.Cells[5].Value.ToString();
            }
            enablecontrolDM();
        }

        private void btnDeleteDM_Click(object sender, EventArgs e)
        {
            actionDM = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateDinhMuc(actionDM, (int)dtgDM.CurrentRow.Cells[0].Value, dtpDateFrom.Value, cbMaSPDM.Text, numDinhMuc.Value);
                actionDM = 0;
                enablecontrolDM();
                GetDinhMuc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnSaveDM_Click(object sender, EventArgs e)
        {
            int currow = current_row(actionDM, dtgDM);
            try
            {
                int results = Import_Manager.Instance.UpdateDinhMuc(actionDM, (int)dtgDM.CurrentRow.Cells[0].Value, dtpDateFrom.Value.Date, cbMaSPDM.Text, numDinhMuc.Value);
                GetDinhMuc();
                dtgDM.CurrentCell = dtgDM.Rows[currow].Cells[0];
                actionDM = 0;
                enablecontrolDM();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void btnCancelDM_Click(object sender, EventArgs e)
        {
            actionDM = 0;
            enablecontrolDM();
        }

        private void tbfilterMaSPDM_TextChanged(object sender, EventArgs e)
        {
            GetDinhMuc();
        }

        private void btnNewSPCD_Click(object sender, EventArgs e)
        {
            actionSPCD = 1;
            enablecontrolSPCD();
            tbMaCD.Text = "";
            tbTenCD.Text = "";
            tbMamay.Text = "";
        }

        private void btnEditSPCD_Click(object sender, EventArgs e)
        {
            actionSPCD = 2;
            if (dtgSPCD.CurrentRow.Cells[0].Value.ToString() != "")
            {
                cbMSQL.Text = dtgSPCD.CurrentRow.Cells[1].Value.ToString() + " - " + dtgSPCD.CurrentRow.Cells[2].Value.ToString();
                tbMaCD.Text = dtgSPCD.CurrentRow.Cells[3].Value.ToString();
                tbTenCD.Text = dtgSPCD.CurrentRow.Cells[4].Value.ToString();
                //cbMayMocCD.Text = "";
                cbMayMocCD.Text = "Tên:" + dtgSPCD.CurrentRow.Cells[5].Value.ToString() + " - Số:" + dtgSPCD.CurrentRow.Cells[6].Value.ToString() + " - Mã:" + dtgSPCD.CurrentRow.Cells[7].Value.ToString();
                numCDso.Text = dtgSPCD.CurrentRow.Cells[8].Value.ToString();
            }
            enablecontrolSPCD();
        }

        private void btnCancelSPCD_Click(object sender, EventArgs e)
        {
            actionSPCD = 0;
            enablecontrolSPCD();
        }

        private void tbSPCD_TextChanged(object sender, EventArgs e)
        {
            getSPCD();
        }

        private void btnSaveSPCD_Click(object sender, EventArgs e)
        {
            int currow = current_row(actionSPCD, dtgSPCD);
            int id_may = 39;
            try
            {
                if (cbMayMocCD.Text != "") id_may = Int32.Parse(cbMayMocCD.SelectedValue.ToString());
                int results = Import_Manager.Instance.UpdateSPCongDoan(actionSPCD, (int)dtgSPCD.CurrentRow.Cells[0].Value,tbMaCD.Text, tbTenCD.Text, id_may,Int32.Parse(cbMSQL.SelectedValue.ToString()), (int)numCDso.Value);
                getSPCD();
                dtgSPCD.CurrentCell = dtgSPCD.Rows[currow].Cells[0];
                actionSPCD = 0;
                enablecontrolSPCD();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDeleteSPCD_Click(object sender, EventArgs e)
        {
            actionSPCD = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateSPCongDoan(actionSPCD, (int)dtgSPCD.CurrentRow.Cells[0].Value, tbMaCD.Text, tbTenCD.Text, 0, 0,0);
                actionSPCD = 0;
                enablecontrolSPCD();
                getSPCD();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        private void tbMSQLDinhMuc_TextChanged(object sender, EventArgs e)
        {
            getsanphamtheomsql();
        }

        private void btnNewDongia_Click(object sender, EventArgs e)
        {
            actionDongia = 1;
            tbMSQLDongia.Text = "";
            numDongia.Value = 0;
            enablecontrolDongia();
        }

        private void btnEditDongia_Click(object sender, EventArgs e)
        {
            actionDongia = 2;
            if (dtgDongia.CurrentRow.Cells[0].Value.ToString() != "")
            {
                dtpDongia.Value = DateTime.Parse(dtgDongia.CurrentRow.Cells[1].Value.ToString());
                tbMSQLDongia.Text = dtgDongia.CurrentRow.Cells[2].Value.ToString();
                numDongia.Text = dtgDongia.CurrentRow.Cells[5].Value.ToString();
            }
            enablecontrolDongia();
        }

        private void btnCancelDongia_Click(object sender, EventArgs e)
        {
            actionDongia = 0;
            enablecontrolDongia();
        }

        private void btnDeleteDongia_Click(object sender, EventArgs e)
        {
   
            actionDongia = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateDongia(actionDongia, (int)dtgDongia.CurrentRow.Cells[0].Value, dtpDongia.Value.Date, cbMaSPDongia.Text, numDongia.Value, cbMaKHDonGia.Text);
                actionDongia = 0;
                enablecontrolDongia();
                GetDongia();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void tbMaSPDongiaFilter_TextChanged(object sender, EventArgs e)
        {
            GetDongia();
        }

        private void btnSaveDongia_Click(object sender, EventArgs e)
        {
            int currow = current_row(actionDongia, dtgDongia);
            int id = 0;
            
            try
            {
                if (dtgDongia.Rows.Count > 1 && dtgDongia.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgDongia.CurrentRow.Cells[0].Value;
                int results = Import_Manager.Instance.UpdateDongia(actionDongia, id, dtpDongia.Value.Date, cbMaSPDongia.Text, numDongia.Value, cbMaKHDonGia.Text);
                GetDongia();
                dtgDongia.CurrentCell = dtgDongia.Rows[currow].Cells[0];
                actionDongia = 0;
                enablecontrolDongia();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbMSQLDongia_TextChanged(object sender, EventArgs e)
        {
            getsanphamtheomsql();
            getKHFromSP();
        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnNewBox_Click(object sender, EventArgs e)
        {
            actionBox = 1;
            enablecontrolBox();
            tbloaithung.Text = "";
            tbkichthuocbox.Text = "";
            tbcase.Text = "";
        }

        private void btnNewBoxSP_Click(object sender, EventArgs e)
        {
            actionBoxSP = 1;
            enablecontrolBoxSP();
            tbMSQLBoxSP.Text = "";
            numSNP.Value = 0;
        }

        private void btnEditBoxSP_Click(object sender, EventArgs e)
        {
            actionBoxSP = 2;
            if (dtgBoxSP.CurrentRow != null)
            {
                tbMSQLBoxSP.Text = dtgBoxSP.CurrentRow.Cells[1].Value.ToString();
                numSNP.Text = dtgBoxSP.CurrentRow.Cells[4].Value.ToString();
                cbloaithung.Text = dtgBoxSP.CurrentRow.Cells[5].Value.ToString();
                cbkichthuoc.Text = dtgBoxSP.CurrentRow.Cells[6].Value.ToString();
                cbcase.Text = dtgBoxSP.CurrentRow.Cells[7].Value.ToString();
            }
            enablecontrolBoxSP();
        }

        private void btnEditBox_Click(object sender, EventArgs e)
        {
            actionBox = 2;
            if (dtgBox.CurrentRow != null)
            {
                tbloaithung.Text = dtgBox.CurrentRow.Cells[1].Value.ToString();
                tbkichthuocbox.Text = dtgBox.CurrentRow.Cells[2].Value.ToString();
                tbcase.Text = dtgBox.CurrentRow.Cells[3].Value.ToString();
            }
            enablecontrolBox();
        }

        private void btnCancelBoxSP_Click(object sender, EventArgs e)
        {
            actionBoxSP = 0;
            enablecontrolBoxSP();
        }

        private void btnCancelBox_Click(object sender, EventArgs e)
        {
            actionBox = 0;
            enablecontrolBox();
        }

        private void cbloaithung_SelectedIndexChanged(object sender, EventArgs e)
        {
            getboxbyboxtype();
        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void cbkichthuoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveBoxSP_Click(object sender, EventArgs e)
        {
            int currow = current_row(actionBoxSP, dtgBoxSP);
            int id = 0;

            try
            {
                if (dtgBoxSP.Rows.Count > 1 && dtgBoxSP.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgBoxSP.CurrentRow.Cells[0].Value;
                int results = Import_Manager.Instance.UpdateSanphamSNP(actionBoxSP, id,cbMaSpBoxSP.Text, (int)numSNP.Value,  cbloaithung.Text, cbkichthuoc.Text, cbcase.Text);
                getsanphamSNP();
                dtgBoxSP.CurrentCell = dtgBoxSP.Rows[currow].Cells[0];
                actionBoxSP = 0;
                enablecontrolBoxSP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveBox_Click(object sender, EventArgs e)
        {
            int currow = current_row(actionBox, dtgBox);
            int id = 0;

            try
            {

                if (dtgBox.Rows.Count > 1 && dtgBox.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgBox.CurrentRow.Cells[0].Value;
                int results = Import_Manager.Instance.UpdateBOX(actionBox, id, tbloaithung.Text, tbkichthuocbox.Text, tbcase.Text);
                getbox();
                dtgBox.CurrentCell = dtgBox.Rows[currow].Cells[0];
                actionBox = 0;
                enablecontrolBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteBox_Click(object sender, EventArgs e)
        {

            actionBox = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateBOX(actionBox, (int)dtgBox.CurrentRow.Cells[0].Value, tbloaithung.Text, tbkichthuocbox.Text, tbcase.Text);
                actionBox = 0;
                enablecontrolBox();
                getbox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void tbMSQLBoxSPFilter_TextChanged(object sender, EventArgs e)
        {
            getsanphamSNP();
        }

        private void btnDeleteBoxSP_Click(object sender, EventArgs e)
        {

            actionBoxSP = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateSanphamSNP(actionBoxSP, (int)dtgBoxSP.CurrentRow.Cells[0].Value, cbMaSpBoxSP.Text, (int)numSNP.Value, cbloaithung.Text, cbkichthuoc.Text, cbcase.Text);
                actionBoxSP = 0;
                enablecontrolBoxSP();
                getsanphamSNP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void tbMSQLBoxSP_TextChanged(object sender, EventArgs e)
        {
            getsanphamtheomsql();
        }

        private void tbMaKHKHSPFilter_TextChanged(object sender, EventArgs e)
        {
            getKHSP();
        }

        private void tbMSQLKHSP_TextChanged(object sender, EventArgs e)
        {
            getsanphamtheomsql();
        }

        private void btnNewKHSP_Click(object sender, EventArgs e)
        {
            actionKHSP = 1;
            enablecontrolKHSP();
            cbMaKHKHSP.Text = "";
            tbMSQLKHSP.Text = "";
        }

        private void btnEditKHSP_Click(object sender, EventArgs e)
        {
            actionKHSP = 2;
            if (dtgKHSP.CurrentRow != null)
            {
                cbMaKHKHSP.Text = dtgKHSP.CurrentRow.Cells[1].Value.ToString();
                tbMSQLKHSP.Text = dtgKHSP.CurrentRow.Cells[2].Value.ToString();

            }
            enablecontrolKHSP();
        }

        private void btnCancelKHSP_Click(object sender, EventArgs e)
        {
            actionKHSP = 0;
            enablecontrolKHSP();
        }
        private void btnSaveKHSP_Click(object sender, EventArgs e)
        {
            int currow = current_row(actionKHSP, dtgKHSP);
            int id = 0;

            try
            {
                if (dtgKHSP.Rows.Count > 1 && dtgKHSP.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgKHSP.CurrentRow.Cells[0].Value;
                int results = Import_Manager.Instance.UpdateKHSP(actionKHSP, id, cbMaKHKHSP.Text, cbMaSPKHSP.Text);
                getKHSP();
                dtgKHSP.CurrentCell = dtgKHSP.Rows[currow].Cells[0];
                actionKHSP = 0;
                enablecontrolKHSP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteKHSP_Click(object sender, EventArgs e)
        {

            actionKHSP = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateKHSP(actionKHSP, (int)dtgKHSP.CurrentRow.Cells[0].Value, cbMaKHKHSP.Text, cbMaSPKHSP.Text);
                actionKHSP = 0;
                enablecontrolKHSP();
                getKHSP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void tbMSQLDonGiaFilter_TextChanged(object sender, EventArgs e)
        {
            GetDongia();
        }

        private void tbMaSPDMSP_TextChanged(object sender, EventArgs e)
        {
            GetSanPham();
        }

        private void tbMaSPSPCDFilter_TextChanged(object sender, EventArgs e)
        {
            getSPCD();
        }

        private void tbMaSPBoxFilter_TextChanged(object sender, EventArgs e)
        {
            getsanphamSNP();
        }

        private void btnNewNVLNCC_Click(object sender, EventArgs e)
        {
            actionNVLNCC = 1;
            enablecontrol(actionNVLNCC, panelnvlncc, panelNVLNCCEntry);
            cbTenNLNVLNCC.Text = "";
            cbNCCNVLNCC.Text = "";
        }

        private void btnEditNVLNCC_Click(object sender, EventArgs e)
        {
            actionNVLNCC = 2;
            enablecontrol(actionNVLNCC, panelnvlncc, panelNVLNCCEntry);
            if (dtgNVLNCC.CurrentRow != null)
            {
                cbTenNLNVLNCC.Text = dtgNVLNCC.CurrentRow.Cells[1].Value.ToString();
                cbNCCNVLNCC.Text = dtgNVLNCC.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void btnSaveNVLNCC_Click(object sender, EventArgs e)
        {
            int currow = current_row(actionNVLNCC, dtgNVLNCC);
            int id = 0;
            try
            { 
                if (dtgNVLNCC.Rows.Count > 1 && dtgNVLNCC.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgNVLNCC.CurrentRow.Cells[0].Value;
                int result = Import_Manager.Instance.UpdateNVL_NCC(actionNVLNCC, id, cbTenNLNVLNCC.Text, cbNCCNVLNCC.Text);
                actionNVLNCC = 0;
                enablecontrol(actionNVLNCC, panelnvlncc, panelNVLNCCEntry);
                loadnvl_ncc();
                dtgNVLNCC.CurrentCell = dtgNVLNCC.Rows[currow].Cells[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int current_row(int act, DataGridView dtg)
        {
            int currow = 0;
            if (act == 2)
                currow = dtg.CurrentRow.Index;
            else if (act == 1)
                currow = dtg.Rows.Count - 1;
            else
                currow = 0;
            return currow;
        }
        void loadnvl_ncc()
        {
            DataTable data = Import_Manager.Instance.GetNVL_NCC(tbNVLNVLNCC.Text, tbNCCNVLNCC.Text);
            dtgNVLNCC.DataSource = data;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            actionNVLNCC = 3;
            try
            {
                int result = Import_Manager.Instance.UpdateNVL_NCC(actionNVLNCC, (int)dtgNVLNCC.CurrentRow.Cells[0].Value, cbTenNLNVLNCC.Text, cbNCCNVLNCC.Text);
                actionNVLNCC = 0;
                enablecontrol(actionNVLNCC, panelnvlncc, panelNVLNCCEntry);
                loadnvl_ncc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelNVLNCC_Click(object sender, EventArgs e)
        {
            actionNVLNCC = 0;
            enablecontrol(actionNVLNCC, panelnvlncc, panelNVLNCCEntry);
        }

        private void tbNVLNVLNCC_TextChanged(object sender, EventArgs e)
        {
            loadnvl_ncc();
        }

        private void tbNCCNVLNCC_TextChanged(object sender, EventArgs e)
        {
            loadnvl_ncc();
        }

        private void tbNVLSP_TextChanged(object sender, EventArgs e)
        {
            GetSanPham();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            xuatexceldtg(dtgNL);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xuatexceldtg(dtgKH);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            xuatexceldtg(dtgSP);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            xuatexceldtg(dtgDM);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            xuatexceldtg(dtgMayMoc);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            xuatexceldtg(dtgSPCD);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            xuatexceldtg(dtgDongia);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            xuatexceldtg(dtgBox);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            xuatexceldtg(dtgBoxSP);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            xuatexceldtg(dtgKHSP);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            xuatexceldtg(dtgNVLNCC);
        }

        private void tbmsqlkhspfil_TextChanged(object sender, EventArgs e)
        {
            getKHSP();
        }

        private void tbmsqldinhmucfil_TextChanged(object sender, EventArgs e)
        {
            GetDinhMuc();
        }

    
    }
}
