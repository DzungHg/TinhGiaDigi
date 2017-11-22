using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewQuanLyKhoSanPham
    {
        int ID { get; set; }
        string Ten { get; set; }
        float KhoCatRong { get; set; }
        float KhoCatCao { get; set; }
        string DienGiai { get; set; }        
        int ThuTu { get; set; }
        FormStateS TinhTrangForm { get; set; }
        bool DataChanged { get; set; }
    }
}
