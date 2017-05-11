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
        public List<string> TaoNoiDungChaoGia ()
        {
            var lst = new List<string>();
            lst.Add(string.Format("Số chào giá: {0}", this.So));
            lst.Add(string.Format("Ngày: {0}", this.Ngay));
            lst.Add(string.Format("Tên KH: {0}", this.TenKhachHang));
            lst.Add(string.Format("Liên hệ: {0}", this.LienHe));
            lst.Add(string.Format("NVKD/BH: {0}", this.TenNhanVien));
            lst.Add("----------------");
            lst.Add("Bài in: ");
                
           if (_dsKetQuaBaiIn.Count() > 0)
            {
                var i = 1;
                
                foreach ( BaiIn bIn in _dsKetQuaBaiIn)
                {
                    lst.Add(string.Format("---Bắt đầu {0}---", i));
                    foreach (KeyValuePair<string,string> kvp in bIn.TomTat_ChaoKH())
                    {
                        lst.Add(kvp.Key + " " + kvp.Value);
                    }

                    lst.Add(string.Format("---Hết bài {0}---", i));
                    ++i;
                }
                
            }

            lst.Add(string.Format("Tổng gia: {0:0,0.00}đ", this.TongTriGiaChao()));
            
            return lst;
            
        }
        public decimal TongTriGiaChao()
        {
            decimal result = 0;
            if (_dsKetQuaBaiIn.Count() > 0)
                result = _dsKetQuaBaiIn.Sum(x => x.TriGiaBaiIn);
            return result;
        }
      
        //phần không lưu data
        List<KetQuaBaiIn> _dsKetQuaBaiIn;
        public List<KetQuaBaiIn> DanhSachBaiIn
        {
            get { return _dsKetQuaBaiIn; }
            set { _dsKetQuaBaiIn = value; }
        }
        
        public TinhGiaIn()
        {

            _dsKetQuaBaiIn = new List<KetQuaBaiIn>();
           
            ///Tạo tự động số chào giá:
            ///SS/NN-TT-NN: SS từ ID hiện tại
            //this.So =  string.Format("{0}/{1}-{2}-{3}", this.ID, ngayChaoGia.Year - 2000,
           //     ngayChaoGia.Month, ngayChaoGia.Day);

        }
       
        
        
        #region Phần Bài in: thêm sửa, xóa bài in
        public void ThemKetQuaBaiIn(KetQuaBaiIn kQuaBaiIn)
        {
            this.DanhSachBaiIn.Add(kQuaBaiIn);
        }
        public void SuaKetQuaBaiIn(KetQuaBaiIn kQuaBaiIn)
        {
            var baiInSua = this.DanhSachBaiIn.Find(x => x.ID == kQuaBaiIn.ID);
            baiInSua.TieuDe = kQuaBaiIn.TieuDe;
            baiInSua.DienGiai = kQuaBaiIn.DienGiai;
            baiInSua.SoLuong = kQuaBaiIn.SoLuong;
            baiInSua.DonVi = kQuaBaiIn.DonVi;
            baiInSua.IdHangKH = kQuaBaiIn.IdHangKH;
               
        }
        public void XoaKetQuaBaiIn(KetQuaBaiIn baiIn)
        {
            this.DanhSachBaiIn.Remove(baiIn);
        }
        public KetQuaBaiIn DocBaiInTheoID(int idKQBaiIn)
        {
            return this.DanhSachBaiIn.Find(x => x.ID == idKQBaiIn);
        }
        public void XoaTatCaKetQuaBaiIn()
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
                    YeuCau = x.YeuCau,
                    TenNhanVien = x.TenNhanVien,
                    NoiDungChaoGia = x.NoiDungChaoGia
                   

                }).ToList();
            }
            catch { }
            return nguon;
        }

         public static TinhGiaIn DocTheoId(int idTinhGia)
        {
            var tinhGiaInLogic = new TinhGiaInnLogic();
            var tinhGia = new TinhGiaIn();
            try
            {
                var giayBDO = tinhGiaInLogic.DocTheoId(idTinhGia);
                //Chuyen
                ChuyenDoiGiayBDOThanhDTO(giayBDO, tinhGia);
            }
                catch {
                }
            return tinhGia;
        }
        
        #region Thêm sửa xóa

         public static string Them(TinhGiaIn item)
        {
            var tinhGiaInLogic = new TinhGiaInnLogic();
            var itemBDO = new TinhGiaInnBDO();
            ChuyenDoiGiayDTOThanhBDO(item, itemBDO);
            return tinhGiaInLogic.Them(itemBDO);
        }

         public static string Sua(TinhGiaIn item)
        {
            var tinhGiaInLogic = new TinhGiaInnLogic();
            var itemBDO = new TinhGiaInnBDO();
            ChuyenDoiGiayDTOThanhBDO(item, itemBDO);
            return tinhGiaInLogic.Sua(itemBDO);
        }
        public static string Xoa(int idTinhGia)
        {
            var tinhGiaInLogic = new TinhGiaInnLogic();
            
            return tinhGiaInLogic.Xoa(idTinhGia);
        }
        #endregion
        //Chuyển đổi
        private static void ChuyenDoiGiayBDOThanhDTO(TinhGiaInnBDO tinhGiaBDO, TinhGiaIn tinhGia)
        {
            tinhGia.ID = tinhGiaBDO.ID;
            tinhGia.So = tinhGiaBDO.So;
            tinhGia.Ngay = tinhGiaBDO.Ngay;
            tinhGia.TenKhachHang = tinhGiaBDO.TenKhachHang;
            tinhGia.LienHe = tinhGiaBDO.LienHe;
            tinhGia.YeuCau = tinhGiaBDO.YeuCau;
            tinhGia.TenNhanVien = tinhGiaBDO.TenNhanVien;
            tinhGia.NoiDungChaoGia = tinhGiaBDO.NoiDungChaoGia;
            
        }
        private static void ChuyenDoiGiayDTOThanhBDO(TinhGiaIn tinhGia, TinhGiaInnBDO tinhGiaBDO)
        {
            tinhGiaBDO.ID = tinhGia.ID;
            tinhGiaBDO.So = tinhGia.So;
            tinhGiaBDO.Ngay = tinhGia.Ngay;
            tinhGiaBDO.TenKhachHang = tinhGia.TenKhachHang;
            tinhGiaBDO.LienHe = tinhGia.LienHe;
            tinhGiaBDO.YeuCau = tinhGia.YeuCau;
            tinhGiaBDO.TenNhanVien = tinhGia.TenNhanVien;
            tinhGiaBDO.NoiDungChaoGia = tinhGia.NoiDungChaoGia;            
        }
        #endregion
    }
}
