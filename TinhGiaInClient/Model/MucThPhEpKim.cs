using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TinhGiaInClient.Model
{
    public class MucThPhEpKim: MucThanhPham
    {
        public bool LaEpViTinh { get; set; }
        public int IdNhuEpKimChon { get; set; }
        public float KhoEpRong { get; set; }
        public float KhoEpCao { get; set; }  
      
      
    }
}
