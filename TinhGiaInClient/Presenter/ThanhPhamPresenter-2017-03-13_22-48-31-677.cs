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
  
    public class ThanhPhamPresenter
    {
        IViewThanhPham View = null;
        public ThanhPhamPresenter(IViewThanhPham view)
        {
            View = view;

        }
        public void KhoiTaoBanDau()
        {
            View.SoLuongA4CanPhu = 0;
            View.SoLuongCuon = 0;
            View.SoLuongToCanGap = 0;
        }
        public Dictionary<int, string>CanPhuS()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            foreach(CanPhu cp in CanPhu.DocTatCa())
            {
                dict.Add(cp.ID, cp.Ten);

            }
            return dict;
        }
        public Dictionary<int, string> CanGapS()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            foreach (CanGap cp in CanGap.DocTatCa())
            {
                dict.Add(cp.ID, cp.Ten);

            }
            return dict;
        }
        public Dictionary<int, string> DongCuonS()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            foreach (DongCuon cp in DongCuon.DocTatCa())
            {
                dict.Add(cp.ID, cp.Ten);

            }
            return dict;
        }
        public int TyLeMarkUp(int idHangKH)
        {
            return HangKhachHang.LayTheoId(idHangKH).LoiNhuanChenhLech;
        }
        public string ThongTinHangKH (int idHangKH)
        {
            return HangKhachHang.LayTheoId(idHangKH).Ten;
        }
        public decimal ThanhTien_CanPhu(string tenCanPhu)
        {
            decimal result = 0;
            var idCanPhu = this.CanPhuS().FirstOrDefault(x => x.Value == tenCanPhu).Key;
            var canPhu = CanPhu.DocTheoId(idCanPhu);
            decimal tyLeMK = this.TyLeMarkUp(View.IdHangKhachHang)/100;
            
            result = canPhu.ThanhTienCoBan(View.SoLuongA4CanPhu) +
                canPhu.ThanhTienCoBan(View.SoLuongA4CanPhu) * tyLeMK / (1 - tyLeMK);

            return result;
        }      
        public decimal ThanhTien_CanGap(string tenCanGap)
        {
            decimal result = 0;
            var idCanPhu = this.CanGapS().FirstOrDefault(x => x.Value == tenCanGap).Key;
            var canGap = CanGap.DocTheoId(idCanPhu);
            decimal tyLeMK = this.TyLeMarkUp(View.IdHangKhachHang) / 100;

            result = canGap.ThanhTienCoBan(View.SoLuongA4CanPhu) +
                canGap.ThanhTienCoBan(View.SoLuongA4CanPhu) * tyLeMK / (1 - tyLeMK);

            return result;
        }
        public decimal ThanhTien_DongCuon(string tenDongCuon)
        {
            decimal result = 0;
            var idCanPhu = this.DongCuonS().FirstOrDefault(x => x.Value == tenDongCuon).Key;
            var dongCuon = DongCuon.DocTheoId(idCanPhu);
            decimal tyLeMK = this.TyLeMarkUp(View.IdHangKhachHang) / 100;

            result = dongCuon.ThanhTienCoBan(View.SoLuongA4CanPhu) +
                dongCuon.ThanhTienCoBan(View.SoLuongA4CanPhu) * tyLeMK / (1 - tyLeMK);

            return result;
        }
    }
}
