using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class OffsetGiaCong
    {
        #region Lớp thật
        public int ID { get; set; }
        public string Ten { get; set; }
        public string TenNhaCungCap { get; set; }
        public string TenKhoIn { get; set; }
        public int KhoInRongMax { get; set; }
        public int KhoInDaiMax { get; set; }
        public int KhoInRongMin { get; set; }
        public int KhoInDaiMin { get; set; }
        public bool TuTroNhip { get; set; }
        public int GiaCongIn { get; set; }
        public int SoMatInCoBan { get; set; }
        public int GiaInMoiMatVuotCoBan { get; set; }
        public int SoToChayBuHaoCoBan { get; set; }
        public string ThongTinThoDungMayIn { get; set; }
        public string GhiChu { get; set; }
        public int ThuTu { get; set; }
        public bool KhongDung { get; set; }
        #endregion
        //Các hàm static
        public static List<OffsetGiaCong> DocTatCa()
        {
            var toChayDigiLogic = new OffsetGiaCongLogic();
            var nguon = toChayDigiLogic.DocTatCa().Select(x => new OffsetGiaCong
            {
                ID = x.ID,
                Ten = x.Ten,
                TenNhaCungCap = x.TenNhaCungCap,
                TenKhoIn = x.TenKhoIn,
                KhoInRongMax = (int)x.KhoInRongMax,
                KhoInDaiMax = (int)x.KhoInDaiMax,
                KhoInRongMin = (int)x.KhoInRongMin,
                KhoInDaiMin = (int)x.KhoInDaiMin,
                TuTroNhip = (bool)x.TuTroNhip,
                GiaCongIn = (int)x.GiaCongIn,
                SoMatInCoBan = (int)x.SoMatInCoBan,
                GiaInMoiMatVuotCoBan = (int)x.GiaInMoiMatVuotCoBan,
                SoToChayBuHaoCoBan = (int)x.SoToChayBuHaoCoBan,
                ThongTinThoDungMayIn = x.ThongTinThoDungMayIn,
                GhiChu = x.GhiChu,
                ThuTu = (int)x.ThuTu,
                KhongDung = (bool)x.KhongDung
            }).OrderBy(x => x.ThuTu);

            return nguon.ToList() ;
        }

        public static OffsetGiaCong DocTheoId(int id)
        {
            var offsetGiaCongLogic = new OffsetGiaCongLogic();   
            //
            OffsetGiaCong toChayDTO = new OffsetGiaCong();
            try
            {
                var toChayBDO = offsetGiaCongLogic.DocTheoId(id);
                //Chuyen
                ChuyenBDOThanhDTO(toChayBDO, toChayDTO);
            }
            catch
            {
            }
            return toChayDTO;
        }
        //--Hàm Chuyển
        private static void ChuyenBDOThanhDTO(OffsetGiaCongBDO offsetGiaCongBDO, OffsetGiaCong offsetGiaCongDTO)
        {
            offsetGiaCongDTO.ID = offsetGiaCongBDO.ID;
            offsetGiaCongDTO.Ten = offsetGiaCongBDO.Ten;
            offsetGiaCongDTO.TenNhaCungCap = offsetGiaCongBDO.TenNhaCungCap;
            offsetGiaCongDTO.TenKhoIn = offsetGiaCongBDO.TenKhoIn;
            offsetGiaCongDTO.KhoInRongMax = offsetGiaCongBDO.KhoInRongMax;
            offsetGiaCongDTO.KhoInDaiMax = offsetGiaCongBDO.KhoInDaiMax;
            offsetGiaCongDTO.KhoInRongMin = offsetGiaCongBDO.KhoInRongMin;
            offsetGiaCongDTO.KhoInDaiMin = offsetGiaCongBDO.KhoInDaiMin;
            offsetGiaCongDTO.TuTroNhip = offsetGiaCongBDO.TuTroNhip;
            offsetGiaCongDTO.GiaCongIn = offsetGiaCongBDO.GiaCongIn;
            offsetGiaCongDTO.SoMatInCoBan = offsetGiaCongBDO.SoMatInCoBan;
            offsetGiaCongDTO.GiaInMoiMatVuotCoBan = offsetGiaCongBDO.GiaInMoiMatVuotCoBan;
            offsetGiaCongDTO.SoToChayBuHaoCoBan = offsetGiaCongBDO.SoToChayBuHaoCoBan;
            offsetGiaCongDTO.ThongTinThoDungMayIn = offsetGiaCongBDO.ThongTinThoDungMayIn;
            offsetGiaCongDTO.GhiChu = offsetGiaCongBDO.GhiChu;
            offsetGiaCongDTO.ThuTu = offsetGiaCongBDO.ThuTu;
            offsetGiaCongDTO.KhongDung = offsetGiaCongBDO.KhongDung;
            
        }
        private static void ChuyenDTOThanhBDO(OffsetGiaCong offsetGiaCongDTO, OffsetGiaCongBDO offsetGiaCongBDO)
        {
            offsetGiaCongBDO.ID = offsetGiaCongDTO.ID;
            offsetGiaCongBDO.Ten = offsetGiaCongDTO.Ten;
            offsetGiaCongBDO.TenNhaCungCap = offsetGiaCongDTO.TenNhaCungCap;
            offsetGiaCongBDO.TenKhoIn = offsetGiaCongDTO.TenKhoIn;
            offsetGiaCongBDO.KhoInRongMax = offsetGiaCongDTO.KhoInRongMax;
            offsetGiaCongBDO.KhoInDaiMax = offsetGiaCongDTO.KhoInDaiMax;
            offsetGiaCongBDO.KhoInRongMin = offsetGiaCongDTO.KhoInRongMin;
            offsetGiaCongBDO.KhoInDaiMin = offsetGiaCongDTO.KhoInDaiMin;
            offsetGiaCongBDO.TuTroNhip = offsetGiaCongDTO.TuTroNhip;
            offsetGiaCongBDO.GiaCongIn = offsetGiaCongDTO.GiaCongIn;
            offsetGiaCongBDO.SoMatInCoBan = offsetGiaCongDTO.SoMatInCoBan;
            offsetGiaCongBDO.GiaInMoiMatVuotCoBan = offsetGiaCongDTO.GiaInMoiMatVuotCoBan;
            offsetGiaCongBDO.SoToChayBuHaoCoBan = offsetGiaCongDTO.SoToChayBuHaoCoBan;
            offsetGiaCongBDO.ThongTinThoDungMayIn = offsetGiaCongDTO.ThongTinThoDungMayIn;
            offsetGiaCongBDO.GhiChu = offsetGiaCongDTO.GhiChu;
            offsetGiaCongBDO.ThuTu = offsetGiaCongDTO.ThuTu;
            offsetGiaCongBDO.KhongDung = offsetGiaCongDTO.KhongDung;
        }
     
    }
}
