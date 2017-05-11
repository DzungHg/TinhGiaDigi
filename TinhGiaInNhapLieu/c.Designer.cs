namespace TinhGiaInNhapLieu
{
    partial class ChuanBiGiayForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.splitCont1 = new System.Windows.Forms.SplitContainer();
            this.splitCont2 = new System.Windows.Forms.SplitContainer();
            this.lbxDanhMucGiay = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cboNhaCC = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvwGiay = new System.Windows.Forms.ListView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.chkGiayKhach = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSoConTrenToIn = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblGiaMua = new System.Windows.Forms.Label();
            this.txtThongTinCauHinh = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSoToChayBuHao = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTenDienGiai = new System.Windows.Forms.TextBox();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKhoToChay = new System.Windows.Forms.TextBox();
            this.txtDienGiaiBaiIn = new System.Windows.Forms.TextBox();
            this.lblGiaBanChoKH = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSoToChayLyThuyet = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoToGiayLon = new System.Windows.Forms.TextBox();
            this.lblChonGiay = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSoToInTong = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCont1)).BeginInit();
            this.splitCont1.Panel1.SuspendLayout();
            this.splitCont1.Panel2.SuspendLayout();
            this.splitCont1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCont2)).BeginInit();
            this.splitCont2.Panel1.SuspendLayout();
            this.splitCont2.Panel2.SuspendLayout();
            this.splitCont2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(641, 31);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "CHUẨN BỊ GIẤY";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnNhan);
            this.panel2.Controls.Add(this.btnHuy);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 502);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(641, 38);
            this.panel2.TabIndex = 1;
            // 
            // btnNhan
            // 
            this.btnNhan.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNhan.Location = new System.Drawing.Point(375, 5);
            this.btnNhan.Name = "btnNhan";
            this.btnNhan.Size = new System.Drawing.Size(75, 23);
            this.btnNhan.TabIndex = 1;
            this.btnNhan.Text = "Nhận";
            this.btnNhan.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Location = new System.Drawing.Point(150, 5);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 0;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // splitCont1
            // 
            this.splitCont1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCont1.Location = new System.Drawing.Point(0, 31);
            this.splitCont1.Name = "splitCont1";
            this.splitCont1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitCont1.Panel1
            // 
            this.splitCont1.Panel1.Controls.Add(this.splitCont2);
            // 
            // splitCont1.Panel2
            // 
            this.splitCont1.Panel2.Controls.Add(this.lblSoToInTong);
            this.splitCont1.Panel2.Controls.Add(this.chkGiayKhach);
            this.splitCont1.Panel2.Controls.Add(this.label16);
            this.splitCont1.Panel2.Controls.Add(this.txtSoConTrenToIn);
            this.splitCont1.Panel2.Controls.Add(this.label14);
            this.splitCont1.Panel2.Controls.Add(this.label15);
            this.splitCont1.Panel2.Controls.Add(this.lblGiaMua);
            this.splitCont1.Panel2.Controls.Add(this.txtThongTinCauHinh);
            this.splitCont1.Panel2.Controls.Add(this.label13);
            this.splitCont1.Panel2.Controls.Add(this.label12);
            this.splitCont1.Panel2.Controls.Add(this.txtSoToChayBuHao);
            this.splitCont1.Panel2.Controls.Add(this.label11);
            this.splitCont1.Panel2.Controls.Add(this.txtTenDienGiai);
            this.splitCont1.Panel2.Controls.Add(this.lblThanhTien);
            this.splitCont1.Panel2.Controls.Add(this.label8);
            this.splitCont1.Panel2.Controls.Add(this.txtKhoToChay);
            this.splitCont1.Panel2.Controls.Add(this.txtDienGiaiBaiIn);
            this.splitCont1.Panel2.Controls.Add(this.lblGiaBanChoKH);
            this.splitCont1.Panel2.Controls.Add(this.label10);
            this.splitCont1.Panel2.Controls.Add(this.label9);
            this.splitCont1.Panel2.Controls.Add(this.label6);
            this.splitCont1.Panel2.Controls.Add(this.txtSoToChayLyThuyet);
            this.splitCont1.Panel2.Controls.Add(this.label5);
            this.splitCont1.Panel2.Controls.Add(this.txtSoToGiayLon);
            this.splitCont1.Panel2.Controls.Add(this.lblChonGiay);
            this.splitCont1.Panel2.Controls.Add(this.label4);
            this.splitCont1.Size = new System.Drawing.Size(641, 471);
            this.splitCont1.SplitterDistance = 218;
            this.splitCont1.TabIndex = 2;
            // 
            // splitCont2
            // 
            this.splitCont2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCont2.Location = new System.Drawing.Point(0, 0);
            this.splitCont2.Name = "splitCont2";
            // 
            // splitCont2.Panel1
            // 
            this.splitCont2.Panel1.Controls.Add(this.lbxDanhMucGiay);
            this.splitCont2.Panel1.Controls.Add(this.panel3);
            // 
            // splitCont2.Panel2
            // 
            this.splitCont2.Panel2.Controls.Add(this.lvwGiay);
            this.splitCont2.Panel2.Controls.Add(this.panel4);
            this.splitCont2.Size = new System.Drawing.Size(641, 218);
            this.splitCont2.SplitterDistance = 209;
            this.splitCont2.TabIndex = 1;
            // 
            // lbxDanhMucGiay
            // 
            this.lbxDanhMucGiay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxDanhMucGiay.FormattingEnabled = true;
            this.lbxDanhMucGiay.Location = new System.Drawing.Point(0, 39);
            this.lbxDanhMucGiay.Name = "lbxDanhMucGiay";
            this.lbxDanhMucGiay.Size = new System.Drawing.Size(209, 179);
            this.lbxDanhMucGiay.TabIndex = 1;
            this.lbxDanhMucGiay.SelectedIndexChanged += new System.EventHandler(this.lbxDanhMucGiay_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cboNhaCC);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(209, 39);
            this.panel3.TabIndex = 0;
            // 
            // cboNhaCC
            // 
            this.cboNhaCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhaCC.FormattingEnabled = true;
            this.cboNhaCC.Location = new System.Drawing.Point(62, 8);
            this.cboNhaCC.Name = "cboNhaCC";
            this.cboNhaCC.Size = new System.Drawing.Size(135, 21);
            this.cboNhaCC.TabIndex = 1;
            this.cboNhaCC.SelectedIndexChanged += new System.EventHandler(this.cboNhaCC_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhà CC:";
            // 
            // lvwGiay
            // 
            this.lvwGiay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwGiay.Location = new System.Drawing.Point(0, 39);
            this.lvwGiay.Name = "lvwGiay";
            this.lvwGiay.Size = new System.Drawing.Size(428, 179);
            this.lvwGiay.TabIndex = 2;
            this.lvwGiay.UseCompatibleStateImageBehavior = false;
            this.lvwGiay.SelectedIndexChanged += new System.EventHandler(this.lvwGiay_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(428, 39);
            this.panel4.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giấy theo Danh mục";
            // 
            // chkGiayKhach
            // 
            this.chkGiayKhach.AutoSize = true;
            this.chkGiayKhach.Location = new System.Drawing.Point(481, 109);
            this.chkGiayKhach.Name = "chkGiayKhach";
            this.chkGiayKhach.Size = new System.Drawing.Size(102, 17);
            this.chkGiayKhach.TabIndex = 48;
            this.chkGiayKhach.Text = "Giấy khách đưa";
            this.chkGiayKhach.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(341, 139);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 13);
            this.label16.TabIndex = 47;
            this.label16.Text = "Con/tờ in";
            // 
            // txtSoConTrenToIn
            // 
            this.txtSoConTrenToIn.Location = new System.Drawing.Point(396, 136);
            this.txtSoConTrenToIn.Name = "txtSoConTrenToIn";
            this.txtSoConTrenToIn.Size = new System.Drawing.Size(54, 20);
            this.txtSoConTrenToIn.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(300, 215);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 45;
            this.label14.Text = "Thành tiền";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(341, 84);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 13);
            this.label15.TabIndex = 44;
            this.label15.Text = "Giá mua";
            // 
            // lblGiaMua
            // 
            this.lblGiaMua.AutoSize = true;
            this.lblGiaMua.Location = new System.Drawing.Point(405, 84);
            this.lblGiaMua.Name = "lblGiaMua";
            this.lblGiaMua.Size = new System.Drawing.Size(46, 13);
            this.lblGiaMua.TabIndex = 43;
            this.lblGiaMua.Text = "Giá mua";
            // 
            // txtThongTinCauHinh
            // 
            this.txtThongTinCauHinh.Location = new System.Drawing.Point(226, 50);
            this.txtThongTinCauHinh.Multiline = true;
            this.txtThongTinCauHinh.Name = "txtThongTinCauHinh";
            this.txtThongTinCauHinh.ReadOnly = true;
            this.txtThongTinCauHinh.Size = new System.Drawing.Size(225, 21);
            this.txtThongTinCauHinh.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(131, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 42;
            this.label13.Text = "Cấu hình SP";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(289, 165);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 41;
            this.label12.Text = "Bù hao";
            // 
            // txtSoToChayBuHao
            // 
            this.txtSoToChayBuHao.Location = new System.Drawing.Point(344, 162);
            this.txtSoToChayBuHao.Name = "txtSoToChayBuHao";
            this.txtSoToChayBuHao.Size = new System.Drawing.Size(54, 20);
            this.txtSoToChayBuHao.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(131, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Tên diễn giải";
            // 
            // txtTenDienGiai
            // 
            this.txtTenDienGiai.Location = new System.Drawing.Point(226, 110);
            this.txtTenDienGiai.Name = "txtTenDienGiai";
            this.txtTenDienGiai.Size = new System.Drawing.Size(225, 20);
            this.txtTenDienGiai.TabIndex = 6;
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Location = new System.Drawing.Point(393, 215);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(58, 13);
            this.lblThanhTien.TabIndex = 39;
            this.lblThanhTien.Text = "Thành tiền";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(131, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Cắt khổ in";
            // 
            // txtKhoToChay
            // 
            this.txtKhoToChay.Location = new System.Drawing.Point(226, 136);
            this.txtKhoToChay.Name = "txtKhoToChay";
            this.txtKhoToChay.Size = new System.Drawing.Size(100, 20);
            this.txtKhoToChay.TabIndex = 7;
            // 
            // txtDienGiaiBaiIn
            // 
            this.txtDienGiaiBaiIn.Location = new System.Drawing.Point(226, 23);
            this.txtDienGiaiBaiIn.Multiline = true;
            this.txtDienGiaiBaiIn.Name = "txtDienGiaiBaiIn";
            this.txtDienGiaiBaiIn.ReadOnly = true;
            this.txtDienGiaiBaiIn.Size = new System.Drawing.Size(225, 21);
            this.txtDienGiaiBaiIn.TabIndex = 26;
            // 
            // lblGiaBanChoKH
            // 
            this.lblGiaBanChoKH.AutoSize = true;
            this.lblGiaBanChoKH.Location = new System.Drawing.Point(225, 215);
            this.lblGiaBanChoKH.Name = "lblGiaBanChoKH";
            this.lblGiaBanChoKH.Size = new System.Drawing.Size(44, 13);
            this.lblGiaBanChoKH.TabIndex = 36;
            this.lblGiaBanChoKH.Text = "Giá bán";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(131, 215);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Giá bán tờ lớn";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(131, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Bài In";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(131, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Số tờ in tính";
            // 
            // txtSoToChayLyThuyet
            // 
            this.txtSoToChayLyThuyet.Location = new System.Drawing.Point(226, 161);
            this.txtSoToChayLyThuyet.Name = "txtSoToChayLyThuyet";
            this.txtSoToChayLyThuyet.Size = new System.Drawing.Size(54, 20);
            this.txtSoToChayLyThuyet.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(131, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Số tờ lớn";
            // 
            // txtSoToGiayLon
            // 
            this.txtSoToGiayLon.Location = new System.Drawing.Point(225, 187);
            this.txtSoToGiayLon.Name = "txtSoToGiayLon";
            this.txtSoToGiayLon.Size = new System.Drawing.Size(54, 20);
            this.txtSoToGiayLon.TabIndex = 11;
            // 
            // lblChonGiay
            // 
            this.lblChonGiay.AutoSize = true;
            this.lblChonGiay.Location = new System.Drawing.Point(225, 84);
            this.lblChonGiay.Name = "lblChonGiay";
            this.lblChonGiay.Size = new System.Drawing.Size(54, 13);
            this.lblChonGiay.TabIndex = 24;
            this.lblChonGiay.Text = "Chọn giấy";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Giấy chọn";
            // 
            // lblSoToInTong
            // 
            this.lblSoToInTong.AutoSize = true;
            this.lblSoToInTong.Location = new System.Drawing.Point(405, 165);
            this.lblSoToInTong.Name = "lblSoToInTong";
            this.lblSoToInTong.Size = new System.Drawing.Size(67, 13);
            this.lblSoToInTong.TabIndex = 49;
            this.lblSoToInTong.Text = "Số tờ in tổng";
            // 
            // ChuanBiGiayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 540);
            this.Controls.Add(this.splitCont1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ChuanBiGiayForm";
            this.Text = "ChuanBiGiayForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChuanBiGiayForm_FormClosing);
            this.Load += new System.EventHandler(this.ChuanBiGiayForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitCont1.Panel1.ResumeLayout(false);
            this.splitCont1.Panel2.ResumeLayout(false);
            this.splitCont1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCont1)).EndInit();
            this.splitCont1.ResumeLayout(false);
            this.splitCont2.Panel1.ResumeLayout(false);
            this.splitCont2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitCont2)).EndInit();
            this.splitCont2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitCont1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNhan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.SplitContainer splitCont2;
        private System.Windows.Forms.ListBox lbxDanhMucGiay;
        private System.Windows.Forms.ComboBox cboNhaCC;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSoConTrenToIn;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblGiaMua;
        private System.Windows.Forms.TextBox txtThongTinCauHinh;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSoToChayBuHao;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTenDienGiai;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKhoToChay;
        private System.Windows.Forms.TextBox txtDienGiaiBaiIn;
        private System.Windows.Forms.Label lblGiaBanChoKH;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSoToChayLyThuyet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSoToGiayLon;
        private System.Windows.Forms.Label lblChonGiay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lvwGiay;
        private System.Windows.Forms.CheckBox chkGiayKhach;
        private System.Windows.Forms.Label lblSoToInTong;

    }
}