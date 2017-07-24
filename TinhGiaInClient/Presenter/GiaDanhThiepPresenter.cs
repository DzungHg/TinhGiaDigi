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
    public class GiaDanhThiepPresenter
    {
        IViewGiaDanhThiep View;
        BaiInDanhThiep MucBaiInDThiep;
        
        public GiaDanhThiepPresenter(IViewGiaDanhThiep view, BaiInDanhThiep baiInDThiep)
        {
            View = view;
            this.MucBaiInDThiep = baiInDThiep;

            View.ID = this.MucBaiInDThiep.ID;
            View.TieuDe = this.MucBaiInDThiep.TieuDe;
            View.IdBangGiaChon = this.MucBaiInDThiep.IdBangGia;
            View.SoLuong = this.MucBaiInDThiep.SoLuongHop;
            View.GiayDeInChon = this.MucBaiInDThiep.ChonGiayIn;
            //Gắn tùy chọ
            if (this.MucBaiInDThiep.TuyChonSChon.TuyChonS.Count > 0)
            {
                foreach (GiaTuyChonDanhThiep tChon in this.MucBaiInDThiep.TuyChonSChon.TuyChonS)
                {
                    View.IdGiaTuyChonChonS.Add(tChon.IdTuyChonDanhThiep);
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
        /*public Dictionary<int, string>BangGiaDanhThiepS()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            foreach (BangGiaDanhThiep bg in BangGiaDanhThiep.DocTheoIdHangKH(View.IdHangKH))
            {
                dict.Add(bg.ID, bg.Ten);
            }
            return dict;
        }*/
        public List<BangGiaDanhThiep> BangGiaDanhThiepS()
        {
            return BangGiaDanhThiep.DocTheoIdHangKH(View.IdHangKH);
        }
       
        public int SoHopToiDaTheoBangGia()
        {
            
            return BangGiaDanhThiep.DocTheoId(View.IdBangGiaChon).SoHopToiDa;
        }
        public int SoDanhThiepTrenMoiHop()
        {
            return BangGiaDanhThiep.DocTheoId(View.IdBangGiaChon).SoDanhThiepTrenHop;
        }
        public string KhoToChay()
        {
            if (View.IdBangGiaChon <= 0)
                return "";

            return BangGiaDanhThiep.DocTheoId(View.IdBangGiaChon).KhoToChay;
        }
        
        public List<string> NoiDungBangGia()
        {
            var lst = new List<string>();
            if (View.IdBangGiaChon > 0)    
                lst = BangGiaDanhThiep.DocTheoId(View.IdBangGiaChon).NoiDungBangGia.Split(';').ToList();
            
            return lst;
        }
        public decimal GiaDanhThiepTheoBang()
        {
            return this.MucBaiInDThiep.GiaDanhThiepTheoBang();
        }
        
        public string TenGiayChon()
        {
            var ketQua = "";
            if (View.GiayDeInChon == null)
                ketQua = BangGiaDanhThiep.DocTheoId(View.IdBangGiaChon).GiayBaoGom;
            else
            {
                ketQua = Giay.DocGiayTheoId(View.GiayDeInChon.IdGiay).TenGiay;
            }
            
            return ketQua;
        }
        public decimal TienGiay()
        {
            var result = 0m;
            if (View.GiayDeInChon == null)
                return result;
            else
                result = View.GiayDeInChon.ThanhTienGiay;

            return result;
        }
        public decimal ThanhTien()
        {
            CapNhatMucBaiIn();
            return this.MucBaiInDThiep.ThanhTien();
        }
        public string GiaTBInfo()
        {
            CapNhatMucBaiIn();
            return string.Format("{0:0,0.00}đ/hộp", this.MucBaiInDThiep.GiaTBHop);
        }
        public List<GiaTuyChonModel> TuyChonSTheoBangGia()
        {//Làm laij
            List<GiaTuyChonModel> lst = null;

            var nguon = GiaTuyChonDanhThiep.DocTheoIdBangGia(View.IdBangGiaChon).Select(x => new GiaTuyChonModel
            {
                IdTuyChon = x.IdTuyChonDanhThiep,
                TenTuyChon = string.Format("{0}: {1:0,0.00}đ", x.TenTuyChon, x.GiaBan),
                GiaBan = (int)x.GiaBan
            });
            if (nguon != null)
                lst = nguon.ToList();

            return lst;
        }
        private void CapNhatTuyChonKemTheo()
        {
            //Xóa hết những gì có trước đó đã
            this.MucBaiInDThiep.TuyChonSChon.TuyChonS.Clear();
            //Cập nhật lại

            if (View.IdGiaTuyChonChonS.Count > 0)
            {
                foreach (int idTuyChon in View.IdGiaTuyChonChonS)
                {
                    this.MucBaiInDThiep.TuyChonSChon.TuyChonS.Add(GiaTuyChonDanhThiep.DocTheoId(View.IdBangGiaChon, idTuyChon));

                }

            }

        }
        private void CapNhatMucBaiIn()
        {
            this.MucBaiInDThiep.ID = View.ID;
            this.MucBaiInDThiep.IdBangGia = View.IdBangGiaChon;
            this.MucBaiInDThiep.TieuDe = View.TieuDe;
            this.MucBaiInDThiep.SoLuongHop = View.SoLuong;
            this.MucBaiInDThiep.ChonGiayIn = View.GiayDeInChon;
            this.MucBaiInDThiep.KichThuoc = View.KichThuoc;
            this.MucBaiInDThiep.TenGiayIn = View.TenGiayChon;
            //Gắn tùy chọ
            CapNhatTuyChonKemTheo();

        }
        public BaiInDanhThiep DocBaiInDanhThiep()
        {
            CapNhatMucBaiIn();

            return this.MucBaiInDThiep;
        }
    }
}
