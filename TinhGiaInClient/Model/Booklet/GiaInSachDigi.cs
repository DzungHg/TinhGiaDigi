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
        public Sach QuiCachSach { get; set; }
        public int SoCuon { get; set; }
        public BaiIn InBia { get; set; }
        public BaiIn InRuot { get; set; }
        public int IdDongCuon { get; set; }
        public int IdHangKhachHang { get; set; }
        public int TyLeMarkUpSales { get; set; }
        public int TongSoTrang
        {
            get
            {
                return this.QuiCachSach.TongSoTrang
                    * this.SoCuon;
            }
        }
        public GiaInSachDigi(Sach quiCachSach, int soCuon, int idHangKH,
            int tyLeMarkUpSales, int idDongCuon)
        {
            this.QuiCachSach = quiCachSach;
            this.SoCuon = soCuon;
            this.IdHangKhachHang = idHangKH;
            this.TyLeMarkUpSales = tyLeMarkUpSales;
            this.IdDongCuon = idDongCuon;
            //----tạo ID tăng tự động
            _lastId += 1;
            this.ID = _lastId;
        }
        public bool HieuLucGiaIn()
        {
            var kq = true;
            if (this.InRuot == null)
                kq = false;
            else 
                if (this.InRuot.GiaInS.Count <= 0)
                    kq = false;
            

            return kq;
        }
        public bool GiaInSach()
        {//Đóng cuốn phải có và giá in phải có
            var kq = true;
            if (!HieuLucGiaIn())
                kq = false;
            else
                if (this.GiaDongCuon <= 0)
                    kq = false;
            return kq;
        }
        public decimal GiaInSach()
        {///Dựa trên Id tờ chạy của ruột để tính
         ///và dựa trên tổng số trang in bao gồm bìa và ruột
            if (!this.HieuLucGiaIn()) //Ruột rỗng hoặc không có giá in
                return 0;

            decimal kq = 0;
            //Lấy mục giá in đầu tiên để tính
            var idBangGiaInNhanh = this.InRuot.GiaInS[0].IdBangGiaInNhanh;
            var idToInDigi = this.InRuot.GiaInS[0].IdMayIn;
            var giaInNhanhKetHop = new GiaInNhanhKetHopBangGia_May(this.TongSoTrang, idBangGiaInNhanh,
                idToInDigi, this.TyLeMarkUpSales);
            kq = giaInNhanhKetHop.GiaBan();

            return kq;
        }
        public decimal GiaDongCuon
        {
            /* decimal kq = 0;
             //Tùy theo Kiểu đóng cuốn bên sách mà chọn bảng để tính
             switch(this.QuiCachSach.KieuDongCuon)
             {
                 case KieuDongCuonS.Keo:
                 case KieuDongCuonS.Kim:
                     var dongCuon = DongCuon.DocTheoId(this.IdDongCuon);

                     var giaDongCuon = new GiaDongCuon(this.SoCuon, this.TyLeMarkUpSales,
                         "cuốn", dongCuon);
                     kq = giaDongCuon.ThanhTienSales();
                     break;
                 case KieuDongCuonS.LoXo:
                     var loXoDongCuon = LoXoDongCuon
                     var dongCuonLX = DongCuonLoXo.DocTheoId(this.IdDongCuon);
                     var giaDongCuonLX = new GiaDongCuonLoXo(this.SoCuon, this.QuiCachSach.ChieuCao,, this.TyLeMarkUpSales,
                         "cuốn", dongCuonLX);

             }
             return kq;
             */
            get;
            set;
        }
    }
}
