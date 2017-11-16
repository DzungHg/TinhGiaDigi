using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.View
{
    public interface IViewSoSanhOffsetNhanh
    {
        string TieuDe { get; set; }
        float SanPhamRong { get; set; }
        float SanPhamCao { get; set; }
        int SoLuongSP { get; set; }
        int IdGiayDiGiChon { get; set; }
        int IdGiayOffsetChon { get; set; }
        float KhoGiayRongDigi { get; set; }
        float KhoGiayCaoDigi { get; set; }
        float KhoGiayRongOffset { get; set; }
        float KhoGiayCaoOffset { get; set; }
        int GiaGiayDigi { get; set; }
        int GiaGiayOffset { get; set; }
        string TenGiayDigi { get; set; }
        string TenGiayOfset { get; set; }
        MotHaiMat KieuInDigi { get; set; }
        KieuInOffsetS KieuInOffset { get; set; }
        int IdMayInDiGiChon { get; set; }
        int IdMayInOffsetChon { get; set; }
        int SoSanPhamTrenToChayDigi { get; set; }
        int SoSanPhamTrenToChayOffset { get; set; }
        float ToChayRongDigi { get; set; }
        float ToChayCaoDigi { get; set; }
        float ToChayRongOffset { get; set; }
        float ToChayCaoOffset { get; set; }
      
        int SoToChayLyThuyetDigi { get; set; }
        int SoToChayLyThuyetOffset { get; set; }
        int SoToChayBuHaoDigi { get; set; }
        int SoToChayBuHaoOffset { get; set; }
        int TongSoToChayDigi { get; set; }
        int TongSoToChayOffset { get; set; }
        int SoToChayTrenToLonDigi { get; set; }
        int SoToChayTrenToLonOffset { get; set; }
        int TongSoToGiayLonDigi { get; set; }
        int TongSoToGiayLonOffset { get; set; }
        int SoLuotInOffset { get; set; }
        int PhiVanChuyenOffset { get; set; }
        int PhiCanhBaiOffset { get; set; }
        decimal PhiGiayOffset { get; set; }
        decimal PhiGiayDigi { get; set; }
        decimal PhiInOffset { get; set; }
        decimal PhiInDigi { get; set; }
        decimal TongPhiDigi { get; set; }
        decimal TongPhiOffset { get; set; }

        string GiaTBTrangInfo { get; }
        
       
    }
}
