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
            return this.GiaSach.TongSoTrangRuot;
        }
        public int TongSoTrang()
        {
            return this.GiaSach.TongSoTrang;
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
            //Cập nhật bìa không cần cập nhật một số reference
            this.GiaSach.InBia = View.Bia;
            this.GiaSach.InRuot = View.Ruot;
            this.GiaSach.GiaInChiTiet = View.GiaInChiTiet;
            this.GiaSach.DongCuon = View.DongCuon;
           
            //Cập nhật thành phẩm

            this.GiaSach.SoCuon = View.SoCuon;
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
            var giaIn = this.DocGiaSachDigi().GiaInChiTiet;
            if ( giaIn != null)
            {
                str = "Kiểu in: " + giaIn.TenPhuongPhapIn + '\r' + '\n'
                    + string.Format("Tổng trang in: {0: 0,0} trang" + '\r' + '\n', this.TongSoTrang())
                    + string.Format("Tiền in: {0:0,0.00}đ" + '\r' + '\n', this.GiaSach.TienInSach())
                    + string.Format("Giá TB/Trg: {0:0,0.00}đ" + '\r' + '\n', (decimal)this.GiaSach.TienInSach() / this.GiaSach.TongSoTrang);
            }
            
            return str;
            
        }
        public string ChiTietDongCuon()
        {
            var str = "";
            var dongCuon = this.DocGiaSachDigi().DongCuon;
            if (dongCuon != null)
            {
                str = "Đóng cuốn: " + dongCuon.TenThanhPham + '\r' + '\n'
                    + string.Format("Số cuốn: {0: 0,0} cuốn" + '\r' + '\n', this.GiaSach.SoCuon)
                    + string.Format("Tiền đóng cuốn: {0:0,0.00}đ" + '\r' + '\n', this.GiaSach.DongCuon.ThanhTien)
                    + string.Format("Giá TB/cuốn: {0:0,0.00}đ" + '\r' + '\n', (decimal)this.GiaSach.DongCuon.ThanhTien / this.GiaSach.SoCuon);
            }

            return str;

        }
        public string TomTatChaoGia_DV()
        {
            return this.DocGiaSachDigi().TomTatChao_DichVu();
        }
        public string TomTatChaoGia_Le()
        {
            return this.DocGiaSachDigi().TomTatChao_KhachLe();
        }
    }
}
