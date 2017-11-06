using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model.Support;

namespace TinhGiaInClient.Model
{
    public class GiaInNhanhKetHopBangGia_May
    {
        public int SoLuongA4 { get; set; }
        private int TyLeMarkUpSales { get; set; }
        private BangGiaBase BangGiaInNhanh { get; set; }
        private int SoTrangToiDaTheoBang { get; set; }
        private int IdToInDiGi { get; set; }
        
        private DuLieuTinhGiaInNhanhTheoMay duLieuInDigi;
        public GiaInNhanhKetHopBangGia_May( int soTrangA4, BangGiaBase bgGiaInNhanh,
                        int soTrangToiDa, int idToInDigi, int tyLeMarkUpSales)
        {
            this.IdToInDiGi = idToInDigi;
            this.BangGiaInNhanh = bgGiaInNhanh;
            this.SoLuongA4 = soTrangA4;
            this.TyLeMarkUpSales = tyLeMarkUpSales;
            this.SoTrangToiDaTheoBang = soTrangToiDa;
            //Chú ý chỉ in 4 màu
            if (idToInDigi > 0)
            {
                duLieuInDigi = new DuLieuTinhGiaInNhanhTheoMay();
                var toInDiGi = ToInMayDigi.DocTheoId(idToInDigi);
                duLieuInDigi.TocDo = toInDiGi.TocDo * toInDiGi.QuiA4;
                duLieuInDigi.InTuTro = toInDiGi.InTuTro;
                duLieuInDigi.ClickTrangA4 = toInDiGi.ClickA4BonMau;
                duLieuInDigi.BHR = toInDiGi.BHR;
                duLieuInDigi.PhiPhePhamSanSang = toInDiGi.PhiPhePhamSanSang;
                duLieuInDigi.ThoiGianSanSang = toInDiGi.ThoiGianSanSang;                
                duLieuInDigi.DaySoLuong = toInDiGi.DaySoLuong;
                duLieuInDigi.DayLoiNhuan = toInDiGi.DayLoiNhuan;
            }
        }
        public decimal GiaBan()
        {
            if (this.BangGiaInNhanh == null || this.IdToInDiGi <= 0)
                return 0;
            //Tiếp
            decimal kq = 0;

            var gioiHanSoTrangTheoBangGia = this.SoTrangToiDaTheoBang;

            if (gioiHanSoTrangTheoBangGia > 0 &&  this.SoLuongA4 > gioiHanSoTrangTheoBangGia)
                kq = new GiaInNhanhTheoMay(duLieuInDigi, this.SoLuongA4, this.TyLeMarkUpSales).ThanhTienSales();
            else                
                kq = new GiaInNhanhNiemYet(this.SoLuongA4, this.BangGiaInNhanh).ThanhTienSales();

            return Math.Round(kq);
        }
        public decimal GiaTBTrenDonViTinh()
        {
            decimal kq = 0;
            if (this.SoLuongA4 >0)
                kq = this.GiaBan() / this.SoLuongA4;

            return kq;
        }
    }
}
