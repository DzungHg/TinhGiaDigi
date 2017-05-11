using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;

namespace TinhGiaInClient.View
{
    public interface IViewTinhGiaIn
    {
        int ID { get; set; }
        int IdBaiIn { get; set; }
        bool LoaiBangGia { get; set; }
        int KieuIn { get; set; }
        int IdBangGiaChon { get; set; }
        int SoTrangA4 { get; set; }
        int TienIn { get; set; }

        List<ToChayDigi> ToChayDigiS { get; set; }
        List<BangGiaInNhanh> BangGiaInNhanhS { get; set; }
      
    }
}
