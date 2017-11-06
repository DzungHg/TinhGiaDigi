using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;



namespace TinhGiaInClient.Presenter
{
    public class GiaInNhanhPresenter
    {
        IViewGiaInNhanh View;
        MucGiaIn MucGiaInNhanh;
        public GiaInNhanhPresenter(IViewGiaInNhanh view, MucGiaIn mucGiaIn)
        {
            View = view;
            MucGiaInNhanh = mucGiaIn;

            View.ID = MucGiaInNhanh.ID;
            View.IdMayInOrToIn = MucGiaInNhanh.IdMayIn;
            View.IdNiemYetChon = MucGiaInNhanh.IdBangGiaInNhanh;
            View.IdBaiIn = MucGiaInNhanh.IdBaiIn;
            View.IdHangKH = MucGiaInNhanh.IdHangKhachHang;
            View.SoToChay = MucGiaInNhanh.SoToChay;
            View.SoMatIn = MucGiaInNhanh.SoMatIn;               
          
        }
        public string TenHangKH (int idHangKH)
        {
            return HangKhachHang.LayTheoId(idHangKH).Ten;
        }
        public int TyLeLoiNhuanTheoHangKH()
        {
            return HangKhachHang.LayTheoId(View.IdHangKH).LoiNhuanChenhLech;
        }
        public List<NiemYetGiaInNhanh>NiemYetGiaInNhanhS()
        {
            return NiemYetGiaInNhanh.DocConDungTheoIdHangKH(View.IdHangKH);
        }
        private BangGiaBase DocBangGiaChon()
        {
            BangGiaBase kq = null;
            if (View.IdNiemYetChon > 0)
            {
                var niemYetGia = NiemYetGiaInNhanh.DocTheoId(View.IdNiemYetChon);

                kq = DanhSachBangGia.DocTheoIDvaLoai(niemYetGia.IdBangGia,
                    niemYetGia.LoaiBangGia);
            }
            return kq;
        }
        public void TrinhBayChiTietNiemYet()
        {
            if (View.IdNiemYetChon > 0)
            {
                var niemYet = NiemYetGiaInNhanh.DocTheoId(View.IdNiemYetChon);
                View.SoTrangToiDaTheoBangGia = niemYet.SoTrangToiDa;
                View.LoaiBangGiaNiemYet = niemYet.LoaiBangGia.Trim();
                View.TenLoaiBangGia = niemYet.TenLoaiBangGia;
            }
        }
        public int SoTrangToiDaTheoBangGia()
        {
            
            return BangGiaInNhanh.DocTheoId(View.IdNiemYetChon).SoTrangToiDa;
        }
        public string TenToInDigiChon()
        {
            var kq = "";
            if (View.IdMayInOrToIn > 0)
                kq = ToInMayDigi.DocTheoId(View.IdMayInOrToIn).Ten;

            return kq;
        }
      
        public int SoTrangA4 ()
        {            
            var toChayDigi = ToInMayDigi.DocTheoId(View.IdMayInOrToIn);
            int result = 0;

            result = View.SoToChay * toChayDigi.QuiA4 * View.SoMatIn;            
            return result;
        }
       
        public Dictionary<string, string> TrinhBayBangGia()
        {
            Dictionary<string, string> kq = null;
            if (this.DocBangGiaChon() != null)
            {
                if (View.LoaiBangGiaNiemYet == EnumsS.cBangGiaLuyTien)
                    kq = HoTro.TrinhBayBangGiaLuyTien(this.DocBangGiaChon().DaySoLuong,
                        this.DocBangGiaChon().DayGia, this.DocBangGiaChon().DonViTinh);

                if (View.LoaiBangGiaNiemYet == EnumsS.cBangGiaBuoc)
                    kq = HoTro.TrinhBayBangGiaBuoc(this.DocBangGiaChon().DaySoLuong,
                        this.DocBangGiaChon().DayGia, this.DocBangGiaChon().DonViTinh);
            }
            return kq;
        }
       
        public decimal GiaInNhanhTheoBang(ref decimal giaTBTrang)
        {
            decimal kq = 0;
            giaTBTrang = 0;

            if (this.DocBangGiaChon() != null)
            {

                if (View.SoTrangA4 <= 0)
                {
                    giaTBTrang = 0;
                    return kq;
                }
                var bGiaINhanh = this.DocBangGiaChon();
                if (bGiaINhanh.LoaiBangGia.Trim() == EnumsS.cBangGiaLuyTien)
                {
                    kq = TinhToan.GiaInLuyTien(bGiaINhanh.DaySoLuong, bGiaINhanh.DayGia, View.SoTrangA4);
                }
                if (bGiaINhanh.LoaiBangGia.Trim() == EnumsS.cBangGiaBuoc)
                    kq = TinhToan.GiaBuoc(bGiaINhanh.DaySoLuong, bGiaINhanh.DayGia, View.SoTrangA4);
                

                giaTBTrang = Math.Round(kq / View.SoTrangA4);
            }
            return kq;
        }
        public decimal TinhGiaCuoiCung(ref decimal giaTBTrang) //Ngưng dùng
        {            
            var giaInKetHop = new GiaInNhanhKetHopBangGia_May(View.SoTrangA4, this.DocBangGiaChon(),
                            View.SoTrangToiDaTheoBangGia, View.IdMayInOrToIn, TyLeLoiNhuanTheoHangKH());

            giaTBTrang = giaInKetHop.GiaTBTrenDonViTinh();
            return giaInKetHop.GiaBan();
        }

    
        private void CapNhatMucGiaInNhanh()
        {
            if (this.MucGiaInNhanh != null)
            {
                MucGiaInNhanh.IdBaiIn = View.IdBaiIn;
                MucGiaInNhanh.PhuongPhapIn = View.PhuongPhapIn;
                MucGiaInNhanh.IdMayIn = View.IdMayInOrToIn;
                MucGiaInNhanh.IdBangGiaInNhanh = View.IdNiemYetChon;
                MucGiaInNhanh.SoTrangIn = View.SoTrangA4;
                MucGiaInNhanh.IdHangKhachHang = View.IdHangKH;
                MucGiaInNhanh.SoToChay = View.SoToChay;
                MucGiaInNhanh.SoMatIn = View.SoMatIn;
              
                decimal giaTBTrang = 0;
                MucGiaInNhanh.TienIn = this.TinhGiaCuoiCung(ref giaTBTrang);
            }
        }
        public MucGiaIn DocMucGiaIn() 
        {
            CapNhatMucGiaInNhanh();//cập nhật đã
            return this.MucGiaInNhanh;

        }
    }
}
