using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;



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
       
        public Dictionary<int, string>BangGiaInNhanhS()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            foreach (BangGiaInNhanh bg in BangGiaInNhanh.DocTatCa())
            {
                dict.Add(bg.ID, bg.TenBangGia);
            }
            return dict;
        }
        public List<ToChayDigi>ToChayDigiS()
        {
            return ToChayDigi.DocTatCa();
        }
        public int TyLeLoiNhuanTheoHangKH()
        {
            return HangKhachHang.LayTheoId(View.IdHangKH).LoiNhuanChenhLech;
        }
        public int SoTrangToiDaTheoBangGia()
        {
            var idBangGia = BangGiaInNhanhS().FirstOrDefault(x=> x.Value == View.TenBangGiaChon).Key;
            return BangGiaInNhanh.DocTheoId(idBangGia).SoTrangToiDa;
        }
        public int SoA4TheoToInDigi()
        {
            return ToChayDigi.DocTheoId(View.IdToInDigiChon).QuiA4;
        }
      
        public int SoTrangA4 ()
        {            
            var toChayDigi = ToChayDigi.DocTheoId(View.IdToInDigiChon);
            int result = 0;
            switch (View.KieuIn)
            {
                case (int)Enumss.PrintSides.FourFour:
                case (int)Enumss.PrintSides.FourOne:
                case (int)Enumss.PrintSides.OneOne:
                    result = toChayDigi.QuiA4 * View.SoToChay * 2;
                    break;
                case (int)Enumss.PrintSides.FourZero:
                case (int)Enumss.PrintSides.OneZero:
                    result = toChayDigi.QuiA4 * View.SoToChay * 1;
                    break;
            }
            return result;
        }
       
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
        }
        public decimal GiaInNhanhTheoBang(ref decimal giaTBTrang)
        {
            decimal result = 0;
            var idBangGia = this.BangGiaInNhanhS().FirstOrDefault(x => x.Value == View.TenBangGiaChon).Key;
            if (idBangGia <= 0 || View.SoTrangA4 <= 0)
            {
                giaTBTrang = 0;
                return result;
            }
            var bGiaINhanh = BangGiaInNhanh.DocTheoId(idBangGia);
            result = TinhToan.GiaInNhanhTheoBang(bGiaINhanh.DaySoLuong, bGiaINhanh.DayGia, View.SoTrangA4);
            giaTBTrang = result / View.SoTrangA4;
            return result;
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
                var toChayDigi = ToChayDigi.DocTheoId(View.IdToInDigiChon);
                var giaInTheoToDiGi = new GiaInMayDigi(toChayDigi, View.SoTrangA4,
                    this.TyLeLoiNhuanTheoHangKH(), (int)Enumss.MauIn.BonMau);
                result = giaInTheoToDiGi.ThanhTienCoBan();
                giaTBTrang = result / View.SoTrangA4;
            }
            return result;
        }
    }
}
