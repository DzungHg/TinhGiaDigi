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
    
    public class QuanLyLoXoDongCuonPresenter
    {
        IViewQuanLyLoXoDongCuon View;
        public QuanLyLoXoDongCuonPresenter(IViewQuanLyLoXoDongCuon view)
        { 
            View = view;
            
        }
       
    
        public List<LoXoDongCuon> LoXoDongCuonS()
        {

            return LoXoDongCuon.DocTatCa();
           
        }
        public void TrinhBayThemMoi()
        {
            View.ID = 0;
            View.Ten_VongXoan = "";
            View.KichCoBuoc = "";
            View.MauSac = "";
            View.GiaMuaTheoMet = 1;
            View.ChoDoDay = "";
           
            View.ThuTu = 100;
        
        }
        public void TrinhBayLoXo()
        {
            if (View.ID <= 0)
                return;

            var loXo = LoXoDongCuon.DocTheoId(View.ID);
            View.ID = loXo.ID;
            View.Ten_VongXoan = loXo.TenVongXoan;
            View.ChoDoDay = loXo.ChoDoDay;
            View.KichCoBuoc = loXo.KichCoBuoc;
            View.MauSac = loXo.MauSac;
            View.GiaMuaTheoMet = loXo.GiaMuaTheoMet;                     
            
            View.ThuTu = loXo.ThuTu;
           
            
        }
     
        public string Luu()
        {
            var kq = "";
            var loXoDongCuon = new LoXoDongCuon();
            loXoDongCuon.ID = View.ID;
            loXoDongCuon.TenVongXoan = View.Ten_VongXoan;
            loXoDongCuon.ChoDoDay = View.ChoDoDay;
            loXoDongCuon.KichCoBuoc = View.KichCoBuoc;
            loXoDongCuon.MauSac = View.MauSac;
            loXoDongCuon.GiaMuaTheoMet = View.GiaMuaTheoMet;
            
            loXoDongCuon.ThuTu = View.ThuTu;
           
            switch (View.TinhTrangForm)
            {
                case FormStateS.Edit:                                     
                    kq = LoXoDongCuon.Sua(loXoDongCuon);
                    break;
                case FormStateS.New:
                    kq = LoXoDongCuon.Them(loXoDongCuon);
                    break;

            }
            return kq;
        }
    }
}
