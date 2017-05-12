using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class MonThanhPham
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string Ma_01 { get; set; }
        public string Ma_02 { get; set; }
        public string Ma_03 { get; set; }
        public string DonViTinh { get; set; }
        public string DaySoLuong { get; set; }
        public int ThuTu { get; set; }

        public static List<MonThanhPham> DocTatCa()
        {
            //Sắp xếp theo thứ tự
            var khoSanPhamLogic = new MonThanhPhamLogic();
            List<MonThanhPham> nguon = null;
            try
            {
                nguon = khoSanPhamLogic.DocTatCa().Select(x => new MonThanhPham
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    Ma_01 = x.Ma_01,
                    Ma_02 = x.Ma_02,
                    Ma_03 = x.Ma_03,
                    DaySoLuong = x.DaySoLuong,
                    DonViTinh = x.DonViTinh,
                    ThuTu = (int)x.ThuTu
                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }
        public static MonThanhPham DocTheoId(int iD)
        {
            var khoSanPhamLogic = new MonThanhPhamLogic();
            MonThanhPhamBDO khoSP_BDO = null;
            MonThanhPham khoSP_DTO = null;
            try
            {
                khoSP_BDO = khoSanPhamLogic.DocTheoId(iD);
                if (khoSP_BDO != null)
                {
                    khoSP_DTO = new MonThanhPham();
                    //Chuyển đổi
                    MonThanhPham.ChuyenBDOThanhDTO(khoSP_BDO, khoSP_DTO);
                }

            }
            catch { }
            return khoSP_DTO;
        }
        //--Hàm Chuyển
        public static void ChuyenBDOThanhDTO(MonThanhPhamBDO monTP_BDO, MonThanhPham monTP_DTO)
        {
            monTP_DTO.ID = monTP_BDO.ID;
            monTP_DTO.Ten = monTP_BDO.Ten;
            monTP_DTO.Ma_01 = monTP_BDO.Ma_01;
            monTP_DTO.Ma_02 = monTP_BDO.Ma_02;
            monTP_DTO.Ma_02 = monTP_BDO.Ma_03;
            monTP_DTO.DaySoLuong = monTP_BDO.DaySoLuong;
            monTP_DTO.DonViTinh = monTP_BDO.DonViTinh;
            monTP_DTO.ThuTu = monTP_BDO.ThuTu;
        }
    }
   
}
