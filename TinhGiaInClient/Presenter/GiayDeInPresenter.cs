﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;
using TinhGiaInClient.Model.Support;

namespace TinhGiaInClient.Presenter
{
    public class GiayDeInPresenter
    {
        IViewGiayDeIn View;
        GiayDeIn MucGiayDeIn = null;

        public GiayDeInPresenter(IViewGiayDeIn view, GiayDeIn giayDeIn)
        {
            View = view;
            MucGiayDeIn = giayDeIn;

            View.ID = MucGiayDeIn.ID;
            View.IdBaiIn = MucGiayDeIn.IdBaiIn;
            View.ToChayRong = MucGiayDeIn.ToChayRong;
            View.ToChayDai = MucGiayDeIn.ToChayDai;
            View.SoConTrenToChay = MucGiayDeIn.SoConTrenToChay;
            View.SoLuongToChayBuHao = MucGiayDeIn.SoToChayBuHao;
            View.GiayKhachDua = MucGiayDeIn.GiayKhachDua;
            View.TenGiayIn = MucGiayDeIn.TenGiayIn;
            
           
            View.SoToChayTrenToLon = MucGiayDeIn.SoToChayTrenToLon;
            
            View.IdGiay = MucGiayDeIn.IdGiay;

        }
        private void KhoiTaoGiaTriBanDau()
        {            
          /*  
            View.SoLuongToChayBuHao = 1;
            View.SoConTrenToChay = 1;
            View.SoToChayTrenToLon = 1;
            View.ToChayDai = 1;
            View.ToChayRong = 1;
           */

        }
        public int SoToChayLyThuyetTinh()
        {
         

            int kq = 0;
            if (View.SoConTrenToChay <= 0 || View.SoLuongSanPham <= 0)
                return kq;
            //Tiếp nếu quá
            if (View.SoLuongSanPham % View.SoConTrenToChay > 0)//Chia lẻ
                kq = View.SoLuongSanPham / View.SoConTrenToChay + 1;
            else
                kq = View.SoLuongSanPham / View.SoConTrenToChay;

            return kq;

         
        }
        public int SoToChayTong()
        {
            int result = 0;

            if (View.SoConTrenToChay <= 0 || View.SoLuongSanPham <= 0)
                return result;
            //Tiếp nếu quá
            result = SoToChayLyThuyetTinh() + View.SoLuongToChayBuHao;

            return result;

        }
        public int SoToGiayLon()
        {

            int kq = 0;
            if (View.SoConTrenToChay <= 0 || View.SoLuongSanPham <= 0)
                return kq;
            //Tiếp nếu quá
            if (SoToChayTong()  % View.SoToChayTrenToLon > 0)//Chia lẻ
                kq = SoToChayTong() / View.SoToChayTrenToLon + 1;
            else
                kq = SoToChayTong() / View.SoToChayTrenToLon;

            return kq;
        }
       
    
       
        private int TyLeMarkUp()
        {
            var result = 0;
            if (View.IdGiay > 0)
            {
                var giay = Giay.DocGiayTheoId(View.IdGiay);
                result = MarkUpLoiNhuanGiay.LayTheoId(giay.IdDanhMucGiay, View.IdHangKH).TiLeLoiNhuanTrenDoanhThu;
            }
            return result;
        }

        public decimal GiaBan()
        {
            decimal result = 0;
            if (!View.GiayKhachDua && View.IdGiay > 0)
            {
                var giay = Giay.DocGiayTheoId(View.IdGiay);
                var giaGiay = new GiaGiay(giay, TyLeMarkUp());
                result = giaGiay.GiaBan();
            }
            return result;
        }
        public decimal ThanhTien()
        {
            return GiaBan() * View.SoToGiayLon;

        }
        private void CapNhatMucGiayDeIn()
        {
            if (this.MucGiayDeIn != null)
            {
                this.MucGiayDeIn.ID = View.ID;
                this.MucGiayDeIn.IdBaiIn = View.IdBaiIn;
                this.MucGiayDeIn.SoConTrenToChay = View.SoConTrenToChay;
                this.MucGiayDeIn.SoToChayBuHao = View.SoLuongToChayBuHao;
                this.MucGiayDeIn.GiayKhachDua = View.GiayKhachDua;
                this.MucGiayDeIn.TenGiayIn = View.TenGiayIn;
                this.MucGiayDeIn.SoToChayLyThuyet = View.SoLuongToChayLyThuyet;
                this.MucGiayDeIn.ToChayRong = View.ToChayRong;
                this.MucGiayDeIn.SoToChayTrenToLon = View.SoToChayTrenToLon;
                this.MucGiayDeIn.SoToLonTong = View.SoToGiayLon; 
                this.MucGiayDeIn.ToChayDai = View.ToChayDai;
                this.MucGiayDeIn.SoToChayTrenToLon = View.SoToChayTrenToLon;
                this.MucGiayDeIn.IdGiay = View.IdGiay;
                this.MucGiayDeIn.ThanhTienGiay = View.ThanhTien;
               
            }
        }
        public GiayDeIn DocGiayDeIn()
        {
            CapNhatMucGiayDeIn();            
            return this.MucGiayDeIn;
        }
    }
}
