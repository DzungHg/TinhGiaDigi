using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewQuanLyToLotDCMP
    {
        int ID { get; set; }
        string Ten { get; set; }
        string MaNhaCungCap { get; set; }
        string TenNhaCungCap { get; set; }
        int GiaMuaTo { get; set; }

        int ThuTu { get; set; }
        FormStateS TinhTrangForm { get; set; }
        bool DataChanged { get; set; }
    }
}
