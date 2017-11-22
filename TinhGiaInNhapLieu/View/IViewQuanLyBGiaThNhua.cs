using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewQuanLyBGiaThNhua
    {
        int ID { get; set; }
        string Ten { get; set; }
        string MoTa { get; set; }
        string DaySoLuong { get; set; }
        string DayGiaThe { get; set; }
       
        string NoiDungBangGia { get; set; }
        int IdHangKhachHang { get; set; }
        int ThuTu { get; set; }
        string DaySoLuongNiemYet { get; set; }
        int SoTheToiDa { get; set; }        
        bool KhongCon { get; set; }
        bool InHaiMat { get; set; }
        string VatLieuInBaoGom { get; set; }
        string KhoToChay { get; set; }
        
        FormStateS TinhTrangForm { get; set; }
        bool DataChanged { get; set; }
        //
      
        
       
        
    }
}
