using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.View
{
    public interface IViewBangGiaInNhanh
    {
        int IdHangKHChon { get; set; }
        int IdNiemYetGiaChon { get; set; }
        string DaySoluong { get; set; }
        string DonViTinh { get; set; }
        string NoiDungBangGia { get; set; }
        int SoTrangToiDaTheoNiemYet { get; set; }
    }
}
