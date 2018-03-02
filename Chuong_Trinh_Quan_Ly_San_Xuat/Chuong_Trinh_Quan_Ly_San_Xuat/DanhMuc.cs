using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chuong_Trinh_Quan_Ly_San_Xuat.BLL;

namespace Chuong_Trinh_Quan_Ly_San_Xuat
{
    public partial class FrmDanhMuc : Form
    {
        int actionNL = 0;
        int actionSP = 0;
        int actionKH = 0;
        int actionDM = 0;
        int actionCD = 0;
        int actionMM = 0;
        int actionSPCD = 0;
        public FrmDanhMuc()
        {
            InitializeComponent();
            dtgNL.Dock = DockStyle.Fill;
            dtgSP.Dock = DockStyle.Fill;
            dtgSPCD.Dock = DockStyle.Fill;
            dtgKH.Dock = DockStyle.Fill;
            dtgDM.Dock = DockStyle.Fill;
            dtgCongDoan.Dock = DockStyle.Fill;
            dtgMayMoc.Dock = DockStyle.Fill;
            //dtpDateFrom.CustomFormat = "yyyy-mm-dd";
            //dtpDateTo.CustomFormat = "yyyy-mm-dd";
            GetNguyenLieu();
            enablecontrolNL();
            enablecontrolSP();
            enablecontrolSPCD();
            GetSanPham();
            GetKhachHang();
            enablecontrolKH();
            GetDinhMuc();
            enablecontrolDM();
            enablecontrolCD();
            enablecontrolMM();
            getcongdoan();
            getmaymoc();
            getSPCD();
        }
        void GetNguyenLieu()
        {
            DataTable data = Import_Manager.Instance.LoadDM_NL(tbFilterNL.Text);
            dtgNL.DataSource = data;
            cbTenNL.DataSource = data;
            cbTenNL.DisplayMember = "TEN_NL";
        }

        void GetSanPham()
        {
            DataTable data = Import_Manager.Instance.LoadDM_SP(tbFilterSP.Text);
            dtgSP.DataSource = data;
            cbMaSPDM.DataSource = data;
            cbMaSPDM.DisplayMember = "MA_SP";
            cbMaSPCD.BindingContext = new BindingContext();
            cbMaSPCD.DataSource = data;
            cbMaSPCD.DisplayMember = "MA_SP";
        }

        void GetKhachHang()
        {
            DataTable data = Import_Manager.Instance.LoadKH(tbFilterKH.Text);
            dtgKH.DataSource = data;
            cbMaKH.DataSource = data;
            cbMaKH.DisplayMember = "MA_KH";
            //cbMaSPDM.DataSource = data;
            //cbMaSPDM.DisplayMember = "MA_KH";
        }
        void GetDinhMuc()
        {
            DataTable data = Import_Manager.Instance.LoadDM(tbfilterMaSPDM.Text);
            dtgDM.DataSource = data;
        }

        void getSPCD()
        {
            DataTable spcd = Import_Manager.Instance.getSPCongDoan(tbSPCD.Text);
            dtgSPCD.DataSource = spcd;
        }

        void getcongdoan()
        {
            DataTable congdoan = Import_Manager.Instance.GetCongDoan();
            dtgCongDoan.DataSource = congdoan;
            cbTenCDSP.DataSource = congdoan;
            cbTenCDSP.DisplayMember = "TEN_CONG_DOAN";
        }

        void getmaymoc()
        {
            DataTable maymoc = Import_Manager.Instance.GetTenMay();
            dtgMayMoc.DataSource = maymoc;
        }

        private void tbFilterNL_TextChanged(object sender, EventArgs e)
        {
            GetNguyenLieu();
        }

        private void dtgNL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbTenNL.Text = dtgNL.CurrentRow.Cells[1].Value.ToString();
            tbKichCo.Text = dtgNL.CurrentRow.Cells[2].Value.ToString();
            if(dtgNL.CurrentRow.Cells[3].Value.ToString() != "") numNL.Value = Convert.ToDecimal(dtgNL.CurrentRow.Cells[3].Value.ToString());
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

