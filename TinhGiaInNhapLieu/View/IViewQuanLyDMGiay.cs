using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewQuanLyDMGiay
    {
        string NhaCungCapChon { get; set; }
        int IdDanhMucGiayChon { get; set; }
        string ThongTin { get; set; }
       
    }
}
