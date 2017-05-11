using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using TinhGiaInClient.Model;

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
        private string TenMayTinhHienTai()
        {
            return System.Environment.MachineName;
        }
        public string TenNguoiDung
        {
            get { return txtTenNguoiDung.Text; }
            set { txtTenNguoiDung.Text = value; }
        }
        private void btnKeQuaChaoGia_Click(object sender, EventArgs e)
        {
            if (frmLietKeTinhGia == null)
            {
                frmLietKeTinhGia = new LietKeTinhGiaForm(null);
                frmLietKeTinhGia.KieuSapXep = (int)Enumss.SapXepTinhGia.Khong;
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
                frmBangGiaGiay = new BangGiaGiayForm();              
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
            }
           
                
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.TenNguoiDung.Trim()))
            {
                MessageBox.Show("Bạn cần điền tên người dùng");
                return;
            }
            var thongTinBanDau = new ThongTinBanDauChoTinhGia();
            thongTinBanDau.TenNguoiDung = this.TenNguoiDung;
            thongTinBanDau.TinhTrangForm = FormStates.New;

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
    }
}
