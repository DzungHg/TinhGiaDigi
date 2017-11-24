using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInNhapLieu.View;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInNhapLieu.Presenter
{
    
    public class NiemYetGiaInNhanhPresenter
    {
        IViewNiemYetGiaInNhanh View;
        public NiemYetGiaInNhanhPresenter(IViewNiemYetGiaInNhanh view)
        { 
            View = view;
            
        }
        public List<NiemYetGiaInNhanh> DanhSachNiemYet()
        {
            return NiemYetGiaInNhanh.DocTatCa();
        }
        public List<HangKhachHang> HangKhachHangS()
        {
            return HangKhachHang.LayTatCa();
        }
        public void TrinhBayThemMoi()
        {
            View.ID = 0;
            View.IdBangGia = 0;
            View.TenBangGia = "";
            View.DienGiai = "Mô tả";
            View.TenNiemYet = "";
            View.IdHangKhachHang = 0;
            View.SoTrangToiDa = 0;
            View.DuocGomTrang = false;
            View.KhongSuDung = false;
            View.LoaiBangGia = "";
            View.DaySoLuongNiemYet = ";";
            View.ThuTu = 100;
            
       
            View.KhongSuDung = false;
        }
        public void TrinhBayChiTietNiemYet()
        {
            if (View.ID <= 0)
                return;

            var niemYetGia = NiemYetGiaInNhanh.DocTheoId(View.ID);
            View.ID = niemYetGia.ID;
            View.TenNiemYet = niemYetGia.Ten;
            View.DienGiai = niemYetGia.DienGiai;
            View.IdBangGia  = niemYetGia.IdBangGia;
            View.LoaiBangGia = niemYetGia.LoaiBangGia;
            View.IdHangKhachHang = niemYetGia.IdHangKhachHang;
            View.DuocGomTrang = niemYetGia.DuocGomTrang;
            View.SoTrangToiDa = niemYetGia.SoTrangToiDa;           
            View.DaySoLuongNiemYet = niemYetGia.DaySoLuongNiemYet;
            View.ThuTu = niemYetGia.ThuTu;                      
            View.KhongSuDung = niemYetGia.KhongSuDung;
            //Cập nhật chi tiết BG
            CapNhatChiTietBangGia();

            
        }
        public string TenBangGia (int iDBangGia, string loaiBangGia)
        {
            var kq = "";
            if (iDBangGia > 0 && !string.IsNullOrEmpty(loaiBangGia))
            {
                kq  = DanhSachBangGia.DocTheoIDvaLoai(iDBangGia, loaiBangGia).Ten;               

            }
            return kq;
        }
        public string DienGiaiBangGia(int iDBangGia, string loaiBangGia)
        {
            var kq = "";
            if (iDBangGia > 0 && !string.IsNullOrEmpty(loaiBangGia))
            {
                kq = DanhSachBangGia.DocTheoIDvaLoai(iDBangGia, loaiBangGia).DienGiai;

            }
            return kq;
        }
        public void CapNhatChiTietBangGia()
        {
            try
            {
                if (View.IdBangGia > 0 && !string.IsNullOrEmpty(View.LoaiBangGia))
                {
                    var bangGia = DanhSachBangGia.DocTheoIDvaLoai(View.IdBangGia, View.LoaiBangGia);
                    View.TenBangGia = bangGia.Ten;

                }
            }
            catch
            { }
        }
        public string DienGiaiHangKH()
        {
            var kq = "";
            if (View.IdHangKhachHang > 0)
                kq = HangKhachHang.LayTheoId(View.IdHangKhachHang).DienGiai;

            return kq;
        }
        
        public void Luu(ref string thongDiep)
        {
            var niemYetGia = new NiemYetGiaInNhanh();
            niemYetGia.ID = View.ID;
            niemYetGia.Ten = View.TenNiemYet;
            niemYetGia.DienGiai = View.DienGiai;
            niemYetGia.IdBangGia = View.IdBangGia;
          
            niemYetGia.IdHangKhachHang = View.IdHangKhachHang;
            niemYetGia.LoaiBangGia = View.LoaiBangGia;
            niemYetGia.SoTrangToiDa = View.SoTrangToiDa;
           
            niemYetGia.DaySoLuongNiemYet = View.DaySoLuongNiemYet;
           
            niemYetGia.ThuTu = View.ThuTu;
            niemYetGia.KhongSuDung = View.KhongSuDung;
            niemYetGia.DuocGomTrang = View.DuocGomTrang;
            switch (View.TinhTrangForm)
            {
                case FormStateS.Edit:
                    NiemYetGiaInNhanh.Sua(ref thongDiep, niemYetGia);
                    break;
                case FormStateS.New:
                    thongDiep =  NiemYetGiaInNhanh.Them(niemYetGia);
                    break;

            }

        }
    }
}
