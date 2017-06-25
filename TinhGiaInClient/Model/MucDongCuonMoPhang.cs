using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TinhGiaInClient.Model
{
    public class MucDongCuonMoPhang: MucThanhPham
    {
      
      
        public KieuDongCuonS KieuDongCuon { get; set; }
        public int SoToDoi { get; set; }        
        public int IdToLotChon { get; set; }
      
      
    }
}
