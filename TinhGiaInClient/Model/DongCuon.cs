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
        public int TocDoCuonGio { get; set; }
        public int PhiNgVLCuon { get; set; }
        
        //Statics
        public static List<DongCuon> DocTatCa()
        {
            var canPhuLogic = new DongCuonLogic();
            var nguon = canPhuLogic.DocTatCa().Select(x => new DongCuon
            {                
                ID = x.ID,
                Ten = x.Ten,
                BHR = x.BHR,
                TocDoCuonGio = x.TocDoCuonGio,
                ThoiGianChuanBi = x.ThoiGianChuanBi,
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
        private static void ChuyenDoiGiayBDOThanhDTO(DongCuonBDO dongCuonBDO, DongCuon dongCuonDTO)
        {
            dongCuonDTO.ID = dongCuonBDO.ID;
            dongCuonDTO.Ten = dongCuonBDO.Ten;
            dongCuonDTO.BHR = dongCuonBDO.BHR;
            dongCuonDTO.TocDoCuonGio = dongCuonBDO.TocDoCuonGio;
            dongCuonDTO.ThoiGianChuanBi = dongCuonBDO.ThoiGianChuanBi;
            dongCuonDTO.DayLoiNhuan = dongCuonBDO.DayLoiNhuan;
            dongCuonDTO.DaySoLuong = dongCuonBDO.DaySoLuong;
            dongCuonDTO.PhiNgVLCuon = dongCuonBDO.PhiNgVLCuon;
            dongCuonDTO.Ma_01 = dongCuonBDO.Ma_01;
            dongCuonDTO.DaySoLuongNiemYet = dongCuonBDO.DaySoLuongNiemYet;
            dongCuonDTO.DonViTinh = dongCuonBDO.DonViTinh;
            dongCuonDTO.ThuTu = dongCuonBDO.ThuTu;
        }
    }
   
}
