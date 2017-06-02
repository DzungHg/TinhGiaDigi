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

    public class ThPhDongCuonLoXoPresenter : IThanhPhamPresenter
    {
        IViewThPhDongCuonLoXo View = null;
        public ThPhDongCuonLoXoPresenter(IViewThPhDongCuonLoXo view, MucThanhPham mucThPham)
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
            View.DonViTinh = "Cuốn";
            View.GayRong = 30f;
            View.GayDay = 0.5f;
        }


        
        public int TyLeMarkUp()
        {
            return HangKhachHang.LayTheoId(View.IdHangKhachHang).LoiNhuanChenhLech;
        }
        public string ThongTinHangKH(int idHangKH)
        {
            return HangKhachHang.LayTheoId(idHangKH).Ten;
        }

        public List<DongCuonLoXo> ThanhPhamS()
        {
            return DongCuonLoXo.DocTatCa();
        }
       
        public decimal ThanhTien_ThPh()
        {
            decimal result = 0;            
           
            var dongCuon = DongCuonLoXo.DocTheoId(View.IdThanhPhamChon);
            
            if (View.IdLoXoDongCuonChon <= 0)
                return 0;//Không thể không có nhũ
            var loXo = LoXoDongCuon.DocTheoId(View.IdLoXoDongCuonChon);
            
            var mucLoiNhuan = TinhToan.GiaTriTheoKhoang(dongCuon.DaySoLuong, dongCuon.DayLoiNhuan, View.SoLuong);
            var giaDongCuon = new GiaDongCuonLoXo(View.SoLuong, View.GayRong,
                            dongCuon, loXo, mucLoiNhuan);
            
            decimal tyLeMK = (decimal)this.TyLeMarkUp() / 100;           

            result = giaDongCuon.ThanhTienCoBan(View.SoLuong) +
                giaDongCuon.ThanhTienCoBan(View.SoLuong) * tyLeMK / (1 - tyLeMK);

            return result;
        }

        public decimal GiaTB_ThPh()
        {
            if (View.SoLuong <= 0)
                return 0;
            return ThanhTien_ThPh() / View.SoLuong;
        }
        //Thêm ngoài Implement
        public List<LoXoDongCuon> LoXoDongCuonS()
       {
           return LoXoDongCuon.DocTatCa();
       }
       
        public MucThanhPham LayMucThanhPham()
        {
            var mucThPham = new MucThanhPham();
            mucThPham.IdBaiIn = View.IdBaiIn;
            mucThPham.TenThanhPham = View.TenThanhPhamChon;
            mucThPham.IdThanhPhamChon = View.IdThanhPhamChon;
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
