using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinhGiaInClient;
using TinhGiaInClient.Model;
using TinhGiaInClient.Model.Support;
using TinhGiaInClient.UI;
using TinhGiaInClient.Common.Enum;
using TinhGiaInClient.Common;

namespace TinhGiaInClient.UI
{
    public partial class TinhThuForm : Form
    {
        //GiaInNhanhThuForm frmGiaInNhanh;
        GiayDeInForm frmGiayDeIn;

        public TinhThuForm(string tenNguoiDung = "")
        {
            InitializeComponent();
            LoadHangKhachHang();
            this.TenNguoiDung = tenNguoiDung;
        }
        public int IdHangKhachHang
        { 
            get { return int.Parse(cboHangKH.SelectedValue.ToString());} 
        }
        public string TenNguoiDung
        {
            get;
            set;
        }
        private void LoadHangKhachHang()
        {
            var nguon = HangKhachHang.LayTatCa();
            cboHangKH.ValueMember = "ID";
            cboHangKH.DisplayMember = "Ten";
            cboHangKH.DataSource = nguon;
            cboHangKH.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private string TenMayTinhHienTai()
        {
            return System.Environment.MachineName;
        }
        private void ByByWindows(object sender, FormClosedEventArgs e)
        {
            Form frm;
            if (sender is Form)
            {
                frm = (Form)sender;
                /*if (frm == frmGiaInNhanh)
                    frmGiaInNhanh = null;
                if (frm == frmGiaInNhanh)
                    frmGiayDeIn = null;
                 */
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void FormClosing_Query(object sender, FormClosingEventArgs e)
        {
          
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
        }

        private void mnuPS_Album_Click(object sender, EventArgs e)
        {
            /*PriceSettingManForm frm = new PriceSettingManForm();
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.ShowDialog();
             */
        }

        private void danhMụcSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnCategorySetting_Click(object sender, EventArgs e)
        {
           
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            /*
            OptionManForm frm = new OptionManForm();
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý các tùy chọn";

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ;
            }
            
             */
        }

  

        private void mnuQuanLy_GiaBia_Click(object sender, EventArgs e)
        {
          
        }

        private void mnuQuanLy_GiaHop_Click(object sender, EventArgs e)
        {
           
        }

        private void bìaAlbumToolStripMenuItem1_Click(object sender, EventArgs e)
        {
         
        }

        private void tênAlbumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void bìaAlbumToolStripMenuItem_Click(object sender, EventArgs e)
        {

         

        }

      

        private void mnuQuanLy_DanhMuc_Click_1(object sender, EventArgs e)
        {
            
        }
        private ThongTinBanDauThanhPham thongTinBanDauChoThPh(int idHangKH, LoaiThanhPhamS loaiThPham,
                        FormStateS tinhTrangForm, string tieuDeForm, string donViTinh)
        {
            var thongTinBanDau = new ThongTinBanDauThanhPham
            {
                IdBaiIn = 1,
                IdHangKhachHang = idHangKH,
                LoaiThanhPham = loaiThPham,
                DonViTinh = donViTinh,
                SoLuongSanPham = 50,
                TieuDeForm = tieuDeForm,
                SoLuongToChay = 1,
                TinhTrangForm = tinhTrangForm,
                ThongDiepCanThiet = "Tính thử:" + '\n' + '\r',

            };
            return thongTinBanDau;
        }

        
    

       
        private void btnTinhThu_CanPhu_Click(object sender, EventArgs e)
        {
            var idHangKH = int.Parse(cboHangKH.SelectedValue.ToString());
            var thongTinBanDau = this.thongTinBanDauChoThPh(idHangKH, LoaiThanhPhamS.CanPhu,
                FormStateS.View,"Cán Phủ [Tính thử]", "Mặt" );
            thongTinBanDau.MoTextSoLuong = true;
            //Mục thành phẩm cán phủ
            var mucThPhCanPhu = new MucThPhCanPhu();
            mucThPhCanPhu.IdBaiIn = 1;
            mucThPhCanPhu.IdHangKhachHang = this.IdHangKhachHang;
            mucThPhCanPhu.LoaiThanhPham = LoaiThanhPhamS.CanPhu;
            mucThPhCanPhu.ToChayDai = 21;//cm
            mucThPhCanPhu.ToChayRong = 32; //cm
            mucThPhCanPhu.SoLuong = 50;
            mucThPhCanPhu.DonViTinh = "mặt";
            mucThPhCanPhu.SoMatCan = 1;
            //Cập nhật lại thông ti ban đầu
            thongTinBanDau.ThongDiepCanThiet += string.Format(" Khổ: {0} x {1}cm",
                mucThPhCanPhu.ToChayRong, mucThPhCanPhu.ToChayDai);

            var frm = new ThPhCanPhuForm( thongTinBanDau, mucThPhCanPhu);
            
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnTinhThu_CanGap_Click(object sender, EventArgs e)
        {
             var idHangKH = int.Parse(cboHangKH.SelectedValue.ToString());
            var thongTinBanDau = this.thongTinBanDauChoThPh(idHangKH, LoaiThanhPhamS.CanGap,
                FormStateS.View,"Cấn gấp [Tính thử]", "con" );
            //Mục thành phẩm cấn gấp
            var mucThPhCanGap = new MucThPhCanGap();
            mucThPhCanGap.IdBaiIn = 1;
            mucThPhCanGap.IdHangKhachHang = this.IdHangKhachHang;
            mucThPhCanGap.LoaiThanhPham = LoaiThanhPhamS.CanGap;
            mucThPhCanGap.SoLuong = 10;
            mucThPhCanGap.DonViTinh = "con";
            mucThPhCanGap.SoDuongCan = 1;

            var frm = new ThPhCanGapForm( thongTinBanDau, mucThPhCanGap);
            
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;           
            frm.ShowDialog();
        }

        private void btnTinhThu_DongCuon_Click(object sender, EventArgs e)
        {
            var idHangKH = int.Parse(cboHangKH.SelectedValue.ToString());
            var thongTinBanDau = this.thongTinBanDauChoThPh(idHangKH, LoaiThanhPhamS.DongCuon,
                FormStateS.View, "Đóng cuốn [Tính thử]", "Cuốn");
            thongTinBanDau.MoTextSoLuong = true;
            //tạo mục thành phẩm đóng cuốn
            var mucThPhamDongCuon = new MucDongCuon();
            mucThPhamDongCuon.IdBaiIn = 1;
            mucThPhamDongCuon.IdHangKhachHang = this.IdHangKhachHang;
            mucThPhamDongCuon.LoaiThanhPham = LoaiThanhPhamS.DongCuon;
            mucThPhamDongCuon.KieuDongCuon = KieuDongCuonS.KimKeoNep;
            mucThPhamDongCuon.SoLuong = 1; //Cần xác định sau
            mucThPhamDongCuon.DonViTinh = "cuốn";

            var frm = new ThPhDongCuonForm(thongTinBanDau, mucThPhamDongCuon);
            
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            //Data gởi qua form
            frm.ShowDialog();
        }

        private void btnTinhThu_EpKim_Click(object sender, EventArgs e)
        {
            var idHangKH = int.Parse(cboHangKH.SelectedValue.ToString());
            var thongTinBanDau = this.thongTinBanDauChoThPh(idHangKH, LoaiThanhPhamS.EpKim,
                FormStateS.View, "Ép kim [Tính thử]", "Con");
            //tạo mới mục ép kim
            var mucThPhEpKim = new MucThPhEpKim();
            mucThPhEpKim.IdBaiIn = 1;
            mucThPhEpKim.IdHangKhachHang = this.IdHangKhachHang;
            mucThPhEpKim.LoaiThanhPham = LoaiThanhPhamS.EpKim;
            mucThPhEpKim.SoLuong = 10; //Tạm
            mucThPhEpKim.DonViTinh = "con";
            mucThPhEpKim.KhoEpRong = 5f;
            mucThPhEpKim.KhoEpCao = 5f;
            mucThPhEpKim.KhoToChayRong = 32;//cm
            mucThPhEpKim.KhoToChayDai = 22;
            mucThPhEpKim.SoLuongToChay = 10;
            var frm = new ThPhEpKimForm(thongTinBanDau, mucThPhEpKim);
           
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            //Data gởi qua form
            frm.ShowDialog();
        }

        private void btnGiaInNhanh_Click(object sender, EventArgs e)
        {/*
            if (frmGiaInNhanh == null)
            {
                frmGiaInNhanh = new GiaInNhanhThuForm((int)FormStateS.View,
               int.Parse(cboHangKH.SelectedValue.ToString()));
                frmGiaInNhanh.FormClosed += new FormClosedEventHandler(ByByWindows);
                frmGiaInNhanh.Text = "Tính thử " + cboHangKH.Text;
                frmGiaInNhanh.MinimizeBox = false;
                frmGiaInNhanh.MaximizeBox = false;
                frmGiaInNhanh.StartPosition = FormStartPosition.CenterParent;
                frmGiaInNhanh.Show();


            }
            else
                frmGiaInNhanh.Focus();*/
            var frmGiaInNhanh = new GiaInNhanhThuForm((int)FormStateS.View,
                int.Parse(cboHangKH.SelectedValue.ToString()));
            
            frmGiaInNhanh.Text = "Tính thử " + cboHangKH.Text;
            frmGiaInNhanh.MinimizeBox = false;
            frmGiaInNhanh.MaximizeBox = false;
            frmGiaInNhanh.StartPosition = FormStartPosition.CenterParent;
            frmGiaInNhanh.Show();
           
        }

   

        private void btnBangGiaGiay_Click(object sender, EventArgs e)
        {
                       
            BangGiaGiayForm frm = new BangGiaGiayForm(FormStateS.View);           
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Bảng giá giấy theo hạng KH ";
            frm.ShowDialog();
        }

       

        private void btnTinhThu_GiaDongCuonLoXo_Click(object sender, EventArgs e)
        {
            var idHangKH = int.Parse(cboHangKH.SelectedValue.ToString());
            var thongTinBanDauLX = new  ThongTinBanDauDongCuon();
            thongTinBanDauLX.TinhTrangForm =  FormStateS.View;
            thongTinBanDauLX.TieuDeForm = "Đóng cuốn [Tính thử]";
            thongTinBanDauLX.MoTextSoLuongCuon = true;
            //Tạo mục đóng cuốn
            var mucDongCuonLX = new MucDongCuonLoXo();
            mucDongCuonLX.IdBaiIn = 1;
            mucDongCuonLX.IdHangKhachHang = this.IdHangKhachHang;
            mucDongCuonLX.SoLuong = 1; //Vì số lượng có thể không trùng
            mucDongCuonLX.DonViTinh = "cuốn";
            mucDongCuonLX.GayCao = 10;
            mucDongCuonLX.GayDay = 0.5f;
            mucDongCuonLX.LoaiThanhPham = LoaiThanhPhamS.DongCuon;
            mucDongCuonLX.KieuDongCuon = KieuDongCuonS.LoXo;
            var frm = new  ThPhDongCuonLoXoForm(thongTinBanDauLX, mucDongCuonLX);

            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            //Data gởi qua form
            frm.ShowDialog();
        }

      

        private void NhapLieuMainForm_Load(object sender, EventArgs e)
        {
            //this.TenNguoiDung = TenMayTinhHienTai();
        }
        private bool CoTheMoFormNay(string tenForm)
        {
            bool kq = true;
         /*   if (string.IsNullOrEmpty(txtTenNguoiDung.Text.Trim()))
            {
                MessageBox.Show("Tên người dùng chưa đúng!");
                return false;
            }*/
            //Kiểm tiếp
            var nguoiDung = NguoiDung.DocTheoTenDangNhap(this.TenNguoiDung.Trim());
            if (nguoiDung.ID == 0)
            {
                MessageBox.Show("Bạn chưa có tài khoản sử dụng");
                return false;
            }
            //Kiểm tra có tên form không
            try
            {
                var danhSachFormS = nguoiDung.FormCoTheMo.ToUpper().Split(';');
                if (danhSachFormS.Contains("*")) //Trường hợp đặc biệt master
                    return true;

                if (!danhSachFormS.Contains(tenForm.ToUpper().Trim()))
                {
                    kq = false;
                }
            }
            catch
            {
                kq = false;
            }
            
            return kq;

        }

        private void NhapLieuMainForm_Resize(object sender, EventArgs e)
        {
            btnDong.Left = (pnlBottom.Width - btnDong.Width) / 2;            
            cboHangKH.Left = lblChonHangKH.Left + lblChonHangKH.Width + 5;
        }

        private void btnTinhThu_DongCuonMoPhang_Click(object sender, EventArgs e)
        {
            var idHangKH = int.Parse(cboHangKH.SelectedValue.ToString());
            var thongTinBanDauMP = new ThongTinBanDauDongCuon();
            thongTinBanDauMP.MoTextSoLuongCuon = true;
            thongTinBanDauMP.TinhTrangForm = FormStateS.View;
            thongTinBanDauMP.TieuDeForm = "Đóng cuốn Mở phẳng [Tính thử]";
            //Tạo mục đóng cuốn
            var mucDongCuonMP = new MucDongCuonMoPhang();
            mucDongCuonMP.IdBaiIn = 1;
            mucDongCuonMP.IdHangKhachHang = this.IdHangKhachHang;
            mucDongCuonMP.SoLuong = 1; //Vì số lượng có thể không trùng
            mucDongCuonMP.DonViTinh = "cuốn";            
            mucDongCuonMP.SoToDoi = 10;
            mucDongCuonMP.LoaiThanhPham = LoaiThanhPhamS.DongCuon;
            mucDongCuonMP.KieuDongCuon = KieuDongCuonS.MoPhang;
            var frm = new ThPhDongCuonMoPhangForm(thongTinBanDauMP, mucDongCuonMP);

            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            //Data gởi qua form
            frm.ShowDialog();
        }

       
      
        private void TinhThu_CatDecal()
        {
            var idHangKH = int.Parse(cboHangKH.SelectedValue.ToString());
            var thongTinBanDau = new ThongTinBanDauThanhPham();
            thongTinBanDau.DonViTinh = "Con";
            thongTinBanDau.TinhTrangForm = FormStateS.View;
            thongTinBanDau.TieuDeForm = "Cắt decal [Tính thử]";

            //Tạo mục đóng cuốn
            var mucThPhCatDecal = new MucThPhCatDecal();
            mucThPhCatDecal.IdBaiIn = 1;
            mucThPhCatDecal.IdHangKhachHang = this.IdHangKhachHang;
            mucThPhCatDecal.SoLuong = 100; //Vì số lượng có thể không trùng
            mucThPhCatDecal.DonViTinh = "con";
            mucThPhCatDecal.ConRong = 5;
            mucThPhCatDecal.ConCao = 5;
            mucThPhCatDecal.LoaiThanhPham = LoaiThanhPhamS.CatDecal;

            var frm = new ThPhCatDecalForm(thongTinBanDau, mucThPhCatDecal);

            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            //Data gởi qua form
            frm.ShowDialog();
        }
        private void btnTinhThu_CatDecal_Click(object sender, EventArgs e)
        {
            TinhThu_CatDecal();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void TinhThuBoiBiaCung()
        {
            var idHangKH = int.Parse(cboHangKH.SelectedValue.ToString());
            var thongTinBanDauMP = new ThongTinBanDauThanhPham();
            thongTinBanDauMP.MoTextSoLuong = true;
            thongTinBanDauMP.TinhTrangForm = FormStateS.View;
            thongTinBanDauMP.TieuDeForm = "Bồi bìa cứng [Tính thử]";
            //Tạo mục đóng cuốn
            var mucThPhBoiBC = new MucThPhBoiBiaCung();
            mucThPhBoiBC.IdBaiIn = 1;
            mucThPhBoiBC.IdHangKhachHang = this.IdHangKhachHang;
            mucThPhBoiBC.SoLuong = 1; //Vì số lượng có thể không trùng
            mucThPhBoiBC.DonViTinh = "Tấm";
            mucThPhBoiBC.TamRong = 10;
            mucThPhBoiBC.TamCao = 10;
            mucThPhBoiBC.SoToBoiTrenTamBia = 1;
            mucThPhBoiBC.LoaiThanhPham = LoaiThanhPhamS.BoiBiaCung;
           
            var frm = new ThPhBoiBiaCungForm(thongTinBanDauMP, mucThPhBoiBC);

            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            //Data gởi qua form
            frm.ShowDialog();
        }

        private void btnTinhThu_BoiBiaCung_Click(object sender, EventArgs e)
        {
            TinhThuBoiBiaCung();
        }

        private void btnGiaGiayIn_Click(object sender, EventArgs e)
        {

            if (frmGiayDeIn == null)
            {
                //Thông tin ban đầu
                var kichThuocSP = new KichThuocPhang
                {
                    Rong = 32,
                    Dai = 22
                };
                var thongTinBanDau = new ThongTinBanDauChoGiayIn();
                thongTinBanDau.IdHangKhachHang = this.IdHangKhachHang;
                thongTinBanDau.TinhTrangForm = FormStateS.TinhThu;
                thongTinBanDau.KichThuocSanPham = kichThuocSP;
                thongTinBanDau.DonViTinhSanPham = "Tờ";
                thongTinBanDau.SoLuongSanPham = 10;
                thongTinBanDau.ThongTinCanThiet = string.Format("Khổ SP A4: {0} x {1}cm",
                    kichThuocSP.Rong, kichThuocSP.Dai);

                //Giây de in
                GiayDeIn giayDeIn = new GiayDeIn(32, 47, 2, 1, 0, 0, false,
                    0, "", 1, 5, 1, 0);
                frmGiayDeIn = new GiayDeInForm(thongTinBanDau, giayDeIn);
                frmGiayDeIn.FormClosed += new FormClosedEventHandler(ByByWindows);
                frmGiayDeIn.Text = "Tính thử " + cboHangKH.Text;
                frmGiayDeIn.MinimizeBox = false;
                frmGiayDeIn.MaximizeBox = false;
                frmGiayDeIn.StartPosition = FormStartPosition.CenterParent;
                frmGiayDeIn.Show();
            }
            else
                frmGiayDeIn.Focus();
           
        }

        private void btnSoSanhGiaInNhanh_Click(object sender, EventArgs e)
        {
            var frm = new SoSanhGiaInNhanhForm();

            frm.Text = "SO SÁNH GIÁ IN NHANH";
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void btnSoSanhOffsetNhanh_Click(object sender, EventArgs e)
        {
            var thongTin ="";
            if (!Global.CoTheMoFormNay("SoSanhOffsetNhanhForm", this.TenNguoiDung,
                out thongTin)) //không có tên form
            {
                MessageBox.Show(thongTin);
                return;
            }
            //Qua khỏi
            var frm = new SoSanhOffsetNhanhForm();

            frm.Text = "SO SÁNH CHI PHÍ";
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }
    }
}
