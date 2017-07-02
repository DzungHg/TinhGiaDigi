using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class TuyChonDanhThiep
    {
        public int ID { get; set; }
        public string Ten { get; set; }
       
        public int ThuTu { get; set; }
       
        //==
        #region Các hàm static
        public static List<TuyChonDanhThiep> DocTatCa()
        {
            var tuyChonDanhThiepLogic = new TuyChonDanhThiepLogic();
            List<TuyChonDanhThiep> nguon = null;
            try
            {
                nguon = tuyChonDanhThiepLogic.DocTatCa().Select(x => new TuyChonDanhThiep
                {
                    ID = x.ID,
                    Ten = x.Ten,            
                                
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }

        public static TuyChonDanhThiep DocTheoId(int idKhuonEpKim)
        {
            var tuyChonDThiepLogic = new TuyChonDanhThiepLogic();
            var tuyChonDThiep = new TuyChonDanhThiep();
            try
            {
                var tuyChonDThiepBDO = tuyChonDThiepLogic.DocTheoId(idKhuonEpKim);
                //Chuyen
                ChuyenDoiBDOThanhDTO(tuyChonDThiepBDO, tuyChonDThiep);
            }
                catch {
                }
            return tuyChonDThiep;
        }
        
        #region Thêm sửa xóa

        public static string Them(TuyChonDanhThiep item)
        {
            var tuyChonDThiepLogic = new TuyChonDanhThiepLogic();
            var itemBDO = new TuyChonDanhThiepBDO();
            ChuyenDoiItemDTOThanhBDO(item, itemBDO);
            return tuyChonDThiepLogic.Them(itemBDO);
        }

        public static string Sua(TuyChonDanhThiep item)
        {
            var tuyChonDThiepLogic = new TuyChonDanhThiepLogic();
            var itemBDO = new TuyChonDanhThiepBDO();
            ChuyenDoiItemDTOThanhBDO(item, itemBDO);
            return tuyChonDThiepLogic.Sua(itemBDO);
        }
        public static string Xoa(int idGiay)
        {
            var tuyChonDThiepLogic = new TuyChonDanhThiepLogic();
            
            return tuyChonDThiepLogic.Xoa(idGiay);
        }
        #endregion
        //Chuyển đổi
        private static void ChuyenDoiBDOThanhDTO(TuyChonDanhThiepBDO tuyChonDThiepBDO, TuyChonDanhThiep tuyChonDThiep)
        {
            tuyChonDThiep.ID = tuyChonDThiepBDO.ID;            
            tuyChonDThiep.Ten = tuyChonDThiepBDO.Ten;            
            tuyChonDThiep.ThuTu = tuyChonDThiepBDO.ThuTu;
        }
        private static void ChuyenDoiItemDTOThanhBDO(TuyChonDanhThiep tuyChonDThiep, TuyChonDanhThiepBDO tuyChonDThiepBDO)
        {
            tuyChonDThiepBDO.ID = tuyChonDThiep.ID;
            tuyChonDThiepBDO.Ten = tuyChonDThiep.Ten;
                   
            tuyChonDThiepBDO.ThuTu = tuyChonDThiep.ThuTu;
        }
        #endregion
    }
}
