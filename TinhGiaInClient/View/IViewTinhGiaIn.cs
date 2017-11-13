using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.View
{
    public interface IViewTinhGiaIn
    {
        int ID { get; set; }
        DateTime NgayTinhGia { get; set; }
        int IdNguoiDung { get; set; }       
        string TenNhanVien { get; set; }
        string TenKhachHang { get; set; }
        string TieuDeTinhGia { get; set; }
        string TenHangKH { get; set; }
        bool QuyetDinhGopTrangIn { get;}
        string TomTatTinhGia { get; set; }
        FormStateS TinhTrangForm { get; set; }
       //Danh sách sp
        Boolean FormChanged { get; set; }

        int IdDanhThiepChon { get; set; }
        int IdBaiInChon { get; set; }
        int IdGiaSachDiGiChon { get; set; }
        int IdTheNhuaChon { get; set; }
   
       
    }
}
