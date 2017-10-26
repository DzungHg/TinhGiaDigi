using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class KhuonBe
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string DienGiai { get; set; }
        public int GiaMua { get; set; }
        public int SoLanBeToiDa { get; set; }
        public int ThuTu { get; set; }
        public int IDMAYBE { get; set; }
        //==
        #region Các hàm static
        public static List<KhuonBe> DocTatCa()
        {
            var khuonBeLogic = new KhuonBeLogic();
            List<KhuonBe> nguon = null;
            try
            {
                nguon = khuonBeLogic.DocTatCa().Select(x => new KhuonBe
                {
                    ID = x.ID,
                    Ten = x.Ten,                  
                    DienGiai = x.DienGiai,                   
                    GiaMua = x.GiaMua,
                    SoLanBeToiDa = x.SoLanBeToiDa,
                    IDMAYBE = x.IDMAYBE,
                    
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }
        public static List<KhuonBe> DocTheoIdEpKim(int maDM)
        {
            var khuonbeLogic = new KhuonBeLogic();
            List<KhuonBe> nguon = null;
            try
            {
                nguon = khuonbeLogic.DocTheoIdEpKim(maDM).Select(x => new KhuonBe
                {
                   ID = x.ID,
                    Ten = x.Ten,                  
                    DienGiai = x.DienGiai,                   
                    GiaMua = x.GiaMua,
                   SoLanBeToiDa = x.SoLanBeToiDa,
                    IDMAYBE = x.IDMAYBE,
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }
        public static KhuonBe DocTheoId(int idKhuonBe)
        {
            var khuonEpKimLogic = new KhuonBeLogic();
            KhuonBe khuonEpKim = new KhuonBe();
            try
            {
                var khuonEpKimBDO = khuonEpKimLogic.DocTheoId(idKhuonBe);
                //Chuyen
                ChuyenDoiKhuonEpKimBDOThanhDTO(khuonEpKimBDO, khuonEpKim);
            }
                catch {
                }
            return khuonEpKim;
        }
        
        #region Thêm sửa xóa

        public static string Them(KhuonBe item)
        {
            KhuonBeLogic khuonBeLogic = new KhuonBeLogic();
            var itemBDO = new KhuonBeBDO();
            ChuyenDoiKhuonEpKimDTOThanhBDO(item, itemBDO);
            return khuonBeLogic.Them(itemBDO);
        }

        public static string Sua(KhuonBe item)
        {
            KhuonBeLogic giayLogic = new KhuonBeLogic();
            var itemBDO = new KhuonBeBDO();
            ChuyenDoiKhuonEpKimDTOThanhBDO(item, itemBDO);
            return giayLogic.Sua(itemBDO);
        }
        public static string Xoa(int idGiay)
        {
            KhuonBeLogic giayLogic = new KhuonBeLogic();
            
            return giayLogic.Xoa(idGiay);
        }
        #endregion
        //Chuyển đổi
        private static void ChuyenDoiKhuonEpKimBDOThanhDTO(KhuonBeBDO khuonBeBDO, KhuonBe khuonBe)
        {
            khuonBe.ID = khuonBeBDO.ID;            
            khuonBe.Ten = khuonBeBDO.Ten;
            khuonBe.DienGiai = khuonBeBDO.DienGiai;          
            khuonBe.GiaMua = khuonBeBDO.GiaMua;
            khuonBe.SoLanBeToiDa = khuonBeBDO.SoLanBeToiDa;
            khuonBe.IDMAYBE = khuonBeBDO.IDMAYBE;                        
            khuonBe.ThuTu = khuonBeBDO.ThuTu;
        }
        private static void ChuyenDoiKhuonEpKimDTOThanhBDO(KhuonBe khuonBe, KhuonBeBDO khuonBeBDO)
        {
            khuonBeBDO.ID = khuonBe.ID;
            khuonBeBDO.Ten = khuonBe.Ten;         
            khuonBeBDO.GiaMua = khuonBe.GiaMua;
            khuonBeBDO.SoLanBeToiDa = khuonBe.SoLanBeToiDa;
            khuonBeBDO.IDMAYBE = khuonBe.IDMAYBE;                 
            khuonBeBDO.ThuTu = khuonBe.ThuTu;
        }
        #endregion
    }
}
