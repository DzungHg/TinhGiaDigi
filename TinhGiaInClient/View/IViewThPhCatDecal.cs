using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.View
{
    public interface IViewThPhCatDecal : IViewThanhPham
    {
        //Thêm 

        float ConRong { get; set; }
         float ConCao { get; set; }
         
    }
}
