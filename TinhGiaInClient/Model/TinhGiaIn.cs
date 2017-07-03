using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TinhGiaInLogic;
using TinhGiaInClient.Model.Booklet;


namespace TinhGiaInClient.Model
{
    public class TinhGiaIn
    {
        public TinhGiaIn(int idHangKhachHang)
        {
            this.IdHangKhachHang = idHangKhachHang;
        }
        public TinhGiaIn()
        {

            _dsKetQuaBaiIn = new List<BaiIn>();
            _chiTietGiaDanhThiep = new List<BaiInDanhThiep>();
            _dsGiaInSach = new List<GiaInSachDigi>();
            _baiInTheNhuaS = new List<BaiInTheNhua>();
            ///Tạo tự động số chào giá:
            ///SS/NN-TT-NN: SS từ ID hiện tại
            //this.So =  string.Format("{0}/{1}-{2}-{3}", this.ID, ngayChaoGia.Year - 2000,
            //     ngayChaoGia.Month, ngayChaoGia.Day);

        }

        public int IdHangKhachHang
        { get; set; }
        public int TyLeMarkupSales()
        {
            return HangKhachHang.LayTheoId(this.IdHangKhachHang).LoiNhuanChenhLech;
        }
        
      
        //phần không lưu data
        List<BaiIn> _dsKetQuaBaiIn;
        public List<BaiIn> KetQuaBaiInS
        {
            get { return _dsKetQuaBaiIn; }
            set { _dsKetQuaBaiIn = value; }
        }

        List<BaiInDanhThiep> _chiTietGiaDanhThiep;
        public List<BaiInDanhThiep> BaiInDanhThiepS
        {
            get { return _chiTietGiaDanhThiep; }
            set { _chiTietGiaDanhThiep = value; }
        }
        List<GiaInSachDigi> _dsGiaInSach;
        public List<GiaInSachDigi> GiaInSachDigiS
        {
            get { return _dsGiaInSach; }
            set { _dsGiaInSach = value; }
        }
        List<BaiInTheNhua> _baiInTheNhuaS;
        public List<BaiInTheNhua> BaiInTheNhuaS
        {
            get { return _baiInTheNhuaS; }
            set { _baiInTheNhuaS = value; }
        }
              
        
        #region Phần Bài in: thêm sửa, xóa bài in
        public void ThemBaiIn(BaiIn kQuaBaiIn)
        {
            this.KetQuaBaiInS.Add(kQuaBaiIn);
        }
        public void SuaKetQuaBaiIn(BaiIn kQuaBaiIn)
        {
            var baiInSua = this.KetQuaBaiInS.Find(x => x.ID == kQuaBaiIn.ID);
            baiInSua.TieuDe = kQuaBaiIn.TieuDe;
            baiInSua.DienGiai = kQuaBaiIn.DienGiai;
            baiInSua.SoLuong = kQuaBaiIn.SoLuong;
            baiInSua.DonVi = kQuaBaiIn.DonVi;
            baiInSua.IdHangKH = kQuaBaiIn.IdHangKH;
            //baiInSua.TomTat_ChaoKH = kQuaBaiIn.TomTat_ChaoKH;
               
        }
        public void XoaBaiIn(BaiIn baiIn)
        {
            this.KetQuaBaiInS.Remove(baiIn);
        }
        public BaiIn DocBaiInTheoID(int idKQBaiIn)
        {
            return this.KetQuaBaiInS.Find(x => x.ID == idKQBaiIn);
        }
        public void XoaTatCaKetQuaBaiIn()
        {
            this.KetQuaBaiInS.Clear();
        }
        //Thêm một số hàm
        public int TongSoTrangInA4BaiIn()
        {
            var kq = 0;
            if (this.KetQuaBaiInS.Count > 0)
            {
                kq = this.KetQuaBaiInS.Sum(x => x.TongSoTrangInA4());
            }
            return kq;
        }
        
        public decimal TongTienInBaiIn()//Gom lại tính gộp
        {
            decimal kq = 0;
            var idBangGiaInNhanh = 0;
            var idMayInDigiChon = 0;
            if (this.TongSoTrangInA4BaiIn() > 0)
            {
                //Tìm mục nào có IdBangGiaInNhanh chung > 0 thì dừng
                foreach (BaiIn baiIn in this.KetQuaBaiInS)
                {
                    if (baiIn.IdBangGiaInNhanhChung() > 0)
                    {
                        idBangGiaInNhanh = baiIn.IdBangGiaInNhanhChung();
                        idMayInDigiChon = baiIn.IdMayInDigiChung();
                    }

                }
                if (idBangGiaInNhanh <= 0 || idMayInDigiChon <= 0)
                {
                    kq = 0;
                }
                else
                {

                    var giaInNhanh = new GiaInNhanhKetHopBangGia_May(this.TongSoTrangInA4BaiIn(),
                        idBangGiaInNhanh, idMayInDigiChon, TyLeMarkupSales());
                    kq = giaInNhanh.GiaBan();
                }
            }

            return kq;
        }
        #endregion

