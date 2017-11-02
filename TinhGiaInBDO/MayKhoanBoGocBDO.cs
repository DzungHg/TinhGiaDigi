using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInBDO
{
    public class MayKhoanBoGocBDO : MayThanhPhamBaseBDO
    {
        public int TocDoBlockGio { get; set; }
        public int PhiDungCuMoiBlock { get; set; }
        public string DienGiai { get; set; }
        public string TieuDe { get; set; }
      
    }
}
