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
    
    public partial class BangGiaThanhPhamForm : Telerik.WinControls.UI.RadForm, IViewBangGiaThanhPham
    {
        public BangGiaThanhPhamForm()
        {
            InitializeComponent();
            bangGiaThPhPres = new BangGiaThanhPhamPresenter(this);

            LoadHangKhachHang();
            LoadDanhSachThanhPham();
        }
        BangGiaThanhPhamPresenter bangGiaThPhPres;
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
        public int IdMonThanhPham
        {
            get
            {
                if (lstDichVuThanhPham.SelectedValue != null)
                    int.TryParse(lstDichVuThanhPham.SelectedValue.ToString(), out _idMonThanhPham);
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
            drpHangKH.DataSource = bangGiaThPhPres.HangKhachHangS();
        }
        private void LoadDanhSachThanhPham()
        {
            lstDichVuThanhPham.DisplayMember = "Ten";
            lstDichVuThanhPham.ValueMember = "ID";
            lstDichVuThanhPham.DataSource = bangGiaThPhPres.DichVuThanhPhamS();
        }
        private void LoadSoLuongTinh()
        {
            lstSoLuongTinh.DataSource = bangGiaThPhPres.SoLuongTinhS();
            lstSoLuongTinh.ValueMember = "ID";
            lstSoLuongTinh.DisplayMember = "SoLuong";
        }

        private void lstDichVuThanhPham_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            bangGiaThPhPres.TrinhBayDuLieuThanhPhamTheoMon();
            LoadSoLuongTinh();
        }
        private void TrinhBaySoLuong_Gia()
        {
           
            Telerik.WinControls.UI.RadLabel lb;
            flowLayOut.Controls.Clear();

            if (bangGiaThPhPres.SoLuong_GiaS().Length <= 0)
                return;

            for (int i = 0; i < bangGiaThPhPres.SoLuong_GiaS().Length; ++i)
            {
                
                lb = new Telerik.WinControls.UI.RadLabel();
                lb.Text = string.Format("{0}" + '\r' + '\n' + "{1:0,0.00}" + '\r' + '\n' + "{2:0,0.00}/{3}",
                    bangGiaThPhPres.SoLuong_GiaS()[i].SoLuong,
                    bangGiaThPhPres.SoLuong_GiaS()[i].Gia,
                    bangGiaThPhPres.SoLuong_GiaS()[i].GiaTrungBinhDonVi(),
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

            if (bangGiaThPhPres.SoLuongTinhS().Length <= 0)
                return;

            lb = new Telerik.WinControls.UI.RadLabel();
            lb.Text = string.Format("{0}" + '\r' + '\n' + "{1:0,0.00}" + '\r' + '\n' + "{2:0,0.00}/{3}",
                bangGiaThPhPres.KetQuaSoLuongGia(soLuong).SoLuong,
                bangGiaThPhPres.KetQuaSoLuongGia(soLuong).Gia,
                bangGiaThPhPres.KetQuaSoLuongGia(soLuong).GiaTrungBinhDonVi(),
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
                TrinhBayGiaTheoSoLuong(bangGiaThPhPres.DocSoLuongTinhTheoId(idSoLuong).SoLuong);
            }

        }

        private void btnXoaBang_Click(object sender, EventArgs e)
        {
            flowLayOut.Controls.Clear();
        }
    }
}
