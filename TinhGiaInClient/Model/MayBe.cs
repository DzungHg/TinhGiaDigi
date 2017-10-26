using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class MayBe : ThanhPhamBase
    {

        //Thêm các properties
        public int TocDoTamGio { get; set; }
        public int PhiNVLChuanBi { get; set; }       
        //Emplement IThanh phẩm
               
        #region hàm static
        public static List<MayBe> DocTatCa()
        {
            var mayBeLogic = new MayBeLogic();
            var nguon = mayBeLogic.DocTatCa().Select(x => new MayBe
            {                
                ID = x.ID,
                Ten = x.Ten,
                BHR = x.BHR,
                TocDoTamGio = x.TocDoTamGio,
                ThoiGianChuanBi = x.ThoiGianChuanBi,
                PhiNVLChuanBi = x.PhiNguyenVatLieuChuanBi,
                DayLoiNhuan = x.DayLoiNhuan,
                DaySoLuong = x.DaySoLuong,    
                            
                DonViTinh = x.DonViTinh,
                DaySoLuongNiemYet = x.DaySoLuongNiemYet,
                ThuTu = x.ThuTu
            }).OrderBy(x => x.ThuTu).ToList();

            return nguon;
        }
        public static MayBe DocTheoId(int iD)
        {
            var mayBeLogic = new MayBeLogic(); ;
            MayBe mayBe = new MayBe();
            try
            {
                var canPhuBDO = mayBeLogic.DocTheoId(iD);
                //Chuyen
                ChuyenDoiEpKimBDOThanhDTO(canPhuBDO, mayBe);
            }
            catch
            {
            }
            return mayBe;
        }
        public static string Them(MayBe mayBe)
        {
            var mayBeLogic = new MayBeLogic();
            var itemBDO = new MayBeBDO();
            ChuyenDoiEpKimDTOThanhBDO(mayBe, itemBDO);
            return mayBeLogic.Them(itemBDO);
        }
        public static string Sua(MayBe canGap)
        {
            var mayBeLogic = new MayBeLogic();
            var itemBDO = new MayBeBDO();
            ChuyenDoiEpKimDTOThanhBDO(canGap, itemBDO);
            return mayBeLogic.Sua(itemBDO);
        }
        private static void ChuyenDoiEpKimBDOThanhDTO(MayBeBDO epKimBDO, MayBe epKimDTO)
        {
            epKimDTO.ID = epKimBDO.ID;
            epKimDTO.Ten = epKimBDO.Ten;
            epKimDTO.BHR = epKimBDO.BHR;
            epKimDTO.TocDoTamGio = epKimBDO.TocDoTamGio;
            epKimDTO.ThoiGianChuanBi = epKimBDO.ThoiGianChuanBi;
            epKimDTO.PhiNVLChuanBi = epKimBDO.PhiNguyenVatLieuChuanBi;
            epKimDTO.DayLoiNhuan = epKimBDO.DayLoiNhuan;
            epKimDTO.DaySoLuong = epKimBDO.DaySoLuong;
           
            epKimDTO.Ma_01 = epKimBDO.Ma_01;
            epKimDTO.DonViTinh = epKimBDO.DonViTinh;
            epKimDTO.DaySoLuongNiemYet = epKimBDO.DaySoLuongNiemYet;
            epKimDTO.ThuTu = epKimBDO.ThuTu;
        }
        private static void ChuyenDoiEpKimDTOThanhBDO(MayBe epKimDTO, MayBeBDO epKimBDO)
        {
            epKimBDO.ID = epKimDTO.ID;
            epKimBDO.Ten = epKimDTO.Ten;
            epKimBDO.BHR = epKimDTO.BHR;
            epKimBDO.TocDoTamGio = epKimDTO.TocDoTamGio;
            epKimBDO.ThoiGianChuanBi = epKimDTO.ThoiGianChuanBi;
            epKimBDO.PhiNguyenVatLieuChuanBi = epKimDTO.PhiNVLChuanBi;
            epKimBDO.DayLoiNhuan = epKimDTO.DayLoiNhuan;
            epKimBDO.DaySoLuong = epKimDTO.DaySoLuong;
          
            epKimBDO.Ma_01 = epKimDTO.Ma_01;
            epKimBDO.DonViTinh = epKimDTO.DonViTinh;
            epKimBDO.DaySoLuongNiemYet = epKimDTO.DaySoLuongNiemYet;
            epKimBDO.ThuTu = epKimDTO.ThuTu;
        }
        #endregion
    }
   
}
