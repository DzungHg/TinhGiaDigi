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
        private static void ChuyenDoiGiayBDOThanhDTO(DongCuonBDO canPhuBDO, DongCuon canPhuDTO)
        {
            canPhuDTO.ID = canPhuBDO.ID;
            canPhuDTO.Ten = canPhuBDO.Ten;
            canPhuDTO.BHR = canPhuBDO.BHR;
            canPhuDTO.TocDoCuonGio = canPhuBDO.TocDoCuonGio;
            canPhuDTO.ThoiGianChuanBi = canPhuBDO.ThoiGianChuanBi;
            canPhuDTO.DayLoiNhuan = canPhuBDO.DayLoiNhuan;
            canPhuDTO.DaySoLuong = canPhuBDO.DaySoLuong;
            canPhuDTO.PhiNgVLCuon = canPhuBDO.PhiNgVLCuon;                   
            canPhuDTO.ThuTu = canPhuBDO.ThuTu;
        }
    }
   
}
