using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Common.Enum;


namespace TinhGiaInClient.View
{
    public interface IViewThPhDongCuonMoPhang: IViewThanhPham
    {
        //Thêm 
         int IdToLotChon { get; set; }
         KieuDongCuonS KieuDongCuon { get; set; }
         int SoToDoi { get; set; }
         
    }
}
