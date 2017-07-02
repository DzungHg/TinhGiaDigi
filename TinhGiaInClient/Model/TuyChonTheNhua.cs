using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class TuyChonTheNhua
    {
        public int ID { get; set; }
        public string Ten { get; set; }
       
        public int ThuTu { get; set; }
       
        //==
        #region Các hàm static
        public static List<TuyChonTheNhua> DocTatCa()
        {
            var tuyChonTheNhuaLogic = new TuyChonTheNhuaLogic();
            List<TuyChonTheNhua> nguon = null;
            try
            {
                nguon = tuyChonTheNhuaLogic.DocTatCa().Select(x => new TuyChonTheNhua
                {
                    ID = x.ID,
                    Ten = x.Ten,            
                                
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }

        public static TuyChonTheNhua DocTheoId(int idKhuonEpKim)
        {
            var tuyChonThNhuaLogic = new TuyChonTheNhuaLogic();
            var tuyChonThNhua = new TuyChonTheNhua();
            try
            {
                var tuyChonThNhuaBDO = tuyChonThNhuaLogic.DocTheoId(idKhuonEpKim);
                //Chuyen
                ChuyenDoiBDOThanhDTO(tuyChonThNhuaBDO, tuyChonThNhua);
            }
                catch {
                }
            return tuyChonThNhua;
        }
        
        #region Thêm sửa xóa

        public static string Them(TuyChonTheNhua item)
        {
            var tuyChonThNhuaLogic = new TuyChonTheNhuaLogic();
            var itemBDO = new TuyChonTheNhuaBDO();
            ChuyenDoiItemDTOThanhBDO(item, itemBDO);
            return tuyChonThNhuaLogic.Them(itemBDO);
        }

        public static string Sua(TuyChonTheNhua item)
        {
            var tuyChonThNhuaLogic = new TuyChonTheNhuaLogic();
            var itemBDO = new TuyChonTheNhuaBDO();
            ChuyenDoiItemDTOThanhBDO(item, itemBDO);
            return tuyChonThNhuaLogic.Sua(itemBDO);
        }
        public static string Xoa(int idGiay)
        {
            var tuyChonThNhuaLogic = new TuyChonTheNhuaLogic();
            
            return tuyChonThNhuaLogic.Xoa(idGiay);
        }
        #endregion
        //Chuyển đổi
        private static void ChuyenDoiBDOThanhDTO(TuyChonTheNhuaBDO tuyChonThNhuaBDO, TuyChonTheNhua tuyChonThNhua)
        {
            tuyChonThNhua.ID = tuyChonThNhuaBDO.ID;            
            tuyChonThNhua.Ten = tuyChonThNhuaBDO.Ten;            
            tuyChonThNhua.ThuTu = tuyChonThNhuaBDO.ThuTu;
        }
        private static void ChuyenDoiItemDTOThanhBDO(TuyChonTheNhua tuyChonThNhua, TuyChonTheNhuaBDO tuyChonThNhuaBDO)
        {
            tuyChonThNhuaBDO.ID = tuyChonThNhua.ID;
            tuyChonThNhuaBDO.Ten = tuyChonThNhua.Ten;
                   
            tuyChonThNhuaBDO.ThuTu = tuyChonThNhua.ThuTu;
        }
        #endregion
    }
}
