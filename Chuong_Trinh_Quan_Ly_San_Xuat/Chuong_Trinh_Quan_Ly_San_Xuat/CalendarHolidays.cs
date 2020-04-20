/*
 * Copyright © 2005, Patrik Bohman
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without modification, 
 * are permitted provided that the following conditions are met:
 *
 *    - Redistributions of source code must retain the above copyright notice, 
 *      this list of conditions and the following disclaimer.
 * 
 *    - Redistributions in binary form must reproduce the above copyright notice, 
 *      this list of conditions and the following disclaimer in the documentation 
 *      and/or other materials provided with the distribution.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
 * IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
 * INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
 * NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, 
 * OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
 * OF SUCH DAMAGE.
 * https://www.codeproject.com/Articles/10840/Another-Month-Calendar
 */
using Pabo.Calendar;
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
    public partial class CalendarHolidays : Form
    {
        int action = 0;
        DateTime startdae;
        DateTime enddate;
        public CalendarHolidays()
        {
            InitializeComponent();

            if (DateTime.Now.Month >= 4)
            {   
                startdae = new DateTime(DateTime.Now.Year, 4, 1);
                enddate = new DateTime(DateTime.Now.Year +1, 3, 31);
                createcalendaryear(DateTime.Now.Year);
                
            }
            else
            {
                startdae = new DateTime(DateTime.Now.Year-1, 4, 1);
                enddate = new DateTime(DateTime.Now.Year, 3, 31);
                createcalendaryear(DateTime.Now.Year - 1);
            }

            tbnamfil.Text = DateTime.Now.Year.ToString();
            refreshallholidays(startdae, enddate);
            getholiday();
            dtgholiday.Columns[0].Width = 0;
        }

        private void monthCalendar1_DayQueryInfo(object sender,
                            DayQueryInfoEventArgs e)
        {
            // Check date
            if (e.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                // Add custom formatting
                e.Info.BackColor1 = Color.Yellow;
                //e.Info.BackColor2 = Color.GhostWhite;
                //e.Info.ImageListIndex = 3;
                e.Info.GradientMode = mcGradientMode.Horizontal;
                // Set ownerdraw = true to add custom formatting
                e.OwnerDraw = true;
            }
        }
        private void monthCalendar_DayQueryInfo(object sender,
                            DayQueryInfoEventArgs e)
        {
            // Check date
            if (e.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                // Add custom formatting
                e.Info.BackColor1 = Color.Yellow;
                e.Info.BackColor2 = Color.GhostWhite;
                //e.Info.ImageListIndex = 3;
                e.Info.GradientMode = mcGradientMode.Horizontal;
                // Set ownerdraw = true to add custom formatting
                e.OwnerDraw = true;
            }
        }
        void createcalendaryear(int year)
        {
            int month_ = 1;
            int year_ = year;
            for (int i = 4;i<=15;i++)
            {
                month_ = i; year_ = year;
                if (i > 12)
                {
                    month_ = i - 12;
                    year_ = year + 1;
                }
                Pabo.Calendar.MonthCalendar frm = new Pabo.Calendar.MonthCalendar();
                frm.Name = "calmonth" + month_.ToString();
                frm.ActiveMonth.Month = month_;
                frm.ActiveMonth.Year = year_;
                frm.Width = 216; frm.Height = 184;
                frm.ShowFooter = false;
                frm.DayQueryInfo += monthCalendar_DayQueryInfo;
                flowpal.Controls.Add(frm);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelholiday.Visible = true;
        }

        private void btnNewDM_Click(object sender, EventArgs e)
        {
            action = 1;
            enablecontrol();
        }
        void enablecontrol()
        {
            if (action == 0)
            {
                btnNew.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                panelentry.Visible = false;

            }
            else
            {
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                panelentry.Visible = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            action = 2;
            if (dtgholiday.CurrentRow != null)
            {
                dtpdate.Text = dtgholiday.CurrentRow.Cells[1].Value.ToString();
                tbdesc.Text = dtgholiday.CurrentRow.Cells[2].Value.ToString();
               
            }
            enablecontrol();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            action = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                DateTime date_ = DateTime.Parse(dtgholiday.CurrentRow.Cells[1].Value.ToString());
                int results = Import_Manager.Instance.updateholidays(action, (int)dtgholiday.CurrentRow.Cells[0].Value , dtpdate.Value, tbdesc.Text);
                action = 0;
                enablecontrol();
                getholiday();
                refreshcalendarformat(date_, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            action = 0;
            enablecontrol();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            int currow = current_row(action, dtgholiday);
            int id = 0;
            if (action != 1) id = (int)dtgholiday.CurrentRow.Cells[0].Value;
            try
            {
                if (tbdesc.Text != "")
                {
                    DateTime date_ = dtpdate.Value;
                    int results = BLL.Import_Manager.Instance.updateholidays(action, id, date_, tbdesc.Text );
                    getholiday();
                    refreshallholidays(startdae, enddate);
                    dtgholiday.CurrentCell = dtgholiday.Rows[currow].Cells[0];
                    action = 0;
                    enablecontrol();
                }
                else
                {
                    MessageBox.Show("mô tả trống");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void getholiday()
        {
            DataTable data = Import_Manager.Instance.getholiday(Int32.Parse(tbnamfil.Text));
            dtgholiday.DataSource = data;
        }
        void refreshallholidays(DateTime stardate, DateTime enddate)
        {
            DateTime date_;
            DataTable data = Import_Manager.Instance.getholiday(startdae.Year);
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    date_ = DateTime.Parse(data.Rows[i][1].ToString());
                    if (date_ >= stardate && date_ <= enddate)
                        refreshcalendarformat(date_,1);
                }
            }
            DataTable data1 = Import_Manager.Instance.getholiday(enddate.Year);
            if (data1.Rows.Count > 0)
            {
                for (int i = 0; i < data1.Rows.Count; i++)
                {
                    date_ = DateTime.Parse(data1.Rows[i][1].ToString());
                    if (date_ >= stardate && date_ <= enddate)
                        refreshcalendarformat(date_,1);
                }
            }
        }

        private void tbnamfil_TextChanged(object sender, EventArgs e)
        {
            getholiday();
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
        private void FormatDates(Pabo.Calendar.MonthCalendar cal, DateTime ngayformat,int ishightlight)
        {
            DateItem d = new DateItem();
            d.Date = ngayformat;
            if(ishightlight == 1)
                d.BackColor1 = Color.Yellow;
            else
                d.BackColor1 = Color.White;

            //d.ImageListIndex = 3;
            //d.Text = "Help";
            cal.AddDateInfo(d);
        }
        void refreshcalendarformat(DateTime ngaycheck, int ishightlight)
        {
            foreach(Pabo.Calendar.MonthCalendar c in flowpal.Controls)
            {
                if(c.Name.Contains(ngaycheck.Month.ToString()))
                {
                    FormatDates(c, ngaycheck, ishightlight);
                }
            }
        }
    }
}
