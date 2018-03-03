using Chuong_Trinh_Quan_Ly_San_Xuat.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chuong_Trinh_Quan_Ly_San_Xuat
{
    public partial class FrmChiThiSX : Form
    {
        int actionSX =0;
        string phanquyen;
        public FrmChiThiSX()
        {
            InitializeComponent();
            dtgChiThiSX.Dock = DockStyle.Fill;
            dtpTuNgay.CustomFormat = "yyyy-MM-dd";
            dtpDenNgay.CustomFormat = "yyyy-MM-dd";
            dtpNgaySX.CustomFormat = "yyyy-MM-dd";
            DateTime now = DateTime.Now;
            dtpDenNgay.Value = new DateTime(now.Year, now.Month, 1).AddMonths(1).AddDays(-1);
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["FrmMain"];
            phanquyen = ((FrmMain)f).quyensudung;
            enablecontrolCTSX();
            LoadDSNhanVien();
            GetCongDoanSX();
            GetTenMay();
            GetChiThiSX();
            GetMaSanPham();
            cbMaSPFilter.SelectedIndex = -1;
            //NewChiThiSX(this.panelFilterCTSX);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            actionSX = 1;
            enablecontrolCTSX();
            NewChiThiSX(this.panelQLSX);
            dtpNgaySX.Value = DateTime.Now;
        }

        void NewChiThiSX(Control col)
        {
            foreach (Control c in col.Controls)
            {
                if (c.GetType().Name == "TextBox") c.Text = "";
                if (c.GetType().Name == "ComboBox") c.Text = "";
                if (c.GetType().Name == "NumericUpDown") c.Text = "";
                NewChiThiSX(c);
            }
        }

        void CheckChiThiSX(Control col)
        {
            foreach (Control c in col.Controls)
            {

                if (c.GetType().Name == "ComboBox")
                {
                    if(c.Text == "" && c.Name != "cbTenMay" && c.Name != "CbSomay") MessageBox.Show("Bạn chưa nhâp thông tin cho " + c.Name);
                }
                CheckChiThiSX(c);
            }
        }

        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (phanquyen == "Full")
            {
                FrmDanhMuc f = new FrmDanhMuc();
                this.Hide();
                f.Show();
                f.FormClosing += frm_Closing;
            }
            
        }

        private void frm_Closing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }
        void enablecontrolCTSX()
        {
            if (actionSX == 0)
            {
                btnNew.Enabled = true;
                BtnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                panelQLSX.Visible = false;
                if (phanquyen != "Full")
                {
                    BtnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
            else
            {
                btnNew.Enabled = false;
                BtnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                panelQLSX.Visible = true;
            }

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            actionSX = 2;
            enablecontrolCTSX();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            actionSX = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateChiThiSX(actionSX, (int)dtgChiThiSX.CurrentRow.Cells[26].Value, cbMaSP.Text, cbCongDoan.Text, cbCongDoanSau.Text, cbTenMay.Text, CbSomay.Text.ToString(), dtpNgaySX.Value, (int)numCaSX.Value, (int)numSoLuong.Value, (int)numSoLot.Value, (int)numtgSX.Value, (int)numtgChuanBi.Value
                                                                    , (int)numtgSua.Value, (int)numtgChaoLe.Value, (int)numtgDaoTao.Value, (int)numtgChoKhuon.Value, (int)numSuoc.Value, (int)numMop.Value, (int)numSet.Value, (int)numBienDang.Value, (int)numhongKhac.Value, (int)numBaoLuu.Value, cbNVSX.Text, cbNVKT.Text, cbNVXN.Text, tbGhiChu.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            actionSX = 0;
            enablecontrolCTSX();
            GetChiThiSX(); 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            actionSX = 0;
            enablecontrolCTSX();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CheckChiThiSX(this.panelQLSX);
            int currow = 0;
            int idCTSX = 0;
            if (dtgChiThiSX.Rows.Count > 1 && dtgChiThiSX.CurrentRow.Cells[26].Value.ToString() != "") idCTSX = (int)dtgChiThiSX.CurrentRow.Cells[26].Value;
            try
            {
                if (actionSX == 2)
                { currow = dtgChiThiSX.CurrentRow.Index; }
                else if (actionSX == 1)
                { currow = dtgChiThiSX.Rows.Count - 1; }
                else
                { currow = 0; }
                int results = Import_Manager.Instance.UpdateChiThiSX(actionSX, idCTSX, cbMaSP.Text,cbCongDoan.Text, cbCongDoanSau.Text, cbTenMay.Text, CbSomay.Text.ToString(), dtpNgaySX.Value, (int)numCaSX.Value, (int)numSoLuong.Value, (int)numSoLot.Value, (int)numtgSX.Value, (int)numtgChuanBi.Value
                                                                    , (int)numtgSua.Value, (int)numtgChaoLe.Value, (int)numtgDaoTao.Value, (int)numtgChoKhuon.Value, (int)numSuoc.Value, (int)numMop.Value, (int)numSet.Value, (int)numBienDang.Value, (int)numhongKhac.Value, (int)numBaoLuu.Value, cbNVSX.Text, cbNVKT.Text, cbNVXN.Text, tbGhiChu.Text);
                GetChiThiSX();
                dtgChiThiSX.CurrentCell = dtgChiThiSX.Rows[currow].Cells[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            actionSX = 0;
            enablecontrolCTSX();
        }
        void LoadDSNhanVien()
        {
            DataTable nhanvien = Import_Manager.Instance.LoadNhanVien();
            cbNVSX.DataSource = nhanvien;
            cbNVKT.BindingContext = new BindingContext();
            cbNVKT.DataSource = nhanvien;
            cbNVXN.BindingContext = new BindingContext();
            cbNVXN.DataSource = nhanvien;
            cbNVSX.DisplayMember = "NV";
            cbNVKT.DisplayMember = "NV";
            cbNVXN.DisplayMember = "NV";
        }
        void GetMaSanPham()
        {
            DataTable data = Import_Manager.Instance.LoadDM_SP("");
            cbMaSPFilter.DataSource = data;
            cbMaSPFilter.DisplayMember = "MA_SP";
            cbMaSP.BindingContext = new BindingContext();
            cbMaSP.DataSource = data;
            cbMaSP.DisplayMember = "MA_SP";
            
        }
        void GetCongDoanSX()
        {
            DataTable congdoan = Import_Manager.Instance.getSPCongDoan(cbMaSP.Text);
            cbCongDoan.DataSource = congdoan;
            cbCongDoan.DisplayMember = "TEN_CONG_DOAN";
            cbCongDoanSau.BindingContext = new BindingContext();
            cbCongDoanSau.DataSource = congdoan;
            cbCongDoanSau.DisplayMember = "TEN_CONG_DOAN";
        }
        void GetChiThiSX()
        {
            DataTable chithi = Import_Manager.Instance.GetChiThiSanXuat(dtpTuNgay.Value, dtpDenNgay.Value, cbMaSPFilter.Text);
            dtgChiThiSX.DataSource = chithi;
        }
        void GetTenMay()
        {
            DataTable maymoc = Import_Manager.Instance.GetTenMay();
            cbTenMay.DataSource = maymoc;
            cbTenMay.DisplayMember = "TEN_MAY";
            DataTable somay = Import_Manager.Instance.GetsOMay();
            CbSomay.DataSource = somay;
            CbSomay.DisplayMember = "SO_MAY";
        }
 

        private void cbMaSPFilter_TextChanged(object sender, EventArgs e)
        {
            GetChiThiSX();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            GetChiThiSX();
        }

        private void dtgChiThiSX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgChiThiSX.CurrentRow.Cells[1].Value.ToString() != "" && actionSX != 1)
            {
                cbMaSP.Text = dtgChiThiSX.CurrentRow.Cells[0].Value.ToString();
                cbCongDoan.Text = dtgChiThiSX.CurrentRow.Cells[1].Value.ToString();
                cbCongDoanSau.Text = dtgChiThiSX.CurrentRow.Cells[2].Value.ToString();
                cbTenMay.Text = dtgChiThiSX.CurrentRow.Cells[3].Value.ToString();
                CbSomay.Text = dtgChiThiSX.CurrentRow.Cells[4].Value.ToString();
                dtpNgaySX.Value = Convert.ToDateTime(dtgChiThiSX.CurrentRow.Cells[5].Value.ToString());
                numCaSX.Text = dtgChiThiSX.CurrentRow.Cells[6].Value.ToString();
                numSoLuong.Text = dtgChiThiSX.CurrentRow.Cells[7].Value.ToString();
                numSoLot.Text = dtgChiThiSX.CurrentRow.Cells[8].Value.ToString();
                numtgSX.Text = dtgChiThiSX.CurrentRow.Cells[9].Value.ToString();
                numtgChuanBi.Text = dtgChiThiSX.CurrentRow.Cells[10].Value.ToString();
                numtgSua.Text = dtgChiThiSX.CurrentRow.Cells[11].Value.ToString();
                numtgChaoLe.Text = dtgChiThiSX.CurrentRow.Cells[12].Value.ToString();
                numtgDaoTao.Text = dtgChiThiSX.CurrentRow.Cells[13].Value.ToString();
                numtgChoKhuon.Text = dtgChiThiSX.CurrentRow.Cells[14].Value.ToString();
                numSuoc.Text = dtgChiThiSX.CurrentRow.Cells[15].Value.ToString();
                numMop.Text = dtgChiThiSX.CurrentRow.Cells[16].Value.ToString();
                numSet.Text = dtgChiThiSX.CurrentRow.Cells[17].Value.ToString();
                numBienDang.Text = dtgChiThiSX.CurrentRow.Cells[18].Value.ToString();
                numhongKhac.Text = dtgChiThiSX.CurrentRow.Cells[19].Value.ToString();
                numBaoLuu.Text = dtgChiThiSX.CurrentRow.Cells[20].Value.ToString();
                cbNVSX.Text = dtgChiThiSX.CurrentRow.Cells[21].Value.ToString();
                cbNVKT.Text = dtgChiThiSX.CurrentRow.Cells[22].Value.ToString();
                cbNVXN.Text = dtgChiThiSX.CurrentRow.Cells[23].Value.ToString();
                tbGhiChu.Text = dtgChiThiSX.CurrentRow.Cells[24].Value.ToString();
            }
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            GetChiThiSX();
        }

        private void dtgChiThiSX_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void cbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCongDoanSX();
        }

        private void cbMaSP_MouseClick(object sender, MouseEventArgs e)
        {
            cbMaSP.DroppedDown = true;
        }

        private void cbNVSX_MouseClick(object sender, MouseEventArgs e)
        {
            cbNVSX.DroppedDown = true;
        }

        private void cbNVKT_MouseClick(object sender, MouseEventArgs e)
        {
            cbNVKT.DroppedDown = true;
        }

        private void cbNVXN_MouseClick(object sender, MouseEventArgs e)
        {
            cbNVXN.DroppedDown = true;
        }

        private void nhânSựToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNhanSu f = new Chuong_Trinh_Quan_Ly_San_Xuat.FrmNhanSu();
            f.Show();
        }
    }
}
