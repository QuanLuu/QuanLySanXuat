namespace Chuong_Trinh_Quan_Ly_San_Xuat
{
    partial class frmDoiMK
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
            this.tbTenDN = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbpassmoi = new System.Windows.Forms.TextBox();
            this.btnDoi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbTenDN
            // 
            this.tbTenDN.Location = new System.Drawing.Point(90, 12);
            this.tbTenDN.Name = "tbTenDN";
            this.tbTenDN.PasswordChar = '*';
            this.tbTenDN.Size = new System.Drawing.Size(98, 20);
            this.tbTenDN.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Mật Khẩu Cũ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Tên Đăng Nhập";
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(90, 38);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '*';
            this.tbPass.Size = new System.Drawing.Size(98, 20);
            this.tbPass.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mật Khẩu Mới";
            // 
            // tbpassmoi
            // 
            this.tbpassmoi.Location = new System.Drawing.Point(90, 64);
            this.tbpassmoi.Name = "tbpassmoi";
            this.tbpassmoi.PasswordChar = '*';
            this.tbpassmoi.Size = new System.Drawing.Size(98, 20);
            this.tbpassmoi.TabIndex = 9;
            // 
            // btnDoi
            // 
            this.btnDoi.Location = new System.Drawing.Point(90, 100);
            this.btnDoi.Name = "btnDoi";
            this.btnDoi.Size = new System.Drawing.Size(75, 23);
            this.btnDoi.TabIndex = 11;
            this.btnDoi.Text = "Đổi";
            this.btnDoi.UseVisualStyleBackColor = true;
            this.btnDoi.Click += new System.EventHandler(this.btnDoi_Click);
            // 
            // frmDoiMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 135);
            this.Controls.Add(this.btnDoi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbpassmoi);
            this.Controls.Add(this.tbTenDN);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbPass);
            this.MaximizeBox = false;
            this.Name = "frmDoiMK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi MK";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbTenDN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbpassmoi;
        private System.Windows.Forms.Button btnDoi;
    }
}