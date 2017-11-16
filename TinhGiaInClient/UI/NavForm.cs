using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;

using TinhGiaInClient.Model;
using TinhGiaInClient.Model.Support;
using TinhGiaInClient.Common.Enum;


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
            this.TenNguoiDung = TenMayTinhHienTai();// TenMayTinhHienTai();
        }
        LietKeTinhGiaForm frmLietKeTinhGia;
        BangGiaGiayForm frmBangGiaGiay;
        BangGiaThanhPhamForm frmBangGiaThanhPham;
        BangGiaInNhanhForm frmBangGiaInNhanh;
        BangGiaInNhanhMayForm frmBangGiaInNhanhMay;
        TinhThuForm frmTinhThu;
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
                if (frm == frmTinhThu)
                    frmTinhThu = null;
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

        private void btnTinhThu_Click(object sender, EventArgs e)
        {
            if (!CoTheMoFormNay("TinhThuForm")) //không có tên form
                return;
            //Qua khỏi
            if (frmTinhThu == null)
            {
                frmTinhThu = new TinhThuForm(this.TenNguoiDung);
                frmTinhThu.Text = "Tính thử";
                frmTinhThu.MinimizeBox = false;
                frmTinhThu.MaximizeBox = false;
                frmTinhThu.FormClosed += new FormClosedEventHandler(ByByWindows);
                frmTinhThu.Show();

            }
            else frmTinhThu.Focus();
        }

        private void NavForm_Load(object sender, EventArgs e)
        {

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

        
    }
}
