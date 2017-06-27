using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class DongCuonMoPhang : ThanhPhamBase
    {
        //Bổ sung thêm thuộc tính
        public int TocDoToDoiGio { get; set; }
        public int PhiKeoToDoi { get; set; }
        public bool BiaToDon { get; set; }
        public bool RuotToDon { get; set; }
        //Statics
        public static List<DongCuonMoPhang> DocTatCa()
        {
            var dongCuonLogic = new DongCuonMoPhangLogic();
            var nguon = dongCuonLogic.DocTatCa().Select(x => new DongCuonMoPhang
            {                
                ID = x.ID,
                Ten = x.Ten,
                BHR = x.BHR,
                TocDoToDoiGio = x.TocDoToDoiGio,
                PhiKeoToDoi = x.PhiKeoToDoi,
                BiaToDon = x.BiaToDon,
                RuotToDon = x.RuotToDon,
                ThoiGianChuanBi = x.ThoiGianChuanBi,
                DayLoiNhuan = x.DayLoiNhuan,
                DaySoLuong = x.DaySoLuong,             
                Ma_01 = x.Ma_01,
                DaySoLuongNiemYet = x.DaySoLuongNiemYet,
                DonViTinh = x.DonViTinh,
                ThuTu = x.ThuTu
            }).OrderBy(x => x.ThuTu).ToList();

            return nguon;
        }
        public static DongCuonMoPhang DocTheoId(int iD)
        {
            var dongCuonLogic = new DongCuonMoPhangLogic(); ;
            DongCuonMoPhang dongCuon = new DongCuonMoPhang();
            try
            {
                var dongCuonBDO = dongCuonLogic.DocTheoId(iD);
                //Chuyen
                ChuyenDoiBDOThanhDTO(dongCuonBDO, dongCuon);
            }
            catch
            {
            }
            return dongCuon;
        }
        #region Thêm sủa xóa
        public static string Sua(DongCuonMoPhang dongCuon)
        {
            var dongCuonLogic = new DongCuonMoPhangLogic();
            var itemBDO = new DongCuonMoPhangBDO();
            ChuyenDoiDTOThanhBDO(dongCuon, itemBDO);
            return dongCuonLogic.Sua(itemBDO);
        }
        #endregion
        private static void ChuyenDoiBDOThanhDTO(DongCuonMoPhangBDO dongCuonBDO, DongCuonMoPhang dongCuonDTO)
        {
            dongCuonDTO.ID = dongCuonBDO.ID;
            dongCuonDTO.Ten = dongCuonBDO.Ten;
            dongCuonDTO.BHR = dongCuonBDO.BHR;
            dongCuonDTO.TocDoToDoiGio = dongCuonBDO.TocDoToDoiGio;
            dongCuonDTO.PhiKeoToDoi = dongCuonBDO.PhiKeoToDoi;
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
        private static void ChuyenDoiDTOThanhBDO(DongCuonMoPhang dongCuonDTO, DongCuonMoPhangBDO dongCuonBDO)
        {
            dongCuonBDO.ID = dongCuonDTO.ID;
            dongCuonBDO.Ten = dongCuonDTO.Ten;
            dongCuonBDO.BHR = dongCuonDTO.BHR;
            dongCuonBDO.TocDoToDoiGio = dongCuonDTO.TocDoToDoiGio;
            dongCuonBDO.PhiKeoToDoi = dongCuonDTO.PhiKeoToDoi;
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
