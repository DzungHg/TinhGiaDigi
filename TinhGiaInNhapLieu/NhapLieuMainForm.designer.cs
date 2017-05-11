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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuanLyDanhMucGiay = new System.Windows.Forms.Button();
            this.btnQuanLyGiay = new System.Windows.Forms.Button();
            this.btnLoiNhuanGiay = new System.Windows.Forms.Button();
            this.btnBangGiaGiay = new System.Windows.Forms.Button();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabTinhThu = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.cboHangKH = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTinhThu_CanPhu = new System.Windows.Forms.Button();
            this.btnTinhThu_CanGap = new System.Windows.Forms.Button();
            this.btnTinhThu_DongCuon = new System.Windows.Forms.Button();
            this.btnTinhThu_EpKim = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnGiaInNhanh = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabCtrl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabTinhThu.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(480, 24);
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Controls.Add(this.btnQuanLyDanhMucGiay);
            this.flowLayoutPanel1.Controls.Add(this.btnQuanLyGiay);
            this.flowLayoutPanel1.Controls.Add(this.btnLoiNhuanGiay);
            this.flowLayoutPanel1.Controls.Add(this.btnBangGiaGiay);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(445, 293);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnQuanLyDanhMucGiay
            // 
            this.btnQuanLyDanhMucGiay.Location = new System.Drawing.Point(3, 3);
            this.btnQuanLyDanhMucGiay.Name = "btnQuanLyDanhMucGiay";
            this.btnQuanLyDanhMucGiay.Size = new System.Drawing.Size(92, 37);
            this.btnQuanLyDanhMucGiay.TabIndex = 6;
            this.btnQuanLyDanhMucGiay.Text = "Q. Lý D. Mục Giấy";
            this.btnQuanLyDanhMucGiay.UseVisualStyleBackColor = true;
            this.btnQuanLyDanhMucGiay.Click += new System.EventHandler(this.btnQuanLyDanhMucGiay_Click);
            // 
            // btnQuanLyGiay
            // 
            this.btnQuanLyGiay.Location = new System.Drawing.Point(101, 3);
            this.btnQuanLyGiay.Name = "btnQuanLyGiay";
            this.btnQuanLyGiay.Size = new System.Drawing.Size(92, 37);
            this.btnQuanLyGiay.TabIndex = 7;
            this.btnQuanLyGiay.Text = "Q. Lý  Giấy";
            this.btnQuanLyGiay.UseVisualStyleBackColor = true;
            this.btnQuanLyGiay.Click += new System.EventHandler(this.btnQuanLyGiay_Click);
            // 
            // btnLoiNhuanGiay
            // 
            this.btnLoiNhuanGiay.Location = new System.Drawing.Point(199, 3);
            this.btnLoiNhuanGiay.Name = "btnLoiNhuanGiay";
            this.btnLoiNhuanGiay.Size = new System.Drawing.Size(92, 37);
            this.btnLoiNhuanGiay.TabIndex = 4;
            this.btnLoiNhuanGiay.Text = "Lợi nhuận giấy";
            this.btnLoiNhuanGiay.UseVisualStyleBackColor = true;
            this.btnLoiNhuanGiay.Click += new System.EventHandler(this.btnPhoto_Click);
            // 
            // btnBangGiaGiay
            // 
            this.btnBangGiaGiay.Location = new System.Drawing.Point(297, 3);
            this.btnBangGiaGiay.Name = "btnBangGiaGiay";
            this.btnBangGiaGiay.Size = new System.Drawing.Size(92, 37);
            this.btnBangGiaGiay.TabIndex = 8;
            this.btnBangGiaGiay.Text = "Bảng giá Giấy";
            this.btnBangGiaGiay.UseVisualStyleBackColor = true;
            this.btnBangGiaGiay.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.tabPage1);
            this.tabCtrl.Controls.Add(this.tabTinhThu);
            this.tabCtrl.Location = new System.Drawing.Point(12, 27);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(459, 325);
            this.tabCtrl.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(451, 299);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Quản lý";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabTinhThu
            // 
            this.tabTinhThu.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabTinhThu.Controls.Add(this.label1);
            this.tabTinhThu.Controls.Add(this.cboHangKH);
            this.tabTinhThu.Controls.Add(this.flowLayoutPanel2);
            this.tabTinhThu.Location = new System.Drawing.Point(4, 22);
            this.tabTinhThu.Name = "tabTinhThu";
            this.tabTinhThu.Padding = new System.Windows.Forms.Padding(3);
            this.tabTinhThu.Size = new System.Drawing.Size(451, 299);
            this.tabTinhThu.TabIndex = 1;
            this.tabTinhThu.Text = "Tính thử";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Chọn Hạng KH";
            // 
            // cboHangKH
            // 
            this.cboHangKH.FormattingEnabled = true;
            this.cboHangKH.Location = new System.Drawing.Point(97, 13);
            this.cboHangKH.Name = "cboHangKH";
            this.cboHangKH.Size = new System.Drawing.Size(121, 21);
            this.cboHangKH.TabIndex = 4;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel2.Controls.Add(this.btnGiaInNhanh);
            this.flowLayoutPanel2.Controls.Add(this.btnTinhThu_CanPhu);
            this.flowLayoutPanel2.Controls.Add(this.btnTinhThu_CanGap);
            this.flowLayoutPanel2.Controls.Add(this.btnTinhThu_DongCuon);
            this.flowLayoutPanel2.Controls.Add(this.btnTinhThu_EpKim);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 40);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(445, 256);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // btnTinhThu_CanPhu
            // 
            this.btnTinhThu_CanPhu.Location = new System.Drawing.Point(101, 3);
            this.btnTinhThu_CanPhu.Name = "btnTinhThu_CanPhu";
            this.btnTinhThu_CanPhu.Size = new System.Drawing.Size(92, 37);
            this.btnTinhThu_CanPhu.TabIndex = 6;
            this.btnTinhThu_CanPhu.Text = "Giá Cán phủ";
            this.btnTinhThu_CanPhu.UseVisualStyleBackColor = true;
            this.btnTinhThu_CanPhu.Click += new System.EventHandler(this.btnTinhThu_CanPhu_Click);
            // 
            // btnTinhThu_CanGap
            // 
            this.btnTinhThu_CanGap.Location = new System.Drawing.Point(199, 3);
            this.btnTinhThu_CanGap.Name = "btnTinhThu_CanGap";
            this.btnTinhThu_CanGap.Size = new System.Drawing.Size(92, 37);
            this.btnTinhThu_CanGap.TabIndex = 7;
            this.btnTinhThu_CanGap.Text = "Giá Cấn gấp";
            this.btnTinhThu_CanGap.UseVisualStyleBackColor = true;
            this.btnTinhThu_CanGap.Click += new System.EventHandler(this.btnTinhThu_CanGap_Click);
            // 
            // btnTinhThu_DongCuon
            // 
            this.btnTinhThu_DongCuon.Location = new System.Drawing.Point(297, 3);
            this.btnTinhThu_DongCuon.Name = "btnTinhThu_DongCuon";
            this.btnTinhThu_DongCuon.Size = new System.Drawing.Size(92, 37);
            this.btnTinhThu_DongCuon.TabIndex = 4;
            this.btnTinhThu_DongCuon.Text = "Giá Đóng cuốn";
            this.btnTinhThu_DongCuon.UseVisualStyleBackColor = true;
            this.btnTinhThu_DongCuon.Click += new System.EventHandler(this.btnTinhThu_DongCuon_Click);
            // 
            // btnTinhThu_EpKim
            // 
            this.btnTinhThu_EpKim.Location = new System.Drawing.Point(3, 46);
            this.btnTinhThu_EpKim.Name = "btnTinhThu_EpKim";
            this.btnTinhThu_EpKim.Size = new System.Drawing.Size(92, 37);
            this.btnTinhThu_EpKim.TabIndex = 8;
            this.btnTinhThu_EpKim.Text = "Giá Ép kim";
            this.btnTinhThu_EpKim.UseVisualStyleBackColor = true;
            this.btnTinhThu_EpKim.Click += new System.EventHandler(this.btnTinhThu_EpKim_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(198, 358);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // btnGiaInNhanh
            // 
            this.btnGiaInNhanh.Location = new System.Drawing.Point(3, 3);
            this.btnGiaInNhanh.Name = "btnGiaInNhanh";
            this.btnGiaInNhanh.Size = new System.Drawing.Size(92, 37);
            this.btnGiaInNhanh.TabIndex = 9;
            this.btnGiaInNhanh.Text = "Giá In nhanh";
            this.btnGiaInNhanh.UseVisualStyleBackColor = true;
            this.btnGiaInNhanh.Click += new System.EventHandler(this.btnGiaInNhanh_Click);
            // 
            // NhapLieuMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 393);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tabCtrl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NhapLieuMainForm";
            this.Text = "Nhập dữ liệu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabCtrl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabTinhThu.ResumeLayout(false);
            this.tabTinhThu.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnLoiNhuanGiay;
        private System.Windows.Forms.Button btnQuanLyDanhMucGiay;
        private System.Windows.Forms.Button btnQuanLyGiay;
        private System.Windows.Forms.Button btnBangGiaGiay;
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabTinhThu;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnTinhThu_CanPhu;
        private System.Windows.Forms.Button btnTinhThu_CanGap;
        private System.Windows.Forms.Button btnTinhThu_DongCuon;
        private System.Windows.Forms.Button btnTinhThu_EpKim;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboHangKH;
        private System.Windows.Forms.Button btnGiaInNhanh;

    }
}

