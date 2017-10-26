using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.View
{
    public interface IViewThPhBe: IViewThanhPham
    {
        //Thêm 
         int IdKhuonBeChon { get; set; }
        
         
         int SoLuongToChay { get; set; }
         float KhoToChayRong { get; set; }
         float KhoToChayDai { get; set; }
         float KhoBeRong { get; set; }
         float KhoBeCao { get; set; }
         
        
       
          
    }
}
