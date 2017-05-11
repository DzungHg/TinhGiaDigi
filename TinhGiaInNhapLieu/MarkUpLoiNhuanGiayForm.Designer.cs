namespace TinhGiaInNhapLieu
{
    partial class MarkUpLoiNhuanGiayForm
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
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.cboHangKH = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTiLeLN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDanhMucGiay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLuu
            // 
            this.btnLuu.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLuu.Location = new System.Drawing.Point(178, 136);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Location = new System.Drawing.Point(74, 136);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // cboHangKH
            // 
            this.cboHangKH.FormattingEnabled = true;
            this.cboHangKH.Location = new System.Drawing.Point(132, 61);
            this.cboHangKH.Name = "cboHangKH";
            this.cboHangKH.Size = new System.Drawing.Size(121, 21);
            this.cboHangKH.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Hạng Khách hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mức LN/DThu (%)";
            // 
            // txtTiLeLN
            // 
            this.txtTiLeLN.Location = new System.Drawing.Point(132, 90);
            this.txtTiLeLN.Name = "txtTiLeLN";
            this.txtTiLeLN.Size = new System.Drawing.Size(55, 20);
            this.txtTiLeLN.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Danh mục giấy";
            // 
            // txtDanhMucGiay
            // 
            this.txtDanhMucGiay.Location = new System.Drawing.Point(132, 31);
            this.txtDanhMucGiay.Name = "txtDanhMucGiay";
            this.txtDanhMucGiay.ReadOnly = true;
            this.txtDanhMucGiay.Size = new System.Drawing.Size(121, 20);
            this.txtDanhMucGiay.TabIndex = 11;
            // 
            // MarkUpLoiNhuanGiayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 170);
            this.Controls.Add(this.txtDanhMucGiay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTiLeLN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboHangKH);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Name = "MarkUpLoiNhuanGiayForm";
            this.Text = "MarkUpLoiNhuanGiayForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MarkUpLoiNhuanGiayForm_FormClosing);
            this.Load += new System.EventHandler(this.MarkUpLoiNhuanGiayForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.ComboBox cboHangKH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTiLeLN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDanhMucGiay;
    }
}