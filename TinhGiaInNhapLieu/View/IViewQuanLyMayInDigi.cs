using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewQuanLyMayInDigi
    {
        int ID { get; set; }
        string Ten { get; set; }
        string KhoInMin { get; set; }
        string KhoInMax { get; set; }
        string ThongTinTocDo { get; set; }
        int TocDoHieuQua { get; set; }
        int BHR { get; set; }
        int PhiPhePhamSanSang { get; set; }
        float ThoiGianSanSang { get; set; }
        int ClickA4_4M { get; set; }
        int ClickA4_1M { get; set; }
        int ClickA4_6M { get; set; }
        FormStateS TinhTrangForm { get; set; }
        bool DataChanged { get; set; }
    }
}
