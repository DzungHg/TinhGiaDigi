using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;
using TinhGiaInClient.Common.Enum;


namespace TinhGiaInClient.Model
{
    public class YeuCauTinhGiaIn
    {
        public int ID { get; set; }
        public int IdNguoiDung { get; set; }
        public DateTime NgayYeuCau { get; set; }
        public string HoTen { get; set; }
        public string CongTy { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string ThamChieuTicket { get; set; }
        public string NoiDung { get; set; }
        public string PhanChoNhanVien { get; set; }
        public int TinhTrang { get; set; }
       
         #region các hàm static kết nối dữ liệu
        public static List<YeuCauTinhGiaIn> DocTatCa()
        {
            var tinhGiaInLogic = new YeuCauTinhGiaInLogic();
            List<YeuCauTinhGiaIn> nguon = null;
            try
            {
                nguon = tinhGiaInLogic.DocTatCa().OrderBy(x => x.ID).Select(x => new YeuCauTinhGiaIn
                {
                    ID = x.ID,
                    IdNguoiDung = x.IdNguoiDung,
                    NgayYeuCau = x.NgayYeuCau,
                    HoTen = x.HoTen,
                    CongTy = x.CongTy,
                    SoDienThoai = x.SoDienThoai,
                    Email = x.Email,
                    ThamChieuTicket = x.ThamChieuTicket,
                    NoiDung = x.NoiDung,
                    PhanChoNhanVien = x.PhanChoNhanVien,
                    TinhTrang = x.TinhTrang

                }).ToList();
            }
            catch { }
            return nguon;
        }
        public static List<YeuCauTinhGiaIn> DocTatCaSX_Ngay(ChieuSapXepS chieuSapXep)
         {
             var nguon = YeuCauTinhGiaIn.DocTatCa().OrderBy(x => x.NgayYeuCau);

             if (chieuSapXep == ChieuSapXepS.Descending)
                 nguon = YeuCauTinhGiaIn.DocTatCa().OrderByDescending(x => x.NgayYeuCau);

             return nguon.ToList();
         }
        public static List<YeuCauTinhGiaIn> DocTatCaSX_NhanVien(ChieuSapXepS chieuSapXep)
        {
            var nguon = YeuCauTinhGiaIn.DocTatCa().OrderBy(x => x.PhanChoNhanVien);

            if (chieuSapXep == ChieuSapXepS.Descending)
                nguon = YeuCauTinhGiaIn.DocTatCa().OrderByDescending(x => x.PhanChoNhanVien);

            return nguon.ToList();
        }
        public static List<YeuCauTinhGiaIn> DocTatCaSX_KhachHang(ChieuSapXepS chieuSapXep)
        {
            var nguon = YeuCauTinhGiaIn.DocTatCa().OrderBy(x => x.HoTen);

            if (chieuSapXep == ChieuSapXepS.Descending)
                nguon = YeuCauTinhGiaIn.DocTatCa().OrderByDescending(x => x.HoTen);

            return nguon.ToList();
        }
        public static YeuCauTinhGiaIn DocTheoId(int idTinhGia)
        {
            var tinhGiaInLogic = new YeuCauTinhGiaInLogic();
            var tinhGia = new YeuCauTinhGiaIn();
            try
            {
                var giayBDO = tinhGiaInLogic.DocTheoId(idTinhGia);
                //Chuyen
                ChuyenDoiGiayBDOThanhDTO(giayBDO, tinhGia);
            }
                catch {
                }
            return tinhGia;
        }
        
        #region Thêm sửa xóa

        public static string Them(YeuCauTinhGiaIn item)
        {
            var tinhGiaInLogic = new YeuCauTinhGiaInLogic();
            var itemBDO = new YeuCauTinhGiaInBDO();
            ChuyenDoiGiayDTOThanhBDO(item, itemBDO);
            return tinhGiaInLogic.Them(itemBDO);
        }

        public static string Sua(YeuCauTinhGiaIn item)
        {
            var tinhGiaInLogic = new YeuCauTinhGiaInLogic();
            var itemBDO = new YeuCauTinhGiaInBDO();
            ChuyenDoiGiayDTOThanhBDO(item, itemBDO);
            return tinhGiaInLogic.Sua(itemBDO);
        }
        public static string Xoa(int idTinhGia)
        {
            var tinhGiaInLogic = new KetQuaTinhGiaInLogic();
            
            return tinhGiaInLogic.Xoa(idTinhGia);
        }
        #endregion
        //Chuyển đổi
        private static void ChuyenDoiGiayBDOThanhDTO(YeuCauTinhGiaInBDO tinhGiaBDO, YeuCauTinhGiaIn tinhGia)
        {
            tinhGia.ID = tinhGiaBDO.ID;
            tinhGia.IdNguoiDung = tinhGiaBDO.IdNguoiDung;
            tinhGia.NgayYeuCau = tinhGiaBDO.NgayYeuCau;
            tinhGia.HoTen = tinhGiaBDO.HoTen;
            tinhGia.CongTy = tinhGiaBDO.CongTy;
            tinhGia.SoDienThoai = tinhGiaBDO.SoDienThoai;
            tinhGia.Email = tinhGiaBDO.Email;
            tinhGia.ThamChieuTicket = tinhGiaBDO.ThamChieuTicket;
            tinhGia.NoiDung = tinhGiaBDO.NoiDung;
            tinhGia.PhanChoNhanVien = tinhGiaBDO.PhanChoNhanVien;
            tinhGia.TinhTrang = tinhGiaBDO.TinhTrang;


        }
        private static void ChuyenDoiGiayDTOThanhBDO(YeuCauTinhGiaIn tinhGia, YeuCauTinhGiaInBDO tinhGiaBDO)
        {
            tinhGiaBDO.ID = tinhGia.ID;
            tinhGiaBDO.IdNguoiDung = tinhGia.IdNguoiDung;
            tinhGiaBDO.NgayYeuCau = tinhGia.NgayYeuCau;
            tinhGiaBDO.HoTen = tinhGia.HoTen;
            tinhGiaBDO.CongTy = tinhGia.CongTy;
            tinhGiaBDO.SoDienThoai = tinhGia.SoDienThoai;
            tinhGiaBDO.Email = tinhGia.Email;
            tinhGiaBDO.ThamChieuTicket = tinhGia.ThamChieuTicket;
            tinhGiaBDO.NoiDung = tinhGia.NoiDung;
            tinhGiaBDO.PhanChoNhanVien = tinhGia.PhanChoNhanVien;
            tinhGiaBDO.TinhTrang = tinhGia.TinhTrang;
            
        }
        #endregion
    }
}
