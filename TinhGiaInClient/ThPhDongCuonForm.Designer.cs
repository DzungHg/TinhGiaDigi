namespace TinhGiaInClient
{
    partial class ThPhDongCuonForm
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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDonViTinh = new System.Windows.Forms.TextBox();
            this.txtThongTinHoTro = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(208, 230);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Nhận";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(94, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblGiaTB
            // 
            this.lblGiaTB.AutoSize = true;
            this.lblGiaTB.Location = new System.Drawing.Point(286, 172);
            this.lblGiaTB.Name = "lblGiaTB";
            this.lblGiaTB.Size = new System.Drawing.Size(60, 13);
            this.lblGiaTB.TabIndex = 101;
            this.lblGiaTB.Text = "Giá TB/ĐV";
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Location = new System.Drawing.Point(180, 172);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(58, 13);
            this.lblThanhTien.TabIndex = 100;
            this.lblThanhTien.Text = "Thành tiền";
            // 
            // lblCanPhu_DonViTinh
            // 
            this.lblCanPhu_DonViTinh.AutoSize = true;
            this.lblCanPhu_DonViTinh.Location = new System.Drawing.Point(288, 115);
            this.lblCanPhu_DonViTinh.Name = "lblCanPhu_DonViTinh";
            this.lblCanPhu_DonViTinh.Size = new System.Drawing.Size(60, 13);
            this.lblCanPhu_DonViTinh.TabIndex = 99;
            this.lblCanPhu_DonViTinh.Text = "Đơn vị tính";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 98;
            this.label2.Text = "Nhập số lượng";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(183, 131);
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
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Location = new System.Drawing.Point(156, 9);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(73, 13);
            this.lblTieuDe.TabIndex = 102;
            this.lblTieuDe.Text = "ĐÓNG CUỐN";
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
            this.txtDonViTinh.Location = new System.Drawing.Point(289, 131);
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.ReadOnly = true;
            this.txtDonViTinh.Size = new System.Drawing.Size(59, 20);
            this.txtDonViTinh.TabIndex = 2;
            // 
            // txtThongTinHoTro
            // 
            this.txtThongTinHoTro.Location = new System.Drawing.Point(183, 55);
            this.txtThongTinHoTro.Multiline = true;
            this.txtThongTinHoTro.Name = "txtThongTinHoTro";
            this.txtThongTinHoTro.ReadOnly = true;
            this.txtThongTinHoTro.Size = new System.Drawing.Size(204, 49);
            this.txtThongTinHoTro.TabIndex = 105;
            // 
            // ThPhDongCuonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 265);
            this.Controls.Add(this.txtThongTinHoTro);
            this.Controls.Add(this.txtDonViTinh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblGiaTB);
            this.Controls.Add(this.lblThanhTien);
            this.Controls.Add(this.lblCanPhu_DonViTinh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.lbxThanhPham);
            this.Name = "ThPhDongCuonForm";
            this.Text = "Đóng cuốn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThPhDongCuonForm_FormClosing);
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
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDonViTinh;
        private System.Windows.Forms.TextBox txtThongTinHoTro;
    }
}