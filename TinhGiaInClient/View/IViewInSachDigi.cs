using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.View
{
    public interface IViewInSachDigi
    {
        int ID { get; set; }
        string TieuDe { get; set; }
        int SoTrangRuot { get; set; }
        int SoTrangBia { get; set; }
        float SachRong { get; set; }
        float SachCao { get; set; }
        float GayDay { get; set; }
        int SoCuon { get; set; }
        bool BiaLayNgoai { get; set; }
        BaiIn Bia { get; set; }
        BaiIn Ruot { get; set; }
        MucGiaIn GiaInChiTiet { get; set; }
        MucThanhPham DongCuon { get; set; }
        int IdMonDongCuonChon { get; set; }
        int IdHangKhachHang { get; set; }
        KieuDongCuonS KieuDongCuon { get; set; }
        FormStateS TinhTrangForm { get; set; }
    }
}
