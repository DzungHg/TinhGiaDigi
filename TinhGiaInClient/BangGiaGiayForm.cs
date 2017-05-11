﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TinhGiaInClient.View;
using TinhGiaInClient.Presenter;

namespace TinhGiaInClient
{
    public partial class BangGiaGiayForm : Form, IViewBangGiaGiay
    {
        BangGiaGiayPresenter bangGiaGiayPres;
        public BangGiaGiayForm()
        {
            InitializeComponent();
            bangGiaGiayPres = new BangGiaGiayPresenter(this);
            LoadHangKhachHang();
            LoadNhaCungCapGiay();
          
        }
        #region Implement Iview..

        public int IdHangKHChon
        {
            get { return int.Parse(cboHangKhachHang.SelectedValue.ToString()); }
        }

        int _idDanhMucGiayChon = 0;
        public int IdDanhMucGiayChon
        {
            get
            {
                if (lbxDanhMucGiay.SelectedValue != null)
                    int.TryParse(lbxDanhMucGiay.SelectedValue.ToString(), out _idDanhMucGiayChon);
                return _idDanhMucGiayChon;
            }
            set { _idDanhMucGiayChon = value;
                if (_idDanhMucGiayChon >0)
                {
                    lbxDanhMucGiay.SelectedValue = _idDanhMucGiayChon.ToString();
                }
            }
        }
        public string MaNhaCungCapChon
        {
            get {return cboNhaCC.Text; }
            set { cboNhaCC.Text = value; }
        }
       
       
      
        #endregion
        public void LoadNhaCungCapGiay()
        {
            cboNhaCC.DisplayMember = "Ten";
            cboNhaCC.ValueMember = "Ten";
            cboNhaCC.DataSource = bangGiaGiayPres.NhaCungCapS();

            //MessageBox.Show(NhaCungCap.DanhSachNCC().Count().ToString());
        }

        public void LoadHangKhachHang()
        {

            cboHangKhachHang.DisplayMember = "Ten";
            cboHangKhachHang.ValueMember = "ID";
            cboHangKhachHang.DataSource = bangGiaGiayPres.HangKhachHangS();

            //MessageBox.Show(NhaCungCap.DanhSachNCC().Count().ToString());
        }
        public void LoadDanhMucTheoNhaCungCap()
        {
            lbxDanhMucGiay.DisplayMember = "Ten";
            lbxDanhMucGiay.ValueMember = "ID";
            lbxDanhMucGiay.DataSource = bangGiaGiayPres.DanhMucTheoNhaCC();

        }
        private void ChuanBiGiayForm_Load(object sender, EventArgs e)
        {
            LoadNhaCungCapGiay();

            lblTieuDeForm.Text = this.Text;
        }

        private void cboNhaCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhMucTheoNhaCungCap();
        }
        private void LoadGiayTheoDanhMuc()
        {
            //Listview Sản phẩm
            lvwGiay.Clear();
            lvwGiay.Columns.Add("Id");
            lvwGiay.Columns.Add("Tên");
            lvwGiay.Columns.Add("Giá mua");
            lvwGiay.Columns.Add("Giá bán");
            lvwGiay.Columns.Add("Hạng KH");
            lvwGiay.View = System.Windows.Forms.View.Details;
            lvwGiay.HideSelection = false;
            lvwGiay.FullRowSelect = true;
            //Xóa;
            //MessageBox.Show(bangGiaGiayPres.GiayTheoDanhMucS().Count.ToString());
            if (this.IdDanhMucGiayChon <= 0)
                return;

            ListViewItem item;
            foreach (KeyValuePair<int, List<string>> kvp in bangGiaGiayPres.GiayTheoDanhMucS())
            {
                item = new ListViewItem();
                item.Text = kvp.Key.ToString();

                item.SubItems.AddRange(kvp.Value.ToArray());                
                lvwGiay.Items.Add(item);
            }
            lvwGiay.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwGiay.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwGiay.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvwGiay.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvwGiay.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);


        }
        
        private void lbxDanhMucGiay_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            LoadGiayTheoDanhMuc();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void lblGiaBanChoKH_Click(object sender, EventArgs e)
        {

        }

        private void lblTriGia_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtThongTinSanPham_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblChonGiay_Click(object sender, EventArgs e)
        {

        }

        private void txtTenDienGiai_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtSoToChayLyThuyet_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKhoToChay_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtSoToChayBuHao_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoToGiayLon_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lvwGiay_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           
        }

        private void cboHangKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDienGiaiHangKH.Text = bangGiaGiayPres.DienGiaiHangKH();
            LoadGiayTheoDanhMuc();
        }
       
        

        
    }

}
