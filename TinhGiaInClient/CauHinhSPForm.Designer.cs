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
            this.txtKhoCatRong = new System.Windows.Forms.TextBox();
            this.txtKhoCatCao = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.btnReverseProdSize = new System.Windows.Forms.Button();
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
            this.rdbKhongIn = new System.Windows.Forms.RadioButton();
            this.lstMayIn = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblMayInChon = new System.Windows.Forms.Label();
            this.txtMayInChon = new System.Windows.Forms.TextBox();
            this.rdbOffset = new System.Windows.Forms.RadioButton();
            this.rdbToner = new System.Windows.Forms.RadioButton();
            this.lblDonViTinh = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.btnSSanhInNhanhOffset = new System.Windows.Forms.Button();
            this.grbTinhThu = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.grbTinhThu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 201;
            this.label1.Text = "Thông tin bài in";
            // 
            // btnThongTinGiay
            // 
            this.btnThongTinGiay.Location = new System.Drawing.Point(619, 332);
            this.btnThongTinGiay.Name = "btnThongTinGiay";
            this.btnThongTinGiay.Size = new System.Drawing.Size(55, 23);
            this.btnThongTinGiay.TabIndex = 2;
            this.btnThongTinGiay.Text = "Về Giấy";
            this.btnThongTinGiay.UseVisualStyleBackColor = true;
            this.btnThongTinGiay.Click += new System.EventHandler(this.btnThongTinGiay_Click);
            // 
            // txtKhoCatRong
            // 
            this.txtKhoCatRong.Location = new System.Drawing.Point(112, 184);
            this.txtKhoCatRong.Name = "txtKhoCatRong";
            this.txtKhoCatRong.Size = new System.Drawing.Size(44, 20);
            this.txtKhoCatRong.TabIndex = 3;
            this.txtKhoCatRong.TextChanged += new System.EventHandler(this.txtProd_CutWidth_TextChanged);
            // 
            // txtKhoCatCao
            // 
            this.txtKhoCatCao.Location = new System.Drawing.Point(172, 185);
            this.txtKhoCatCao.Name = "txtKhoCatCao";
            this.txtKhoCatCao.Size = new System.Drawing.Size(44, 20);
            this.txtKhoCatCao.TabIndex = 4;
            this.txtKhoCatCao.TextChanged += new System.EventHandler(this.txtProd_CutHeight_TextChanged);
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(12, 209);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(97, 13);
            this.label58.TabIndex = 194;
            this.label58.Text = "hoặc nhập khổ cắt";
            this.label58.Click += new System.EventHandler(this.label58_Click);
            // 
            // btnReverseProdSize
            // 
            this.btnReverseProdSize.Location = new System.Drawing.Point(222, 182);
            this.btnReverseProdSize.Name = "btnReverseProdSize";
            this.btnReverseProdSize.Size = new System.Drawing.Size(41, 23);
            this.btnReverseProdSize.TabIndex = 5;
            this.btnReverseProdSize.Text = "Xoay";
            this.btnReverseProdSize.UseVisualStyleBackColor = true;
            this.btnReverseProdSize.Click += new System.EventHandler(this.btnReverseProdSize_Click);
            // 
            // btnGetProdTemplate
            // 
            this.btnGetProdTemplate.Location = new System.Drawing.Point(15, 182);
            this.btnGetProdTemplate.Name = "btnGetProdTemplate";
            this.btnGetProdTemplate.Size = new System.Drawing.Size(88, 23);
            this.btnGetProdTemplate.TabIndex = 2;
            this.btnGetProdTemplate.Text = "Lấy Kích thước";
            this.btnGetProdTemplate.UseVisualStyleBackColor = true;
            this.btnGetProdTemplate.Click += new System.EventHandler(this.btnGetProdTemplate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 13);
            this.label2.TabIndex = 202;
            this.label2.Text = "TRIỂN KHAI CẤU HÌNH SẢN PHẨM TỜ";
            // 
            // txtTranLeTren
            // 
            this.txtTranLeTren.Location = new System.Drawing.Point(134, 220);
            this.txtTranLeTren.Name = "txtTranLeTren";
            this.txtTranLeTren.Size = new System.Drawing.Size(30, 20);
            this.txtTranLeTren.TabIndex = 6;
            // 
            // txtTranLeNgoai
            // 
            this.txtTranLeNgoai.Location = new System.Drawing.Point(170, 240);
            this.txtTranLeNgoai.Name = "txtTranLeNgoai";
            this.txtTranLeNgoai.Size = new System.Drawing.Size(30, 20);
            this.txtTranLeNgoai.TabIndex = 9;
            // 
            // txtTranLeTrong
            // 
            this.txtTranLeTrong.Location = new System.Drawing.Point(98, 239);
            this.txtTranLeTrong.Name = "txtTranLeTrong";
            this.txtTranLeTrong.Size = new System.Drawing.Size(30, 20);
            this.txtTranLeTrong.TabIndex = 8;
            // 
            // txtTranLeDuoi
            // 
            this.txtTranLeDuoi.Location = new System.Drawing.Point(134, 262);
            this.txtTranLeDuoi.Name = "txtTranLeDuoi";
            this.txtTranLeDuoi.Size = new System.Drawing.Size(30, 20);
            this.txtTranLeDuoi.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(269, 396);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(375, 396);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 17;
            this.btnOK.Text = "Nhận";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblKhoGomLe
            // 
            this.lblKhoGomLe.AutoSize = true;
            this.lblKhoGomLe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhoGomLe.Location = new System.Drawing.Point(109, 295);
            this.lblKhoGomLe.Name = "lblKhoGomLe";
            this.lblKhoGomLe.Size = new System.Drawing.Size(68, 16);
            this.lblKhoGomLe.TabIndex = 210;
            this.lblKhoGomLe.Text = "R x C cm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 212;
            this.label5.Text = "Khổ gồm lề";
            // 
            // txtLeDuoi
            // 
            this.txtLeDuoi.Location = new System.Drawing.Point(289, 262);
            this.txtLeDuoi.Name = "txtLeDuoi";
            this.txtLeDuoi.Size = new System.Drawing.Size(30, 20);
            this.txtLeDuoi.TabIndex = 11;
            // 
            // txtLeTrong
            // 
            this.txtLeTrong.Location = new System.Drawing.Point(253, 240);
            this.txtLeTrong.Name = "txtLeTrong";
            this.txtLeTrong.Size = new System.Drawing.Size(30, 20);
            this.txtLeTrong.TabIndex = 12;
            // 
            // txtLeNgoai
            // 
            this.txtLeNgoai.Location = new System.Drawing.Point(325, 240);
            this.txtLeNgoai.Name = "txtLeNgoai";
            this.txtLeNgoai.Size = new System.Drawing.Size(30, 20);
            this.txtLeNgoai.TabIndex = 13;
            // 
            // txtLeTren
            // 
            this.txtLeTren.Location = new System.Drawing.Point(289, 220);
            this.txtLeTren.Name = "txtLeTren";
            this.txtLeTren.Size = new System.Drawing.Size(30, 20);
            this.txtLeTren.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 214;
            this.label3.Text = "Tràn lề";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 215;
            this.label4.Text = "Lề";
            // 
            // btnLeBangTranLe
            // 
            this.btnLeBangTranLe.Location = new System.Drawing.Point(196, 266);
            this.btnLeBangTranLe.Name = "btnLeBangTranLe";
            this.btnLeBangTranLe.Size = new System.Drawing.Size(67, 23);
            this.btnLeBangTranLe.TabIndex = 14;
            this.btnLeBangTranLe.Text = "lề = tràn lề";
            this.btnLeBangTranLe.UseVisualStyleBackColor = true;
            this.btnLeBangTranLe.Click += new System.EventHandler(this.btnLeBangTranLe_Click);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong.Location = new System.Drawing.Point(116, 134);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.ReadOnly = true;
            this.txtSoLuong.Size = new System.Drawing.Size(43, 20);
            this.txtSoLuong.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 219;
            this.label6.Text = "Số lượng";
            // 
            // txtDienGiaiBaiIn
            // 
            this.txtDienGiaiBaiIn.Location = new System.Drawing.Point(15, 62);
            this.txtDienGiaiBaiIn.Multiline = true;
            this.txtDienGiaiBaiIn.Name = "txtDienGiaiBaiIn";
            this.txtDienGiaiBaiIn.ReadOnly = true;
            this.txtDienGiaiBaiIn.Size = new System.Drawing.Size(329, 61);
            this.txtDienGiaiBaiIn.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbKhongIn);
            this.groupBox1.Controls.Add(this.lstMayIn);
            this.groupBox1.Controls.Add(this.lblMayInChon);
            this.groupBox1.Controls.Add(this.txtMayInChon);
            this.groupBox1.Controls.Add(this.rdbOffset);
            this.groupBox1.Controls.Add(this.rdbToner);
            this.groupBox1.Location = new System.Drawing.Point(385, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 297);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "B.3. Chọn PP In";
            // 
            // rdbKhongIn
            // 
            this.rdbKhongIn.AutoSize = true;
            this.rdbKhongIn.Location = new System.Drawing.Point(122, 23);
            this.rdbKhongIn.Name = "rdbKhongIn";
            this.rdbKhongIn.Size = new System.Drawing.Size(68, 17);
            this.rdbKhongIn.TabIndex = 4;
            this.rdbKhongIn.Text = "Không In";
            this.rdbKhongIn.UseVisualStyleBackColor = true;
            // 
            // lstMayIn
            // 
            this.lstMayIn.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lstMayIn.FullRowSelect = true;
            this.lstMayIn.GridLines = true;
            this.lstMayIn.Location = new System.Drawing.Point(6, 46);
            this.lstMayIn.MultiSelect = false;
            this.lstMayIn.Name = "lstMayIn";
            this.lstMayIn.Size = new System.Drawing.Size(348, 142);
            this.lstMayIn.TabIndex = 3;
            this.lstMayIn.UseCompatibleStateImageBehavior = false;
            this.lstMayIn.View = System.Windows.Forms.View.Details;
            this.lstMayIn.SelectedIndexChanged += new System.EventHandler(this.lstMayIn_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Khổ In Max";
            this.columnHeader3.Width = 83;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Khổ in Min";
            this.columnHeader4.Width = 76;
            // 
            // lblMayInChon
            // 
            this.lblMayInChon.AutoSize = true;
            this.lblMayInChon.Location = new System.Drawing.Point(6, 189);
            this.lblMayInChon.Name = "lblMayInChon";
            this.lblMayInChon.Size = new System.Drawing.Size(112, 13);
            this.lblMayInChon.TabIndex = 222;
            this.lblMayInChon.Text = "Thông tin máy in chọn";
            // 
            // txtMayInChon
            // 
            this.txtMayInChon.Location = new System.Drawing.Point(9, 206);
            this.txtMayInChon.Multiline = true;
            this.txtMayInChon.Name = "txtMayInChon";
            this.txtMayInChon.ReadOnly = true;
            this.txtMayInChon.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMayInChon.Size = new System.Drawing.Size(345, 77);
            this.txtMayInChon.TabIndex = 223;
            // 
            // rdbOffset
            // 
            this.rdbOffset.AutoSize = true;
            this.rdbOffset.Enabled = false;
            this.rdbOffset.Location = new System.Drawing.Point(301, 23);
            this.rdbOffset.Name = "rdbOffset";
            this.rdbOffset.Size = new System.Drawing.Size(53, 17);
            this.rdbOffset.TabIndex = 1;
            this.rdbOffset.Text = "Offset";
            this.rdbOffset.UseVisualStyleBackColor = true;
            this.rdbOffset.Visible = false;
            this.rdbOffset.CheckedChanged += new System.EventHandler(this.rdbToner_CheckedChanged);
            // 
            // rdbToner
            // 
            this.rdbToner.AutoSize = true;
            this.rdbToner.Checked = true;
            this.rdbToner.Location = new System.Drawing.Point(35, 23);
            this.rdbToner.Name = "rdbToner";
            this.rdbToner.Size = new System.Drawing.Size(67, 17);
            this.rdbToner.TabIndex = 0;
            this.rdbToner.TabStop = true;
            this.rdbToner.Text = "In nhanh";
            this.rdbToner.UseVisualStyleBackColor = true;
            this.rdbToner.CheckedChanged += new System.EventHandler(this.rdbToner_CheckedChanged);
            // 
            // lblDonViTinh
            // 
            this.lblDonViTinh.AutoSize = true;
            this.lblDonViTinh.Location = new System.Drawing.Point(167, 137);
            this.lblDonViTinh.Name = "lblDonViTinh";
            this.lblDonViTinh.Size = new System.Drawing.Size(60, 13);
            this.lblDonViTinh.TabIndex = 224;
            this.lblDonViTinh.Text = "Đơn vị tính";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(120, 167);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(107, 13);
            this.label25.TabIndex = 195;
            this.label25.Text = "Rộng     x    Cao (cm)";
            // 
            // btnSSanhInNhanhOffset
            // 
            this.btnSSanhInNhanhOffset.Location = new System.Drawing.Point(29, 19);
            this.btnSSanhInNhanhOffset.Name = "btnSSanhInNhanhOffset";
            this.btnSSanhInNhanhOffset.Size = new System.Drawing.Size(120, 23);
            this.btnSSanhInNhanhOffset.TabIndex = 225;
            this.btnSSanhInNhanhOffset.Text = "So sánh";
            this.btnSSanhInNhanhOffset.UseVisualStyleBackColor = true;
            this.btnSSanhInNhanhOffset.Click += new System.EventHandler(this.btnSSanhInNhanhOffset_Click);
            // 
            // grbTinhThu
            // 
            this.grbTinhThu.Controls.Add(this.btnSSanhInNhanhOffset);
            this.grbTinhThu.Location = new System.Drawing.Point(15, 333);
            this.grbTinhThu.Name = "grbTinhThu";
            this.grbTinhThu.Size = new System.Drawing.Size(195, 56);
            this.grbTinhThu.TabIndex = 15;
            this.grbTinhThu.TabStop = false;
            this.grbTinhThu.Text = "B.2. Nên in nhanh hay offset";
            // 
            // CauHinhSPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 437);
            this.Controls.Add(this.grbTinhThu);
            this.Controls.Add(this.lblDonViTinh);
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
            this.Controls.Add(this.btnGetProdTemplate);
            this.Name = "CauHinhSPForm";
            this.Text = "Triển khai Sản phẩm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrienKhaiCauHinhSPForm_FormClosing);
            this.Load += new System.EventHandler(this.TrienKhaiSanPhamForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbTinhThu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThongTinGiay;
        private System.Windows.Forms.TextBox txtKhoCatRong;
        private System.Windows.Forms.TextBox txtKhoCatCao;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Button btnReverseProdSize;
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
        private System.Windows.Forms.RadioButton rdbOffset;
        private System.Windows.Forms.RadioButton rdbToner;
        private System.Windows.Forms.ListView lstMayIn;
        private System.Windows.Forms.Label lblMayInChon;
        private System.Windows.Forms.TextBox txtMayInChon;
        private System.Windows.Forms.Label lblDonViTinh;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.RadioButton rdbKhongIn;
        private System.Windows.Forms.Button btnSSanhInNhanhOffset;
        private System.Windows.Forms.GroupBox grbTinhThu;
    }
}