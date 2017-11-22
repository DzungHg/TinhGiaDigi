using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewQuanLyLoXoDongCuon
    {
        int ID { get; set; }
        string Ten_VongXoan { get; set; }
        string KichCoBuoc { get; set; }
        string MauSac { get; set; }
        string ChoDoDay { get; set; }
        int GiaMuaTheoMet { get; set; }
       
        int ThuTu { get; set; }
        FormStateS TinhTrangForm { get; set; }
        bool DataChanged { get; set; }
    }
}
