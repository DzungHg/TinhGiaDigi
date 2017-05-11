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

    public class ThPhEpKimPresenter : IThanhPhamPresenter
    {
        IViewThPhEpKim View = null;
        public ThPhEpKimPresenter(IViewThPhEpKim view)
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
            foreach (EpKim ek in EpKim.DocTatCa())
            {
                dict.Add(ek.ID, ek.Ten);

            }
            return dict;
        }

        public decimal ThanhTien_ThPh()
        {
            decimal result = 0;
            var idEpKim = this.ThanhPhamS().FirstOrDefault(x => x.Value == View.TenThPhChon).Key;
            var epKim = EpKim.DocTheoId(idEpKim);
            var khuonEp = KhuonEpKim.DocTheoId(View.IdKhuonChon);
            var nhuEp = NhuEpKim.DocTheoId(View.IdNhuEpKimChon);
            var mucLoiNhuan = TinhToanThanhPham.MucLoiNhuan(epKim.DaySoLuong, epKim.DaySoLuong, View.SoLuong);
            var giaEpKim = new GiaEpKim(View.SoLuong, View.KhoEpRong, View.KhoEpCao,
                            epKim, nhuEp, mucLoiNhuan);

            var idCanPhu = this.ThanhPhamS().FirstOrDefault(x => x.Value == View.TenThPhChon).Key;
            var epKim = EpKim.DocTheoId(idCanPhu);
            decimal tyLeMK = (decimal)this.TyLeMarkUp(View.IdHangKhachHang) / 100;

            result = epKim.ThanhTienCoBan(View.SoLuong) +
                epKim.ThanhTienCoBan(View.SoLuong) * tyLeMK / (1 - tyLeMK);

            return result;
        }

        public decimal GiaTB_ThPh()
        {
            if (View.SoLuong <= 0)
                return 0;
            return ThanhTien_ThPh() / View.SoLuong;
        }
        //Thêm ngoài Implement
        public List<KhuonEpKim> KhuonTheoEpKimS()
        {
            var idEpKim = this.ThanhPhamS().FirstOrDefault(x => x.Value == View.TenThPhChon).Key;
            return KhuonEpKim.DocTheoIdEpKim(idEpKim);
        }
        public Dictionary<int, List<string>> NhuTheoEpKimS()
        {
            var dict = new Dictionary<int, List<string>>();
            if (string.IsNullOrEmpty(View.TenThPhChon))
                return dict;
            //Qua tiếp

            var idEpKim = this.ThanhPhamS().FirstOrDefault(x => x.Value == View.TenThPhChon).Key;
            foreach (NhuEpKim nhu in  NhuEpKim.DocTheoIdEpKim(idEpKim))
            {
                var lst = new List<string>();
                lst.Add(nhu.Ten);
                lst.Add(nhu.DienGiai);
                lst.Add(string.Format("{0:0,0.00}đ/cm2", nhu.GiaMuaCm2));
                lst.Add(nhu.ThuTu.ToString());
                dict.Add(nhu.ID, lst);
            }
            return dict;
        }
    }
}
