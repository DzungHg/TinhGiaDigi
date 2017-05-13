using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TinhGiaInClient.Model;
using TinhGiaInClient.View;

namespace TinhGiaInClient.Presenter
{
    public struct SoLuong_Gia 
    {
        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }
        public decimal Gia
        {
            get { return _gia; }
            set { _gia = value; }
        }
        public decimal GiaTrungBinhDonVi()
        {
            return _gia / _soLuong;
        }
        public SoLuong_Gia(int soLuong, decimal gia)
        {
            _soLuong = soLuong;
            _gia = gia;
        }
        private int _soLuong;
        private decimal _gia;
    }
    public struct SoLuongTinh
    {
        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        
        public SoLuongTinh(int iD, int soLuong)
        {
            _soLuong = soLuong;
            _id = iD;
        }
        private int _soLuong;
        private int _id;
    }
    public class BangGiaThanhPhamPresenter
    {
        /// <summary>
        /// Việc tính toán hoạt động hơi chậm nên cần lưu trữ trên bộ nhớ trước khi tính toán
        /// </summary>



        IViewBangGiaThanhPham View;
        public BangGiaThanhPhamPresenter(IViewBangGiaThanhPham view)
        {
            View = view;
            
        }
        
        public List<HangKhachHang>HangKhachHangS()
        {
            return HangKhachHang.LayTatCa();
        }
        public string TenHangKhachHang()
        {
            return HangKhachHang.LayTheoId(View.IdHangKHChon).Ten;

        }
        public int TiLeMarkUpTheoHangKH ()
        {
            return HangKhachHang.LayTheoId(View.IdHangKHChon).LoiNhuanChenhLech;
        }
        public List<DichVuThanhPham> DichVuThanhPhamS()
        {
            return MonThanhPham.DocTatCaDichVuThanhPham();
        }
       
        public void TrinhBayDuLieuThanhPhamTheoMon()
        {
            var monThPh = MonThanhPham.DocDVThanhPhamTheoId(View.IdMonThanhPham);
            //var count = MonThanhPham.DocTatCaDichVuThanhPham().Count();
            
           View.DaySoluong = monThPh.DaySoLuongNiemYet;
           View.DonViTinh = monThPh.DonViTinh;
        }
        public SoLuongTinh [] SoLuongTinhS()
        {
            var soLuongS = View.DaySoluong.Split(';');
            
            var arrSL = new SoLuongTinh[soLuongS.Count()];
            var j = 1;
            for (int i = 0; i < arrSL.Length; i++ )
            {
                SoLuongTinh soLuongTinh = new SoLuongTinh(i, int.Parse(soLuongS[i]));
                arrSL[i] = soLuongTinh;
                j += 1;
            }

            return arrSL;
        }
        public SoLuongTinh DocSoLuongTinhTheoId(int iD)
        {
            return this.SoLuongTinhS().FirstOrDefault(x => x.ID == iD);
        }
        private decimal GiaThPhamTheoSLuong( int soLuong)
        {
            decimal ketQua = 0;
            var iDThanhPham = MonThanhPham.DocDVThanhPhamTheoId(View.IdMonThanhPham).ID_DV;
            var LoaiTP = MonThanhPham.DocDVThanhPhamTheoId(View.IdMonThanhPham).LoaiThPham;
            switch (LoaiTP)
            {
                case LoaiThanhPham.CanPhu:
                    var giaCanPhu = new GiaCanPhu(soLuong, View.DonViTinh, TiLeMarkUpTheoHangKH(), CanPhu.DocTheoId(iDThanhPham));
                    ketQua = giaCanPhu.ThanhTienSales();
                    break;
                case LoaiThanhPham.CanGap:
                    var giaCanGap = new GiaCanGap(soLuong, TiLeMarkUpTheoHangKH(), View.DonViTinh, CanGap.DocTheoId(iDThanhPham));
                    ketQua = giaCanGap.ThanhTienSales();
                    break;
                case LoaiThanhPham.DongCuon:
                    var giaDongCuon = new GiaDongCuon(soLuong, TiLeMarkUpTheoHangKH(), View.DonViTinh, DongCuon.DocTheoId(iDThanhPham));
                    ketQua = giaDongCuon.ThanhTienSales();
                    break;
                case LoaiThanhPham.EpKim:
                    //var giaEpKim = new GiaEpKim(soLuong, 5,5, 10, CanPhu.DocTheoId(iDThanhPham));
                    ketQua = 0;
                    break;
            }
            return ketQua;
        }
        public SoLuong_Gia KetQuaSoLuongGia(int soLuong)
        {
            var sL_G = new SoLuong_Gia(soLuong,
                        GiaThPhamTheoSLuong(soLuong));
            return sL_G;
        }
        public SoLuong_Gia[] SoLuong_GiaS()
        {

            var soLuongS = View.DaySoluong.Split(';');
            var kQSoluong_gia = new SoLuong_Gia[soLuongS.Count()];
            if (soLuongS.Count() > 0) 
            {
                SoLuong_Gia sLG;
                var i = 0;
                foreach (string st in soLuongS)
                {
                    sLG = new SoLuong_Gia(int.Parse(st), 
                        GiaThPhamTheoSLuong(int.Parse(st)));
                    kQSoluong_gia[i] = sLG;
                    i++;
                }
            }
            return kQSoluong_gia;
        }
       private void LuuDaySoLuong()
        {
            decimal ketQua = 0;
            var iDThanhPham = MonThanhPham.DocDVThanhPhamTheoId(View.IdMonThanhPham).ID_DV;
            var LoaiTP = MonThanhPham.DocDVThanhPhamTheoId(View.IdMonThanhPham).LoaiThPham;
            switch (LoaiTP)
            {
                case LoaiThanhPham.CanPhu:
                    var canPhu = new CanPhu();
                    canPhu.DaySoLuongNiemYet = View.DaySoluong;
                    
                        (soLuong, View.DonViTinh, TiLeMarkUpTheoHangKH(), CanPhu.DocTheoId(iDThanhPham));
                    ketQua = canPhu.ThanhTienSales();
                    break;
                case LoaiThanhPham.CanGap:
                    var giaCanGap = new GiaCanGap(soLuong, TiLeMarkUpTheoHangKH(), View.DonViTinh, CanGap.DocTheoId(iDThanhPham));
                    ketQua = giaCanGap.ThanhTienSales();
                    break;
                case LoaiThanhPham.DongCuon:
                    var giaDongCuon = new GiaDongCuon(soLuong, TiLeMarkUpTheoHangKH(), View.DonViTinh, DongCuon.DocTheoId(iDThanhPham));
                    ketQua = giaDongCuon.ThanhTienSales();
                    break;
                case LoaiThanhPham.EpKim:
                    //var giaEpKim = new GiaEpKim(soLuong, 5,5, 10, CanPhu.DocTheoId(iDThanhPham));
                    ketQua = 0;
                    break;
            }
            return ketQua;
    }

}
