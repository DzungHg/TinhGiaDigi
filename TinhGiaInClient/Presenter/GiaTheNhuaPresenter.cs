using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;



namespace TinhGiaInClient.Presenter
{
    public class GiaTheNhuaPresenter
    {
        IViewGiaTheNhua View;
        BaiInTheNhua MucBaInTheNhua { get; set; }

        public GiaTheNhuaPresenter(IViewGiaTheNhua view, BaiInTheNhua baiInTheNhua)
        {
            
            View = view;
            this.MucBaInTheNhua = baiInTheNhua;
            View.ID = this.MucBaInTheNhua.ID;
            View.IdBangGiaChon = this.MucBaInTheNhua.IdBangGia;
            View.SoLuong = this.MucBaInTheNhua.SoLuongThe;
            View.TenVatLieuBaoGom = this.MucBaInTheNhua.TenGiayBaoGom;
            View.SoMatIn = this.MucBaInTheNhua.SoMatIn;
           

           
        }
        public string TenHangKH ()
        {
            return HangKhachHang.LayTheoId(View.IdHangKH).Ten;
        }
        public int TyLeLoiNhuanTheoHangKH()
        {
            return HangKhachHang.LayTheoId(View.IdHangKH).LoiNhuanChenhLech;
        }
        public List<BangGiaTheNhua> BangGiaTheNhuaS()
        {
            return BangGiaTheNhua.DocTatCa();
        }
        
        public int SoHopToiDaTheoBangGia()
        {
            var kq = 0;
            if (View.IdBangGiaChon > 0)
                kq = BangGiaTheNhua.DocTheoId(View.IdBangGiaChon).SoTheToiDa;

            return kq;
        }
        public string KhoToChay()
        {
            var kq = "";
            if (View.IdBangGiaChon > 0)
                kq = BangGiaTheNhua.DocTheoId(View.IdBangGiaChon).KhoToChay;
            return kq;
        }
       
        public string NoiDungBangGia()
        {
            var kq = "";
            if (View.IdBangGiaChon > 0)
                kq = BangGiaTheNhua.DocTheoId(View.IdBangGiaChon).NoiDungBangGia;

            return kq;
        }
        
        
      
      
        public decimal ThanhTien()
        {
            return this.MucBaInTheNhua.ThanhTien();
        }
        public string GiaTBInfo()
        {
            return string.Format("{0:0,0.00}đ/Thẻ", this.MucBaInTheNhua.GiaTBThe);
        }
        private void CapNhatBaiInTheNhua()
        {
            this.MucBaInTheNhua.ID = View.ID;
            this.MucBaInTheNhua.SoMatIn = View.SoMatIn;
            this.MucBaInTheNhua.IdBangGia = View.IdBangGiaChon;

            this.MucBaInTheNhua.KichThuoc = View.KichThuoc;
            this.MucBaInTheNhua.SoLuongThe = View.SoLuong;         
        }
        public BaiInTheNhua DocBaiInTheNhua()
        {
            CapNhatBaiInTheNhua();
            return this.MucBaInTheNhua;
        }
    }
}
