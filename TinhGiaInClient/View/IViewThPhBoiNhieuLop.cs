using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.View
{
    public interface IViewThPhBoiNhieuLop : IViewThanhPham
    {
        //Thêm 
        float ToBoiRong { get; set; }
        float ToBoiCao { get; set; }
         int IdGiayBoiGiuaChon { get; set; }         
         int SoLopLotGiua { get; set; }
         GiayDeBoi GiayDeBoiChon { get; set; }
         KieuBoiNhieuLop KieuBoi { get; set; }
        
         
    }
}
