using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class NhuEpKim
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string DienGiai { get; set; }
        public int GiaMuaCm2 { get; set; }
        public int ThuTu { get; set; }
        public int IDEPKIM { get; set; }
        //==
        #region Các hàm static
        public static List<NhuEpKim> DocTatCa()
        {
            var nhuEpKimLogic = new NhuEpKimLogic();
            List<NhuEpKim> nguon = null;
            try
            {
                nguon = nhuEpKimLogic.DocTatCa().Select(x => new NhuEpKim
                {
                    ID = x.ID,
                    Ten = x.Ten,            
                    MaNhaCungCap = x.MaNhaCungCap,
                    TenNhaCungCap = x.TenNhaCungCap,
                    DienGiai = x.DienGiai,                     
                    GiaMuaCm2 = x.GiaMuaCm2,
                    IDEPKIM = x.IDEPKIM,
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }
        public static List<NhuEpKim> DocTheoIdEpKim(int maDM)
        {
            var khuonEpKimLogic = new NhuEpKimLogic();
            List<NhuEpKim> nguon = null;
            try
            {
                nguon = khuonEpKimLogic.DocTheoIdEpKim(maDM).Select(x => new NhuEpKim
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    MaNhaCungCap = x.MaNhaCungCap,
                    TenNhaCungCap = x.TenNhaCungCap,
                    DienGiai = x.DienGiai,
                    GiaMuaCm2 = x.GiaMuaCm2,
                    IDEPKIM = x.IDEPKIM,
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }
        public static NhuEpKim DocTheoId(int idKhuonEpKim)
        {
            var khuonEpKimLogic = new NhuEpKimLogic();
            var khuonEpKim = new NhuEpKim();
            try
            {
                var khuonEpKimBDO = khuonEpKimLogic.DocTheoId(idKhuonEpKim);
                //Chuyen
                ChuyenDoiNhuEpKimBDOThanhDTO(khuonEpKimBDO, khuonEpKim);
            }
                catch {
                }
            return khuonEpKim;
        }
        
        #region Thêm sửa xóa

        public static string Them(NhuEpKim item)
        {
            var giayLogic = new NhuEpKimLogic();
            var itemBDO = new NhuEpKimBDO();
            ChuyenDoiNhuEpKimDTOThanhBDO(item, itemBDO);
            return giayLogic.Them(itemBDO);
        }

        public static string Sua(NhuEpKim item)
        {
            var giayLogic = new NhuEpKimLogic();
            var itemBDO = new NhuEpKimBDO();
            ChuyenDoiNhuEpKimDTOThanhBDO(item, itemBDO);
            return giayLogic.Sua(itemBDO);
        }
        public static string Xoa(int idGiay)
        {
            var giayLogic = new NhuEpKimLogic();
            
            return giayLogic.Xoa(idGiay);
        }
        #endregion
        //Chuyển đổi
        private static void ChuyenDoiNhuEpKimBDOThanhDTO(NhuEpKimBDO nhuEpKimBDO, NhuEpKim nhuEpKim)
        {
            nhuEpKim.ID = nhuEpKimBDO.ID;            
            nhuEpKim.Ten = nhuEpKimBDO.Ten;
            nhuEpKim.DienGiai = nhuEpKimBDO.DienGiai;          
            nhuEpKim.GiaMuaCm2 = nhuEpKimBDO.GiaMuaCm2;
            nhuEpKim.MaNhaCungCap = nhuEpKimBDO.MaNhaCungCap;
            nhuEpKim.TenNhaCungCap = nhuEpKimBDO.TenNhaCungCap;
            nhuEpKim.IDEPKIM = nhuEpKimBDO.IDEPKIM;                        
            nhuEpKim.ThuTu = nhuEpKimBDO.ThuTu;
        }
        private static void ChuyenDoiNhuEpKimDTOThanhBDO(NhuEpKim nhuEpKim, NhuEpKimBDO nhuEpKimBDO)
        {
            nhuEpKimBDO.ID = nhuEpKim.ID;
            nhuEpKimBDO.Ten = nhuEpKim.Ten;
            nhuEpKimBDO.DienGiai = nhuEpKim.DienGiai;         
            nhuEpKimBDO.GiaMuaCm2 = nhuEpKim.GiaMuaCm2;
            nhuEpKimBDO.MaNhaCungCap = nhuEpKim.MaNhaCungCap;
            nhuEpKimBDO.TenNhaCungCap = nhuEpKim.TenNhaCungCap;
            nhuEpKimBDO.IDEPKIM = nhuEpKim.IDEPKIM;            
            nhuEpKimBDO.ThuTu = nhuEpKim.ThuTu;
        }
        #endregion
    }
}
