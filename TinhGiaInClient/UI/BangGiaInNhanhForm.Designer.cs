namespace TinhGiaInClient.UI
{
    partial class BangGiaInNhanhForm
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
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.drpHangKH = new Telerik.WinControls.UI.RadDropDownList();
            this.btnDong = new Telerik.WinControls.UI.RadButton();
            this.txtDaySoLuong = new Telerik.WinControls.UI.RadTextBox();
            this.lblTieuDeDaySoLuong = new Telerik.WinControls.UI.RadLabel();
            this.btnLuuSoLuongMacDinh = new Telerik.WinControls.UI.RadButton();
            this.lstBangGiaInNhanh = new Telerik.WinControls.UI.RadListControl();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.lblDonViTinh = new Telerik.WinControls.UI.RadLabel();
            this.flowLayOut = new System.Windows.Forms.FlowLayoutPanel();
            this.lstSoLuongTinh = new Telerik.WinControls.UI.RadListControl();
            this.btnXoaBang = new Telerik.WinControls.UI.RadButton();
            this.btnRefreshDaySoLuong = new Telerik.WinControls.UI.RadButton();
            this.chkLuuSoLuong = new Telerik.WinControls.UI.RadCheckBox();
            this.txtNoiDungBangGia = new Telerik.WinControls.UI.RadTextBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpHangKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDaySoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTieuDeDaySoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLuuSoLuongMacDinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstBangGiaInNhanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDonViTinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstSoLuongTinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXoaBang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefreshDaySoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLuuSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDungBangGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(228, 12);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(167, 25);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "BẢNG GIÁ IN NHANH";
            // 
            // drpHangKH
            // 
            this.drpHangKH.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.drpHangKH.Location = new System.Drawing.Point(11, 86);
            this.drpHangKH.Name = "drpHangKH";
            this.drpHangKH.Size = new System.Drawing.Size(120, 20);
            this.drpHangKH.TabIndex = 4;
            this.drpHangKH.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.drpHangKH_SelectedIndexChanged);
            // 
            // btnDong
            // 
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Location = new System.Drawing.Point(273, 360);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 24);
            this.btnDong.TabIndex = 5;
            this.btnDong.Text = "Đóng";
            // 
            // txtDaySoLuong
            // 
            this.txtDaySoLuong.Location = new System.Drawing.Point(152, 84);
            this.txtDaySoLuong.Name = "txtDaySoLuong";
            this.txtDaySoLuong.Size = new System.Drawing.Size(329, 20);
            this.txtDaySoLuong.TabIndex = 6;
            this.txtDaySoLuong.TextChanged += new System.EventHandler(this.txtDaySoLuong_TextChanged);
            // 
            // lblTieuDeDaySoLuong
            // 
            this.lblTieuDeDaySoLuong.Location = new System.Drawing.Point(157, 62);
            this.lblTieuDeDaySoLuong.Name = "lblTieuDeDaySoLuong";
            this.lblTieuDeDaySoLuong.Size = new System.Drawing.Size(133, 18);
            this.lblTieuDeDaySoLuong.TabIndex = 7;
            this.lblTieuDeDaySoLuong.Text = "Dãy số lượng cần cách \";\"";
            // 
            // btnLuuSoLuongMacDinh
            // 
            this.btnLuuSoLuongMacDinh.Enabled = false;
            this.btnLuuSoLuongMacDinh.Location = new System.Drawing.Point(472, 52);
            this.btnLuuSoLuongMacDinh.Name = "btnLuuSoLuongMacDinh";
            this.btnLuuSoLuongMacDinh.Size = new System.Drawing.Size(110, 24);
            this.btnLuuSoLuongMacDinh.TabIndex = 9;
            this.btnLuuSoLuongMacDinh.Text = "Lưu lại Số lượng";
            this.btnLuuSoLuongMacDinh.Click += new System.EventHandler(this.btnLuuSoLuongMacDinh_Click);
            // 
            // lstBangGiaInNhanh
            // 
            this.lstBangGiaInNhanh.Location = new System.Drawing.Point(11, 110);
            this.lstBangGiaInNhanh.Name = "lstBangGiaInNhanh";
            this.lstBangGiaInNhanh.Size = new System.Drawing.Size(140, 107);
            this.lstBangGiaInNhanh.TabIndex = 10;
            this.lstBangGiaInNhanh.Text = "radListControl1";
            this.lstBangGiaInNhanh.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.lstDichVuThanhPham_SelectedIndexChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 62);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(120, 18);
            this.radLabel1.TabIndex = 3;
            this.radLabel1.Text = "Bảng giá theo hạng Kh";
            this.radLabel1.Click += new System.EventHandler(this.radLabel1_Click);
            // 
            // lblDonViTinh
            // 
            this.lblDonViTinh.Location = new System.Drawing.Point(296, 62);
            this.lblDonViTinh.Name = "lblDonViTinh";
            this.lblDonViTinh.Size = new System.Drawing.Size(39, 18);
            this.lblDonViTinh.TabIndex = 8;
            this.lblDonViTinh.Text = "Đơn vị";
            // 
            // flowLayOut
            // 
            this.flowLayOut.Location = new System.Drawing.Point(263, 110);
            this.flowLayOut.Name = "flowLayOut";
            this.flowLayOut.Size = new System.Drawing.Size(382, 230);
            this.flowLayOut.TabIndex = 11;
            // 
            // lstSoLuongTinh
            // 
            this.lstSoLuongTinh.Location = new System.Drawing.Point(157, 110);
            this.lstSoLuongTinh.Name = "lstSoLuongTinh";
            this.lstSoLuongTinh.Size = new System.Drawing.Size(100, 230);
            this.lstSoLuongTinh.TabIndex = 12;
            this.lstSoLuongTinh.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.lstSoLuongTinh_SelectedIndexChanged);
            // 
            // btnXoaBang
            // 
            this.btnXoaBang.Location = new System.Drawing.Point(535, 82);
            this.btnXoaBang.Name = "btnXoaBang";
            this.btnXoaBang.Size = new System.Drawing.Size(110, 24);
            this.btnXoaBang.TabIndex = 10;
            this.btnXoaBang.Text = "Xóa bảng";
            this.btnXoaBang.Click += new System.EventHandler(this.btnXoaBang_Click);
            // 
            // btnRefreshDaySoLuong
            // 
            this.btnRefreshDaySoLuong.Location = new System.Drawing.Point(487, 82);
            this.btnRefreshDaySoLuong.Name = "btnRefreshDaySoLuong";
            this.btnRefreshDaySoLuong.Size = new System.Drawing.Size(42, 24);
            this.btnRefreshDaySoLuong.TabIndex = 10;
            this.btnRefreshDaySoLuong.Text = "R";
            this.btnRefreshDaySoLuong.Click += new System.EventHandler(this.btnRefreshDaySoLuong_Click);
            // 
            // chkLuuSoLuong
            // 
            this.chkLuuSoLuong.Location = new System.Drawing.Point(372, 62);
            this.chkLuuSoLuong.Name = "chkLuuSoLuong";
            this.chkLuuSoLuong.Size = new System.Drawing.Size(85, 18);
            this.chkLuuSoLuong.TabIndex = 13;
            this.chkLuuSoLuong.Text = "Lưu số lượng";
            this.chkLuuSoLuong.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkLuuSoLuong_ToggleStateChanged);
            // 
            // txtNoiDungBangGia
            // 
            this.txtNoiDungBangGia.IsReadOnly = true;
            this.txtNoiDungBangGia.Location = new System.Drawing.Point(12, 223);
            this.txtNoiDungBangGia.Multiline = true;
            this.txtNoiDungBangGia.Name = "txtNoiDungBangGia";
            this.txtNoiDungBangGia.Size = new System.Drawing.Size(139, 117);
            this.txtNoiDungBangGia.TabIndex = 0;
            // 
            // BangGiaInNhanhForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 396);
            this.Controls.Add(this.txtNoiDungBangGia);
            this.Controls.Add(this.chkLuuSoLuong);
            this.Controls.Add(this.btnRefreshDaySoLuong);
            this.Controls.Add(this.btnXoaBang);
            this.Controls.Add(this.lstSoLuongTinh);
            this.Controls.Add(this.flowLayOut);
            this.Controls.Add(this.lblDonViTinh);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.lstBangGiaInNhanh);
            this.Controls.Add(this.btnLuuSoLuongMacDinh);
            this.Controls.Add(this.lblTieuDeDaySoLuong);
            this.Controls.Add(this.txtDaySoLuong);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.drpHangKH);
            this.Controls.Add(this.radLabel2);
            this.Name = "BangGiaInNhanhForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "BangGiaThanhPhamForm";
            this.Load += new System.EventHandler(this.BangGiaInNhanhForm_Load);
            this.Resize += new System.EventHandler(this.BangGiaInNhanhForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpHangKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDaySoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTieuDeDaySoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLuuSoLuongMacDinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstBangGiaInNhanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDonViTinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstSoLuongTinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXoaBang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefreshDaySoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLuuSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDungBangGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadDropDownList drpHangKH;
        private Telerik.WinControls.UI.RadButton btnDong;
        private Telerik.WinControls.UI.RadTextBox txtDaySoLuong;
        private Telerik.WinControls.UI.RadLabel lblTieuDeDaySoLuong;
        private Telerik.WinControls.UI.RadButton btnLuuSoLuongMacDinh;
        private Telerik.WinControls.UI.RadListControl lstBangGiaInNhanh;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel lblDonViTinh;
        private System.Windows.Forms.FlowLayoutPanel flowLayOut;
        private Telerik.WinControls.UI.RadListControl lstSoLuongTinh;
        private Telerik.WinControls.UI.RadButton btnXoaBang;
        private Telerik.WinControls.UI.RadButton btnRefreshDaySoLuong;
        private Telerik.WinControls.UI.RadCheckBox chkLuuSoLuong;
        private Telerik.WinControls.UI.RadTextBoxControl txtNoiDungBangGia;
    }
}
