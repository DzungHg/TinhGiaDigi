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
       //Danh sách sp
        int IdCauHinhSPChon { get; set; }
        int IdGiayInChon { get; set; }
        int IdBaiInChon { get; set; }
        int IdGiaInChon { get; set; }
        List<BaiIn> BaiInS { get; set; }
        List<CauHinhSanPham> CauHinhSanPhamS { get; set; }
        List<GiayDeIn> GiayDeInS { get; set; }
        List<GiaIn> GiaInS { get; set; }
        List<MucThanhPham> ThanhPhamS { get; set; }
       
    }
}
