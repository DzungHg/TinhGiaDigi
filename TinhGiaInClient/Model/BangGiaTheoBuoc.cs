using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class BangGiaTheoBuoc: BangGiaBase
    {
        //Thêm ở đây

        //==
        #region Các hàm static
        public static List<BangGiaTheoBuoc> DocTatCa()
        {
            var bangGiaLogic = new BangGiaTheoBuocLogic();
            List<BangGiaTheoBuoc> nguon = null;
            try
            {
                nguon = bangGiaLogic.LayTatCa().Where(x => x.KhongCon == false).Select(x => new BangGiaTheoBuoc
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    DienGiai = x.DienGiai,
                    DaySoLuong = x.DaySoLuong,
                    DayGia = x.DayGia,
                    LoaiBangGia = x.LoaiBangGia,
                    KhongCon = x.KhongCon,
                    DonViTinh = x.DonViTinh,
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }

        public static BangGiaTheoBuoc DocTheoId(int idBangGia)
        {
            var bangGiaLogic = new BangGiaTheoBuocLogic();
            BangGiaTheoBuoc bGiaInNhanh = new BangGiaTheoBuoc();
            try
            {
                var giayBDO = bangGiaLogic.DocTheoId(idBangGia);
                //Chuyen
                ChuyenDoiBDOThanhDTO(giayBDO, bGiaInNhanh);
            }
            catch
            {
            }
            return bGiaInNhanh;
        }
        #region them sua xoa
        public static string Them(BangGiaTheoBuoc bangGia)
        {
            var bangGiaLogic = new BangGiaTheoBuocLogic();
            var itemBDO = new BangGiaTheoBuocBDO();
            ChuyenDoDTOThanhBDO(bangGia, itemBDO);
            return bangGiaLogic.Them(itemBDO);
        }
        public static string Sua(BangGiaTheoBuoc bangGia)
        {
            var bangGiaLogic = new BangGiaTheoBuocLogic();
            var itemBDO = new BangGiaTheoBuocBDO();
            ChuyenDoDTOThanhBDO(bangGia, itemBDO);
            return bangGiaLogic.Sua(itemBDO);
        }
        #endregion
        //Chuyển đổi
        private static void ChuyenDoiBDOThanhDTO(BangGiaTheoBuocBDO bangGiaBDO, BangGiaTheoBuoc bangGia)
        {
            bangGia.ID = bangGiaBDO.ID;
            bangGia.Ten = bangGiaBDO.Ten;
            bangGia.DienGiai = bangGiaBDO.DienGiai;
            bangGia.LoaiBangGia = bangGiaBDO.LoaiBangGia;
            bangGia.DaySoLuong = bangGiaBDO.DaySoLuong;
            bangGia.DayGia = bangGiaBDO.DayGia;
            bangGia.DonViTinh = bangGiaBDO.DonViTinh;
            bangGia.KhongCon = bangGiaBDO.KhongCon;
            bangGia.ThuTu = bangGiaBDO.ThuTu;
           
        }
        private static void ChuyenDoDTOThanhBDO(BangGiaTheoBuoc bangGia, BangGiaTheoBuocBDO bangGiaBDO)
        {
            bangGiaBDO.ID = bangGia.ID;
            bangGiaBDO.Ten = bangGia.Ten;
            bangGiaBDO.DienGiai = bangGia.DienGiai;
            bangGiaBDO.LoaiBangGia = bangGia.LoaiBangGia;
            bangGiaBDO.DaySoLuong = bangGia.DaySoLuong;
            bangGiaBDO.DayGia = bangGia.DayGia;
            bangGiaBDO.DonViTinh = bangGia.DonViTinh;
            bangGiaBDO.KhongCon = bangGia.KhongCon;
            bangGiaBDO.ThuTu = bangGia.ThuTu;
            
        }
        #endregion

    }
}
