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
        IViewThanhPham View = null;
        public CanGapPresenter(IViewThanhPham view)
        {
            View = view;

        }
        public void KhoiTaoBanDau()
        {
            View.SoLuong = 50;
            View.DonViTinh = "Con";
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

            var idCanPhu = this.ThanhPhamS().FirstOrDefault(x => x.Value == View.TenThPhChon).Key;
            var canGap = CanGap.DocTheoId(idCanPhu);
            var tyLeMK = this.TyLeMarkUp(View.IdHangKhachHang);
            var giaCanGap = new GiaCanGap(View.SoLuong, tyLeMK, View.DonViTinh, canGap);
            result = giaCanGap.ThanhTien_CanGap();
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
