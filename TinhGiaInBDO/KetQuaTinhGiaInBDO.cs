using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInBDO
{
    public class KetQuaTinhGiaInBDO
    {
        public int ID { get; set; }
        public int IdNguoiDung { get; set; }
        public string TenNguoiDung { get; set; }
        public DateTime NgayTinhGia { get; set; }
        public string TieuDe { get; set; }
        public int IdYeuCauTinhGiaIn { get; set; }
        public string NoiDungChaoGia { get; set; }
        public string NoiDungChaoGiaNoiBo { get; set; }
        public string TenKhachHang { get; set; }
        
    }
}
