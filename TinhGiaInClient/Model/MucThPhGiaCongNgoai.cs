using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TinhGiaInClient.Model
{
    public class MucThPhGiaCongNgoai: MucThanhPham
    {
      
      
        public int PhiGiaCong { get; set; }
        public int PhiVanChuyen { get; set; }
        public string TenNhaCungCap { get; set; }
      
      
    }
}
