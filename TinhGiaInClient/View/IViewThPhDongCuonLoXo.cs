using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.View
{
    public interface IViewThPhDongCuonLoXo: IViewThanhPham
    {
        //Thêm 
         int IdLoXoDongCuonChon { get; set; }
         KieuDongCuonS KieuDongCuon { get; set; }
         float GayCao { get; set; }
         float GayDay { get; set; }
    }
}
