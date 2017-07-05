using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class GiaTuyChonDanhThiep
    {
        public int IdBangGiaDanhThiep { get; set; }
        public int IdTuyChonDanhThiep { get; set; }
        public string TenBangGia { get; set; }//chỉ lấy tham chiếu
        public string TenTuyChon { get; set; }//chỉ lấy tham chiếu
        public int GiaBan { get; set; }
        //Static

        
        public static List<GiaTuyChonDanhThiep> DocTatCa()
        {
            List<GiaTuyChonDanhThiep> lst = null;
            GiaTuyChonDanhThiepLogic giaTChonDThiepLogic = new GiaTuyChonDanhThiepLogic();
            try
            {
                 lst = giaTChonDThiepLogic.DocTatCa().Select(x => new GiaTuyChonDanhThiep
                {
                    IdBangGiaDanhThiep = x.IdBangGiaDanhThiep,
                    IdTuyChonDanhThiep = x.IdTuyChonDanhThiep,
                    TenBangGia = x.TenBangGia,
                    TenTuyChon = x.TenTuyChon,
                    GiaBan = x.GiaBan
                }).ToList();
                
            }
            catch { }
            return lst;
        }
        public static GiaTuyChonDanhThiep DocTheoId(int IdBangGiaDanhThiep, int idHangKH)
        {
            GiaTuyChonDanhThiep item = null;
            GiaTuyChonDanhThiepLogic markUpLNGLogic = new GiaTuyChonDanhThiepLogic();
            try
            {
                item = new GiaTuyChonDanhThiep();
                var itemBDO = markUpLNGLogic.DocTheoId(IdBangGiaDanhThiep, idHangKH);
                ChuyenDoiGiayBDOThanhDTO(itemBDO, item);

            }
            catch { }
            return item;
        }
        public static List<GiaTuyChonDanhThiep> DocTheoIdBangGia(int iD)
        {
            List<GiaTuyChonDanhThiep> lst = null;
            GiaTuyChonDanhThiepLogic giaTChonDThiepLogic = new GiaTuyChonDanhThiepLogic();
            try
            {
                lst = giaTChonDThiepLogic.DocTheoIdBangGia(iD).Select(x => new GiaTuyChonDanhThiep
                {
                    IdBangGiaDanhThiep = x.IdBangGiaDanhThiep,
                    IdTuyChonDanhThiep = x.IdTuyChonDanhThiep,                    
                    TenTuyChon = x.TenTuyChon,
                    GiaBan = x.GiaBan
                }).ToList();

            }
            catch { }
            return lst;
        }
        public static List<GiaTuyChonDanhThiep> DocTheoIdTuyChon(int iD)
        {
            List<GiaTuyChonDanhThiep> lst = null;
            GiaTuyChonDanhThiepLogic giaTChonDThiepLogic = new GiaTuyChonDanhThiepLogic();
            try
            {
                lst = giaTChonDThiepLogic.DocTheoIdTuyChon(iD).Select(x => new GiaTuyChonDanhThiep
                {
                    IdBangGiaDanhThiep = x.IdBangGiaDanhThiep,
                    IdTuyChonDanhThiep = x.IdTuyChonDanhThiep,
                    TenBangGia = x.TenBangGia,                   
                    GiaBan = x.GiaBan
                }).ToList();

            }
            catch { }
            return lst;
        }
        #region THêm, sửa xóa
        public static string Them(GiaTuyChonDanhThiep item)
        {
            GiaTuyChonDanhThiepLogic giaTChonDThiepLogic = new GiaTuyChonDanhThiepLogic();
            var itemBDO = new GiaTuyChonDanhThiepBDO();
            ChuyenDoiGiayDTOThanhBDO(item, itemBDO);
            return giaTChonDThiepLogic.Them(itemBDO);

        }

        public static string Sua(GiaTuyChonDanhThiep item)
        {
            GiaTuyChonDanhThiepLogic giaTChonDThiepLogic = new GiaTuyChonDanhThiepLogic();
            var itemBDO = new GiaTuyChonDanhThiepBDO();
            ChuyenDoiGiayDTOThanhBDO(item, itemBDO);
            return giaTChonDThiepLogic.Sua(itemBDO);
        }
        public static string Xoa (int idBangGia, int idTuyChon)
        {
            GiaTuyChonDanhThiepLogic giaTChonDThiepLogic = new GiaTuyChonDanhThiepLogic();
            return giaTChonDThiepLogic.Xoa(idBangGia, idTuyChon);
        }

        #endregion
        //Chuyển đổi
        private static void ChuyenDoiGiayBDOThanhDTO(GiaTuyChonDanhThiepBDO giaTuyChonBDO, GiaTuyChonDanhThiep giaTuyChonDTO)
        {
            giaTuyChonDTO.IdBangGiaDanhThiep = giaTuyChonBDO.IdBangGiaDanhThiep;
            giaTuyChonDTO.IdTuyChonDanhThiep = giaTuyChonBDO.IdTuyChonDanhThiep;
            giaTuyChonDTO.TenTuyChon = giaTuyChonBDO.TenTuyChon;
            giaTuyChonDTO.TenBangGia = giaTuyChonBDO.TenBangGia;
            giaTuyChonDTO.GiaBan = giaTuyChonBDO.GiaBan;
        }
        private static void ChuyenDoiGiayDTOThanhBDO(GiaTuyChonDanhThiep giaTuyChonDTO, GiaTuyChonDanhThiepBDO giaTuyChonBDO)
        {
            giaTuyChonBDO.IdBangGiaDanhThiep = giaTuyChonDTO.IdBangGiaDanhThiep;
            giaTuyChonBDO.IdTuyChonDanhThiep = giaTuyChonDTO.IdTuyChonDanhThiep;
            giaTuyChonBDO.GiaBan = giaTuyChonDTO.GiaBan;
        }
    }
}
