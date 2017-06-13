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
        GiaInSachDigi GiaSach;
        public InSachDigiPresenter(IViewInSachDigi view, GiaInSachDigi giaInSach)
        {
            View = view;
            this.GiaSach = giaInSach;

            //
            View.ID = this.GiaSach.ID;
            View.TieuDe = this.GiaSach.TieuDe;
            View.SachRong = this.GiaSach.QuiCachSach.ChieuRong;
            View.SachCao = this.GiaSach.QuiCachSach.ChieuCao;
            View.GayDay = this.GiaSach.QuiCachSach.GayDay;
            View.KieuDongCuon = this.GiaSach.QuiCachSach.KieuDongCuon;
            View.SoTrangBia = this.GiaSach.QuiCachSach.SoTrangBia;
            View.SoTrangRuot = this.GiaSach.QuiCachSach.SoTrangRuot;
            View.SoCuon = this.GiaSach.SoCuon;
            View.Bia = this.GiaSach.InBia;
            View.Ruot = this.GiaSach.InRuot;
            View.GiaInChiTiet = this.GiaSach.GiaInChiTiet;
            View.DongCuon = this.GiaSach.DongCuon;
           
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
            this.GiaSach.ID = View.ID;
            this.GiaSach.TieuDe = View.TieuDe;
            this.GiaSach.QuiCachSach.ChieuRong = View.SachRong;
            this.GiaSach.QuiCachSach.ChieuCao = View.SachCao;
            this.GiaSach.QuiCachSach.GayDay = View.GayDay;
            this.GiaSach.QuiCachSach.KieuDongCuon = View.KieuDongCuon;
            this.GiaSach.QuiCachSach.SoTrangBia = View.SoTrangBia;
            this.GiaSach.QuiCachSach.SoTrangRuot = View.SoTrangRuot;
            this.GiaSach.SoCuon = View.SoCuon;
            //Cập nhật bìa không cần cập nhật một số reference
            //this.GiaSach.InBia = View.Bia;
           // this.GiaSach.InRuot = View.Ruot;
            //this.GiaSach.GiaInChiTiet = View.GiaInChiTiet;
            //this.GiaSach.DongCuon = View.DongCuon;
           
            //Cập nhật thành phẩm

            
        }
        public GiaInSachDigi DocGiaSachDigi()
        {
            CapNhatGiaSach();
            return this.GiaSach;
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
    }
}
