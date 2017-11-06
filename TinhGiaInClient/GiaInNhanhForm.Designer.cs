namespace TinhGiaInClient
{
    partial class GiaInNhanhForm
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
            this.grbMatIn = new System.Windows.Forms.GroupBox();
            this.rdbInMotMat = new System.Windows.Forms.RadioButton();
            this.rdbInHaiMat = new System.Windows.Forms.RadioButton();
            this.cboNiemYetGia = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtSoTrangA4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.lblGiaTB_A4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtThongTinGiay = new System.Windows.Forms.TextBox();
            this.txtHangKhachHang = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lvwBangGia = new System.Windows.Forms.ListView();
            this.label8 = new System.Windows.Forms.Label();
            this.txtToInDigiChon = new System.Windows.Forms.TextBox();
            this.txtSoTrangToiDa = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSoLuongToChay = new System.Windows.Forms.TextBox();
            this.lblLoaiBangGia = new System.Windows.Forms.Label();
            this.txtDienGiaiNiemYet = new System.Windows.Forms.TextBox();
            this.grbMatIn.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbMatIn
            // 
            this.grbMatIn.Controls.Add(this.rdbInMotMat);
            this.grbMatIn.Controls.Add(this.rdbInHaiMat);
            this.grbMatIn.Location = new System.Drawing.Point(349, 146);
            this.grbMatIn.Name = "grbMatIn";
            this.grbMatIn.Size = new System.Drawing.Size(199, 46);
            this.grbMatIn.TabIndex = 8;
            this.grbMatIn.TabStop = false;
            this.grbMatIn.Text = "Mặt in";
            // 
            // rdbInMotMat
            // 
            this.rdbInMotMat.AutoSize = true;
            this.rdbInMotMat.Location = new System.Drawing.Point(109, 19);
            this.rdbInMotMat.Name = "rdbInMotMat";
            this.rdbInMotMat.Size = new System.Drawing.Size(52, 17);
            this.rdbInMotMat.TabIndex = 2;
            this.rdbInMotMat.TabStop = true;
            this.rdbInMotMat.Text = "1 Mặt";
            this.rdbInMotMat.UseVisualStyleBackColor = true;
            // 
            // rdbInHaiMat
            // 
            this.rdbInHaiMat.AutoSize = true;
            this.rdbInHaiMat.Checked = true;
            this.rdbInHaiMat.Location = new System.Drawing.Point(12, 19);
            this.rdbInHaiMat.Name = "rdbInHaiMat";
            this.rdbInHaiMat.Size = new System.Drawing.Size(52, 17);
            this.rdbInHaiMat.TabIndex = 1;
            this.rdbInHaiMat.TabStop = true;
            this.rdbInHaiMat.Text = "2 Mặt";
            this.rdbInHaiMat.UseVisualStyleBackColor = true;
            // 
            // cboNiemYetGia
            // 
            this.cboNiemYetGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNiemYetGia.FormattingEnabled = true;
            this.cboNiemYetGia.Location = new System.Drawing.Point(21, 60);
            this.cboNiemYetGia.Name = "cboNiemYetGia";
            this.cboNiemYetGia.Size = new System.Drawing.Size(222, 21);
            this.cboNiemYetGia.TabIndex = 2;
            this.cboNiemYetGia.SelectedIndexChanged += new System.EventHandler(this.cboBangGia_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(254, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 91;
            this.label1.Text = "GIÁ IN NHANH";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(280, 341);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Hủy";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(430, 341);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "Nhận";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtSoTrangA4
            // 
            this.txtSoTrangA4.Location = new System.Drawing.Point(349, 198);
            this.txtSoTrangA4.Name = "txtSoTrangA4";
            this.txtSoTrangA4.ReadOnly = true;
            this.txtSoTrangA4.Size = new System.Drawing.Size(70, 20);
            this.txtSoTrangA4.TabIndex = 9;
            this.txtSoTrangA4.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 95;
            this.label2.Text = "Quy trang A4";
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThanhTien.Location = new System.Drawing.Point(346, 237);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(32, 13);
            this.lblThanhTien.TabIndex = 96;
            this.lblThanhTien.Text = "Tiền";
            // 
            // lblGiaTB_A4
            // 
            this.lblGiaTB_A4.AutoSize = true;
            this.lblGiaTB_A4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaTB_A4.Location = new System.Drawing.Point(346, 266);
            this.lblGiaTB_A4.Name = "lblGiaTB_A4";
            this.lblGiaTB_A4.Size = new System.Drawing.Size(44, 13);
            this.lblGiaTB_A4.TabIndex = 97;
            this.lblGiaTB_A4.Text = "TB/A4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 98;
            this.label3.Text = "Bảng giá theo";
            // 
            // txtThongTinGiay
            // 
            this.txtThongTinGiay.Location = new System.Drawing.Point(349, 92);
            this.txtThongTinGiay.Multiline = true;
            this.txtThongTinGiay.Name = "txtThongTinGiay";
            this.txtThongTinGiay.ReadOnly = true;
            this.txtThongTinGiay.Size = new System.Drawing.Size(199, 20);
            this.txtThongTinGiay.TabIndex = 6;
            // 
            // txtHangKhachHang
            // 
            this.txtHangKhachHang.Location = new System.Drawing.Point(107, 34);
            this.txtHangKhachHang.Name = "txtHangKhachHang";
            this.txtHangKhachHang.ReadOnly = true;
            this.txtHangKhachHang.Size = new System.Drawing.Size(136, 20);
            this.txtHangKhachHang.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 102;
            this.label4.Text = "Máy in";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(269, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 103;
            this.label5.Text = "Khổ giấy chạy";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(269, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 104;
            this.label6.Text = "Tổng tiền In";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(269, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 105;
            this.label7.Text = "Giá TB/A4";
            // 
            // lvwBangGia
            // 
            this.lvwBangGia.Location = new System.Drawing.Point(21, 143);
            this.lvwBangGia.Name = "lvwBangGia";
            this.lvwBangGia.Size = new System.Drawing.Size(222, 195);
            this.lvwBangGia.TabIndex = 4;
            this.lvwBangGia.UseCompatibleStateImageBehavior = false;
            this.lvwBangGia.View = System.Windows.Forms.View.Details;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(269, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 106;
            this.label8.Text = "Số tờ";
            // 
            // txtToInDigiChon
            // 
            this.txtToInDigiChon.Location = new System.Drawing.Point(349, 65);
            this.txtToInDigiChon.Name = "txtToInDigiChon";
            this.txtToInDigiChon.ReadOnly = true;
            this.txtToInDigiChon.Size = new System.Drawing.Size(199, 20);
            this.txtToInDigiChon.TabIndex = 5;
            // 
            // txtSoTrangToiDa
            // 
            this.txtSoTrangToiDa.Location = new System.Drawing.Point(172, 344);
            this.txtSoTrangToiDa.Name = "txtSoTrangToiDa";
            this.txtSoTrangToiDa.ReadOnly = true;
            this.txtSoTrangToiDa.Size = new System.Drawing.Size(70, 20);
            this.txtSoTrangToiDa.TabIndex = 109;
            this.txtSoTrangToiDa.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(128, 347);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 110;
            this.label9.Text = "Tối đa";
            // 
            // txtSoLuongToChay
            // 
            this.txtSoLuongToChay.Location = new System.Drawing.Point(349, 120);
            this.txtSoLuongToChay.Name = "txtSoLuongToChay";
            this.txtSoLuongToChay.ReadOnly = true;
            this.txtSoLuongToChay.Size = new System.Drawing.Size(70, 20);
            this.txtSoLuongToChay.TabIndex = 7;
            this.txtSoLuongToChay.Text = "0";
            // 
            // lblLoaiBangGia
            // 
            this.lblLoaiBangGia.AutoSize = true;
            this.lblLoaiBangGia.Location = new System.Drawing.Point(21, 84);
            this.lblLoaiBangGia.Name = "lblLoaiBangGia";
            this.lblLoaiBangGia.Size = new System.Drawing.Size(71, 13);
            this.lblLoaiBangGia.TabIndex = 112;
            this.lblLoaiBangGia.Text = "Loại bảng giá";
            // 
            // txtDienGiaiNiemYet
            // 
            this.txtDienGiaiNiemYet.Location = new System.Drawing.Point(24, 100);
            this.txtDienGiaiNiemYet.Multiline = true;
            this.txtDienGiaiNiemYet.Name = "txtDienGiaiNiemYet";
            this.txtDienGiaiNiemYet.ReadOnly = true;
            this.txtDienGiaiNiemYet.Size = new System.Drawing.Size(219, 37);
            this.txtDienGiaiNiemYet.TabIndex = 3;
            // 
            // GiaInNhanhForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 378);
            this.Controls.Add(this.txtDienGiaiNiemYet);
            this.Controls.Add(this.lblLoaiBangGia);
            this.Controls.Add(this.txtSoLuongToChay);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtSoTrangToiDa);
            this.Controls.Add(this.txtToInDigiChon);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lvwBangGia);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHangKhachHang);
            this.Controls.Add(this.txtThongTinGiay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblGiaTB_A4);
            this.Controls.Add(this.lblThanhTien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSoTrangA4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboNiemYetGia);
            this.Controls.Add(this.grbMatIn);
            this.Name = "GiaInNhanhForm";
            this.Text = "TinhGiaInForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GiaInForm_FormClosing);
            this.Load += new System.EventHandler(this.GiaInForm_Load);
            this.grbMatIn.ResumeLayout(false);
            this.grbMatIn.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbMatIn;
        private System.Windows.Forms.RadioButton rdbInMotMat;
        private System.Windows.Forms.RadioButton rdbInHaiMat;
        private System.Windows.Forms.ComboBox cboNiemYetGia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtSoTrangA4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.Label lblGiaTB_A4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtThongTinGiay;
        private System.Windows.Forms.TextBox txtHangKhachHang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView lvwBangGia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtToInDigiChon;
        private System.Windows.Forms.TextBox txtSoTrangToiDa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSoLuongToChay;
        private System.Windows.Forms.Label lblLoaiBangGia;
        private System.Windows.Forms.TextBox txtDienGiaiNiemYet;
    }
}