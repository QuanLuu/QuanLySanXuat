namespace Chuong_Trinh_Quan_Ly_San_Xuat
{
    partial class FrmBaocao
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnInpass = new System.Windows.Forms.Button();
            this.btninCTSX = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Info;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Fuchsia;
            this.button2.Location = new System.Drawing.Point(22, 114);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(253, 35);
            this.button2.TabIndex = 4;
            this.button2.Text = "Báo cáo .......";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Info;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Fuchsia;
            this.button1.Location = new System.Drawing.Point(22, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(253, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "Nhập - Xuất - Tồn";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnInpass
            // 
            this.btnInpass.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnInpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInpass.ForeColor = System.Drawing.Color.Yellow;
            this.btnInpass.Location = new System.Drawing.Point(310, 114);
            this.btnInpass.Name = "btnInpass";
            this.btnInpass.Size = new System.Drawing.Size(253, 35);
            this.btnInpass.TabIndex = 6;
            this.btnInpass.Text = "PASS";
            this.btnInpass.UseVisualStyleBackColor = false;
            // 
            // btninCTSX
            // 
            this.btninCTSX.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btninCTSX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btninCTSX.ForeColor = System.Drawing.Color.Yellow;
            this.btninCTSX.Location = new System.Drawing.Point(310, 56);
            this.btninCTSX.Name = "btninCTSX";
            this.btninCTSX.Size = new System.Drawing.Size(253, 35);
            this.btninCTSX.TabIndex = 5;
            this.btninCTSX.Text = "Chỉ thị sản xuất";
            this.btninCTSX.UseVisualStyleBackColor = false;
            this.btninCTSX.Click += new System.EventHandler(this.btninCTSX_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(104, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Báo Cáo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(408, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "In ấn";
            // 
            // FrmBaocao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(588, 349);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInpass);
            this.Controls.Add(this.btninCTSX);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBaocao";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnInpass;
        private System.Windows.Forms.Button btninCTSX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}