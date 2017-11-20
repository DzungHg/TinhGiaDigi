using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInClient.View;
using TinhGiaInClient.Model.Support;

namespace TinhGiaInClient.Presenter
{
  
    public class BangGiaInNhanhPresenter
    {
        /// <summary>
        /// Việc tính toán hoạt động hơi chậm nên cần lưu trữ trên bộ nhớ trước khi tính toán
        /// </summary>



        IViewBangGiaInNhanh View;
        public BangGiaInNhanhPresenter(IViewBangGiaInNhanh view)
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
        public int TyLeMarkUpTheoHangKH ()
        {
            return HangKhachHang.LayTheoId(View.IdHangKHChon).LoiNhuanChenhLech;
        }
        public List<NiemYetGiaInNhanh> NiemYetGiaInNhanhS()
        {
            return NiemYetGiaInNhanh.DocConDungTheoIdHangKH(View.IdHangKHChon);
        }
       
        public void TrinhBayDuLieuInNhanhChon()
        {
            var niemYetGia = NiemYetGiaInNhanh.DocTheoId(View.IdNiemYetGiaChon);
            //var count = MonThanhPham.DocTatCaDichVuThanhPham().Count();
            /*List<string> lst = bangGiaInNhanh.NoiDungBangGia.Split(';').ToList();
            View.NoiDungBangGia = "";
            foreach (string str in lst)
            {
                View.NoiDungBangGia += str +'\n' + '\r';
            }
             
            View.DaySoluong = bangGiaInNhanh.DaySoLuongNiemYet;
            View.DonViTinh = "Trang A4";
            */
            View.DaySoluong = niemYetGia.DaySoLuongNiemYet;
            View.NoiDungBangGia = "";
            View.SoTrangToiDaTheoNiemYet = niemYetGia.SoTrangToiDa;
        }
        private BangGiaBase DocBangGiaChon()
        {
            BangGiaBase kq = null;
            if (View.IdNiemYetGiaChon > 0)
            {
                var niemYetGia = NiemYetGiaInNhanh.DocTheoId(View.IdNiemYetGiaChon);

                kq = DanhSachBangGia.DocTheoIDvaLoai(niemYetGia.IdBangGia,
                    niemYetGia.LoaiBangGia);
            }
            return kq;
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
        private decimal GiaInNhanhTheoSLuong( int soLuong)
        {          
            decimal ketQua = 0;
            //ketQua = new GiaInNhanhTheoBang(soLuong, View.IdBangGiaChon).ThanhTienSales();            
            ketQua = new GiaInNhanhKetHopBangGia_May(soLuong, this.DocBangGiaChon(), View.SoTrangToiDaTheoNiemYet, 1,
                this.TyLeMarkUpTheoHangKH()).GiaBan(); //Mã tờ in chọn 1 vì chuẩn luôn            
            return ketQua;
        }
        public SoLuong_Gia KetQuaSoLuongGia(int soLuong)
        {
            var sL_G = new SoLuong_Gia(soLuong,
                        GiaInNhanhTheoSLuong(soLuong));
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
                        GiaInNhanhTheoSLuong(int.Parse(st)));
                    kQSoluong_gia[i] = sLG;
                    i++;
                }
            }
            return kQSoluong_gia;
        }
        public string LuuDaySoLuong()
        {
            var mg = "";
            var bangGia = BangGiaInNhanh.DocTheoId( View.IdNiemYetGiaChon);
            bangGia.DaySoLuongNiemYet = View.DaySoluong;
            BangGiaInNhanh.Sua(ref mg, bangGia);

            return mg;
        }
    }

}
