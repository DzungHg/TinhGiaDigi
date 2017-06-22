using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class NguoiDung
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string ChoHangKhachHang { get; set; }
        public string FormCoTheMo { get; set; }
        public bool HieuLuc { get; set; }
        //Static
        public static List<NguoiDung> DocTatCa()
        {
            var nguoiDungLogic = new NguoiDungLogic();
            var nguon = nguoiDungLogic.DocTatCa().Select(x => new NguoiDung
            {                
                ID = x.ID,
                Ten = x.Ten,
                ChoHangKhachHang = x.ChoHangKhachHang,
                FormCoTheMo = x.FormCoTheMo,
                HieuLuc = x.HieuLuc
            }).ToList();

            return nguon;
        }
        public static NguoiDung DocTheoId(int iD)
        {
            var nguoiDungLogic = new NguoiDungLogic(); ;
            NguoiDung nguoiDung = new NguoiDung();
            try
            {
                var canPhuBDO = nguoiDungLogic.DicTheoId(iD);
                //Chuyen
                ChuyenDoiGiayBDOThanhDTO(canPhuBDO, nguoiDung);
            }
            catch
            {
            }
            return nguoiDung;
        }
        public static NguoiDung DocTheoTenDangNhap(string tenDangNhap)
        {
            var nguoiDungLogic = new NguoiDungLogic(); ;
            NguoiDung nguoiDung = new NguoiDung();
            try
            {
                var canPhuBDO = nguoiDungLogic.DicTheoTenDangNhap(tenDangNhap);
                //Chuyen
                ChuyenDoiGiayBDOThanhDTO(canPhuBDO, nguoiDung);
            }
            catch
            {
            }
            return nguoiDung;
        }
        public static string Sua(NguoiDung canGap)
        {
            NguoiDungLogic nguoiDungLogic = new NguoiDungLogic();
            var itemBDO = new NguoiDungBDO();
            ChuyenDoiGiayDTOThanhBDO(canGap, itemBDO);
            return nguoiDungLogic.Sua(itemBDO);
        }
        private static void ChuyenDoiGiayBDOThanhDTO(NguoiDungBDO nguoiDungBDO, NguoiDung nguoiDungDTO)
        {
            nguoiDungDTO.ID = nguoiDungBDO.ID;
            nguoiDungDTO.Ten = nguoiDungBDO.Ten;
            nguoiDungDTO.ChoHangKhachHang = nguoiDungBDO.ChoHangKhachHang;
            nguoiDungDTO.FormCoTheMo = nguoiDungBDO.FormCoTheMo;
            nguoiDungDTO.HieuLuc = nguoiDungBDO.HieuLuc;           
        }
        private static void ChuyenDoiGiayDTOThanhBDO(NguoiDung nguoiDungDTO, NguoiDungBDO nguoiDungBDO)
        {
            nguoiDungBDO.ID = nguoiDungDTO.ID;
            nguoiDungBDO.Ten = nguoiDungDTO.Ten;
            nguoiDungBDO.ChoHangKhachHang = nguoiDungDTO.ChoHangKhachHang;
            nguoiDungBDO.FormCoTheMo = nguoiDungDTO.FormCoTheMo;
            nguoiDungBDO.HieuLuc = nguoiDungDTO.HieuLuc;           
        }
    }
   
}
