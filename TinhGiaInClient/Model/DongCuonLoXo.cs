using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class DongCuonLoXo : ThanhPhamBase
    {
        //Bổ sung thêm thuộc tính
        public int TocDoCuonGio { get; set; }
        public bool BiaToDon { get; set; }
        public bool RuotToDon { get; set; }
        
        //Statics
        public static List<DongCuonLoXo> DocTatCa()
        {
            var canPhuLogic = new DongCuonLoXoLogic();
            var nguon = canPhuLogic.DocTatCa().Select(x => new DongCuonLoXo
            {                
                ID = x.ID,
                Ten = x.Ten,
                BHR = x.BHR,
                TocDoCuonGio = x.TocDoCuonGio,
                ThoiGianChuanBi = x.ThoiGianChuanBi,
                BiaToDon = x.BiaToDon,
                RuotToDon = x.RuotToDon,
                DayLoiNhuan = x.DayLoiNhuan,
                DaySoLuong = x.DaySoLuong,             
                Ma_01 = x.Ma_01,
                DaySoLuongNiemYet = x.DaySoLuongNiemYet,
                DonViTinh = x.DonViTinh,
                ThuTu = x.ThuTu
            }).OrderBy(x => x.ThuTu).ToList();

            return nguon;
        }
        public static DongCuonLoXo DocTheoId(int iD)
        {
            var canPhuLogic = new DongCuonLoXoLogic(); ;
            DongCuonLoXo dongCuon = new DongCuonLoXo();
            try
            {
                var dongCuonBDO = canPhuLogic.DocTheoId(iD);
                //Chuyen
                ChuyenDoiBDOThanhDTO(dongCuonBDO, dongCuon);
            }
            catch
            {
            }
            return dongCuon;
        }
        #region Thêm sủa xóa
        public static string Sua(DongCuonLoXo dongCuon)
        {
            var dongCuonLogic = new DongCuonLoXoLogic();
            var itemBDO = new DongCuonLoXoBDO();
            ChuyenDoiDTOThanhBDO(dongCuon, itemBDO);
            return dongCuonLogic.Sua(itemBDO);
        }
        #endregion
        private static void ChuyenDoiBDOThanhDTO(DongCuonLoXoBDO dongCuonBDO, DongCuonLoXo dongCuonDTO)
        {
            dongCuonDTO.ID = dongCuonBDO.ID;
            dongCuonDTO.Ten = dongCuonBDO.Ten;
            dongCuonDTO.BHR = dongCuonBDO.BHR;
            dongCuonDTO.TocDoCuonGio = dongCuonBDO.TocDoCuonGio;
            dongCuonDTO.ThoiGianChuanBi = dongCuonBDO.ThoiGianChuanBi;
            dongCuonDTO.BiaToDon = dongCuonBDO.BiaToDon;
            dongCuonDTO.RuotToDon = dongCuonBDO.RuotToDon;
            dongCuonDTO.DayLoiNhuan = dongCuonBDO.DayLoiNhuan;
            dongCuonDTO.DaySoLuong = dongCuonBDO.DaySoLuong;          
            dongCuonDTO.Ma_01 = dongCuonBDO.Ma_01;
            dongCuonDTO.DaySoLuongNiemYet = dongCuonBDO.DaySoLuongNiemYet;
            dongCuonDTO.DonViTinh = dongCuonBDO.DonViTinh;
            dongCuonDTO.ThuTu = dongCuonBDO.ThuTu;
        }
        private static void ChuyenDoiDTOThanhBDO(DongCuonLoXo dongCuonDTO, DongCuonLoXoBDO dongCuonBDO)
        {
            dongCuonBDO.ID = dongCuonDTO.ID;
            dongCuonBDO.Ten = dongCuonDTO.Ten;
            dongCuonBDO.BHR = dongCuonDTO.BHR;
            dongCuonBDO.TocDoCuonGio = dongCuonDTO.TocDoCuonGio;
            dongCuonBDO.ThoiGianChuanBi = dongCuonDTO.ThoiGianChuanBi;
            dongCuonBDO.BiaToDon = dongCuonDTO.BiaToDon;
            dongCuonBDO.RuotToDon = dongCuonDTO.RuotToDon;
            dongCuonBDO.DayLoiNhuan = dongCuonDTO.DayLoiNhuan;
            dongCuonBDO.DaySoLuong = dongCuonDTO.DaySoLuong;
            dongCuonBDO.Ma_01 = dongCuonDTO.Ma_01;
            dongCuonBDO.DonViTinh = dongCuonDTO.DonViTinh;
            dongCuonBDO.DaySoLuongNiemYet = dongCuonDTO.DaySoLuongNiemYet;
            dongCuonBDO.ThuTu = dongCuonDTO.ThuTu;
        }
    }
   
}
