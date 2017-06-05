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
            View.IdBangGiaInNhanhChon = MucGiaInNhanh.IdBangGiaInNhanh;
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
        public List<BangGiaInNhanh>BangGiaInNhanhS()
        {
            return BangGiaInNhanh.DocConDungTheoIdHangKH(View.IdHangKH);
        }
        public int SoTrangToiDaTheoBangGia()
        {
            
            return BangGiaInNhanh.DocTheoId(View.IdBangGiaInNhanhChon).SoTrangToiDa;
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
            Dictionary<string, string> st_dict = new Dictionary<string, string>();
            
            
            if (View.IdBangGiaInNhanhChon > 0)//có bản giá
            {
                var bGia = BangGiaInNhanh.DocTheoId(View.IdBangGiaInNhanhChon);
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

            if (View.IdBangGiaInNhanhChon <= 0 || View.SoTrangA4 <= 0)
            {
                giaTBTrang = 0;
                return result;
            }
            var bGiaINhanh = BangGiaInNhanh.DocTheoId(View.IdBangGiaInNhanhChon);
            result = TinhToan.GiaInNhanhTheoBang(bGiaINhanh.DaySoLuong, bGiaINhanh.DayGia, View.SoTrangA4);
            giaTBTrang = result / View.SoTrangA4;
            return result;
        }
        public decimal TinhGiaCuoiCung(ref decimal giaTBTrang)
        {            
           /* decimal result = 0;
            if (View.SoTrangToiDaTheoBangGia <= 0)
            {
                result = GiaInNhanhTheoBang(ref giaTBTrang);
                return result; //ket luon
            }
            //Vượt tiếp
            if (View.SoTrangA4 <= View.SoTrangToiDaTheoBangGia)
                
            {
                result = GiaInNhanhTheoBang(ref giaTBTrang);
            }
            else
            {
                var toChayDigi = ToInMayDigi.DocTheoId(View.IdToInDigiChon);
                var giaInTheoToDiGi = new GiaInMayDigi(toChayDigi, View.SoTrangA4,
                    View.TyLeLoiNhuanTheoHangKH, MauIn.BonMau);
                result = giaInTheoToDiGi.ThanhTien_In();
                giaTBTrang = result / View.SoTrangA4;
            }
            */
            var giaInKetHop = new GiaInNhanhKetHopBangGia_May(View.SoTrangA4, View.IdBangGiaInNhanhChon,
                            View.IdMayInOrToIn, TyLeLoiNhuanTheoHangKH());

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
                MucGiaInNhanh.IdBangGiaInNhanh = View.IdBangGiaInNhanhChon;
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
