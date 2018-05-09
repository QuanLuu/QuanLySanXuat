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
    public partial class FrmBaocao : Form
    {
        public FrmBaocao()
        {
            InitializeComponent();
        }

        private void btninCTSX_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://tran_tuan/ReportServer/Pages/ReportViewer.aspx?%2fIn+CTSX&rs:Command=Render");
        }

        private void btnUpdatedulieu_Click(object sender, EventArgs e)
        {
            try
            {
                int result = Import_Manager.Instance.UpdateDuLieu();
                MessageBox.Show("Cập nhật dữ liệu xong");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInpass_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://tran_tuan/ReportServer/Pages/ReportViewer.aspx?%2fPO_Pass&rs:Command=Render");
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://tran_tuan/ReportServer/Pages/ReportViewer.aspx?%2fInvoice&rs:Command=Render");
        }
    }
}
