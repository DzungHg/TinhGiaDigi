using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;



namespace TinhGiaInClient.Presenter
{
    public class GiaDanhThiepPresenter
    {
        IViewGiaDanhThiep View;
        
        public GiaDanhThiepPresenter(IViewGiaDanhThiep view)
        {
            View = view;
            View.SoLuong = 1;

        
           
        }
        public string TenHangKH ()
        {
            return HangKhachHang.LayTheoId(View.IdHangKH).Ten;
        }
        public int TyLeLoiNhuanTheoHangKH()
        {
            return HangKhachHang.LayTheoId(View.IdHangKH).LoiNhuanChenhLech;
        }
        public Dictionary<int, string>BangGiaDanhThiepS()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            foreach (BangGiaDanhThiep bg in BangGiaDanhThiep.DocTheoIdHangKH(View.IdHangKH))
            {
                dict.Add(bg.ID, bg.Ten);
            }
            return dict;
        }
        public int IdBangGiaChon()
        {
            var result = 0;
            if (!string.IsNullOrEmpty(View.TenBangGiaChon))
                result = this.BangGiaDanhThiepS().FirstOrDefault(x => x.Value == View.TenBangGiaChon).Key;
            return result;
        }
        public int SoHopToiDaTheoBangGia()
        {
            var idBangGia = BangGiaDanhThiepS().FirstOrDefault(x=> x.Value == View.TenBangGiaChon).Key;
            return BangGiaDanhThiep.DocTheoId(idBangGia).SoHopToiDa;
        }
        public string KhoToChay()
        {
            if (this.IdBangGiaChon() <= 0)
                return "";

            return BangGiaDanhThiep.DocTheoId(this.IdBangGiaChon()).KhoToChay;
        }
       
        public List<string> NoiDungBangGia()
        {
            var lst = new List<string>();
            var idBangGia = this.BangGiaDanhThiepS().FirstOrDefault(x => x.Value == View.TenBangGiaChon).Key;
            lst = BangGiaDanhThiep.DocTheoId(idBangGia).NoiDungBangGia.Split(';').ToList();
            
            return lst;
        }
        public decimal GiaDanhThiepTheoBang()
        {
            decimal result = 0;
            var idBangGia = this.BangGiaDanhThiepS().FirstOrDefault(x => x.Value == View.TenBangGiaChon).Key;
            if (idBangGia <= 0 || View.SoLuong <= 0)
            {                
                return result;
            }
            var bGiaINhanh = BangGiaDanhThiep.DocTheoId(idBangGia);
            result = TinhToan.GiaDanhThiep(bGiaINhanh.DaySoLuong, bGiaINhanh.DayGia, View.SoLuong);
            
            return result;
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
            return DocBaiInDanhThiep().ThanhTien;
        }
        public string GiaTBInfo()
        {
            return string.Format("{0:0,0.00}đ/hộp", this.DocBaiInDanhThiep().GiaTBHop);
        }
        public BaiInDanhThiep DocBaiInDanhThiep()
        {
            var baiInDanhThiep = new BaiInDanhThiep(View.IdBangGiaChon, View.TenBangGiaChon,
                View.KichThuoc, View.SoLuong);
           
            //Điền thêm dữ liệu
            baiInDanhThiep.IdBangGia = View.IdBangGiaChon;
            baiInDanhThiep.TenBangGia = View.TenBangGiaChon;
            baiInDanhThiep.TenGiayIn = this.TenGiayChon();
            if (BangGiaDanhThiep.DocTheoId(View.IdBangGiaChon).InHaiMat)
                baiInDanhThiep.SoMatIn = 2;
            else
                baiInDanhThiep.SoMatIn = 1;
            baiInDanhThiep.KichThuoc = View.KichThuoc;
            baiInDanhThiep.SoLuongHop = View.SoLuong;            
            baiInDanhThiep.TienIn = this.GiaDanhThiepTheoBang();
            baiInDanhThiep.TienGiay = this.TienGiay();

            if (View.TinhTrangForm == FormStateS.Edit)
                baiInDanhThiep.ID = View.ID; //Do sửa lấy I di cũ
           
            return baiInDanhThiep;
        }
    }
}
