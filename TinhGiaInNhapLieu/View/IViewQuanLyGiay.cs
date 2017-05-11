using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewQuanLyGiay
    {
        string NhaCungCapChon { get; }
        int IdDanhMucGiayChon { get;}
        int IdGiayChon { get;  }
       
    }
}
