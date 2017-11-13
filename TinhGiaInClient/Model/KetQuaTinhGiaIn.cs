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
    public class KetQuaTinhGiaIn
    {
        public int ID { get; set; }
        public int IdNguoiDung { get; set; }
        public string TenNguoiDung { get; set; }
        public DateTime NgayTinhGia { get; set; }
        public string TieuDe { get; set; }
        public int IdYeuCauTinhGia { get; set; }
        public string TenKhachHang { get; set; }
        public string NoiDungChaoGia { get; set; }
        public string NoiDungChaoGiaNoiBo { get; set; }
       
         #region các hàm static kết nối dữ liệu
         public static List<KetQuaTinhGiaIn> DocTatCa()
        {
            var tinhGiaInLogic = new KetQuaTinhGiaInLogic();
            List<KetQuaTinhGiaIn> nguon = null;
            try
            {
                nguon = tinhGiaInLogic.DocTatCa().OrderBy(x => x.ID).Select(x => new KetQuaTinhGiaIn
                {
                    ID = x.ID,
                    IdNguoiDung = x.IdNguoiDung,
                    NgayTinhGia = x.NgayTinhGia,
                    TieuDe = x.TieuDe,
                    NoiDungChaoGia = x.NoiDungChaoGia,
                    NoiDungChaoGiaNoiBo = x.NoiDungChaoGiaNoiBo,
                    IdYeuCauTinhGia = x.IdYeuCauTinhGiaIn,
                    TenNguoiDung = x.TenNguoiDung,
                    TenKhachHang = x.TenKhachHang

                }).ToList();
            }
            catch { }
            return nguon;
        }
         public static List<KetQuaTinhGiaIn> DocTatCaSX_Ngay(ChieuSapXepS chieuSapXep)
         {
             var nguon = KetQuaTinhGiaIn.DocTatCa().OrderBy(x => x.NgayTinhGia);

             if (chieuSapXep == ChieuSapXepS.Descending)
                 nguon = KetQuaTinhGiaIn.DocTatCa().OrderByDescending(x => x.NgayTinhGia);

             return nguon.ToList();
         }
         public static List<KetQuaTinhGiaIn> DocTatCaSX_NhanVien(ChieuSapXepS chieuSapXep)
        {
            var nguon = KetQuaTinhGiaIn.DocTatCa().OrderBy(x => x.TenNguoiDung);

            if (chieuSapXep == ChieuSapXepS.Descending)
                nguon = KetQuaTinhGiaIn.DocTatCa().OrderByDescending(x => x.TenNguoiDung);

            return nguon.ToList();
        }
         public static List<KetQuaTinhGiaIn> DocTatCaSX_TieuDe(ChieuSapXepS chieuSapXep)
        {
            var nguon = KetQuaTinhGiaIn.DocTatCa().OrderBy(x => x.TieuDe);

            if (chieuSapXep == ChieuSapXepS.Descending)
                nguon = KetQuaTinhGiaIn.DocTatCa().OrderByDescending(x => x.TieuDe);

            return nguon.ToList();
        }
         public static KetQuaTinhGiaIn DocTheoId(int idTinhGia)
        {
            var tinhGiaInLogic = new KetQuaTinhGiaInLogic();
            var tinhGia = new KetQuaTinhGiaIn();
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

         public static string Them(KetQuaTinhGiaIn item)
        {
            var tinhGiaInLogic = new KetQuaTinhGiaInLogic();
            var itemBDO = new KetQuaTinhGiaInBDO();
            ChuyenDoiGiayDTOThanhBDO(item, itemBDO);
            return tinhGiaInLogic.Them(itemBDO);
        }

         public static string Sua(KetQuaTinhGiaIn item)
        {
            var tinhGiaInLogic = new KetQuaTinhGiaInLogic();
            var itemBDO = new KetQuaTinhGiaInBDO();
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
        private static void ChuyenDoiGiayBDOThanhDTO(KetQuaTinhGiaInBDO tinhGiaBDO, KetQuaTinhGiaIn tinhGia)
        {
            tinhGia.ID = tinhGiaBDO.ID;
            tinhGia.IdNguoiDung = tinhGiaBDO.IdNguoiDung;
            tinhGia.NgayTinhGia = tinhGiaBDO.NgayTinhGia;
            tinhGia.TieuDe = tinhGiaBDO.TieuDe;
            tinhGia.TenNguoiDung = tinhGiaBDO.TenNguoiDung;
            tinhGia.IdYeuCauTinhGia = tinhGiaBDO.IdYeuCauTinhGiaIn;
            tinhGia.NoiDungChaoGia = tinhGiaBDO.NoiDungChaoGia;
            tinhGia.NoiDungChaoGiaNoiBo = tinhGiaBDO.NoiDungChaoGiaNoiBo;
            tinhGia.TenKhachHang = tinhGiaBDO.TenKhachHang;
            
        }
        private static void ChuyenDoiGiayDTOThanhBDO(KetQuaTinhGiaIn tinhGia, KetQuaTinhGiaInBDO tinhGiaBDO)
        {
            tinhGiaBDO.ID = tinhGia.ID;
            tinhGiaBDO.IdNguoiDung = tinhGia.IdNguoiDung;
            tinhGiaBDO.NgayTinhGia = tinhGia.NgayTinhGia;
            tinhGiaBDO.TieuDe = tinhGia.TieuDe;
            tinhGiaBDO.TenNguoiDung = tinhGia.TenNguoiDung;
            tinhGiaBDO.IdYeuCauTinhGiaIn = tinhGia.IdYeuCauTinhGia;
            tinhGiaBDO.NoiDungChaoGia = tinhGia.NoiDungChaoGia;
            tinhGiaBDO.NoiDungChaoGiaNoiBo = tinhGia.NoiDungChaoGiaNoiBo;
            tinhGiaBDO.TenKhachHang = tinhGia.TenKhachHang;
            
        }
        #endregion
    }
}
