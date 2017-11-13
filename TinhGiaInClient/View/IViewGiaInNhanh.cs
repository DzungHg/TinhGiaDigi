using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.View
{
    public interface IViewGiaInNhanh
    {
        int ID { get; set; }
        int IdBaiIn { get; set; }
        int IdHangKH { get; set; }
        string TenHangKH { get; set; }
        int TyLeLoiNhuanTheoHangKH { get; set; }
        int  SoMatIn { get; set; }
        int IdMayInOrToIn { get; set; }       
        int IdNiemYetChon { get; set; }
        int SoToChay { get; set; }
        int SoTrangA4 { get; }
        int SoTrangToiDaTheoBangGia { get; set; }
        bool ChoTinhGopTrang { get; set; }
        decimal TienIn { get; set; }
        string GiaTBTrangInfo { get; set; }
        string ThongTinGiay { get; set; }
        PhuongPhapInS PhuongPhapIn { get; }
        FormStateS TinhTrangForm { get; set; }
        //Thêm mới
        
        string TenLoaiBangGia { get; set; }
        string LoaiBangGiaNiemYet { get; set; }
       
        string DienGiaiNiemYet { get; set; }
        /*
        List<ToChayDigi> ToChayDigiS { get; set; }
        List<BangGiaInNhanh> BangGiaInNhanhS { get; set; }
        */
    }
}
