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
    public class GiaTheNhuaPresenter
    {
        IViewGiaTheNhua View;
        BaiInTheNhua MucBaiInTheNhua { get; set; }

        public GiaTheNhuaPresenter(IViewGiaTheNhua view, BaiInTheNhua baiInTheNhua)
        {
            
            View = view;
            this.MucBaiInTheNhua = baiInTheNhua;
            View.ID = this.MucBaiInTheNhua.ID;
            View.TieuDe = this.MucBaiInTheNhua.TieuDe;
            View.KichThuoc = this.MucBaiInTheNhua.KichThuoc;
            View.IdBangGiaChon = this.MucBaiInTheNhua.IdBangGia;
            View.SoLuong = this.MucBaiInTheNhua.SoLuongThe;
            View.TenVatLieuBaoGom = this.MucBaiInTheNhua.TenGiayBaoGom;
            View.SoMatIn = this.MucBaiInTheNhua.SoMatIn;
            //Gắn tùy chọ
            if (this.MucBaiInTheNhua.TuyChonSChon.TuyChonS.Count > 0)
            {
                foreach (GiaTuyChonTheNhua tChon in this.MucBaiInTheNhua.TuyChonSChon.TuyChonS)
                {
                    View.IdGiaTuyChonChonS.Add(tChon.IdTuyChonTheNhua);
                }
            }
           
        }
        public string TenHangKH ()
        {
            return HangKhachHang.LayTheoId(View.IdHangKH).Ten;
        }
        public int TyLeLoiNhuanTheoHangKH()
        {
            return HangKhachHang.LayTheoId(View.IdHangKH).LoiNhuanChenhLech;
        }
        public List<BangGiaTheNhua> BangGiaTheNhuaS()
        {
            return BangGiaTheNhua.DocTatCa();
        }
        
       
        public string KhoToChay()
        {
            var kq = "";
            if (View.IdBangGiaChon > 0)
                kq = BangGiaTheNhua.DocTheoId(View.IdBangGiaChon).KhoToChay;
            return kq;
        }
             
        
        public void TrinhBayChiTietBangGia()
        {
            if (View.IdBangGiaChon >0)
            {
                var bangGia = BangGiaTheNhua.DocTheoId(View.IdBangGiaChon);
                View.NoiDungBangGia = bangGia.NoiDungBangGia;
                View.SoTheToiDaTinh = bangGia.SoTheToiDa;
               

            }
        }
        public List<GiaTuyChonModel>TuyChonSTheoBangGia()
        {//Làm laij
            List<GiaTuyChonModel> lst = null;

            var nguon = GiaTuyChonTheNhua.DocTheoIdBangGia(View.IdBangGiaChon).Select(x => new GiaTuyChonModel
            {
                IdTuyChon = x.IdTuyChonTheNhua,
                TenTuyChon = string.Format("{0}: {1:0,0.00}đ", x.TenTuyChon, x.GiaBan),
                GiaBan = (int)x.GiaBan
            });
            if (nguon != null)
                lst = nguon.ToList();

            return lst;
        }
      
      
        public decimal ThanhTien()
        {
            CapNhatBaiInTheNhua();
            return this.MucBaiInTheNhua.ThanhTien();
        }
        public string GiaTBInfo()
        {
            CapNhatBaiInTheNhua();
            return string.Format("{0:0,0.00}đ/Thẻ", this.MucBaiInTheNhua.GiaTBThe);
        }
        private void CapNhatTuyChonKemTheo()
        {
            //Xóa hết những gì có trước đó đã
            this.MucBaiInTheNhua.TuyChonSChon.TuyChonS.Clear();
            //Cập nhật lại
            
            if (View.IdGiaTuyChonChonS.Count > 0)
            {
                foreach (int idTuyChon in View.IdGiaTuyChonChonS)
                {
                    this.MucBaiInTheNhua.TuyChonSChon.TuyChonS.Add(GiaTuyChonTheNhua.DocTheoId(View.IdBangGiaChon, idTuyChon));

                }
                
            }
            
        }
        private void CapNhatBaiInTheNhua()
        {
            this.MucBaiInTheNhua.ID = View.ID;
            this.MucBaiInTheNhua.SoMatIn = View.SoMatIn;
            this.MucBaiInTheNhua.IdBangGia = View.IdBangGiaChon;
            this.MucBaiInTheNhua.TieuDe = View.TieuDe;
            this.MucBaiInTheNhua.KichThuoc = View.KichThuoc;
            this.MucBaiInTheNhua.SoLuongThe = View.SoLuong;
            CapNhatTuyChonKemTheo();
        }
        public BaiInTheNhua DocBaiInTheNhua()
        {
            CapNhatBaiInTheNhua();
            return this.MucBaiInTheNhua;
        }

    }
}
