namespace TinhGiaInClient
{
    partial class ThPhEpKimForm
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblGiaTB = new System.Windows.Forms.Label();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.lblCanPhu_DonViTinh = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDonViTinh = new System.Windows.Forms.TextBox();
            this.cboEpKim = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstNhuEpKim = new System.Windows.Forms.ListView();
            this.txtRong = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCao = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtThongTinHoTro = new System.Windows.Forms.TextBox();
            this.btnTinhToan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(249, 255);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "Nhận";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(151, 255);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblGiaTB
            // 
            this.lblGiaTB.AutoSize = true;
            this.lblGiaTB.Location = new System.Drawing.Point(92, 222);
            this.lblGiaTB.Name = "lblGiaTB";
            this.lblGiaTB.Size = new System.Drawing.Size(13, 13);
            this.lblGiaTB.TabIndex = 101;
            this.lblGiaTB.Text = "0";
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Location = new System.Drawing.Point(92, 193);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(13, 13);
            this.lblThanhTien.TabIndex = 100;
            this.lblThanhTien.Text = "0";
            // 
            // lblCanPhu_DonViTinh
            // 
            this.lblCanPhu_DonViTinh.AutoSize = true;
            this.lblCanPhu_DonViTinh.Location = new System.Drawing.Point(14, 173);
            this.lblCanPhu_DonViTinh.Name = "lblCanPhu_DonViTinh";
            this.lblCanPhu_DonViTinh.Size = new System.Drawing.Size(60, 13);
            this.lblCanPhu_DonViTinh.TabIndex = 99;
            this.lblCanPhu_DonViTinh.Text = "Đơn vị tính";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 98;
            this.label2.Text = "Số lượng";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(95, 144);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(105, 20);
            this.txtSoLuong.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 102;
            this.label1.Text = "ÉP KIM";
            // 
            // txtDonViTinh
            // 
            this.txtDonViTinh.Location = new System.Drawing.Point(95, 170);
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.Size = new System.Drawing.Size(59, 20);
            this.txtDonViTinh.TabIndex = 6;
            // 
            // cboEpKim
            // 
            this.cboEpKim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEpKim.FormattingEnabled = true;
            this.cboEpKim.Location = new System.Drawing.Point(95, 76);
            this.cboEpKim.Name = "cboEpKim";
            this.cboEpKim.Size = new System.Drawing.Size(146, 21);
            this.cboEpKim.TabIndex = 2;
            this.cboEpKim.SelectedIndexChanged += new System.EventHandler(this.cboEpKim_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 103;
            this.label3.Text = "Ép kim";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(305, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 105;
            this.label4.Text = "Chọn nhũ";
            // 
            // lstNhuEpKim
            // 
            this.lstNhuEpKim.FullRowSelect = true;
            this.lstNhuEpKim.GridLines = true;
            this.lstNhuEpKim.Location = new System.Drawing.Point(249, 76);
            this.lstNhuEpKim.Name = "lstNhuEpKim";
            this.lstNhuEpKim.Size = new System.Drawing.Size(197, 159);
            this.lstNhuEpKim.TabIndex = 7;
            this.lstNhuEpKim.UseCompatibleStateImageBehavior = false;
            this.lstNhuEpKim.View = System.Windows.Forms.View.Details;
            this.lstNhuEpKim.SelectedIndexChanged += new System.EventHandler(this.lstNhuEpKim_SelectedIndexChanged);
            // 
            // txtRong
            // 
            this.txtRong.Location = new System.Drawing.Point(95, 117);
            this.txtRong.Name = "txtRong";
            this.txtRong.Size = new System.Drawing.Size(40, 20);
            this.txtRong.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 109;
            this.label6.Text = "Kích thước ép";
            // 
            // txtCao
            // 
            this.txtCao.Location = new System.Drawing.Point(160, 118);
            this.txtCao.Name = "txtCao";
            this.txtCao.Size = new System.Drawing.Size(40, 20);
            this.txtCao.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(140, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 111;
            this.label7.Text = "X";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(114, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 112;
            this.label8.Text = "Rộng x Cao (cm)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 113;
            this.label9.Text = "Thành tiền";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 222);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 114;
            this.label10.Text = "Giá TB";
            // 
            // txtThongTinHoTro
            // 
            this.txtThongTinHoTro.Location = new System.Drawing.Point(95, 33);
            this.txtThongTinHoTro.Multiline = true;
            this.txtThongTinHoTro.Name = "txtThongTinHoTro";
            this.txtThongTinHoTro.ReadOnly = true;
            this.txtThongTinHoTro.Size = new System.Drawing.Size(204, 37);
            this.txtThongTinHoTro.TabIndex = 1;
            // 
            // btnTinhToan
            // 
            this.btnTinhToan.Location = new System.Drawing.Point(168, 170);
            this.btnTinhToan.Name = "btnTinhToan";
            this.btnTinhToan.Size = new System.Drawing.Size(75, 23);
            this.btnTinhToan.TabIndex = 7;
            this.btnTinhToan.Text = "Tính";
            this.btnTinhToan.UseVisualStyleBackColor = true;
            this.btnTinhToan.Click += new System.EventHandler(this.btnTinhToan_Click);
            // 
            // ThPhEpKimForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 294);
            this.Controls.Add(this.btnTinhToan);
            this.Controls.Add(this.txtThongTinHoTro);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCao);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRong);
            this.Controls.Add(this.lstNhuEpKim);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboEpKim);
            this.Controls.Add(this.txtDonViTinh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblGiaTB);
            this.Controls.Add(this.lblThanhTien);
            this.Controls.Add(this.lblCanPhu_DonViTinh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSoLuong);
            this.Name = "ThPhEpKimForm";
            this.Text = "Ép kim";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThPhCanPhuForm_FormClosing);
            this.Load += new System.EventHandler(this.ThanhPhamForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblGiaTB;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.Label lblCanPhu_DonViTinh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDonViTinh;
        private System.Windows.Forms.ComboBox cboEpKim;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lstNhuEpKim;
        private System.Windows.Forms.TextBox txtRong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtThongTinHoTro;
        private System.Windows.Forms.Button btnTinhToan;
    }
}