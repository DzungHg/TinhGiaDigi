using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Common;

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
            if (this.BangGiaInNhanh == null || soLuong == 0)
                return 0;
            //Qua, tính tiếp
            switch (this.BangGiaInNhanh.LoaiBangGia.Trim())
            {
                case Global.cBangGiaLuyTien:

                    ketQua = TinhToan.GiaInLuyTien(this.BangGiaInNhanh.DaySoLuong, this.BangGiaInNhanh.DayGia, soLuong);
                    break;
                case Global.cBangGiaBuoc:

                    ketQua = TinhToan.GiaBuoc(this.BangGiaInNhanh.DaySoLuong, this.BangGiaInNhanh.DayGia, soLuong);
                    break;
                case Global.cBangGiaGoi:
                    ketQua = TinhToan.GiaGoi(this.BangGiaInNhanh.DaySoLuong, this.BangGiaInNhanh.DayGia, soLuong);
                    break;
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
