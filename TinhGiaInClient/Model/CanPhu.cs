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
            canPhuDTO.ThuTu = canPhuBDO.ThuTu;
        }
    }
   
}
