using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class CanPhu: ThanhPhamBase
    {
        //Bổ sung
        public int TocDoMetGio { get; set; }
        public int PhiNgVLM2 { get; set; }
                   
        public static List<CanPhu> DocTatCa()
        {
            var canPhuLogic = new CanPhuLogic();
            var nguon = canPhuLogic.LayTatCa().Select(x => new CanPhu
            {                
                ID = x.ID,
                Ten = x.Ten,
                BHR = x.BHR,
                TocDoMetGio = x.TocDoMetGio,
                ThoiGianChuanBi = x.ThoiGianChuanBi,
                DayLoiNhuan = x.DayLoiNhuan,
                DaySoLuong = x.DaySoLuong,
                PhiNgVLM2 = x.PhiNgVLM2,
                Ma_01 = x.Ma_01,
                DonViTinh = x.DonViTinh,
                DaySoLuongNiemYet = x.DaySoLuongNiemYet,
                ThuTu = x.ThuTu
            }).OrderBy(x => x.ThuTu).ToList();

            return nguon;
        }
        public static CanPhu DocTheoId(int iD)
        {
            var canPhuLogic = new CanPhuLogic(); ;
            CanPhu canPhu = new CanPhu();
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
        public static string Sua(CanPhu canPhu)
        {
            var canPhuLogic = new CanPhuLogic();
            var itemBDO = new CanPhuBDO();
            ChuyenDoiGiayDTOThanhBDO(canPhu, itemBDO);
            return canPhuLogic.Sua(itemBDO);
        }
        private static void ChuyenDoiGiayBDOThanhDTO(CanPhuBDO canPhuBDO, CanPhu canPhuDTO)
        {
            canPhuDTO.ID = canPhuBDO.ID;
            canPhuDTO.Ten = canPhuBDO.Ten;
            canPhuDTO.BHR = canPhuBDO.BHR;
            canPhuDTO.TocDoMetGio = canPhuBDO.TocDoMetGio;
            canPhuDTO.ThoiGianChuanBi = canPhuBDO.ThoiGianChuanBi;
            canPhuDTO.DayLoiNhuan = canPhuBDO.DayLoiNhuan;
            canPhuDTO.DaySoLuong = canPhuBDO.DaySoLuong;
            canPhuDTO.PhiNgVLM2 = canPhuBDO.PhiNgVLM2;
            canPhuDTO.Ma_01 = canPhuBDO.Ma_01;
            canPhuDTO.DonViTinh = canPhuBDO.DonViTinh;
            canPhuDTO.DaySoLuongNiemYet = canPhuBDO.DaySoLuongNiemYet;
            canPhuDTO.ThuTu = canPhuBDO.ThuTu;
        }
        private static void ChuyenDoiGiayDTOThanhBDO(CanPhu canPhuDTO, CanPhuBDO canPhuBDO)
        {
            canPhuBDO.ID = canPhuDTO.ID;
            canPhuBDO.Ten = canPhuDTO.Ten;
            canPhuBDO.BHR = canPhuDTO.BHR;
            canPhuBDO.TocDoMetGio = canPhuDTO.TocDoMetGio;
            canPhuBDO.ThoiGianChuanBi = canPhuDTO.ThoiGianChuanBi;
            canPhuBDO.DayLoiNhuan = canPhuDTO.DayLoiNhuan;
            canPhuBDO.DaySoLuong = canPhuDTO.DaySoLuong;
            canPhuBDO.PhiNgVLM2 = canPhuDTO.PhiNgVLM2;
            canPhuBDO.Ma_01 = canPhuDTO.Ma_01;
            canPhuBDO.DonViTinh = canPhuDTO.DonViTinh;
            canPhuBDO.DaySoLuongNiemYet = canPhuDTO.DaySoLuongNiemYet;
            canPhuBDO.ThuTu = canPhuDTO.ThuTu;
        }
    }
   
}
