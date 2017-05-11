using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.View
{
    public interface IViewBaiIn
    {
        
        int ID
        {
            get;
            set;
        }
        string TieuDe
        {
            get;
            set;
        }
        string DienGiai
        {
            get;
            set;
        }
        int SoLuong
        {
            get;
            set;
        }
        string DonViTinh
        {
            get;
            set;
        }

        string TenHangKhachHang
        {
            get;
            set;
        }
        int IdHangKhachHang { get; set; }
        
        string TomTatCauHinhSP { get; set; }
        List<string> TomTatBaiIn_ChaoKH { get; set; }
        FormStates TinhTrangForm { get; set; }
    }
}
