using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class DongCuon : ThanhPhamBase
    {
        //Bổ sung thêm thuộc tính
        public string TieuDe { get; set; }
        public int TocDoCuonGio { get; set; }
        public int PhiNgVLCuon { get; set; }
        public bool BiaToDon { get; set; }
        public bool RuotToDon { get; set; }
        //Statics
        public static List<DongCuon> DocTatCa()
        {
            var canPhuLogic = new DongCuonLogic();
            var nguon = canPhuLogic.DocTatCa().Select(x => new DongCuon
            {                
                ID = x.ID,
                Ten = x.Ten,
                TieuDe = x.TieuDe,
                BHR = x.BHR,
                TocDoCuonGio = x.TocDoCuonGio,
                ThoiGianChuanBi = x.ThoiGianChuanBi,
                BiaToDon = x.BiaToDon,
                RuotToDon = x.RuotToDon,
                DayLoiNhuan = x.DayLoiNhuan,
                DaySoLuong = x.DaySoLuong,
                PhiNgVLCuon = x.PhiNgVLCuon,
                Ma_01 = x.Ma_01,
                DaySoLuongNiemYet = x.DaySoLuongNiemYet,
                DonViTinh = x.DonViTinh,
                ThuTu = x.ThuTu
            }).OrderBy(x => x.ThuTu).ToList();

            return nguon;
        }
        public static DongCuon DocTheoId(int iD)
        {
            var canPhuLogic = new DongCuonLogic(); ;
            DongCuon dongCuon = new DongCuon();
            try
            {
                var dongCuonBDO = canPhuLogic.DocTheoId(iD);
                //Chuyen
                ChuyenDoiGiayBDOThanhDTO(dongCuonBDO, dongCuon);
            }
            catch
            {
            }
            return dongCuon;
        }
        #region Thêm sủa xóa
        public static string Sua(DongCuon canGap)
        {
            var dongCuonLogic = new DongCuonLogic();
            var itemBDO = new DongCuonBDO();
            ChuyenDoiGiayDTOThanhBDO(canGap, itemBDO);
            return dongCuonLogic.Sua(itemBDO);
        }
        #endregion
        private static void ChuyenDoiGiayBDOThanhDTO(DongCuonBDO dongCuonBDO, DongCuon dongCuonDTO)
        {
            dongCuonDTO.ID = dongCuonBDO.ID;
            dongCuonDTO.Ten = dongCuonBDO.Ten;
            dongCuonDTO.TieuDe = dongCuonBDO.TieuDe;
            dongCuonDTO.BHR = dongCuonBDO.BHR;
            dongCuonDTO.TocDoCuonGio = dongCuonBDO.TocDoCuonGio;
            dongCuonDTO.ThoiGianChuanBi = dongCuonBDO.ThoiGianChuanBi;
            dongCuonDTO.BiaToDon = dongCuonBDO.BiaToDon;
            dongCuonDTO.RuotToDon = dongCuonBDO.RuotToDon;
            dongCuonDTO.DayLoiNhuan = dongCuonBDO.DayLoiNhuan;
            dongCuonDTO.DaySoLuong = dongCuonBDO.DaySoLuong;
            dongCuonDTO.PhiNgVLCuon = dongCuonBDO.PhiNgVLCuon;
            dongCuonDTO.Ma_01 = dongCuonBDO.Ma_01;
            dongCuonDTO.DaySoLuongNiemYet = dongCuonBDO.DaySoLuongNiemYet;
            dongCuonDTO.DonViTinh = dongCuonBDO.DonViTinh;
            dongCuonDTO.ThuTu = dongCuonBDO.ThuTu;
        }
        private static void ChuyenDoiGiayDTOThanhBDO(DongCuon dongCuonDTO, DongCuonBDO dongCuonBDO)
        {
            dongCuonBDO.ID = dongCuonDTO.ID;
            dongCuonBDO.Ten = dongCuonDTO.Ten;
            dongCuonBDO.TieuDe = dongCuonDTO.TieuDe;
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
