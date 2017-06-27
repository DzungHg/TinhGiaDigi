using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TinhGiaInClient.Model
{
    public class MucThPhBoiBiaCung : MucThanhPham
    {

        public float TamRong { get; set; }
        public float TamCao { get; set; }
        public int SoToBoiTrenTamBia { get; set; }        
        public int IdToBoiChon { get; set; }
      
      
    }
}
