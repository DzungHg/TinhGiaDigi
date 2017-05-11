using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class OffsetGiaCongDAO : IOffsetGiaCongDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<OffsetGiaCongBDO> DocTatCa()
        {
            List<OffsetGiaCongBDO> list = null;
            try
            {
                var nguon = db.IN_OFFSET_GIA_CONG.Select(x => new OffsetGiaCongBDO
                {
                    ID = x.ID,
                    Ten = x.ten_may_in,
                    TenNhaCungCap = x.ten_nha_cung_cap,
                    TenKhoIn = x.ten_kho_in,
                    KhoInRongMax = (int)x.kho_in_rong_max,
                    KhoInDaiMax = (int)x.kho_in_dai_max,
                    KhoInRongMin = (int)x.kho_in_rong_max,
                    KhoInDaiMin = (int)x.kho_in_dai_min,
                    TuTroNhip = (bool)x.tu_tro_nhip,
                    GiaCongIn = (int)x.gia_cong_in,
                    SoMatInCoBan = (int)x.so_mat_in_co_ban,
                    GiaInMoiMatVuotCoBan = (int)x.gia_in_moi_mat_vuot,
                    SoToChayBuHaoCoBan = (int)x.so_to_chay_bu_hao_co_ban,
                    ThongTinThoDungMayIn = x.thong_tin_nguoi_dung_may,
                    GhiChu = x.ghi_chu,
                    ThuTu = (int)x.thu_tu,
                    KhongDung = (bool)x.khong_dung
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }

        public OffsetGiaCongBDO DocTheoId(int iD)
        {
            var toChay = new OffsetGiaCongBDO();
            try
            {
                toChay = db.IN_OFFSET_GIA_CONG.Where(x => x.ID == iD).Select(x => new OffsetGiaCongBDO
                {
                    ID = x.ID,
                    Ten = x.ten_may_in,
                    TenNhaCungCap = x.ten_nha_cung_cap,
                    TenKhoIn = x.ten_kho_in,
                    KhoInRongMax = (int)x.kho_in_rong_max,
                    KhoInDaiMax = (int)x.kho_in_dai_max,
                    KhoInRongMin = (int)x.kho_in_rong_max,
                    KhoInDaiMin = (int)x.kho_in_dai_min,
                    TuTroNhip = (bool)x.tu_tro_nhip,
                    GiaCongIn = (int)x.gia_cong_in,
                    SoMatInCoBan = (int)x.so_mat_in_co_ban,
                    GiaInMoiMatVuotCoBan = (int)x.gia_in_moi_mat_vuot,
                    SoToChayBuHaoCoBan = (int)x.so_to_chay_bu_hao_co_ban,
                    ThongTinThoDungMayIn = x.thong_tin_nguoi_dung_may,
                    GhiChu = x.ghi_chu,
                    ThuTu = (int)x.thu_tu,
                    KhongDung = (bool)x.khong_dung
                }).SingleOrDefault();

            }
            catch { }
            return toChay;
        }
        public IEnumerable<string> NhaCungCapS()
        {
            var dsNguon = db.IN_OFFSET_GIA_CONG.Select(x => x.ten_nha_cung_cap).Distinct().ToList();
            return dsNguon;
        }
        public IEnumerable<OffsetGiaCongBDO> DocTheoNhaCungCap(string tenNCC)
        {
            List<OffsetGiaCongBDO> list = null;
            try
            {
                var nguon = db.IN_OFFSET_GIA_CONG.Where(x => x.ten_nha_cung_cap == tenNCC.Trim()).Select(x => new OffsetGiaCongBDO
                {
                    ID = x.ID,
                    Ten = x.ten_may_in,
                    TenNhaCungCap = x.ten_nha_cung_cap,
                    TenKhoIn = x.ten_kho_in,
                    KhoInRongMax = (int)x.kho_in_rong_max,
                    KhoInDaiMax = (int)x.kho_in_dai_max,
                    KhoInRongMin = (int)x.kho_in_rong_max,
                    KhoInDaiMin = (int)x.kho_in_dai_min,
                    TuTroNhip = (bool)x.tu_tro_nhip,
                    GiaCongIn = (int)x.gia_cong_in,
                    SoMatInCoBan = (int)x.so_mat_in_co_ban,
                    GiaInMoiMatVuotCoBan = (int)x.gia_in_moi_mat_vuot,
                    SoToChayBuHaoCoBan = (int)x.so_to_chay_bu_hao_co_ban,
                    ThongTinThoDungMayIn = x.thong_tin_nguoi_dung_may,
                    GhiChu = x.ghi_chu,
                    ThuTu = (int)x.thu_tu,
                    KhongDung = (bool)x.khong_dung
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }

        

        public void Them(OffsetGiaCongBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public void Sua(OffsetGiaCongBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public void Xoa(int iD)
        {
            throw new NotImplementedException();
        }


       
    }
}
