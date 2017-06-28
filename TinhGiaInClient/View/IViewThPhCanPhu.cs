using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.View
{
    public interface IViewThPhCanPhu: IViewThanhPham
    {
        //Bổ sung thêm        
        int SoMatCan { get; set; }
        float ToChayRong { get; set; }
        float ToChayDai { get; set; }
    }
}
