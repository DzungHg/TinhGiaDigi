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

namespace TinhGiaInNhapLieu
{
    public partial class NhapLieuMainForm : Form
    {
        public NhapLieuMainForm()
        {
            InitializeComponent();
           
        }
       
        public string TenNguoiDung
        {
            get { return txtTenNguoiDung.Text; }
            set { txtTenNguoiDung.Text = value; }
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

        private void mnuQuanLy_DanhMuc_Click(object sender, EventArgs e)
        {
            QuanLyDanhMucGiayForm frm = new QuanLyDanhMucGiayForm();
            if (!CoTheMoFormNay(frm.Name)) //không có tên form
                return;
            //Qua khỏi
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý NCC và Danh mục Giấy";
            frm.StartPosition = FormStartPosition.CenterParent;     
            frm.ShowDialog();
            
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
                ThongDiepCanThiet = "Chỉ tính toán thử",

            };
            return thongTinBanDau;
        }

        
      
        private void btnQuanLyGiay_Click(object sender, EventArgs e)
        {
            QuanLyGiayForm frm = new QuanLyGiayForm();
            if (!CoTheMoFormNay(frm.Name)) //không có tên form
                return;
            //Qua khỏi
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý Giấy";
            frm.StartPosition = FormStartPosition.CenterParent;     
            frm.ShowDialog();
        }

       
     

       



      

        private void btnMayInDigi_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyMayInDigiForm();
            if (!CoTheMoFormNay(frm.Name)) //không có tên form
                return;
            //Qua khỏi
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý Máy in Digital";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnQLyToInMayDigi_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyToInMayDigiForm();
            if (!CoTheMoFormNay(frm.Name)) //không có tên form
                return;
            //Qua khỏi
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản ký Tờ in máy Digital";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnKhoSanPham_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyKhoSanPhamForm();
            if (!CoTheMoFormNay(frm.Name)) //không có tên form
                return;
            //Qua khỏi
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý Khổ Sản phẩm";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnBangGiaInNhanh_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyBGiaInNhanhForm();
            if (!CoTheMoFormNay(frm.Name)) //không có tên form
                return;
            //Qua khỏi
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản ký Bảng giá In nhanh";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnCanPhu_Click(object sender, EventArgs e)
        {
            var frm = new  QuanLyCanPhuForm();
            if (!CoTheMoFormNay(frm.Name)) //không có tên form
                return;
            //Qua khỏi
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý Cán phủ";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnCanGap_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyCanGapForm();
            if (!CoTheMoFormNay(frm.Name)) //không có tên form
                return;
            //Qua khỏi
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý Cấn gấp";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnQuanLy_DongCuon_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyDongCuonForm();
            if (!CoTheMoFormNay(frm.Name)) //không có tên form
                return;
            //Qua khỏi
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý Đóng cuốn";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnEpKim_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyEpKimForm();
            if (!CoTheMoFormNay(frm.Name)) //không có tên form
                return;
            //Qua khỏi
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý Ép kim";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnLoiNhuanGiay_Click(object sender, EventArgs e)
        {
            QuanLyMarkUpLoiNhuanGiayForm frm = new QuanLyMarkUpLoiNhuanGiayForm();
            if (!CoTheMoFormNay(frm.Name)) //không có tên form
                return;
            //Qua khỏi
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Cài đặt lợi nhuận giấy";
            frm.ShowDialog();

        }

        private void btnBangGiaGiay_Click(object sender, EventArgs e)
        {
                       
            BangGiaGiayForm frm = new BangGiaGiayForm(FormStateS.View);           
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Bảng giá giấy theo hạng KH ";
            frm.ShowDialog();
        }

        private void btnNhuEpKim_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyNhuEpKimForm();
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý Nhũ ép kim ";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

      

        private void btnQuanLyLoXo_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyLoXoDongCuonForm();
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý Lò xo ";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void NhapLieuMainForm_Load(object sender, EventArgs e)
        {
            this.TenNguoiDung = TenMayTinhHienTai(); //"Tên người dùng";
        }
        private bool CoTheMoFormNay(string tenForm)
        {
            bool kq = true;
            if (string.IsNullOrEmpty(txtTenNguoiDung.Text.Trim()))
            {
                MessageBox.Show("Tên người dùng chưa đúng!");
                return false;
            }
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
            txtTenNguoiDung.Left = lblNguoiDung.Left + lblNguoiDung.Width + 5;
        }

    

        private void btnQuanLy_DongCuonMP_Click(object sender, EventArgs e)
        {
            QuanLyDongCuonMoPhang();
        }
        private void QuanLyDongCuonMoPhang()
        {
            var frm = new QuanLyDongCuonMPForm();
            if (!CoTheMoFormNay(frm.Name)) //không có tên form
                return;
            //Qua khỏi
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý Đóng cuốn Mở phẳng";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void pnlBottom_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnQuanLy_CatDecal_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyCatDecalForm();
            if (!CoTheMoFormNay(frm.Name)) //không có tên form
                return;
            //Qua khỏi
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý Cắt Decal";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnQuanLy_BoiBiaCung_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyBoiBiaCungForm();
            if (!CoTheMoFormNay(frm.Name)) //không có tên form
                return;
            //Qua khỏi
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý Bồi bìa cứng";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnQuanLy_ToBoiBiaCung_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyToBoiBiaCungForm();
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý Tờ bồi Bìa cứng";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnQuanLy_ToLotDongMoPhang_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyToLotDCMPForm();
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý Tờ lót";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnGiaTuyChonDanhThiep_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyTChonDThiepForm();
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý Giá tùy chọn";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnBangGiaDanhThiep_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyBGiaDThiepForm();
            if (!CoTheMoFormNay(frm.Name)) //không có tên form
                return;
            //Qua khỏi
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý Bảng giá danh thiếp";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnBangGiaTheNhua_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyBGiaThNhuaForm();
            if (!CoTheMoFormNay(frm.Name)) //không có tên form
                return;
            //Qua khỏi
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý Bảng giá Thẻ nhựa";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnGiaTuyChonTheNhua_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyTChonThNhuaForm();
            if (!CoTheMoFormNay(frm.Name)) //không có tên form
                return;
            //Qua khỏi
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý Tùy chọn Thẻ nhựa";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
        private void QuanLyDongCuonLoXo()
        {
            var frm = new QuanLyDongCuonLXoForm();
            if (!CoTheMoFormNay(frm.Name)) //không có tên form
                return;
            //Qua khỏi
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý Đóng cuốn Lò xo";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
        private void btnQuanLy_DCuonLXo_Click(object sender, EventArgs e)
        {
            QuanLyDongCuonLoXo();
        }

        private void btnNY_GiaInNhanh_Click(object sender, EventArgs e)
        {
            var frm = new NiemYetGiaInNhanhForm();
            frm.TinhTrangForm = FormStateS.View;
            //if (!CoTheMoFormNay(frm.Name)) //không có tên form
             //   return;
            //Qua khỏi
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Niêm yết giá in nhanh";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnQuanLyBangGia_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyBangGiaForm();
            
            //if (!CoTheMoFormNay(frm.Name)) //không có tên form
            //   return;
            //Qua khỏi
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý các Bảng giá";
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
       
       
    }
}
