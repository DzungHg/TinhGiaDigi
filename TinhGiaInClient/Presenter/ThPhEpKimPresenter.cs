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
        public ThPhEpKimPresenter(IViewThPhEpKim view, MucThanhPham mucThPham)
        {
            View = view;
            View = view;
            if (mucThPham != null)
            {
                View.ID = mucThPham.ID;
                View.IdBaiIn = mucThPham.IdBaiIn;
                View.IdHangKhachHang = mucThPham.IdHangKhachHang;
                View.IdThanhPhamChon = mucThPham.IdThanhPhamChon;
                View.LoaiThPh = mucThPham.LoaiThanhPham;
                View.SoLuong = mucThPham.SoLuong;

            }
            switch (View.TinhTrangForm)
            {
                case FormStateS.New:
                    KhoiTaoBanDau();
                    break;

            }

        }
        public void KhoiTaoBanDau()
        {
            View.SoLuong = 50;
            View.DonViTinh = "Con";
            View.KhoEpRong = 5f;
            View.KhoEpCao = 10f;
        }


        
        public int TyLeMarkUp(int idHangKH)
        {
            return HangKhachHang.LayTheoId(idHangKH).LoiNhuanChenhLech;
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
            
            var epKim = EpKim.DocTheoId(View.IdThanhPhamChon);
            if (epKim.LaNhuViTinh)
                return true;
            else
                return false;
        }
        public decimal ThanhTien_ThPh()
        {
            decimal result = 0;            
           
            var epKim = EpKim.DocTheoId(View.IdThanhPhamChon);
            
            if (View.IdNhuEpKimChon <= 0)
                return 0;//Không thể không có nhũ
            var nhuEp = NhuEpKim.DocTheoId(View.IdNhuEpKimChon);
            
            var mucLoiNhuan = TinhToan.GiaTriTheoKhoang(epKim.DaySoLuong, epKim.DayLoiNhuan, View.SoLuong);
            var giaEpKim = new GiaEpKim(View.SoLuong, View.KhoEpRong, View.KhoEpCao,
                            epKim,nhuEp, mucLoiNhuan);
            
            decimal tyLeMK = (decimal)this.TyLeMarkUp(View.IdHangKhachHang) / 100;           

            result = giaEpKim.ThanhTienCoBan(View.SoLuong) +
                giaEpKim.ThanhTienCoBan(View.SoLuong) * tyLeMK / (1 - tyLeMK);

            return result;
        }

        public decimal GiaTB_ThPh()
        {
            if (View.SoLuong <= 0)
                return 0;
            return ThanhTien_ThPh() / View.SoLuong;
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
        public MucThanhPham LayMucThanhPham()
        {
            var mucThPham = new MucThanhPham();
            mucThPham.IdBaiIn = View.IdBaiIn;
            mucThPham.TenThanhPham = View.TenThanhPhamChon;
            mucThPham.IdHangKhachHang = View.IdHangKhachHang;
            mucThPham.LoaiThanhPham = View.LoaiThPh;
            mucThPham.SoLuong = View.SoLuong;
            mucThPham.DonViTinh = View.DonViTinh;
            mucThPham.ThanhTien = View.ThanhTien;
            if (View.TinhTrangForm == FormStateS.Edit)
                mucThPham.ID = View.ID; //Cập nhật lại ID
            return mucThPham;
        }
    }
}
