using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class ThanhPhamBase
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public int BHR { get; set; }
        public float ThoiGianChuanBi { get; set; }
        public string DaySoLuong { get; set; }
        public string DayLoiNhuan { get; set; }
        public string Ma_01 { get; set; }
        public string DonViTinh { get; set; }
        public string DaySoLuongNiemYet { get; set; }
        public int ThuTu { get; set; }
    }
}
