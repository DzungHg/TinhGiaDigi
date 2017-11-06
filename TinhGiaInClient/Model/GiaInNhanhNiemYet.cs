using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class GiaInNhanhNiemYet: IGiaIn
    {
        public int SoLuongA4 { get; set; }
        public BangGiaBase BangGiaInNhanh { get; set; }
        public GiaInNhanhNiemYet(int soLuongA4, BangGiaBase bangGiaInNhanh)
        {
            this.SoLuongA4 = soLuongA4;
            this.BangGiaInNhanh = bangGiaInNhanh;
        }
        public decimal ChiPhi(int soLuong)
        {
            return 0;
        }

        public decimal ThanhTienCoBan(int soLuong)
        {
            decimal ketQua = 0;
            if (this.BangGiaInNhanh == null)
                return 0;
            //Qua, tính tiếp
            if (this.BangGiaInNhanh.LoaiBangGia.Trim() == EnumsS.cBangGiaLuyTien)
                {
                    ketQua = TinhToan.GiaInLuyTien(this.BangGiaInNhanh.DaySoLuong, this.BangGiaInNhanh.DayGia, soLuong);
                }
            if (this.BangGiaInNhanh.LoaiBangGia.Trim() == EnumsS.cBangGiaBuoc)
                ketQua = TinhToan.GiaBuoc(this.BangGiaInNhanh.DaySoLuong, this.BangGiaInNhanh.DayGia, soLuong);
                        
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
