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
    
    public class QuanLyNhuEpKimPresenter
    {
        IViewQuanLyNhuEpKim View;
        public QuanLyNhuEpKimPresenter(IViewQuanLyNhuEpKim view)
        { 
            View = view;
            
        }
       
        public List<EpKim> EpKimS()
        {
            return EpKim.DocTatCa();
        }
        public List<NhuEpKim> NhuEpKimSTheoEpKim()
        {
                       
             return NhuEpKim.DocTheoIdEpKim(View.IdEpKim);
           
        }
        public void TrinhBayThemMoi()
        {
            View.ID = 0;
            View.Ten = "";
            View.MaNhaCungCap = "";
            View.TenNhaCungCap = "";
            View.GiaMuaCm2 = 1;
            View.DienGiai = "";
           
            View.ThuTu = 100;
        
        }
        public void TrinhBayChiTietMayIn()
        {
            if (View.ID <= 0)
                return;

            var nhuEpKim = NhuEpKim.DocTheoId(View.ID);
            View.ID = nhuEpKim.ID;
            View.Ten = nhuEpKim.Ten;
            View.DienGiai = nhuEpKim.DienGiai;
            View.MaNhaCungCap = nhuEpKim.MaNhaCungCap;
            View.TenNhaCungCap = nhuEpKim.TenNhaCungCap;
            View.GiaMuaCm2 = nhuEpKim.GiaMuaCm2;                     
            
            View.ThuTu = nhuEpKim.ThuTu;
           
            
        }
     
        public string Luu()
        {
            var kq = "";
            NhuEpKim nhuEpKim = new NhuEpKim();
            nhuEpKim.ID = View.ID;
            nhuEpKim.Ten = View.Ten;
            nhuEpKim.DienGiai = View.DienGiai;
            nhuEpKim.MaNhaCungCap = View.MaNhaCungCap;
            nhuEpKim.TenNhaCungCap = View.TenNhaCungCap;
            nhuEpKim.GiaMuaCm2 = View.GiaMuaCm2;
            nhuEpKim.IDEPKIM = View.IdEpKim;
            nhuEpKim.ThuTu = View.ThuTu;
           
            switch (View.TinhTrangForm)
            {
                case FormStateS.Edit:                                     
                    kq = NhuEpKim.Sua(nhuEpKim);
                    break;
                case FormStateS.New:
                    kq = NhuEpKim.Them(nhuEpKim);
                    break;

            }
            return kq;
        }
    }
}
