using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInBDO
{
    public class CanGapBDO: MayThanhPhamBaseBDO
    {

        public int TocDoConGio { get; set; }
        public float MotDuongCanTangThoiGianChuanBi { get; set; } //phần so với đường kế cận
    }
}
