using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewDanhMucGiay
    {
        int IdDanhMucgiay { get; set; }
        string TenDanhMuc { get; set; }
        string TenNhaCungCapChon { get; set; }
        int ThuTu { get; set; }
        int TinhTrangForm { get; set; }
        string ThongTin { get; set; }
    }
}
