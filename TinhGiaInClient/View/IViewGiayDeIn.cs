using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;

namespace TinhGiaInClient.View
{
    public interface IViewGiayDeIn
    {
        int ID { get; set; }
        int IdBaiIn { get; set; }
        int IdHangKH { get; set; }
        string DienGiaiBaiInVaSoLuong { get; set; }
        string ThongTinBaiIn_CauHinh { get; set; }
        Giay GiayChon { get; set; }
        int IdDanhMucGiayChon { get; set; }
        string TenNhaCC { get; set; }
        string TenGiayIn { get; set; }
        bool GiayKhachDua { get; set; }
        string KhoToChay { get; set; }
        int SoLuongSanPham { get; set; }
        int SoConTrenToChay { get; set; }
        int SoLuongToChayLyThuyet { get; set; }
        int SoLuongToChayBuHao { get; set; }
        int SoLuongToChayTong { get; set; }
        int SoToChayTrenToLon { get; set; }
        decimal GiaBan { get; }
        int SoToGiayLon { get; set; }
        decimal ThanhTien { get; }
        FormStates TinhTrangForm { get; set; }
    }
}
