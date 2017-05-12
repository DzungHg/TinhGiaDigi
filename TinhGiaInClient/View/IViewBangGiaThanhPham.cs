using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.View
{
    public interface IViewBangGiaThanhPham
    {
        int IdHangKHChon { get; set; }
        int IdMonThanhPham { get; set; }
        string DaySoluong { get; set; }
        string DonViTinh { get; set; }
    }
}
