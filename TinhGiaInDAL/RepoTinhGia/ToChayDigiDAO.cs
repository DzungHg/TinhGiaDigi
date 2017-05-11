using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class ToChayDigiDAO: IToChayDigiDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<ToChayDigiBDO> LayTatCa()
        {
            List<ToChayDigiBDO> list = null;
            try
            {
                var nguon = db.TO_IN_MAY_DIGI.Select(x => new ToChayDigiBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    Rong = (float)x.Rong,
                    Cao = (float)x.Cao,
                    VungInRong = (float)x.Vung_in_rong,
                    VungInCao = (float)x.Vung_in_cao,
                    KhoToChayCoTheIn = x.Kho_to_chay_co_the_in,
                    TocDo = (int)x.Toc_do,
                    InTuTro = (bool)x.In_tu_tro,
                    LaInKhoDai = (bool)x.La_in_kho_dai,
                    LaHPIndigo = (bool)x.La_hp_indigo,
                    ClickA4MotMau = (int)x.MAY_IN_DIGI.Click_A4_1M,
                    ClickA4BonMau = (int)x.MAY_IN_DIGI.Click_A4_4M,
                    ClickA4SauMau = (int)x.MAY_IN_DIGI.Click_A4_6M,
                    QuiA4 = (int)x.Qui_a4,
                    IdMayIn = (int)x.ID_MAY_IN,
                    BHR = (int)x.MAY_IN_DIGI.BHR,
                    ThoiGianSanSang = (float)x.MAY_IN_DIGI.Thoi_gian_san_sang,
                    PhiPhePhamSanSang = (int)x.MAY_IN_DIGI.Phi_phe_pham_san_sang,
                    ThoiGianDuLieuBienDoi = (float)x.MAY_IN_DIGI.Thoi_gian_du_lieu_bien_doi,
                    DaySoLuong = x.Day_so_luong,
                    DayLoiNhuan = x.Day_loi_nhuan,
                    ThuTu = (int)x.Thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }

        public ToChayDigiBDO LayTheoId(int iD)
        {
            var toChay = new ToChayDigiBDO();
            try
            {
                toChay = db.TO_IN_MAY_DIGI.Where(x => x.ID == iD).Select(x => new ToChayDigiBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    Rong = (float)x.Rong,
                    Cao = (float)x.Cao,
                    VungInRong = (float)x.Vung_in_rong,
                    VungInCao = (float)x.Vung_in_cao,
                    KhoToChayCoTheIn = x.Kho_to_chay_co_the_in,
                    TocDo = (int)x.Toc_do,
                    InTuTro = (bool)x.In_tu_tro,
                    LaInKhoDai = (bool)x.La_in_kho_dai,
                    LaHPIndigo = (bool)x.La_hp_indigo,
                    ClickA4MotMau = (int)x.MAY_IN_DIGI.Click_A4_1M,
                    ClickA4BonMau = (int)x.MAY_IN_DIGI.Click_A4_4M,
                    ClickA4SauMau = (int)x.MAY_IN_DIGI.Click_A4_6M,
                    QuiA4 = (int)x.Qui_a4,
                    IdMayIn = (int)x.ID_MAY_IN,
                    BHR = (int)x.MAY_IN_DIGI.BHR,
                    ThoiGianSanSang = (float)x.MAY_IN_DIGI.Thoi_gian_san_sang,
                    PhiPhePhamSanSang = (int)x.MAY_IN_DIGI.Phi_phe_pham_san_sang,
                    ThoiGianDuLieuBienDoi = (float)x.MAY_IN_DIGI.Thoi_gian_du_lieu_bien_doi,
                    DaySoLuong = x.Day_so_luong,
                    DayLoiNhuan = x.Day_loi_nhuan,
                    ThuTu = (int)x.Thu_tu
                }).SingleOrDefault();
                
            }
            catch { }
        return toChay;
        }

        public void Them(ToChayDigiBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public void Sua(ToChayDigiBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public void Xoa(int iD)
        {
            throw new NotImplementedException();
        }
    }
}
