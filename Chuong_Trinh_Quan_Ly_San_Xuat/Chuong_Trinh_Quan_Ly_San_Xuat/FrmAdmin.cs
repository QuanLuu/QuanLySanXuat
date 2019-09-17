using Chuong_Trinh_Quan_Ly_San_Xuat.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chuong_Trinh_Quan_Ly_San_Xuat
{
    public partial class FrmAdmin : Form
    {
        int Action = 0;
        public FrmAdmin()
        {
            InitializeComponent();
            LoadDataTypeTable();
            loaduser();
            loadbophan();
            dtgDataType.Dock = DockStyle.Fill;
            dtgDataTypeSheet.Dock = DockStyle.Fill;
        }
        void loaduser()
        {
            DataTable data = Import_Manager.Instance.GetUser();
            dtgUsers.DataSource = data;
        }

        private void btnNewDataType_Click(object sender, EventArgs e)
        {
            Action = 1;
            Disablecontrol();
            tbeditDataType.Text = "";
            tbdelimeter.Text = "";
            tbSourcepath.Text = "";
            tbDespath.Text = "";
            tbFilter.Text = "";
            chbignoreedit.Checked = false;
            chbtextfile.Checked = false;

        }

        private void btnEditDatatype_Click(object sender, EventArgs e)
        {
            Action = 2;
            Disablecontrol();
            if (dtgDataType.CurrentRow.Cells[0].Value.ToString() != ""  && Action != 1)
            {
                int rowselectd = dtgDataType.CurrentRow.Index;
                //LoadDataTypeSheetTable(dtgDataType[2, rowselectd].Value.ToString());
                tbeditDataType.Text = dtgDataType[2, rowselectd].Value.ToString();
                tbdelimeter.Text = dtgDataType[5, rowselectd].Value.ToString();
                tbSourcepath.Text = dtgDataType[8, rowselectd].Value.ToString();
                tbDespath.Text = dtgDataType[9, rowselectd].Value.ToString();
                tbFilter.Text = dtgDataType[10, rowselectd].Value.ToString();
                tbEditSchedule.Text = dtgDataType[3, rowselectd].Value.ToString();
                if (Convert.ToInt32(dtgDataType[1, rowselectd].Value.ToString()) == 1)
                { chbignoreedit.Checked = true; }
                else
                { chbignoreedit.Checked = false; }
                if (dtgDataType[4, rowselectd].Value.ToString() == "TEXT")
                { chbtextfile.Checked = true; }
                else
                { chbtextfile.Checked = false; }
            }
            //dtgDataType_SelectionChanged(sender, e);
        }
        private void dtgDataType_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgDataType.CurrentRow.Cells[0].Value.ToString() != "" && Action != 1)
            {
                int rowselectd = dtgDataType.CurrentRow.Index;
                LoadDataTypeSheetTable(dtgDataType[2, rowselectd].Value.ToString());
            }
        }

        private void btnCancelDataType_Click(object sender, EventArgs e)
        {
            Action = 0;
            Disablecontrol();
        }

        private void BtnSaveDataType_Click(object sender, EventArgs e)
        {
            try
            {
                int rowaffect;
                int ignore = 0;
                string text = "EXCEL";
                if (chbignoreedit.Checked == true) ignore = 1; if (chbtextfile.Checked == true) text = "TEXT";
                rowaffect = Import_Manager.Instance.UpdateDataType(Action, ignore, tbeditDataType.Text, Convert.ToInt32(tbEditSchedule.Text), text
                                                                , tbdelimeter.Text, tbSourcepath.Text, tbDespath.Text, tbFilter.Text, (int)dtgDataType.CurrentRow.Cells[0].Value);
                LoadDataTypeTable();
                Action = 0;
                Disablecontrol();
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void btnDeleteDataType_Click(object sender, EventArgs e)
        {
            Action = 3;
            if (MessageBox.Show("Are you sure to delete datatype: " + dtgDataType.CurrentRow.Cells[3].Value.ToString() + "?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                BtnSaveDataType_Click(sender, e);
        }

        private void dtgDataTpyeSheet_SelectionChanged(object sender, EventArgs e)
        {
            
        }
        void Disablecontrol()
        {
            if (Action == 0)
            {
                paeditdatatype.Visible = false;
                btnNewDataType.Enabled = true;
                btnEditDatatype.Enabled = true;
                btnDeleteDataType.Enabled = true;
                BtnSaveDataType.Enabled = false;
                btnCancelDataType.Enabled = false;
            }
            else
            {
                paeditdatatype.Visible = true;
                btnNewDataType.Enabled = false;
                btnEditDatatype.Enabled = false;
                btnDeleteDataType.Enabled = false;
                BtnSaveDataType.Enabled = true;
                btnCancelDataType.Enabled = true;
            }
        }

        void Disablecontroldatatypesheet()
        {
            if (Action == 0)
            {
                paneditdatatypesheet.Visible = false;
                btnNewDataSheet.Enabled = true;
                btnEditDataSheet.Enabled = true;
                btnDeleteDataSheet.Enabled = true;
                btnSaveDataSheet.Enabled = false;
                btnCancelDataSheet.Enabled = false;
            }
            else
            {
                paneditdatatypesheet.Visible = true;
                btnNewDataSheet.Enabled = false;
                btnEditDataSheet.Enabled = false;
                btnDeleteDataSheet.Enabled = false;
                btnSaveDataSheet.Enabled = true;
                btnCancelDataSheet.Enabled = true;
            }
        }
        void DisableUser()
        {
            if (Action == 0)
            {
                panelUser.Visible = false;
                btnNewUser.Enabled = true;
                btnEditUser.Enabled = true;
                btnDeleteUser.Enabled = true;
                btnSaveUser.Enabled = false;
                btnCancelUser.Enabled = false;
            }
            else
            {
                panelUser.Visible = true;
                btnNewUser.Enabled = false;
                btnEditUser.Enabled = false;
                btnDeleteUser.Enabled = false;
                btnSaveUser.Enabled = true;
                btnCancelUser.Enabled = true;
            }
        }
        void LoadDataTypeSheetTable(string data_type)
        {
            DataTable data = Import_Manager.Instance.LoadDataTypeSheetTable(data_type);
            dtgDataTypeSheet.DataSource = data;
        }
        void LoadDataTypeTable()
        {
            DataTable data = Import_Manager.Instance.LoadDataTypeTable();
            dtgDataType.DataSource = data;
        }
        private void btnNewDataSheet_Click(object sender, EventArgs e)
        {
            Action = 1;
            Disablecontroldatatypesheet();
            tbBuffer.Text = "";
            tbEditDataSheet.Text = "";
            tbSheetName.Text = "";
            numColumnPivot.Value = 0;
            chbpivot.Checked = false;
            chbDataSheetIgnore.Checked = false;
        }

        private void btnEditDataSheet_Click(object sender, EventArgs e)
        {
            Action = 2;
            Disablecontroldatatypesheet();
            if (dtgDataTypeSheet.CurrentRow.Cells[0].Value.ToString() != "" && Action != 1)
            {
                int rowselectd = dtgDataTypeSheet.CurrentRow.Index;
                tbEditDataSheet.Text = dtgDataTypeSheet[6, rowselectd].Value.ToString();
                tbBuffer.Text = dtgDataTypeSheet[7, rowselectd].Value.ToString();
                tbSheetName.Text = dtgDataTypeSheet[5, rowselectd].Value.ToString();
                if (dtgDataTypeSheet[3, rowselectd].Value.ToString() != "") numColumnPivot.Value = (int)dtgDataTypeSheet[4, rowselectd].Value;
                if (Convert.ToInt32(dtgDataTypeSheet[2, rowselectd].Value.ToString()) == 1)
                { chbDataSheetIgnore.Checked = true; }
                else
                { chbDataSheetIgnore.Checked = false; }
                if ((int)dtgDataTypeSheet[3, rowselectd].Value == 1)
                { chbpivot.Checked = true; }
                else
                { chbpivot.Checked = false; }
            }
        }

        private void btnCancelDataSheet_Click(object sender, EventArgs e)
        {
            Action = 0;
            Disablecontroldatatypesheet();
        }

        private void btnSaveDataSheet_Click(object sender, EventArgs e)
        {
            try
            {
                int row_affect;
                int ignore = 0;
                int pivottable = 0;
                int id = 0; 
                if (dtgDataTypeSheet.Rows.Count > 1) id = (int)dtgDataTypeSheet.CurrentRow.Cells[0].Value;
                if (chbpivot.Checked) pivottable = 1;
                if (chbDataSheetIgnore.Checked == true) ignore = 1;
                row_affect = Import_Manager.Instance.UpdateDataTypeSheet(Action, (int)dtgDataType.CurrentRow.Cells[0].Value, ignore, pivottable, (int)numColumnPivot.Value, tbSheetName.Text, tbEditDataSheet.Text, tbBuffer.Text, id);
                LoadDataTypeSheetTable(dtgDataType.CurrentRow.Cells[2].Value.ToString());
                Action = 0;
                Disablecontroldatatypesheet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteDataSheet_Click(object sender, EventArgs e)
        {
            Action = 3;
            if (MessageBox.Show("Are you sure to delete datatypesheet: " + dtgDataTypeSheet.CurrentRow.Cells[6].Value.ToString() + "?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                btnSaveDataSheet_Click(sender, e);
        }

        private void btnDeleteDataSheet_Click_1(object sender, EventArgs e)
        {
            Action = 3;
            if (MessageBox.Show("Are you sure to delete datatypesheet: " + dtgDataTypeSheet.CurrentRow.Cells[6].Value.ToString() + "?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                btnSaveDataSheet_Click(sender, e);
        }

        private void dtgDataTypeSheet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dtgDataType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            int currow = 0;
            try
            {
                if (Action == 2)
                { currow = dtgUsers.CurrentRow.Index; }
                else if (Action == 1)
                { currow = dtgUsers.Rows.Count - 1; }
                else
                { currow = 0; }
                string capquyen = "";
                for(int i = 0; i <chListCapquyen.Items.Count;i++)
                {
                    if(chListCapquyen.GetItemChecked(i)) capquyen += chListCapquyen.Items[i].ToString() + ";";
                }
               
                int results = Import_Manager.Instance.UpdateUsers(Action, (int)dtgUsers.CurrentRow.Cells[0].Value, tbTenUser.Text, tbmatkhau.Text, capquyen, tbcaSX.Text, cbbophan.Text);
                loaduser();
                dtgUsers.CurrentCell = dtgUsers.Rows[currow].Cells[0];
                Action = 0;
                DisableUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            Action = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateUsers(Action, (int)dtgUsers.CurrentRow.Cells[0].Value, tbTenUser.Text, tbmatkhau.Text, chListCapquyen.Text, tbcaSX.Text, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Action = 0;
            DisableUser();
            loaduser();
        }

     
        private void btnNewUser_Click(object sender, EventArgs e)
        {
            Action = 1;
            tbTenUser.Text = "";
            tbmatkhau.Text = "";
            tbcaSX.Text = "";
            DisableUser();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            Action = 2;
            if (dtgUsers.CurrentRow != null)
            {
                int rowselectd = dtgUsers.CurrentRow.Index;
                tbTenUser.Text = dtgUsers[1, rowselectd].Value.ToString();
                tbmatkhau.Text = dtgUsers[2, rowselectd].Value.ToString();
                tbcaSX.Text = dtgUsers[4, rowselectd].Value.ToString();
                cbbophan.Text = dtgUsers[5, rowselectd].Value.ToString();
                string quyenhan = dtgUsers[3, rowselectd].Value.ToString();
                for (int i = 0; i < chListCapquyen.Items.Count; i++)
                {
                    chListCapquyen.SetItemChecked(i, false);
                    if (quyenhan.Contains(chListCapquyen.Items[i].ToString())) chListCapquyen.SetItemChecked(i, true);
                }

            }
            DisableUser();
        }

        private void btnCancelUser_Click(object sender, EventArgs e)
        {
            Action = 0;
            DisableUser();
        }
        void loadbophan()
        {
            DataTable data = Import_Manager.Instance.getbophan();
            cbbophan.DataSource = data;
            cbbophan.DisplayMember = "TEN";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
