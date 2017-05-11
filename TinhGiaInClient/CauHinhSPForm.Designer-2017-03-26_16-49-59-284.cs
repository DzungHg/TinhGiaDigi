namespace TinhGiaInClient
{
    partial class CauHinhSPForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnThongTinGiay = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.txtKhoCatRong = new System.Windows.Forms.TextBox();
            this.txtKhoCatCao = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.btnReverseProdSize = new System.Windows.Forms.Button();
            this.txtTenSanPham = new System.Windows.Forms.TextBox();
            this.btnGetProdTemplate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTranLeTren = new System.Windows.Forms.TextBox();
            this.txtTranLeNgoai = new System.Windows.Forms.TextBox();
            this.txtTranLeTrong = new System.Windows.Forms.TextBox();
            this.txtTranLeDuoi = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblKhoGomLe = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLeDuoi = new System.Windows.Forms.TextBox();
            this.txtLeTrong = new System.Windows.Forms.TextBox();
            this.txtLeNgoai = new System.Windows.Forms.TextBox();
            this.txtLeTren = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLeBangTranLe = new System.Windows.Forms.Button();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDienGiaiBaiIn = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.lstMayIn = new System.Windows.Forms.ListView();
            this.lblMayInChon = new System.Windows.Forms.Label();
            this.txtMayInChon = new System.Windows.Forms.TextBox();
            this.lblDonViTinh = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 201;
            this.label1.Text = "Thông tin bài in";
            // 
            // btnThongTinGiay
            // 
            this.btnThongTinGiay.Location = new System.Drawing.Point(6, 252);
            this.btnThongTinGiay.Name = "btnThongTinGiay";
            this.btnThongTinGiay.Size = new System.Drawing.Size(55, 23);
            this.btnThongTinGiay.TabIndex = 2;
            this.btnThongTinGiay.Text = "Về Giấy";
            this.btnThongTinGiay.UseVisualStyleBackColor = true;
            this.btnThongTinGiay.Click += new System.EventHandler(this.btnThongTinGiay_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(480, 202);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(107, 13);
            this.label25.TabIndex = 195;
            this.label25.Text = "Rộng     x    Cao (cm)";
            this.label25.Click += new System.EventHandler(this.label25_Click);
            // 
            // txtKhoCatRong
            // 
            this.txtKhoCatRong.Location = new System.Drawing.Point(472, 219);
            this.txtKhoCatRong.Name = "txtKhoCatRong";
            this.txtKhoCatRong.Size = new System.Drawing.Size(44, 20);
            this.txtKhoCatRong.TabIndex = 5;
            this.txtKhoCatRong.TextChanged += new System.EventHandler(this.txtProd_CutWidth_TextChanged);
            // 
            // txtKhoCatCao
            // 
            this.txtKhoCatCao.Location = new System.Drawing.Point(530, 219);
            this.txtKhoCatCao.Name = "txtKhoCatCao";
            this.txtKhoCatCao.Size = new System.Drawing.Size(44, 20);
            this.txtKhoCatCao.TabIndex = 6;
            this.txtKhoCatCao.TextChanged += new System.EventHandler(this.txtProd_CutHeight_TextChanged);
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(385, 222);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(84, 13);
            this.label58.TabIndex = 194;
            this.label58.Text = "khổ thành phẩm";
            this.label58.Click += new System.EventHandler(this.label58_Click);
            // 
            // btnReverseProdSize
            // 
            this.btnReverseProdSize.Location = new System.Drawing.Point(582, 217);
            this.btnReverseProdSize.Name = "btnReverseProdSize";
            this.btnReverseProdSize.Size = new System.Drawing.Size(41, 23);
            this.btnReverseProdSize.TabIndex = 7;
            this.btnReverseProdSize.Text = "Xoay";
            this.btnReverseProdSize.UseVisualStyleBackColor = true;
            this.btnReverseProdSize.Click += new System.EventHandler(this.btnReverseProdSize_Click);
            // 
            // txtTenSanPham
            // 
            this.txtTenSanPham.Location = new System.Drawing.Point(478, 173);
            this.txtTenSanPham.Name = "txtTenSanPham";
            this.txtTenSanPham.ReadOnly = true;
            this.txtTenSanPham.Size = new System.Drawing.Size(131, 20);
            this.txtTenSanPham.TabIndex = 4;
            // 
            // btnGetProdTemplate
            // 
            this.btnGetProdTemplate.Location = new System.Drawing.Point(385, 170);
            this.btnGetProdTemplate.Name = "btnGetProdTemplate";
            this.btnGetProdTemplate.Size = new System.Drawing.Size(88, 23);
            this.btnGetProdTemplate.TabIndex = 3;
            this.btnGetProdTemplate.Text = "Lấy Kích thước";
            this.btnGetProdTemplate.UseVisualStyleBackColor = true;
            this.btnGetProdTemplate.Click += new System.EventHandler(this.btnGetProdTemplate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 202;
            this.label2.Text = "TRIỂN KHAI SẢN PHẨM TỜ";
            // 
            // txtTranLeTren
            // 
            this.txtTranLeTren.Location = new System.Drawing.Point(508, 245);
            this.txtTranLeTren.Name = "txtTranLeTren";
            this.txtTranLeTren.Size = new System.Drawing.Size(30, 20);
            this.txtTranLeTren.TabIndex = 8;
            this.txtTranLeTren.TextChanged += new System.EventHandler(this.txtTranLeTren_TextChanged);
            // 
            // txtTranLeNgoai
            // 
            this.txtTranLeNgoai.Location = new System.Drawing.Point(544, 265);
            this.txtTranLeNgoai.Name = "txtTranLeNgoai";
            this.txtTranLeNgoai.Size = new System.Drawing.Size(30, 20);
            this.txtTranLeNgoai.TabIndex = 11;
            this.txtTranLeNgoai.TextChanged += new System.EventHandler(this.txtTranLeNgoai_TextChanged);
            // 
            // txtTranLeTrong
            // 
            this.txtTranLeTrong.Location = new System.Drawing.Point(472, 264);
            this.txtTranLeTrong.Name = "txtTranLeTrong";
            this.txtTranLeTrong.Size = new System.Drawing.Size(30, 20);
            this.txtTranLeTrong.TabIndex = 10;
            this.txtTranLeTrong.TextChanged += new System.EventHandler(this.txtTranLeTrong_TextChanged);
            // 
            // txtTranLeDuoi
            // 
            this.txtTranLeDuoi.Location = new System.Drawing.Point(508, 287);
            this.txtTranLeDuoi.Name = "txtTranLeDuoi";
            this.txtTranLeDuoi.Size = new System.Drawing.Size(30, 20);
            this.txtTranLeDuoi.TabIndex = 9;
            this.txtTranLeDuoi.TextChanged += new System.EventHandler(this.txtTranLeDuoi_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(279, 361);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(385, 361);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "Nhận";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblKhoGomLe
            // 
            this.lblKhoGomLe.AutoSize = true;
            this.lblKhoGomLe.Location = new System.Drawing.Point(469, 319);
            this.lblKhoGomLe.Name = "lblKhoGomLe";
            this.lblKhoGomLe.Size = new System.Drawing.Size(50, 13);
            this.lblKhoGomLe.TabIndex = 210;
            this.lblKhoGomLe.Text = "R x C cm";
            this.lblKhoGomLe.Click += new System.EventHandler(this.lblKhoGomLe_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(385, 319);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 212;
            this.label5.Text = "Khổ gồm lề";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtLeDuoi
            // 
            this.txtLeDuoi.Location = new System.Drawing.Point(663, 287);
            this.txtLeDuoi.Name = "txtLeDuoi";
            this.txtLeDuoi.Size = new System.Drawing.Size(30, 20);
            this.txtLeDuoi.TabIndex = 14;
            this.txtLeDuoi.TextChanged += new System.EventHandler(this.txtLeDuoi_TextChanged);
            // 
            // txtLeTrong
            // 
            this.txtLeTrong.Location = new System.Drawing.Point(627, 265);
            this.txtLeTrong.Name = "txtLeTrong";
            this.txtLeTrong.Size = new System.Drawing.Size(30, 20);
            this.txtLeTrong.TabIndex = 15;
            this.txtLeTrong.TextChanged += new System.EventHandler(this.txtLeTrong_TextChanged);
            // 
            // txtLeNgoai
            // 
            this.txtLeNgoai.Location = new System.Drawing.Point(699, 265);
            this.txtLeNgoai.Name = "txtLeNgoai";
            this.txtLeNgoai.Size = new System.Drawing.Size(30, 20);
            this.txtLeNgoai.TabIndex = 16;
            this.txtLeNgoai.TextChanged += new System.EventHandler(this.txtLeNgoai_TextChanged);
            // 
            // txtLeTren
            // 
            this.txtLeTren.Location = new System.Drawing.Point(663, 245);
            this.txtLeTren.Name = "txtLeTren";
            this.txtLeTren.Size = new System.Drawing.Size(30, 20);
            this.txtLeTren.TabIndex = 13;
            this.txtLeTren.TextChanged += new System.EventHandler(this.txtLeTren_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(385, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 214;
            this.label3.Text = "Tràn lề";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(602, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 215;
            this.label4.Text = "Lề";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnLeBangTranLe
            // 
            this.btnLeBangTranLe.Location = new System.Drawing.Point(569, 291);
            this.btnLeBangTranLe.Name = "btnLeBangTranLe";
            this.btnLeBangTranLe.Size = new System.Drawing.Size(67, 23);
            this.btnLeBangTranLe.TabIndex = 217;
            this.btnLeBangTranLe.Text = "lề = tràn lề";
            this.btnLeBangTranLe.UseVisualStyleBackColor = true;
            this.btnLeBangTranLe.Click += new System.EventHandler(this.btnLeBangTranLe_Click);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(430, 53);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.ReadOnly = true;
            this.txtSoLuong.Size = new System.Drawing.Size(102, 20);
            this.txtSoLuong.TabIndex = 15;
            this.txtSoLuong.TextChanged += new System.EventHandler(this.txtSoLuong_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(375, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 219;
            this.label6.Text = "Số lượng";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtDienGiaiBaiIn
            // 
            this.txtDienGiaiBaiIn.Location = new System.Drawing.Point(84, 53);
            this.txtDienGiaiBaiIn.Multiline = true;
            this.txtDienGiaiBaiIn.Name = "txtDienGiaiBaiIn";
            this.txtDienGiaiBaiIn.ReadOnly = true;
            this.txtDienGiaiBaiIn.Size = new System.Drawing.Size(285, 29);
            this.txtDienGiaiBaiIn.TabIndex = 220;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstMayIn);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(6, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 158);
            this.groupBox1.TabIndex = 221;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin máy in các loại";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(78, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(96, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Konica, Recoh";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(195, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(53, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Offset";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 222;
            this.label8.Text = "Khổ máy in:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // lstMayIn
            // 
            this.lstMayIn.Location = new System.Drawing.Point(9, 55);
            this.lstMayIn.Name = "lstMayIn";
            this.lstMayIn.Size = new System.Drawing.Size(348, 97);
            this.lstMayIn.TabIndex = 223;
            this.lstMayIn.UseCompatibleStateImageBehavior = false;
            // 
            // lblMayInChon
            // 
            this.lblMayInChon.AutoSize = true;
            this.lblMayInChon.Location = new System.Drawing.Point(381, 88);
            this.lblMayInChon.Name = "lblMayInChon";
            this.lblMayInChon.Size = new System.Drawing.Size(65, 13);
            this.lblMayInChon.TabIndex = 222;
            this.lblMayInChon.Text = "Máy in chọn";
            // 
            // txtMayInChon
            // 
            this.txtMayInChon.Location = new System.Drawing.Point(385, 107);
            this.txtMayInChon.Multiline = true;
            this.txtMayInChon.Name = "txtMayInChon";
            this.txtMayInChon.ReadOnly = true;
            this.txtMayInChon.Size = new System.Drawing.Size(307, 57);
            this.txtMayInChon.TabIndex = 223;
            // 
            // lblDonViTinh
            // 
            this.lblDonViTinh.AutoSize = true;
            this.lblDonViTinh.Location = new System.Drawing.Point(541, 56);
            this.lblDonViTinh.Name = "lblDonViTinh";
            this.lblDonViTinh.Size = new System.Drawing.Size(60, 13);
            this.lblDonViTinh.TabIndex = 224;
            this.lblDonViTinh.Text = "Đơn vị tính";
            // 
            // CauHinhSPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 398);
            this.Controls.Add(this.lblDonViTinh);
            this.Controls.Add(this.txtMayInChon);
            this.Controls.Add(this.lblMayInChon);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtDienGiaiBaiIn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.btnLeBangTranLe);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLeDuoi);
            this.Controls.Add(this.txtLeTrong);
            this.Controls.Add(this.txtLeNgoai);
            this.Controls.Add(this.txtLeTren);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblKhoGomLe);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtTranLeDuoi);
            this.Controls.Add(this.txtTranLeTrong);
            this.Controls.Add(this.txtTranLeNgoai);
            this.Controls.Add(this.txtTranLeTren);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThongTinGiay);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.txtKhoCatRong);
            this.Controls.Add(this.txtKhoCatCao);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.btnReverseProdSize);
            this.Controls.Add(this.txtTenSanPham);
            this.Controls.Add(this.btnGetProdTemplate);
            this.Name = "CauHinhSPForm";
            this.Text = "TrienKhaiSanPhamForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrienKhaiCauHinhSPForm_FormClosing);
            this.Load += new System.EventHandler(this.TrienKhaiSanPhamForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThongTinGiay;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtKhoCatRong;
        private System.Windows.Forms.TextBox txtKhoCatCao;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Button btnReverseProdSize;
        private System.Windows.Forms.TextBox txtTenSanPham;
        private System.Windows.Forms.Button btnGetProdTemplate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTranLeTren;
        private System.Windows.Forms.TextBox txtTranLeNgoai;
        private System.Windows.Forms.TextBox txtTranLeTrong;
        private System.Windows.Forms.TextBox txtTranLeDuoi;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblKhoGomLe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLeDuoi;
        private System.Windows.Forms.TextBox txtLeTrong;
        private System.Windows.Forms.TextBox txtLeNgoai;
        private System.Windows.Forms.TextBox txtLeTren;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLeBangTranLe;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDienGiaiBaiIn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ListView lstMayIn;
        private System.Windows.Forms.Label lblMayInChon;
        private System.Windows.Forms.TextBox txtMayInChon;
        private System.Windows.Forms.Label lblDonViTinh;
    }
}