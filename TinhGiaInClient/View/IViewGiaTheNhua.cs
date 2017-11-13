using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.View
{
    public interface IViewGiaTheNhua
    {
        int ID { get; set; }        
        int IdHangKH { get; set; }
        string TieuDe { get; set; }
        string TenHangKH { get; set; }
        int SoMatIn { get; set; }
        int IdBangGiaChon { get; set; }
        List<int> IdGiaTuyChonChonS { get; set; }  
        string TenVatLieuBaoGom { get; set; }
        int SoTheToiDaTinh { get; set; }
        string NoiDungBangGia { get; set; }
        string KichThuoc { get; set; }
        int SoLuong { get; set; }
      
        FormStateS TinhTrangForm { get; set; }
        bool DataChanged { get; set; }
        /*
        List<ToChayDigi> ToChayDigiS { get; set; }
        List<BangGiaInNhanh> BangGiaInNhanhS { get; set; }
        */
    }
}
