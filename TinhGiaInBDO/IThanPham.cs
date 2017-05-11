using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInBDO
{
    public interface IThanPham
    {
        int ID { get; set; }
        string Ten { get; set; }
        int BHR { get; set; }
        float ThoiGianChuanBi { get; set; }
        string DaySoLuong { get; set; }
        string DayLoiNhuan { get; set; }
        int ThuTu { get; set; }
    }
}
