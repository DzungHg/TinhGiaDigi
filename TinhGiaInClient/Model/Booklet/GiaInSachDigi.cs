using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model.Booklet
{
    public class GiaInSachDigi
    {//Sách có thể không có bìa nhưng bắt buộc phải có ruột
        private static int _lastId = 0;
        public int ID
        {
            get;
            set;
        }
        public string TieuDe { get; set; }
        public Sach QuiCachSach { get; set; }
        public int SoCuon { get; set; }
        public BaiIn InBia { get; set; }
        public BaiIn InRuot { get; set; }
        public MucThanhPham DongCuon { get; set; }
        public MucGiaIn GiaInChiTiet { get; set; }
        public int IdDongCuon { get; set; }
        public int IdHangKhachHang { get; set; }
      
        public int TongSoTrangRuot
        {
            get { return this.QuiCachSach.SoTrangRuot * SoCuon; }
        }
        public int TongSoTrangSach
        {
            get
            {
                return this.QuiCachSach.TongSoTrang
                    * this.SoCuon;
            }
        }
        public GiaInSachDigi(Sach quiCachSach, int soCuon, int idHangKH,
            int idDongCuon, string tieuDe)
        {
            this.QuiCachSach = quiCachSach;
            this.SoCuon = soCuon;
            this.IdHangKhachHang = idHangKH;
           
            this.IdDongCuon = idDongCuon;
            this.TieuDe = tieuDe;
            //----tạo ID tăng tự động
            _lastId += 1;
            this.ID = _lastId;
        }

        public bool HieuLucChoGiaIn()
        {
            var kq = true;
            if (this.InRuot == null)
                kq = false;
            else 
                if (this.InRuot.GiaInS.Count <= 0)
                    kq = false;
            

            return kq;
        }
        public bool HieuLucTongThe()
        {//Đóng cuốn phải có và giá in phải có
            var kq = true;
            if (!HieuLucChoGiaIn())
                kq = false;
            else
                if (this.TienDongCuon() <= 0)
                    kq = false;
            return kq;
        }
        public string TenDongCuon()
        {
            var kq = "";
            if (this.DongCuon != null)
            {
                kq = this.DongCuon.TenThanhPham;
            }
            return kq;
        }
        public string TenGiayInBia()
        {
            var kq = "";
            if (this.InBia != null)
            {
                if (this.InBia.CoGiayIn)
                    kq = this.InBia.GiayDeInIn.TenGiayIn;
            }
            return kq;
        }
        public string TenGiayInRuot()
        {
            var kq = "";
            if (this.InRuot != null)
            {
                if (this.InRuot.CoGiayIn)
                    kq = this.InRuot.GiayDeInIn.TenGiayIn;
            }
            return kq;
        }
        public string LietKeDichVuThanhPhamBia()
        {
            var kq = "";
            if (this.InBia != null)
            {
                if (this.InBia.CoGiayIn)
                    kq = this.InBia.LietKeCacDichVuThanhPham();
            }
            return kq;
        }
        #region về IN
        public int TongSoTrangA4In()
        {
            int kqBia = 0, kqRuot = 0;
            if (this.InBia != null)
            {
                kqBia = this.InBia.TongSoTrangInA4();
            }
            if (this.InRuot != null)
            {
                kqRuot = this.InRuot.TongSoTrangInA4();
            }
            return kqBia + kqRuot;
        }
        public decimal TienInSach()
        {///Dựa trên Id tờ chạy của ruột để tính
         ///và dựa trên tổng số trang in bao gồm bìa và ruột
            if (!this.HieuLucChoGiaIn()) //Ruột rỗng hoặc không có giá in
                return 0;

            decimal kq = 0;
            //Lấy mục giá in đầu tiên để tính
            var idBangGiaInNhanh = this.InRuot.GiaInS[0].IdNiemYetGiaInNhanh;
            var idToInDigi = this.InRuot.GiaInS[0].IdMayIn;
            var tyLeMarkUpSalesIn = HangKhachHang.LayTheoId(this.IdHangKhachHang).LoiNhuanChenhLech;
            /// Đoạn này tạm ngừng vì giá in cataloque là riêng //đã sửa lại
            ///var giaInNhanhKetHop = new GiaInNhanhKetHopBangGia_May(this.TongSoTrangA4In(), idBangGiaInNhanh,
            ///    idToInDigi, tyLeMarkUpSalesIn);
            ///kq = giaInNhanhKetHop.GiaBan();
            kq = this.InBia.TongTienIn() + this.InRuot.TongTienIn();
            return kq;
            
        }
        #endregion

        #region Tính các tổng
        public decimal TienDongCuon()
        {
            decimal kq = 0;
            if (this.DongCuon != null)
            {
                kq = this.DongCuon.ThanhTien;
            }

            return kq;
        }
      
      
        public decimal TienGiayInBia()
        {
            decimal kqBia = 0;
            if (this.InBia != null)
            {
                if (this.InBia.CoGiayIn)
                    kqBia = this.InBia.GiayDeInIn.ThanhTienGiay;
            }
            return kqBia;
        }
        public decimal TienGiayInRuot()
        {
            decimal kqRuot = 0;
            if (this.InRuot != null)
            {
                if (this.InRuot.CoGiayIn)
                    kqRuot = this.InRuot.GiayDeInIn.ThanhTienGiay;
            }

            return kqRuot;
        }
        public decimal TienThanhPhamBia()
        {//Phải trừ tiền in vì in chung
            decimal kqBia = 0;
            if (this.InBia != null)
            {                
                kqBia = this.InBia.TienThanhPham();
            }
            return kqBia;
        }

        public decimal TienThanhPhamRuot()
        {//Phải trừ tiền in vì in chung
            decimal kq = 0;
            if (this.InRuot != null)
            {
                kq = this.InRuot.TienThanhPham();
            }
            return kq;
        }
        public decimal TienThanhPhamBiaVaRuot()
        {
            return this.TienThanhPhamBia() + this.TienThanhPhamRuot();
        }
        public decimal TienGiay()
        {
            return this.TienGiayInBia() + this.TienGiayInRuot();
        }
        public decimal GiaChaoTong()
        {
            return this.TienGiay() + this.TienThanhPhamBiaVaRuot() 
                    + this.TienInSach() + this.TienDongCuon();
        }
        public decimal GiaTBTrenCuon()
        {
            return Math.Round(this.GiaChaoTong() /this.SoCuon, 0);
        }
        #endregion
        #region Tóm tắt thông tin
        private string TomTatQuiCach()
        {
            var str = "";
            var strThongTinBia = "";
            if (this.QuiCachSach.BiaLayNgoai)
                strThongTinBia = " Bìa ngoài ";

            str = this.TieuDe + '\r' + '\n'
                + string.Format( " + Khổ: {0} x {1}cm" + '\r' + '\n',
                    this.QuiCachSach.ChieuRong, this.QuiCachSach.ChieuCao)
                + string.Format( " + Số lượng: {0} cuốn" + '\r' + '\n',
                    this.SoCuon)
                + string.Format( " + Số trang/Cuốn: {0:0,0} trg" + '\r' + '\n',
                    this.QuiCachSach.TongSoTrang)
                + string.Format( " ++ Bìa: {0}/{1} trang" + '\r' + '\n',
                    strThongTinBia, this.QuiCachSach.SoTrangBia)
                + string.Format( " +++ Giấy in Bìa: {0}" + '\r' + '\n',
                    this.TenGiayInBia())
                + string.Format(" +++ Th. phẩm Bìa: {0}" + '\r' + '\n',
                    this.LietKeDichVuThanhPhamBia())
                + string.Format( " ++ Ruột: {0} trang" + '\r' + '\n',
                    this.QuiCachSach.SoTrangRuot)
                + string.Format( " +++ Giấy in Ruột: {0}" + '\r' + '\n',
                    this.TenGiayInRuot())
                + string.Format( " + Đóng cuốn: {0}" + '\r' + '\n',
                    this.TenDongCuon())
                + "--------------" + '\r' + '\n';

            return str;
        }
        public string TomTatChao_KhachLe()
        {
            var str = "";
            //Tiếp các tổng
            str = string.Format(" + Tổng trị giá: {0: 0,0.00}đ" + '\r' + '\n',
                    this.GiaChaoTong())
                    + string.Format(" + Giá: {0: 0,0.00}đ / cuốn" + '\r' + '\n',
                    this.GiaTBTrenCuon());
            //Gộp đầu và đuôi
            return this.TomTatQuiCach() + str;
        }
        public string TomTatChao_DichVu()
        {
            var str = "";
            //Tiếp các tổng
            str = string.Format(" + Tổng tiền giấy: {0:0,0.00}đ" + '\r' + '\n',
                    this.TienGiay())                    
                    + string.Format(" + Tổng tiền In: {0:0,0.00}đ / {1:0,0} trg" + '\r' + '\n',
                    this.TienInSach(), this.TongSoTrangA4In())
                    + string.Format(" + Tiền thành phẩm và đóng cuốn: {0: 0,0.00}đ" + '\r' + '\n',
                    this.TienThanhPhamBiaVaRuot() + this.TienDongCuon())
                    + string.Format(" + Tổng trị giá: {0: 0,0.00}đ" + '\r' + '\n',
                    this.GiaChaoTong())
                    + string.Format(" + Giá: {0: 0,0.00}đ / cuốn" + '\r' + '\n',
                    this.GiaTBTrenCuon());
                 
            //Gộp đầu và đuôi
            return this.TomTatQuiCach() + str;
        }
        public string TomTatChiTiet_KyThuat()
        {
            var str = "";
            //Tiếp các tổng
            str = string.Format(" + Tiền giấy bìa: {0:0,0.00}đ" + '\r' + '\n',
                    this.TienGiayInBia())
                    + string.Format(" + Tiền giấy ruột: {0:0,0.00}đ" + '\r' + '\n',
                    this.TienGiayInRuot())
                    + string.Format(" + Tổng tiền giấy: {0:0,0.00}đ" + '\r' + '\n',
                    this.TienGiay())
                    + string.Format(" + Tổng tiền In: {0:0,0.00}đ / {1:0,0} trg" + '\r' + '\n',
                    this.TienInSach(), this.TongSoTrangA4In())
                    + string.Format(" + Tiền thành phẩm và đóng cuốn: {0: 0,0.00}đ" + '\r' + '\n',
                    this.TienThanhPhamBiaVaRuot() + this.TienDongCuon())
                    + string.Format(" + Tổng trị giá: {0: 0,0.00}đ" + '\r' + '\n',
                    this.GiaChaoTong())
                    + string.Format(" + Giá: {0: 0,0.00}đ / cuốn" + '\r' + '\n',
                    this.GiaTBTrenCuon());

            //Gộp đầu và đuôi
            return this.TomTatQuiCach() + str;
        }

        #endregion

    }
}
