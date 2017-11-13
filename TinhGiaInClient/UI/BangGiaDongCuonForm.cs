using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TinhGiaInClient.View;
using TinhGiaInClient.Presenter;
using TinhGiaInClient.Model.Support;
using TinhGiaInClient.Model;
using TinhGiaInClient.Common.Enum;


namespace TinhGiaInClient.UI
{
    
    public partial class BangGiaDongCuonForm : Telerik.WinControls.UI.RadForm, IViewBangGiaThanhPham
    {
        public BangGiaDongCuonForm()
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
            btnXoaBang_Click(btnXoaBang, e);
            //Trường hợp đặc biệt ép kim
            if (bangGiaThPhPres.DocLoaiThanhPham() == LoaiThanhPhamS.EpKim)
            {
                ShowFormEpKim();
            }
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

        private void btnLuuSoLuongMacDinh_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.DaySoluong.Trim()) || chkLuuSoLuong.Checked)
            {
                MessageBox.Show(bangGiaThPhPres.LuuDaySoLuong());
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
        private void ShowFormEpKim()
        {
            var thongTinBanDau = new ThongTinBanDauThanhPham
            {
                IdBaiIn = 1,
                IdHangKhachHang = this.IdHangKHChon,
                LoaiThanhPham = LoaiThanhPhamS.EpKim,
                DonViTinh = "Con",
                SoLuongSanPham = 50,
                TieuDeForm = "Ép kim [Tính thử]",
                SoLuongToChay = 0,
                TinhTrangForm = FormStateS.View,
                ThongDiepCanThiet = "Chỉ tính toán thử"

            };
            //muc emkim
            var mucThPhEpKim = new MucThPhEpKim();
            mucThPhEpKim.IdBaiIn = 1;
            mucThPhEpKim.IdHangKhachHang =this.IdHangKHChon;
            mucThPhEpKim.LoaiThanhPham = LoaiThanhPhamS.EpKim;
            mucThPhEpKim.SoLuong = 100; //Tạm
            mucThPhEpKim.DonViTinh = "con";
            mucThPhEpKim.KhoEpRong = 5f;
            mucThPhEpKim.KhoEpCao = 5f;

            var frm = new ThPhEpKimForm(thongTinBanDau, mucThPhEpKim);
            frm.TinhTrangForm = (int)FormStateS.View;
            
          
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            //Data gởi qua form

           
            frm.ShowDialog();
        }
    }
}
