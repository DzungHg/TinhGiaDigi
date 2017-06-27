using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInBDO
{
    public class DongCuonMoPhangBDO : MayThanhPhamBaseBDO
    {
        public int TocDoToDoiGio { get; set; }
        public int PhiKeoToDoi { get; set; }

        public bool BiaToDon { get; set; }
        public bool RuotToDon { get; set; }
    }
}
