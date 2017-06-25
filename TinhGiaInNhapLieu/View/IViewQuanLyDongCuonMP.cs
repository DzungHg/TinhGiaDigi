using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewQuanLyDongCuonMP
    {

        int ID { get; set; }
        string Ten { get; set; }
        int BHR { get; set; }              
        string DaySoLuongCoBan { get; set; }
        string DayLoiNhuanCoBan { get; set; }
        string DonViTinh { get; set; }
        int PhiKeoToDoi { get; set; }
        int TocDoToDoiGio { get; set; }
        float ThoiGianChuanBi { get; set; }
        int ThuTu { get; set; }
        string DaySoLuongNiemYet { get; set; }
      
        FormStateS TinhTrangForm { get; set; }
        bool DuLieuDaThayDoi { get; set; }
    }
}