        void enablecontrolCD()
        {
            if (actionCD == 0)
            {
                btnNewCD.Enabled = true;
                btnEditCD.Enabled = true;
                btnDeleteCD.Enabled = true;
                btnSaveCD.Enabled = false;
                btnCancelCD.Enabled = false;
                panelCD.Visible = false;
            }
            else
            {
                btnNewCD.Enabled = false;
                btnEditCD.Enabled = false;
                btnDeleteCD.Enabled = false;
                btnSaveCD.Enabled = true;
                btnCancelCD.Enabled = true;
                panelCD.Visible = true;
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

        private void BtnEdit_Click(object sender, EventArgs e)
        {

            actionNL = 2;
            enablecontrolNL();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int currow = 0;
            try
            {
                if (actionNL == 2)
                { currow = dtgNL.CurrentRow.Index; }
                else if (actionNL == 1)
                { currow = dtgNL.Rows.Count - 1; }
                else
                { currow = 0; }
                int results = Import_Manager.Instance.UpdateNL(actionNL, (int)dtgNL.CurrentRow.Cells[0].Value, tbTenNL.Text, tbKichCo.Text, numNL.Value);
                GetNguyenLieu();
                dtgNL.CurrentCell = dtgNL.Rows[currow].Cells[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            actionNL = 0;
            enablecontrolNL();
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
                int results = Import_Manager.Instance.UpdateNL(actionNL, (int)dtgNL.CurrentRow.Cells[0].Value, tbTenNL.Text, tbKichCo.Text, numNL.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            actionNL = 0;
            enablecontrolNL();
            GetNguyenLieu();
        }

        private void btnNewSP_Click(object sender, EventArgs e)
        {
            tbMaSP.Text = "";
            tbTenSP.Text = "";
            numSP.Value = 0;
            cbTenNL.Text = "";
            cbMaKH.Text = "";
            actionSP = 1;
            enablecontrolSP();
        }

        private void btnEditSP_Click(object sender, EventArgs e)
        {

            actionSP = 2;
            enablecontrolSP();
        }

        private void btnCancelSP_Click(object sender, EventArgs e)
        {

            actionSP = 0;
            enablecontrolSP();
        }

        private void btnSaveSP_Click(object sender, EventArgs e)
        {
            int currow = 0;
            try
            {
                if (actionSP == 2)
                { currow = dtgSP.CurrentRow.Index; }
                else if (actionSP == 1)
                { currow = dtgSP.Rows.Count - 1; }
                else
                { currow = 0; }

                int results = Import_Manager.Instance.UpdateSP(actionSP, (int)dtgSP.CurrentRow.Cells[0].Value, tbMaSP.Text, tbTenSP.Text, cbTenNL.Text, cbMaKH.Text, numSP.Value);
                GetSanPham();
                dtgSP.CurrentCell = dtgSP.Rows[currow].Cells[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            actionSP = 0;
            enablecontrolSP();
        }

        private void tbFilterSP_TextChanged(object sender, EventArgs e)
        {
            GetSanPham();
        }

        private void dtgSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbMaSP.Text = dtgSP.CurrentRow.Cells[1].Value.ToString();
            tbTenSP.Text = dtgSP.CurrentRow.Cells[2].Value.ToString();
            cbTenNL.Text = dtgSP.CurrentRow.Cells[3].Value.ToString();
            cbMaKH.Text = dtgSP.CurrentRow.Cells[4].Value.ToString();
            if (dtgSP.CurrentRow.Cells[5].Value.ToString() != "") numSP.Value = Convert.ToDecimal(dtgSP.CurrentRow.Cells[5].Value.ToString());
        }

        private void btnDeleteSP_Click(object sender, EventArgs e)
        {
            actionSP = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateSP(actionSP, (int)dtgSP.CurrentRow.Cells[0].Value, tbMaSP.Text, tbTenSP.Text, cbTenNL.Text, cbMaKH.Text, numSP.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            actionSP = 0;
            enablecontrolSP();
            GetSanPham();
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

        private void dtgKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbMaKH.Text = dtgKH.CurrentRow.Cells[1].Value.ToString();
            tbKH.Text = dtgKH.CurrentRow.Cells[2].Value.ToString();
            tbNguoiLienHe.Text = dtgKH.CurrentRow.Cells[3].Value.ToString();
            tbBoPhan.Text = dtgKH.CurrentRow.Cells[4].Value.ToString();
            tbDiaChi.Text = dtgKH.CurrentRow.Cells[7].Value.ToString();
            tbEmail.Text = dtgKH.CurrentRow.Cells[6].Value.ToString();
            tbSdt.Text = dtgKH.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnEditKH_Click(object sender, EventArgs e)
        {
            actionKH = 2;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            actionKH = 0;
            enablecontrolKH();
            GetKhachHang();
        }

        private void btnSaveKH_Click(object sender, EventArgs e)
        {
            int currow = 0;
            try
            {
                if (actionKH == 2)
                { currow = dtgKH.CurrentRow.Index; }
                else if (actionKH == 1)
                { currow = dtgKH.Rows.Count - 1; }
                else
                { currow = 0; }

                int results = Import_Manager.Instance.UpdateKH(actionKH, (int)dtgKH.CurrentRow.Cells[0].Value, tbMaKH.Text, tbKH.Text, tbNguoiLienHe.Text, tbBoPhan.Text, tbSdt.Text, tbEmail.Text, tbDiaChi.Text);
                GetKhachHang();
                dtgKH.CurrentCell = dtgKH.Rows[currow].Cells[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            actionKH = 0;
            enablecontrolKH();
        }

        private void btnNewDM_Click(object sender, EventArgs e)
        {
            actionDM = 1;
            cbMaSPDM.Text = "";
            numDinhMuc.Value = 0;
            dtpDateFrom.Value = DateTime.Now;
            dtpDateTo.Value = DateTime.Now.AddYears(1);
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
            enablecontrolMM();
        }

        private void btnDeleteMM_Click(object sender, EventArgs e)
        {
            actionMM = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateMaymoc(actionMM, (int)dtgMayMoc.CurrentRow.Cells[0].Value, tbTenMay.Text, Int32.Parse(tbSoMay.Text.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            actionMM = 0;
            enablecontrolMM();
            getmaymoc();
        }

        private void btnCancelMM_Click(object sender, EventArgs e)
        {
            actionMM = 0;
            enablecontrolMM();
        }

        private void btnNewCD_Click(object sender, EventArgs e)
        {
            actionCD = 1;
            tbTenCD.Text = "";
            enablecontrolCD();
        }

        private void btnEditCD_Click(object sender, EventArgs e)
        {
            actionCD = 2;
            enablecontrolCD();
        }

        private void btnCancelCD_Click(object sender, EventArgs e)
        {
            actionCD = 0;
            enablecontrolCD();
        }

        private void btnSaveCD_Click(object sender, EventArgs e)
        {
            int currow = 0;
            try
            {
                if (actionCD == 2)
                { currow = dtgCongDoan.CurrentRow.Index; }
                else if (actionCD == 1)
                { currow = dtgCongDoan.Rows.Count - 1; }
                else
                { currow = 0; }
                int results = Import_Manager.Instance.UpdateCongDoan(actionCD, (int)dtgCongDoan.CurrentRow.Cells[0].Value, tbTenCD.Text);
                getcongdoan();
                dtgCongDoan.CurrentCell = dtgCongDoan.Rows[currow].Cells[0];
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    actionCD = 0;
            enablecontrolCD();
        }

        private void btnSaveMM_Click(object sender, EventArgs e)
        {
            int currow = 0;
            try
            {
                if (actionMM == 2)
                { currow = dtgMayMoc.CurrentRow.Index; }
                else if (actionMM == 1)
                { currow = dtgMayMoc.Rows.Count - 1; }
                else
                { currow = 0; }
                int results = Import_Manager.Instance.UpdateMaymoc(actionMM, (int)dtgMayMoc.CurrentRow.Cells[0].Value, tbTenMay.Text, Int32.Parse(tbSoMay.Text.ToString()));
                getmaymoc();
                dtgMayMoc.CurrentCell = dtgMayMoc.Rows[currow].Cells[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            actionMM = 0;
            enablecontrolMM();
        }

        private void btnDeleteCD_Click(object sender, EventArgs e)
        {
            actionCD = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateCongDoan(actionCD, (int)dtgCongDoan.CurrentRow.Cells[0].Value, tbTenCD.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            actionCD = 0;
            enablecontrolCD();
            getcongdoan();
        }

        private void dtgCongDoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbTenCD.Text  = dtgCongDoan.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnEditDM_Click(object sender, EventArgs e)
        {
            actionDM = 2;
            enablecontrolDM();
        }

        private void btnDeleteDM_Click(object sender, EventArgs e)
        {
            actionDM = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateDinhMuc(actionDM, (int)dtgDM.CurrentRow.Cells[0].Value, dtpDateFrom.Value, dtpDateTo.Value, cbMaSPDM.Text, numDinhMuc.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            actionDM = 0;
            enablecontrolDM();
            GetDinhMuc();
        }

        private void btnSaveDM_Click(object sender, EventArgs e)
        {
            int currow = 0;
            try
            {
                if (actionDM == 2)
                { currow = dtgDM.CurrentRow.Index; }
                else if (actionDM == 1)
                { currow = dtgDM.Rows.Count - 1; }
                else
                { currow = 0; }
                int results = Import_Manager.Instance.UpdateDinhMuc(actionDM, (int)dtgDM.CurrentRow.Cells[0].Value, dtpDateFrom.Value.Date, dtpDateTo.Value.Date, cbMaSPDM.Text, numDinhMuc.Value);
                GetDinhMuc();
                dtgDM.CurrentCell = dtgDM.Rows[currow].Cells[0];
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    actionDM = 0;
            enablecontrolDM();
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
            cbMaSPCD.Text = "";
            cbTenCDSP.Text = "";
        }

        private void btnEditSPCD_Click(object sender, EventArgs e)
        {
            actionSPCD = 2;
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
            int currow = 0;
            try
            {
                if (actionSPCD == 2)
                { currow = dtgSPCD.CurrentRow.Index; }
                else if (actionSPCD == 1)
                { currow = dtgSPCD.Rows.Count - 1; }
                else
                { currow = 0; }
                int results = Import_Manager.Instance.UpdateSPCongDoan(actionSPCD, (int)dtgSPCD.CurrentRow.Cells[0].Value, cbMaSPCD.Text, cbTenCDSP.Text);
                getSPCD();
                dtgSPCD.CurrentCell = dtgSPCD.Rows[currow].Cells[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            actionSPCD = 0;
            enablecontrolSPCD();
        }

        private void btnDeleteSPCD_Click(object sender, EventArgs e)
        {
            actionSPCD = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateSPCongDoan(actionSPCD, (int)dtgSPCD.CurrentRow.Cells[0].Value, cbMaSPCD.Text, cbTenCDSP.Text );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            actionSPCD = 0;
            enablecontrolSPCD();
            getSPCD();
        }

        private void dtgSPCD_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dtgSPCD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgSPCD.CurrentRow.Cells[0].Value.ToString() != "" && actionSPCD != 1)
            {
                cbMaSPCD.Text = dtgSPCD.CurrentRow.Cells[1].Value.ToString();
                cbTenCDSP.Text = dtgSPCD.CurrentRow.Cells[2].Value.ToString();
            }
        }
    }
}
