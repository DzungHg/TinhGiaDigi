using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class BangGiaDanhThiepDAO : IBangGiaDanhThiepDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<BangGiaDanhThiepBDO> DocTatCa()
        {
            List<BangGiaDanhThiepBDO> list = null;
            try
            {
                var nguon = db.BANG_GIA_DANH_THIEP.Select(x => new BangGiaDanhThiepBDO
                {
                    ID = x.ID,
                    Ten = x.ten_bang_gia,
                    MoTa = x.mo_ta,
                    DayGia = x.day_gia,
                    DaySoLuong = x.day_so_luong,
                    InHaiMat = (bool)x.in_hai_mat,
                    KhongCon = (bool)x.khong_con,
                    NoiDungBangGia = x.noi_dung_bang_gia,
                    GiayBaoGom = x.giay_bao_gom,
                    KhoToChay = x.kho_to_chay,
                    IdHangKhachHang = (int)x.ID_HANG_KHACH_HANG,
                    SoHopToiDa = (int)x.so_hop_toi_da,
                    ThuTu = (int)x.thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }
        public IEnumerable<BangGiaDanhThiepBDO> DocTheoIdHangKH(int idHangKH)
        {
            List<BangGiaDanhThiepBDO> list = null;
            try
            {
                var nguon = db.BANG_GIA_DANH_THIEP.Where(x => x.ID_HANG_KHACH_HANG == idHangKH).Select(x => new BangGiaDanhThiepBDO
                {
                    ID = x.ID,
                    Ten = x.ten_bang_gia,
                    MoTa = x.mo_ta,
                    DayGia = x.day_gia,
                    DaySoLuong = x.day_so_luong,
                    InHaiMat = (bool)x.in_hai_mat,
                    KhongCon = (bool)x.khong_con,
                    NoiDungBangGia = x.noi_dung_bang_gia,
                    GiayBaoGom = x.giay_bao_gom,
                    KhoToChay = x.kho_to_chay,
                    IdHangKhachHang = (int)x.ID_HANG_KHACH_HANG,
                    SoHopToiDa = (int)x.so_hop_toi_da,
                    ThuTu = (int)x.thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }

        public BangGiaDanhThiepBDO DocTheoId(int iD)
        {
            BangGiaDanhThiepBDO item = null;
            try
            {
                item = db.BANG_GIA_DANH_THIEP.Where(x => x.ID == iD).Select(x => new BangGiaDanhThiepBDO
                {
                    ID = x.ID,
                    Ten = x.ten_bang_gia,
                    MoTa = x.mo_ta,
                    DayGia = x.day_gia,
                    DaySoLuong = x.day_so_luong,
                    InHaiMat = (bool)x.in_hai_mat,
                    KhongCon = (bool)x.khong_con,
                    NoiDungBangGia = x.noi_dung_bang_gia,
                    GiayBaoGom = x.giay_bao_gom,
                    KhoToChay = x.kho_to_chay,
                    IdHangKhachHang = (int)x.ID_HANG_KHACH_HANG,
                    SoHopToiDa = (int)x.so_hop_toi_da,
                    ThuTu = (int)x.thu_tu
                }).SingleOrDefault();
                
            }
            catch { }

            return item;
        }

        public void Them(BangGiaDanhThiepBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public void Sua(BangGiaDanhThiepBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public void Xoa(int iD)
        {
            throw new NotImplementedException();
        }
    }
}
