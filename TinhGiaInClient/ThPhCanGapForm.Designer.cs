namespace TinhGiaInClient
{
    partial class ThPhCanGapForm
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
            this.lbxThanhPham = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDonViTinh = new System.Windows.Forms.TextBox();
            this.txtThongTinBoSung = new System.Windows.Forms.TextBox();
            this.txtSoDuongCan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTinhToan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(242, 230);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Nhận";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(128, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblGiaTB
            // 
            this.lblGiaTB.AutoSize = true;
            this.lblGiaTB.Location = new System.Drawing.Point(319, 179);
            this.lblGiaTB.Name = "lblGiaTB";
            this.lblGiaTB.Size = new System.Drawing.Size(60, 13);
            this.lblGiaTB.TabIndex = 101;
            this.lblGiaTB.Text = "Giá TB/ĐV";
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Location = new System.Drawing.Point(182, 179);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(58, 13);
            this.lblThanhTien.TabIndex = 100;
            this.lblThanhTien.Text = "Thành tiền";
            // 
            // lblCanPhu_DonViTinh
            // 
            this.lblCanPhu_DonViTinh.AutoSize = true;
            this.lblCanPhu_DonViTinh.Location = new System.Drawing.Point(282, 100);
            this.lblCanPhu_DonViTinh.Name = "lblCanPhu_DonViTinh";
            this.lblCanPhu_DonViTinh.Size = new System.Drawing.Size(60, 13);
            this.lblCanPhu_DonViTinh.TabIndex = 99;
            this.lblCanPhu_DonViTinh.Text = "Đơn vị tính";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 98;
            this.label2.Text = "Nhập số lượng";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(179, 116);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(100, 20);
            this.txtSoLuong.TabIndex = 1;
            // 
            // lbxThanhPham
            // 
            this.lbxThanhPham.FormattingEnabled = true;
            this.lbxThanhPham.Location = new System.Drawing.Point(24, 55);
            this.lbxThanhPham.Name = "lbxThanhPham";
            this.lbxThanhPham.Size = new System.Drawing.Size(145, 147);
            this.lbxThanhPham.TabIndex = 0;
            this.lbxThanhPham.SelectedIndexChanged += new System.EventHandler(this.ListBoxes_SelectedIndex_Changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 102;
            this.label1.Text = "CẤN, CẤN GẤP, RĂNG CƯA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 103;
            this.label3.Text = "Danh sách ";
            // 
            // txtDonViTinh
            // 
            this.txtDonViTinh.Location = new System.Drawing.Point(285, 116);
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.ReadOnly = true;
            this.txtDonViTinh.Size = new System.Drawing.Size(59, 20);
            this.txtDonViTinh.TabIndex = 2;
            // 
            // txtThongTinBoSung
            // 
            this.txtThongTinBoSung.Location = new System.Drawing.Point(175, 55);
            this.txtThongTinBoSung.Multiline = true;
            this.txtThongTinBoSung.Name = "txtThongTinBoSung";
            this.txtThongTinBoSung.ReadOnly = true;
            this.txtThongTinBoSung.Size = new System.Drawing.Size(204, 37);
            this.txtThongTinBoSung.TabIndex = 105;
            this.txtThongTinBoSung.TextChanged += new System.EventHandler(this.txtThongTinBoSung_TextChanged);
            // 
            // txtSoDuongCan
            // 
            this.txtSoDuongCan.Location = new System.Drawing.Point(246, 142);
            this.txtSoDuongCan.Name = "txtSoDuongCan";
            this.txtSoDuongCan.Size = new System.Drawing.Size(37, 20);
            this.txtSoDuongCan.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 107;
            this.label4.Text = "Số đường";
            // 
            // btnTinhToan
            // 
            this.btnTinhToan.Location = new System.Drawing.Point(304, 139);
            this.btnTinhToan.Name = "btnTinhToan";
            this.btnTinhToan.Size = new System.Drawing.Size(75, 23);
            this.btnTinhToan.TabIndex = 3;
            this.btnTinhToan.Text = "Tính";
            this.btnTinhToan.UseVisualStyleBackColor = true;
            this.btnTinhToan.Click += new System.EventHandler(this.btnTinhToan_Click);
            // 
            // ThPhCanGapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 265);
            this.Controls.Add(this.btnTinhToan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSoDuongCan);
            this.Controls.Add(this.txtThongTinBoSung);
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
            this.Controls.Add(this.lbxThanhPham);
            this.Name = "ThPhCanGapForm";
            this.Text = "Cấn Gấp Răng cưa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThPhCanGapForm_FormClosing);
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
        private System.Windows.Forms.ListBox lbxThanhPham;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDonViTinh;
        private System.Windows.Forms.TextBox txtThongTinBoSung;
        private System.Windows.Forms.TextBox txtSoDuongCan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTinhToan;
    }
}