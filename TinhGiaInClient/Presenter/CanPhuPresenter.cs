using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;
using TinhGiaInLogic;

namespace TinhGiaInClient.Presenter
{

    public class CanPhuPresenter : IThanhPhamPresenter
    {
        IViewThPhCanPhu View = null;
        public CanPhuPresenter(IViewThPhCanPhu view)
        {
            View = view;
        }
        public void KhoiTaoBanDau()
        {
            View.SoLuong = 50;
            View.DonViTinh = "Mặt";
            View.KieuCanPhu = 1;
            
        }

        public int TyLeMarkUp(int idHangKH)
        {
            return HangKhachHang.LayTheoId(idHangKH).LoiNhuanChenhLech;
        }
        public string ThongTinHangKH(int idHangKH)
        {
            return HangKhachHang.LayTheoId(idHangKH).Ten;
        }
        //Dành cho display
        public Dictionary<int, string> ThanhPhamS()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            foreach (CanPhu cp in CanPhu.DocTatCa())
            {
                dict.Add(cp.ID, cp.Ten);

            }
            return dict;
        }

        public decimal ThanhTien_ThPh()
        {
            decimal result = 0;
            if (View.IdBaiIn <= 0 || View.SoLuong <= 0)
                return result;

            var idCanPhu = this.ThanhPhamS().FirstOrDefault(x => x.Value == View.TenThPhChon).Key;
            var canPhu = CanPhu.DocTheoId(idCanPhu);

            var tyLeMK = this.TyLeMarkUp(View.IdHangKhachHang);

            var giaCanPhu = new GiaCanPhu(View.IdBaiIn, View.LoaiThPh, View.TenThPhChon,
                View.IdHangKhachHang,View.ThongTinHangKH,tyLeMK, View.ThongTinTyLeMarkUp,
                View.SoLuong, View.DonViTinh, View.ThongTinHoTro, View.TenCanPhuMoRong, View.KieuCanPhu, canPhu);

            result = giaCanPhu.ThanhTienSales();

            return result;
        }

        public decimal GiaTB_ThPh()
        {
            if (View.SoLuong <= 0)
                return 0;
            return ThanhTien_ThPh() / View.SoLuong;
        }
    }
}
