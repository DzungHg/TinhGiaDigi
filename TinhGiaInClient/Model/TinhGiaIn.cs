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
        public bool QuyetDinhGopTrangInBaiIn
        { get; set; }
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
        
        public bool ChoTinhGopTrangIn ()
        {
            var kq = false;
            if (this.KetQuaBaiInS.Count >0)
            {
                foreach (BaiIn bi in this.KetQuaBaiInS)
                {
                    if (bi.ChoTinhGopTrang())
                    {
                        kq = true;
                        break;
                    }
                }
            }

            return kq;
        }
        
        #region Phần Bài in: thêm sửa, xóa bài in và một số hàm để tính gộp tiền in...
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
        
        public decimal TongTienInTatCaBaiInTinhGopTrang()//Gom lại tính gộp
        {
            decimal kq = 0;
            var idNiemYetGiaInNhanh = 0;
            var idMayInDigiChon = 0;
            if (this.TongSoTrangInA4BaiIn() > 0)
            {
                //Tìm mục nào có IdBangGiaInNhanh chung > 0 thì dừng
                foreach (BaiIn baiIn in this.KetQuaBaiInS)
                {
                    if (baiIn.IdNiemYetGiaInNhanhChung() > 0)
                    {
                        idNiemYetGiaInNhanh = baiIn.IdNiemYetGiaInNhanhChung();
                        idMayInDigiChon = baiIn.IdMayInDigiChung();
                    }

                }
                if (idNiemYetGiaInNhanh <= 0 || idMayInDigiChon <= 0)
                {
                    kq = 0;
                }
                else
                {
                    //Tạo bảng giá in nhanh
                    var bangGia = DanhSachBangGia.DocTheoIDvaLoai(NiemYetGiaInNhanh.DocTheoId(idNiemYetGiaInNhanh).IdBangGia,
                        NiemYetGiaInNhanh.DocTheoId(idNiemYetGiaInNhanh).LoaiBangGia);
                    var soTrangToiDa = NiemYetGiaInNhanh.DocTheoId(idNiemYetGiaInNhanh).SoTrangToiDa;

                    var giaInNhanh = new GiaInNhanhKetHopBangGia_May(this.TongSoTrangInA4BaiIn(),
                        bangGia, soTrangToiDa, idMayInDigiChon, this.TyLeMarkupSales());
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
       /* public void SuaDanhThiep(BaiInDanhThiep baiInDanhThiep)
        {
            var baiInSua = this.BaiInDanhThiepS.Find(x => x.ID == baiInDanhThiep.ID);
            baiInSua.SoMatIn = baiInDanhThiep.SoMatIn;

            baiInSua.IdBangGia = baiInDanhThiep.IdBangGia;
            baiInSua.TenBangGia = baiInDanhThiep.TenBangGia;
            baiInSua.SoLuongHop = baiInDanhThiep.SoLuongHop;
            baiInSua.TenGiayIn = baiInDanhThiep.TenGiayIn;
            baiInSua.TienGiay = baiInDanhThiep.TienGiay;
            baiInSua.TienIn = baiInDanhThiep.TienIn;
          
        }*/
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
        #region Phần Cuốn: thêm sửa, xóa
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
                kq = this.BaiInDanhThiepS.Sum(x => x.ThanhTien());            
            }
            return kq;
        }

        public decimal TongTienBaiInChuaDieuChinhGiaIn() //Chưa điều chỉnh giá
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
                //Tính tổng tiền in
                var tongTienInToanBoBai = _dsKetQuaBaiIn.Sum(x => x.TongTienIn());
                //Tiền còn lại không bao gồm in
                var tienConLaiKhongGomIn = this.TongTienBaiInChuaDieuChinhGiaIn()
                    - tongTienInToanBoBai;
                //Kết quả = Số tiền còn lại không tính in + tổng số tiền in bài in đã điều chỉnh
                kq = tienConLaiKhongGomIn + this.TongTienInTatCaBaiInTinhGopTrang();
            }

            return kq;
        }
        public decimal TienInDaKhauTruTheoBai()
        {
            return this.TongTienBaiInChuaDieuChinhGiaIn() -
                TongTienBaiInDaDieuChinhTienIn();
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
        #region Tóm tăt cas subs theo, danh thiếp, bài in, cata,thẻ nhựa
        public List<string> NoiDungGiaChaoKH_DanhThiep()
        {
            var lst = new List<string>();
            var dSachMucTinhGia = "";

            if (this.BaiInDanhThiepS.Count > 0)
            {

                dSachMucTinhGia += string.Format("---Danh thiếp [{0}]---, ", this.BaiInDanhThiepS.Count);

                
                foreach (BaiInDanhThiep bInDanhThiep in this.BaiInDanhThiepS)
                {
                    foreach (KeyValuePair<string, string> kvp in bInDanhThiep.TomTat_ChaoKH())
                    {
                        lst.Add(string.Format("{0} {1}", kvp.Key, kvp.Value));
                    }
                    
                    
                }
                lst.Add("---Tóm tắt in Danh thiếp---");
                lst.Add(string.Format("----Tổng trị giá: {0:0,0.00}đ", this.BaiInDanhThiepS.Sum(x => x.ThanhTien())));

                lst.Add("---Hết danh thiếp---");
            }   
            
            return lst;
        }
        public List<string> NoiDungGiaChaoKH_InTheoBai()
        {
            var lst = new List<string>();
            var dSachMucTinhGia = "";

            if (this.KetQuaBaiInS.Count > 0)
            {

                dSachMucTinhGia += string.Format("---In theo bài [{0}]---, ", this.BaiInDanhThiepS.Count);

                
                foreach (BaiIn kQuaBaiIn in this.KetQuaBaiInS)
                {
                    foreach (KeyValuePair<string, string> kvp in kQuaBaiIn.TomTat_ChaoKH())
                    {
                        lst.Add(string.Format("{0} {1}", kvp.Key, kvp.Value));
                    }

                   
                }
                lst.Add("---Tóm tắt in chưa gộp trang in---");
                lst.Add(string.Format("----Tổng trang in A4: {0:0,0}", this.KetQuaBaiInS.Sum(x => x.TongSoTrangInA4())));
                lst.Add(string.Format("----Tổng tiền in: {0:0,0.00}đ", this.KetQuaBaiInS.Sum(x => x.TongTienIn())));
                lst.Add(string.Format("----Tổng trị giá: {0:0,0.00}đ", this.KetQuaBaiInS.Sum(x => x.TriGiaBaiIn())));
                lst.Add("---Hết Bài in---");
            }

            return lst;
        }
        public List<string> NoiDungGiaChaoKH_InSach()
        {
            var lst = new List<string>();
            var dSachMucTinhGia = "";

            if (this.GiaInSachDigiS.Count > 0)
            {

                dSachMucTinhGia += string.Format("---In Cuốn [{0}]---, ", this.BaiInDanhThiepS.Count);

                var i = 1;
                foreach (GiaInSachDigi giaInSachDigi in this.GiaInSachDigiS)
                {
                    
                        lst.Add(string.Format("{0}). {1}", i, giaInSachDigi.TomTatChao_DichVu()));
                    
                    ++i;
                }
                lst.Add("---Tóm tắt In cuốn---");
                lst.Add(string.Format("----Tổng trang in A4: {0:0,0}", this.GiaInSachDigiS.Sum(x => x.TongSoTrangA4In())));
                lst.Add(string.Format("----Tổng tiền in: {0:0,0.00}đ", this.GiaInSachDigiS.Sum(x => x.TienInSach())));
                lst.Add(string.Format("----Tổng trị giá: {0:0,0.00}đ", this.GiaInSachDigiS.Sum(x => x.GiaChaoTong())));
                lst.Add("---Hết In cuốn---");
            }

            return lst;
        }
        public List<string> NoiDungGiaChaoKH_TheNhua()
        {
            var lst = new List<string>();
            var dSachMucTinhGia = "";

            if (this.BaiInTheNhuaS.Count > 0)
            {

                dSachMucTinhGia += string.Format("---Thẻ nhựa [{0}]---, ", this.BaiInDanhThiepS.Count);

              
                foreach (BaiInTheNhua bInTheNhua in this.BaiInTheNhuaS)
                {
                    foreach (KeyValuePair<string, string> kvp in bInTheNhua.TomTat_ChaoKH())
                    {
                        lst.Add(string.Format("{0} {1}", kvp.Key, kvp.Value));
                    }

                   
                }
                lst.Add("---Tóm tắt in Thẻ nhựa---");
                lst.Add(string.Format("----Tổng trị giá: {0:0,0.00}đ", this.BaiInTheNhuaS.Sum(x => x.ThanhTien())));                
                lst.Add("---Hết thẻ nhựa---");
            }

            return lst;
        }
        #endregion
        #region Tóm tắt tổng
        public decimal TongTriGiaChao()
        {
            decimal kq = 0;
            if (this.QuyetDinhGopTrangInBaiIn)
                kq = TongTienDanhThiep() + this.TongTienBaiInDaDieuChinhTienIn() +
                    TongTienCuon() + TongTienTheNhua();
            else
                kq = TongTienDanhThiep() + this.TongTienBaiInChuaDieuChinhGiaIn() +
                    TongTienCuon() + TongTienTheNhua();

            return kq;
        
        }
        public List<string> NoiDungGiaChaoKhachHang()
        { ///từng dòng 
            var lst = new List<string>();           
            lst.Add("----------------");//Ngăn tiêu đề
           
            var j = 0; //dùng cho các mục tính giá
            
            //Danh thiếp
            if (this.NoiDungGiaChaoKH_DanhThiep().Count > 0)
            {
                j += 1;
            
                lst.Add(string.Format("Mục {0}: ", j));
                foreach(string str in this.NoiDungGiaChaoKH_DanhThiep())
                {
                    lst.Add(string.Format("--{0}", str));
                }
               

            }
            //Phần bài in
            if (this.NoiDungGiaChaoKH_InTheoBai().Count > 0)
            {
                j += 1;
                lst.Add(string.Format("Mục {0}: ", j));
                foreach (string str in this.NoiDungGiaChaoKH_InTheoBai())
                {
                    lst.Add(string.Format("--{0}", str));
                }
                //lst.Add(string.Format("---Tổng trị giá bài in đã tính lại tiền in: {0:0,0.00}đ",
                //    this.TongTienBaiInDaDieuChinhTienIn()));
                
            }
           
            //Phần Cuốn
            if (this.NoiDungGiaChaoKH_InSach().Count > 0)
            {
                j += 1;
                
                lst.Add(string.Format("Mục {0}:", j));

               

                foreach (string str in this.NoiDungGiaChaoKH_InSach())
                {
                    lst.Add(string.Format("--{0}", str));
                }
                
            }
            //Thẻ nhựa
            if (this.NoiDungGiaChaoKH_TheNhua().Count > 0)
            {
                j += 1;

                lst.Add(string.Format("Mục {0}: ", j));
                foreach (string str in this.NoiDungGiaChaoKH_TheNhua())
                {
                    lst.Add(string.Format("--{0}", str));
                }


            }

            lst.Add("-----Tổng kết chào giá-----");            
            if (this.QuyetDinhGopTrangInBaiIn)
                lst.Add(string.Format("Bài in đã khấu trừ tiền in: {0:0,0.00}đ", TienInDaKhauTruTheoBai()));
            lst.Add(string.Format("Tổng chào giá: {0:0,0.00}đ", this.TongTriGiaChao()));

            return lst;

        }

        #endregion
    }
}
