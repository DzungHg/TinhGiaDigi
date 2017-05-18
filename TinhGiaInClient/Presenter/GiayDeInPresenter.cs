using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;
using TinhGiaInClient.Model.Support;

namespace TinhGiaInClient.Presenter
{
    public class GiayDeInPresenter
    {
        IViewGiayDeIn View;
        GiayDeIn giayDeIn;
        public GiayDeInPresenter(IViewGiayDeIn view, GiayDeIn giayDeIn = null)
        {
            View = view;
            //Việc đặt dữ liệu ban đầu do 
            switch (View.TinhTrangForm)
            {
                case FormStates.New:
                    this.KhoiTaoGiaTriBanDau();
                    var quiCachToChay = new QuiCachToChay(View.KhoToChay, View.SoLuongSanPham, View.SoLuongToChayBuHao);

                    giayDeIn = new GiayDeIn(quiCachToChay, null, View.SoToChayTrenToLon);
                    break;
                case FormStates.Edit:
                    View.ID = giayDeIn.ID;
                    View.IdBaiIn = giayDeIn.IdBaiIn;
                    View.IdHangKH = giayDeIn.IdHangKhachHang;
                    View.SoLuongSanPham = giayDeIn.ToChay.SoLuongSanPham;
                    View.SoConTrenToChay = giayDeIn.ToChay.SoConTrenToChay;
                    View.SoLuongToChayBuHao = giayDeIn.ToChay.SoToChayBuHao;
                    View.LaGiayKhachDua = giayDeIn.GiayKhachDua;
                    View.GiayChon = giayDeIn.GiaGiayChon.Giay;
                    View.TenGiayInDatLai = giayDeIn.TenGiayIn;
                    View.KhoToChay = giayDeIn.ToChay.KhoToChay;
                    View.SoToChayTrenToLon = giayDeIn.SoToChayTrenToLon;
                    break;

            }
            
                     

        }
        private void KhoiTaoGiaTriBanDau()
        {
            
            
            View.SoLuongToChayBuHao = 1;
            View.SoConTrenToChay = 1;
            View.SoToChayTrenToLon = 1;

        }
        public int SoToChayLyThuyetTinh()
        {
            int result = 0;
           
            if (View.SoConTrenToChay <= 0 || View.SoLuongSanPham <= 0)
                return result;
            //Tiếp nếu quá
            result = giayDeIn.ToChay.soLuongToChayLyThuyet();

            return result;
        }
        public int SoToChayTong()
        {
            int result = 0;

            if (View.SoConTrenToChay <= 0 || View.SoLuongSanPham <= 0)
                return result;
            //Tiếp nếu quá
            result = giayDeIn.ToChay.TongSoToChay();

            return result;

        }
        public int SoToGiayLon()
        {
            int result = 0;
            if (View.SoToChayTrenToLon == 0 || View.SoLuongSanPham <= 0)
                return result;
            //Tiếp nếu qua khỏi
            result = giayDeIn.SoToLonCan();

            return result;
        }
       
    
       
        private int TyLeMarkUp()
        {
            if (View.GiayChon == null)
                return 0;

            var result = 0;
            result = MarkUpLoiNhuanGiay.LayTheoId(View.GiayChon.IdDanhMucGiay, View.IdHangKH).TiLeLoiNhuanTrenDoanhThu;
            return result;
        }

        public decimal GiaBan()
        {
            decimal result = 0;
            if (!View.LaGiayKhachDua && View.GiayChon != null)
            {
                var giaGiay = new GiaGiay(View.GiayChon, TyLeMarkUp());
                result = giaGiay.GiaBan();
            }
            return result;
        }
        public decimal ThanhTien()
        {
            decimal result = 0;

            if (!View.LaGiayKhachDua && View.GiayChon != null)
            {
                 var giaGiay = new GiaGiay(View.GiayChon, TyLeMarkUp());
                 result = giaGiay.TienGiaySales(View.SoToGiayLon);
            }

            return result;

        }
        public CauHinhGiayIn DocCauHinhGiay()
        {
            var cauHinhGiay = new CauHinhGiayIn();
            cauHinhGiay.GiayChon = View.GiayChon;
            cauHinhGiay.KhoToChay = View.KhoToChay;
            cauHinhGiay.SoConTrenToChay = View.SoConTrenToChay;
            cauHinhGiay.SoLuongToChayLyThuyet = View.SoLuongToChayLyThuyet;
            cauHinhGiay.SoLuongToChayBuHao = View.SoLuongToChayBuHao;
            cauHinhGiay.TongSoToChay = this.SoToChayTong();
            cauHinhGiay.SoToChayTrenToLon = View.SoToChayTrenToLon;
            cauHinhGiay.SoToGiayLon = this.SoToGiayLon();
            cauHinhGiay.GiayKhachDua = View.LaGiayKhachDua;
           
            cauHinhGiay.TienGiay = this.ThanhTien();

            return cauHinhGiay;
        }
        public GiayDeIn DocGiayDeIn()
        {
            var giayDeIn = new GiayDeIn(View.GiayChon);
            if (View.TinhTrangForm == FormStates.Edit)
                giayDeIn.ID = View.ID;

            giayDeIn.IdBaiIn = View.IdBaiIn;
            giayDeIn.IdHangKhachHang = View.IdHangKH;
            giayDeIn.SoToChayTrenToLon = View.SoToChayTrenToLon;
            giayDeIn.SoLuongToChayBuHao = View.SoLuongToChayBuHao;
            giayDeIn.SoLuongSanPham = View.SoLuongSanPham;
            giayDeIn.GiaGiayChon = View.GiayChon;
            giayDeIn.TenGiayIn = View.TenGiayInDatLai;
            giayDeIn.KhoToChay = View.KhoToChay;
            giayDeIn.SoConTrenToChay = View.SoConTrenToChay;
            giayDeIn.SoLuongToChayLyThuyet = View.SoLuongToChayLyThuyet;
            giayDeIn.SoLuongToChayBuHao = View.SoLuongToChayBuHao;
            giayDeIn.SoToChayTong = this.SoToChayTong();
            giayDeIn.SoToChayTrenToLon = View.SoToChayTrenToLon;
            giayDeIn.SoToLonCan = this.SoToGiayLon();
            giayDeIn.GiayKhachDua = View.LaGiayKhachDua;
           
            giayDeIn.ThanhTien = this.ThanhTien();
            //Về in

            return giayDeIn;
        }
    }
}
