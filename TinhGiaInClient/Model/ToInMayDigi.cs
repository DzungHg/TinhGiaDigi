using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class ToInMayDigi
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
        public int ClickA4MotMau { get; set; }
        public int ClickA4BonMau { get; set; }
        public int ClickA4SauMau { get; set; }
        public int QuiA4 { get; set; }
        public int IdMayIn { get; set; }
        public int BHR { get; set; }
        public int PhiPhePhamSanSang { get; set; }
        public float ThoiGianSanSang { get; set; }
        
        public string KhoToChayCoTheIn { get; set; }
        public string DaySoLuong { get; set; }
        public string DayLoiNhuan { get; set; }
        public string DaySoLuongNiemYet { get; set; }
        public bool KhongSuDung { get; set; }
        public int ThuTu { get; set; }        
        #endregion
        //Các hàm static
        public static List<ToInMayDigi> DocTatCa()
        {
            var toChayDigiLogic = new ToInMayDigiLogic();
            var nguon = toChayDigiLogic.DocTatCa().Select(x => new ToInMayDigi
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
                ClickA4MotMau = (int)x.ClickA4MotMau,
                ClickA4BonMau = (int)x.ClickA4BonMau,
                ClickA4SauMau = (int)x.ClickA4SauMau,
                QuiA4 = (int)x.QuiA4,
                IdMayIn = (int)x.IdMayIn,
                BHR = (int)x.BHR,
                ThoiGianSanSang = (float)x.ThoiGianSanSang,
                PhiPhePhamSanSang = (int)x.PhiPhePhamSanSang,
                
                DaySoLuong = x.DaySoLuong,
                DayLoiNhuan = x.DayLoiNhuan,
                DaySoLuongNiemYet = x.DaySoLuongNiemYet,
                KhongSuDung = x.KhongSuDung,
                ThuTu = (int)x.ThuTu
            }).OrderBy(x => x.ThuTu);

            return nguon.ToList() ;
        }
         
        public static ToInMayDigi DocTheoId(int idToDigi)
        {
            var toChayDigiLogic = new ToInMayDigiLogic();   
            //
            ToInMayDigi toChayDTO = new ToInMayDigi();
            try
            {
                var toChayBDO = toChayDigiLogic.DocTheoId(idToDigi);
                //Chuyen
                ToInMayDigi.ChuyenBDOThanhDTO(toChayBDO, toChayDTO);
            }
            catch
            {
            }
            return toChayDTO;
        }
        public static bool Them(ref string thongDiep, ToInMayDigi toInMayDigi)
        {
            var toInMayDigiLogic = new ToInMayDigiLogic();
            var itemBDO = new ToInMayDigiBDO();
            ChuyenDTOThanhBDO(toInMayDigi, itemBDO);
            return toInMayDigiLogic.Them(ref thongDiep, itemBDO);
        }
        public static bool Sua (ref string thongDiep, ToInMayDigi toInMayDigi)
        {
            var toInMayDigiLogic = new ToInMayDigiLogic();
            var itemBDO = new ToInMayDigiBDO();
            ChuyenDTOThanhBDO(toInMayDigi, itemBDO);
            return toInMayDigiLogic.Sua(ref thongDiep, itemBDO);
        }
        
        //--Hàm Chuyển
        private static void ChuyenBDOThanhDTO(ToInMayDigiBDO toChayDigiBDO, ToInMayDigi toChayDigiDTO)
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
            toChayDigiDTO.ClickA4MotMau = toChayDigiBDO.ClickA4MotMau;
            toChayDigiDTO.ClickA4BonMau = toChayDigiBDO.ClickA4BonMau;
            toChayDigiDTO.ClickA4SauMau = toChayDigiBDO.ClickA4SauMau;
            toChayDigiDTO.QuiA4 = toChayDigiBDO.QuiA4;
            toChayDigiDTO.IdMayIn = toChayDigiBDO.IdMayIn;
            toChayDigiDTO.BHR = toChayDigiBDO.BHR;
            toChayDigiDTO.ThoiGianSanSang = toChayDigiBDO.ThoiGianSanSang;
            toChayDigiDTO.PhiPhePhamSanSang = toChayDigiBDO.PhiPhePhamSanSang;
           
            toChayDigiDTO.DaySoLuong = toChayDigiBDO.DaySoLuong;
            toChayDigiDTO.DayLoiNhuan = toChayDigiBDO.DayLoiNhuan;
            toChayDigiDTO.DaySoLuongNiemYet = toChayDigiBDO.DaySoLuongNiemYet;
            toChayDigiDTO.KhongSuDung = toChayDigiBDO.KhongSuDung;
            toChayDigiDTO.ThuTu = toChayDigiBDO.ThuTu;
        }
        private static void ChuyenDTOThanhBDO(ToInMayDigi toChayDigiDTO, ToInMayDigiBDO toChayDigiBDO)
        {
            toChayDigiBDO.ID = toChayDigiDTO.ID;
            toChayDigiBDO.Ten = toChayDigiDTO.Ten;
            toChayDigiBDO.Rong = toChayDigiDTO.Rong;
            toChayDigiBDO.Cao = toChayDigiDTO.Cao;
            toChayDigiBDO.VungInRong = toChayDigiDTO.VungInRong;
            toChayDigiBDO.VungInCao = toChayDigiDTO.VungInCao;
            toChayDigiBDO.KhoToChayCoTheIn = toChayDigiDTO.KhoToChayCoTheIn;
            toChayDigiBDO.TocDo = toChayDigiDTO.TocDo;
        
            toChayDigiBDO.InTuTro = toChayDigiDTO.InTuTro;
            toChayDigiBDO.LaInKhoDai = toChayDigiDTO.LaInKhoDai;
            toChayDigiBDO.LaHPIndigo = toChayDigiDTO.LaHPIndigo;
            toChayDigiBDO.ClickA4MotMau = toChayDigiDTO.ClickA4MotMau;
            toChayDigiBDO.ClickA4BonMau = toChayDigiDTO.ClickA4BonMau;
            toChayDigiBDO.ClickA4SauMau = toChayDigiDTO.ClickA4SauMau;
            toChayDigiBDO.QuiA4 = toChayDigiDTO.QuiA4;
            toChayDigiBDO.IdMayIn = toChayDigiDTO.IdMayIn;
            toChayDigiBDO.BHR = toChayDigiDTO.BHR;
            toChayDigiBDO.ThoiGianSanSang = toChayDigiDTO.ThoiGianSanSang;
            toChayDigiBDO.PhiPhePhamSanSang = toChayDigiDTO.PhiPhePhamSanSang;
           
            toChayDigiBDO.DaySoLuong = toChayDigiDTO.DaySoLuong;
            toChayDigiBDO.DayLoiNhuan = toChayDigiDTO.DayLoiNhuan;
            toChayDigiBDO.DaySoLuongNiemYet = toChayDigiDTO.DaySoLuongNiemYet;
            toChayDigiBDO.ThuTu = toChayDigiDTO.ThuTu;
            toChayDigiBDO.KhongSuDung = toChayDigiDTO.KhongSuDung;

        }
    
    }
}
