using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class ToBoiBiaCung
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public float DoDayCm { get; set; }
        public int GiaMuaTo { get; set; }
        public int ThuTu { get; set; }
       
        //==
        #region Các hàm static
        public static List<ToBoiBiaCung> DocTatCa()
        {
            var toBoiLogic = new ToBoiBiaCungLogic();
            List<ToBoiBiaCung> nguon = null;
            try
            {
                nguon = toBoiLogic.DocTatCa().Select(x => new ToBoiBiaCung
                {
                    ID = x.ID,
                    Ten = x.Ten,            
                    DoDayCm = (float) x.DoDayCm,                   
                    GiaMuaTo = x.GiaMuaTo,                    
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }

        public static ToBoiBiaCung DocTheoId(int idKhuonEpKim)
        {
            var toBoiBCLogic = new ToBoiBiaCungLogic();
            var toBoiBC = new ToBoiBiaCung();
            try
            {
                var khuonEpKimBDO = toBoiBCLogic.DocTheoId(idKhuonEpKim);
                //Chuyen
                ChuyenDoiBDOThanhDTO(khuonEpKimBDO, toBoiBC);
            }
                catch {
                }
            return toBoiBC;
        }
        
        #region Thêm sửa xóa

        public static string Them(ToBoiBiaCung item)
        {
            var toLotMPLogic = new ToBoiBiaCungLogic();
            var itemBDO = new ToBoiBiaCungBDO();
            ChuyenDoiItemDTOThanhBDO(item, itemBDO);
            return toLotMPLogic.Them(itemBDO);
        }

        public static string Sua(ToBoiBiaCung item)
        {
            var toLotLogic = new ToBoiBiaCungLogic();
            var itemBDO = new ToBoiBiaCungBDO();
            ChuyenDoiItemDTOThanhBDO(item, itemBDO);
            return toLotLogic.Sua(itemBDO);
        }
        public static string Xoa(int idGiay)
        {
            var toLotMPLogic = new ToLotMoPhangLogic();
            
            return toLotMPLogic.Xoa(idGiay);
        }
        #endregion
        //Chuyển đổi
        private static void ChuyenDoiBDOThanhDTO(ToBoiBiaCungBDO toBoiBiaCungBDO, ToBoiBiaCung toBoiBiaCung)
        {
            toBoiBiaCung.ID = toBoiBiaCungBDO.ID;            
            toBoiBiaCung.Ten = toBoiBiaCungBDO.Ten;
            toBoiBiaCung.DoDayCm = toBoiBiaCungBDO.DoDayCm;          
            toBoiBiaCung.GiaMuaTo = toBoiBiaCungBDO.GiaMuaTo;            
            toBoiBiaCung.ThuTu = toBoiBiaCungBDO.ThuTu;
        }
        private static void ChuyenDoiItemDTOThanhBDO(ToBoiBiaCung toBoiBiaCung, ToBoiBiaCungBDO toBoiBiaCungBDO)
        {
            toBoiBiaCungBDO.ID = toBoiBiaCung.ID;
            toBoiBiaCungBDO.Ten = toBoiBiaCung.Ten;
            toBoiBiaCungBDO.DoDayCm = toBoiBiaCung.DoDayCm;         
            toBoiBiaCungBDO.GiaMuaTo = toBoiBiaCung.GiaMuaTo;            
            toBoiBiaCungBDO.ThuTu = toBoiBiaCung.ThuTu;
        }
        #endregion
    }
}
