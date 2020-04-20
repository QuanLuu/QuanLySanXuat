namespace Chuong_Trinh_Quan_Ly_San_Xuat
{
    partial class CalendarHolidays
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowpal = new System.Windows.Forms.FlowLayoutPanel();
            this.panelholiday = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelentry = new System.Windows.Forms.Panel();
            this.dtgholiday = new System.Windows.Forms.DataGridView();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbdesc = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.tbnamfil = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelholiday.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelentry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgholiday)).BeginInit();
            this.SuspendLayout();
            // 
            // flowpal
            // 
            this.flowpal.AutoScroll = true;
            this.flowpal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowpal.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowpal.Location = new System.Drawing.Point(0, 0);
            this.flowpal.Name = "flowpal";
            this.flowpal.Size = new System.Drawing.Size(666, 766);
            this.flowpal.TabIndex = 0;
            // 
            // panelholiday
            // 
            this.panelholiday.AutoSize = true;
            this.panelholiday.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelholiday.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelholiday.Controls.Add(this.dtgholiday);
            this.panelholiday.Controls.Add(this.panelentry);
            this.panelholiday.Controls.Add(this.panel3);
            this.panelholiday.Controls.Add(this.panel2);
            this.panelholiday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelholiday.Location = new System.Drawing.Point(666, 0);
            this.panelholiday.Name = "panelholiday";
            this.panelholiday.Size = new System.Drawing.Size(432, 766);
            this.panelholiday.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tbnamfil);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(428, 38);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnEdit);
            this.panel3.Controls.Add(this.btnNew);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(428, 37);
            this.panel3.TabIndex = 1;
            // 
            // panelentry
            // 
            this.panelentry.AutoSize = true;
            this.panelentry.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelentry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelentry.Controls.Add(this.tbdesc);
            this.panelentry.Controls.Add(this.label2);
            this.panelentry.Controls.Add(this.label1);
            this.panelentry.Controls.Add(this.dtpdate);
            this.panelentry.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelentry.Location = new System.Drawing.Point(0, 75);
            this.panelentry.Name = "panelentry";
            this.panelentry.Size = new System.Drawing.Size(428, 31);
            this.panelentry.TabIndex = 2;
            this.panelentry.Visible = false;
            // 
            // dtgholiday
            // 
            this.dtgholiday.AllowUserToResizeRows = false;
            this.dtgholiday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgholiday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgholiday.Location = new System.Drawing.Point(0, 106);
            this.dtgholiday.Name = "dtgholiday";
            this.dtgholiday.ReadOnly = true;
            this.dtgholiday.RowHeadersVisible = false;
            this.dtgholiday.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgholiday.Size = new System.Drawing.Size(428, 656);
            this.dtgholiday.TabIndex = 3;
            // 
            // dtpdate
            // 
            this.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdate.Location = new System.Drawing.Point(36, 6);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(98, 20);
            this.dtpdate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mô tả";
            // 
            // tbdesc
            // 
            this.tbdesc.Location = new System.Drawing.Point(173, 6);
            this.tbdesc.Name = "tbdesc";
            this.tbdesc.Size = new System.Drawing.Size(198, 20);
            this.tbdesc.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(206, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(51, 21);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(155, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 21);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(104, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(51, 21);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Location = new System.Drawing.Point(53, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(51, 21);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(2, 6);
            this.btnNew.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(51, 21);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNewDM_Click);
            // 
            // tbnamfil
            // 
            this.tbnamfil.Location = new System.Drawing.Point(36, 11);
            this.tbnamfil.Name = "tbnamfil";
            this.tbnamfil.Size = new System.Drawing.Size(81, 20);
            this.tbnamfil.TabIndex = 5;
            this.tbnamfil.TextChanged += new System.EventHandler(this.tbnamfil_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Năm";
            // 
            // CalendarHolidays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1098, 766);
            this.Controls.Add(this.panelholiday);
            this.Controls.Add(this.flowpal);
            this.MaximizeBox = false;
            this.Name = "CalendarHolidays";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CalendarHolidays";
            this.panelholiday.ResumeLayout(false);
            this.panelholiday.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panelentry.ResumeLayout(false);
            this.panelentry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgholiday)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowpal;
        private System.Windows.Forms.Panel panelholiday;
        private System.Windows.Forms.DataGridView dtgholiday;
        private System.Windows.Forms.Panel panelentry;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbdesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox tbnamfil;
        private System.Windows.Forms.Label label3;
    }
}