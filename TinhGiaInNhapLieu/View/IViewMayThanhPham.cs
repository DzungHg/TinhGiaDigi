using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewMayThanhPham
    {
        int ID { get; set; }
        string Ten { get; set; }
        int BHR { get; set; }
        string DaySoLuongCoBan { get; set; }
        string DayLoiNhuanCoBan { get; set; }
        string DonViTinh { get; set; }
        int TocDo { get; set; }
        float ThoiGianChuanBi { get; set; }
    }
}
