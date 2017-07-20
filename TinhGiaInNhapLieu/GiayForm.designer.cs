namespace TinhGiaInNhapLieu
{
    partial class GiayForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblPaperId = new System.Windows.Forms.Label();
            this.txtTenGiay = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaGiayNCC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChieuNgan = new System.Windows.Forms.TextBox();
            this.txtChieuDai = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGiaMua = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDinhLuong = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtThuTu = new System.Windows.Forms.TextBox();
            this.lblTieuDeForm = new System.Windows.Forms.Label();
            this.txtTenNCC = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMaGiayTuDat = new System.Windows.Forms.TextBox();
            this.txtDienGiai = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.chkTonKho = new System.Windows.Forms.CheckBox();
            this.chkKhongCon = new System.Windows.Forms.CheckBox();
            this.txtKhoGiay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDanhMucGiay = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTenGiayMoRong = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(188, 295);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(280, 295);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPaperId
            // 
            this.lblPaperId.AutoSize = true;
            this.lblPaperId.Location = new System.Drawing.Point(264, 222);
            this.lblPaperId.Name = "lblPaperId";
            this.lblPaperId.Size = new System.Drawing.Size(35, 13);
            this.lblPaperId.TabIndex = 7;
            this.lblPaperId.Text = "label1";
            // 
            // txtTenGiay
            // 
            this.txtTenGiay.Location = new System.Drawing.Point(358, 38);
            this.txtTenGiay.Name = "txtTenGiay";
            this.txtTenGiay.Size = new System.Drawing.Size(195, 20);
            this.txtTenGiay.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(301, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tên giấy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Mã giấy của NCC";
            // 
            // txtMaGiayNCC
            // 
            this.txtMaGiayNCC.Location = new System.Drawing.Point(107, 89);
            this.txtMaGiayNCC.Name = "txtMaGiayNCC";
            this.txtMaGiayNCC.Size = new System.Drawing.Size(158, 20);
            this.txtMaGiayNCC.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Kích thước";
            // 
            // txtChieuNgan
            // 
            this.txtChieuNgan.Location = new System.Drawing.Point(358, 89);
            this.txtChieuNgan.Name = "txtChieuNgan";
            this.txtChieuNgan.Size = new System.Drawing.Size(40, 20);
            this.txtChieuNgan.TabIndex = 6;
            this.txtChieuNgan.TextChanged += new System.EventHandler(this.txtShortDim_TextChanged);
            // 
            // txtChieuDai
            // 
            this.txtChieuDai.Location = new System.Drawing.Point(424, 89);
            this.txtChieuDai.Name = "txtChieuDai";
            this.txtChieuDai.Size = new System.Drawing.Size(40, 20);
            this.txtChieuDai.TabIndex = 7;
            this.txtChieuDai.TextChanged += new System.EventHandler(this.txtShortDim_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(405, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "x";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Giá tồn kho";
            // 
            // txtGiaMua
            // 
            this.txtGiaMua.Location = new System.Drawing.Point(104, 219);
            this.txtGiaMua.Name = "txtGiaMua";
            this.txtGiaMua.Size = new System.Drawing.Size(79, 20);
            this.txtGiaMua.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(189, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "đ/tờ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Danh mục";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(291, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Định lượng";
            // 
            // txtDinhLuong
            // 
            this.txtDinhLuong.Location = new System.Drawing.Point(358, 64);
            this.txtDinhLuong.Name = "txtDinhLuong";
            this.txtDinhLuong.Size = new System.Drawing.Size(40, 20);
            this.txtDinhLuong.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(405, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "g/m2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(468, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "(cm) Nhỏ x Lớn";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 248);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Thứ tự";
            // 
            // txtThuTu
            // 
            this.txtThuTu.Location = new System.Drawing.Point(104, 245);
            this.txtThuTu.Name = "txtThuTu";
            this.txtThuTu.Size = new System.Drawing.Size(35, 20);
            this.txtThuTu.TabIndex = 12;
            // 
            // lblTieuDeForm
            // 
            this.lblTieuDeForm.AutoSize = true;
            this.lblTieuDeForm.Location = new System.Drawing.Point(104, 9);
            this.lblTieuDeForm.Name = "lblTieuDeForm";
            this.lblTieuDeForm.Size = new System.Drawing.Size(35, 13);
            this.lblTieuDeForm.TabIndex = 32;
            this.lblTieuDeForm.Text = "label1";
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Location = new System.Drawing.Point(107, 36);
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.ReadOnly = true;
            this.txtTenNCC.Size = new System.Drawing.Size(158, 20);
            this.txtTenNCC.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 13);
            this.label14.TabIndex = 35;
            this.label14.Text = "Nhà cung cấp";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 115);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 37;
            this.label15.Text = "Mã tự đặt";
            // 
            // txtMaGiayTuDat
            // 
            this.txtMaGiayTuDat.Location = new System.Drawing.Point(107, 115);
            this.txtMaGiayTuDat.Name = "txtMaGiayTuDat";
            this.txtMaGiayTuDat.Size = new System.Drawing.Size(158, 20);
            this.txtMaGiayTuDat.TabIndex = 3;
            // 
            // txtDienGiai
            // 
            this.txtDienGiai.Location = new System.Drawing.Point(104, 170);
            this.txtDienGiai.Multiline = true;
            this.txtDienGiai.Name = "txtDienGiai";
            this.txtDienGiai.Size = new System.Drawing.Size(195, 43);
            this.txtDienGiai.TabIndex = 10;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 173);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 13);
            this.label16.TabIndex = 39;
            this.label16.Text = "Diễn giải";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // chkTonKho
            // 
            this.chkTonKho.AutoSize = true;
            this.chkTonKho.Location = new System.Drawing.Point(369, 218);
            this.chkTonKho.Name = "chkTonKho";
            this.chkTonKho.Size = new System.Drawing.Size(78, 17);
            this.chkTonKho.TabIndex = 12;
            this.chkTonKho.Text = "Có tồn kho";
            this.chkTonKho.UseVisualStyleBackColor = true;
            // 
            // chkKhongCon
            // 
            this.chkKhongCon.AutoSize = true;
            this.chkKhongCon.Location = new System.Drawing.Point(369, 244);
            this.chkKhongCon.Name = "chkKhongCon";
            this.chkKhongCon.Size = new System.Drawing.Size(78, 17);
            this.chkKhongCon.TabIndex = 13;
            this.chkKhongCon.Text = "Không còn";
            this.chkKhongCon.UseVisualStyleBackColor = true;
            // 
            // txtKhoGiay
            // 
            this.txtKhoGiay.Location = new System.Drawing.Point(358, 114);
            this.txtKhoGiay.Name = "txtKhoGiay";
            this.txtKhoGiay.Size = new System.Drawing.Size(79, 20);
            this.txtKhoGiay.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(289, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Kích thước";
            // 
            // cboDanhMucGiay
            // 
            this.cboDanhMucGiay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMucGiay.FormattingEnabled = true;
            this.cboDanhMucGiay.Location = new System.Drawing.Point(107, 62);
            this.cboDanhMucGiay.Name = "cboDanhMucGiay";
            this.cboDanhMucGiay.Size = new System.Drawing.Size(156, 21);
            this.cboDanhMucGiay.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(282, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 45;
            this.label12.Text = "Tên mở rộng";
            // 
            // txtTenGiayMoRong
            // 
            this.txtTenGiayMoRong.Location = new System.Drawing.Point(358, 140);
            this.txtTenGiayMoRong.Name = "txtTenGiayMoRong";
            this.txtTenGiayMoRong.Size = new System.Drawing.Size(195, 20);
            this.txtTenGiayMoRong.TabIndex = 9;
            // 
            // GiayForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 344);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTenGiayMoRong);
            this.Controls.Add(this.cboDanhMucGiay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtKhoGiay);
            this.Controls.Add(this.chkKhongCon);
            this.Controls.Add(this.chkTonKho);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtDienGiai);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtMaGiayTuDat);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtTenNCC);
            this.Controls.Add(this.lblTieuDeForm);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtThuTu);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDinhLuong);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtGiaMua);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtChieuDai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtChieuNgan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaGiayNCC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTenGiay);
            this.Controls.Add(this.lblPaperId);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "GiayForm";
            this.Text = "PaperCateForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GiayForm_FormClosing);
            this.Load += new System.EventHandler(this.PaperCateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblPaperId;
        private System.Windows.Forms.TextBox txtTenGiay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaGiayNCC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtChieuNgan;
        private System.Windows.Forms.TextBox txtChieuDai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGiaMua;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDinhLuong;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtThuTu;
        private System.Windows.Forms.Label lblTieuDeForm;
        private System.Windows.Forms.TextBox txtTenNCC;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMaGiayTuDat;
        private System.Windows.Forms.TextBox txtDienGiai;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox chkTonKho;
        private System.Windows.Forms.CheckBox chkKhongCon;
        private System.Windows.Forms.TextBox txtKhoGiay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDanhMucGiay;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTenGiayMoRong;

    }
}