namespace TinhGiaInNhapLieu
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
            this.btnBangGiaDanhThiep = new System.Windows.Forms.Button();
            this.btnBangGiaTheNhua = new System.Windows.Forms.Button();
            this.tabNgVatLieu = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuanLyDanhMucGiay = new System.Windows.Forms.Button();
            this.btnQuanLyGiay = new System.Windows.Forms.Button();
            this.btnLoiNhuanGiay = new System.Windows.Forms.Button();
            this.btnBangGiaGiay = new System.Windows.Forms.Button();
            this.btnNhuEpKim = new System.Windows.Forms.Button();
            this.btnQuanLy_LoXo = new System.Windows.Forms.Button();
            this.btnQuanLy_ToBoiBiaCung = new System.Windows.Forms.Button();
            this.btnQuanLy_ToLotDongMoPhang = new System.Windows.Forms.Button();
            this.tabThanhPham = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCanPhu = new System.Windows.Forms.Button();
            this.btnCanGap = new System.Windows.Forms.Button();
            this.btnQuanLy_DongCuon = new System.Windows.Forms.Button();
            this.btnEpKim = new System.Windows.Forms.Button();
            this.btnQuanLy_DCuonMP = new System.Windows.Forms.Button();
            this.btnQuanLy_CatDecal = new System.Windows.Forms.Button();
            this.btnQuanLy_BoiBiaCung = new System.Windows.Forms.Button();
            this.btnQuanLy_DCuonLXo = new System.Windows.Forms.Button();
            this.tabTuyChon = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGiaTuyChonDanhThiep = new System.Windows.Forms.Button();
            this.btnGiaTuyChonTheNhua = new System.Windows.Forms.Button();
            this.tabNiemYetGia = new System.Windows.Forms.TabPage();
            this.btnNY_GiaInNhanh = new System.Windows.Forms.Button();
            this.btnQuanLyBangGia = new System.Windows.Forms.Button();
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
            this.tabTuyChon.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tabNiemYetGia.SuspendLayout();
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
            this.btnDong.Location = new System.Drawing.Point(174, 6);
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
            this.tabCtrl.Controls.Add(this.tabTuyChon);
            this.tabCtrl.Controls.Add(this.tabNiemYetGia);
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
            this.tabChung.Size = new System.Drawing.Size(418, 207);
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
            this.flowLayoutPanel1.Controls.Add(this.btnBangGiaDanhThiep);
            this.flowLayoutPanel1.Controls.Add(this.btnBangGiaTheNhua);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(412, 201);
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
            // btnBangGiaDanhThiep
            // 
            this.btnBangGiaDanhThiep.Location = new System.Drawing.Point(3, 46);
            this.btnBangGiaDanhThiep.Name = "btnBangGiaDanhThiep";
            this.btnBangGiaDanhThiep.Size = new System.Drawing.Size(92, 37);
            this.btnBangGiaDanhThiep.TabIndex = 13;
            this.btnBangGiaDanhThiep.Text = "Bảng giá Danh thiếp";
            this.btnBangGiaDanhThiep.UseVisualStyleBackColor = true;
            this.btnBangGiaDanhThiep.Click += new System.EventHandler(this.btnBangGiaDanhThiep_Click);
            // 
            // btnBangGiaTheNhua
            // 
            this.btnBangGiaTheNhua.Location = new System.Drawing.Point(101, 46);
            this.btnBangGiaTheNhua.Name = "btnBangGiaTheNhua";
            this.btnBangGiaTheNhua.Size = new System.Drawing.Size(92, 37);
            this.btnBangGiaTheNhua.TabIndex = 14;
            this.btnBangGiaTheNhua.Text = "Bảng giá Thẻ nhựa";
            this.btnBangGiaTheNhua.UseVisualStyleBackColor = true;
            this.btnBangGiaTheNhua.Click += new System.EventHandler(this.btnBangGiaTheNhua_Click);
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
            this.flowLayoutPanel4.Controls.Add(this.btnQuanLy_LoXo);
            this.flowLayoutPanel4.Controls.Add(this.btnQuanLy_ToBoiBiaCung);
            this.flowLayoutPanel4.Controls.Add(this.btnQuanLy_ToLotDongMoPhang);
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
            // btnQuanLy_LoXo
            // 
            this.btnQuanLy_LoXo.Location = new System.Drawing.Point(101, 46);
            this.btnQuanLy_LoXo.Name = "btnQuanLy_LoXo";
            this.btnQuanLy_LoXo.Size = new System.Drawing.Size(92, 37);
            this.btnQuanLy_LoXo.TabIndex = 14;
            this.btnQuanLy_LoXo.Text = "Lò xo Đóng cuốn";
            this.btnQuanLy_LoXo.UseVisualStyleBackColor = true;
            this.btnQuanLy_LoXo.Click += new System.EventHandler(this.btnQuanLyLoXo_Click);
            // 
            // btnQuanLy_ToBoiBiaCung
            // 
            this.btnQuanLy_ToBoiBiaCung.Location = new System.Drawing.Point(199, 46);
            this.btnQuanLy_ToBoiBiaCung.Name = "btnQuanLy_ToBoiBiaCung";
            this.btnQuanLy_ToBoiBiaCung.Size = new System.Drawing.Size(92, 37);
            this.btnQuanLy_ToBoiBiaCung.TabIndex = 15;
            this.btnQuanLy_ToBoiBiaCung.Text = "Tờ bồi Bìa cứng";
            this.btnQuanLy_ToBoiBiaCung.UseVisualStyleBackColor = true;
            this.btnQuanLy_ToBoiBiaCung.Click += new System.EventHandler(this.btnQuanLy_ToBoiBiaCung_Click);
            // 
            // btnQuanLy_ToLotDongMoPhang
            // 
            this.btnQuanLy_ToLotDongMoPhang.Location = new System.Drawing.Point(297, 46);
            this.btnQuanLy_ToLotDongMoPhang.Name = "btnQuanLy_ToLotDongMoPhang";
            this.btnQuanLy_ToLotDongMoPhang.Size = new System.Drawing.Size(92, 37);
            this.btnQuanLy_ToLotDongMoPhang.TabIndex = 16;
            this.btnQuanLy_ToLotDongMoPhang.Text = "Tờ lót ĐCMP";
            this.btnQuanLy_ToLotDongMoPhang.UseVisualStyleBackColor = true;
            this.btnQuanLy_ToLotDongMoPhang.Click += new System.EventHandler(this.btnQuanLy_ToLotDongMoPhang_Click);
            // 
            // tabThanhPham
            // 
            this.tabThanhPham.Controls.Add(this.flowLayoutPanel3);
            this.tabThanhPham.Location = new System.Drawing.Point(4, 22);
            this.tabThanhPham.Name = "tabThanhPham";
            this.tabThanhPham.Size = new System.Drawing.Size(418, 207);
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
            this.flowLayoutPanel3.Controls.Add(this.btnQuanLy_DCuonMP);
            this.flowLayoutPanel3.Controls.Add(this.btnQuanLy_CatDecal);
            this.flowLayoutPanel3.Controls.Add(this.btnQuanLy_BoiBiaCung);
            this.flowLayoutPanel3.Controls.Add(this.btnQuanLy_DCuonLXo);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(418, 207);
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
            // btnQuanLy_DCuonMP
            // 
            this.btnQuanLy_DCuonMP.Location = new System.Drawing.Point(3, 46);
            this.btnQuanLy_DCuonMP.Name = "btnQuanLy_DCuonMP";
            this.btnQuanLy_DCuonMP.Size = new System.Drawing.Size(92, 37);
            this.btnQuanLy_DCuonMP.TabIndex = 9;
            this.btnQuanLy_DCuonMP.Text = "Đ. Cuốn Mở phẳng";
            this.btnQuanLy_DCuonMP.UseVisualStyleBackColor = true;
            this.btnQuanLy_DCuonMP.Click += new System.EventHandler(this.btnQuanLy_DongCuonMP_Click);
            // 
            // btnQuanLy_CatDecal
            // 
            this.btnQuanLy_CatDecal.Location = new System.Drawing.Point(101, 46);
            this.btnQuanLy_CatDecal.Name = "btnQuanLy_CatDecal";
            this.btnQuanLy_CatDecal.Size = new System.Drawing.Size(92, 37);
            this.btnQuanLy_CatDecal.TabIndex = 10;
            this.btnQuanLy_CatDecal.Text = "Cắt Decal";
            this.btnQuanLy_CatDecal.UseVisualStyleBackColor = true;
            this.btnQuanLy_CatDecal.Click += new System.EventHandler(this.btnQuanLy_CatDecal_Click);
            // 
            // btnQuanLy_BoiBiaCung
            // 
            this.btnQuanLy_BoiBiaCung.Location = new System.Drawing.Point(199, 46);
            this.btnQuanLy_BoiBiaCung.Name = "btnQuanLy_BoiBiaCung";
            this.btnQuanLy_BoiBiaCung.Size = new System.Drawing.Size(92, 37);
            this.btnQuanLy_BoiBiaCung.TabIndex = 11;
            this.btnQuanLy_BoiBiaCung.Text = "Bồi bìa cứng";
            this.btnQuanLy_BoiBiaCung.UseVisualStyleBackColor = true;
            this.btnQuanLy_BoiBiaCung.Click += new System.EventHandler(this.btnQuanLy_BoiBiaCung_Click);
            // 
            // btnQuanLy_DCuonLXo
            // 
            this.btnQuanLy_DCuonLXo.Location = new System.Drawing.Point(297, 46);
            this.btnQuanLy_DCuonLXo.Name = "btnQuanLy_DCuonLXo";
            this.btnQuanLy_DCuonLXo.Size = new System.Drawing.Size(92, 37);
            this.btnQuanLy_DCuonLXo.TabIndex = 12;
            this.btnQuanLy_DCuonLXo.Text = "Đ. Cuốn Lò xo";
            this.btnQuanLy_DCuonLXo.UseVisualStyleBackColor = true;
            this.btnQuanLy_DCuonLXo.Click += new System.EventHandler(this.btnQuanLy_DCuonLXo_Click);
            // 
            // tabTuyChon
            // 
            this.tabTuyChon.Controls.Add(this.flowLayoutPanel2);
            this.tabTuyChon.Location = new System.Drawing.Point(4, 22);
            this.tabTuyChon.Name = "tabTuyChon";
            this.tabTuyChon.Padding = new System.Windows.Forms.Padding(3);
            this.tabTuyChon.Size = new System.Drawing.Size(418, 207);
            this.tabTuyChon.TabIndex = 4;
            this.tabTuyChon.Text = "Tùy chọn";
            this.tabTuyChon.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel2.Controls.Add(this.btnGiaTuyChonDanhThiep);
            this.flowLayoutPanel2.Controls.Add(this.btnGiaTuyChonTheNhua);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(412, 201);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // btnGiaTuyChonDanhThiep
            // 
            this.btnGiaTuyChonDanhThiep.Location = new System.Drawing.Point(3, 3);
            this.btnGiaTuyChonDanhThiep.Name = "btnGiaTuyChonDanhThiep";
            this.btnGiaTuyChonDanhThiep.Size = new System.Drawing.Size(92, 37);
            this.btnGiaTuyChonDanhThiep.TabIndex = 6;
            this.btnGiaTuyChonDanhThiep.Text = "Giá Tùy chọn danh thiếp";
            this.btnGiaTuyChonDanhThiep.UseVisualStyleBackColor = true;
            this.btnGiaTuyChonDanhThiep.Click += new System.EventHandler(this.btnGiaTuyChonDanhThiep_Click);
            // 
            // btnGiaTuyChonTheNhua
            // 
            this.btnGiaTuyChonTheNhua.Location = new System.Drawing.Point(101, 3);
            this.btnGiaTuyChonTheNhua.Name = "btnGiaTuyChonTheNhua";
            this.btnGiaTuyChonTheNhua.Size = new System.Drawing.Size(92, 37);
            this.btnGiaTuyChonTheNhua.TabIndex = 7;
            this.btnGiaTuyChonTheNhua.Text = "Giá Tùy chọn thẻ nhựa";
            this.btnGiaTuyChonTheNhua.UseVisualStyleBackColor = true;
            this.btnGiaTuyChonTheNhua.Click += new System.EventHandler(this.btnGiaTuyChonTheNhua_Click);
            // 
            // tabNiemYetGia
            // 
            this.tabNiemYetGia.Controls.Add(this.btnNY_GiaInNhanh);
            this.tabNiemYetGia.Controls.Add(this.btnQuanLyBangGia);
            this.tabNiemYetGia.Location = new System.Drawing.Point(4, 22);
            this.tabNiemYetGia.Name = "tabNiemYetGia";
            this.tabNiemYetGia.Padding = new System.Windows.Forms.Padding(3);
            this.tabNiemYetGia.Size = new System.Drawing.Size(418, 207);
            this.tabNiemYetGia.TabIndex = 5;
            this.tabNiemYetGia.Text = "Niêm yết giá";
            this.tabNiemYetGia.UseVisualStyleBackColor = true;
            // 
            // btnNY_GiaInNhanh
            // 
            this.btnNY_GiaInNhanh.Location = new System.Drawing.Point(119, 40);
            this.btnNY_GiaInNhanh.Name = "btnNY_GiaInNhanh";
            this.btnNY_GiaInNhanh.Size = new System.Drawing.Size(92, 37);
            this.btnNY_GiaInNhanh.TabIndex = 10;
            this.btnNY_GiaInNhanh.Text = "Niêm yêt Giá in nhanh";
            this.btnNY_GiaInNhanh.UseVisualStyleBackColor = true;
            this.btnNY_GiaInNhanh.Click += new System.EventHandler(this.btnNY_GiaInNhanh_Click);
            // 
            // btnQuanLyBangGia
            // 
            this.btnQuanLyBangGia.Location = new System.Drawing.Point(21, 6);
            this.btnQuanLyBangGia.Name = "btnQuanLyBangGia";
            this.btnQuanLyBangGia.Size = new System.Drawing.Size(92, 37);
            this.btnQuanLyBangGia.TabIndex = 11;
            this.btnQuanLyBangGia.Text = "Các loại Bảng giá";
            this.btnQuanLyBangGia.UseVisualStyleBackColor = true;
            this.btnQuanLyBangGia.Click += new System.EventHandler(this.btnQuanLyBangGia_Click);
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
            this.tabTuyChon.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tabNiemYetGia.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnQuanLy_LoXo;
        private System.Windows.Forms.TabPage tabThanhPham;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnCanPhu;
        private System.Windows.Forms.Button btnCanGap;
        private System.Windows.Forms.Button btnQuanLy_DongCuon;
        private System.Windows.Forms.Button btnEpKim;
        private System.Windows.Forms.TextBox txtTenNguoiDung;
        private System.Windows.Forms.Label lblNguoiDung;
        private System.Windows.Forms.Button btnQuanLy_DCuonMP;
        private System.Windows.Forms.Button btnQuanLy_CatDecal;
        private System.Windows.Forms.Button btnQuanLy_BoiBiaCung;
        private System.Windows.Forms.Button btnQuanLy_ToBoiBiaCung;
        private System.Windows.Forms.Button btnQuanLy_ToLotDongMoPhang;
        private System.Windows.Forms.TabPage tabTuyChon;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnGiaTuyChonDanhThiep;
        private System.Windows.Forms.Button btnGiaTuyChonTheNhua;
        private System.Windows.Forms.Button btnBangGiaDanhThiep;
        private System.Windows.Forms.Button btnBangGiaTheNhua;
        private System.Windows.Forms.Button btnQuanLy_DCuonLXo;
        private System.Windows.Forms.TabPage tabNiemYetGia;
        private System.Windows.Forms.Button btnNY_GiaInNhanh;
        private System.Windows.Forms.Button btnQuanLyBangGia;

    }
}

