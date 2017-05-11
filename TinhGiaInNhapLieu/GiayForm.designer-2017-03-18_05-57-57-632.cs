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
            this.txtPaperName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPaperCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtShortDim = new System.Windows.Forms.TextBox();
            this.txtLongDim = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSubstance = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtProfitMargin = new System.Windows.Forms.TextBox();
            this.lblTieuDeForm = new System.Windows.Forms.Label();
            this.txtDanhMuc = new System.Windows.Forms.TextBox();
            this.txtNhaCungCap = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMaTuDat = new System.Windows.Forms.TextBox();
            this.txtDienGiai = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.chkTonKho = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(77, 352);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(169, 352);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPaperId
            // 
            this.lblPaperId.AutoSize = true;
            this.lblPaperId.Location = new System.Drawing.Point(269, 98);
            this.lblPaperId.Name = "lblPaperId";
            this.lblPaperId.Size = new System.Drawing.Size(35, 13);
            this.lblPaperId.TabIndex = 7;
            this.lblPaperId.Text = "label1";
            // 
            // txtPaperName
            // 
            this.txtPaperName.Location = new System.Drawing.Point(105, 150);
            this.txtPaperName.Name = "txtPaperName";
            this.txtPaperName.Size = new System.Drawing.Size(158, 20);
            this.txtPaperName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tên giấy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Mã nhà CC";
            // 
            // txtPaperCode
            // 
            this.txtPaperCode.Location = new System.Drawing.Point(105, 98);
            this.txtPaperCode.Name = "txtPaperCode";
            this.txtPaperCode.Size = new System.Drawing.Size(158, 20);
            this.txtPaperCode.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Kích thước:";
            // 
            // txtShortDim
            // 
            this.txtShortDim.Location = new System.Drawing.Point(105, 201);
            this.txtShortDim.Name = "txtShortDim";
            this.txtShortDim.Size = new System.Drawing.Size(40, 20);
            this.txtShortDim.TabIndex = 6;
            this.txtShortDim.TextChanged += new System.EventHandler(this.txtShortDim_TextChanged);
            // 
            // txtLongDim
            // 
            this.txtLongDim.Location = new System.Drawing.Point(169, 201);
            this.txtLongDim.Name = "txtLongDim";
            this.txtLongDim.Size = new System.Drawing.Size(40, 20);
            this.txtLongDim.TabIndex = 7;
            this.txtLongDim.TextChanged += new System.EventHandler(this.txtShortDim_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(150, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "x";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 279);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Đơn giá:";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(105, 276);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(79, 20);
            this.txtUnitPrice.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(190, 279);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "đ/tờ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Danh mục";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Định lượng:";
            // 
            // txtSubstance
            // 
            this.txtSubstance.Location = new System.Drawing.Point(105, 176);
            this.txtSubstance.Name = "txtSubstance";
            this.txtSubstance.Size = new System.Drawing.Size(40, 20);
            this.txtSubstance.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(152, 179);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "g/m2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(213, 204);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "(cm) Nhỏ x Lớn";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 305);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Thứ tự";
            // 
            // txtProfitMargin
            // 
            this.txtProfitMargin.Location = new System.Drawing.Point(105, 302);
            this.txtProfitMargin.Name = "txtProfitMargin";
            this.txtProfitMargin.Size = new System.Drawing.Size(79, 20);
            this.txtProfitMargin.TabIndex = 10;
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
            // txtDanhMuc
            // 
            this.txtDanhMuc.Location = new System.Drawing.Point(105, 71);
            this.txtDanhMuc.Name = "txtDanhMuc";
            this.txtDanhMuc.ReadOnly = true;
            this.txtDanhMuc.Size = new System.Drawing.Size(158, 20);
            this.txtDanhMuc.TabIndex = 1;
            // 
            // txtNhaCungCap
            // 
            this.txtNhaCungCap.Location = new System.Drawing.Point(105, 45);
            this.txtNhaCungCap.Name = "txtNhaCungCap";
            this.txtNhaCungCap.ReadOnly = true;
            this.txtNhaCungCap.Size = new System.Drawing.Size(158, 20);
            this.txtNhaCungCap.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 13);
            this.label14.TabIndex = 35;
            this.label14.Text = "Nhà cung cấp";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 124);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 37;
            this.label15.Text = "Mã tự đặt";
            // 
            // txtMaTuDat
            // 
            this.txtMaTuDat.Location = new System.Drawing.Point(105, 124);
            this.txtMaTuDat.Name = "txtMaTuDat";
            this.txtMaTuDat.Size = new System.Drawing.Size(158, 20);
            this.txtMaTuDat.TabIndex = 3;
            // 
            // txtDienGiai
            // 
            this.txtDienGiai.Location = new System.Drawing.Point(105, 227);
            this.txtDienGiai.Multiline = true;
            this.txtDienGiai.Name = "txtDienGiai";
            this.txtDienGiai.Size = new System.Drawing.Size(195, 43);
            this.txtDienGiai.TabIndex = 8;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 227);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 13);
            this.label16.TabIndex = 39;
            this.label16.Text = "Diễn giải";
            // 
            // chkTonKho
            // 
            this.chkTonKho.AutoSize = true;
            this.chkTonKho.Location = new System.Drawing.Point(226, 305);
            this.chkTonKho.Name = "chkTonKho";
            this.chkTonKho.Size = new System.Drawing.Size(78, 17);
            this.chkTonKho.TabIndex = 11;
            this.chkTonKho.Text = "Có tồn kho";
            this.chkTonKho.UseVisualStyleBackColor = true;
            // 
            // GiayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 401);
            this.Controls.Add(this.chkTonKho);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtDienGiai);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtMaTuDat);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtNhaCungCap);
            this.Controls.Add(this.txtDanhMuc);
            this.Controls.Add(this.lblTieuDeForm);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtProfitMargin);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtSubstance);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLongDim);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtShortDim);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPaperCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPaperName);
            this.Controls.Add(this.lblPaperId);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "GiayForm";
            this.Text = "PaperCateForm";
            this.Load += new System.EventHandler(this.PaperCateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblPaperId;
        private System.Windows.Forms.TextBox txtPaperName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPaperCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtShortDim;
        private System.Windows.Forms.TextBox txtLongDim;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSubstance;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtProfitMargin;
        private System.Windows.Forms.Label lblTieuDeForm;
        private System.Windows.Forms.TextBox txtDanhMuc;
        private System.Windows.Forms.TextBox txtNhaCungCap;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMaTuDat;
        private System.Windows.Forms.TextBox txtDienGiai;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox chkTonKho;

    }
}