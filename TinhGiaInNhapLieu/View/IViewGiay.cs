using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewGiay
    {
       
        int IdGiay { get; set; }
        string MaGiayNhaCungCap { get; set; }
         string MaTuDat { get; set; }
        string TenGiay { get; set; }
         string DienGiai { get; set; }
        int DinhLuong { get; set; }
        string KhoGiay { get; set; }
        float ChieuNgan { get; set; }
        float ChieuDai { get; set; }
        int GiaMua { get; set; }
        int IdDanhMucGiay { get; set; }
        string TenDanhMucGiayChon { get; set; }
        string TenNhaCungCap { get; set; }
        string TenGiayMoRong { get; set; }
        int ThuTu {get;set;}
        bool TonKho { get; set; }
        bool KhongCon { get; set; }
        int TinhTrangForm { get; set; }
        //--
        
    }
}
