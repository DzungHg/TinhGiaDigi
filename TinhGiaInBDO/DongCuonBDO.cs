using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInBDO
{
    public class DongCuonBDO : MayThanhPhamBaseBDO
    {
        public string TieuDe { get; set; }
        public int TocDoCuonGio { get; set; }
        public int PhiNgVLCuon { get; set; }
        public bool BiaToDon { get; set; }
        public bool RuotToDon { get; set; }
        
    }
}
