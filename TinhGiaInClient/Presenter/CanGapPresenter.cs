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

    public class CanGapPresenter : IThanhPhamPresenter
    {
        IViewGiaCanGap View = null;
        public CanGapPresenter(IViewGiaCanGap view)
        {
            View = view;

        }
        public void KhoiTaoBanDau()
        {
            View.SoLuong = 50;
            View.DonViTinh = "Con";
            View.SoDuongCan = 1;
        }


        
        public int TyLeMarkUp(int idHangKH)
        {
            return HangKhachHang.LayTheoId(idHangKH).LoiNhuanChenhLech;
        }
        public string ThongTinHangKH(int idHangKH)
        {
            return HangKhachHang.LayTheoId(idHangKH).Ten;
        }

        public Dictionary<int, string> ThanhPhamS()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            foreach (CanGap cp in CanGap.DocTatCa())
            {
                dict.Add(cp.ID, cp.Ten);

            }
            return dict;
        }

        public decimal ThanhTien_ThPh()
        {
            decimal result = 0;

            var idCanGap = this.ThanhPhamS().FirstOrDefault(x => x.Value == View.TenThPhChon).Key;
            var canGap = CanGap.DocTheoId(idCanGap);
            var tyLeMK = this.TyLeMarkUp(View.IdHangKhachHang);
            var giaCanGap = new GiaCanGap(View.SoLuong, View.SoDuongCan, tyLeMK, View.DonViTinh, canGap);
            result = giaCanGap.ThanhTienSales();
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
