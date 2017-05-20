using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class DanhMucGiay
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string NhaCungCap { get; set; }
        public int ThuTu { get; set; }

        public static List<DanhMucGiay>LayTatCa()
        {
            var dmGiayLogic = new DanhMucGiayLogic();
            var nguon = dmGiayLogic.LayTatCa().Select(x => new DanhMucGiay
            {
                ID = x.ID,
                Ten = x.Ten,
                NhaCungCap = x.NhaCungCap,
                ThuTu = (int)x.ThuTu
            }).OrderBy(x => x.ThuTu).ToList();

            return nguon;
        }
        public static DanhMucGiay DocTheoId(int idDanhMucGiay)
        {
            var dMucGiayLogic = new DanhMucGiayLogic();
            DanhMucGiay dMucGiay = new DanhMucGiay();
            try
            {
                var dMucGiayBDO = dMucGiayLogic.LayTheoId(idDanhMucGiay);
                //Chuyen
                ChuyenDoiDMGiayBDOThanhDTO(dMucGiayBDO, dMucGiay);
            }
            catch
            {
            }
            return dMucGiay;
        }
        public static List<DanhMucGiay> LayTheoNhaCungCap(string nhaCC)
        {
            var dmGiayLogic = new DanhMucGiayLogic();
            var nguon = dmGiayLogic.LayTheoNhaCungCap(nhaCC).Select(x => new DanhMucGiay
            {
                ID = x.ID,
                Ten = x.Ten,
                NhaCungCap = x.NhaCungCap,
                ThuTu = (int)x.ThuTu
            }).OrderBy(x => x.ThuTu).ToList();

            return nguon;
        }
        #region thêm sửa xóa
          public static string Them(DanhMucGiay item)
        {
            DanhMucGiayLogic dMucGiayLogic = new DanhMucGiayLogic();
            var itemBDO = new DanhMucGiayBDO();
            ChuyenDoiDMGiayDTOThanhBDO(item, itemBDO);
            return dMucGiayLogic.Them(itemBDO);
        }

          public static string Sua(DanhMucGiay item)
        {
            DanhMucGiayLogic dMucGiayLogic = new DanhMucGiayLogic();
            var itemBDO = new DanhMucGiayBDO();
            ChuyenDoiDMGiayDTOThanhBDO(item, itemBDO);
            return dMucGiayLogic.Sua(itemBDO);
            
        }
        public static string Xoa(int idDanhMucGiay)
        {
            DanhMucGiayLogic dMucGiayLogic = new DanhMucGiayLogic();
            
            return dMucGiayLogic.Xoa(idDanhMucGiay);
        }

        #endregion
        //Chuyển đổi
        private static void ChuyenDoiDMGiayBDOThanhDTO(DanhMucGiayBDO dMucGiayBDO, DanhMucGiay dMucGiayDTO)
        {
            dMucGiayDTO.ID = dMucGiayBDO.ID;
            dMucGiayDTO.Ten = dMucGiayBDO.Ten;
            dMucGiayDTO.NhaCungCap = dMucGiayBDO.NhaCungCap;
            dMucGiayDTO.ThuTu = dMucGiayBDO.ThuTu;
        }
         private static void ChuyenDoiDMGiayDTOThanhBDO(DanhMucGiay dMucGiayDTO, DanhMucGiayBDO dMucGiayBDO)
        {
            dMucGiayBDO.ID = dMucGiayDTO.ID;
            dMucGiayBDO.Ten = dMucGiayDTO.Ten;            
            dMucGiayBDO.NhaCungCap = dMucGiayDTO.NhaCungCap;            
            dMucGiayBDO.ThuTu = dMucGiayDTO.ThuTu;
        }
        
    }
   
}
