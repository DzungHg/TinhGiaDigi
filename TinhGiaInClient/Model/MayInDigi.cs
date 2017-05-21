using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class MayInDigi
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string KhoInMin { get; set; }
        public string KhoInMax { get; set; }
        public string ThongTinTocDo { get; set; }
        public int TocDoHieuQua { get; set; }
        public int BHR { get; set; }
        public int PhiPhePhamSanSang { get; set; }
        public float ThoiGianSanSang { get; set; }       
        public int ClickA4_4M { get; set; }
        public int ClickA4_1M { get; set; }
        public int ClickA4_6M { get; set; }

        #region các hàm static
        public static List<MayInDigi> DocTatCa()
        {
            //Sắp xếp theo thứ tự
            var khoSanPhamLogic = new MayInDigiLogic();
            List<MayInDigi> nguon = null;
            try
            {
                nguon = khoSanPhamLogic.DocTatCa().Select(x => new MayInDigi
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    KhoInMin = x.KhoInMin,
                    KhoInMax = x.KhoInMax,
                    ThongTinTocDo = x.ThongTinTocDo,
                    TocDoHieuQua = x.TocDoHieuQua,
                    BHR = x.BHR,
                    PhiPhePhamSanSang = x.PhiPhePhamSanSang,
                    ThoiGianSanSang = x.ThoiGianSanSang,
                    ClickA4_4M = x.ClickA4_4M,
                    ClickA4_1M = x.ClickA4_1M,
                    ClickA4_6M = x.ClickA4_6M,
                }).ToList();
            }
            catch { }
            return nguon;
        }
        public static MayInDigi DocTheoId(int iD)
        {
            var mayInDigiLogic = new MayInDigiLogic();
            MayInDigiBDO mayInDigi_BDO = null;
            MayInDigi mayInDigi_DTO = null;
            try
            {
                mayInDigi_BDO = mayInDigiLogic.DocTheoId(iD);
                if (mayInDigi_BDO != null)
                {
                    mayInDigi_DTO = new MayInDigi();
                    //Chuyển đổi
                    MayInDigi.ChuyenBDOThanhDTO(mayInDigi_BDO, mayInDigi_DTO);
                }

            }
            catch { }
            return mayInDigi_DTO;
        }
        public static string Them(MayInDigi item)
        {
            MayInDigiLogic mayInDigiLogic = new MayInDigiLogic();
            var itemBDO = new MayInDigiBDO();
            ChuyenDTOhanhBDO(item, itemBDO);
            return mayInDigiLogic.Them(itemBDO);
        }
        public static string Sua(MayInDigi item)
        {
            MayInDigiLogic mayInDigiLogic = new MayInDigiLogic();
            var itemBDO = new MayInDigiBDO();
            ChuyenDTOhanhBDO(item, itemBDO);
            return mayInDigiLogic.Sua(itemBDO);
        }

        //--Hàm Chuyển
        public static void ChuyenBDOThanhDTO(MayInDigiBDO monTP_BDO, MayInDigi monTP_DTO)
        {
            monTP_DTO.ID = monTP_BDO.ID;
            monTP_DTO.Ten = monTP_BDO.Ten;
            monTP_DTO.BHR = monTP_BDO.BHR;
            monTP_DTO.KhoInMin = monTP_BDO.KhoInMin;
            monTP_DTO.KhoInMax = monTP_BDO.KhoInMax;
            monTP_DTO.ThongTinTocDo = monTP_BDO.ThongTinTocDo;
            monTP_DTO.TocDoHieuQua = monTP_BDO.TocDoHieuQua;
            monTP_DTO.ClickA4_1M = monTP_BDO.ClickA4_1M;
            monTP_DTO.ClickA4_4M = monTP_BDO.ClickA4_4M;
            monTP_DTO.ClickA4_6M = monTP_BDO.ClickA4_6M;
            monTP_DTO.ThoiGianSanSang = monTP_BDO.ThoiGianSanSang;
            monTP_DTO.PhiPhePhamSanSang = monTP_BDO.PhiPhePhamSanSang;
        }
        public static void ChuyenDTOhanhBDO(MayInDigi monTP_DTO, MayInDigiBDO monTP_BDO)
        {
            monTP_BDO.ID = monTP_DTO.ID;
            monTP_BDO.Ten = monTP_DTO.Ten;
            monTP_BDO.BHR = monTP_DTO.BHR;
            monTP_BDO.KhoInMin = monTP_DTO.KhoInMin;
            monTP_BDO.KhoInMax = monTP_DTO.KhoInMax;
            monTP_BDO.ThongTinTocDo = monTP_DTO.ThongTinTocDo;
            monTP_BDO.TocDoHieuQua = monTP_DTO.TocDoHieuQua;
            monTP_BDO.ClickA4_1M = monTP_DTO.ClickA4_1M;
            monTP_BDO.ClickA4_4M = monTP_DTO.ClickA4_4M;
            monTP_BDO.ClickA4_6M = monTP_DTO.ClickA4_6M;
            monTP_BDO.ThoiGianSanSang = monTP_DTO.ThoiGianSanSang;
            monTP_BDO.PhiPhePhamSanSang = monTP_DTO.PhiPhePhamSanSang;
        }        
      
        #endregion
    }
   
}
