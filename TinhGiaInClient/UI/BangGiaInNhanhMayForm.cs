using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TinhGiaInClient.View;
using TinhGiaInClient.Presenter;


namespace TinhGiaInClient.UI
{
    
    public partial class BangGiaInNhanhMayForm : Telerik.WinControls.UI.RadForm, IViewBangGiaInNhanhMay
    {
        public BangGiaInNhanhMayForm()
        {
            InitializeComponent();
            bangGiaInMayPres = new BangGiaInNhanhMayPresenter(this);

            LoadHangKhachHang();
            LoadDanhSachThanhPham();
        }
        BangGiaInNhanhMayPresenter bangGiaInMayPres;
        int _idHangKHChon = 0;
        public int IdHangKHChon
        {
            get
            {
                if (drpHangKH.SelectedValue != null)
                    int.TryParse(drpHangKH.SelectedValue.ToString(), out _idHangKHChon);
                return _idHangKHChon;
                    
            }
            set
            {
                _idHangKHChon = value;
            }
        }
        int _idMonThanhPham = 0;
        public int IdToInDigiChon
        {
            get
            {
                if (lstToInDigi.SelectedValue != null)
                    int.TryParse(lstToInDigi.SelectedValue.ToString(), out _idMonThanhPham);
                return _idMonThanhPham;

            }
            set
            {
                _idMonThanhPham = value;
            }
        }
        public string DaySoluong 
        {
            get { return txtDaySoLuong.Text; }
            set { txtDaySoLuong.Text = value; }
        }
        public string DonViTinh
        {
            get { return lblDonViTinh.Text; }
            set { lblDonViTinh.Text = value; }
        }
        private void LoadHangKhachHang()
        {
            drpHangKH.DisplayMember = "Ten";
            drpHangKH.ValueMember = "ID";
            drpHangKH.DataSource = bangGiaInMayPres.HangKhachHangS();
        }
        private void LoadDanhSachThanhPham()
        {
            lstToInDigi.DisplayMember = "Ten";
            lstToInDigi.ValueMember = "ID";
            lstToInDigi.DataSource = bangGiaInMayPres.BangGiaInNhanhS();
        }
        private void LoadSoLuongTinh()
        {
            lstSoLuongTinh.DataSource = bangGiaInMayPres.SoLuongTinhS();
            lstSoLuongTinh.ValueMember = "ID";
            lstSoLuongTinh.DisplayMember = "SoLuong";
        }

        private void lstDichVuThanhPham_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            bangGiaInMayPres.TrinhBayDuLieuInNhanhChon();
            LoadSoLuongTinh();
            btnXoaBang_Click(btnXoaBang, e);
        }
        private void TrinhBaySoLuong_Gia()
        {
           
            Telerik.WinControls.UI.RadLabel lb;
            flowLayOut.Controls.Clear();

            if (bangGiaInMayPres.SoLuong_GiaS().Length <= 0)
                return;

            for (int i = 0; i < bangGiaInMayPres.SoLuong_GiaS().Length; ++i)
            {
                
                lb = new Telerik.WinControls.UI.RadLabel();
                lb.Text = string.Format("{0}" + '\r' + '\n' + "{1:0,0.00}" + '\r' + '\n' + "{2:0,0.00}/{3}",
                    bangGiaInMayPres.SoLuong_GiaS()[i].SoLuong,
                    bangGiaInMayPres.SoLuong_GiaS()[i].Gia,
                    bangGiaInMayPres.SoLuong_GiaS()[i].GiaTrungBinhDonVi(),
                    this.DonViTinh);
                flowLayOut.Controls.Add(lb);
            }
        }

        private void btnTinhGia_Click(object sender, EventArgs e)
        {
            TrinhBaySoLuong_Gia();
        }
        private void TrinhBayGiaTheoSoLuong(int soLuong)
        {

            Telerik.WinControls.UI.RadLabel lb;
            //flowLayOut.Controls.Clear();

            if (bangGiaInMayPres.SoLuongTinhS().Length <= 0)
                return;

            lb = new Telerik.WinControls.UI.RadLabel();
            lb.Text = string.Format("{0}" + '\r' + '\n' + "{1:0,0.00}" + '\r' + '\n' + "{2:0,0.00}/{3}",
                bangGiaInMayPres.KetQuaSoLuongGia(soLuong).SoLuong,
                bangGiaInMayPres.KetQuaSoLuongGia(soLuong).Gia,
                bangGiaInMayPres.KetQuaSoLuongGia(soLuong).GiaTrungBinhDonVi(),
                this.DonViTinh);
            flowLayOut.Controls.Add(lb);

        }
        private void lstSoLuongTinh_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

            var idSoLuong = 0;
            if (lstSoLuongTinh.SelectedValue != null)
                int.TryParse(lstSoLuongTinh.SelectedValue.ToString(), out idSoLuong);
            {
                //MessageBox.Show(idSoLuong.ToString());
                TrinhBayGiaTheoSoLuong(bangGiaInMayPres.DocSoLuongTinhTheoId(idSoLuong).SoLuong);
            }

        }

        private void btnXoaBang_Click(object sender, EventArgs e)
        {
            flowLayOut.Controls.Clear();
        }

        private void btnLuuSoLuongMacDinh_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.DaySoluong.Trim()) || chkLuuSoLuong.Checked)
            {
                MessageBox.Show(bangGiaInMayPres.LuuDaySoLuong());
                chkLuuSoLuong.Checked = false;
                btnLuuSoLuongMacDinh.Enabled = chkLuuSoLuong.Checked;
                //LoadSoLuongTinh();
                //btnXoaBang_Click(btnXoaBang, e);
            }
        }

        private void btnRefreshDaySoLuong_Click(object sender, EventArgs e)
        {
            LoadSoLuongTinh();
            btnXoaBang_Click(btnXoaBang, e);
        }

        private void drpHangKH_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            btnXoaBang_Click(btnXoaBang, e);
            //MessageBox.Show(bangGiaThPhPres.TiLeMarkUpTheoHangKH().ToString());
        }

        private void chkLuuSoLuong_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {

            btnLuuSoLuongMacDinh.Enabled = chkLuuSoLuong.Checked;
        }

        private void BangGiaThanhPhamForm_Resize(object sender, EventArgs e)
        {
            txtDaySoLuong.Width = 6 * (this.Width / 12);
            btnRefreshDaySoLuong.Left = txtDaySoLuong.Left + txtDaySoLuong.Width + 5;
            btnXoaBang.Left = btnRefreshDaySoLuong.Left + btnRefreshDaySoLuong.Width + 5;
            flowLayOut.Width = txtDaySoLuong.Width;
            flowLayOut.Left = lstSoLuongTinh.Left + lstSoLuongTinh.Width + 5;
            btnDong.Left = (this.ClientSize.Width - btnDong.Width) / 2;
        }

        private void txtDaySoLuong_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDaySoLuong.Text.Trim()))
            {
                txtDaySoLuong.Text = "10;11";
            }
        }
    }
}
