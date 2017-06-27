using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class CatDecal : ThanhPhamBase
    {
        //Bổ sung thêm thuộc tính
        public int TocDoMetGio { get; set; }
        public int PhiDao1000Met { get; set; }
        public string GhiChu {get;set;}
        
        //Statics
        public static List<CatDecal> DocTatCa()
        {
            var dongCuonLogic = new CatDecalLogic();
            var nguon = dongCuonLogic.DocTatCa().Select(x => new CatDecal
            {                
                ID = x.ID,
                Ten = x.Ten,
                BHR = x.BHR,
                TocDoMetGio = x.TocDoMetGio,
                PhiDao1000Met = x.PhiDao1000Met,
                ThoiGianChuanBi = x.ThoiGianChuanBi,
                DayLoiNhuan = x.DayLoiNhuan,
                DaySoLuong = x.DaySoLuong,             
                Ma_01 = x.Ma_01,
                DaySoLuongNiemYet = x.DaySoLuongNiemYet,
                DonViTinh = x.DonViTinh,
                GhiChu = x.GhiChu,
                ThuTu = x.ThuTu
            }).OrderBy(x => x.ThuTu).ToList();

            return nguon;
        }
        public static CatDecal DocTheoId(int iD)
        {
            var catDecalLogic = new CatDecalLogic(); ;
            CatDecal dongCuon = new CatDecal();
            try
            {
                var dongCuonBDO = catDecalLogic.DocTheoId(iD);
                //Chuyen
                ChuyenDoiBDOThanhDTO(dongCuonBDO, dongCuon);
            }
            catch
            {
            }
            return dongCuon;
        }
        #region Thêm sủa xóa
        public static string Them(CatDecal catDecal)
        {
            var catDecalLogic = new CatDecalLogic();
            var itemBDO = new CatDecalBDO();
            ChuyenDoiDTOThanhBDO(catDecal, itemBDO);
            return catDecalLogic.Them(itemBDO);
        }
        public static string Sua(CatDecal catDecal)
        {
            var catDecalLogic = new CatDecalLogic();
            var itemBDO = new CatDecalBDO();
            ChuyenDoiDTOThanhBDO(catDecal, itemBDO);
            return catDecalLogic.Sua(itemBDO);
        }
        #endregion
        private static void ChuyenDoiBDOThanhDTO(CatDecalBDO catDecalBDO, CatDecal catDecalDTO)
        {
            catDecalDTO.ID = catDecalBDO.ID;
            catDecalDTO.Ten = catDecalBDO.Ten;
            catDecalDTO.BHR = catDecalBDO.BHR;
            catDecalDTO.TocDoMetGio = catDecalBDO.TocDoMetGio;
            catDecalDTO.PhiDao1000Met = catDecalBDO.PhiDao1000Met;
            catDecalDTO.ThoiGianChuanBi = catDecalBDO.ThoiGianChuanBi;
            catDecalDTO.DayLoiNhuan = catDecalBDO.DayLoiNhuan;
            catDecalDTO.DaySoLuong = catDecalBDO.DaySoLuong;
            
            catDecalDTO.Ma_01 = catDecalBDO.Ma_01;
            catDecalDTO.DaySoLuongNiemYet = catDecalBDO.DaySoLuongNiemYet;
            catDecalDTO.DonViTinh = catDecalBDO.DonViTinh;
            catDecalDTO.GhiChu = catDecalBDO.GhiChu;
            catDecalDTO.ThuTu = catDecalBDO.ThuTu;
        }
        private static void ChuyenDoiDTOThanhBDO(CatDecal catDecalDTO, CatDecalBDO catDecalBDO)
        {
            catDecalBDO.ID = catDecalDTO.ID;
            catDecalBDO.Ten = catDecalDTO.Ten;
            catDecalBDO.BHR = catDecalDTO.BHR;
            catDecalBDO.TocDoMetGio = catDecalDTO.TocDoMetGio;
            catDecalBDO.PhiDao1000Met = catDecalDTO.PhiDao1000Met;
            catDecalBDO.ThoiGianChuanBi = catDecalDTO.ThoiGianChuanBi;
            catDecalBDO.DayLoiNhuan = catDecalDTO.DayLoiNhuan;
            catDecalBDO.DaySoLuong = catDecalDTO.DaySoLuong;
            catDecalBDO.Ma_01 = catDecalDTO.Ma_01;
            catDecalBDO.DonViTinh = catDecalDTO.DonViTinh;
            catDecalBDO.DaySoLuongNiemYet = catDecalDTO.DaySoLuongNiemYet;
            catDecalBDO.GhiChu = catDecalDTO.GhiChu;
            catDecalBDO.ThuTu = catDecalDTO.ThuTu;
        }
    }
   
}
