﻿using System;
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

namespace TinhGiaInClient.UI
{
    public partial class TinhThuForm : Form
    {
        public TinhThuForm()
        {
            InitializeComponent();
            LoadHangKhachHang();
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

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
        private ThongTinBanDauChoThanhPham thongTinBanDauChoThPh(int idHangKH, LoaiThanhPhamS loaiThPham,
                        FormStateS tinhTrangForm, string tieuDeForm, string donViTinh)
        {
            var thongTinBanDau = new ThongTinBanDauChoThanhPham
            {
                IdBaiIn = 1,
                IdHangKhachHang = idHangKH,
                LoaiThanhPham = loaiThPham,
                DonViTinh = donViTinh,
                SoLuongSanPham = 50,
                TieuDeForm = tieuDeForm,
                SoLuongToChay = 1,
                TinhTrangForm = tinhTrangForm,
                ThongDiepCanThiet = "Chỉ tính toán thử",

            };
            return thongTinBanDau;
        }

        
    

       
        private void btnTinhThu_CanPhu_Click(object sender, EventArgs e)
        {
            var idHangKH = int.Parse(cboHangKH.SelectedValue.ToString());
            var thongTinBanDau = this.thongTinBanDauChoThPh(idHangKH, LoaiThanhPhamS.CanPhu,
                FormStateS.View,"Cán Phủ [Tính thử]", "Mặt" );
            //Mục thành phẩm cán phủ
            var mucThPhCanPhu = new MucThPhCanPhu();
            mucThPhCanPhu.IdBaiIn = 1;
            mucThPhCanPhu.IdHangKhachHang = this.IdHangKhachHang;
            mucThPhCanPhu.LoaiThanhPham = LoaiThanhPhamS.CanPhu;
            mucThPhCanPhu.SoLuong = 50;
            mucThPhCanPhu.DonViTinh = "mặt";
            mucThPhCanPhu.SoMatCan = 1;
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
            //tạo mục thành phẩm đóng cuốn
            var mucThPhamDongCuon = new MucThanhPham();
            mucThPhamDongCuon.IdBaiIn = 1;
            mucThPhamDongCuon.IdHangKhachHang = this.IdHangKhachHang;
            mucThPhamDongCuon.LoaiThanhPham = LoaiThanhPhamS.DongCuon;
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
            var frm = new ThPhEpKimForm(thongTinBanDau, mucThPhEpKim);
           
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            //Data gởi qua form
            frm.ShowDialog();
        }

        private void btnGiaInNhanh_Click(object sender, EventArgs e)
        {

            var frm = new GiaInNhanhThuForm((int)FormStateS.View,
                int.Parse(cboHangKH.SelectedValue.ToString()));
            frm.Text = "Tính thử " + cboHangKH.Text;
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;            
            frm.Show();
           
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
            this.TenNguoiDung = TenMayTinhHienTai();
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
            var nguoiDung = NguoiDung.DocTheoTenDangNhap(this.TenNguoiDung);
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
            txtChonHangKH.Left = txtChonHangKH.Left + txtChonHangKH.Width + 5;
            cboHangKH.Left = txtChonHangKH.Left + txtChonHangKH.Width + 5;
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
            var thongTinBanDau = new ThongTinBanDauChoThanhPham();
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
    }
}