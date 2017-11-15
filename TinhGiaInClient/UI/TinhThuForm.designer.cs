namespace TinhGiaInClient.UI
{
    partial class TinhThuForm
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
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblChonHangKH = new System.Windows.Forms.Label();
            this.cboHangKH = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGiaInNhanh = new System.Windows.Forms.Button();
            this.btnGiaGiayIn = new System.Windows.Forms.Button();
            this.btnTinhThu_CanPhu = new System.Windows.Forms.Button();
            this.btnTinhThu_CanGap = new System.Windows.Forms.Button();
            this.btnTinhThu_DongCuon = new System.Windows.Forms.Button();
            this.btnTinhThu_EpKim = new System.Windows.Forms.Button();
            this.btnTinhThu_GiaDongCuonLoXo = new System.Windows.Forms.Button();
            this.btnTinhThu_DongCuonMoPhang = new System.Windows.Forms.Button();
            this.btnTinhThu_CatDecal = new System.Windows.Forms.Button();
            this.btnTinhThu_BoiBiaCung = new System.Windows.Forms.Button();
            this.btnSoSanhGiaInNhanh = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnSoSanhOffsetNhanh = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(169, 6);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnDong);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 287);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(412, 39);
            this.pnlBottom.TabIndex = 6;
            // 
            // lblChonHangKH
            // 
            this.lblChonHangKH.AutoSize = true;
            this.lblChonHangKH.Location = new System.Drawing.Point(12, 13);
            this.lblChonHangKH.Name = "lblChonHangKH";
            this.lblChonHangKH.Size = new System.Drawing.Size(79, 13);
            this.lblChonHangKH.TabIndex = 5;
            this.lblChonHangKH.Text = "Chọn Hạng KH";
            // 
            // cboHangKH
            // 
            this.cboHangKH.FormattingEnabled = true;
            this.cboHangKH.Location = new System.Drawing.Point(97, 10);
            this.cboHangKH.Name = "cboHangKH";
            this.cboHangKH.Size = new System.Drawing.Size(121, 21);
            this.cboHangKH.TabIndex = 4;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel2.Controls.Add(this.btnGiaInNhanh);
            this.flowLayoutPanel2.Controls.Add(this.btnGiaGiayIn);
            this.flowLayoutPanel2.Controls.Add(this.btnTinhThu_CanPhu);
            this.flowLayoutPanel2.Controls.Add(this.btnTinhThu_CanGap);
            this.flowLayoutPanel2.Controls.Add(this.btnTinhThu_DongCuon);
            this.flowLayoutPanel2.Controls.Add(this.btnTinhThu_EpKim);
            this.flowLayoutPanel2.Controls.Add(this.btnTinhThu_GiaDongCuonLoXo);
            this.flowLayoutPanel2.Controls.Add(this.btnTinhThu_DongCuonMoPhang);
            this.flowLayoutPanel2.Controls.Add(this.btnTinhThu_CatDecal);
            this.flowLayoutPanel2.Controls.Add(this.btnTinhThu_BoiBiaCung);
            this.flowLayoutPanel2.Controls.Add(this.btnSoSanhGiaInNhanh);
            this.flowLayoutPanel2.Controls.Add(this.btnSoSanhOffsetNhanh);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 36);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(412, 251);
            this.flowLayoutPanel2.TabIndex = 3;
            this.flowLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel2_Paint);
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
            // btnGiaGiayIn
            // 
            this.btnGiaGiayIn.Location = new System.Drawing.Point(101, 3);
            this.btnGiaGiayIn.Name = "btnGiaGiayIn";
            this.btnGiaGiayIn.Size = new System.Drawing.Size(92, 37);
            this.btnGiaGiayIn.TabIndex = 14;
            this.btnGiaGiayIn.Text = "Giá giấy in";
            this.btnGiaGiayIn.UseVisualStyleBackColor = true;
            this.btnGiaGiayIn.Click += new System.EventHandler(this.btnGiaGiayIn_Click);
            // 
            // btnTinhThu_CanPhu
            // 
            this.btnTinhThu_CanPhu.Location = new System.Drawing.Point(199, 3);
            this.btnTinhThu_CanPhu.Name = "btnTinhThu_CanPhu";
            this.btnTinhThu_CanPhu.Size = new System.Drawing.Size(92, 37);
            this.btnTinhThu_CanPhu.TabIndex = 6;
            this.btnTinhThu_CanPhu.Text = "Giá Cán phủ";
            this.btnTinhThu_CanPhu.UseVisualStyleBackColor = true;
            this.btnTinhThu_CanPhu.Click += new System.EventHandler(this.btnTinhThu_CanPhu_Click);
            // 
            // btnTinhThu_CanGap
            // 
            this.btnTinhThu_CanGap.Location = new System.Drawing.Point(297, 3);
            this.btnTinhThu_CanGap.Name = "btnTinhThu_CanGap";
            this.btnTinhThu_CanGap.Size = new System.Drawing.Size(92, 37);
            this.btnTinhThu_CanGap.TabIndex = 7;
            this.btnTinhThu_CanGap.Text = "Giá Cấn gấp";
            this.btnTinhThu_CanGap.UseVisualStyleBackColor = true;
            this.btnTinhThu_CanGap.Click += new System.EventHandler(this.btnTinhThu_CanGap_Click);
            // 
            // btnTinhThu_DongCuon
            // 
            this.btnTinhThu_DongCuon.Location = new System.Drawing.Point(3, 46);
            this.btnTinhThu_DongCuon.Name = "btnTinhThu_DongCuon";
            this.btnTinhThu_DongCuon.Size = new System.Drawing.Size(92, 37);
            this.btnTinhThu_DongCuon.TabIndex = 4;
            this.btnTinhThu_DongCuon.Text = "Giá Đóng cuốn";
            this.btnTinhThu_DongCuon.UseVisualStyleBackColor = true;
            this.btnTinhThu_DongCuon.Click += new System.EventHandler(this.btnTinhThu_DongCuon_Click);
            // 
            // btnTinhThu_EpKim
            // 
            this.btnTinhThu_EpKim.Location = new System.Drawing.Point(101, 46);
            this.btnTinhThu_EpKim.Name = "btnTinhThu_EpKim";
            this.btnTinhThu_EpKim.Size = new System.Drawing.Size(92, 37);
            this.btnTinhThu_EpKim.TabIndex = 8;
            this.btnTinhThu_EpKim.Text = "Giá Ép kim";
            this.btnTinhThu_EpKim.UseVisualStyleBackColor = true;
            this.btnTinhThu_EpKim.Click += new System.EventHandler(this.btnTinhThu_EpKim_Click);
            // 
            // btnTinhThu_GiaDongCuonLoXo
            // 
            this.btnTinhThu_GiaDongCuonLoXo.Location = new System.Drawing.Point(199, 46);
            this.btnTinhThu_GiaDongCuonLoXo.Name = "btnTinhThu_GiaDongCuonLoXo";
            this.btnTinhThu_GiaDongCuonLoXo.Size = new System.Drawing.Size(92, 37);
            this.btnTinhThu_GiaDongCuonLoXo.TabIndex = 10;
            this.btnTinhThu_GiaDongCuonLoXo.Text = "Đóng cuốn Lò xo";
            this.btnTinhThu_GiaDongCuonLoXo.UseVisualStyleBackColor = true;
            this.btnTinhThu_GiaDongCuonLoXo.Click += new System.EventHandler(this.btnTinhThu_GiaDongCuonLoXo_Click);
            // 
            // btnTinhThu_DongCuonMoPhang
            // 
            this.btnTinhThu_DongCuonMoPhang.Location = new System.Drawing.Point(297, 46);
            this.btnTinhThu_DongCuonMoPhang.Name = "btnTinhThu_DongCuonMoPhang";
            this.btnTinhThu_DongCuonMoPhang.Size = new System.Drawing.Size(92, 37);
            this.btnTinhThu_DongCuonMoPhang.TabIndex = 11;
            this.btnTinhThu_DongCuonMoPhang.Text = "Đóng cuốn Mở phẳng";
            this.btnTinhThu_DongCuonMoPhang.UseVisualStyleBackColor = true;
            this.btnTinhThu_DongCuonMoPhang.Click += new System.EventHandler(this.btnTinhThu_DongCuonMoPhang_Click);
            // 
            // btnTinhThu_CatDecal
            // 
            this.btnTinhThu_CatDecal.Location = new System.Drawing.Point(3, 89);
            this.btnTinhThu_CatDecal.Name = "btnTinhThu_CatDecal";
            this.btnTinhThu_CatDecal.Size = new System.Drawing.Size(92, 37);
            this.btnTinhThu_CatDecal.TabIndex = 12;
            this.btnTinhThu_CatDecal.Text = "Cắt Decal";
            this.btnTinhThu_CatDecal.UseVisualStyleBackColor = true;
            this.btnTinhThu_CatDecal.Click += new System.EventHandler(this.btnTinhThu_CatDecal_Click);
            // 
            // btnTinhThu_BoiBiaCung
            // 
            this.btnTinhThu_BoiBiaCung.Location = new System.Drawing.Point(101, 89);
            this.btnTinhThu_BoiBiaCung.Name = "btnTinhThu_BoiBiaCung";
            this.btnTinhThu_BoiBiaCung.Size = new System.Drawing.Size(92, 37);
            this.btnTinhThu_BoiBiaCung.TabIndex = 13;
            this.btnTinhThu_BoiBiaCung.Text = "Bồi Bìa cứng";
            this.btnTinhThu_BoiBiaCung.UseVisualStyleBackColor = true;
            this.btnTinhThu_BoiBiaCung.Click += new System.EventHandler(this.btnTinhThu_BoiBiaCung_Click);
            // 
            // btnSoSanhGiaInNhanh
            // 
            this.btnSoSanhGiaInNhanh.Location = new System.Drawing.Point(199, 89);
            this.btnSoSanhGiaInNhanh.Name = "btnSoSanhGiaInNhanh";
            this.btnSoSanhGiaInNhanh.Size = new System.Drawing.Size(92, 37);
            this.btnSoSanhGiaInNhanh.TabIndex = 15;
            this.btnSoSanhGiaInNhanh.Text = "So sánh giá In nhanh";
            this.btnSoSanhGiaInNhanh.UseVisualStyleBackColor = true;
            this.btnSoSanhGiaInNhanh.Click += new System.EventHandler(this.btnSoSanhGiaInNhanh_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblChonHangKH);
            this.pnlTop.Controls.Add(this.cboHangKH);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(412, 36);
            this.pnlTop.TabIndex = 5;
            // 
            // btnSoSanhOffsetNhanh
            // 
            this.btnSoSanhOffsetNhanh.Location = new System.Drawing.Point(297, 89);
            this.btnSoSanhOffsetNhanh.Name = "btnSoSanhOffsetNhanh";
            this.btnSoSanhOffsetNhanh.Size = new System.Drawing.Size(92, 37);
            this.btnSoSanhOffsetNhanh.TabIndex = 16;
            this.btnSoSanhOffsetNhanh.Text = "Offset vs Nhanh";
            this.btnSoSanhOffsetNhanh.UseVisualStyleBackColor = true;
            this.btnSoSanhOffsetNhanh.Click += new System.EventHandler(this.btnSoSanhOffsetNhanh_Click);
            // 
            // TinhThuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 326);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TinhThuForm";
            this.Text = "Nhập dữ liệu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClosing_Query);
            this.Load += new System.EventHandler(this.NhapLieuMainForm_Load);
            this.Resize += new System.EventHandler(this.NhapLieuMainForm_Resize);
            this.pnlBottom.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblChonHangKH;
        private System.Windows.Forms.ComboBox cboHangKH;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnGiaInNhanh;
        private System.Windows.Forms.Button btnTinhThu_CanPhu;
        private System.Windows.Forms.Button btnTinhThu_CanGap;
        private System.Windows.Forms.Button btnTinhThu_DongCuon;
        private System.Windows.Forms.Button btnTinhThu_EpKim;
        private System.Windows.Forms.Button btnTinhThu_GiaDongCuonLoXo;
        private System.Windows.Forms.Button btnTinhThu_DongCuonMoPhang;
        private System.Windows.Forms.Button btnTinhThu_CatDecal;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnTinhThu_BoiBiaCung;
        private System.Windows.Forms.Button btnGiaGiayIn;
        private System.Windows.Forms.Button btnSoSanhGiaInNhanh;
        private System.Windows.Forms.Button btnSoSanhOffsetNhanh;

    }
}

