using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class ToInMayDigiDAO: IToChayDigiDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<ToInMayDigiBDO> LayTatCa()
        {
            List<ToInMayDigiBDO> list = null;
            try
            {
                var nguon = db.TO_IN_MAY_DIGI.Select(x => new ToInMayDigiBDO
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
                    
                    DaySoLuong = x.Day_so_luong,
                    DayLoiNhuan = x.Day_loi_nhuan,
                    DaySoLuongNiemYet = x.day_so_luong_niem_yet,
                    ThuTu = (int)x.Thu_tu,
                    KhongSuDung = (bool)x.khong_su_dung
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }

        public ToInMayDigiBDO LayTheoId(int iD)
        {
            var toChay = new ToInMayDigiBDO();
            try
            {
                toChay = db.TO_IN_MAY_DIGI.Where(x => x.ID == iD).Select(x => new ToInMayDigiBDO
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
                   
                    DaySoLuong = x.Day_so_luong,
                    DayLoiNhuan = x.Day_loi_nhuan,
                    DaySoLuongNiemYet = x.day_so_luong_niem_yet,
                    ThuTu = (int)x.Thu_tu,
                    KhongSuDung = (bool)x.khong_su_dung
                }).SingleOrDefault();
                
            }
            catch { }
        return toChay;
        }

        public bool Them(ref string thongDiep, ToInMayDigiBDO entityBDO)
        {
            var kq = true;

            try
            {
                var kqKiemTrung = KiemTraTrung(entityBDO.Ten);
                if (kqKiemTrung != "")
                {
                    thongDiep = kqKiemTrung;
                    return false;
                }
                TO_IN_MAY_DIGI entity = new TO_IN_MAY_DIGI();
                ChuyenBDOThanhDAO(entityBDO, entity);
                db.TO_IN_MAY_DIGI.Add(entity);
                db.SaveChanges();
                thongDiep = string.Format("Lưu mục tin {0} thành công", entity.ID);//trả về số Id
            }
            catch
            {
                thongDiep = string.Format("Thêm mục tin {0} không thành công!", entityBDO.ID);
            }

            return kq;
        }

        public bool Sua(ref string thongDiep, ToInMayDigiBDO entityBDO)
        {
            TO_IN_MAY_DIGI entity = db.TO_IN_MAY_DIGI.Where(x => x.ID == entityBDO.ID).SingleOrDefault();
            var kq = true;
            if (entity != null)
            {
                try
                {
                    var kqKiemTrung = KiemTraTrung(entityBDO.Ten, entityBDO.ID);
                    if (kqKiemTrung != "")
                    {
                        thongDiep = kqKiemTrung;
                        return false;
                    }
                    ChuyenBDOThanhDAO(entityBDO, entity);
                    db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    thongDiep = string.Format("Lưu mục tin {0} thành công", entity.ID);//trả về số Id
                }
                catch
                {
                    thongDiep = string.Format("Sửa mục tin {0} không thành công!", entity.ID);
                }
            }
            else
            {
                thongDiep = string.Format("Mục tin {0} không tồn tại!", entity.ID);
                return false;
            }
            return kq;
        }

        public bool Xoa(int iD)
        {
            throw new NotImplementedException();
        }
        private string KiemTraTrung(string value, int id = 0)
        {
            string kq = "";
            var entity = db.DONG_CUON.SingleOrDefault(x => x.Ten == value);
            if (entity != null && entity.ID != id)
                kq = string.Format("Tên {0} đã có rồi!", value);
            return kq;
        }
        private void ChuyenBDOThanhDAO(ToInMayDigiBDO entityBDO, TO_IN_MAY_DIGI entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.Ten = entityBDO.Ten;
            entityDAO.Rong = entityBDO.Rong;
            entityDAO.Cao = entityBDO.Cao;
            entityDAO.Vung_in_rong = entityBDO.VungInRong;
            entityDAO.Vung_in_cao = entityBDO.VungInCao;
            entityDAO.Kho_to_chay_co_the_in = entityBDO.KhoToChayCoTheIn;
            entityDAO.Toc_do = entityBDO.TocDo;
           
            entityDAO.In_tu_tro = entityBDO.InTuTro;
            entityDAO.La_in_kho_dai = entityBDO.LaInKhoDai;
            entityDAO.La_hp_indigo = entityBDO.LaHPIndigo;
            entityDAO.Click_mot_mau = entityBDO.ClickA4MotMau;
            entityDAO.Click_bon_mau = entityBDO.ClickA4BonMau;
            entityDAO.Click_sau_mau = entityBDO.ClickA4SauMau;
            entityDAO.Qui_a4 = entityBDO.QuiA4;
            entityDAO.ID_MAY_IN = entityBDO.IdMayIn;           
            entityDAO.Day_so_luong = entityBDO.DaySoLuong;
            entityDAO.Day_loi_nhuan = entityBDO.DayLoiNhuan;
            entityDAO.day_so_luong_niem_yet = entityBDO.DaySoLuongNiemYet;
            entityDAO.Thu_tu = entityBDO.ThuTu;
            entityDAO.khong_su_dung = entityBDO.KhongSuDung;
        }
    }
}
