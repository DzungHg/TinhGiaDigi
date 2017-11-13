using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInClient.View;
using TinhGiaInClient.Model.Support;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.Presenter
{
  
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
        public LoaiThanhPhamS DocLoaiThanhPham ()
        {
            var monThPh = MonThanhPham.DocDVThanhPhamTheoId(View.IdMonThanhPham);
            return monThPh.LoaiThPham;
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
                case LoaiThanhPhamS.CanPhu: //Tính theo A4 vậy
                    var giaCanPhu = new GiaCanPhu(soLuong, 32, 22, 1, TiLeMarkUpTheoHangKH(), CanPhu.DocTheoId(iDThanhPham));
                    ketQua = giaCanPhu.ThanhTienSales();
                    break;
                case LoaiThanhPhamS.CanGap:
                    //Làm tạm 2 đường
                    var giaCanGap = new GiaCanGap(soLuong, 2, TiLeMarkUpTheoHangKH(), View.DonViTinh, CanGap.DocTheoId(iDThanhPham));
                    ketQua = giaCanGap.ThanhTienSales();
                    break;
                case LoaiThanhPhamS.DongCuon:
                    var giaDongCuon = new GiaDongCuon(soLuong, TiLeMarkUpTheoHangKH(), View.DonViTinh, DongCuon.DocTheoId(iDThanhPham));
                    ketQua = giaDongCuon.ThanhTienSales();
                    break;
                case LoaiThanhPhamS.EpKim:
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
        public string LuuDaySoLuong()
        {
            var mg = "";
            var iDThanhPham = MonThanhPham.DocDVThanhPhamTheoId(View.IdMonThanhPham).ID_DV;
            var LoaiTP = MonThanhPham.DocDVThanhPhamTheoId(View.IdMonThanhPham).LoaiThPham;
            switch (LoaiTP)
            {
                case LoaiThanhPhamS.CanPhu:
                    var canPhu = CanPhu.DocTheoId(iDThanhPham);
                    canPhu.DaySoLuongNiemYet = View.DaySoluong;
                    mg = CanPhu.Sua(canPhu);
                    break;
                case LoaiThanhPhamS.CanGap:
                    var canGap = CanGap.DocTheoId(iDThanhPham);
                    canGap.DaySoLuongNiemYet = View.DaySoluong;
                    mg = CanGap.Sua(canGap);
                    break;
                case LoaiThanhPhamS.DongCuon:
                    var dongCuon = DongCuon.DocTheoId(iDThanhPham);
                    dongCuon.DaySoLuongNiemYet = View.DaySoluong;
                    mg = DongCuon.Sua(dongCuon);
                    break;
                case LoaiThanhPhamS.EpKim:
                    var epKim = EpKim.DocTheoId(iDThanhPham);
                    epKim.DaySoLuongNiemYet = View.DaySoluong;
                    mg = EpKim.Sua(epKim);
                    break;
            }
            return mg;
        }
    }

}
