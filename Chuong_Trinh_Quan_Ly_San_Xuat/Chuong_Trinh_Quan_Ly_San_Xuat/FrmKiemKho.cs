using Chuong_Trinh_Quan_Ly_San_Xuat.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Chuong_Trinh_Quan_Ly_San_Xuat
{
    public partial class FrmKiemKho : Form
    {
        int actionKKTP = 0;
        int actionKKNL = 0;
        int actionKKBanTP = 0;
        //string congdoan = "BAN CONG DOAN";
        string bophan = "";
        string usernhap = "";
        string phanquyen;
        string langue_ge;
        ResourceManager res_man;
        string temp = "";
        public FrmKiemKho()
        {
            InitializeComponent();
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgKKTP, new object[] { true });
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgNL, new object[] { true });
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgbanTP, new object[] { true });
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgbaoluu, new object[] { true });
            dtgKKTP.Dock = DockStyle.Fill;
            dtgNL.Dock = DockStyle.Fill;
            dtgbanTP.Dock = DockStyle.Fill;
            dtgbaoluu.Dock = DockStyle.Fill;
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["FrmMain"];
            usernhap = ((FrmMain)f).tbTenDN.Text.ToString();
            phanquyen = ((FrmMain)f).quyensudung;
            bophan = bophankiemke(usernhap);
            langue_ge = ((FrmMain)f).languege_set;
            setlangue();
            getthanhpham();
            getkiemkhonl();
            GetNguyenLieu();
            getbanthanhpham();
            dtpGiacongTP.Value = DateTime.Now;
            dtpKiemTP.Value = DateTime.Now;
            dtpNgayKiemFilter.Value = DateTime.Now;
            dtpngaykiemNL.Value = DateTime.Now;
            dtpngaykiemNLFilter.Value = DateTime.Now;
            dtpngaykiembantp.Value = DateTime.Now;
            dtpngaykiembantpfil.Value = DateTime.Now;
            loadnhanvien();
            phanquyennhaplieu();
            gettencongdoan();

            setlangforallgridview();
            dtgNL.Columns[0].Width = 0;
            //getallcomponettext(this);
            //tbFilterNL.Text = temp;
        }
        void getallcomponettext(Control par)
        {
            foreach (Control c in par.Controls)
            {
                temp += "," + c.Text;
                getallcomponettext(c);
            }
        }


        void setlangue()
        {
            string res_file = "Chuong_Trinh_Quan_Ly_San_Xuat.lang_vi";
            if (langue_ge == "Japan") res_file = "Chuong_Trinh_Quan_Ly_San_Xuat.lang_ja";
            res_man = new ResourceManager(res_file, Assembly.GetExecutingAssembly());
            setlangforlabel(this);
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
                setlangforheader(dtgbanTP);
                setlangforheader(dtgbaoluu);
                setlangforheader(dtgKKTP);
                setlangforheader(dtgNL);
  
            }
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
        void gettencongdoan()
        {
            DataTable data = Import_Manager.Instance.gettencongdoanbantp(bophan);
            cbtencongdoanbantpfil.DisplayMember = "TEN_CONG_DOAN";
            cbtencongdoanbantpfil.DataSource = data;
        }
        void phanquyennhaplieu()
        {
            if (!phanquyen.Contains("Full") )
            {
                if (bophan == "Sản Xuất")
                    tabControlDanhMuc.TabPages.Remove(tabPSP);
                if (bophan == "Chất Lượng")
                    tabControlDanhMuc.TabPages.Remove(tabPNL);
            }
        }
        void getthanhpham()
        {
            DataTable data = Import_Manager.Instance.getkiemkhotp("THANH PHAM", tbMSQLTPFilter.Text, dtpNgayKiemFilter.Value, dtpngaykiemtpfilto.Value, tbmasptpfil.Text);
            dtgKKTP.DataSource = data;
            //setlangforheader(dtgKKTP);
        }
        string bophankiemke(string username)
        {
            DataTable data = Import_Manager.Instance.getuserinfor(username);
            if (data.Rows.Count > 0)
                return data.Rows[0][5].ToString();
            else
                return "";
        }
        void getbanthanhpham()
        {
            DataTable data = Import_Manager.Instance.getkiemkhotp(cbtencongdoanbantpfil.Text, tbmsqlbantpfil.Text, dtpngaykiembantpfil.Value, dtpngaykiembtpfilto.Value, tbmaspbtpfil.Text);
            dtgbanTP.DataSource = data;
            
            //if (bophan == "Sản Xuất")
            //{
            //    congdoan = "BAN CONG DOAN";
            //    DataTable data = Import_Manager.Instance.getkiemkhotp(congdoan, tbmsqlbantpfil.Text, dtpngaykiembantpfil.Value,dtpngaykiembtpfilto.Value);
            //    dtgbanTP.DataSource = data;
            //}

            //else if(bophan == "Chất Lượng")
            //{
            //    congdoan = "TRUOC KIEM";
            //    DataTable data = Import_Manager.Instance.getkiemkhotp("TRUOC KIEM", tbmsqlbantpfil.Text, dtpngaykiembantpfil.Value, dtpngaykiembtpfilto.Value);
            //    dtgbanTP.DataSource = data;
            //}
            //else
            //{
            //    congdoan = "";
            //    DataTable data = Import_Manager.Instance.getkiemkhotp("", tbmsqlbantpfil.Text, dtpngaykiembantpfil.Value, dtpngaykiemtpfilto.Value);
            //    dtgbanTP.DataSource = data;
            //}
        }
       
        void getkiemkhonl()
        {
            DataTable data = Import_Manager.Instance.getkiemkhonl(tbFilterNL.Text, dtpngaykiemNLFilter.Value, dtpngaykiemnlfilto.Value);
            dtgNL.DataSource = data;
            //setlangforheader(dtgNL);
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
        void GetNguyenLieu()
        {
            DataTable data = Import_Manager.Instance.LoadDM_NL(tbFilterNL.Text);
            dtgNL.DataSource = data;
            //setlangforheader(dtgNL);
            cbMaNL.DataSource = data;
            cbMaNL.DisplayMember = "SHORT_NL";
            cbMaNL.ValueMember = "TEN_NL";
        }
        void getmacongdoantheomsql()
        {
            DataTable data = Import_Manager.Instance.Loadcongdoantheomsql(tbMSQLTP.Text,"");
            cbMaTP.DisplayMember = "MA_CONG_DOAN";
            cbMaTP.DataSource = data;

            DataTable bantp = Import_Manager.Instance.Loadcongdoantheomsql(tbmsqlbantp.Text,"");
            cbmaspbantp.DisplayMember = "MA_CONG_DOAN";
            cbmaspbantp.DataSource = bantp;
        }

        void getmacongdoantheomsqlvatencd()
        {
            DataTable data = Import_Manager.Instance.getcongdoantheomsqlvatencd(tbMSQLTP.Text, "THANH PHAM");
            cbMaTP.DisplayMember = "MA_CONG_DOAN";
            cbMaTP.DataSource = data;

            DataTable bantp = Import_Manager.Instance.getcongdoantheomsqlvatencd(tbmsqlbantp.Text, cbtencongdoanbantpfil.Text);
            cbmaspbantp.DisplayMember = "MA_CONG_DOAN";
            cbmaspbantp.DataSource = bantp;
            cbtencdbantp.DisplayMember = "TEN_CONG_DOAN";
            cbtencdbantp.DataSource = bantp;
        }
        //getcongdoantheomsqlvatencd
        void getsanphamtheomsql()
        {
            DataTable data = Import_Manager.Instance.getmasptheomsql(tbMSQLTP.Text);
            cbMaTP.DisplayMember = "MA_SP";
            cbMaTP.DataSource = data;


            DataTable bantp = Import_Manager.Instance.getmasptheomsql(tbmsqlbantp.Text);
            cbmaspbantp.DisplayMember = "MA_SP";
            cbmaspbantp.DataSource = bantp;
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
        void enablecontrol(int action, Panel pan, Panel panentry)
        {
            if (action == 0)
            {
                foreach (Control c in pan.Controls)
                {
                    if (c.Text == "New") c.Enabled = true;
                    if (c.Text == "Edit") c.Enabled = true;
                    if (c.Text == "Delete") c.Enabled = true;
                    if (c.Text == "Save") c.Enabled = false;
                    if (c.Text == "Cancel") c.Enabled = false;
                }
                panentry.Visible = false;
            }
            else
            {
                foreach (Control c in pan.Controls)
                {
                    if (c.Text == "New") c.Enabled = false;
                    if (c.Text == "Edit") c.Enabled = false;
                    if (c.Text == "Delete") c.Enabled = false;
                    if (c.Text == "Save") c.Enabled = true;
                    if (c.Text == "Cancel") c.Enabled = true;
                }
                panentry.Visible = true;
            }
        }
        void newentry(Panel pan)
        {
            foreach(Control c in pan.Controls)
            {
                if (c.GetType().Name == "TextBox" && c.Tag == null) c.Text = "";
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
        private void btnEditTP_Click(object sender, EventArgs e)
        {
            actionKKTP = 2;
            if (dtgKKTP.CurrentRow != null)
            {
                tbMSQLTP.Text = dtgKKTP.CurrentRow.Cells[0].Value.ToString();
                cbMaTP.Text = dtgKKTP.CurrentRow.Cells[2].Value.ToString();
                tbsolotTP.Text = dtgKKTP.CurrentRow.Cells[4].Value.ToString();
                tbsothungTP.Text = dtgKKTP.CurrentRow.Cells[5].Value.ToString();
                dtpGiacongTP.Value = DateTime.Parse(dtgKKTP.CurrentRow.Cells[6].Value.ToString());
                numTonTP.Text = dtgKKTP.CurrentRow.Cells[7].Value.ToString();
                dtpKiemTP.Value = DateTime.Parse(dtgKKTP.CurrentRow.Cells[8].Value.ToString());
                cbnguoikiemtp.Text = dtgKKTP.CurrentRow.Cells[9].Value.ToString();
                tbghichuTP.Text = dtgKKTP.CurrentRow.Cells[10].Value.ToString();

            }
            enablecontrol(actionKKTP, panTP, panelTP);
        }

        private void btnNewSP_Click(object sender, EventArgs e)
        {
            actionKKTP = 1;
            newentry(panelTP);
            enablecontrol(actionKKTP, panTP, panelTP);
        }

        private void btnCancelSP_Click(object sender, EventArgs e)
        {
            actionKKTP = 0;
            enablecontrol(actionKKTP, panTP, panelTP);
        }

        private void btnSaveSP_Click(object sender, EventArgs e)
        {
            if (dtpGiacongTP.Value > dtpKiemTP.Value)
            {
                MessageBox.Show("Vui lòng kiểm tra ngày gia công và ngày kiểm!");
                return;
            }
            int currow = current_row(actionKKTP, dtgKKTP);
            int id = 0;
            if (actionKKTP != 1) id = (int)dtgKKTP.CurrentRow.Cells[11].Value;
            try
            {               
                int results = Import_Manager.Instance.UpdateKiemKhoTP(actionKKTP, id, tbMSQLTP.Text, tbsolotTP.Text, tbsothungTP.Text, dtpGiacongTP.Value, float.Parse(numTonTP.Value.ToString()), dtpKiemTP.Value, cbnguoikiemtp.Text, tbghichuTP.Text, cbMaTP.Text);
                getthanhpham();
                dtgKKTP.CurrentCell = dtgKKTP.Rows[currow].Cells[0];
                actionKKTP = 0;
                enablecontrol(actionKKTP, panTP, panelTP);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteSP_Click(object sender, EventArgs e)
        {
            actionKKTP = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateKiemKhoTP(actionKKTP, (int)dtgKKTP.CurrentRow.Cells[11].Value, tbMSQLTP.Text, tbsolotTP.Text, tbsothungTP.Text, dtpGiacongTP.Value, 0, dtpKiemTP.Value, "", tbghichuTP.Text,"");
                actionKKTP = 0;
                enablecontrol(actionKKTP, panTP, panelTP);
                getthanhpham();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbMSQLTPFilter_TextChanged(object sender, EventArgs e)
        {
            getthanhpham();
        }

        private void dtpNgayKiemFilter_ValueChanged(object sender, EventArgs e)
        {
            getthanhpham();
        }

        private void tbFilterNL_TextChanged(object sender, EventArgs e)
        {
            getkiemkhonl();
        }

        private void dtpngaykiemNLFilter_ValueChanged(object sender, EventArgs e)
        {
            getkiemkhonl();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            actionKKNL = 1;
            newentry(panelNL);
            enablecontrol(actionKKNL, panNL, panelNL);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            actionKKNL = 0;
            enablecontrol(actionKKNL, panNL, panelNL);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            actionKKNL = 2;
            if(dtgNL.CurrentRow != null)
            {
                cbMaNL.Text = dtgNL.CurrentRow.Cells[10].Value.ToString();
                tbsolotNL.Text = dtgNL.CurrentRow.Cells[3].Value.ToString();
                tbsocuon.Text = dtgNL.CurrentRow.Cells[4].Value.ToString();
                tbcuonme.Text = dtgNL.CurrentRow.Cells[5].Value.ToString();
                numtonNL.Text = dtgNL.CurrentRow.Cells[6].Value.ToString();
                dtpngaykiemNL.Value = DateTime.Parse(dtgNL.CurrentRow.Cells[7].Value.ToString());
                cbnguoikiemnl.Text = dtgNL.CurrentRow.Cells[8].Value.ToString();
                tbghichuNL.Text = dtgNL.CurrentRow.Cells[9].Value.ToString();
            }
            enablecontrol(actionKKNL, panNL, panelNL);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            int currow = current_row(actionKKNL, dtgNL);
            int id = 0;
            if (actionKKNL != 1) id = (int)dtgNL.CurrentRow.Cells[0].Value;
            try
            {
                int checkmnl = checkmanl(cbMaNL.SelectedValue.ToString());
                if (checkmnl > 0)
                {
                    int results = Import_Manager.Instance.UpdateKiemKhoNL(actionKKNL, id, cbMaNL.SelectedValue.ToString(), tbsolotNL.Text, tbsocuon.Text, tbcuonme.Text, numtonNL.Value, dtpngaykiemNL.Value, cbnguoikiemnl.Text, tbghichuNL.Text);
                    getkiemkhonl();
                    dtgNL.CurrentCell = dtgNL.Rows[currow].Cells[0];
                    actionKKNL = 0;
                    enablecontrol(actionKKNL, panNL, panelNL);
                }
                else
                {
                    MessageBox.Show("Please check Ma NL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            actionKKNL = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateKiemKhoNL(actionKKNL, (int)dtgNL.CurrentRow.Cells[0].Value, cbMaNL.Text, tbsolotNL.Text, tbsocuon.Text, tbcuonme.Text, numtonNL.Value, dtpngaykiemNL.Value, "", tbghichuNL.Text);
                actionKKNL = 0;
                enablecontrol(actionKKNL, panNL, panelNL);
                getkiemkhonl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbMSQLTP_TextChanged(object sender, EventArgs e)
        {
            getmacongdoantheomsqlvatencd();
        }

        private void btnNewDM_Click(object sender, EventArgs e)
        {
            actionKKBanTP = 1;
            enablecontrol(actionKKBanTP, panbanTP, panelBanTP);
            newentry(panelBanTP);
        }

        private void btnEditDM_Click(object sender, EventArgs e)
        {
            actionKKBanTP = 2;
            if (dtgbanTP.CurrentRow != null)
            {
                tbmsqlbantp.Text = dtgbanTP.CurrentRow.Cells[0].Value.ToString();
                cbmaspbantp.Text = dtgbanTP.CurrentRow.Cells[2].Value.ToString();
                tbsolotbantp.Text = dtgbanTP.CurrentRow.Cells[4].Value.ToString();
                tbsothungbantp.Text = dtgbanTP.CurrentRow.Cells[5].Value.ToString();
                dtpngaygiacongbantp.Value = DateTime.Parse(dtgbanTP.CurrentRow.Cells[6].Value.ToString());
                numtonbantp.Text = dtgbanTP.CurrentRow.Cells[7].Value.ToString();
                dtpngaykiembantp.Value = DateTime.Parse(dtgbanTP.CurrentRow.Cells[8].Value.ToString());
                cbnguoikiembantp.Text = dtgbanTP.CurrentRow.Cells[9].Value.ToString();
                tbghichubantp.Text = dtgbanTP.CurrentRow.Cells[10].Value.ToString();
            }
            enablecontrol(actionKKBanTP, panbanTP, panelBanTP);
        }

        private void btnDeleteDM_Click(object sender, EventArgs e)
        {
            actionKKBanTP = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateKiemKhoTP(actionKKBanTP, (int)dtgbanTP.CurrentRow.Cells[11].Value, "", "", "", dtpngaygiacongbantp.Value, 0, dtpngaykiembantp.Value, "", "","");
                actionKKBanTP = 0;
                enablecontrol(actionKKBanTP, panbanTP, panelBanTP);
                getbanthanhpham();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void loadnhanvien()
        {
            DataTable data = Import_Manager.Instance.LoadNhanVien();
            cbnguoikiembantp.DisplayMember = "NV";
            //cbGiaCong.ValueMember = "ID";
            cbnguoikiembantp.DataSource = data;

            cbnguoikiemtp.DisplayMember = "NV";
            cbnguoikiemtp.DataSource = data;

            cbnguoikiemnl.DisplayMember = "NV";
            cbnguoikiemnl.DataSource = data;
        }

        private void btnSaveDM_Click(object sender, EventArgs e)
        {
            if (dtpngaygiacongbantp.Value > dtpngaykiembantp.Value)
            {
                MessageBox.Show("Vui lòng kiểm tra ngày gia công và ngày kiểm!");
                return;
            }
            int currow = current_row(actionKKBanTP, dtgbanTP);
            int id = 0;
            if (actionKKBanTP != 1) id = (int)dtgbanTP.CurrentRow.Cells[11].Value;          
            try
            {
                if (cbmaspbantp.Text != "")
                {
                    int results = Import_Manager.Instance.UpdateKiemKhoTP(actionKKBanTP, id, tbmsqlbantp.Text, tbsolotbantp.Text, tbsothungbantp.Text, dtpngaygiacongbantp.Value, float.Parse(numtonbantp.Value.ToString()), dtpngaykiembantp.Value, cbnguoikiembantp.Text, tbghichubantp.Text, cbmaspbantp.Text);
                    getbanthanhpham();
                    dtgbanTP.CurrentCell = dtgbanTP.Rows[currow].Cells[0];
                    actionKKBanTP = 0;
                    enablecontrol(actionKKBanTP, panbanTP, panelBanTP);
                }
                else
                {
                    MessageBox.Show("Mã Công Đoạn trống!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbmsqlbantpfil_TextChanged(object sender, EventArgs e)
        {
            getbanthanhpham();
        }

        private void dtpngaykiembantpfil_ValueChanged(object sender, EventArgs e)
        {
            getbanthanhpham();
        }

        private void btnCancelDM_Click(object sender, EventArgs e)
        {
            actionKKBanTP = 0;
            enablecontrol(actionKKBanTP, panbanTP, panelBanTP);
        }

        private void tbmsqlbantp_TextChanged(object sender, EventArgs e)
        {
            getmacongdoantheomsqlvatencd();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            xuatexceldtg(dtgNL);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            xuatexceldtg(dtgKKTP);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            xuatexceldtg(dtgbanTP);
        }

        private void cbtencongdoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            getbanthanhpham();
        }

        private void tbmsqlbaoluufil_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbmaspbtpfil_TextChanged(object sender, EventArgs e)
        {
            getbanthanhpham(); 
        }

        private void tbmasptpfil_TextChanged(object sender, EventArgs e)
        {
            getthanhpham();
        }
    }
}
