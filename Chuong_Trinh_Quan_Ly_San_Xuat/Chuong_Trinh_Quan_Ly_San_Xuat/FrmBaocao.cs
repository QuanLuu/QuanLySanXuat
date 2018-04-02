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
            System.Diagnostics.Process.Start("http://laptop318/Reports/report/In%20CTSX");
        }

    }
}
