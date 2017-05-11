using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInBDO
{
    public class YeuCauTinhGiaInBDO
    {
        public int ID { get; set; }
        public int IdNguoiDung { get; set; }
        public DateTime NgayYeuCau { get; set; }
        public string HoTen { get; set; }
        public string CongTy { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string ThamChieuTicket { get; set; }
        public string NoiDung { get; set; }
        public string PhanChoNhanVien { get; set; }
        public int TinhTrang { get; set; }
        
    }
}
