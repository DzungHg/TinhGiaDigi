using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;
using TinhGiaInLogic;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.Presenter
{

    public class ThPhBoiNhieuLopPresenter : IThanhPhamPresenter
    {
        IViewThPhBoiNhieuLop View = null;
        MucThPhBoiNhieuLop MucBoiNhieuLop = null;
        public ThPhBoiNhieuLopPresenter(IViewThPhBoiNhieuLop view, MucThPhBoiNhieuLop mucThPham)
        {
            View = view;
            View = view;
            this.MucBoiNhieuLop = mucThPham;
            //Cập nhật form
            View.ID = mucThPham.ID;
            View.IdBaiIn = mucThPham.IdBaiIn;
            View.IdHangKhachHang = mucThPham.IdHangKhachHang;
            View.IdThanhPhamChon = mucThPham.IdThanhPhamChon;
            View.LoaiThPh = mucThPham.LoaiThanhPham;
            View.ToBoiRong = mucThPham.ToBoiRong;
            View.ToBoiCao = mucThPham.ToBoiCao;
            View.SoLuong = mucThPham.SoLuong;
            View.DonViTinh = mucThPham.DonViTinh;
            //View.IdGiayBoiGiuaChon = mucThPham.IdGiayBoiGiuaChon;
            View.GiayDeBoiChon = mucThPham.GiayBoiChon;
            View.SoLopLotGiua = mucThPham.SoLopLotGiua;
            View.KieuBoi = mucThPham.KieuBoi;
            
            //Nếu mới
            switch (View.TinhTrangForm)
            {
                case FormStateS.New:
                    LamLai();
                    break;
                case FormStateS.Edit:
                    
                    break;
            }
           
            


        }
        public void KhoiTaoBanDau()
        {
          //implement
        }
        public void LamLai()
        {
            View.SoLuong = MucBoiNhieuLop.SoLuongToChay;
            View.ToBoiRong = MucBoiNhieuLop.ToBoiRong;
            View.ToBoiCao = MucBoiNhieuLop.ToBoiCao;
            View.SoLopLotGiua = 0;
            View.GiayDeBoiChon = null;
            View.KieuBoi = KieuBoiNhieuLop.BoiDap;
            View.SoLopLotGiua = 1;
        }
        public int SoToLotGiua()
        {
            return View.SoLopLotGiua * View.SoLuong;
        }
        
        public int TyLeMarkUp()
        {
            return HangKhachHang.LayTheoId(View.IdHangKhachHang).LoiNhuanChenhLech;
        }
        public string ThongTinHangKH(int idHangKH)
        {
            return HangKhachHang.LayTheoId(idHangKH).Ten;
        }

        public List<MayBoiNhieuLop> ThanhPhamS()
        {
            return MayBoiNhieuLop.DocTatCa();
        }
       
        public decimal ThanhTien_ThPh()
        {
            decimal kq = 0;

            var boiBiaCung = MayBoiNhieuLop.DocTheoId(View.IdThanhPhamChon);
            
                                   
            var giaBoi = new GiaBoiNhieuLop(View.SoLuong, boiBiaCung, 
                            View.ToBoiRong, View.ToBoiCao, View.GiayDeBoiChon,
                            View.SoLopLotGiua, View.KieuBoi, this.TyLeMarkUp());

            kq = giaBoi.ThanhTienSales();

            return kq;
        }

        public decimal GiaTB_ThPh()
        {
            if (View.SoLuong <= 0)
                return 0;
            return ThanhTien_ThPh() / View.SoLuong;
        }
        //Thêm ngoài Implement
       
        private void CapNhatMucThanhPham()
        {
            if (this.MucBoiNhieuLop != null)
            {
                this.MucBoiNhieuLop.IdBaiIn = View.IdBaiIn;
                this.MucBoiNhieuLop.TenThanhPham = string.Format("Bồi nhiều lớp/{0}", View.TenThanhPhamChon);
                this.MucBoiNhieuLop.IdThanhPhamChon = View.IdThanhPhamChon;
                this.MucBoiNhieuLop.IdHangKhachHang = View.IdHangKhachHang;
                this.MucBoiNhieuLop.LoaiThanhPham = View.LoaiThPh;
                this.MucBoiNhieuLop.ToBoiRong = View.ToBoiRong;
                this.MucBoiNhieuLop.ToBoiCao = View.ToBoiCao;
                this.MucBoiNhieuLop.SoLuong = View.SoLuong;
                this.MucBoiNhieuLop.DonViTinh = View.DonViTinh;
                this.MucBoiNhieuLop.ThanhTien = View.ThanhTien;
                this.MucBoiNhieuLop.SoLopLotGiua = View.SoLopLotGiua;
                this.MucBoiNhieuLop.KieuBoi = View.KieuBoi;
                //this.MucBoiNhieuLop.IdGiayBoiGiuaChon = View.IdGiayBoiGiuaChon;
                this.MucBoiNhieuLop.GiayBoiChon = View.GiayDeBoiChon;
            }
        }
        public MucThPhBoiNhieuLop LayMucThanhPham()
        {
            CapNhatMucThanhPham();
           
            return this.MucBoiNhieuLop;
        }
    }
}
