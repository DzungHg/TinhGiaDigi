using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.View
{
    public interface IViewThPhEpKim: IViewThanhPham
    {
        //Thêm 
         int IdNhuEpKimChon { get; set; }
         bool LaEpViTinh { get; }
         float KhoEpRong { get; set; }
         float KhoEpCao { get; set; }
         int SoLuongToChay { get; set; }
         float KhoToChayRong { get; set; }
         float KhoToChayDai { get; set; }
         int SoLuongTinhGia { get; set; }
       
          
    }
}
