using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class CanGap : ThanhPhamBase
    {
        public int TocDoConGio { get; set; }
        public float MotDuongCanTangThoiGianChuanBi { get; set; }
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
                Ma_01 = x.Ma_01,     
                DonViTinh = x.DonViTinh,
                DaySoLuongNiemYet = x.DaySoLuongNiemYet,
                MotDuongCanTangThoiGianChuanBi = x.MotDuongCanTangThoiGianChuanBi,
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
        public static string Sua(CanGap canGap)
        {
            CanGapLogic canGapLogic = new CanGapLogic();
            var itemBDO = new CanGapBDO();
            ChuyenDoiGiayDTOThanhBDO(canGap, itemBDO);
            return canGapLogic.Sua(itemBDO);
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
            canGapDTO.Ma_01 = canGapBDO.Ma_01;
            canGapDTO.DonViTinh = canGapBDO.DonViTinh;
            canGapDTO.DaySoLuongNiemYet = canGapBDO.DaySoLuongNiemYet;
            canGapDTO.MotDuongCanTangThoiGianChuanBi = canGapBDO.MotDuongCanTangThoiGianChuanBi;
            canGapDTO.ThuTu = canGapBDO.ThuTu;
        }
        private static void ChuyenDoiGiayDTOThanhBDO(CanGap canGapDTO, CanGapBDO canGapBDO)
        {
            canGapBDO.ID = canGapDTO.ID;
            canGapBDO.Ten = canGapDTO.Ten;
            canGapBDO.BHR = canGapDTO.BHR;
            canGapBDO.TocDoConGio = canGapDTO.TocDoConGio;
            canGapBDO.ThoiGianChuanBi = canGapDTO.ThoiGianChuanBi;
            canGapBDO.DayLoiNhuan = canGapDTO.DayLoiNhuan;
            canGapBDO.DaySoLuong = canGapDTO.DaySoLuong;
            canGapBDO.Ma_01 = canGapDTO.Ma_01;
            canGapBDO.DonViTinh = canGapDTO.DonViTinh;
            canGapBDO.DaySoLuongNiemYet = canGapDTO.DaySoLuongNiemYet;
            canGapBDO.MotDuongCanTangThoiGianChuanBi = canGapDTO.MotDuongCanTangThoiGianChuanBi;
            canGapBDO.ThuTu = canGapDTO.ThuTu;
        }
    }
   
}
