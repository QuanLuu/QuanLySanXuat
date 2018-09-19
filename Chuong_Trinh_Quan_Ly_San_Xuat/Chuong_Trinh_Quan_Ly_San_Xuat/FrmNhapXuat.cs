using Chuong_Trinh_Quan_Ly_San_Xuat.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Chuong_Trinh_Quan_Ly_San_Xuat
{
    public partial class FrmNhapXuat : Form
    {
        int action = 0;
        bool refreshflag = false;
        public FrmNhapXuat()
        {
            InitializeComponent();
            dtgNhapNVL.Dock = DockStyle.Fill;
            dtgXuatNL.Dock = DockStyle.Fill;
            dtgXuatSP.Dock = DockStyle.Fill;
            dtgXuatgiacong.Dock = DockStyle.Fill;
            dtgNhapgiacong.Dock = DockStyle.Fill;
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgNhapNVL, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgXuatNL, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgNhapgiacong, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgXuatgiacong, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgXuatSP, new object[] { true });

            GetNguyenLieu();
            GetKhachHang();
            //getnhatkynhapNL();
            //getnhatkyxuatNL();
            //getnhatkyxuatSP();
            getxuatgiacong();
            getnhapgiacong();
            dtpNgayNhap.Value = DateTime.Now;
            dtpNgayxuat.Value = DateTime.Now;
            dtpXuatSP.Value = DateTime.Now;
            dtpNgayCO.Value = DateTime.Now;
            dtpNgayInvoice.Value = DateTime.Now;
            dtpXuatgiacong.Value = DateTime.Now;

            dtpnhapgc.Value = DateTime.Now;
            dtpXuatSPto.Value = DateTime.Now;
            dtpNhapNLto.Value = DateTime.Now;
            dtpXuatNLto.Value = DateTime.Now;
            dtpXuatGiacongto.Value = DateTime.Now;
            dtpnhapgcto.Value = DateTime.Now;

            refreshflag = true;
            dtpNhapNLfrom.Value = DateTime.Now.AddDays(-7);
            dtpXuatNLfrom.Value = DateTime.Now.AddDays(-7);
            dtpXuatSPfrom.Value = DateTime.Now.AddDays(-7);
            dtpXuatGiacongfrom.Value = DateTime.Now.AddDays(-7);
            dtpnhapgcfrom.Value = DateTime.Now.AddDays(-7);


        }
        void GetNguyenLieu()
        {
            DataTable data = Import_Manager.Instance.LoadDM_NL(tbMaNLFilter.Text);
            cbMaNL.DisplayMember = "SHORT_NL";
            cbMaNL.ValueMember = "TEN_NL";
            cbMaNL.DataSource = data;
            cbNLXuat.DisplayMember = "SHORT_NL";
            cbNLXuat.ValueMember = "TEN_NL";
            cbNLXuat.DataSource = data;
        }
        void GetKhachHang()
        {
            DataTable data = Import_Manager.Instance.LoadKH("");
            cbNCC.DisplayMember = "MA_KH";
            cbNCC.DataSource = data;
            cbctyxuatgiacong.DisplayMember = "MA_KH";
            cbctyxuatgiacong.DataSource = data;

            cbctynhapgc.DisplayMember = "MA_KH";
            cbctynhapgc.DataSource = data;
            //cbMaSPDM.DataSource = data;
            //cbMaSPDM.DisplayMember = "MA_KH";
        }
        void getnhatkynhapNL()
        {
            DataTable data = Import_Manager.Instance.getNhatKyNhapNL(tbMaNLFilter.Text, dtpNhapNLfrom.Value, dtpNhapNLto.Value, tbNhapNlinvoicefil.Text );
            dtgNhapNVL.DataSource = data;
        }

        void loadmasptheomsql(string msql)
        {
            DataTable data = Import_Manager.Instance.getmasptheomsql(msql);
            cbMaSP.DisplayMember = "MA_SP";
            cbMaSP.DataSource = data;
            cbmaspxuatgiacong.DisplayMember = "MA_SP";
            cbmaspxuatgiacong.DataSource = data;

            cbmaspnhapgc.DisplayMember = "MA_SP";
            cbmaspnhapgc.DataSource = data;
        }
        void getmasptheonl()
        {
            DataTable data = Import_Manager.Instance.getmasptheoNL(cbNLXuat.SelectedValue.ToString());
            cbMaspNLxuat.DisplayMember = "MA_SP";
            cbMaspNLxuat.DataSource = data;
        }
        void getnhatkyxuatNL()
        {
            DataTable data = Import_Manager.Instance.getnhatkyxuatNL(tbNLXuatFilter.Text, dtpXuatNLfrom.Value, dtpXuatNLto.Value);
            dtgXuatNL.DataSource = data;
        }
        void getnhatkyxuatSP()
        {
            DataTable data = Import_Manager.Instance.getnhatkyxuatSP(tbMaSPFilter.Text, dtpXuatSPfrom.Value, dtpXuatSPto.Value, tbXuatSPInvfil.Text);
            dtgXuatSP.DataSource = data;
        }
        void getxuatgiacong()
        {
            DataTable data = Import_Manager.Instance.getxuatgiacong(tbmaspxuatgiacongfilter.Text, dtpXuatGiacongfrom.Value, dtpXuatGiacongto.Value, tbxuatgiacongctyfil.Text);
            dtgXuatgiacong.DataSource = data;
        }
        void getnhapgiacong()
        {
            DataTable data = Import_Manager.Instance.getnhapgiacong(tbmaspnhapgcfilter.Text, dtpnhapgcfrom.Value, dtpnhapgcto.Value, tbnhapgcctyfil.Text);
            dtgNhapgiacong.DataSource = data;
        }

        void enablecontrol()
        {
            if (action == 0)
            {
                btnNew.Enabled = true;
                BtnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                if (tabNhapXuat.SelectedIndex == 0) panelNhapNL.Visible = false;
                if (tabNhapXuat.SelectedIndex == 2) panelXuatSP.Visible = false;
                if (tabNhapXuat.SelectedIndex == 1) panelXuatNL.Visible = false;
                if (tabNhapXuat.SelectedIndex == 3) panelXuatGiaCong.Visible = false;
                if (tabNhapXuat.SelectedIndex == 4) panelNhapGC.Visible = false;

            }
            else
            {
                btnNew.Enabled = false;
                BtnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                if (tabNhapXuat.SelectedIndex == 0) panelNhapNL.Visible = true;
                if (tabNhapXuat.SelectedIndex == 2) panelXuatSP.Visible = true;
                if (tabNhapXuat.SelectedIndex == 1) panelXuatNL.Visible = true;
                if (tabNhapXuat.SelectedIndex == 3) panelXuatGiaCong.Visible = true;
                if (tabNhapXuat.SelectedIndex == 4) panelNhapGC.Visible = true;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            action = 1;
            if (tabNhapXuat.SelectedIndex == 0)
            {
                nhapmoi(this.panelNhapNL);
                //dtpNgayCO.Value = DateTime.Now;
                //dtpNgayInvoice.Value = DateTime.Now;
            }
            if (tabNhapXuat.SelectedIndex == 1) nhapmoi(this.panelXuatNL);
            if (tabNhapXuat.SelectedIndex == 2) nhapmoi(this.panelXuatSP);
            if (tabNhapXuat.SelectedIndex == 3)
            {
                nhapmoi(this.panelXuatGiaCong);
                //dtpXuatgiacong.Value = DateTime.Now;

            }
            if (tabNhapXuat.SelectedIndex == 4)
            {
                nhapmoi(this.panelNhapGC);
                //dtpnhapgc.Value = DateTime.Now;

            }
            //dtpNgayNhap.Value = DateTime.Now;
            //dtpNgayxuat.Value = DateTime.Now;
            //dtpXuatSP.Value = DateTime.Now;
            enablecontrol();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            action = 2;
            enablecontrol();
            if (tabNhapXuat.SelectedIndex == 3)
            {
                if (dtgXuatgiacong.CurrentRow != null)
                {
                    tbmsqlxuatgiacong.Text = dtgXuatgiacong.CurrentRow.Cells[1].Value.ToString();
                    dtpXuatgiacong.Value = DateTime.Parse(dtgXuatgiacong.CurrentRow.Cells[4].Value.ToString());
                    numslxuatgiacong.Text = dtgXuatgiacong.CurrentRow.Cells[5].Value.ToString();
                    tbpalletxuatgiacong.Text = dtgXuatgiacong.CurrentRow.Cells[6].Value.ToString();
                    tbsothungxuatgiacong.Text = dtgXuatgiacong.CurrentRow.Cells[7].Value.ToString();
                    tbtokhiaxuatgiacong.Text = dtgXuatgiacong.CurrentRow.Cells[8].Value.ToString();
                    tbhopdongxuatgiacong.Text = dtgXuatgiacong.CurrentRow.Cells[9].Value.ToString();
                    cbctyxuatgiacong.Text = dtgXuatgiacong.CurrentRow.Cells[10].Value.ToString();
                    tbghichuxuatgiacong.Text = dtgXuatgiacong.CurrentRow.Cells[11].Value.ToString(); ;
                }
            }

            if (tabNhapXuat.SelectedIndex == 4)
            {
                if (dtgNhapgiacong.CurrentRow != null)
                {
                    tbmsqlnhapgc.Text = dtgNhapgiacong.CurrentRow.Cells[1].Value.ToString();
                    dtpnhapgc.Value = DateTime.Parse(dtgNhapgiacong.CurrentRow.Cells[4].Value.ToString());
                    numslnhapgc.Text = dtgNhapgiacong.CurrentRow.Cells[5].Value.ToString();
                    numslNGnhapgc.Text = dtgNhapgiacong.CurrentRow.Cells[6].Value.ToString();
                    numslNGkiemtranhapgc.Text = dtgNhapgiacong.CurrentRow.Cells[7].Value.ToString();
                    tbsotokhainhapgc.Text = dtgNhapgiacong.CurrentRow.Cells[8].Value.ToString();
                    tbsohopdongnhapgc.Text = dtgNhapgiacong.CurrentRow.Cells[9].Value.ToString();
                    cbctynhapgc.Text = dtgNhapgiacong.CurrentRow.Cells[10].Value.ToString();
                    tbghichunhapgc.Text = dtgNhapgiacong.CurrentRow.Cells[11].Value.ToString(); ;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            action = 0;
            enablecontrol();
        }

        void nhapmoi(Control col)
        {
            foreach(Control c in col.Controls)
            {
                if (c.GetType().Name == "NumericUpDown") c.Text = "";
                //if (c.GetType().Name == "TextBox") c.Text = "";
                //if (c.GetType().Name == "ComboBox") c.Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int currow = 0;
            int id = 0;
            int actioncur = action;
            try
            {
                if (tabNhapXuat.SelectedIndex == 0)
                {
                    id = 0;
                    if (dtgNhapNVL.Rows.Count > 1 && dtgNhapNVL.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgNhapNVL.CurrentRow.Cells[0].Value;
                    if (action == 2)
                    { currow = dtgNhapNVL.CurrentRow.Index; }
                    else if (action == 1)
                    { currow = dtgNhapNVL.Rows.Count - 1; }
                    else
                    { currow = 0; }
                    int results = Import_Manager.Instance.UpdatenhatkynhapNL(action, id, cbMaNL.SelectedValue.ToString(), dtpNgayNhap.Value, cbNCC.Text, tbSoLot.Text, tbSoPO.Text, tbSoInvoice.Text, dtpNgayInvoice.Value, tbSoCO.Text, dtpNgayCO.Value, (int)numsocuonnhap.Value, numKLNhap.Value, tbGhiChuNLNhap.Text);
                    getnhatkynhapNL();
                    dtgNhapNVL.CurrentCell = dtgNhapNVL.Rows[currow].Cells[0];
                   
                }
                if (tabNhapXuat.SelectedIndex == 1)
                {
                    id = 0;
                    if (dtgXuatNL.Rows.Count > 1 && dtgXuatNL.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgXuatNL.CurrentRow.Cells[0].Value;
                    if (action == 2)
                    { currow = dtgXuatNL.CurrentRow.Index; }
                    else if (action == 1)
                    { currow = dtgXuatNL.Rows.Count - 1; }
                    else
                    { currow = 0; }
                    int results = Import_Manager.Instance.UpdatenhatkyxuatNL(action, id, cbNLXuat.SelectedValue.ToString(), cbMaspNLxuat.Text, dtpNgayxuat.Value, tbsolotxuat.Text, (int)numsocuonxuat.Value, numkhoiluongxuat.Value, tbghichuNlxuat.Text);
                    getnhatkyxuatNL();
                    dtgXuatNL.CurrentCell = dtgXuatNL.Rows[currow].Cells[0];
                }

                if (tabNhapXuat.SelectedIndex == 2)
                {
                    id = 0;
                    if (dtgXuatSP.Rows.Count > 1 && dtgXuatSP.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgXuatSP.CurrentRow.Cells[0].Value;
                    if (action == 2)
                    { currow = dtgXuatSP.CurrentRow.Index; }
                    else if (action == 1)
                    { currow = dtgXuatSP.Rows.Count - 1; }
                    else
                    { currow = 0; }
                    int results = Import_Manager.Instance.updatenhatkyxuatSP(action, id, cbMaSP.Text, dtpXuatSP.Value, tbsolotxuatsp.Text, tbSoPOSP.Text, tbSoInvoiceSP.Text, tbsotokhai.Text, dtpngaytokhai.Value, (int)numsothung.Value, (int)numsoluong.Value, tbGhiChuxuatSP.Text);
                    getnhatkyxuatSP();
                    dtgXuatSP.CurrentCell = dtgXuatSP.Rows[currow].Cells[0];
                }
                if (tabNhapXuat.SelectedIndex == 3)
                {

                    id = 0;
                    if (dtgXuatgiacong.Rows.Count > 1 && dtgXuatgiacong.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgXuatgiacong.CurrentRow.Cells[0].Value;
                    if (action == 2)
                        { currow = dtgXuatgiacong.CurrentRow.Index; }
                    else if (action == 1)
                        { currow = dtgXuatgiacong.Rows.Count - 1; }
                    else
                    { currow = 0; }
                    int results = Import_Manager.Instance.UpdateXUATGIACONG(action, id, cbmaspxuatgiacong.Text, dtpXuatgiacong.Value, Int32.Parse(numslxuatgiacong.Value.ToString()), tbpalletxuatgiacong.Text, tbsothungxuatgiacong.Text, tbsothungxuatgiacong.Text, tbhopdongxuatgiacong.Text, cbctyxuatgiacong.Text, tbghichuxuatgiacong.Text);
                    getxuatgiacong();
                    dtgXuatgiacong.CurrentCell = dtgXuatgiacong.Rows[currow].Cells[0];
                }

                if (tabNhapXuat.SelectedIndex == 4)
                {
                    
                    id = 0;
                    if (dtgNhapgiacong.Rows.Count > 1 && dtgNhapgiacong.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgNhapgiacong.CurrentRow.Cells[0].Value;
                    if (action == 2)
                    { currow = dtgNhapgiacong.CurrentRow.Index; }
                    else if (action == 1)
                    { currow = dtgNhapgiacong.Rows.Count - 1; }
                    else
                    { currow = 0; }
                    int results = Import_Manager.Instance.UpdateNHAPGIACONG(action, id, cbmaspnhapgc.Text, dtpnhapgc.Value, Int32.Parse(numslnhapgc.Value.ToString()), Int32.Parse(numslNGnhapgc.Value.ToString()), Int32.Parse(numslNGkiemtranhapgc.Value.ToString()), tbsotokhainhapgc.Text, tbsohopdongnhapgc.Text, cbctynhapgc.Text, tbghichunhapgc.Text);
                    getnhapgiacong();
                    dtgNhapgiacong.CurrentCell = dtgNhapgiacong.Rows[currow].Cells[0];
                }
                action = 0;
                enablecontrol();
                if (actioncur == 1) btnNew_Click(btnNew, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            action = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {

                if (tabNhapXuat.SelectedIndex == 0)
                {         
                    int results = Import_Manager.Instance.UpdatenhatkynhapNL(action, (int)dtgNhapNVL.CurrentRow.Cells[0].Value, cbMaNL.SelectedValue.ToString(), dtpNgayNhap.Value, cbNCC.Text, tbSoLot.Text, tbSoPO.Text, tbSoInvoice.Text, dtpNgayInvoice.Value, tbSoCO.Text, dtpNgayCO.Value, (int)numsocuonnhap.Value, numKLNhap.Value, tbGhiChuNLNhap.Text);
                    getnhatkynhapNL();  
                }
                if (tabNhapXuat.SelectedIndex == 1)
                {
                    int results = Import_Manager.Instance.UpdatenhatkyxuatNL(action, (int)dtgXuatNL.CurrentRow.Cells[0].Value, cbNLXuat.SelectedValue.ToString(), cbMaspNLxuat.Text, dtpNgayxuat.Value, tbsolotxuat.Text, (int)numsocuonxuat.Value, numkhoiluongxuat.Value, tbghichuNlxuat.Text);
                    getnhatkyxuatNL();
                }
                if (tabNhapXuat.SelectedIndex == 2)
                {

                    int results = Import_Manager.Instance.updatenhatkyxuatSP(action, (int)dtgXuatSP.CurrentRow.Cells[0].Value, cbMaSP.Text, dtpXuatSP.Value, tbsolotxuatsp.Text, tbSoPOSP.Text, tbSoInvoiceSP.Text, tbsotokhai.Text, dtpngaytokhai.Value, (int)numsothung.Value, (int)numsoluong.Value, tbGhiChuxuatSP.Text);
                    getnhatkyxuatSP();
                }
                if (tabNhapXuat.SelectedIndex == 3)
                {

                    int results = Import_Manager.Instance.UpdateXUATGIACONG(action, (int)dtgXuatgiacong.CurrentRow.Cells[0].Value, cbmaspxuatgiacong.Text, dtpXuatgiacong.Value, Int32.Parse(numslxuatgiacong.Value.ToString()), tbpalletxuatgiacong.Text, tbsothungxuatgiacong.Text, tbsothungxuatgiacong.Text, tbhopdongxuatgiacong.Text, cbctyxuatgiacong.Text, tbghichuxuatgiacong.Text);
                    getxuatgiacong();
                }
                if (tabNhapXuat.SelectedIndex == 4)
                {
                    int results = Import_Manager.Instance.UpdateNHAPGIACONG(action, (int)dtgNhapgiacong.CurrentRow.Cells[0].Value, cbmaspnhapgc.Text, dtpnhapgc.Value, Int32.Parse(numslnhapgc.Value.ToString()), Int32.Parse(numslNGnhapgc.Value.ToString()), Int32.Parse(numslNGkiemtranhapgc.Value.ToString()), tbsotokhainhapgc.Text, tbsohopdongnhapgc.Text, cbctynhapgc.Text, tbghichunhapgc.Text);
                    getnhapgiacong();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            action = 0;
            enablecontrol();
        }

        private void tabNhapXuat_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (action != 0)
            {
                MessageBox.Show("Bạn chưa lưu dữ liệu, vui lòng chọn Save hoặc Cancel");
                e.Cancel = true;
            }
        }

        private void dtgNhapNVL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgNhapNVL.CurrentRow.Cells[0].Value.ToString() != "" && action != 1)
            {
   
                cbMaNL.Text = dtgNhapNVL.CurrentRow.Cells[14].Value.ToString();
                dtpNgayNhap.Value = DateTime.Parse(dtgNhapNVL.CurrentRow.Cells[2].Value.ToString());
                cbNCC.Text = dtgNhapNVL.CurrentRow.Cells[3].Value.ToString();
                tbSoPO.Text = dtgNhapNVL.CurrentRow.Cells[4].Value.ToString();
                tbSoInvoice.Text = dtgNhapNVL.CurrentRow.Cells[5].Value.ToString();
                dtpNgayInvoice.Value = DateTime.Parse(dtgNhapNVL.CurrentRow.Cells[6].Value.ToString());
                tbSoCO.Text = dtgNhapNVL.CurrentRow.Cells[7].Value.ToString();
                dtpNgayCO.Value = DateTime.Parse(dtgNhapNVL.CurrentRow.Cells[8].Value.ToString());
                tbSoLot.Text = dtgNhapNVL.CurrentRow.Cells[9].Value.ToString();
                numsocuonnhap.Value = (int)dtgNhapNVL.CurrentRow.Cells[10].Value;
                numKLNhap.Value = decimal.Parse(dtgNhapNVL.CurrentRow.Cells[11].Value.ToString());
                tbGhiChuNLNhap.Text = dtgNhapNVL.CurrentRow.Cells[12].Value.ToString();
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            getnhatkyxuatSP();
        }

        private void tbNLXuatFilter_TextChanged(object sender, EventArgs e)
        {
            getnhatkyxuatNL();
        }

        private void tbMaNLFilter_TextChanged(object sender, EventArgs e)
        {
            getnhatkynhapNL();
        }

        private void dtgXuatNL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgXuatNL.CurrentRow.Cells[1].Value.ToString() != "" && action != 1)
            {
                cbNLXuat.Text = dtgXuatNL.CurrentRow.Cells[9].Value.ToString();
                //cbMaspNLxuat.Text = dtgXuatNL.CurrentRow.Cells[2].Value.ToString();
                dtpNgayxuat.Value = DateTime.Parse(dtgXuatNL.CurrentRow.Cells[3].Value.ToString());
                tbsolotxuat.Text = dtgXuatNL.CurrentRow.Cells[4].Value.ToString();
                numsocuonxuat.Value = (int)dtgXuatNL.CurrentRow.Cells[5].Value;
                numkhoiluongxuat.Value = decimal.Parse(dtgXuatNL.CurrentRow.Cells[6].Value.ToString());
                tbghichuNlxuat.Text = dtgXuatNL.CurrentRow.Cells[7].Value.ToString();
            }
        }

        private void dtgXuatSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgXuatSP.CurrentRow.Cells[1].Value.ToString() != "" && action != 1)
            {
                tbmsql.Text = dtgXuatSP.CurrentRow.Cells[1].Value.ToString();
                //cbMaSP.Text = dtgXuatSP.CurrentRow.Cells[2].Value.ToString();
                dtpXuatSP.Value = DateTime.Parse(dtgXuatSP.CurrentRow.Cells[3].Value.ToString());
                tbsolotxuatsp.Text = dtgXuatSP.CurrentRow.Cells[4].Value.ToString();
                tbSoPOSP.Text  = dtgXuatSP.CurrentRow.Cells[5].Value.ToString();
                tbSoInvoiceSP.Text = dtgXuatSP.CurrentRow.Cells[6].Value.ToString();
                tbsotokhai.Text = dtgXuatSP.CurrentRow.Cells[7].Value.ToString();
                dtpngaytokhai.Value = DateTime.Parse(dtgXuatSP.CurrentRow.Cells[8].Value.ToString());
                numsothung.Value = (int)dtgXuatSP.CurrentRow.Cells[9].Value;
                numsoluong.Value = (int)dtgXuatSP.CurrentRow.Cells[10].Value;
                tbGhiChuxuatSP.Text = dtgXuatSP.CurrentRow.Cells[11].Value.ToString();
            }
        }

        private void cbNLXuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            getmasptheonl();
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void cbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbmsql_TextChanged(object sender, EventArgs e)
        {
            loadmasptheomsql(tbmsql.Text);
        }

        private void tbmsqlxuatgiacong_TextChanged(object sender, EventArgs e)
        {
            loadmasptheomsql(tbmsqlxuatgiacong.Text);
        }

        private void tbmaspxuatgiacongfilter_TextChanged(object sender, EventArgs e)
        {
            if (refreshflag) getxuatgiacong();
        }

        private void tbmaspnhapgcfilter_TextChanged(object sender, EventArgs e)
        {
            if (refreshflag) getnhapgiacong();
        }

        private void tbmsqlnhapgc_TextChanged(object sender, EventArgs e)
        {
            loadmasptheomsql(tbmsqlnhapgc.Text);
        }

        private void dtpNhapNLfrom_ValueChanged(object sender, EventArgs e)
        {
            if(refreshflag) getnhatkynhapNL();
        }

        private void dtpNhapNLto_ValueChanged(object sender, EventArgs e)
        {
            if (refreshflag) getnhatkynhapNL();
        }

        private void dtpXuatNLfrom_ValueChanged(object sender, EventArgs e)
        {
            if (refreshflag) getnhatkyxuatNL();
        }

        private void dtpXuatNLto_ValueChanged(object sender, EventArgs e)
        {
            if (refreshflag) getnhatkyxuatNL();
        }

        private void dtpXuatSPfrom_ValueChanged(object sender, EventArgs e)
        {
            if (refreshflag) getnhatkyxuatSP();
        }

        private void dtpXuatSPto_ValueChanged(object sender, EventArgs e)
        {
            if (refreshflag) getnhatkyxuatSP();
        }

        private void dtpXuatGiacongfrom_ValueChanged(object sender, EventArgs e)
        {
            if (refreshflag) getxuatgiacong();
        }

        private void dtpXuatGiacongto_ValueChanged(object sender, EventArgs e)
        {
            if (refreshflag) getxuatgiacong();
        }

        private void tbxuatgiacongctyfil_TextChanged(object sender, EventArgs e)
        {
            if (refreshflag) getxuatgiacong();
        }

        private void dtpnhapgcfrom_ValueChanged(object sender, EventArgs e)
        {
            if (refreshflag) getnhapgiacong();
        }

        private void dtpnhapgcto_ValueChanged(object sender, EventArgs e)
        {
            if (refreshflag) getnhapgiacong();
        }

        private void tbnhapgcctyfil_TextChanged(object sender, EventArgs e)
        {
            if (refreshflag) getnhapgiacong();
        }
    }
}
