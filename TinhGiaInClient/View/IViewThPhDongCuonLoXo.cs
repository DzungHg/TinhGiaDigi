using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.View
{
    public interface IViewThPhDongCuonLoXo: IViewThanhPham
    {
        //Thêm 
         int IdLoXoDongCuonChon { get; set; }
         KieuDongCuonS KieuDongCuon { get; set; }
         float GayRong { get; set; }
         float GayDay { get; set; }
    }
}
