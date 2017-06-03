using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TinhGiaInClient.Model
{
    public class MucDongCuonLoXo: MucThanhPham
    {
      
      
        public KieuDongCuonS KieuDongCuon { get; set; }
        public int GayCao { get; set; }
        public float GayDay { get; set; }
      
      
    }
}
