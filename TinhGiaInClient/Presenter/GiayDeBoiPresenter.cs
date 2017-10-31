using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;
using TinhGiaInClient.Model.Support;

namespace TinhGiaInClient.Presenter
{
    public class GiayDeBoiPresenter
    {
        IViewGiayDeBoi View;
        GiayDeBoi MucGiayDeBoi = null;

        public GiayDeBoiPresenter(IViewGiayDeBoi view, GiayDeBoi giayDeBoi)
        {
            View = view;
            MucGiayDeBoi = giayDeBoi;

            View.ID = MucGiayDeBoi.ID;
            View.IdBaiIn = MucGiayDeBoi.IdBaiIn;
            View.ToBoiRong = MucGiayDeBoi.ToBoiRong;
            View.ToBoiCao = MucGiayDeBoi.ToBoiDai;
            View.SoLuongToBoiLyThuyet = MucGiayDeBoi.SoToBoiLyThuyet;
            View.SoLuongToBoiBuHao = MucGiayDeBoi.SoToBoiBuHao;
           
            View.TenGiayBoi = MucGiayDeBoi.TenGiayIn;
                     
            View.SoToChayTrenToLon = MucGiayDeBoi.SoToBoiTrenToLon;
            
            
            View.IdGiay = MucGiayDeBoi.IdGiay;

        }
        public string TenGiayDeIn()
        {
            var kq = "";
            if (View.IdGiay > 0)
            {
                kq = string.Format("[{0}] {1}",
                    Giay.DocGiayTheoId(View.IdGiay).TenDanhMucGiay,
                    Giay.DocGiayTheoId(View.IdGiay).TenGiayMoRong);
            }
            return kq;
        }
        public void CapNhatGiayDeBoi()
        {
            if (View.IdGiay >0 )
            {
                var giay = Giay.DocGiayTheoId(View.IdGiay);
                View.TenGiayBoi = string.Format("[{0}] {1}",
                    giay.TenDanhMucGiay, giay.TenGiayMoRong);
                View.GiayLonRong = giay.ChieuNgan;
                View.GiayLonCao = giay.ChieuDai;
               
            }
            else
            {
                View.TenGiayBoi = "";
                View.GiayLonRong = 0;
                View.GiayLonCao = 0;
            }
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
       
        public int SoToBoiTongTong()
        {
            int result = 0;

            //Tiếp nếu quá
            result = View.SoLuongToBoiLyThuyet + View.SoLuongToBoiBuHao;

            return result;

        }
        public int SoToGiayLon()
        {

            int kq = 0;
            if (SoToBoiTongTong() <= 0 || View.SoToChayTrenToLon <=0)
                return kq;
            //Tiếp nếu quá
            if (SoToBoiTongTong()  % View.SoToChayTrenToLon > 0)//Chia lẻ
                kq = SoToBoiTongTong() / View.SoToChayTrenToLon + 1;
            else
                kq = SoToBoiTongTong() / View.SoToChayTrenToLon;

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

        public decimal GiaBanChoKhach()
        {
            decimal result = 0;
            if (View.IdGiay > 0)
            {
                var giay = Giay.DocGiayTheoId(View.IdGiay);
                var giaGiay = new GiaGiay(giay, TyLeMarkUp());
                result = giaGiay.GiaBan();
            }
            return result;
        }
        public decimal ThanhTien()
        {
            return GiaBanChoKhach() * View.SoToGiayLon;

        }
        private void CapNhatMucGiayDeBoi()
        {
            if (this.MucGiayDeBoi != null)
            {
                this.MucGiayDeBoi.ID = View.ID;
                this.MucGiayDeBoi.IdBaiIn = View.IdBaiIn;
               
                this.MucGiayDeBoi.SoToBoiBuHao = View.SoLuongToBoiBuHao;
               
                this.MucGiayDeBoi.TenGiayIn = View.TenGiayBoi;
                this.MucGiayDeBoi.SoToBoiLyThuyet = View.SoLuongToBoiLyThuyet;
                this.MucGiayDeBoi.ToBoiRong = View.ToBoiRong;
                this.MucGiayDeBoi.ToBoiDai = View.ToBoiCao;
               
                this.MucGiayDeBoi.SoToBoiTrenToLon = View.SoToChayTrenToLon;
                this.MucGiayDeBoi.SoToLonTong = View.SoToGiayLon; 
               
                this.MucGiayDeBoi.SoToBoiTrenToLon =  View.SoToChayTrenToLon;
             
                this.MucGiayDeBoi.IdGiay = View.IdGiay;
                this.MucGiayDeBoi.ThanhTienGiay = View.ThanhTien;
               
            }
        }
        public GiayDeBoi DocGiayDeBoi()
        {
            CapNhatMucGiayDeBoi();            
            return this.MucGiayDeBoi;
        }
    }
}
