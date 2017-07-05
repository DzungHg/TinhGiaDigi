using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class GiaTuyChonTheNhua
    {
        public int IdBangGiaTheNhua { get; set; }
        public int IdTuyChonTheNhua { get; set; }
        public string TenBangGia { get; set; }//chỉ lấy tham chiếu
        public string TenTuyChon { get; set; }//chỉ lấy tham chiếu
        public int GiaBan { get; set; }
        //Static

        
        public static List<GiaTuyChonTheNhua> DocTatCa()
        {
            List<GiaTuyChonTheNhua> lst = null;
            GiaTuyChonTheNhuaLogic giaTuyChonTheNhuaLogic = new GiaTuyChonTheNhuaLogic();
            try
            {
                 lst = giaTuyChonTheNhuaLogic.DocTatCa().Select(x => new GiaTuyChonTheNhua
                {
                    IdBangGiaTheNhua = x.IdBangGiaTheNhua,
                    IdTuyChonTheNhua = x.IdTuyChonTheNhua,
                    TenBangGia = x.TenBangGia,
                    TenTuyChon = x.TenTuyChon,
                    GiaBan = x.GiaBan
                }).ToList();
                
            }
            catch { }
            return lst;
        }
        public static GiaTuyChonTheNhua DocTheoId(int IdBangGia, int idIdTuyChon)
        {
            GiaTuyChonTheNhua item = null;
            GiaTuyChonTheNhuaLogic markUpLNGLogic = new GiaTuyChonTheNhuaLogic();
            try
            {
                item = new GiaTuyChonTheNhua();
                var itemBDO = markUpLNGLogic.DocTheoId(IdBangGia, idIdTuyChon);
                ChuyenDoiGiayBDOThanhDTO(itemBDO, item);

            }
            catch { }
            return item;
        }
        public static List<GiaTuyChonTheNhua> DocTheoIdBangGia(int iD)
        {
            List<GiaTuyChonTheNhua> lst = null;
            GiaTuyChonTheNhuaLogic giaTuyChonTheNhuaLogic = new GiaTuyChonTheNhuaLogic();
            try
            {
                lst = giaTuyChonTheNhuaLogic.DocTheoIdBangGia(iD).Select(x => new GiaTuyChonTheNhua
                {
                    IdBangGiaTheNhua = x.IdBangGiaTheNhua,
                    IdTuyChonTheNhua = x.IdTuyChonTheNhua,                    
                    TenTuyChon = x.TenTuyChon,
                    GiaBan = x.GiaBan
                }).ToList();

            }
            catch { }
            return lst;
        }
        public static List<GiaTuyChonTheNhua> DocTheoIdTuyChon(int iD)
        {
            List<GiaTuyChonTheNhua> lst = null;
            GiaTuyChonTheNhuaLogic giaTuyChonTheNhuaLogic = new GiaTuyChonTheNhuaLogic();
            try
            {
                lst = giaTuyChonTheNhuaLogic.DocTheoIdTuyChon(iD).Select(x => new GiaTuyChonTheNhua
                {
                    IdBangGiaTheNhua = x.IdBangGiaTheNhua,
                    IdTuyChonTheNhua = x.IdTuyChonTheNhua,                   
                    TenTuyChon = x.TenTuyChon,
                    GiaBan = x.GiaBan
                }).ToList();

            }
            catch { }
            return lst;
        }
        #region THêm, sửa xóa
        public static string Them(GiaTuyChonTheNhua item)
        {
            GiaTuyChonTheNhuaLogic giaTuyChonTheNhuaLogic = new GiaTuyChonTheNhuaLogic();
            var itemBDO = new GiaTuyChonTheNhuaBDO();
            ChuyenDoiGiayDTOThanhBDO(item, itemBDO);
            return giaTuyChonTheNhuaLogic.Them(itemBDO);
        }

        public static string Sua(GiaTuyChonTheNhua item)
        {
            GiaTuyChonTheNhuaLogic giaTuyChonTheNhuaLogic = new GiaTuyChonTheNhuaLogic();
            var itemBDO = new GiaTuyChonTheNhuaBDO();
            ChuyenDoiGiayDTOThanhBDO(item, itemBDO);
            return giaTuyChonTheNhuaLogic.Sua(itemBDO);
        }

        #endregion
        //Chuyển đổi
        private static void ChuyenDoiGiayBDOThanhDTO(GiaTuyChonTheNhuaBDO giaTuyChonBDO, GiaTuyChonTheNhua giaTuyChonDTO)
        {
            giaTuyChonDTO.IdBangGiaTheNhua = giaTuyChonBDO.IdBangGiaTheNhua;
            giaTuyChonDTO.IdTuyChonTheNhua = giaTuyChonBDO.IdTuyChonTheNhua;
            giaTuyChonDTO.TenTuyChon = giaTuyChonBDO.TenTuyChon;
            giaTuyChonDTO.TenBangGia = giaTuyChonBDO.TenBangGia;
            giaTuyChonDTO.GiaBan = giaTuyChonBDO.GiaBan;
        }
        private static void ChuyenDoiGiayDTOThanhBDO(GiaTuyChonTheNhua giaTuyChonDTO, GiaTuyChonTheNhuaBDO giaTuyChonBDO)
        {
            giaTuyChonBDO.IdBangGiaTheNhua = giaTuyChonDTO.IdBangGiaTheNhua;
            giaTuyChonBDO.IdTuyChonTheNhua = giaTuyChonDTO.IdTuyChonTheNhua;
            giaTuyChonBDO.GiaBan = giaTuyChonDTO.GiaBan;
        }
    }
}
