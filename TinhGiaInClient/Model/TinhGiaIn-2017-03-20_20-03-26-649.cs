using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;


namespace TinhGiaInClient.Model
{
    public class TinhGiaIn
    {
        public int ID { get; set; }
        public string So { get; set; }
        public DateTime Ngay { get; set; }
        public string TenKhachHang { get; set; }
        public string LienHe { get; set; }
        public string YeuCau { get; set; }
        public string TenNhanVien { get; set; }
        public string NoiDungChaoGia { get; set; }
        public int ThuTu { get; set; }
        //phần không lưu data
        List<BaiIn> _dsBaiIn;
        public List<BaiIn> DanhSachBaiIn
        {
            get { return _dsBaiIn; }
            set { _dsBaiIn = value; }
        }
        public TinhGiaIn()
        {
           
            _dsBaiIn = new List<BaiIn>();
           
            ///Tạo tự động số chào giá:
            ///SS/NN-TT-NN: SS từ ID hiện tại
            //this.So =  string.Format("{0}/{1}-{2}-{3}", this.ID, ngayChaoGia.Year - 2000,
           //     ngayChaoGia.Month, ngayChaoGia.Day);

        }
       
        
        
        #region Phần Bài in: thêm sửa, xóa bài in
        public void Them_BaiIn(BaiIn baiIn)
        {
            this.DanhSachBaiIn.Add(baiIn);
        }
        public void Sua_BaiIn(BaiIn baiIn)
        {
            var baiInSua = this.DanhSachBaiIn.Find(x => x.ID == baiIn.ID);
            baiInSua.TieuDe = baiIn.TieuDe;
            baiInSua.DienGiai = baiIn.DienGiai;
            baiInSua.SoLuong = baiIn.SoLuong;
            baiInSua.DonVi = baiIn.DonVi;
            baiInSua.IdHangKH = baiIn.IdHangKH;
            baiInSua.TenHangKH = baiIn.TenHangKH;
            baiInSua.GiayDeInIn = baiIn.GiayDeInIn;
            baiInSua.CauHinhSP = baiIn.CauHinhSP;
            baiInSua.GiaInS = baiIn.GiaInS;
            baiInSua.ThanhPhamS = baiIn.ThanhPhamS;            
        }
        public void Xoa_BaiIn(BaiIn baiIn)
        {
            this.DanhSachBaiIn.Remove(baiIn);
        }
        public BaiIn DocBaiInTheoID(int idBaiIn)
        {
            return this.DanhSachBaiIn.Find(x => x.ID == idBaiIn);
        }
        public void XoaTatCa_BaiIn()
        {
            this.DanhSachBaiIn.Clear();
        }
        #endregion
         #region các hàm static kết nối dữ liệu
         public static List<TinhGiaIn> DocTatCa()
        {
            var tinhGiaInLogic = new TinhGiaInnLogic();
            List<TinhGiaIn > nguon = null;
            try
            {
                nguon = tinhGiaInLogic.DocTatCa().Select(x => new TinhGiaIn
                {
                    ID = x.ID,
                    So = x.So,
                    Ngay = x.Ngay,
                    TenKhachHang = x.TenKhachHang,
                    LienHe = x.LienHe,
                    TenNhanVien = x.TenNhanVien,
                    NoiDungChaoGia = x.NoiDungChaoGia,
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }
       
        public static Giay DocGiayTheoId(int idGiay)
        {
            var tinhGiaInLogic = new GiayLogic();
            Giay giay = new Giay();
            try
            {
                var giayBDO = tinhGiaInLogic.LayTheoId(idGiay);
                //Chuyen
                ChuyenDoiGiayBDOThanhDTO(giayBDO, giay);
            }
                catch {
                }
            return giay;
        }
        
        #region Thêm sửa xóa

        public static string Them(Giay item)
        {
            GiayLogic giayLogic = new GiayLogic();
            var itemBDO = new GiayBDO();
            ChuyenDoiGiayDTOThanhBDO(item, itemBDO);
            return giayLogic.Them(itemBDO);
        }

        public static string Sua(Giay item)
        {
            GiayLogic giayLogic = new GiayLogic();
            var itemBDO = new GiayBDO();
            ChuyenDoiGiayDTOThanhBDO(item, itemBDO);
            return giayLogic.Sua(itemBDO);
        }
        public static string Xoa(int idGiay)
        {
            GiayLogic giayLogic = new GiayLogic();
            
            return giayLogic.Xoa(idGiay);
        }
        #endregion
        //Chuyển đổi
        private static void ChuyenDoiGiayBDOThanhDTO(GiayBDO giayBDO, Giay giay)
        {
            giay.ID = giayBDO.ID;
            giay.MaGiayNCC = giayBDO.MaGiayNCC;
            giay.MaGiayTuDat = giayBDO.MaGiayTuDat;
            giay.TenGiay = giayBDO.TenGiay;
            giay.DienGiai = giayBDO.DienGiai;
            giay.DinhLuong = giayBDO.DinhLuong;
            giay.KhoGiay = giayBDO.KhoGiay;
            giay.ChieuNgan = giayBDO.ChieuNgan;
            giay.ChieuDai = giayBDO.ChieuDai;
            giay.GiaMua = giayBDO.GiaMua;
            giay.KhongCon = giayBDO.KhongCon;            
            giay.IdDanhMucGiay = giayBDO.IdDanhMucGiay;
            giay.TonKho = giayBDO.TonKho;
            giay.ThuTu = giayBDO.ThuTu;
        }
        private static void ChuyenDoiGiayDTOThanhBDO(Giay giay, GiayBDO giayBDO)
        {
            giayBDO.ID = giay.ID;
            giayBDO.MaGiayNCC = giay.MaGiayNCC;
            giayBDO.MaGiayTuDat = giay.MaGiayTuDat;
            giayBDO.TenGiay = giay.TenGiay;
            giayBDO.DienGiai = giay.DienGiai;
            giayBDO.DinhLuong = giay.DinhLuong;
            giayBDO.KhoGiay = giay.KhoGiay;
            giayBDO.ChieuNgan = giay.ChieuNgan;
            giayBDO.ChieuDai = giay.ChieuDai;
            giayBDO.GiaMua = giay.GiaMua;
            giayBDO.KhongCon = giay.KhongCon;
            giayBDO.IdDanhMucGiay = giay.IdDanhMucGiay;
            giayBDO.TonKho = giay.TonKho;
            giayBDO.ThuTu = giay.ThuTu;
        }
        #endregion
    }
}
