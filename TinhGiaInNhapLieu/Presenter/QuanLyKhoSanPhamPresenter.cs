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
    
    public class QuanLyKhoSanPhamPresenter
    {
        IViewQuanLyKhoSanPham View;
        public QuanLyKhoSanPhamPresenter(IViewQuanLyKhoSanPham view)
        { 
            View = view;
            
        }
        public List<KhoSanPham> KhoSanPhamS()
        {
            return KhoSanPham.DocTatCa();
        }
        public void TrinhBayThemMoi()
        {
            View.ID = 0;
            View.Ten = "";
            View.KhoCatRong = 0;
            View.KhoCatCao = 0;
            View.DienGiai = "";
            View.ThuTu = 99;
            
        }
        public void TrinhBayChiTietMayIn()
        {
            if (View.ID <= 0)
                return;

            var khoSP = KhoSanPham.DocTheoId(View.ID);

            View.Ten = khoSP.Ten;
            View.KhoCatRong = khoSP.KhoCatRong;
            View.KhoCatCao = khoSP.KhoCatCao;
            View.DienGiai = khoSP.DienGiai;
            View.ThuTu = khoSP.ThuTu;
        }
        public void Luu()
        {
            KhoSanPham khoSPh = new KhoSanPham();
            khoSPh.ID = View.ID;
            khoSPh.Ten = View.Ten;
            khoSPh.KhoCatRong = View.KhoCatRong;
            khoSPh.KhoCatCao = View.KhoCatCao;
            khoSPh.DienGiai = View.DienGiai;
            khoSPh.ThuTu = View.ThuTu;
            switch (View.TinhTrangForm)
            {
                case FormStateS.Edit:                                     
                    KhoSanPham.Sua(khoSPh);
                    break;
                case FormStateS.New:
                    KhoSanPham.Them(khoSPh);
                    break;

            }
        }
    }
}
