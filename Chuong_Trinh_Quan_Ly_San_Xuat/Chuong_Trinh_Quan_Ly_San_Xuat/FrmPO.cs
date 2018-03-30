﻿using Chuong_Trinh_Quan_Ly_San_Xuat.BLL;
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
    public partial class FrmPO : Form
    {
        int action = 0;
        public FrmPO()
        {
            InitializeComponent();
            dtgPO.Dock = DockStyle.Fill;
            dtgForecast.Dock = DockStyle.Fill;
            dtgListTime.Dock = DockStyle.Fill;
            dtpDateFromPOFilter.Value = DateTime.Now.AddDays(-30);
            dtpDateToPOFilter.Value = DateTime.Now;
            dtpfromforecastfilter.Value = DateTime.Now.AddDays(-30);
            dtptoforecastfilter.Value = DateTime.Now;
            loadallPO();
            LoadForecast();
            loadlistitme();
            loadkhachhang();
            
        }
        void loadallPO()
        {
            DataTable data = Import_Manager.Instance.getpoall(tbMaKHPOFilter.Text, tbMSQLPOFilter.Text, dtpDateFromPOFilter.Value, dtpDateToPOFilter.Value);
            dtgPO.DataSource = data;
        }
        void LoadForecast()
        {
            DataTable data = Import_Manager.Instance.getForecast(tbMaKHForecastFil.Text, tbmsqlforecastfilter.Text, dtpfromforecastfilter.Value, dtptoforecastfilter.Value);
            dtgForecast.DataSource = data;
        }

        void loadlistitme()
        {
            DataTable data = Import_Manager.Instance.getlisttime(tbMSQLListtimeFilter.Text);
            dtgListTime.DataSource = data;
        }
        void loadsanphmtheokh()
        {
            DataTable data = Import_Manager.Instance.GetKhvamasp(cbMaKHPO.Text);
            cbMSQLPO.DisplayMember = "MSQL";
            cbMSQLPO.DataSource = data;
            cbMaSPPO.DisplayMember = "MA_SP";
            cbMaSPPO.DataSource = data;
            cbmsqlforecast.DisplayMember = "MSQL";
            cbmsqlforecast.DataSource = data;
            cbmaspforecast.DisplayMember = "MA_SP";
            cbmaspforecast.DataSource = data;
        }
        void loadkhachhang()
        {
            DataTable data = Import_Manager.Instance.LoadKH(tbMaKHPOFilter.Text);
            cbMaKHPO.DisplayMember = "MA_KH";
            cbMaKHPO.DataSource = data;
            cbmakhforecast.DisplayMember = "MA_KH";
            cbmakhforecast.DataSource = data;
        }
        void getmacongdoantheomsql()
        {
            DataTable data = Import_Manager.Instance.Loadcongdoantheomsql(tbmsqllisttime.Text);
            cbMaCDListTime.DisplayMember = "MA_CONG_DOAN";
            cbMaCDListTime.DataSource = data;

        }
        private void tbMaKHPOFilter_TextChanged(object sender, EventArgs e)
        {
            loadallPO();
        }

        private void tbMSQLPOFilter_TextChanged(object sender, EventArgs e)
        {
            loadallPO();
        }

        private void dtpDateFromPOFilter_ValueChanged(object sender, EventArgs e)
        {
            loadallPO();
        }

        private void dtpDateToPOFilter_ValueChanged(object sender, EventArgs e)
        {
            loadallPO();
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
                if (tabPO.SelectedIndex == 0) panelPO.Visible = false;
                if (tabPO.SelectedIndex == 2) panelListtime.Visible = false;
                if (tabPO.SelectedIndex == 1) panelForecast.Visible = false;

            }
            else
            {
                btnNew.Enabled = false;
                BtnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                if (tabPO.SelectedIndex == 0) panelPO.Visible = true;
                if (tabPO.SelectedIndex == 2) panelListtime.Visible = true;
                if (tabPO.SelectedIndex == 1) panelForecast.Visible = true;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            action = 1;
            enablecontrol();
            if (tabPO.SelectedIndex == 0) nhapmoi(this.panelPO);
            if (tabPO.SelectedIndex == 1) nhapmoi(this.panelForecast);
            if (tabPO.SelectedIndex == 2) nhapmoi(this.panelListtime);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            action = 2;
            enablecontrol();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            action = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {

                if (tabPO.SelectedIndex == 0)
                { 
                    int results = Import_Manager.Instance.UpdatePO(action, (int)dtgPO.CurrentRow.Cells[0].Value, cbMaSPPO.Text, dtpNgayPO.Value, tbSoPO.Text, dtpETD.Value, dtpETA.Value, (int)numsoluongPO.Value, numdongiaPO.Value, tbghichupo.Text);
                    loadallPO();
                }
                if (tabPO.SelectedIndex == 1)
                {
                    int results = Import_Manager.Instance.Updateforecast(action, (int)dtgForecast.CurrentRow.Cells[0].Value, cbmaspforecast.Text, dtpNgayforecast.Value, dtpngaydukien.Value, (int)numsoluongforecast.Value, tbghichuforecast.Text);
                    LoadForecast();
                }
                if (tabPO.SelectedIndex == 2)
                {

                    int results = Import_Manager.Instance.updatelisttime(action, (int)dtgListTime.CurrentRow.Cells[0].Value, cbMaCDListTime.Text, (int)numlisttime.Value);
                    loadlistitme();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            action = 0;
            enablecontrol();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            action = 0;
            enablecontrol();
        }
       
        private void tbMSQLListtimeFilter_TextChanged(object sender, EventArgs e)
        {
            loadlistitme();
        }
        void nhapmoi(Control col)
        {
            foreach (Control c in col.Controls)
            {
                if (c.GetType().Name == "NumericUpDown") c.Text = "0";
                if (c.GetType().Name == "TextBox") c.Text = "";
                if (c.GetType().Name == "ComboBox") c.Text = "";
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int currow = 0;
            int id = 0;
            try
            {
                if (tabPO.SelectedIndex == 0)
                {
                    if (dtgPO.Rows.Count > 1 && dtgPO.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgPO.CurrentRow.Cells[0].Value;
                    if (action == 2)
                    { currow = dtgPO.CurrentRow.Index; }
                    else if (action == 1)
                    { currow = dtgPO.Rows.Count - 1; }
                    else
                    { currow = 0; }
                    int results = Import_Manager.Instance.UpdatePO(action, id, cbMaSPPO.Text, dtpNgayPO.Value, tbSoPO.Text, dtpETD.Value, dtpETA.Value, (int)numsoluongPO.Value, numdongiaPO.Value,tbghichupo.Text);
                    loadallPO();
                    dtgPO.CurrentCell = dtgPO.Rows[currow].Cells[0];
                }
                if (tabPO.SelectedIndex == 1)
                {
                    if (dtgForecast.Rows.Count > 1 && dtgForecast.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgForecast.CurrentRow.Cells[0].Value;
                    if (action == 2)
                    { currow = dtgForecast.CurrentRow.Index; }
                    else if (action == 1)
                    { currow = dtgForecast.Rows.Count - 1; }
                    else
                    { currow = 0; }
                    int results = Import_Manager.Instance.Updateforecast(action, id, cbmaspforecast.Text, dtpNgayforecast.Value, dtpngaydukien.Value, (int)numsoluongforecast.Value, tbghichuforecast.Text);
                    LoadForecast(); 
                    dtgForecast.CurrentCell = dtgForecast.Rows[currow].Cells[0];
                }

                if (tabPO.SelectedIndex == 2)
                {
                    if (dtgListTime.Rows.Count > 1 && dtgListTime.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgListTime.CurrentRow.Cells[0].Value;
                    if (action == 2)
                    { currow = dtgListTime.CurrentRow.Index; }
                    else if (action == 1)
                    { currow = dtgListTime.Rows.Count - 1; }
                    else
                    { currow = 0; }
                    int results = Import_Manager.Instance.updatelisttime(action, id, cbMaCDListTime.Text, (int)numlisttime.Value);
                    loadlistitme();
                    dtgListTime.CurrentCell = dtgListTime.Rows[currow].Cells[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            action = 0;
            enablecontrol();
        }

        private void cbMaKHPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadsanphmtheokh();
        }

        private void tbmsqllisttime_TextChanged(object sender, EventArgs e)
        {
            getmacongdoantheomsql();
        }

        private void dtgListTime_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dtgListTime.CurrentRow.Cells[0].Value.ToString() != "" && action != 1)
            {
                tbmsqllisttime.Text = dtgListTime.CurrentRow.Cells[1].Value.ToString();
                cbMaCDListTime.Text = dtgListTime.CurrentRow.Cells[2].Value.ToString();
                numlisttime.Text = dtgListTime.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void dtgPO_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgPO.CurrentRow.Cells[0].Value.ToString() != "" && action != 1)
            {
                cbMaKHPO.Text = dtgPO.CurrentRow.Cells[1].Value.ToString();
                cbMSQLPO.Text = dtgPO.CurrentRow.Cells[2].Value.ToString();
                cbMaSPPO.Text = dtgPO.CurrentRow.Cells[3].Value.ToString();
                dtpNgayPO.Value = Convert.ToDateTime(dtgPO.CurrentRow.Cells[4].Value.ToString());
                tbSoPO.Text = dtgPO.CurrentRow.Cells[5].Value.ToString();
                dtpETA.Value = Convert.ToDateTime(dtgPO.CurrentRow.Cells[6].Value.ToString());
                dtpETD.Value = Convert.ToDateTime(dtgPO.CurrentRow.Cells[7].Value.ToString());
                numsoluongPO.Text = dtgPO.CurrentRow.Cells[8].Value.ToString();
                numdongiaPO.Text = dtgPO.CurrentRow.Cells[9].Value.ToString();
                tbghichupo.Text = dtgPO.CurrentRow.Cells[10].Value.ToString();
            }
        }

        private void tbMaKHForecastFil_TextChanged(object sender, EventArgs e)
        {
            LoadForecast();
        }

        private void tbmsqlforecastfilter_TextChanged(object sender, EventArgs e)
        {
            LoadForecast();
        }

        private void dtpfromforecastfilter_ValueChanged(object sender, EventArgs e)
        {
            LoadForecast();
        }

        private void dtptoforecastfilter_ValueChanged(object sender, EventArgs e)
        {
            LoadForecast();
        }

        private void dtgForecast_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgForecast.CurrentRow.Cells[0].Value.ToString() != "" && action != 1)
            {
                cbmakhforecast.Text = dtgForecast.CurrentRow.Cells[1].Value.ToString();
                cbmsqlforecast.Text = dtgForecast.CurrentRow.Cells[2].Value.ToString();
                cbmaspforecast.Text = dtgForecast.CurrentRow.Cells[3].Value.ToString();
                dtpNgayforecast.Value = Convert.ToDateTime(dtgForecast.CurrentRow.Cells[4].Value.ToString());
                dtpngaydukien.Value = Convert.ToDateTime(dtgForecast.CurrentRow.Cells[5].Value.ToString());       
                numsoluongforecast.Text = dtgForecast.CurrentRow.Cells[6].Value.ToString();
                tbghichuforecast.Text = dtgForecast.CurrentRow.Cells[7].Value.ToString();
            }
        }

        private void cbmakhforecast_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadsanphmtheokh();
        }
    }
}
