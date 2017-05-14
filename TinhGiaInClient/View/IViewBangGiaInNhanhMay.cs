using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.View
{
    public interface IViewBangGiaInNhanhMay
    {
        int IdHangKHChon { get; set; }
        int IdToInDigiChon { get; set; }
        string DaySoluong { get; set; }
        string DonViTinh { get; set; }       
    }
}
