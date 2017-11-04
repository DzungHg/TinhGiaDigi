using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewNiemYetGiaInNhanh
    {
        int ID { get; set; }
        string Ten { get; set; }
        string DienGiai { get; set; }
        string LoaiBangGia { get; set; }
        
        int IdHangKhachHang { get; set; }
        int ThuTu { get; set; }
        string DaySoLuongNiemYet { get; set; }
      
        int SoTrangToiDaTinh { get; set; }        
        bool KhongSuDung { get; set; }
        
        FormStateS TinhTrangForm { get; set; }
        bool DataChanged { get; set; }
    }
}
