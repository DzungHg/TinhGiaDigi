using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;

namespace TinhGiaInClient.View
{
    public interface IViewGiaInNhanhThu
    {
        
        int KieuIn { get; set; }
        int IdToInDigiChon { get; }
        int IdHangKH { get; set; }
        string TenBangGiaChon { get; set; }
        int SoToChay { get; set; }
        int SoTrangA4 { get; }
        int SoTrangToiDaTheoBangGia { get; set; }
        decimal TienIn { get; set; }
        string GiaTBTrangInfo { get; set; }
        int PhuongPhapIn { get; }

        FormStateS TinhTrangForm { get; set; }
        /*
        List<ToChayDigi> ToChayDigiS { get; set; }
        List<BangGiaInNhanh> BangGiaInNhanhS { get; set; }
        */
    }
}
