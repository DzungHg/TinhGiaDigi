using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInBDO
{
    public class EpKimBDO : MayThanhPhamBaseBDO
    {

        public int TocDoConGio { get; set; }
        public int PhiNguyenVatLieuChuanBi { get; set; }
        public int GiaKhuonCm2 { get; set; }
        public bool LaViTinh { get; set; }
    }
}
