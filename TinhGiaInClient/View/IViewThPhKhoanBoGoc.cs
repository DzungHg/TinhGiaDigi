using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;

namespace TinhGiaInClient.View
{
    public interface IViewThPhKhoanBoGoc : IViewThanhPham
    {
        //Thêm 
        string KichThuocBlock { get; set; }
        //int SoLuongBlock { get; set; } // Chính là số lượng sp
         string TieuDe { get; set; }         
         int SoLanKhoanBoTrenMoiBlock { get; set; }
        //
         /* int SoLuongSanPham { get; set; }
         float KhoSanPhamRong { get; set; }
         float KhoSanPhamCao { get; set; } */
         
        
         
    }
}
