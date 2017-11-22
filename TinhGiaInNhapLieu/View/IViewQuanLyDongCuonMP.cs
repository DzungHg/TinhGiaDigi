using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewQuanLyDongCuonMP: IViewMayThanhPham
    {
        
        int PhiKeoToDoi { get; set; }        
        int ThuTu { get; set; }
        string DaySoLuongNiemYet { get; set; }
      
        FormStateS TinhTrangForm { get; set; }
        bool DuLieuDaThayDoi { get; set; }
    }
}
