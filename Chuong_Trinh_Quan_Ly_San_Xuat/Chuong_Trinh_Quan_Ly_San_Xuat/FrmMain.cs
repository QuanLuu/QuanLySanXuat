﻿using Chuong_Trinh_Quan_Ly_San_Xuat.BLL;
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
    public partial class FrmMain : Form
    {
        public string quyensudung;

        public FrmMain()
        {
            InitializeComponent();
            EventKhiLoadForm(this.panelMain);
            getusername();
            panelMain.Enabled = false;
        }
        void HieuUngChon(Control col)
        {
            if (col.GetType().Name == "Label") col.BackColor = Color.White;
            if (col.GetType().Name == "PictureBox") col.BackColor = Color.White;
        }

        void BoHieuUng(Control col)
        {
            if (col.GetType().Name == "Label") col.BackColor = Color.LightBlue;
            if (col.GetType().Name == "PictureBox") col.BackColor = Color.LightBlue;
        }
        void EventKhiLoadForm(Control col)
        {
            foreach (Control c in col.Controls)
            {
                if (c.GetType().Name == "Label") c.MouseHover += hieung;
                if (c.GetType().Name == "PictureBox") c.MouseHover += hieung;
                if (c.GetType().Name == "Label") c.MouseLeave += bohieung;
                if (c.GetType().Name == "PictureBox") c.MouseLeave += bohieung;
                EventKhiLoadForm(c);
            }
        }

        private void bohieung(object sender, EventArgs e)
        {
            BoHieuUng((Control)sender);
        }

        private void hieung(object sender, EventArgs e)
        {
            HieuUngChon((Control)sender);
        }

        private void toolStripbtnDangNhap_Click(object sender, EventArgs e)
        {
           
        }
        void enablecontrol()
        {
            panelMain.Enabled = true;
        }
        void getusername()
        {
            DataTable tendn = Import_Manager.Instance.GetTenDangNhap();
            for (int i = 0; i < tendn.Rows.Count; i++)
            {
                cbName.Items.Add(tendn.Rows[i][1].ToString());
            }

        }
        void showdanhmuc()
        {
            FrmDanhMuc danhmuc = new FrmDanhMuc();
            this.Hide();
            danhmuc.Show();
            danhmuc.FormClosing += main_close;

        }

        void showchithisx()
        {
            FrmChiThiSX chithisx = new FrmChiThiSX();
            this.Hide();
            chithisx.Show();
            chithisx.FormClosing += main_close;

        }

        void shownhansu()
        {
            FrmNhanSu frm = new FrmNhanSu();
            this.Hide();
            frm.Show();
            frm.FormClosing += main_close;

        }

        private void main_close(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            showdanhmuc();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            showchithisx();
        }

        private void lbDanhMuc_Click(object sender, EventArgs e)
        {
            showdanhmuc();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            showchithisx();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable data = Import_Manager.Instance.CheckLogin(cbName.Text, tbPass.Text);
                int kqcheck = data.Rows.Count;
                if (kqcheck > 0)
                {
                    quyensudung = data.Rows[0][1].ToString();
                    enablecontrol();
                    panelLogin.Visible = false;
                }
                else
                {
                    MessageBox.Show("Không đúng mật khẩu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            shownhansu();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            shownhansu();
        }
    }
}