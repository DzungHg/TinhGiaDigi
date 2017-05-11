using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;



namespace TinhGiaInClient.Presenter
{
    public class GiaInPresenter
    {
        IViewGiaIn View;
        public GiaInPresenter(IViewGiaIn view)
        {
            View = view;
        }
        public string TenHangKH (int idHangKH)
        {
            return HangKhachHang.LayTheoId(idHangKH).Ten;
        }
        public Dictionary<int, string>BangGiaInNhanhS()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            foreach (BangGiaInNhanh bg in BangGiaInNhanh.DocTheoIdHangKH(View.IdHangKH))
            {
                dict.Add(bg.ID, bg.TenBangGia);
            }
            return dict;
        }
        public Dictionary<int, string> ToInDigiS()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            foreach (ToChayDigi to in ToChayDigi.LayTatCa())
            {
                dict.Add(to.ID, to.Ten);
            }
            return dict;
        }
        public int SoTrangA4 ()
        {
            var idToChayDigiChon = this.ToInDigiS().FirstOrDefault(x => x.Value == View.TenInDigiChon).Key;
            var toChayDigi = ToChayDigi.LayTheoId(idToChayDigiChon);
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
        public decimal TinhGiaInNhanh(string tenBangGiaInNhanh, int soTrangA4, ref decimal giaTBTrang)
        {
            decimal result = 0;
            var idBangGia = this.BangGiaInNhanhS().FirstOrDefault(x => x.Value == tenBangGiaInNhanh).Key;
            if (idBangGia <= 0 || soTrangA4 <= 0)
            {
                giaTBTrang = 0;
                return result;
            }

            result = BangGiaInNhanh.TinhGiaInNhanh(BangGiaInNhanh.LayGiayTheoId(idBangGia), soTrangA4);
            giaTBTrang = result / soTrangA4;
            return result;
        }
        public Dictionary<string, string> TrinhBayBangGia(string khoangSoLuong, string khoangGia, string donViTinh)
        {
            var idBangGia = this.BangGiaInNhanhS().FirstOrDefault(x => x.Value == View.TenBangGiaChon).Key;

            int i;//For index

            Dictionary<string, string> st_dict = new Dictionary<string, string>();
            var tmp_st_arrKey = khoangSoLuong.Split(';');
            var tmp_st_arrGia = khoangGia.Split(';');
            int soDauTien = 1;
            //Biến đổi số lượng
            int soTam = 0;
            for (i = 0; i < tmp_st_arrKey.Length - 1; i++)
            {
                soTam = int.Parse(tmp_st_arrKey[i]);
                tmp_st_arrKey[i] = string.Format("{0} - {1} " + donViTinh, soDauTien, soTam);
                soDauTien = soTam + 1;

            }
            //Biến đổi tiếp key của Dict

            for (i = 0; i < tmp_st_arrKey.Length; i++)
            {
                st_dict.Add(tmp_st_arrKey[i], tmp_st_arrGia[i]);
            }
            return st_dict;
        }
    }
}
