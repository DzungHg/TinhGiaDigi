using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewNiemYetGiaInNhanh
    {
        int ID { get; set; }
        string TenNiemYet { get; set; }
       
        string DienGiai { get; set; }
        string LoaiBangGia { get; set; }
        int IdBangGia { get; set; }
        string TenBangGia { get; set; }
        int IdHangKhachHang { get; set; }
        int ThuTu { get; set; }
        string DaySoLuongNiemYet { get; set; }
      
        int SoTrangToiDa { get; set; }        
        bool KhongSuDung { get; set; }
        bool DuocGomTrang { get; set; }
        
        FormStateS TinhTrangForm { get; set; }
        bool DataChanged { get; set; }
        //bổ sung
       
    }
}
