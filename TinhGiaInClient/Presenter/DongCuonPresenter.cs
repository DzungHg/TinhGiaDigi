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

    public class DongCuonPresenter : IThanhPhamPresenter
    {
        IViewThanhPham View = null;
        public DongCuonPresenter(IViewThanhPham view)
        {
            View = view;

        }
        public void KhoiTaoBanDau()
        {
            View.SoLuong = 10;
            View.DonViTinh = "Cuốn";
            
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
            foreach (DongCuon cp in DongCuon.DocTatCa())
            {
                dict.Add(cp.ID, cp.Ten);

            }
            return dict;
        }

        public decimal ThanhTien_ThPh()
        {
            decimal result = 0;

            var idDongCuon = this.ThanhPhamS().FirstOrDefault(x => x.Value == View.TenThPhChon).Key;
            var dongCuon = DongCuon.DocTheoId(idDongCuon);
            var tyLeMK = this.TyLeMarkUp(View.IdHangKhachHang);
            var giaDongCuon = new GiaDongCuon(View.SoLuong, tyLeMK, View.DonViTinh, dongCuon);
            result = giaDongCuon.ThanhTienSales();

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
