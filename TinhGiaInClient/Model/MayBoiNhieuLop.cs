using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class MayBoiNhieuLop : ThanhPhamBase
    {
        //Bổ sung thêm thuộc tính
        public int TocDoTamGio { get; set; }
        public int PhiKeoMetVuong { get; set; }
        public string DienGiai { get; set; }  
        
        //Statics
        public static List<MayBoiNhieuLop> DocTatCa()
        {
            var boiNhieuLopLogic = new MayBoiNhieuLopLogic();
            var nguon = boiNhieuLopLogic.DocTatCa().Select(x => new MayBoiNhieuLop
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
        public static MayBoiNhieuLop DocTheoId(int iD)
        {
            var boiNhieuLopLogic = new MayBoiNhieuLopLogic(); ;
            MayBoiNhieuLop dongCuon = new MayBoiNhieuLop();
            try
            {
                var dongCuonBDO = boiNhieuLopLogic.DocTheoId(iD);
                //Chuyen
                ChuyenDoiBDOThanhDTO(dongCuonBDO, dongCuon);
            }
            catch
            {
            }
            return dongCuon;
        }
        #region Thêm sủa xóa
        public static string Them(MayBoiNhieuLop boiBiaCung)
        {
            var boiNhieuLoplLogic = new MayBoiNhieuLopLogic();
            var itemBDO = new MayBoiNhieuLopBDO();
            ChuyenDoiDTOThanhBDO(boiBiaCung, itemBDO);
            return boiNhieuLoplLogic.Them(itemBDO);
        }
        public static string Sua(MayBoiNhieuLop boiBiaCung)
        {
            var boiNhieuLopLogic = new MayBoiNhieuLopLogic();
            var itemBDO = new MayBoiNhieuLopBDO();
            ChuyenDoiDTOThanhBDO(boiBiaCung, itemBDO);
            return boiNhieuLopLogic.Sua(itemBDO);
        }
        #endregion
        private static void ChuyenDoiBDOThanhDTO(MayBoiNhieuLopBDO itemBDO, MayBoiNhieuLop itemDTO)
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
        private static void ChuyenDoiDTOThanhBDO(MayBoiNhieuLop itemDTO, MayBoiNhieuLopBDO itemBDO)
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
