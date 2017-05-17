using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;

namespace TinhGiaInClient.View
{
    public interface IViewBangGiaGiay
    {

        int IdHangKHChon { get; set; }
        FormStates TinhTrangForm { get; set; }
        int IdDanhMucGiayChon { get; }
        string MaNhaCungCapChon { get; set; }
    }
}
