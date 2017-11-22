using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewQuanLyDongCuonLX: IViewMayThanhPham
    {
        
       
        int ThuTu { get; set; }
        string DaySoLuongNiemYet { get; set; }
        bool BiaToDon { get; set; }
        bool RuotToDon { get; set; }
        FormStateS TinhTrangForm { get; set; }
        bool DuLieuDaThayDoi { get; set; }
    }
}
