using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInClient.Model.Support;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.View
{
    public interface IViewGiayDeBoi
    {
        int ID { get; set; }
        int IdBaiIn { get; set; }
        int IdHangKH { get; set; }
        string DienGiaiBaiInVaSoLuong { get; set; }
        string ThongTinBaiIn_CauHinh { get; set; }
        int IdGiay { get; set; }        
        string TenGiayBoi { get; set; }
        float GiayLonRong { get; set; }
        float GiayLonCao { get; set; }
      
        float ToBoiRong { get; set; }
        float ToBoiCao { get; set; }


        int SoLuongToBoiLyThuyet { get; set; }
        int SoLuongToBoiBuHao { get; set; }
        int SoLuongToBoiTong { get; }
        int SoToChayTrenToLon { get; set; }
        decimal GiaGiayBan { get; }
        int SoToGiayLon { get; }
        decimal ThanhTien { get; }
        FormStateS TinhTrangForm { get; set; }
    }
}
