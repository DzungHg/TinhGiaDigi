using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.Model
{
    public class MucDongCuonLoXo: MucThanhPham
    {
      
      
        public KieuDongCuonS KieuDongCuon { get; set; }
        public float GayCao { get; set; }
        public float GayDay { get; set; }
        public int IdLoXoChon { get; set; }
      
      
    }
}
