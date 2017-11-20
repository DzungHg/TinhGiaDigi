using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;
using TinhGiaInClient.Common;



namespace TinhGiaInClient.Presenter
{
    public class SoSanhGiaInNhanhPresenter
    {
        IViewSoSanhGiaInNhanh View;
        public SoSanhGiaInNhanhPresenter(IViewSoSanhGiaInNhanh view)
        {
            View = view;
            //Đưa dãy số lượng tính thử
            
        }
       
       
       public List<NiemYetGiaInNhanh>NiemYetGiaInNhanhA()
        {
           return NiemYetGiaInNhanh.DocTatCa();
        }
       public List<NiemYetGiaInNhanh> NiemYetGiaInNhanhB()
       {
           return NiemYetGiaInNhanh.DocTatCa();
       }
        public List<ToInMayDigi>ToChayDigiS()
        {
            return ToInMayDigi.DocTatCa();
        }
       
        public void TrinhBayChiTietNiemYet()
        {
            if (View.IdNiemYetChonA > 0)
            {
                var niemYet = NiemYetGiaInNhanh.DocTheoId(View.IdNiemYetChonA);
                
                View.LoaiBangGiaNiemYetA = niemYet.LoaiBangGia.Trim();
                View.DienGiaiNiemYetA = niemYet.DienGiai;
                
            }
            if (View.IdNiemYetChonB > 0)
            {
                var niemYet = NiemYetGiaInNhanh.DocTheoId(View.IdNiemYetChonB);

                View.LoaiBangGiaNiemYetB = niemYet.LoaiBangGia.Trim();
                View.DienGiaiNiemYetB = niemYet.DienGiai;

            }

        }
      
       
        private BangGiaBase DocBangGiaChon(int idNiemYetChon)
        {
            BangGiaBase kq = null;
            if (idNiemYetChon > 0)
            {
                var niemYetGia = NiemYetGiaInNhanh.DocTheoId(idNiemYetChon);
                
                kq = DanhSachBangGia.DocTheoIDvaLoai(niemYetGia.IdBangGia,
                    niemYetGia.LoaiBangGia);
            }
            return kq;
        }
        public Dictionary<string, string> TrinhBayBangGia(string loaiBangGiaNiemYet, int idNiemYetChon)
        {
            Dictionary<string, string> kq = null;
            if (this.DocBangGiaChon(idNiemYetChon) == null)
                return kq;
            switch (loaiBangGiaNiemYet.Trim())
            {
                case Global.cBangGiaLuyTien:

                    kq = HoTro.TrinhBayBangGiaLuyTien(this.DocBangGiaChon(idNiemYetChon).DaySoLuong,
                        this.DocBangGiaChon(idNiemYetChon).DayGia, this.DocBangGiaChon(idNiemYetChon).DonViTinh);
                    break;

                case Global.cBangGiaBuoc:

                    kq = HoTro.TrinhBayBangGiaBuoc(this.DocBangGiaChon(idNiemYetChon).DaySoLuong,
                        this.DocBangGiaChon(idNiemYetChon).DayGia, this.DocBangGiaChon(idNiemYetChon).DonViTinh);
                    break;
                case Global.cBangGiaGoi:

                    kq = HoTro.TrinhBayBangGiaGoi(this.DocBangGiaChon(idNiemYetChon).DaySoLuong,
                        this.DocBangGiaChon(idNiemYetChon).DayGia, this.DocBangGiaChon(idNiemYetChon).DonViTinh);
                    break;
            }
            return kq;
        }
     
        
        public decimal GiaInNhanhTheoBang(ref decimal giaTBTrang)
        {
            
            decimal kq = 0;
            giaTBTrang = 0;
            /*
            if (this.DocBangGiaChon() != null)
            {
                
                if ( View.DaySoLuongTrangA4 <= 0)
                {
                    giaTBTrang = 0;
                    return kq;
                }
                var bGiaINhanh = this.DocBangGiaChon();
                if (bGiaINhanh.LoaiBangGia.Trim() == EnumsS.cBangGiaLuyTien)
                {
                    kq = TinhToan.GiaInLuyTien(bGiaINhanh.DaySoLuong, bGiaINhanh.DayGia, View.DaySoLuongTrangA4);
                }
                if (bGiaINhanh.LoaiBangGia.Trim() == EnumsS.cBangGiaBuoc)
                    kq = TinhToan.GiaBuoc(bGiaINhanh.DaySoLuong, bGiaINhanh.DayGia, View.DaySoLuongTrangA4);
                else
                    

                giaTBTrang = Math.Round(kq / View.DaySoLuongTrangA4);
            }
             */
            return kq;
        }
        public decimal GiaInNhanh(int iDNiemYetChon, int soTrangA4, BangGiaBase bGiaInNhanh)
        {
            decimal kq = 0;
                                    
            
            if (bGiaInNhanh == null || soTrangA4 < 0)                
            {
                return 0;
            }
            //vượt làm tiếp
            switch (bGiaInNhanh.LoaiBangGia.Trim())
            {
                case Global.cBangGiaLuyTien:

                    kq = TinhToan.GiaInLuyTien(bGiaInNhanh.DaySoLuong, bGiaInNhanh.DayGia, soTrangA4);
                    break;
                case Global.cBangGiaBuoc:
                    kq = TinhToan.GiaBuoc(bGiaInNhanh.DaySoLuong, bGiaInNhanh.DayGia, soTrangA4);
                    break;
                case Global.cBangGiaGoi:
                    kq = TinhToan.GiaGoi(bGiaInNhanh.DaySoLuong, bGiaInNhanh.DayGia, soTrangA4);
                    break;
            }           
             
            return kq;
        }
        public List<string> KetQuaTinhA()
        {//Giống dãy số lượng nên AB giống nhau
            
            var lst = new List<string>();
            var arrySoLuongStr = View.DaySoLuongTrangA4.Split(';');
            
            string kqTinh = "";
            //Tạo giá:
            var bGiaIn = this.DocBangGiaChon(View.IdNiemYetChonA);
            //thử giới hạn
            var j =  arrySoLuongStr.Length;
            for (int i = 0; i <j; i++)
            {//Cấu hình tổng; giá/trang
                kqTinh = string.Format("{0:0,0} / {1:0,0}đ", this.GiaInNhanh(View.IdNiemYetChonA, int.Parse(arrySoLuongStr[i]), bGiaIn),
                    this.GiaInNhanh(View.IdNiemYetChonA, int.Parse(arrySoLuongStr[i]), bGiaIn) /  int.Parse(arrySoLuongStr[i] ));
                lst.Add(kqTinh);
                
            }
            return lst;
            //Tính bị chậm
        }
        public List<string> KetQuaTinhB()
        {//Giống dãy số lượng nên AB giống nhau
            var lst = new List<string>();
            var arrySoLuongStr = View.DaySoLuongTrangA4.Split(';');
            string kqTinh = "";
            //Tạo giá:
            var bGiaIn = this.DocBangGiaChon(View.IdNiemYetChonB);
            //thử giới hạn
            var j = arrySoLuongStr.Length;
            for (int i = 0; i < j; i++)
            {
                kqTinh = string.Format("{0:0,0} / {1:0,0}đ", this.GiaInNhanh(View.IdNiemYetChonB, int.Parse(arrySoLuongStr[i]), bGiaIn),
                   this.GiaInNhanh(View.IdNiemYetChonB, int.Parse(arrySoLuongStr[i]), bGiaIn) / int.Parse(arrySoLuongStr[i]));
                lst.Add(kqTinh);

            }
            return lst;
        }
        public Dictionary<int, List<string>> TrinhBayKetQua()
        {
            var dict = new Dictionary<int, List<string>>();
            List<string> lst;           
            var arrySoLuongStr = View.DaySoLuongTrangA4.Split(';');
            //thử giới hạn
            var j = arrySoLuongStr.Length;
            for (int i = 0; i < j; i++)
            {                
                lst = new List<string>();
                lst.Add(string.Format("{0:0,0}",arrySoLuongStr[i]));
                lst.Add(string.Format("{0}", this.KetQuaTinhA()[i]));
                lst.Add(string.Format("{0}", this.KetQuaTinhB()[i]));
                dict.Add(i+1, lst);
            }
            return dict;
        }
    }
}
