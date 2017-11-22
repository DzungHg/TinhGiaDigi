using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewQuanLyBangGiaInNhanh
    {
        int ID { get; set; }
        string Ten { get; set; }
        string MoTa { get; set; }
        string DaySoLuong { get; set; }
        string DayGiaTrang { get; set; }
        string NoiDungBangGia { get; set; }
       
        int IdHangKhachHang { get; set; }
        int ThuTu { get; set; }
        string DaySoLuongNiemYet { get; set; }
      
        int SoTrangToiDaTinh { get; set; }        
        bool KhongSuDung { get; set; }
        bool GiaTheoKhoang { get; set; }
        FormStateS TinhTrangForm { get; set; }
        bool DataChanged { get; set; }
    }
}
