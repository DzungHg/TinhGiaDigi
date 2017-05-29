using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TinhGiaInClient.View
{
    public interface IViewThPhGiaCongNgoai: IViewThanhPham
    {
              
         int PhiGiaCong { get; set; }
         int PhiVanChuyen { get; set; }
         int TyLeMarkUp { get; set; }
         string TenNhaCungCap { get; set; }       
        
    }
}
