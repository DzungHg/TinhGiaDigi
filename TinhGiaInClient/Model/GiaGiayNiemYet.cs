using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class GiaGiayNiemYet
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public int GiaMua { get; set; }
        public int IdDanhMucGiay { get; set; }
        public int IdHangKhachHang { get; set; }
        public int MucLoiNhuan { get; set; }

        public decimal GiaBan()
        {
            decimal tyLeMK = (decimal)this.MucLoiNhuan / 100;
            return this.GiaMua + this.GiaMua * tyLeMK / (1 - tyLeMK);
        }
        public string TenHangKhachHang()
        {
            return HangKhachHang.LayTheoId(this.IdHangKhachHang).Ten;
        }
        //hàm static
        public static List<GiaGiayNiemYet> DocTatCa()
        {/*var result=products.Join(
            categories,
            p=>p.CategoryID,
            c=>c.CategoryID,
            (p,c) => new
            {
                ProductName=p.ProductName,
                CategoryName=c.CategoryName
            });*/

            //Đọc những cái Còn
            var nguonGiayMoi = Giay.DocTatCa().Where(x => !x.KhongCon).Join(MarkUpLoiNhuanGiay.LayTatCa(), g => g.IdDanhMucGiay,
                            m => m.IdDanhMucGiay, (g, m) => new
                            {
                                ID = g.ID,
                                Ten = g.TenGiayMoRong,
                                GiaMua = g.GiaMua,
                                IdDanhMucGiay = g.IdDanhMucGiay,
                                IdHangKhachHang = m.IdHangKhachHang,
                                MucLoiNhuan = m.TiLeLoiNhuanTrenDoanhThu                           
                            });

            var nguon = nguonGiayMoi.Select(x => new GiaGiayNiemYet
            {
                ID = x.ID,
                Ten = x.Ten,
                GiaMua = x.GiaMua,
                IdDanhMucGiay = x.IdDanhMucGiay,
                IdHangKhachHang = x.IdHangKhachHang,
                MucLoiNhuan = x.MucLoiNhuan
            }).ToList();
         
            return nguon;
        }
        public static List<GiaGiayNiemYet> DocTheoDanhMucGiay_HangKH(int idDanhMucGiay, int idHangKH)
        {
            var nguon = GiaGiayNiemYet.DocTatCa().Where((x => (x.IdDanhMucGiay == idDanhMucGiay) &&
                                                (x.IdHangKhachHang == idHangKH)));
                                
            return nguon.ToList();
        }
        public static List<GiaGiayNiemYet> DocTheoHangKhachHang(int idHangKH)
        {
            var nguon = GiaGiayNiemYet.DocTatCa().Where(x => x.IdHangKhachHang == idHangKH);
            return nguon.ToList();
        }

    }

}
