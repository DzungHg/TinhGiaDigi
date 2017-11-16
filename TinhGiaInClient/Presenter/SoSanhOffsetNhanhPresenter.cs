using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;
using TinhGiaInClient.Common.Enum;
using TinhGiaInClient.Model.Support;



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
            //Digi
            View.GiaGiayDigi = 0;
            View.ToChayRongDigi = 32f;
            View.ToChayCaoDigi = 48.5f;

            View.SoLuongSP = 1000;
            View.KieuInDigi = MotHaiMat.HaiMat;
            View.SoSanPhamTrenToChayDigi = 1;
            View.SoToChayTrenToLonDigi = 1;
            View.SoToChayBuHaoDigi = 1;
            //Offset
            View.GiaGiayOffset = 0;
            View.ToChayRongOffset = 36f;
            View.ToChayCaoOffset = 52f;
            View.SoSanPhamTrenToChayOffset = 1;            
            View.SoToChayTrenToLonOffset = 1;            
            View.SoToChayBuHaoOffset = 1;
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
                View.KhoGiayRongDigi = giay.ChieuNgan;
                View.KhoGiayCaoDigi = giay.ChieuDai;
            }
        }
        public void CapNhatChiTietGiayOffset()
        {
            if (View.IdGiayOffsetChon > 0)
            {
                var giay = Giay.DocGiayTheoId(View.IdGiayOffsetChon);
                View.TenGiayOfset = giay.TenGiayMoRong;
                View.GiaGiayOffset = giay.GiaMua;
                View.KhoGiayRongOffset = giay.ChieuNgan;
                View.KhoGiayCaoOffset = giay.ChieuDai;
            }
        }
        public void CapNhatKhoToChayDigi()
        {
            if (View.IdMayInDiGiChon <= 0 )
                return;

            var mayIn = ToInMayDigi.DocTheoId(View.IdMayInDiGiChon);
            View.ToChayRongDigi = mayIn.Rong;
            View.ToChayCaoDigi = mayIn.Cao;
            View.SoToChayBuHaoDigi = 1;
        }
        
        public void CapNhatKhoToChayOffset()
        {
            if (View.IdMayInOffsetChon <= 0)
                return;

            var mayIn = OffsetGiaCong.DocTheoId(View.IdMayInOffsetChon);
            View.ToChayRongOffset = mayIn.KhoInRongMax;
            View.ToChayCaoOffset = mayIn.KhoInDaiMax;
            View.SoToChayBuHaoOffset = mayIn.SoToChayBuHaoCoBan;
        }
        #region về in digi
        public int SoToChayLyThuyetDigi()
        {
            var kq = 0;
            if (View.SoSanPhamTrenToChayDigi <= 0 || View.SoLuongSP <= 0)
                return 0;
            //
            kq = (int)View.SoLuongSP / View.SoSanPhamTrenToChayDigi;
            if (View.SoLuongSP % View.SoSanPhamTrenToChayDigi > 0)//dư cần thêm giấy
                kq += 1;

            return kq;
        }
        public int TongSoToChayDigi()
        {
           if (this.SoToChayLyThuyetDigi() <= 0)
               return 0;

            return this.SoToChayLyThuyetDigi() + View.SoToChayBuHaoDigi;
        }
        public int SoConTrenToLon(float toRong, float toCao,
            float conRong, float conCao)
            
        {
            return TinhToan.SoConTrenToChayDigi(toRong, toCao,
                conRong, conCao);
        }
       
        public int TongSoToGiayLonDigi()
        {
            var kq = 0;          
            if (View.SoToChayTrenToLonDigi > 0)
            {
                kq = (int)View.TongSoToChayDigi / View.SoToChayTrenToLonDigi;
                //Không cần chính xác nên tính vậy
            }
            return kq;
        }
       
        #endregion
        #region phần offset
        public int SoToChayLyThuyetOffset()
        {
            var kq = 0;
            if (View.SoSanPhamTrenToChayOffset <= 0 || View.SoLuongSP <= 0)
                return 0;
            //
            kq = (int)View.SoLuongSP / View.SoSanPhamTrenToChayOffset;
            if (View.SoLuongSP % View.SoSanPhamTrenToChayDigi > 0)//dư cần thêm giấy
                kq += 1;

            return kq;
        }
        public int TongSoToChayOffset()
        {
            if (this.SoToChayLyThuyetOffset() <= 0)
                return 0;

            return this.SoToChayLyThuyetOffset() + View.SoToChayBuHaoOffset;
        }
        public void CapNhatSoToChayLyThuyetTrenToGiayLonOffset()
        {
            var soToChayTrenToGiay = 0;

            if (View.IdGiayOffsetChon > 0 && View.TongSoToChayOffset > 0)
            {
                var giay = Giay.DocGiayTheoId(View.IdGiayOffsetChon);
                soToChayTrenToGiay = TinhToan.SoConTrenToChayDigi(View.ToChayRongOffset,
                    View.ToChayCaoOffset, giay.ChieuNgan, giay.ChieuDai);
            }
            //Cập nhật
            View.SoToChayTrenToLonOffset = soToChayTrenToGiay;
        }
        public int TongSoToGiayLonOffset()
        {
            var kq = 0;
            if (View.SoToChayTrenToLonOffset > 0)
            {
                kq = (int)View.TongSoToChayOffset / View.SoToChayTrenToLonOffset;
                //Không cần chính xác nên tính vậy
            }
            return kq;
        }
       
       