        #region Phần Danh thiếp: thêm sửa, xóa Danh thiếp
        public void ThemDanhThiep(BaiInDanhThiep kQuaBaiIn)
        {
            this.BaiInDanhThiepS.Add(kQuaBaiIn);
        }
        public void SuaDanhThiep(BaiInDanhThiep baiInDanhThiep)
        {
            var baiInSua = this.BaiInDanhThiepS.Find(x => x.ID == baiInDanhThiep.ID);
            baiInSua.SoMatIn = baiInDanhThiep.SoMatIn;

            baiInSua.IdBangGia = baiInDanhThiep.IdBangGia;
            baiInSua.TenBangGia = baiInDanhThiep.TenBangGia;
            baiInSua.SoLuongHop = baiInDanhThiep.SoLuongHop;
            baiInSua.TenGiayIn = baiInDanhThiep.TenGiayIn;
            baiInSua.TienGiay = baiInDanhThiep.TienGiay;
            baiInSua.TienIn = baiInDanhThiep.TienIn;
          
        }
        public void XoaDanhThiep(BaiInDanhThiep baiIn)
        {
            this.BaiInDanhThiepS.Remove(baiIn);
        }
        public BaiInDanhThiep DocDanhThiepTheoID(int idKQBaiIn)
        {
            return this.BaiInDanhThiepS.Find(x => x.ID == idKQBaiIn);
        }
        public void XoaTatDanhThiep()
        {
            this.BaiInDanhThiepS.Clear();
        }
        
        #endregion
        #region Phần Cuốn: thêm sửa, xóa bài in
        public void ThemCuon(GiaInSachDigi giaCuonDigi)
        {
            this.GiaInSachDigiS.Add(giaCuonDigi);
        }
        //Cập nhật cuốn không cần thiết vì tự cập nhật ở form rồi
        public void XoaCuon(GiaInSachDigi giaCuonDigi)
        {
            this.GiaInSachDigiS.Remove(giaCuonDigi);
        }
        public GiaInSachDigi DocCuonTheoID(int idGiaInCuon)
        {
            return this.GiaInSachDigiS.Find(x => x.ID == idGiaInCuon);
        }
        public void XoaTatCaCuon()
        {
            this.GiaInSachDigiS.Clear();
        }
        #endregion
        #region Phần Thẻ nhựa: thêm sửa, xóa Danh thiếp
        public void ThemTheNhua(BaiInTheNhua kQuaBaiIn)
        {
            this.BaiInTheNhuaS.Add(kQuaBaiIn);
        }

        public void XoaTheNhua(BaiInTheNhua baiIn)
        {
            this.BaiInTheNhuaS.Remove(baiIn);
        }
        public BaiInTheNhua DocTheNhuaTheoID(int idKQBaiIn)
        {
            return this.BaiInTheNhuaS.Find(x => x.ID == idKQBaiIn);
        }
        public void XoaTatTheNhua()
        {
            this.BaiInTheNhuaS.Clear();
        }

        #endregion
        #region Các tổng danh thiếp, bài in, cataloque, thẻ nhựa
        public decimal TongTienDanhThiep()
        {
            decimal kq = 0;
            //Danh thiếp
            if (this.BaiInDanhThiepS.Count > 0)
            {
                kq = this.BaiInDanhThiepS.Sum(x => x.ThanhTien);            
            }
            return kq;
        }

