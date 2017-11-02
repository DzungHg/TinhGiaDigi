using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class MayKhoanBoGoc : ThanhPhamBase
    {
        //Bổ sung thêm thuộc tính
        public int TocDoBlockGio { get; set; }
        public int PhiDungCuMoiBlock { get; set; }
        public string DienGiai { get; set; }
        public string TieuDe { get; set; } 
        
        //Statics
        public static List<MayKhoanBoGoc> DocTatCa()
        {
            var khoanBoGocLogic = new MayKhoanBoGocLogic();
            var nguon = khoanBoGocLogic.DocTatCa().Select(x => new MayKhoanBoGoc
            {                
                ID = x.ID,
                Ten = x.Ten,
                DienGiai = x.DienGiai,
                TieuDe = x.TieuDe,
                BHR = x.BHR,
                TocDoBlockGio = x.TocDoBlockGio,
                PhiDungCuMoiBlock  = x.PhiDungCuMoiBlock,
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
        public static MayKhoanBoGoc DocTheoId(int iD)
        {
            var khoanBoGocLogic = new MayKhoanBoGocLogic(); ;
            MayKhoanBoGoc dongCuon = new MayKhoanBoGoc();
            try
            {
                var dongCuonBDO = khoanBoGocLogic.DocTheoId(iD);
                //Chuyen
                ChuyenDoiBDOThanhDTO(dongCuonBDO, dongCuon);
            }
            catch
            {
            }
            return dongCuon;
        }
        #region Thêm sủa xóa
        public static string Them(MayKhoanBoGoc boiBiaCung)
        {
            var khoanBoGoclLogic = new MayKhoanBoGocLogic();
            var itemBDO = new MayKhoanBoGocBDO();
            ChuyenDoiDTOThanhBDO(boiBiaCung, itemBDO);
            return khoanBoGoclLogic.Them(itemBDO);
        }
        public static string Sua(MayKhoanBoGoc khoanBoGoc)
        {
            var khoanBoGocLogic = new MayKhoanBoGocLogic();
            var itemBDO = new MayKhoanBoGocBDO();
            ChuyenDoiDTOThanhBDO(khoanBoGoc, itemBDO);
            return khoanBoGocLogic.Sua(itemBDO);
        }
        #endregion
        private static void ChuyenDoiBDOThanhDTO(MayKhoanBoGocBDO itemBDO, MayKhoanBoGoc itemDTO)
        {
            itemDTO.ID = itemBDO.ID;
            itemDTO.Ten = itemBDO.Ten;
            itemDTO.BHR = itemBDO.BHR;
            itemDTO.TieuDe = itemBDO.TieuDe;
            itemDTO.TocDoBlockGio = itemBDO.TocDoBlockGio;
            itemDTO.PhiDungCuMoiBlock = itemBDO.PhiDungCuMoiBlock;
            itemDTO.ThoiGianChuanBi = itemBDO.ThoiGianChuanBi;
            itemDTO.DayLoiNhuan = itemBDO.DayLoiNhuan;
            itemDTO.DaySoLuong = itemBDO.DaySoLuong;
            itemDTO.DienGiai = itemBDO.DienGiai;
            itemDTO.Ma_01 = itemBDO.Ma_01;
            itemDTO.DaySoLuongNiemYet = itemBDO.DaySoLuongNiemYet;
            itemDTO.DonViTinh = itemBDO.DonViTinh;
          
            itemDTO.ThuTu = itemBDO.ThuTu;
        }
        private static void ChuyenDoiDTOThanhBDO(MayKhoanBoGoc itemDTO, MayKhoanBoGocBDO itemBDO)
        {
            itemBDO.ID = itemDTO.ID;
            itemBDO.Ten = itemDTO.Ten;
            itemBDO.BHR = itemDTO.BHR;
            itemBDO.TieuDe = itemDTO.TieuDe;
            itemBDO.TocDoBlockGio = itemDTO.TocDoBlockGio;
            itemBDO.PhiDungCuMoiBlock = itemDTO.PhiDungCuMoiBlock;
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
