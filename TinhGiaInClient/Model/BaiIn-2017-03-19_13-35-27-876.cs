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
        private List<GiaIn> _giaInS;
        public List<GiaIn> GiaInS
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
            
            get {
                bool result = false;
                if (this.CauHinhSP != null)
                    result = true;
                return result;}
        }
        public GiayDeIn GiayDeInIn { get; set; }
        public bool CoGiayIn
        {

            get
            {
                bool result = false;
                if (this.GiayDeInIn != null)
                    result = true;
                return result;
            }
        }
        public BaiIn(string tenBai)
        {
            _mucTPs = new List<MucThanhPham>();
            _giaInS = new List<GiaIn>();
            //---
            this.TieuDe = tenBai;
            _lastId +=1;
            this.ID = _lastId;
            
        }
       public int SoLuongGiaInKemTheo( List<GiaIn> dsGiaIn)
       {

           return dsGiaIn.Where(x => x.IdBaiIn == this.ID).Count();
       }
       public int SoLuongThanhPhamKem(List<MucThanhPham> dsThanhPham)
       {
           return dsThanhPham.Where(x => x.IdBaiIn == this.ID).Count();
       }
        #region thêm sửa, xóa giá In
        public void Them_GiaIn(GiaIn giaIn)
       {
           _giaInS.Add(giaIn);
       }
        public void Sua_GiaIn (GiaIn giaIn)
        {
            var giaInSua = this.GiaInS.Find(x => x.ID == giaIn.ID);
            giaInSua.IdBaiIn = giaIn.IdBaiIn;
            giaInSua.KieuIn = giaIn.KieuIn;
            giaInSua.LoaiBangGia = giaIn.LoaiBangGia;
            giaInSua.SoTrangA4 = giaIn.SoTrangA4;
            giaInSua.TenBangGiaChon = giaIn.TenBangGiaChon;
            giaInSua.TenToInDigiChon = giaIn.TenToInDigiChon;
            giaInSua.TienIn = giaIn.TienIn;

        }
        public void Xoa_GiaIn (GiaIn giaIn)
        {
            this.GiaInS.Remove(giaIn);
        }
        public GiaIn DocGiaInTheoID (int idGiaIn)
        {
            return this.GiaInS.Find(x => x.ID == idGiaIn);
        }
        #endregion
        #region thêm sửa, xóa Thành phẩm
        public void Them_ThanhPham(MucThanhPham thPham)
        {

            this.ThanhPhamS.Add(thPham);
        }
        public void Sua_ThanhPham(MucThanhPham thPham)
        {
            var giaInSua = this.ThanhPhamS.Find(x => x.ID == thPham.ID);
            giaInSua.IdBaiIn = thPham.IdBaiIn;
            giaInSua.KieuIn = thPham.KieuIn;
            giaInSua.LoaiBangGia = thPham.LoaiBangGia;
            giaInSua.SoTrangA4 = thPham.SoTrangA4;
            giaInSua.TenBangGiaChon = thPham.TenBangGiaChon;
            giaInSua.TenToInDigiChon = thPham.TenToInDigiChon;
            giaInSua.TienIn = thPham.TienIn;

        }
        public void Xoa_ThanhPham(MucThanhPham thPham)
        {
            this.ThanhPhamS.Remove(thPham);
        }
        public MucThanhPham DocThanhPhamTheoID(int idThPham)
        {
            return this.ThanhPhamS.Find(x => x.ID == idThPham);
        }
        #endregion
    }
}
