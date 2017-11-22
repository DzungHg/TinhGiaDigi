using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewQuanLyBangGia
    {
        int IdBangGiaChon { get;set; }
        LoaiBangGiaS LoaiBangGia { get; set; }
        int SoTrangTinhThu { get; set; }
    }
}
