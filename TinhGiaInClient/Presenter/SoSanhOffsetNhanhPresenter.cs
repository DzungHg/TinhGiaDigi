using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;
using TinhGiaInClient.Common.Enum;



namespace TinhGiaInClient.Presenter
{
    public class SoSanhOffsetNhanhPresenter
    {
        IViewSoSanhOffsetNhanh View;

        public SoSanhOffsetNhanhPresenter(IViewSoSanhOffsetNhanh view)
        {
            View = view;
           
        }

        public void ResetForm()
        {
            View.TieuDe = "So sánh giá in digi và Offset của ...";
            View.PhiVanChuyenOffset = 200000;
            View.PhiCanhBaiOffset = 100000;
            View.SoLuotInOffset = 1;
            View.SanPhamCao = 29.7f;
            View.SanPhamRong = 21.0f;
            View.SoLuongSP = 1000;
        }

        public List<ToInMayDigi>MayInDigiS()
        {
            return ToInMayDigi.DocTatCa();
        }
       
        public List<OffsetGiaCong>MayInOffsetS()
        {
            return OffsetGiaCong.DocTatCa();
        }
        public void CapNhatChiTietGiayDigi()
        {
            if (View.IdGiayDiGiChon >0)
            {
                var giay = Giay.DocGiayTheoId(View.IdGiayDiGiChon);
                View.TenGiayDigi = giay.TenGiayMoRong;
                View.GiaGiayDigi = giay.GiaMua;
            }
        }
        public void CapNhatChiTietGiayOffset()
        {
            if (View.IdGiayOffsetChon > 0)
            {
                var giay = Giay.DocGiayTheoId(View.IdGiayOffsetChon);
                View.TenGiayOfset = giay.TenGiayMoRong;
                View.GiaGiayOffset = giay.GiaMua;
            }
        }
        public void CapNhatKhoToChayDigi()
        {
            if (View.IdMayInDiGiChon <= 0 )
                return;

            var mayIn = ToInMayDigi.DocTheoId(View.IdMayInDiGiChon);
            View.ToChayRongDigi = mayIn.Rong;
            View.ToChayCaoDigi = mayIn.Cao;
        }
        public void CapNhatKhoToChayOffset()
        {
            if (View.IdMayInOffsetChon <= 0)
                return;

            var mayIn = OffsetGiaCong.DocTheoId(View.IdMayInOffsetChon);
            View.ToChayRongOffset = mayIn.KhoInRongMax;
            View.ToChayCaoOffset = mayIn.KhoInDaiMax;
        }
        public int SoMatIn()
        {
            
            int result = 0;
            switch (View.KieuInOffset)
            {
                case KieuInOffsetS.AB:
                case KieuInOffsetS.TuTro:
                case KieuInOffsetS.TuTroNhip:
                    result = View.SoToChayLyThuyetDigi * 2;
                    break;
                case KieuInOffsetS.MotMat:                
                    result = View.SoToChayLyThuyetDigi * 1;
                    break;
            }
            return result;
        }
    
       
        public decimal GiaInMotBaiOffset()
        {  
           
            var mayInOffset = OffsetGiaCong.DocTheoId(View.IdMayInOffsetChon);

            var giaInOffset = new GiaInOffsetGiaCong(mayInOffset, SoMatIn(), 0,
                            View.KieuInOffset, View.PhiVanChuyenOffset, View.PhiCanhBaiOffset);
                                
            return giaInOffset.ThanhTien_In();
        }
        public decimal PhiInOffset()
        {
            return GiaInMotBaiOffset() * View.SoLuotInOffset;
        }
    }
}
