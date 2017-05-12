﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TinhGiaInClient.View;
using TinhGiaInClient.Presenter;

namespace TinhGiaInClient.UI
{
    
    public partial class BangGiaThanhPhamForm : Telerik.WinControls.UI.RadForm, IViewBangGiaThanhPham
    {
        public BangGiaThanhPhamForm()
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
            lstDichVuThanhPham.DataSource = bangGiaThPhPres.MonThanhPhamS();
        }

        private void lstDichVuThanhPham_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            bangGiaThPhPres.TrinhBayDuLieuThanhPhamTheoMon();
        }
        private void TrinhBaySoLuong_Gia()
        {
            Telerik.WinControls.UI.CardViewItem cardItem;
            Telerik.WinControls.UI.LayoutControlItem layOutItem;
            Telerik.WinControls.UI.RadLabel lb;
            
            for (int i = 0; i < bangGiaThPhPres.SoLuong_GiaS().Length; ++i)
            {
                cardItem = new Telerik.WinControls.UI.CardViewItem();
                cardItem.Text = bangGiaThPhPres.SoLuong_GiaS()[i].SoLuong.ToString();
                cardItem.Text = bangGiaThPhPres.SoLuong_GiaS()[i].Gia.ToString();
                layOutItem = new Telerik.WinControls.UI.LayoutControlItem();
                lb = new Telerik.WinControls.UI.RadLabel();
                lb.Text = string.Format("{0}" + '\r' + '\n' + "{1:0,0.00}", bangGiaThPhPres.SoLuong_GiaS()[i].SoLuong,
                    bangGiaThPhPres.SoLuong_GiaS()[i].Gia);
                flowLayOut.Controls.Add(lb);
            }
        }

        private void btnTinhGia_Click(object sender, EventArgs e)
        {
            TrinhBaySoLuong_Gia();
        }
    }
}
