using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Common;
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
            View.IdNiemYetChon = MucGiaInNhanh.IdNiemYetGiaInNhanh;
            View.ChoTinhGopTrang = MucGiaInNhanh.ChoTinhGopTrang;
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
                View.DienGiaiNiemYet = niemYet.DienGiai;
                View.ChoTinhGopTrang = niemYet.DuocGomTrang;
            }
        }
        public int SoTrangToiDaTheoBangGia()
        {
            
            return NiemYetGiaInNhanh.DocTheoId(View.IdNiemYetChon).SoTrangToiDa;
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
                if (View.LoaiBangGiaNiemYet == Global.cBangGiaLuyTien)
                    kq = HoTro.TrinhBayBangGiaLuyTien(this.DocBangGiaChon().DaySoLuong,
                        this.DocBangGiaChon().DayGia, this.DocBangGiaChon().DonViTinh);

                if (View.LoaiBangGiaNiemYet == Global.cBangGiaBuoc)
                    kq = HoTro.TrinhBayBangGiaBuoc(this.DocBangGiaChon().DaySoLuong,
                        this.DocBangGiaChon().DayGia, this.DocBangGiaChon().DonViTinh);

                if (View.LoaiBangGiaNiemYet == Global.cBangGiaGoi)
                    kq = HoTro.TrinhBayBangGiaGoi(this.DocBangGiaChon().DaySoLuong,
                        this.DocBangGiaChon().DayGia, this.DocBangGiaChon().DonViTinh);
            }
            return kq;
        }
       
        public decimal GiaInNhanhTheoBang(ref decimal giaTBTrang)//Chưa xài tới
        {
            decimal kq = 0;
            giaTBTrang = 0;
            if (this.DocBangGiaChon() == null || View.SoTrangA4 <= 0)
            {
                return kq;
            }
            //Vượt tiép
           
                var bGiaInNhanh = this.DocBangGiaChon();
                switch (bGiaInNhanh.LoaiBangGia.Trim())
                { 
                    case Global.cBangGiaLuyTien:                
                        kq = TinhToan.GiaInLuyTien(bGiaInNhanh.DaySoLuong, bGiaInNhanh.DayGia, View.SoTrangA4);
                        break;
                    case Global.cBangGiaBuoc:
                        kq = TinhToan.GiaBuoc(bGiaInNhanh.DaySoLuong, bGiaInNhanh.DayGia, View.SoTrangA4);
                        break;
                    case Global.cBangGiaGoi:
                         kq = TinhToan.GiaGoi(bGiaInNhanh.DaySoLuong, bGiaInNhanh.DayGia, View.SoTrangA4);
                        break;
                }

                giaTBTrang = Math.Round(kq / View.SoTrangA4);
            
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
                MucGiaInNhanh.IdNiemYetGiaInNhanh = View.IdNiemYetChon;
                MucGiaInNhanh.ChoTinhGopTrang = View.ChoTinhGopTrang;
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
