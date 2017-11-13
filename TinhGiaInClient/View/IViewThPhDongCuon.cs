using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.View
{
    public interface IViewThPhDongCuon: IViewThanhPham
    {
        //Thêm 
         string TieuDe { get; set; }
         KieuDongCuonS KieuDongCuon { get; set; }
         float GayCao { get; set; }
         float GayDay { get; set; }
         bool MoTextSoLuong { get; set; }
    }
}
