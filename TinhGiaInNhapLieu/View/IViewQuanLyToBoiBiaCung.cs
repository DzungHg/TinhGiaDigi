using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewQuanLyToBoiBiaCung
    {
        int ID { get; set; }
        string Ten { get; set; }
        float DoDayCm { get; set; }       
        int GiaMuaTheoTam { get; set; }
       
        int ThuTu { get; set; }
        FormStateS TinhTrangForm { get; set; }
        bool DataChanged { get; set; }
    }
}
