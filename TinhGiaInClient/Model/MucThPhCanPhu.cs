using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TinhGiaInClient.Model
{
    public class MucThPhCanPhu: MucThanhPham
    {
        public int SoMatCan { get; set; }
        public float ToChayRong { get; set; }
        public float ToChayDai { get; set; }
      
    }
}
