using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;

namespace TinhGiaInClient.View
{
    public interface IViewTinhGiaIn
    {
        int ID { get; set; }
        DateTime NgayTinhGia { get; set; }
        int IdNguoiDung { get; set; }
       
        string TenNhanVien { get; set; }
        string TieuDeTinhGia { get; set; }
        string TenHangKH { get; set; }
        FormStates TinhTrangForm { get; set; }
       //Danh sách sp
        Boolean FormChanged { get; set; }

        int IdDanhThiepChon { get; set; }
        int IdBaiInChon { get; set; }
   
       
    }
}
