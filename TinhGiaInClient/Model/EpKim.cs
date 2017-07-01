using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class EpKim : ThanhPhamBase
    {

        //Thêm các properties
        public int TocDoConGio { get; set; }
        public int PhiNVLChuanBi { get; set; }
        public int GiaKhuonCm2 { get; set; }
        public bool LaNhuViTinh { get; set; }
        //Emplement IThanh phẩm
               
        #region hàm static
        public static List<EpKim> DocTatCa()
        {
            var canPhuLogic = new EpKimLogic();
            var nguon = canPhuLogic.DocTatCa().Select(x => new EpKim
            {                
                ID = x.ID,
                Ten = x.Ten,
                BHR = x.BHR,
                TocDoConGio = x.TocDoConGio,
                ThoiGianChuanBi = x.ThoiGianChuanBi,
                PhiNVLChuanBi = x.PhiNguyenVatLieuChuanBi,
                DayLoiNhuan = x.DayLoiNhuan,
                DaySoLuong = x.DaySoLuong,    
                GiaKhuonCm2 = x.GiaKhuonCm2,
                LaNhuViTinh = x.LaViTinh,
                Ma_01 = x.Ma_01,
                DonViTinh = x.DonViTinh,
                DaySoLuongNiemYet = x.DaySoLuongNiemYet,
                ThuTu = x.ThuTu
            }).OrderBy(x => x.ThuTu).ToList();

            return nguon;
        }
        public static EpKim DocTheoId(int iD)
        {
            var canPhuLogic = new EpKimLogic(); ;
            EpKim canPhu = new EpKim();
            try
            {
                var canPhuBDO = canPhuLogic.DocTheoId(iD);
                //Chuyen
                ChuyenDoiEpKimBDOThanhDTO(canPhuBDO, canPhu);
            }
            catch
            {
            }
            return canPhu;
        }
        public static string Them(EpKim epKim)
        {
            var epKimLogic = new EpKimLogic();
            var itemBDO = new EpKimBDO();
            ChuyenDoiEpKimDTOThanhBDO(epKim, itemBDO);
            return epKimLogic.Them(itemBDO);
        }
        public static string Sua(EpKim canGap)
        {
            var epKimLogic = new EpKimLogic();
            var itemBDO = new EpKimBDO();
            ChuyenDoiEpKimDTOThanhBDO(canGap, itemBDO);
            return epKimLogic.Sua(itemBDO);
        }
        private static void ChuyenDoiEpKimBDOThanhDTO(EpKimBDO epKimBDO, EpKim epKimDTO)
        {
            epKimDTO.ID = epKimBDO.ID;
            epKimDTO.Ten = epKimBDO.Ten;
            epKimDTO.BHR = epKimBDO.BHR;
            epKimDTO.TocDoConGio = epKimBDO.TocDoConGio;
            epKimDTO.ThoiGianChuanBi = epKimBDO.ThoiGianChuanBi;
            epKimDTO.PhiNVLChuanBi = epKimBDO.PhiNguyenVatLieuChuanBi;
            epKimDTO.DayLoiNhuan = epKimBDO.DayLoiNhuan;
            epKimDTO.DaySoLuong = epKimBDO.DaySoLuong;
            epKimDTO.LaNhuViTinh = epKimBDO.LaViTinh;
            epKimDTO.GiaKhuonCm2 = epKimBDO.GiaKhuonCm2;
            epKimDTO.Ma_01 = epKimBDO.Ma_01;
            epKimDTO.DonViTinh = epKimBDO.DonViTinh;
            epKimDTO.DaySoLuongNiemYet = epKimBDO.DaySoLuongNiemYet;
            epKimDTO.ThuTu = epKimBDO.ThuTu;
        }
        private static void ChuyenDoiEpKimDTOThanhBDO(EpKim epKimDTO, EpKimBDO epKimBDO)
        {
            epKimBDO.ID = epKimDTO.ID;
            epKimBDO.Ten = epKimDTO.Ten;
            epKimBDO.BHR = epKimDTO.BHR;
            epKimBDO.TocDoConGio = epKimDTO.TocDoConGio;
            epKimBDO.ThoiGianChuanBi = epKimDTO.ThoiGianChuanBi;
            epKimBDO.PhiNguyenVatLieuChuanBi = epKimDTO.PhiNVLChuanBi;
            epKimBDO.DayLoiNhuan = epKimDTO.DayLoiNhuan;
            epKimBDO.DaySoLuong = epKimDTO.DaySoLuong;
            epKimBDO.LaViTinh = epKimDTO.LaNhuViTinh;
            epKimBDO.GiaKhuonCm2 = epKimDTO.GiaKhuonCm2;
            epKimBDO.Ma_01 = epKimDTO.Ma_01;
            epKimBDO.DonViTinh = epKimDTO.DonViTinh;
            epKimBDO.DaySoLuongNiemYet = epKimDTO.DaySoLuongNiemYet;
            epKimBDO.ThuTu = epKimDTO.ThuTu;
        }
        #endregion
    }
   
}
