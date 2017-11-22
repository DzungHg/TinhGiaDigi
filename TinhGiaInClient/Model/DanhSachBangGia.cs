using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Presenter;
using TinhGiaInClient.Common;


namespace TinhGiaInClient.Model
{
    public static class DanhSachBangGia
    {
        public static List<BangGiaBase> DanhSachS()
        {
            var lst = new List<BangGiaBase>();
            //
            foreach(BangGiaLuyTien bg in BangGiaLuyTien.DocTatCa())
            {
                lst.Add(bg);

            }
            //Bảng giá tiếp
            foreach (BangGiaTheoBuoc bg in BangGiaTheoBuoc.DocTatCa())
            {
                lst.Add(bg);

            }
            return lst;
        }
        public static BangGiaBase DocTheoIDvaLoai(int id, string loai)
        {
            BangGiaBase bg = null;
            bg = DanhSachBangGia.DanhSachS().Where(x => x.ID == id && x.LoaiBangGia == loai).SingleOrDefault();
            return bg;
        }
        public static Dictionary<string, string> TrinhBayBangGia(int idBangGia, string loaiBangGia)
        {
            Dictionary<string, string> kq = null;
            if (idBangGia <= 0)
                return kq;


            var bangGiaChon = DanhSachBangGia.DocTheoIDvaLoai(idBangGia, loaiBangGia);
            switch (loaiBangGia)
            {
                case Global.cBangGiaLuyTien:

                    kq = HoTro.TrinhBayBangGiaLuyTien(bangGiaChon.DaySoLuong,
                        bangGiaChon.DayGia, bangGiaChon.DonViTinh);
                    break;

                case Global.cBangGiaBuoc:

                    kq = HoTro.TrinhBayBangGiaBuoc(bangGiaChon.DaySoLuong,
                        bangGiaChon.DayGia, bangGiaChon.DonViTinh);
                    break;
                case Global.cBangGiaGoi:

                    kq = HoTro.TrinhBayBangGiaGoi(bangGiaChon.DaySoLuong,
                        bangGiaChon.DayGia, bangGiaChon.DonViTinh);
                    break;
            }
            return kq;
        }
    }
}
