using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class CanGap : ThanhPhamBase,IThanhPham
    {
        public int TocDoConGio { get; set; }
        public decimal ChiPhiCanGap(int soLuong)
        {
            decimal result = 0;
            float soGioChay = soLuong  / this.TocDoConGio;
            decimal phiChay = base.BHR * (decimal)soGioChay;
            decimal phiChuanBi = base.BHR * (decimal)base.ThoiGianChuanBi;            
            result = phiChay + phiChuanBi;
            return result;
        }
        public decimal ThanhTienCoBan(int soLuong)
        {  //Giá đại lý         
            decimal result = 0;
            float tyLeLN = (float)TinhToanThanhPham.MucLoiNhuan(this.DaySoLuong, this.DayLoiNhuan, soLuong) / 100;
            decimal chiPhiCanGap = ChiPhiCanGap(soLuong);
            result = chiPhiCanGap + chiPhiCanGap * (decimal)tyLeLN / (decimal)(1 - tyLeLN);
            return result;
        }
        //Static
        public static List<CanGap> DocTatCa()
        {
            var canPhuLogic = new CanGapLogic();
            var nguon = canPhuLogic.LayTatCa().Select(x => new CanGap
            {                
                ID = x.ID,
                Ten = x.Ten,
                BHR = x.BHR,
                TocDoConGio = x.TocDoConGio,
                ThoiGianChuanBi = x.ThoiGianChuanBi,
                DayLoiNhuan = x.DayLoiNhuan,
                DaySoLuong = x.DaySoLuong,                         
                ThuTu = x.ThuTu
            }).OrderBy(x => x.ThuTu).ToList();

            return nguon;
        }
        public static CanGap DocTheoId(int iD)
        {
            var canPhuLogic = new CanGapLogic(); ;
            CanGap canPhu = new CanGap();
            try
            {
                var canPhuBDO = canPhuLogic.LayTheoId(iD);
                //Chuyen
                ChuyenDoiGiayBDOThanhDTO(canPhuBDO, canPhu);
            }
            catch
            {
            }
            return canPhu;
        }
        private static void ChuyenDoiGiayBDOThanhDTO(CanGapBDO canGapBDO, CanGap canGapDTO)
        {
            canGapDTO.ID = canGapBDO.ID;
            canGapDTO.Ten = canGapBDO.Ten;
            canGapDTO.BHR = canGapBDO.BHR;
            canGapDTO.TocDoConGio = canGapBDO.TocDoConGio;
            canGapDTO.ThoiGianChuanBi = canGapBDO.ThoiGianChuanBi;
            canGapDTO.DayLoiNhuan = canGapBDO.DayLoiNhuan;
            canGapDTO.DaySoLuong = canGapBDO.DaySoLuong;                            
            canGapDTO.ThuTu = canGapBDO.ThuTu;
        }
    }
   
}
