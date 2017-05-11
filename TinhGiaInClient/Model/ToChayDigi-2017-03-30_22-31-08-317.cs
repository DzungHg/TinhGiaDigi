using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class ToChayDigi
    {
        #region Lớp thật
        public int ID { get; set; }
        public string Ten { get; set; }
        public float Rong { get; set; }
        public float Cao { get; set; }
        public float VungInRong  {get;set;}
        public float VungInCao {get;set;}

        public int TocDo { get; set; }
        public bool InTuTro { get; set; }
        public bool LaInKhoDai { get; set; }
        public bool LaHPIndigo { get; set; }
        public int ClickMotMau { get; set; }
        public int ClickBonMau { get; set; }
        public int ClickSauMau { get; set; }
        public int QuiA4 { get; set; }
        public int IdMayIn { get; set; }
        public int BHR { get; set; }
        public int PhiPhePhamSanSang { get; set; }
        public float ThoiGianSanSang { get; set; }
        public float ThoiGianDuLieuBienDoi { get; set; }
        public string KhoToChayCoTheIn { get; set; }
        public string DaySoLuong { get; set; }
        public string DayLoiNhuan { get; set; }
        public int ThuTu { get; set; }        
        #endregion
        //Các hàm static
        public static List<ToChayDigi> DocTatCa()
        {
            var toChayDigiLogic = new ToChayDigiLogic();
            var nguon = toChayDigiLogic.LayTatCa().Select(x => new ToChayDigi
            {
                ID = x.ID,
                Ten = x.Ten,
                Rong = (float)x.Rong,
                Cao = (float)x.Cao,
                VungInRong = (float)x.VungInRong,
                VungInCao = (float)x.VungInCao,
                KhoToChayCoTheIn = x.KhoToChayCoTheIn,   
                TocDo = (int)x.TocDo,
                InTuTro = (bool)x.InTuTro,
                LaInKhoDai = (bool)x.LaInKhoDai,
                LaHPIndigo = (bool)x.LaHPIndigo,
                ClickMotMau = (int)x.ClickMotMau,
                ClickBonMau = (int)x.ClickBonMau,
                ClickSauMau = (int)x.ClickSauMau,
                QuiA4 = (int)x.QuiA4,
                IdMayIn = (int)x.IdMayIn,
                BHR = (int)x.BHR,
                ThoiGianSanSang = (float)x.ThoiGianSanSang,
                PhiPhePhamSanSang = (int)x.PhiPhePhamSanSang,
                ThoiGianDuLieuBienDoi = (float)x.ThoiGianDuLieuBienDoi,
                DaySoLuong = x.DaySoLuong,
                DayLoiNhuan = x.DayLoiNhuan,
                ThuTu = (int)x.ThuTu
            }).OrderBy(x => x.ThuTu);

            return nguon.ToList() ;
        }
        /*public static List<ToChayDigi> DocTatCaConHoatDong()
        {
            var toChayDigiLogic = new ToChayDigiLogic();
            var nguon = toChayDigiLogic.LayTatCa().Where(x => x..Select(x => new ToChayDigi
            {
                ID = x.ID,
                Ten = x.Ten,
                Rong = (float)x.Rong,
                Cao = (float)x.Cao,
                TocDo = (int)x.TocDo,
                InTuTro = (bool)x.InTuTro,
                LaInKhoDai = (bool)x.LaInKhoDai,
                LaHPIndigo = (bool)x.LaHPIndigo,
                ClickMotMau = (int)x.ClickMotMau,
                ClickBonMau = (int)x.ClickBonMau,
                ClickSauMau = (int)x.ClickSauMau,
                QuiA4 = (int)x.QuiA4,
                IdMayIn = (int)x.IdMayIn,
                BHR = (int)x.BHR,
                ThoiGianSanSang = (float)x.ThoiGianSanSang,
                PhiPhePhamSanSang = (int)x.PhiPhePhamSanSang,
                ThoiGianDuLieuBienDoi = (float)x.ThoiGianDuLieuBienDoi,
                ThuTu = (int)x.ThuTu
            }).OrderBy(x => x.ThuTu);

            return nguon.ToList();
        }
         */
        public static ToChayDigi DocTheoId(int idToDigi)
        {
            var toChayDigiLogic = new ToChayDigiLogic();   
            //
            ToChayDigi toChayDTO = new ToChayDigi();
            try
            {
                var toChayBDO = toChayDigiLogic.LayTheoId(idToDigi);
                //Chuyen
                ToChayDigi.ChuyenBDOThanhDTO(toChayBDO, toChayDTO);
            }
            catch
            {
            }
            return toChayDTO;
        }
        //--Hàm Chuyển
        private static void ChuyenBDOThanhDTO(ToChayDigiBDO toChayDigiBDO, ToChayDigi toChayDigiDTO)
        {
            toChayDigiDTO.ID = toChayDigiBDO.ID;
            toChayDigiDTO.Ten = toChayDigiBDO.Ten;
            toChayDigiDTO.Rong = toChayDigiBDO.Rong;
            toChayDigiDTO.Cao = toChayDigiBDO.Cao;
            toChayDigiDTO.VungInRong = toChayDigiBDO.VungInRong;
            toChayDigiDTO.VungInCao = toChayDigiBDO.VungInCao;
            toChayDigiDTO.KhoToChayCoTheIn = toChayDigiBDO.KhoToChayCoTheIn;
            toChayDigiDTO.TocDo = toChayDigiBDO.TocDo;
            toChayDigiDTO.InTuTro = toChayDigiBDO.InTuTro;
            toChayDigiDTO.LaInKhoDai = toChayDigiBDO.LaInKhoDai;
            toChayDigiDTO.LaHPIndigo = toChayDigiBDO.LaHPIndigo;
            toChayDigiDTO.ClickMotMau = toChayDigiBDO.ClickMotMau;
            toChayDigiDTO.ClickBonMau = toChayDigiBDO.ClickBonMau;
            toChayDigiDTO.ClickSauMau = toChayDigiBDO.ClickSauMau;
            toChayDigiDTO.QuiA4 = toChayDigiBDO.QuiA4;
            toChayDigiDTO.IdMayIn = toChayDigiBDO.IdMayIn;
            toChayDigiBDO.BHR = toChayDigiBDO.BHR;
            toChayDigiDTO.ThoiGianSanSang = toChayDigiBDO.ThoiGianSanSang;
            toChayDigiDTO.PhiPhePhamSanSang = toChayDigiBDO.PhiPhePhamSanSang;
            toChayDigiDTO.ThoiGianDuLieuBienDoi = toChayDigiBDO.ThoiGianDuLieuBienDoi;
            toChayDigiDTO.DaySoLuong = toChayDigiDTO.DaySoLuong;
            toChayDigiDTO.DayLoiNhuan = toChayDigiDTO.DayLoiNhuan;
            toChayDigiDTO.ThuTu = toChayDigiBDO.ThuTu;
        }
        private static void ChuyenDTOThanhBDO(ToChayDigiBDO toChayDigiDTO, ToChayDigi toChayDigiDTOx)
        {
            toChayDigiDTOx.ID = toChayDigiDTO.ID;
            toChayDigiDTOx.Ten = toChayDigiDTO.Ten;
            toChayDigiDTOx.Rong = toChayDigiDTO.Rong;
            toChayDigiDTOx.Cao = toChayDigiDTO.Cao;
            toChayDigiDTOx.VungInRong = toChayDigiDTO.VungInRong;
            toChayDigiDTOx.VungInCao = toChayDigiDTO.VungInCao;
            toChayDigiDTOx.KhoToChayCoTheIn = toChayDigiDTO.KhoToChayCoTheIn;
            toChayDigiDTOx.TocDo = toChayDigiDTO.TocDo;
            toChayDigiDTOx.InTuTro = toChayDigiDTO.InTuTro;
            toChayDigiDTOx.LaInKhoDai = toChayDigiDTO.LaInKhoDai;
            toChayDigiDTOx.LaHPIndigo = toChayDigiDTO.LaHPIndigo;
            toChayDigiDTOx.ClickMotMau = toChayDigiDTO.ClickMotMau;
            toChayDigiDTOx.ClickBonMau = toChayDigiDTO.ClickBonMau;
            toChayDigiDTOx.ClickSauMau = toChayDigiDTO.ClickSauMau;
            toChayDigiDTOx.QuiA4 = toChayDigiDTO.QuiA4;
            toChayDigiDTOx.IdMayIn = toChayDigiDTO.IdMayIn;
            toChayDigiDTO.BHR = toChayDigiDTO.BHR;
            toChayDigiDTOx.ThoiGianSanSang = toChayDigiDTO.ThoiGianSanSang;
            toChayDigiDTOx.PhiPhePhamSanSang = toChayDigiDTO.PhiPhePhamSanSang;
            toChayDigiDTOx.ThoiGianDuLieuBienDoi = toChayDigiDTO.ThoiGianDuLieuBienDoi;
            toChayDigiDTOx.DaySoLuong = toChayDigiDTOx.DaySoLuong;
            toChayDigiDTOx.DayLoiNhuan = toChayDigiDTOx.DayLoiNhuan;
            toChayDigiDTOx.ThuTu = toChayDigiDTO.ThuTu;
        }
        #region Tính phí giá
       

        #endregion
    }
}
