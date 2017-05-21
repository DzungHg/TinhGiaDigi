using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class KhoSanPham
    {
        //Class
        public int ID { get; set; }
        public string Ten { get; set; }
        public float KhoCatRong { get; set; }
        public float KhoCatCao { get; set; }
        public string DienGiai { get; set; }
        public int ThuTu { get; set; }  
   //Hàm static
        public static List<KhoSanPham> DocTatCa()
        {
            //Sắp xếp theo thứ tự
            var khoSanPhamLogic = new KhoSanPhamLogic();
            List<KhoSanPham> nguon = null;
            try
            {
                nguon = khoSanPhamLogic.LayTatCa().Select(x => new KhoSanPham
                    {
                        ID = x.ID,
                        Ten = x.Ten,
                        KhoCatCao = (float)x.KhoCatCao,
                        KhoCatRong = (float)x.KhoCatRong,
                        DienGiai = x.DienGiai,
                        ThuTu = (int)x.ThuTu
                    }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }
        public static KhoSanPham DocTheoId(int iD)
        {
            var khoSanPhamLogic = new KhoSanPhamLogic();
            KhoSanPhamBDO khoSP_BDO = null;
            KhoSanPham khoSP_DTO = null;
            try
            {
                khoSP_BDO = khoSanPhamLogic.LayTheoId(iD);
                if (khoSP_BDO != null)
                {
                    khoSP_DTO = new KhoSanPham();
                    //Chuyển đổi
                    KhoSanPham.ChuyenBDOThanhDTO(khoSP_BDO, khoSP_DTO);
                }
                
            }
            catch {}
            return khoSP_DTO;
        }
        #region them, sua
        public static string Them(KhoSanPham item)
        {
            var khoSanPhamLogic = new KhoSanPhamLogic();
            var itemBDO = new KhoSanPhamBDO();
            ChuyenDTOThanhBDO(item, itemBDO);
            return khoSanPhamLogic.Them(itemBDO);
        }

        public static string Sua(KhoSanPham item)
        {
            var khoSanPhamLogic = new KhoSanPhamLogic();
            var itemBDO = new KhoSanPhamBDO();
            ChuyenDTOThanhBDO(item, itemBDO);
            return khoSanPhamLogic.Sua(itemBDO);
        }
        #endregion

        //--Hàm Chuyển
        public static void ChuyenBDOThanhDTO(KhoSanPhamBDO khoSP_BDO, KhoSanPham khoSP_DTO )
        {
            khoSP_DTO.ID = khoSP_BDO.ID;
            khoSP_DTO.Ten = khoSP_BDO.Ten;
            khoSP_DTO.KhoCatRong = khoSP_BDO.KhoCatRong;
            khoSP_DTO.KhoCatCao = khoSP_BDO.KhoCatCao;
            khoSP_DTO.DienGiai = khoSP_BDO.DienGiai;
            khoSP_DTO.ThuTu = khoSP_BDO.ThuTu;
        }
        public static void ChuyenDTOThanhBDO(KhoSanPham khoSP_DTO, KhoSanPhamBDO khoSP_BDO)
        {
            khoSP_BDO.ID = khoSP_DTO.ID;
            khoSP_BDO.Ten = khoSP_DTO.Ten;
            khoSP_BDO.KhoCatRong = khoSP_DTO.KhoCatRong;
            khoSP_BDO.KhoCatCao = khoSP_DTO.KhoCatCao;
            khoSP_BDO.DienGiai = khoSP_DTO.DienGiai;
            khoSP_BDO.ThuTu = khoSP_DTO.ThuTu;
        }
        
    }
}
