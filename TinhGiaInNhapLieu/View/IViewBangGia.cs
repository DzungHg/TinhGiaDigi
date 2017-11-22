using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewBangGia
    {
        int ID { get; set; }
        string Ten { get; set; }
        string DienGiai { get; set; }
        string DaySoLuong { get; set; }
        string DayGiaTrang { get; set; }
        string DonViTinh { get; set; }      
        string LoaiBangGia { get; set; }
        int ThuTu { get; set; }
       
        bool KhongSuDung { get; set; }
       
        FormStateS TinhTrangForm { get; set; }       
    }
}
