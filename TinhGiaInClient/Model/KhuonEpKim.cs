using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class KhuonEpKim
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string DienGiai { get; set; }
        public int GiaMua { get; set; }
        public int ThuTu { get; set; }
        public int IDEPKIM { get; set; }
        //==
        #region Các hàm static
        public static List<KhuonEpKim> DocTatCa()
        {
            var khuonEpKimLogic = new KhuonEpKimLogic();
            List<KhuonEpKim> nguon = null;
            try
            {
                nguon = khuonEpKimLogic.DocTatCa().Select(x => new KhuonEpKim
                {
                    ID = x.ID,
                    Ten = x.Ten,                  
                    DienGiai = x.DienGiai,                   
                    GiaMua = x.GiaMua,
                    IDEPKIM = x.IDEPKIM,
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }
        public static List<KhuonEpKim> DocTheoIdEpKim(int maDM)
        {
            var khuonEpKimLogic = new KhuonEpKimLogic();
            List<KhuonEpKim> nguon = null;
            try
            {
                nguon = khuonEpKimLogic.DocTheoIdEpKim(maDM).Select(x => new KhuonEpKim
                {
                   ID = x.ID,
                    Ten = x.Ten,                  
                    DienGiai = x.DienGiai,                   
                    GiaMua = x.GiaMua,
                    IDEPKIM = x.IDEPKIM,
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }
        public static KhuonEpKim DocTheoId(int idKhuonEpKim)
        {
            var khuonEpKimLogic = new KhuonEpKimLogic();
            KhuonEpKim khuonEpKim = new KhuonEpKim();
            try
            {
                var khuonEpKimBDO = khuonEpKimLogic.DocTheoId(idKhuonEpKim);
                //Chuyen
                ChuyenDoiKhuonEpKimBDOThanhDTO(khuonEpKimBDO, khuonEpKim);
            }
                catch {
                }
            return khuonEpKim;
        }
        
        #region Thêm sửa xóa

        public static string Them(KhuonEpKim item)
        {
            KhuonEpKimLogic giayLogic = new KhuonEpKimLogic();
            var itemBDO = new KhuonEpKimBDO();
            ChuyenDoiKhuonEpKimDTOThanhBDO(item, itemBDO);
            return giayLogic.Them(itemBDO);
        }

        public static string Sua(KhuonEpKim item)
        {
            KhuonEpKimLogic giayLogic = new KhuonEpKimLogic();
            var itemBDO = new KhuonEpKimBDO();
            ChuyenDoiKhuonEpKimDTOThanhBDO(item, itemBDO);
            return giayLogic.Sua(itemBDO);
        }
        public static string Xoa(int idGiay)
        {
            KhuonEpKimLogic giayLogic = new KhuonEpKimLogic();
            
            return giayLogic.Xoa(idGiay);
        }
        #endregion
        //Chuyển đổi
        private static void ChuyenDoiKhuonEpKimBDOThanhDTO(KhuonEpKimBDO giayBDO, KhuonEpKim giay)
        {
            giay.ID = giayBDO.ID;            
            giay.Ten = giayBDO.Ten;
            giay.DienGiai = giayBDO.DienGiai;          
            giay.GiaMua = giayBDO.GiaMua;
            giay.IDEPKIM = giayBDO.IDEPKIM;                        
            giay.ThuTu = giayBDO.ThuTu;
        }
        private static void ChuyenDoiKhuonEpKimDTOThanhBDO(KhuonEpKim giay, KhuonEpKimBDO giayBDO)
        {
            giayBDO.ID = giay.ID;
            giayBDO.Ten = giay.Ten;         
            giayBDO.GiaMua = giay.GiaMua;
            giayBDO.IDEPKIM = giay.IDEPKIM;                 
            giayBDO.ThuTu = giay.ThuTu;
        }
        #endregion
    }
}
