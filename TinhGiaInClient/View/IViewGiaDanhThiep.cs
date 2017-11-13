using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.View
{
    public interface IViewGiaDanhThiep
    {
        int ID { get; set; }        
        int IdHangKH { get; set; }
        string TieuDe { get; set; }
        int SoMatIn { get; set; }
        int IdBangGiaChon { get; set; }        
        GiayDeIn GiayDeInChon { get; set; }
        string TenGiayChon { get; set; }
        string TenBangGiaChon { get; set; }
        string KichThuoc { get; set; }
        int SoLuong { get; set; }
        decimal TienIn { get; set; }
        decimal TienGiay { get; set; }
       
        List<int> IdGiaTuyChonChonS { get; set; }  
        FormStateS TinhTrangForm { get; set; }
        bool DataChanged { get; set; }
        /*
        List<ToChayDigi> ToChayDigiS { get; set; }
        List<BangGiaInNhanh> BangGiaInNhanhS { get; set; }
        */
    }
}
