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
        MucThPhEpKim MucEpKim = null;
        public ThPhEpKimPresenter(IViewThPhEpKim view, MucThPhEpKim mucThPham)
        {
            View = view;
            this.MucEpKim = mucThPham;

            View.ID = this.MucEpKim.ID;
            View.IdBaiIn = this.MucEpKim.IdBaiIn;
            View.IdHangKhachHang = this.MucEpKim.IdHangKhachHang;
            View.IdThanhPhamChon = this.MucEpKim.IdThanhPhamChon;
            View.LoaiThPh = this.MucEpKim.LoaiThanhPham;
            View.SoLuong = this.MucEpKim.SoLuong;
            View.DonViTinh = this.MucEpKim.DonViTinh;
            View.IdNhuEpKimChon = this.MucEpKim.IdNhuEpKimChon;
            
            View.KhoEpCao = this.MucEpKim.KhoEpCao;
            View.KhoEpRong = this.MucEpKim.KhoEpRong;
            View.KhoToChayRong = this.MucEpKim.KhoToChayRong;
            View.KhoToChayDai = this.MucEpKim.KhoToChayDai;
            View.SoLuongToChay = this.MucEpKim.SoLuongToChay;

        }
        public void KhoiTaoBanDau()
        {
           
        }


        
        public int TyLeMarkUp()
        {
            return HangKhachHang.LayTheoId(View.IdHangKhachHang).LoiNhuanChenhLech;
        }
        public string ThongTinHangKH(int idHangKH)
        {
            return HangKhachHang.LayTheoId(idHangKH).Ten;
        }

        public List<EpKim> ThanhPhamS()
        {
            return EpKim.DocTatCa();
        }
        public bool LaNhuViTinh()
        {
            var kq = false;           
            var epKim = EpKim.DocTheoId(View.IdThanhPhamChon);
            if (epKim != null)
                kq = epKim.LaNhuViTinh;

            return kq;
        }
        public decimal ThanhTien_ThPh()
        {
            decimal kq = 0;            
           
            var epKim = EpKim.DocTheoId(View.IdThanhPhamChon);
            
            if (View.IdNhuEpKimChon <= 0)
                return 0;//Không thể không có nhũ
            var nhuEp = NhuEpKim.DocTheoId(View.IdNhuEpKimChon);           
            //Lưu ý số lượng tính giá
            var giaEpKim = new GiaEpKim(View.SoLuongTinhGia, View.KhoEpRong, View.KhoEpCao,
                            epKim, nhuEp, this.TyLeMarkUp());    
       
            kq = giaEpKim.ThanhTienSales();

            return kq;
        }

        public decimal GiaTB_ThPh()
        {
            if (View.SoLuongTinhGia <= 0)
                return 0;
            return ThanhTien_ThPh() / View.SoLuongTinhGia; //Số lượng Để tính giá
        }
        //Thêm ngoài Implement
       
        public Dictionary<int, List<string>> NhuTheoEpKimS()
        {
            var dict = new Dictionary<int, List<string>>();
            if (string.IsNullOrEmpty(View.TenThanhPhamChon))
                return dict;
            //Qua tiếp

           
            foreach (NhuEpKim nhu in  NhuEpKim.DocTheoIdEpKim(View.IdThanhPhamChon))
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
        private void CapNhatMucThanhPham()
        {
            if (this.MucEpKim != null)
            {
                this.MucEpKim.ID = View.ID;
                this.MucEpKim.IdBaiIn = View.IdBaiIn;
                this.MucEpKim.TenThanhPham = View.TenThanhPhamChon;
                this.MucEpKim.IdThanhPhamChon = View.IdThanhPhamChon;
                this.MucEpKim.IdHangKhachHang = View.IdHangKhachHang;
                this.MucEpKim.LoaiThanhPham = View.LoaiThPh;
                this.MucEpKim.SoLuong = View.SoLuong;
                this.MucEpKim.KhoEpCao = View.KhoEpCao;
                this.MucEpKim.KhoEpRong = View.KhoEpRong;
                this.MucEpKim.KhoToChayRong = View.KhoToChayRong;
                this.MucEpKim.KhoToChayDai = View.KhoToChayDai;
                this.MucEpKim.SoLuongToChay = View.SoLuongToChay;
                this.MucEpKim.IdNhuEpKimChon = View.IdNhuEpKimChon;
                this.MucEpKim.DonViTinh = View.DonViTinh;
                this.MucEpKim.ThanhTien = View.ThanhTien;
            }
        }
        public MucThPhEpKim LayMucThanhPham()
        {
            CapNhatMucThanhPham();

            return this.MucEpKim;
        }
    }
}
