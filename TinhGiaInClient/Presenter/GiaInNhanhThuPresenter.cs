using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;
using TinhGiaInClient.Common;
using TinhGiaInClient.Common.Enum;



namespace TinhGiaInClient.Presenter
{
    public class GiaInNhanhThuPresenter
    {
        IViewGiaInNhanhThu View;
        public GiaInNhanhThuPresenter(IViewGiaInNhanhThu view)
        {
            View = view;
            View.SoToChay = 50;
        }
       
        /*public Dictionary<int, string>BangGiaInNhanhS()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            foreach (BangGiaInNhanh bg in BangGiaInNhanh.DocTheoIdHangKH(View.IdHangKH))
            {
                dict.Add(bg.ID, bg.TenBangGia);
            }
            return dict;
        }*/
       public List<NiemYetGiaInNhanh>NiemYetGiaInNhanhS()
        {
           return NiemYetGiaInNhanh.DocTheoIdHangKH(View.IdHangKH);
        }
        public List<ToInMayDigi>ToChayDigiS()
        {
            return ToInMayDigi.DocTatCa();
        }
        public int TyLeLoiNhuanTheoHangKH()
        {
            return HangKhachHang.LayTheoId(View.IdHangKH).LoiNhuanChenhLech;
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
        
        public int SoA4TheoToInDigi()
        {
            return ToInMayDigi.DocTheoId(View.IdToInDigiChon).QuiA4;
        }
      
        public int SoTrangA4 ()
        {            
            var toChayDigi = ToInMayDigi.DocTheoId(View.IdToInDigiChon);
            int result = 0;
            switch (View.KieuIn)
            {
                case PrintSideColorS.FourFour:
                case PrintSideColorS.FourOne:
                case PrintSideColorS.OneOne:
                    result = toChayDigi.QuiA4 * View.SoToChay * 2;
                    break;
                case PrintSideColorS.FourZero:
                case PrintSideColorS.OneZero:
                    result = toChayDigi.QuiA4 * View.SoToChay * 1;
                    break;
            }
            return result;
        }
        private BangGiaBase DocBangGiaChon()
        {
            BangGiaBase kq = null;
            if (View.IdNiemYetChon >0 )
            {
                var niemYetGia = NiemYetGiaInNhanh.DocTheoId(View.IdNiemYetChon);
                
                kq = DanhSachBangGia.DocTheoIDvaLoai(niemYetGia.IdBangGia,
                    niemYetGia.LoaiBangGia);
            }
            return kq;
        }
        public Dictionary<string, string> TrinhBayBangGia()
        {
            Dictionary<string, string> kq = null;
            if (this.DocBangGiaChon() != null)
            {
                if (View.LoaiBangGiaNiemYet.Trim() == Global.cBangGiaLuyTien)
                    kq = HoTro.TrinhBayBangGiaLuyTien(this.DocBangGiaChon().DaySoLuong,
                        this.DocBangGiaChon().DayGia, this.DocBangGiaChon().DonViTinh);

                if (View.LoaiBangGiaNiemYet.Trim() == Global.cBangGiaBuoc)
                    kq = HoTro.TrinhBayBangGiaBuoc(this.DocBangGiaChon().DaySoLuong,
                        this.DocBangGiaChon().DayGia, this.DocBangGiaChon().DonViTinh);

                if (View.LoaiBangGiaNiemYet.Trim() == Global.cBangGiaGoi)
                    kq = HoTro.TrinhBayBangGiaGoi(this.DocBangGiaChon().DaySoLuong,
                        this.DocBangGiaChon().DayGia, this.DocBangGiaChon().DonViTinh);
            }
            return kq;
        }
       /*
        public Dictionary<string, string> TrinhBayBangGia()
        {
            Dictionary<string, string> st_dict = new Dictionary<string, string>();
            
            var idBangGia = this.BangGiaInNhanhS().FirstOrDefault(x => x.Value == View.TenBangGiaChon).Key;
            if (idBangGia > 0)//có bản giá
            {
                var bGia = BangGiaInNhanh.DocTheoId(idBangGia);
                var donViTinh = "Trang A4";
                var khoangSoLuong = bGia.DaySoLuong;
                var khoangGia = bGia.DayGia;
                int i;//For index


                var tmp_st_arrKey = khoangSoLuong.Split(';');
                var tmp_st_arrGia = khoangGia.Split(';');
                int soDauTien = 1;
                //Biến đổi số lượng
                var soLuongTam = 0;
                for (i = 0; i < tmp_st_arrKey.Length - 1; i++)
                {
                    soLuongTam += int.Parse(tmp_st_arrKey[i + 1]) - int.Parse(tmp_st_arrKey[i]);
                    tmp_st_arrKey[i] = string.Format("{0} - {1} " + donViTinh, soDauTien, soLuongTam);
                    soDauTien = soLuongTam + 1;

                }
                //Biến đổi tiếp key của Dict

                for (i = 0; i < tmp_st_arrKey.Length; i++)
                {
                    st_dict.Add(tmp_st_arrKey[i], tmp_st_arrGia[i]);
                }
            }
            return st_dict;
        }*/
        public decimal GiaInNhanhTheoBang(ref decimal giaTBTrang)
        {
            decimal kq = 0;
            giaTBTrang = 0;
            
            if (this.DocBangGiaChon() != null)
            {
                
                if ( View.SoTrangA4 <= 0)
                {
                    giaTBTrang = 0;
                    return kq;
                }
                var bGiaINhanh = this.DocBangGiaChon();
                if (bGiaINhanh.LoaiBangGia.Trim() == Global.cBangGiaLuyTien)
                {
                    kq = TinhToan.GiaInLuyTien(bGiaINhanh.DaySoLuong, bGiaINhanh.DayGia, View.SoTrangA4);
                }
                if (bGiaINhanh.LoaiBangGia.Trim() == Global.cBangGiaBuoc)
                    kq = TinhToan.GiaBuoc(bGiaINhanh.DaySoLuong, bGiaINhanh.DayGia, View.SoTrangA4);

                if (bGiaINhanh.LoaiBangGia.Trim() == Global.cBangGiaGoi)
                    kq = TinhToan.GiaGoi(bGiaINhanh.DaySoLuong, bGiaINhanh.DayGia, View.SoTrangA4);
                    

                giaTBTrang = Math.Round(kq / View.SoTrangA4);
            }
            return kq;
        }
        public decimal TinhGiaCuoiCung(ref decimal giaTBTrang)
        {            
            decimal result = 0;

            if (View.SoTrangToiDaTheoBangGia <= 0)
            {
                result = GiaInNhanhTheoBang(ref giaTBTrang);
                return result; //ket luon
            }
            //Vượt tiếp
            if ( View.SoTrangA4 <= View.SoTrangToiDaTheoBangGia)                
            {
                result = GiaInNhanhTheoBang(ref giaTBTrang);
            } else //Vượt ngoài giới hạn
            {
                var toChayDigi = ToInMayDigi.DocTheoId(View.IdToInDigiChon);
                var giaInTheoToDiGi = new GiaInMayDigi(toChayDigi, View.SoTrangA4,
                    this.TyLeLoiNhuanTheoHangKH(), MauInS.BonMau);
                result = giaInTheoToDiGi.ThanhTienCoBan();
                giaTBTrang = result / View.SoTrangA4;
            }
            return result;
        }
    }
}
