using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewQuanLyEpKim: IViewMayThanhPham
    {
        //Thêm vô
        int PhiNguyenVatLieuChuanBi { get; set; }
        int GiaKhuonCM2 { get; set; }
        bool LaNhuViTinh { get; set; }
        int ThuTu { get; set; }
        string DaySoLuongNiemYet { get; set; }
      
        FormStateS TinhTrangForm { get; set; }
        bool DuLieuDaThayDoi { get; set; }
    }
}
