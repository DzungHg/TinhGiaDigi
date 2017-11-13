using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.View
{
    public interface IViewGiaInOffset
    {
        int ID { get; set; }
        int IdBaiIn { get; set; }
        int IdHangKH { get; set; }
        string TenHangKH { get; set; }        
        KieuInOffsetS KieuInOffset { get; set; }
        int IdMayIn { get; set; }
        string KhoToChay { get; set; }
        int SoTrangIn { get; }
        int SoToChay { get; set; }
        int PhiVanChuyen { get; set; }
        int PhiCanhBai { get; set; }
        decimal TienIn { get; set; }
        string GiaTBTrangInfo { get; }
        PhuongPhapInS PhuongPhapIn { get; }
        FormStateS TinhTrangForm { get; set; }
        /*
        List<ToChayDigi> ToChayDigiS { get; set; }
        List<BangGiaInNhanh> BangGiaInNhanhS { get; set; }
        */
    }
}
