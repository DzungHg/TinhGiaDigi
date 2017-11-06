using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class GiaInNhanhTheoBang: IGiaIn
    {
        public int SoLuongA4 { get; set; }
        public int IdBangGiaInNhanh { get; set; }
        public GiaInNhanhTheoBang(int soLuongA4, int idBangGiaInNhanh)
        {
            this.SoLuongA4 = soLuongA4;
            this.IdBangGiaInNhanh = idBangGiaInNhanh;
        }
        public decimal ChiPhi(int soLuong)
        {
            return 0;
        }

        public decimal ThanhTienCoBan(int soLuong)
        {
            decimal ketQua = 0;
            if (this.IdBangGiaInNhanh <= 0)
                return 0;
            var bangGiaInNhanh = BangGiaInNhanh.DocTheoId(this.IdBangGiaInNhanh);
            if (!bangGiaInNhanh.GiaTheoKhoang) //tính theo  lũy tiến
                ketQua = TinhToan.GiaInLuyTien(bangGiaInNhanh.DaySoLuong,
                    bangGiaInNhanh.DayGia, soLuong);
            else //tính theo khoảng
            {
                var giaTrangTrongKhoang = TinhToan.GiaTriTheoKhoang(bangGiaInNhanh.DaySoLuong,
                    bangGiaInNhanh.DayGia, this.SoLuongA4);
                ketQua = giaTrangTrongKhoang * this.SoLuongA4;
            }
            return ketQua;
        }

        public decimal ThanhTienSales()
        {
            return this.ThanhTienCoBan(this.SoLuongA4);
        }

        public decimal GiaTBTrenDonVi()
        {
            throw new NotImplementedException();
        }
    }
}
