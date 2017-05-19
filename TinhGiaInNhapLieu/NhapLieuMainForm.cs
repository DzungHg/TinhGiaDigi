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
            var frm = new ThPhCanPhuForm("");
            frm.TinhTrangForm = (int)FormStateS.View;
            frm.LoaiThPh = LoaiThanhPhamS.CanPhu;
            frm.Text = "Cán Phủ [Tính thử]";
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            //Data gởi qua form

            frm.IdHangKhachHang = int.Parse(cboHangKH.SelectedValue.ToString());
            frm.IdBaiIn = 1;//Lừa để tính được.
            frm.ShowDialog();
        }

        private void btnTinhThu_CanGap_Click(object sender, EventArgs e)
        {
            var frm = new ThPhCanGapForm("");
            frm.TinhTrangForm = (int)FormStateS.View;
            frm.LoaiThPh = LoaiThanhPhamS.CanGap;
            frm.Text = "Cấn gấp [Tính thử]";
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            //Data gởi qua form

            frm.IdHangKhachHang = int.Parse(cboHangKH.SelectedValue.ToString());
            frm.IdBaiIn = 1;//Lừa để tính được.
            frm.ShowDialog();
        }

        private void btnTinhThu_DongCuon_Click(object sender, EventArgs e)
        {
            var frm = new ThPhDongCuonForm("");
            frm.TinhTrangForm = (int)FormStateS.View;
            frm.LoaiThPh = LoaiThanhPhamS.DongCuon;
            frm.Text = "Đóng cuốn [Tính thử]";
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            //Data gởi qua form

            frm.IdHangKhachHang = int.Parse(cboHangKH.SelectedValue.ToString());
            frm.IdBaiIn = 1;//Lừa để tính được.
            frm.ShowDialog();
        }

        private void btnTinhThu_EpKim_Click(object sender, EventArgs e)
        {
            var frm = new ThPhEpKimForm("");
            frm.TinhTrangForm = (int)FormStateS.View;
            frm.LoaiThPh = LoaiThanhPhamS.EpKim;
            frm.Text = "Ép kim [Tính thử]";
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            //Data gởi qua form

            frm.IdHangKhachHang = int.Parse(cboHangKH.SelectedValue.ToString());
            frm.IdBaiIn = 1;//Lừa để tính được.
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