#endregion
        public decimal PhiGiayDigi()
        {
            var kq = 0m;
            if (View.GiaGiayDigi > 0)
            {
                kq = View.GiaGiayDigi * View.TongSoToGiayLonDigi;
            }

            return kq;
        }
        public decimal PhiGiayTrenMoiBaiOffset()
        {
            var kq = 0m;
            if (View.GiaGiayOffset > 0)
            {
                kq = View.GiaGiayOffset * View.TongSoToGiayLonOffset;
            }

            return kq;
        }
        public int SoMatInOffset()
        {
            
            int result = 0;
            switch (View.KieuInOffset)
            {
                case KieuInOffsetS.AB:
                case KieuInOffsetS.TuTro:
                case KieuInOffsetS.TuTroNhip:
                    result = View.TongSoToChayOffset * 2;
                    break;
                case KieuInOffsetS.MotMat:
                    result = View.TongSoToChayOffset * 1;
                    break;
            }
            return result;
        }
    
       
        public decimal GiaInMotBaiOffset()
        {  
           
            var mayInOffset = OffsetGiaCong.DocTheoId(View.IdMayInOffsetChon);

            var giaInOffset = new GiaInOffsetGiaCong(mayInOffset, SoMatInOffset(), 0,
                            View.KieuInOffset);
                                
            return giaInOffset.ThanhTien_In();
        }
        public decimal PhiInOffsetTong()
        {
            return GiaInMotBaiOffset() * View.SoLuotInOffset;
        }
        public decimal PhiGiayOffsetTong()
        {
            return PhiGiayTrenMoiBaiOffset() * View.SoLuotInOffset;
        }
        public decimal TongPhiJobOffset()
        {
            return this.PhiInOffsetTong() + this.PhiGiayOffsetTong()
                + View.PhiVanChuyenOffset + View.PhiCanhBaiOffset;

        }
#region tính phí in digital
        private int SoTrangA4Digi()
        {
            var kq = 0;
            if (View.SoLuongSP <= 0 || View.TongSoToChayDigi <= 0)
                return 0;
            var soMat = 1;
            if (View.KieuInDigi == MotHaiMat.HaiMat)
                soMat = 2;

            var mayIn = ToInMayDigi.DocTheoId(View.IdMayInDiGiChon);

            kq = mayIn.QuiA4 * View.TongSoToChayDigi * soMat;
            return kq;
        }
        public decimal PhiInDigi()
        {
            var kq = 0m;
            if (View.TongSoToChayDigi <= 0)
                return kq;

            var mayIn = ToInMayDigi.DocTheoId(View.IdMayInDiGiChon);
            var duLieuTinhGia = new DuLieuTinhGiaInNhanhTheoMay()
                {
                    BHR = mayIn.BHR,
                    ClickTrangA4 = mayIn.ClickA4BonMau,
                    DayLoiNhuan = mayIn.DayLoiNhuan,
                    DaySoLuong = mayIn.DaySoLuong,
                    InTuTro = mayIn.InTuTro,
                    PhiPhePhamSanSang = mayIn.PhiPhePhamSanSang,
                    ThoiGianSanSang = mayIn.ThoiGianSanSang,
                    TocDo = mayIn.TocDo
                };
           
            var giaIn = new GiaInNhanhTheoMay(duLieuTinhGia,
                this.SoTrangA4Digi(), 0);

            kq = giaIn.ChiPhi(this.SoTrangA4Digi());

            return kq;
        }
        public decimal TongPhiJobDigi()
        {
            return this.PhiGiayDigi() + this.PhiInDigi();
        }
#endregion
        
    }
}
