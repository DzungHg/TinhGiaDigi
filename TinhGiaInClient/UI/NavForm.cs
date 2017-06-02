using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using TinhGiaInClient.Model;
using TinhGiaInClient.Model.Support;

namespace TinhGiaInClient.UI
{
    public partial class NavForm : Telerik.WinControls.UI.RadForm
    {
        public NavForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Tính giá In";
            this.TenNguoiDung = TenMayTinhHienTai();
        }
        LietKeTinhGiaForm frmLietKeTinhGia;
        BangGiaGiayForm frmBangGiaGiay;
        BangGiaThanhPhamForm frmBangGiaThanhPham;
        BangGiaInNhanhForm frmBangGiaInNhanh;
        BangGiaInNhanhMayForm frmBangGiaInNhanhMay;
        //BangGiaDongCuonForm frmDongCuonLoXo;
        private string TenMayTinhHienTai()
        {
            return System.Environment.MachineName;
        }
        public string TenNguoiDung
        {
            get { return txtTenNguoiDung.Text.Trim(); }
            set { txtTenNguoiDung.Text = value; }
        }
        private void btnKeQuaChaoGia_Click(object sender, EventArgs e)
        {
            if (frmLietKeTinhGia == null)
            {
                frmLietKeTinhGia = new LietKeTinhGiaForm();
                frmLietKeTinhGia.KieuSapXep = SapXepTinhGiaS.Khong;
                frmLietKeTinhGia.FormClosed += new FormClosedEventHandler(ByByWindows);
                //frmLietKeTinhGia.MdiParent = this;
                frmLietKeTinhGia.Show();

            }
            else frmLietKeTinhGia.Focus();
        }

        private void btnBangGiaGiay_Click(object sender, EventArgs e)
        {
            if (frmBangGiaGiay == null)
            {
                frmBangGiaGiay = new BangGiaGiayForm(FormStateS.View);              
                frmBangGiaGiay.FormClosed += new FormClosedEventHandler(ByByWindows);               
                frmBangGiaGiay.Show();

            }
            else frmBangGiaGiay.Focus();
        }
        private void ByByWindows(object sender, FormClosedEventArgs e)
        {
            Form frm;
            if (sender is Form)
            {
                frm = (Form)sender;
                if (frm == frmLietKeTinhGia)
                    frmLietKeTinhGia = null;
                if (frm == frmBangGiaGiay)
                    frmBangGiaGiay = null;
                if (frm == frmBangGiaThanhPham)
                    frmBangGiaThanhPham = null;
                if (frm == frmBangGiaInNhanh)
                    frmBangGiaInNhanh = null;
                if (frm == frmBangGiaInNhanhMay)
                    frmBangGiaInNhanhMay = null;
            }
           
                
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.TenNguoiDung))
            {
                MessageBox.Show("Bạn cần điền tên người dùng");
                return;
            }
            var thongTinBanDau = new ThongTinBanDauChoTinhGia();
            thongTinBanDau.TenNguoiDung = this.TenNguoiDung;
            thongTinBanDau.TinhTrangForm = FormStateS.New;
            //Kiểm tra người dùng có trong database không
            var nguoiDung = NguoiDung.DocTheoTenDangNhap(thongTinBanDau.TenNguoiDung);

            if (nguoiDung.ID == 0)
            {
                MessageBox.Show("Bạn chưa có tài khoản sử dụng");
                return;
            }
            
            var frm = new TinhGiaForm(thongTinBanDau);
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
           
            //frm.FormState = (int)Ennums.FormState.New;
            frm.Text = "Tính giá sản phẩm";
            frm.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void dbtnBangGia_Click(object sender, EventArgs e)
        {

        }

        private void btnBangGiaThanhPham_Click(object sender, EventArgs e)
        {
            if (frmBangGiaThanhPham == null)
            {
                frmBangGiaThanhPham = new BangGiaThanhPhamForm();
                frmBangGiaThanhPham.MinimizeBox = false;
                frmBangGiaThanhPham.MaximizeBox = false;                
                frmBangGiaThanhPham.FormClosed += new FormClosedEventHandler(ByByWindows);
                frmBangGiaThanhPham.Show();

            }
            else frmBangGiaThanhPham.Focus();
        }

        private void btnBangGiaInNhanh_Click(object sender, EventArgs e)
        {
            if (frmBangGiaInNhanh == null)
            {
                frmBangGiaInNhanh = new BangGiaInNhanhForm();
                frmBangGiaInNhanh.MinimizeBox = false;
                frmBangGiaInNhanh.MaximizeBox = false;
                frmBangGiaInNhanh.FormClosed += new FormClosedEventHandler(ByByWindows);
                frmBangGiaInNhanh.Show();

            }
            else frmBangGiaInNhanh.Focus();
        }

        private void btnInNhanhTheoMay_Click(object sender, EventArgs e)
        {
            if (frmBangGiaInNhanhMay == null)
            {
                frmBangGiaInNhanhMay = new BangGiaInNhanhMayForm();
                frmBangGiaInNhanhMay.MinimizeBox = false;
                frmBangGiaInNhanhMay.MaximizeBox = false;
                frmBangGiaInNhanhMay.FormClosed += new FormClosedEventHandler(ByByWindows);
                frmBangGiaInNhanhMay.Show();

            }
            else frmBangGiaInNhanhMay.Focus();
        }

        
    }
}
