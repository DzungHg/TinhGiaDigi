﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;
using TinhGiaInLogic;

namespace TinhGiaInClient.Presenter
{

    public class CanPhuPresenter : IThanhPhamPresenter
    {
        IViewThPhCanPhu View = null;
        MucThPhCanPhu MucCanPhu = null;
        public CanPhuPresenter(IViewThPhCanPhu view, MucThPhCanPhu mucThPham )
        {
            View = view;
            this.MucCanPhu = mucThPham;

            View.ID = this.MucCanPhu.ID;
            View.IdBaiIn = this.MucCanPhu.IdBaiIn;
            View.IdHangKhachHang = this.MucCanPhu.IdHangKhachHang;
            View.IdThanhPhamChon = this.MucCanPhu.IdThanhPhamChon;
            View.LoaiThPh = this.MucCanPhu.LoaiThanhPham;
            View.SoLuong = this.MucCanPhu.SoLuong;
            View.DonViTinh = this.MucCanPhu.DonViTinh;
            View.SoMatCan = this.MucCanPhu.SoMatCan;
               
           

        }
        public void KhoiTaoBanDau()
        {

            
            
        }

        public int TyLeMarkUp()
        {
            return HangKhachHang.LayTheoId(View.IdHangKhachHang).LoiNhuanChenhLech;
        }
        public string ThongTinHangKH(int idHangKH)
        {
            return HangKhachHang.LayTheoId(idHangKH).Ten;
        }
        //Dành cho display
        public List<CanPhu> ThanhPhamS()
        {
            return CanPhu.DocTatCa();
        }

        public decimal ThanhTien_ThPh()
        {
            decimal result = 0;
            if (View.IdBaiIn <= 0 || View.SoLuong <= 0 || View.IdThanhPhamChon <= 0 )
                return result;

            
            var canPhu = CanPhu.DocTheoId(View.IdThanhPhamChon);

            var tyLeMK = this.TyLeMarkUp();

            var giaCanPhu = new GiaCanPhu(View.SoLuong, View.DonViTinh,
                TyLeMarkUp(), canPhu);

            result = giaCanPhu.ThanhTienSales();

            return result;
        }

        public decimal GiaTB_ThPh()
        {
            if (View.SoLuong <= 0)
                return 0;
            return ThanhTien_ThPh() / View.SoLuong;
        }
        public MucThPhCanPhu LayMucThanhPham()
        {
            this.MucCanPhu.IdBaiIn = View.IdBaiIn;
            this.MucCanPhu.IdThanhPhamChon = View.IdThanhPhamChon;
            this.MucCanPhu.TenThanhPham = View.TenThanhPhamChon;
            this.MucCanPhu.IdHangKhachHang = View.IdHangKhachHang;
            this.MucCanPhu.LoaiThanhPham = View.LoaiThPh;
            this.MucCanPhu.SoLuong = View.SoLuong;
            this.MucCanPhu.DonViTinh = View.DonViTinh;
            this.MucCanPhu.ThanhTien = View.ThanhTien;
            this.MucCanPhu.SoMatCan = View.SoMatCan;
            return this.MucCanPhu;
        }
    }
}
