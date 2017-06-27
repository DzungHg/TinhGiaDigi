﻿namespace TinhGiaInNhapLieu
{
    partial class NhapLieuMainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.txtTenNguoiDung = new System.Windows.Forms.TextBox();
            this.lblNguoiDung = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabChung = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMayInDigi = new System.Windows.Forms.Button();
            this.btnQLyToInMayDigi = new System.Windows.Forms.Button();
            this.btnBangGiaInNhanh = new System.Windows.Forms.Button();
            this.btnKhoSanPham = new System.Windows.Forms.Button();
            this.tabNgVatLieu = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuanLyDanhMucGiay = new System.Windows.Forms.Button();
            this.btnQuanLyGiay = new System.Windows.Forms.Button();
            this.btnLoiNhuanGiay = new System.Windows.Forms.Button();
            this.btnBangGiaGiay = new System.Windows.Forms.Button();
            this.btnNhuEpKim = new System.Windows.Forms.Button();
            this.btnQuanLyLoXo = new System.Windows.Forms.Button();
            this.tabThanhPham = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCanPhu = new System.Windows.Forms.Button();
            this.btnCanGap = new System.Windows.Forms.Button();
            this.btnQuanLy_DongCuon = new System.Windows.Forms.Button();
            this.btnEpKim = new System.Windows.Forms.Button();
            this.btnQuanLy_DongCuonMP = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.tabCtrl.SuspendLayout();
            this.tabChung.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabNgVatLieu.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.tabThanhPham.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(426, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thoátToolStripMenuItem});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(148, 6);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtTenNguoiDung);
            this.pnlTop.Controls.Add(this.lblNguoiDung);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 24);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(426, 36);
            this.pnlTop.TabIndex = 5;
            // 
            // txtTenNguoiDung
            // 
            this.txtTenNguoiDung.Location = new System.Drawing.Point(80, 7);
            this.txtTenNguoiDung.Name = "txtTenNguoiDung";
            this.txtTenNguoiDung.Size = new System.Drawing.Size(185, 20);
            this.txtTenNguoiDung.TabIndex = 1;
            // 
            // lblNguoiDung
            // 
            this.lblNguoiDung.AutoSize = true;
            this.lblNguoiDung.Location = new System.Drawing.Point(12, 10);
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Size = new System.Drawing.Size(62, 13);
            this.lblNguoiDung.TabIndex = 0;
            this.lblNguoiDung.Text = "Người dùng";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnDong);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 293);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(426, 39);
            this.pnlBottom.TabIndex = 6;
            this.pnlBottom.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBottom_Paint);
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.tabChung);
            this.tabCtrl.Controls.Add(this.tabNgVatLieu);
            this.tabCtrl.Controls.Add(this.tabThanhPham);
            this.tabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrl.Location = new System.Drawing.Point(0, 60);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(426, 233);
            this.tabCtrl.TabIndex = 2;
            // 
            // tabChung
            // 
            this.tabChung.Controls.Add(this.flowLayoutPanel1);
            this.tabChung.Location = new System.Drawing.Point(4, 22);
            this.tabChung.Name = "tabChung";
            this.tabChung.Padding = new System.Windows.Forms.Padding(3);
            this.tabChung.Size = new System.Drawing.Size(507, 298);
            this.tabChung.TabIndex = 0;
            this.tabChung.Text = "Chung";
            this.tabChung.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Controls.Add(this.btnMayInDigi);
            this.flowLayoutPanel1.Controls.Add(this.btnQLyToInMayDigi);
            this.flowLayoutPanel1.Controls.Add(this.btnBangGiaInNhanh);
            this.flowLayoutPanel1.Controls.Add(this.btnKhoSanPham);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(501, 292);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnMayInDigi
            // 
            this.btnMayInDigi.Location = new System.Drawing.Point(3, 3);
            this.btnMayInDigi.Name = "btnMayInDigi";
            this.btnMayInDigi.Size = new System.Drawing.Size(92, 37);
            this.btnMayInDigi.TabIndex = 9;
            this.btnMayInDigi.Text = "Máy In Digital";
            this.btnMayInDigi.UseVisualStyleBackColor = true;
            this.btnMayInDigi.Click += new System.EventHandler(this.btnMayInDigi_Click);
            // 
            // btnQLyToInMayDigi
            // 
            this.btnQLyToInMayDigi.Location = new System.Drawing.Point(101, 3);
            this.btnQLyToInMayDigi.Name = "btnQLyToInMayDigi";
            this.btnQLyToInMayDigi.Size = new System.Drawing.Size(92, 37);
            this.btnQLyToInMayDigi.TabIndex = 10;
            this.btnQLyToInMayDigi.Text = "Tờ in máy Digital";
            this.btnQLyToInMayDigi.UseVisualStyleBackColor = true;
            this.btnQLyToInMayDigi.Click += new System.EventHandler(this.btnQLyToInMayDigi_Click);
            // 
            // btnBangGiaInNhanh
            // 
            this.btnBangGiaInNhanh.Location = new System.Drawing.Point(199, 3);
            this.btnBangGiaInNhanh.Name = "btnBangGiaInNhanh";
            this.btnBangGiaInNhanh.Size = new System.Drawing.Size(92, 37);
            this.btnBangGiaInNhanh.TabIndex = 12;
            this.btnBangGiaInNhanh.Text = "Bảng giá In nhanh";
            this.btnBangGiaInNhanh.UseVisualStyleBackColor = true;
            this.btnBangGiaInNhanh.Click += new System.EventHandler(this.btnBangGiaInNhanh_Click);
            // 
            // btnKhoSanPham
            // 
            this.btnKhoSanPham.Location = new System.Drawing.Point(297, 3);
            this.btnKhoSanPham.Name = "btnKhoSanPham";
            this.btnKhoSanPham.Size = new System.Drawing.Size(92, 37);
            this.btnKhoSanPham.TabIndex = 11;
            this.btnKhoSanPham.Text = "Khổ Sản phẩm";
            this.btnKhoSanPham.UseVisualStyleBackColor = true;
            this.btnKhoSanPham.Click += new System.EventHandler(this.btnKhoSanPham_Click);
            // 
            // tabNgVatLieu
            // 
            this.tabNgVatLieu.Controls.Add(this.flowLayoutPanel4);
            this.tabNgVatLieu.Location = new System.Drawing.Point(4, 22);
            this.tabNgVatLieu.Name = "tabNgVatLieu";
            this.tabNgVatLieu.Size = new System.Drawing.Size(418, 207);
            this.tabNgVatLieu.TabIndex = 3;
            this.tabNgVatLieu.Text = "Nguyên liệu";
            this.tabNgVatLieu.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel4.Controls.Add(this.btnQuanLyDanhMucGiay);
            this.flowLayoutPanel4.Controls.Add(this.btnQuanLyGiay);
            this.flowLayoutPanel4.Controls.Add(this.btnLoiNhuanGiay);
            this.flowLayoutPanel4.Controls.Add(this.btnBangGiaGiay);
            this.flowLayoutPanel4.Controls.Add(this.btnNhuEpKim);
            this.flowLayoutPanel4.Controls.Add(this.btnQuanLyLoXo);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(418, 207);
            this.flowLayoutPanel4.TabIndex = 3;
            // 
            // btnQuanLyDanhMucGiay
            // 
            this.btnQuanLyDanhMucGiay.Location = new System.Drawing.Point(3, 3);
            this.btnQuanLyDanhMucGiay.Name = "btnQuanLyDanhMucGiay";
            this.btnQuanLyDanhMucGiay.Size = new System.Drawing.Size(92, 37);
            this.btnQuanLyDanhMucGiay.TabIndex = 10;
            this.btnQuanLyDanhMucGiay.Text = "Q. Lý D. Mục Giấy";
            this.btnQuanLyDanhMucGiay.UseVisualStyleBackColor = true;
            this.btnQuanLyDanhMucGiay.Click += new System.EventHandler(this.mnuQuanLy_DanhMuc_Click);
            // 
            // btnQuanLyGiay
            // 
            this.btnQuanLyGiay.Location = new System.Drawing.Point(101, 3);
            this.btnQuanLyGiay.Name = "btnQuanLyGiay";
            this.btnQuanLyGiay.Size = new System.Drawing.Size(92, 37);
            this.btnQuanLyGiay.TabIndex = 11;
            this.btnQuanLyGiay.Text = "Q. Lý  Giấy";
            this.btnQuanLyGiay.UseVisualStyleBackColor = true;
            this.btnQuanLyGiay.Click += new System.EventHandler(this.btnQuanLyGiay_Click);
            // 
            // btnLoiNhuanGiay
            // 
            this.btnLoiNhuanGiay.Location = new System.Drawing.Point(199, 3);
            this.btnLoiNhuanGiay.Name = "btnLoiNhuanGiay";
            this.btnLoiNhuanGiay.Size = new System.Drawing.Size(92, 37);
            this.btnLoiNhuanGiay.TabIndex = 9;
            this.btnLoiNhuanGiay.Text = "Lợi nhuận giấy";
            this.btnLoiNhuanGiay.UseVisualStyleBackColor = true;
            this.btnLoiNhuanGiay.Click += new System.EventHandler(this.btnLoiNhuanGiay_Click);
            // 
            // btnBangGiaGiay
            // 
            this.btnBangGiaGiay.Location = new System.Drawing.Point(297, 3);
            this.btnBangGiaGiay.Name = "btnBangGiaGiay";
            this.btnBangGiaGiay.Size = new System.Drawing.Size(92, 37);
            this.btnBangGiaGiay.TabIndex = 12;
            this.btnBangGiaGiay.Text = "Bảng giá Giấy";
            this.btnBangGiaGiay.UseVisualStyleBackColor = true;
            this.btnBangGiaGiay.Click += new System.EventHandler(this.btnBangGiaGiay_Click);
            // 
            // btnNhuEpKim
            // 
            this.btnNhuEpKim.Location = new System.Drawing.Point(3, 46);
            this.btnNhuEpKim.Name = "btnNhuEpKim";
            this.btnNhuEpKim.Size = new System.Drawing.Size(92, 37);
            this.btnNhuEpKim.TabIndex = 13;
            this.btnNhuEpKim.Text = "Nhũ Ép kim";
            this.btnNhuEpKim.UseVisualStyleBackColor = true;
            this.btnNhuEpKim.Click += new System.EventHandler(this.btnNhuEpKim_Click);
            // 
            // btnQuanLyLoXo
            // 
            this.btnQuanLyLoXo.Location = new System.Drawing.Point(101, 46);
            this.btnQuanLyLoXo.Name = "btnQuanLyLoXo";
            this.btnQuanLyLoXo.Size = new System.Drawing.Size(92, 37);
            this.btnQuanLyLoXo.TabIndex = 14;
            this.btnQuanLyLoXo.Text = "Lò xo Đóng cuốn";
            this.btnQuanLyLoXo.UseVisualStyleBackColor = true;
            this.btnQuanLyLoXo.Click += new System.EventHandler(this.btnQuanLyLoXo_Click);
            // 
            // tabThanhPham
            // 
            this.tabThanhPham.Controls.Add(this.flowLayoutPanel3);
            this.tabThanhPham.Location = new System.Drawing.Point(4, 22);
            this.tabThanhPham.Name = "tabThanhPham";
            this.tabThanhPham.Size = new System.Drawing.Size(507, 298);
            this.tabThanhPham.TabIndex = 2;
            this.tabThanhPham.Text = "Thành phẩm";
            this.tabThanhPham.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel3.Controls.Add(this.btnCanPhu);
            this.flowLayoutPanel3.Controls.Add(this.btnCanGap);
            this.flowLayoutPanel3.Controls.Add(this.btnQuanLy_DongCuon);
            this.flowLayoutPanel3.Controls.Add(this.btnEpKim);
            this.flowLayoutPanel3.Controls.Add(this.btnQuanLy_DongCuonMP);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(507, 298);
            this.flowLayoutPanel3.TabIndex = 3;
            // 
            // btnCanPhu
            // 
            this.btnCanPhu.Location = new System.Drawing.Point(3, 3);
            this.btnCanPhu.Name = "btnCanPhu";
            this.btnCanPhu.Size = new System.Drawing.Size(92, 37);
            this.btnCanPhu.TabIndex = 6;
            this.btnCanPhu.Text = "Cán phủ";
            this.btnCanPhu.UseVisualStyleBackColor = true;
            this.btnCanPhu.Click += new System.EventHandler(this.btnCanPhu_Click);
            // 
            // btnCanGap
            // 
            this.btnCanGap.Location = new System.Drawing.Point(101, 3);
            this.btnCanGap.Name = "btnCanGap";
            this.btnCanGap.Size = new System.Drawing.Size(92, 37);
            this.btnCanGap.TabIndex = 7;
            this.btnCanGap.Text = "Cấn gấp";
            this.btnCanGap.UseVisualStyleBackColor = true;
            this.btnCanGap.Click += new System.EventHandler(this.btnCanGap_Click);
            // 
            // btnQuanLy_DongCuon
            // 
            this.btnQuanLy_DongCuon.Location = new System.Drawing.Point(199, 3);
            this.btnQuanLy_DongCuon.Name = "btnQuanLy_DongCuon";
            this.btnQuanLy_DongCuon.Size = new System.Drawing.Size(92, 37);
            this.btnQuanLy_DongCuon.TabIndex = 4;
            this.btnQuanLy_DongCuon.Text = "Đóng cuốn";
            this.btnQuanLy_DongCuon.UseVisualStyleBackColor = true;
            this.btnQuanLy_DongCuon.Click += new System.EventHandler(this.btnQuanLy_DongCuon_Click);
            // 
            // btnEpKim
            // 
            this.btnEpKim.Location = new System.Drawing.Point(297, 3);
            this.btnEpKim.Name = "btnEpKim";
            this.btnEpKim.Size = new System.Drawing.Size(92, 37);
            this.btnEpKim.TabIndex = 8;
            this.btnEpKim.Text = "Ép kim";
            this.btnEpKim.UseVisualStyleBackColor = true;
            this.btnEpKim.Click += new System.EventHandler(this.btnEpKim_Click);
            // 
            // btnQuanLy_DongCuonMP
            // 
            this.btnQuanLy_DongCuonMP.Location = new System.Drawing.Point(395, 3);
            this.btnQuanLy_DongCuonMP.Name = "btnQuanLy_DongCuonMP";
            this.btnQuanLy_DongCuonMP.Size = new System.Drawing.Size(92, 37);
            this.btnQuanLy_DongCuonMP.TabIndex = 9;
            this.btnQuanLy_DongCuonMP.Text = "Đ. Cuốn Mở phẳng";
            this.btnQuanLy_DongCuonMP.UseVisualStyleBackColor = true;
            this.btnQuanLy_DongCuonMP.Click += new System.EventHandler(this.btnQuanLy_DongCuonMP_Click);
            // 
            // NhapLieuMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 332);
            this.Controls.Add(this.tabCtrl);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NhapLieuMainForm";
            this.Text = "Nhập dữ liệu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.NhapLieuMainForm_Load);
            this.Resize += new System.EventHandler(this.NhapLieuMainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.tabCtrl.ResumeLayout(false);
            this.tabChung.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabNgVatLieu.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.tabThanhPham.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabChung;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnMayInDigi;
        private System.Windows.Forms.Button btnQLyToInMayDigi;
        private System.Windows.Forms.Button btnBangGiaInNhanh;
        private System.Windows.Forms.Button btnKhoSanPham;
        private System.Windows.Forms.TabPage tabNgVatLieu;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button btnQuanLyDanhMucGiay;
        private System.Windows.Forms.Button btnQuanLyGiay;
        private System.Windows.Forms.Button btnLoiNhuanGiay;
        private System.Windows.Forms.Button btnBangGiaGiay;
        private System.Windows.Forms.Button btnNhuEpKim;
        private System.Windows.Forms.Button btnQuanLyLoXo;
        private System.Windows.Forms.TabPage tabThanhPham;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnCanPhu;
        private System.Windows.Forms.Button btnCanGap;
        private System.Windows.Forms.Button btnQuanLy_DongCuon;
        private System.Windows.Forms.Button btnEpKim;
        private System.Windows.Forms.TextBox txtTenNguoiDung;
        private System.Windows.Forms.Label lblNguoiDung;
        private System.Windows.Forms.Button btnQuanLy_DongCuonMP;

    }
}

