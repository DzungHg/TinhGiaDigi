namespace TinhGiaInClient
{
    partial class GiayDeInForm
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
            this.lblTieuDeForm = new System.Windows.Forms.Label();
            this.btnNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.txtSoToGiayLon = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSoToInTong = new System.Windows.Forms.Label();
            this.chkGiayKhach = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSoConTrenToIn = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSoToChayBuHao = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTenGiayDatLai = new System.Windows.Forms.TextBox();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKhoToChay = new System.Windows.Forms.TextBox();
            this.txtThongTinBaiIn = new System.Windows.Forms.TextBox();
            this.lblGiaBan = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSoToChayLyThuyet = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoToChayTrenToLon = new System.Windows.Forms.TextBox();
            this.lblThongTinGiayChon = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnChonGiay = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDeForm
            // 
            this.lblTieuDeForm.AutoSize = true;
            this.lblTieuDeForm.Location = new System.Drawing.Point(317, 19);
            this.lblTieuDeForm.Name = "lblTieuDeForm";
            this.lblTieuDeForm.Size = new System.Drawing.Size(86, 13);
            this.lblTieuDeForm.TabIndex = 1;
            this.lblTieuDeForm.Text = "CHUẨN BỊ GIẤY";
            // 
            // btnNhan
            // 
            this.btnNhan.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNhan.Location = new System.Drawing.Point(404, 339);
            this.btnNhan.Name = "btnNhan";
            this.btnNhan.Size = new System.Drawing.Size(75, 23);
            this.btnNhan.TabIndex = 1;
            this.btnNhan.Text = "Nhận";
            this.btnNhan.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Location = new System.Drawing.Point(233, 339);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 0;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // txtSoToGiayLon
            // 
            this.txtSoToGiayLon.Location = new System.Drawing.Point(163, 169);
            this.txtSoToGiayLon.Name = "txtSoToGiayLon";
            this.txtSoToGiayLon.ReadOnly = true;
            this.txtSoToGiayLon.Size = new System.Drawing.Size(54, 20);
            this.txtSoToGiayLon.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Số tờ lớn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "=";
            // 
            // lblSoToInTong
            // 
            this.lblSoToInTong.AutoSize = true;
            this.lblSoToInTong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoToInTong.Location = new System.Drawing.Point(343, 64);
            this.lblSoToInTong.Name = "lblSoToInTong";
            this.lblSoToInTong.Size = new System.Drawing.Size(80, 13);
            this.lblSoToInTong.TabIndex = 49;
            this.lblSoToInTong.Text = "Số tờ in tổng";
            // 
            // chkGiayKhach
            // 
            this.chkGiayKhach.AutoSize = true;
            this.chkGiayKhach.Location = new System.Drawing.Point(371, 94);
            this.chkGiayKhach.Name = "chkGiayKhach";
            this.chkGiayKhach.Size = new System.Drawing.Size(102, 17);
            this.chkGiayKhach.TabIndex = 5;
            this.chkGiayKhach.Text = "Giấy khách đưa";
            this.chkGiayKhach.UseVisualStyleBackColor = true;
            this.chkGiayKhach.CheckedChanged += new System.EventHandler(this.chkGiayKhach_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(272, 36);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 13);
            this.label16.TabIndex = 47;
            this.label16.Text = "Con/tờ chạy";
            // 
            // txtSoConTrenToIn
            // 
            this.txtSoConTrenToIn.Location = new System.Drawing.Point(344, 33);
            this.txtSoConTrenToIn.Name = "txtSoConTrenToIn";
            this.txtSoConTrenToIn.Size = new System.Drawing.Size(43, 20);
            this.txtSoConTrenToIn.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(31, 225);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 45;
            this.label14.Text = "Thành tiền";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(223, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 41;
            this.label12.Text = "+ bù hao";
            // 
            // txtSoToChayBuHao
            // 
            this.txtSoToChayBuHao.Location = new System.Drawing.Point(275, 61);
            this.txtSoToChayBuHao.Name = "txtSoToChayBuHao";
            this.txtSoToChayBuHao.Size = new System.Drawing.Size(50, 20);
            this.txtSoToChayBuHao.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "B4. Tên giấy đặt lại";
            // 
            // txtTenGiayDatLai
            // 
            this.txtTenGiayDatLai.Location = new System.Drawing.Point(162, 117);
            this.txtTenGiayDatLai.Name = "txtTenGiayDatLai";
            this.txtTenGiayDatLai.Size = new System.Drawing.Size(260, 20);
            this.txtTenGiayDatLai.TabIndex = 6;
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Location = new System.Drawing.Point(156, 225);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(58, 13);
            this.lblThanhTien.TabIndex = 39;
            this.lblThanhTien.Text = "Thành tiền";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "B1. Khổ tờ in";
            // 
            // txtKhoToChay
            // 
            this.txtKhoToChay.Location = new System.Drawing.Point(163, 33);
            this.txtKhoToChay.Name = "txtKhoToChay";
            this.txtKhoToChay.Size = new System.Drawing.Size(100, 20);
            this.txtKhoToChay.TabIndex = 0;
            // 
            // txtThongTinBaiIn
            // 
            this.txtThongTinBaiIn.Location = new System.Drawing.Point(12, 62);
            this.txtThongTinBaiIn.Multiline = true;
            this.txtThongTinBaiIn.Name = "txtThongTinBaiIn";
            this.txtThongTinBaiIn.ReadOnly = true;
            this.txtThongTinBaiIn.Size = new System.Drawing.Size(192, 250);
            this.txtThongTinBaiIn.TabIndex = 26;
            // 
            // lblGiaBan
            // 
            this.lblGiaBan.AutoSize = true;
            this.lblGiaBan.Location = new System.Drawing.Point(161, 201);
            this.lblGiaBan.Name = "lblGiaBan";
            this.lblGiaBan.Size = new System.Drawing.Size(44, 13);
            this.lblGiaBan.TabIndex = 36;
            this.lblGiaBan.Text = "Giá bán";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 201);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Giá bán tờ lớn";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Thông tin  cần";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "B2. Số tờ chạy tính";
            // 
            // txtSoToChayLyThuyet
            // 
            this.txtSoToChayLyThuyet.Location = new System.Drawing.Point(163, 61);
            this.txtSoToChayLyThuyet.Name = "txtSoToChayLyThuyet";
            this.txtSoToChayLyThuyet.ReadOnly = true;
            this.txtSoToChayLyThuyet.Size = new System.Drawing.Size(54, 20);
            this.txtSoToChayLyThuyet.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "B5. Số Tờ Chạy / Tờ Lớn";
            // 
            // txtSoToChayTrenToLon
            // 
            this.txtSoToChayTrenToLon.Location = new System.Drawing.Point(163, 143);
            this.txtSoToChayTrenToLon.Name = "txtSoToChayTrenToLon";
            this.txtSoToChayTrenToLon.Size = new System.Drawing.Size(54, 20);
            this.txtSoToChayTrenToLon.TabIndex = 9;
            // 
            // lblThongTinGiayChon
            // 
            this.lblThongTinGiayChon.AutoSize = true;
            this.lblThongTinGiayChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongTinGiayChon.Location = new System.Drawing.Point(163, 93);
            this.lblThongTinGiayChon.Name = "lblThongTinGiayChon";
            this.lblThongTinGiayChon.Size = new System.Drawing.Size(120, 13);
            this.lblThongTinGiayChon.TabIndex = 24;
            this.lblThongTinGiayChon.Text = "Thông tin giấy chọn";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnChonGiay);
            this.groupBox1.Controls.Add(this.txtKhoToChay);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblThanhTien);
            this.groupBox1.Controls.Add(this.lblGiaBan);
            this.groupBox1.Controls.Add(this.txtSoToGiayLon);
            this.groupBox1.Controls.Add(this.txtTenGiayDatLai);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.chkGiayKhach);
            this.groupBox1.Controls.Add(this.lblThongTinGiayChon);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblSoToInTong);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtSoToChayBuHao);
            this.groupBox1.Controls.Add(this.txtSoToChayLyThuyet);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSoConTrenToIn);
            this.groupBox1.Controls.Add(this.txtSoToChayTrenToLon);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(228, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 250);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thiết đặt giấy in";
            // 
            // btnChonGiay
            // 
            this.btnChonGiay.Location = new System.Drawing.Point(120, 88);
            this.btnChonGiay.Name = "btnChonGiay";
            this.btnChonGiay.Size = new System.Drawing.Size(30, 23);
            this.btnChonGiay.TabIndex = 4;
            this.btnChonGiay.Text = "..";
            this.btnChonGiay.UseVisualStyleBackColor = true;
            this.btnChonGiay.Click += new System.EventHandler(this.btnChonGiay_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "B3. Chọn giấy";
            // 
            // GiayDeInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 383);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNhan);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.lblTieuDeForm);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtThongTinBaiIn);
            this.Name = "GiayDeInForm";
            this.Text = "Giấy để in";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChuanBiGiayForm_FormClosing);
            this.Load += new System.EventHandler(this.ChuanBiGiayForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDeForm;
        private System.Windows.Forms.Button btnNhan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSoConTrenToIn;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSoToChayBuHao;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTenGiayDatLai;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKhoToChay;
        private System.Windows.Forms.TextBox txtThongTinBaiIn;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSoToChayLyThuyet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSoToChayTrenToLon;
        private System.Windows.Forms.Label lblThongTinGiayChon;
        private System.Windows.Forms.CheckBox chkGiayKhach;
        private System.Windows.Forms.Label lblSoToInTong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoToGiayLon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnChonGiay;
        private System.Windows.Forms.Label label4;

    }
}