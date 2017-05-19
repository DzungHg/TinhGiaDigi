using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TinhGiaInClient.Model
{
    public class BaiIn
    {
        private static int _lastId = 0;
        public int ID
        {
            get;
            set;
        }
        public string TieuDe{ get; set; }
        public string DienGiai { get; set; }
        public int SoLuong { get; set; }
        public string DonVi { get; set; }
        public int IdHangKH { get; set; }
        public string TenHangKH { get; set; }
        public CauHinhSanPham CauHinhSP { get; set; }
        public GiayDeIn GiayDeInIn { get; set; }
        private List<MucTinGiaIn> _giaInS;
        public List<MucTinGiaIn> GiaInS
        {
            get { return _giaInS; }
            set { _giaInS = value;}
        
       }
        List<MucThanhPham> _mucTPs;
        public List<MucThanhPham> ThanhPhamS 
        {
            get { return _mucTPs; }
            set { _mucTPs = value; }
        }
        public bool CoCauHinh
        {

            get
            {
                if (this.CauHinhSP != null)
                    return true;
                else return false;
            }
        }
        
        public bool CoGiayIn
        {

            get
            {
                if (this.GiayDeInIn != null)
                    return true;
                else
                    return false;
            }
        }
        public BaiIn(string tenBai)
        {
            _mucTPs = new List<MucThanhPham>();
            _giaInS = new List<MucTinGiaIn>();
            //---
            this.TieuDe = tenBai;
            _lastId +=1;
            this.ID = _lastId;
            
        }
       public int SoLuongGiaInKemTheo()
       {

           return this.GiaInS.Count();
       }
       public int SoLuongThanhPhamKem()
       {
           return this.ThanhPhamS.Count();
       }
        #region thêm sửa, xóa giá In
        public void Them_GiaIn(MucTinGiaIn giaIn)
       {
           _giaInS.Add(giaIn);
       }
        public void Sua_GiaIn (MucTinGiaIn giaIn)
        {
            var giaInSua = this.GiaInS.Find(x => x.ID == giaIn.ID);
            giaInSua.IdBaiIn = giaIn.IdBaiIn;
            giaInSua.PhuongPhapIn = giaIn.PhuongPhapIn;            
            giaInSua.SoTrangIn = giaIn.SoTrangIn;            
            giaInSua.IdMayIn_IdBangGia = giaIn.IdMayIn_IdBangGia;
            giaInSua.TienIn = giaIn.TienIn;

        }
        public void Xoa_GiaIn (MucTinGiaIn giaIn)
        {
            this.GiaInS.Remove(giaIn);
        }
        public MucTinGiaIn DocGiaInTheoID (int idGiaIn)
        {
            return this.GiaInS.Find(x => x.ID == idGiaIn);
        }
        public void XoaTatCa_GiaIn()
        {
            this.GiaInS.Clear();
        }
        #endregion
        #region thêm sửa, xóa Thành phẩm
        public void Them_ThanhPham(MucThanhPham thPham)
        {

            this.ThanhPhamS.Add(thPham);
        }
        public void Sua_ThanhPham(MucThanhPham thPham)
        {
            var thPhamSua = this.ThanhPhamS.Find(x => x.ID == thPham.ID);
            thPhamSua.IdBaiIn = thPham.IdBaiIn;
            thPhamSua.DonViTinh = thPham.DonViTinh;
            thPhamSua.IdHangKhachHang = thPham.IdHangKhachHang;
            thPhamSua.LoaiThPh = thPham.LoaiThPh;
            thPhamSua.SoLuong = thPham.SoLuong;
            thPhamSua.TenThPh = thPham.TenThPh;
            thPhamSua.ThanhTien = thPham.ThanhTien;
            thPhamSua.ThongTinHangKH = thPham.ThongTinHangKH;
            thPhamSua.ThongTinTyLeMarkUp = thPham.ThongTinTyLeMarkUp;                

        }
        public void Xoa_ThanhPham(MucThanhPham thPham)
        {
            this.ThanhPhamS.Remove(thPham);
        }
        public void XoaTatCa_ThanhPham()
        {
            this.ThanhPhamS.Clear();
        }
        public MucThanhPham DocThanhPhamTheoID(int idThPham)
        {
            return this.ThanhPhamS.Find(x => x.ID == idThPham);
        }
        #endregion
        #region Tóm tắt bài in
        public decimal TriGiaBaiIn()
        {
            decimal result = 0;
            decimal tienGiay = 0;
            if (this.GiayDeInIn != null)
            {                
                
                tienGiay = this.GiayDeInIn.ThanhTienGiay;
                
            }
            //Tính in
            
            decimal thanhTienIn = 0;
            if (this.SoLuongGiaInKemTheo() > 0)
            {                
                thanhTienIn = this.GiaInS.Sum(x => x.TienIn);
             
            }
            //Tính thành phẩm
            decimal thanhTienTP = 0;
            if (this.SoLuongThanhPhamKem() > 0)
            {

                thanhTienTP = this.ThanhPhamS.Sum(x => x.ThanhTien);
            }
            result = tienGiay + thanhTienIn + thanhTienTP;
            return result;

        }
        public Dictionary<string, string> TomTat_ChaoKH()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("STT:", this.ID.ToString());
            dict.Add("Tên dịch vụ:", this.TieuDe);
            dict.Add("Số lượng:", string.Format("{0:0,0}",this.SoLuong));
            dict.Add("ĐV tính:", this.DonVi);
            if (this.CauHinhSP != null)
            {
                dict.Add("Khổ Th. Phẩm:", string.Format("{0} x {1}cm",
                    this.CauHinhSP.KhoSP.KhoCatRong, this.CauHinhSP.KhoSP.KhoCatCao));
            }
            decimal tienGiay = 0;
            if (this.GiayDeInIn != null)
            {                
                dict.Add("Giấy in:", this.GiayDeInIn.TenGiayIn);
                tienGiay = this.GiayDeInIn.ThanhTienGiay;
                dict.Add("Tiền giấy:", string.Format("{0:0,00.00}đ", tienGiay));
            }
            //Chi tiết in và Tính in
            var tenPPIn = "";
            foreach(MucTinGiaIn giaIn in this.GiaInS)
            {
                tenPPIn += giaIn.TenPhuongPhapIn + ",";
            }
            dict.Add("In:", tenPPIn);
            decimal thanhTienIn = 0;
            if (this.SoLuongGiaInKemTheo() > 0)
            {
                var soTrangIn = this.GiaInS.Sum(x => x.SoTrangIn);
                thanhTienIn = this.GiaInS.Sum(x => x.TienIn);
                dict.Add("+ Số trang in:", string.Format("{0:0,0} trang/mặt", soTrangIn));
                dict.Add("+ Thành tiền in:", string.Format("{0:0,0.00}đ", thanhTienIn));
            }
            //Tính thành phẩm
            decimal thanhTienTP = 0;
            if (this.SoLuongThanhPhamKem() > 0)
            {
                var nguonTP = this.ThanhPhamS.Select(x => x.TenThPh).ToList();
                var dvTP = "";
                var i = 0;
                foreach (string str in nguonTP)
                {
                    if (i < nguonTP.Count - 1)
                        dvTP += str + ";";
                    else
                        dvTP += str;

                    i++;
                }
                thanhTienTP = this.ThanhPhamS.Sum(x => x.ThanhTien);
                dict.Add("DV thành phẩm:", dvTP);
                dict.Add("Tiền Th. Phẩm:", string.Format("{0:0,0.00}đ", thanhTienTP));
            }
            dict.Add("Tổng giá bài in: ", string.Format("{0:0,0.00}đ",
                tienGiay + thanhTienIn + thanhTienTP));
            return dict;
        }
        #endregion
    }
}
