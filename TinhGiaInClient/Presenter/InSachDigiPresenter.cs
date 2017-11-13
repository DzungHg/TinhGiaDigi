using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInClient.Model.Booklet;
using TinhGiaInClient.View;
namespace TinhGiaInClient.Presenter
{
    public class InSachDigiPresenter
    {
        IViewInSachDigi View;
        GiaInSachDigi GiaSachDigi;
        public InSachDigiPresenter(IViewInSachDigi view, GiaInSachDigi giaInSach)
        {
            View = view;
            this.GiaSachDigi = giaInSach;
            //
            View.ID = this.GiaSachDigi.ID;
            View.TieuDe = this.GiaSachDigi.TieuDe;
            View.SachRong = this.GiaSachDigi.QuiCachSach.ChieuRong;
            View.SachCao = this.GiaSachDigi.QuiCachSach.ChieuCao;
            View.GayDay = this.GiaSachDigi.QuiCachSach.GayDay;
            View.KieuDongCuon = this.GiaSachDigi.QuiCachSach.KieuDongCuon;
            View.SoTrangBia = this.GiaSachDigi.QuiCachSach.SoTrangBia;
            View.SoTrangRuot = this.GiaSachDigi.QuiCachSach.SoTrangRuot;
            View.SoCuon = this.GiaSachDigi.SoCuon;
            View.Bia = this.GiaSachDigi.InBia;
            View.Ruot = this.GiaSachDigi.InRuot;
            View.GiaInChiTiet = this.GiaSachDigi.GiaInChiTiet;
            View.DongCuon = this.GiaSachDigi.DongCuon;
            View.BiaLayNgoai = this.GiaSachDigi.QuiCachSach.BiaLayNgoai;
           
        }
        public List<MonDongCuon> MonDongCuonS()
        {
            return MonDongCuon.DocTatCa();
        }
        public MonDongCuon DocMonDongCuonTheoID()
        {
            return MonDongCuon.DocTheoId(View.IdMonDongCuonChon);
        }
        
        public int TongSoTrangRuot()
        {
            return this.DocGiaSachDigi().TongSoTrangRuot;
        }
        public int TongSoTrang()
        {
            return this.DocGiaSachDigi().TongSoTrangSach;
        }
        private void CapNhatGiaSach()
        {
            this.GiaSachDigi.ID = View.ID;
            this.GiaSachDigi.TieuDe = View.TieuDe;
            this.GiaSachDigi.QuiCachSach.ChieuRong = View.SachRong;
            this.GiaSachDigi.QuiCachSach.ChieuCao = View.SachCao;
            this.GiaSachDigi.QuiCachSach.GayDay = View.GayDay;
            this.GiaSachDigi.QuiCachSach.KieuDongCuon = View.KieuDongCuon;
            this.GiaSachDigi.QuiCachSach.SoTrangBia = View.SoTrangBia;
            this.GiaSachDigi.QuiCachSach.SoTrangRuot = View.SoTrangRuot;
            this.GiaSachDigi.SoCuon = View.SoCuon;
            this.GiaSachDigi.InBia = View.Bia;
            this.GiaSachDigi.InRuot = View.Ruot;
            this.GiaSachDigi.GiaInChiTiet = View.GiaInChiTiet;
            this.GiaSachDigi.DongCuon = View.DongCuon;
            this.GiaSachDigi.QuiCachSach.BiaLayNgoai = View.BiaLayNgoai;
           
            
        }
        public GiaInSachDigi DocGiaSachDigi()
        {
            CapNhatGiaSach();
            return this.GiaSachDigi;
        }
        public bool HieuLucThietLapGiaIn()
        {
            return this.DocGiaSachDigi().HieuLucChoGiaIn();
        }
        public string ChiTietGiaIn()
        {
            var str = "";
            var giaSach = this.DocGiaSachDigi();
            if ( giaSach.GiaInChiTiet != null)
            {
                str = "Kiểu in: " + giaSach.GiaInChiTiet.TenPhuongPhapIn + '\r' + '\n'
                    + string.Format("Tổng trang A4 in: {0: 0,0} trang" + '\r' + '\n', giaSach.TongSoTrangA4In())
                    + string.Format("Tiền in: {0:0,0.00}đ" + '\r' + '\n', giaSach.TienInSach())
                    + string.Format("Giá TB/Trg: {0:0,0.00}đ" + '\r' + '\n', (decimal)giaSach.TienInSach() / giaSach.TongSoTrangSach);
            }
            
            return str;
            
        }
        public string ChiTietDongCuon() //Đã OK
        {
            var str = "";
            var giaSach = this.DocGiaSachDigi();
            if (giaSach.DongCuon != null)
            {
                str = "Đóng cuốn: " + giaSach.DongCuon.TenThanhPham + '\r' + '\n'
                    + string.Format("Số cuốn: {0: 0,0} cuốn" + '\r' + '\n', giaSach.SoCuon)
                    + string.Format("Tiền đóng cuốn: {0:0,0.00}đ" + '\r' + '\n', giaSach.DongCuon.ThanhTien)
                    + string.Format("Giá TB/cuốn: {0:0,0.00}đ" + '\r' + '\n', (decimal)giaSach.DongCuon.ThanhTien / giaSach.SoCuon);
            }

            return str;

        }
        public string TomTatChaoGia_DV()
        {
            var giaSach = this.DocGiaSachDigi();
            return giaSach.TomTatChao_DichVu();
        }
        public string TomTatChaoGia_Le()
        {
            var giaSach = this.DocGiaSachDigi();
            return giaSach.TomTatChao_KhachLe();
        }
        public string TomTatChiTiet_KyThuat()
        {
            var giaSach = this.DocGiaSachDigi();
            return giaSach.TomTatChiTiet_KyThuat();
        }
    }
}
