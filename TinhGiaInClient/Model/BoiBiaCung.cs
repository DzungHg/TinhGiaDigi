using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class BoiBiaCung : ThanhPhamBase
    {
        //Bổ sung thêm thuộc tính
        public int TocDoTamGio { get; set; }
        public int PhiKeoMetVuong { get; set; }
        public string DienGiai { get; set; }  
        
        //Statics
        public static List<BoiBiaCung> DocTatCa()
        {
            var boiBiaCungLogic = new BoiBiaCungLogic();
            var nguon = boiBiaCungLogic.DocTatCa().Select(x => new BoiBiaCung
            {                
                ID = x.ID,
                Ten = x.Ten,
                DienGiai = x.DienGiai,
                BHR = x.BHR,
                TocDoTamGio = x.TocDoTamGio,
                PhiKeoMetVuong = x.PhiKeoMetVuong,
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
        public static BoiBiaCung DocTheoId(int iD)
        {
            var boiBiaCungLogic = new BoiBiaCungLogic(); ;
            BoiBiaCung dongCuon = new BoiBiaCung();
            try
            {
                var dongCuonBDO = boiBiaCungLogic.DocTheoId(iD);
                //Chuyen
                ChuyenDoiBDOThanhDTO(dongCuonBDO, dongCuon);
            }
            catch
            {
            }
            return dongCuon;
        }
        #region Thêm sủa xóa
        public static string Them(BoiBiaCung boiBiaCung)
        {
            var boiBiaCunglLogic = new BoiBiaCungLogic();
            var itemBDO = new BoiBiaCungBDO();
            ChuyenDoiDTOThanhBDO(boiBiaCung, itemBDO);
            return boiBiaCunglLogic.Them(itemBDO);
        }
        public static string Sua(BoiBiaCung boiBiaCung)
        {
            var boiBiaCunglLogic = new BoiBiaCungLogic();
            var itemBDO = new BoiBiaCungBDO();
            ChuyenDoiDTOThanhBDO(boiBiaCung, itemBDO);
            return boiBiaCunglLogic.Sua(itemBDO);
        }
        #endregion
        private static void ChuyenDoiBDOThanhDTO(BoiBiaCungBDO itemBDO, BoiBiaCung itemDTO)
        {
            itemDTO.ID = itemBDO.ID;
            itemDTO.Ten = itemBDO.Ten;
            itemDTO.BHR = itemBDO.BHR;
            itemDTO.TocDoTamGio = itemBDO.TocDoTamGio;
            itemDTO.PhiKeoMetVuong = itemBDO.PhiKeoMetVuong;
            itemDTO.ThoiGianChuanBi = itemBDO.ThoiGianChuanBi;
            itemDTO.DayLoiNhuan = itemBDO.DayLoiNhuan;
            itemDTO.DaySoLuong = itemBDO.DaySoLuong;
            itemDTO.DienGiai = itemBDO.DienGiai;
            itemDTO.Ma_01 = itemBDO.Ma_01;
            itemDTO.DaySoLuongNiemYet = itemBDO.DaySoLuongNiemYet;
            itemDTO.DonViTinh = itemBDO.DonViTinh;
          
            itemDTO.ThuTu = itemBDO.ThuTu;
        }
        private static void ChuyenDoiDTOThanhBDO(BoiBiaCung itemDTO, BoiBiaCungBDO itemBDO)
        {
            itemBDO.ID = itemDTO.ID;
            itemBDO.Ten = itemDTO.Ten;
            itemBDO.BHR = itemDTO.BHR;
            itemBDO.TocDoTamGio = itemDTO.TocDoTamGio;
            itemBDO.PhiKeoMetVuong = itemDTO.PhiKeoMetVuong;
            itemBDO.ThoiGianChuanBi = itemDTO.ThoiGianChuanBi;
            itemBDO.DayLoiNhuan = itemDTO.DayLoiNhuan;
            itemBDO.DaySoLuong = itemDTO.DaySoLuong;
            itemBDO.Ma_01 = itemDTO.Ma_01;
            itemBDO.DonViTinh = itemDTO.DonViTinh;
            itemBDO.DaySoLuongNiemYet = itemDTO.DaySoLuongNiemYet;
            itemBDO.DienGiai = itemDTO.DienGiai;
            itemBDO.ThuTu = itemDTO.ThuTu;
        }
    }
   
}
