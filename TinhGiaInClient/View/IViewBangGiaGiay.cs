using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.View
{
    public interface IViewBangGiaGiay
    {

        int IdHangKHChon { get; set; }
        FormStateS TinhTrangForm { get; set; }
        int IdDanhMucGiayChon { get; }
        string MaNhaCungCapChon { get; set; }
        int IdGiayChon { get; set; }
        Giay GiayChon { get; set; }
    }
}
