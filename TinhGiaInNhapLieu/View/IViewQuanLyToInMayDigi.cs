using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewQuanLyToInMayDigi
    {
        int ID { get; set; }
        string Ten { get; set; }
        float Rong { get; set; }
        float Cao { get; set; }
        float VungInRong { get; set; }
        float VungInCao { get; set; }
        int TocDo { get; set; }
       
        string KhoToChayCoTheIn { get; set; } 
        int IdMayInDigi { get; set; }        
        string DaySoLuongCoBan { get; set; }
        string DayLoiNhuanCoBan { get; set; }
        string DaySoLuongNiemYet { get; set; }
        bool InTuTro { get; set; }
        bool HPIndigo { get; set; }
        int QuiSoTrangA4 { get; set; }        
        int ThuTu { get; set; }
        bool KhongSuDung { get; set; }
        FormStateS TinhTrangForm { get; set; }
        bool DataChanged { get; set; }
    }
}
