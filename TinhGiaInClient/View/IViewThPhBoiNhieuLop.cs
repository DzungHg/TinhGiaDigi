using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.View
{
    public interface IViewThPhBoiNhieuLop : IViewThanhPham
    {
        //Thêm 
        float ToBoiRong { get; set; }
        float ToBoiCao { get; set; }
         int IdGiayBoiGiuaChon { get; set; }         
         int SoToLotGiua { get; set; }
         
    }
}
