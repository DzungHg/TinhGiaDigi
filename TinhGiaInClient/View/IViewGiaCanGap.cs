using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.View
{
    public interface IViewGiaCanGap : IViewThanhPham
    {
        //Bổ sung thêm
       
        int SoDuongCan { get; set; }
    }
}
