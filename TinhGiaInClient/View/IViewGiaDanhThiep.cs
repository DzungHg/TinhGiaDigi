using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;

namespace TinhGiaInClient.View
{
    public interface IViewGiaDanhThiep
    {
        int ID { get; set; }        
        int IdHangKH { get; set; }
        string TenHangKH { get; set; }
        int SoMatIn { get; set; }
        int IdBangGiaChon { get; set; }        
        GiayDeIn GiayInChon { get; set; }
        string TenGiayChon { get; set; }
        string TenBangGiaChon { get; set; }
        string KichThuoc { get; set; }
        int SoLuong { get; set; }
        decimal TienIn { get; set; }
        decimal TienGiay { get; set; }
        decimal ThanhTien { get; set; }
        string GiaTBHopInfo { get; set; }
        FormStates TinhTrangForm { get; set; }
        /*
        List<ToChayDigi> ToChayDigiS { get; set; }
        List<BangGiaInNhanh> BangGiaInNhanhS { get; set; }
        */
    }
}
