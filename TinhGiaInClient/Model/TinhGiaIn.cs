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
        public List<BaiInDanhThiep> BaiInGiaDanhThiepS
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
        public TinhGiaIn()
        {

            _dsKetQuaBaiIn = new List<BaiIn>();
            _chiTietGiaDanhThiep = new List<BaiInDanhThiep>();
            _dsGiaInSach = new List<GiaInSachDigi>(); 
            ///Tạo tự động số chào giá:
            ///SS/NN-TT-NN: SS từ ID hiện tại
            //this.So =  string.Format("{0}/{1}-{2}-{3}", this.ID, ngayChaoGia.Year - 2000,
           //     ngayChaoGia.Month, ngayChaoGia.Day);

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
                kq = this.KetQuaBaiInS.Sum(x => x.TongSoTrangInA4ToanBai());
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
            this.BaiInGiaDanhThiepS.Add(kQuaBaiIn);
        }
        public void SuaDanhThiep(BaiInDanhThiep baiInDanhThiep)
        {
            var baiInSua = this.BaiInGiaDanhThiepS.Find(x => x.ID == baiInDanhThiep.ID);
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
            this.BaiInGiaDanhThiepS.Remove(baiIn);
        }
        public BaiInDanhThiep DocDanhThiepTheoID(int idKQBaiIn)
        {
            return this.BaiInGiaDanhThiepS.Find(x => x.ID == idKQBaiIn);
        }
        public void XoaTatDanhThiep()
        {
            this.BaiInGiaDanhThiepS.Clear();
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
        #region Một số tóm tắt
        public decimal TongTriGiaChao()
        {
            decimal result = 0;

            //bài in
            if (_dsKetQuaBaiIn.Count() > 0)
            { //Tính hơi khác trừ tiền in theo từng bài ra
                var tongTienInToanBoBai = _dsKetQuaBaiIn.Sum(x => x.TongTienIn());
                var tienConLaiKhongGomIn = _dsKetQuaBaiIn.Sum(x => x.TriGiaBaiIn()) -
                                tongTienInToanBoBai; //Để tính gom tiền in riêng
                result += (tienConLaiKhongGomIn + this.TongTienInBaiIn()) ;
            }
            //Danh thiếp
            if (_chiTietGiaDanhThiep.Count() > 0)
                result += _chiTietGiaDanhThiep.Sum(x => x.ThanhTien);
            
            //Bài in cataloque
            if (_dsGiaInSach.Count() > 0)
                result += _dsGiaInSach.Sum(x => x.GiaChaoTong());

            return result;
        }
        public List<string> NoiDungGiaChaoKhachHang()
        { ///từng dòng 
            var lst = new List<string>();
            lst.Add("----------------");//Ngăn tiêu đề
            if (this.BaiInGiaDanhThiepS.Count <= 0 && this.KetQuaBaiInS.Count <= 0)
            {
                lst.Add("Chưa có nội dung tính toán");
                return lst;
            }

            //Danh thiếp
            if (this.BaiInGiaDanhThiepS.Count > 0)
            {
                lst.Add("Danh thiếp: ");
                var i = 1;
                foreach (BaiInDanhThiep bInDanhThiep in this.BaiInGiaDanhThiepS)
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
                lst.Add("In theo bài: ");


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
                lst.Add("---Hết in theo bài---");
            }
           
            //Phần Cuốn
            if (this.GiaInSachDigiS.Count > 0)
            {
                lst.Add("In cuốn ");


                var i = 1;

                foreach (GiaInSachDigi giaInSachDigi in this.GiaInSachDigiS)
                {

                    lst.Add(giaInSachDigi.TomTatChao_DichVu());

                    lst.Add(string.Format("---Hết {0}---", i));
                    ++i;
                }
                lst.Add("---Hết in theo bài---");
            }
            

            lst.Add("-----Hết Chào giá-----");
            lst.Add(string.Format("Tổng chào giá: {0:0,0.00}đ", this.TongTriGiaChao()));

            return lst;

        }

        #endregion
    }
}