        public decimal TongTienBaiIn() //Không điều chỉnh giá in
        {
            decimal kq = 0;
            if (this.KetQuaBaiInS.Count > 0)
                kq = this.KetQuaBaiInS.Sum(x => x.TriGiaBaiIn());

            return kq;
            
        }
        public decimal TongTienBaiInDaDieuChinhTienIn()
        {
            decimal kq = 0;
            if (_dsKetQuaBaiIn.Count() > 0)
            { //Tính hơi khác trừ tiền in theo từng bài ra
                var tongTienInToanBoBai = _dsKetQuaBaiIn.Sum(x => x.TongTienIn());
                var tienConLaiKhongGomIn = _dsKetQuaBaiIn.Sum(x => x.TriGiaBaiIn()) -
                                tongTienInToanBoBai; //Để tính gom tiền in riêng
                kq += (tienConLaiKhongGomIn + this.TongTienInBaiIn());
            }
            return kq;
        }
        public decimal TongTienCuon()
        {
            decimal kq = 0;
            //Danh thiếp
            if (this.GiaInSachDigiS.Count > 0)
            {
                kq = this.GiaInSachDigiS.Sum(x => x.GiaChaoTong());
            }
            return kq;
        }
        public decimal TongTienTheNhua()
        {
            decimal kq = 0;
            //Danh thiếp
            if (this.BaiInTheNhuaS.Count > 0)
            {
                kq = this.BaiInTheNhuaS.Sum(x => x.ThanhTien());
            }
            return kq;
        }
        #endregion
        #region Một số tóm tắt
        public decimal TongTriGiaChao()
        {

            return TongTienDanhThiep() + TongTienBaiInDaDieuChinhTienIn() +
                TongTienCuon() + TongTienTheNhua();
        
        }
        public List<string> NoiDungGiaChaoKhachHang()
        { ///từng dòng 
            var lst = new List<string>();           
            lst.Add("----------------");//Ngăn tiêu đề
            if (this.BaiInDanhThiepS.Count <= 0 && this.KetQuaBaiInS.Count <= 0)
            {
                lst.Add("Chưa có nội dung tính toán");
                return lst;
            }
            var j = 0; //dùng cho các mục tính giá
            var dSachMucTinhGia = ""; //dùng ghi nhận
            //Danh thiếp
            if (this.BaiInDanhThiepS.Count > 0)
            {
                j += 1;
                dSachMucTinhGia += string.Format("Danh thiếp [{0}], ", this.BaiInDanhThiepS.Count);
                lst.Add(string.Format("{0}). Danh thiếp: ", j));
                var i = 1;
                foreach (BaiInDanhThiep bInDanhThiep in this.BaiInDanhThiepS)
                {                    
                    foreach (KeyValuePair<string, string> kvp in bInDanhThiep.TomTat_ChaoKH())
                    {
                        lst.Add(string.Format("{0} {1}", kvp.Key, kvp.Value));
                    }

                    lst.Add(string.Format("---Hết{0}---", i));
                    ++i;
                }

                lst.Add("---Hết danh thiếp---");

            }
            //Phần bài in
            if (this.KetQuaBaiInS.Count > 0)
            {
                j += 1;
                dSachMucTinhGia += string.Format("In theo bài [{0}], ", this.KetQuaBaiInS.Count);
                lst.Add(string.Format("{0}). In theo bài: ", j));

                var i = 1;

                foreach (BaiIn kQuaBaiIn in this.KetQuaBaiInS)
                {                    
                    foreach (KeyValuePair<string, string> kvp in kQuaBaiIn.TomTat_ChaoKH())
                    {
                        lst.Add(string.Format("{0} {1}", kvp.Key, kvp.Value));
                    }

                    lst.Add(string.Format("---Hết {0}---", i));
                    ++i;
                }
                lst.Add("--- Tóm tắt in theo bài ---");
                lst.Add(string.Format("Tổng trang in gộp: {0}", this.TongSoTrangInA4BaiIn()));
                lst.Add(string.Format("Tổng tiền in gộp: {0:0,0.00}đ", this.TongTienInBaiIn()));                
                lst.Add("---Hết in theo bài---");
            }
           
            //Phần Cuốn
            if (this.GiaInSachDigiS.Count > 0)
            {
                j += 1;
                dSachMucTinhGia += string.Format("In cuốn [{0}] ", this.GiaInSachDigiS.Count);
                lst.Add(string.Format("{0}). In cuốn/Cataloque: ", j));

                var i = 1;

                foreach (GiaInSachDigi giaInSachDigi in this.GiaInSachDigiS)
                {

                    lst.Add(giaInSachDigi.TomTatChao_DichVu());

                    lst.Add(string.Format("---Hết {0}---", i));
                    ++i;
                }
                lst.Add("---Hết in Cuốn ---");
            }
            //Thẻ nhựa
            if (this.BaiInTheNhuaS.Count > 0)
            {
                j += 1;
                dSachMucTinhGia += string.Format("Danh thiếp [{0}], ", this.BaiInTheNhuaS.Count);
                lst.Add(string.Format("{0}). Thẻ nhựa: ", j));
                var i = 1;
                foreach (BaiInTheNhua bInDanhThiep in this.BaiInTheNhuaS)
                {
                    foreach (KeyValuePair<string, string> kvp in bInDanhThiep.TomTat_ChaoKH())
                    {
                        lst.Add(string.Format("{0} {1}", kvp.Key, kvp.Value));
                    }

                    lst.Add(string.Format("---Hết{0}---", i));
                    ++i;
                }

                lst.Add("---Hết Thẻ nhựa---");

            }

            lst.Add("-----Tổng kết chào giá-----");
            lst.Add("KH đã thực hiện: " + dSachMucTinhGia);
            lst.Add(string.Format("Tổng chào giá: {0:0,0.00}đ", this.TongTriGiaChao()));

            return lst;

        }

        #endregion
    }
}
