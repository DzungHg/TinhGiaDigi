using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TinhGiaInClient.Model
{
    public class MucThPhBe: MucThanhPham
    {
       
        public int IdKhuonBeChon { get; set; }
        public float KhoBeRong { get; set; }
        public float KhoBeCao { get; set; }
        
        public int SoLuongToChay { get; set; }
        public float KhoToChayRong { get; set; }
        public float KhoToChayDai { get; set; }       
      
    }
}
