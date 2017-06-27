using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.View
{
    public interface IViewThPhBoiBiaCung : IViewThanhPham
    {
        //Thêm 
        float TamRong { get; set; }
        float TamCao { get; set; }
         int IdToBoiChon { get; set; }         
         int SoToBoiTrenTamBia { get; set; }
         
    }
}
