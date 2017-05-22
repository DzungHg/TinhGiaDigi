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
  
    public class BangGiaInNhanhMayPresenter
    {
        /// <summary>
        /// Việc tính toán hoạt động hơi chậm nên cần lưu trữ trên bộ nhớ trước khi tính toán
        /// </summary>



        IViewBangGiaInNhanhMay View;
        public BangGiaInNhanhMayPresenter(IViewBangGiaInNhanhMay view)
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
        public List<ToInMayDigi> BangGiaInNhanhS()
        {
            return ToInMayDigi.DocTatCa();
        }
       
        public void TrinhBayDuLieuInNhanhChon()
        {
            var bangGiaInNhanh = ToInMayDigi.DocTheoId(View.IdToInDigiChon);
             
            View.DaySoluong = bangGiaInNhanh.DaySoLuongNiemYet;
            View.DonViTinh = "Trang A4";
        
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
            var toInDiGi = ToInMayDigi.DocTheoId(View.IdToInDigiChon);
            var duLieuDeTinh = new DuLieuTinhGiaInNhanhTheoMay();
             duLieuDeTinh.TocDo = toInDiGi.TocDo * toInDiGi.QuiA4;//Quan trọng qui A4
                duLieuDeTinh.InTuTro = toInDiGi.InTuTro;
                duLieuDeTinh.ClickTrangA4 = toInDiGi.ClickA4BonMau; //Chọn 4 màu
                duLieuDeTinh.BHR = toInDiGi.BHR;
                duLieuDeTinh.PhiPhePhamSanSang = toInDiGi.PhiPhePhamSanSang;
                duLieuDeTinh.ThoiGianSanSang = toInDiGi.ThoiGianSanSang;               
                duLieuDeTinh.DaySoLuong = toInDiGi.DaySoLuong;
                duLieuDeTinh.DayLoiNhuan = toInDiGi.DayLoiNhuan;

            ketQua = new GiaInNhanhTheoMay(duLieuDeTinh, soLuong, TyLeMarkUpTheoHangKH()).ThanhTienSales();            
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
            var bangGia = ToInMayDigi.DocTheoId( View.IdToInDigiChon);
            bangGia.DaySoLuongNiemYet = View.DaySoluong;
            ToInMayDigi.Sua(ref mg, bangGia);

            return mg;
        }
    }

}
