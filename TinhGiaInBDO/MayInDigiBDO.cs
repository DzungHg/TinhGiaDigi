using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInBDO
{
    public class MayInDigiBDO
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string KhoInMin { get; set; }
        public string KhoInMax { get; set; }
        public string ThongTinTocDo { get; set; }
        public int TocDoHieuQua { get; set; }
        public int BHR { get; set; }
        public int PhiPhePhamSanSang { get; set; }
        public float ThoiGianSanSang { get; set; }       
        public int ClickA4_4M { get; set; }
        public int ClickA4_1M { get; set; }
        public int ClickA4_6M { get; set; }
    }
}
