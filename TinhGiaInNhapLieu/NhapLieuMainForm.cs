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

namespace TinhGiaInNhapLieu
{
    public partial class NhapLieuMainForm : Form
    {
        public NhapLieuMainForm()
        {
            InitializeComponent();
            LoadHangKhachHang();
        }
        
        private void LoadHangKhachHang()
        {
            var nguon = HangKhachHang.LayTatCa();
            cboHangKH.ValueMember = "ID";
            cboHangKH.DisplayMember = "Ten";
            cboHangKH.DataSource = nguon;
            cboHangKH.DropDownStyle = ComboBoxStyle.DropDownList;
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

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            QuanLyMarkUpLoiNhuanGiayForm frm = new QuanLyMarkUpLoiNhuanGiayForm();
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Cài đặt lợi nhuận giấy";
            frm.ShowDialog();
        }

        private void btnQuanLyDanhMucGiay_Click(object sender, EventArgs e)
        {
            QuanLyDanhMucGiayForm frm = new QuanLyDanhMucGiayForm();
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý NCC và Danh mục Giấy";
            frm.ShowDialog();
        }

        private void btnQuanLyGiay_Click(object sender, EventArgs e)
        {
            QuanLyGiayForm frm = new QuanLyGiayForm();
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Quản lý Giấy";
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BangGiaGiayForm frm = new BangGiaGiayForm(FormStateS.View);
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = "Bảng giá giấy theo hạng KH ";
            frm.ShowDialog();
        }

        private void btnTinhThu_CanPhu_Click(object sender, EventArgs e)
        {
            var idHangKH = int.Parse(cboHangKH.SelectedValue.ToString());
            var thongTinBanDau = this.thongTinBanDauChoThPh(idHangKH, LoaiThanhPhamS.CanPhu,
                FormStateS.View,"Cán Phủ [Tính thử]", "Mặt" );
            var frm = new ThPhCanPhuForm( thongTinBanDau );
            
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
            var frm = new ThPhCanGapForm( thongTinBanDau );
            
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
            var frm = new ThPhDongCuonForm(thongTinBanDau);
            
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
            var frm = new ThPhEpKimForm(thongTinBanDau);
           
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
    }
}
