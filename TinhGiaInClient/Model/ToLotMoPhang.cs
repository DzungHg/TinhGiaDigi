using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class ToLotMoPhang
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string DienGiai { get; set; }
        public int GiaMuaTo { get; set; }
        public int ThuTu { get; set; }
       
        //==
        #region Các hàm static
        public static List<ToLotMoPhang> DocTatCa()
        {
            var toLotMPLogic = new ToLotMoPhangLogic();
            List<ToLotMoPhang> nguon = null;
            try
            {
                nguon = toLotMPLogic.DocTatCa().Select(x => new ToLotMoPhang
                {
                    ID = x.ID,
                    Ten = x.Ten,            
                    MaNhaCungCap = x.MaNhaCungCap,
                    TenNhaCungCap = x.TenNhaCungCap,
                    DienGiai = x.DienGiai,                     
                    GiaMuaTo = x.GiaMuaTo,                    
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }

        public static ToLotMoPhang DocTheoId(int idKhuonEpKim)
        {
            var toLotMPLogic = new ToLotMoPhangLogic();
            var toLotMP = new ToLotMoPhang();
            try
            {
                var khuonEpKimBDO = toLotMPLogic.DocTheoId(idKhuonEpKim);
                //Chuyen
                ChuyenDoiNhuEpKimBDOThanhDTO(khuonEpKimBDO, toLotMP);
            }
                catch {
                }
            return toLotMP;
        }
        
        #region Thêm sửa xóa

        public static string Them(ToLotMoPhang item)
        {
            var toLotMPLogic = new ToLotMoPhangLogic();
            var itemBDO = new ToLotMoPhangBDO();
            ChuyenDoiNhuEpKimDTOThanhBDO(item, itemBDO);
            return toLotMPLogic.Them(itemBDO);
        }

        public static string Sua(ToLotMoPhang item)
        {
            var toLotLogic = new ToLotMoPhangLogic();
            var itemBDO = new ToLotMoPhangBDO();
            ChuyenDoiNhuEpKimDTOThanhBDO(item, itemBDO);
            return toLotLogic.Sua(itemBDO);
        }
        public static string Xoa(int idGiay)
        {
            var toLotMPLogic = new ToLotMoPhangLogic();
            
            return toLotMPLogic.Xoa(idGiay);
        }
        #endregion
        //Chuyển đổi
        private static void ChuyenDoiNhuEpKimBDOThanhDTO(ToLotMoPhangBDO nhuEpKimBDO, ToLotMoPhang nhuEpKim)
        {
            nhuEpKim.ID = nhuEpKimBDO.ID;            
            nhuEpKim.Ten = nhuEpKimBDO.Ten;
            nhuEpKim.DienGiai = nhuEpKimBDO.DienGiai;          
            nhuEpKim.GiaMuaTo = nhuEpKimBDO.GiaMuaTo;
            nhuEpKim.MaNhaCungCap = nhuEpKimBDO.MaNhaCungCap;
            nhuEpKim.TenNhaCungCap = nhuEpKimBDO.TenNhaCungCap;
            
            nhuEpKim.ThuTu = nhuEpKimBDO.ThuTu;
        }
        private static void ChuyenDoiNhuEpKimDTOThanhBDO(ToLotMoPhang nhuEpKim, ToLotMoPhangBDO nhuEpKimBDO)
        {
            nhuEpKimBDO.ID = nhuEpKim.ID;
            nhuEpKimBDO.Ten = nhuEpKim.Ten;
            nhuEpKimBDO.DienGiai = nhuEpKim.DienGiai;         
            nhuEpKimBDO.GiaMuaTo = nhuEpKim.GiaMuaTo;
            nhuEpKimBDO.MaNhaCungCap = nhuEpKim.MaNhaCungCap;
            nhuEpKimBDO.TenNhaCungCap = nhuEpKim.TenNhaCungCap;
            
            nhuEpKimBDO.ThuTu = nhuEpKim.ThuTu;
        }
        #endregion
    }
}
