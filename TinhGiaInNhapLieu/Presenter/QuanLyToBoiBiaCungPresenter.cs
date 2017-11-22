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
    
    public class QuanLyToBoiBiaCungPresenter
    {
        IViewQuanLyToBoiBiaCung View;
        public QuanLyToBoiBiaCungPresenter(IViewQuanLyToBoiBiaCung view)
        { 
            View = view;
            
        }
       
    
        public List<ToBoiBiaCung> LoXoToBoiS()
        {

            return ToBoiBiaCung.DocTatCa();
           
        }
        public void TrinhBayThemMoi()
        {
            View.ID = 0;
            View.Ten = "";
            
            View.DoDayCm = 0.3f;
                       
            View.ThuTu = 100;
        
        }
        public void TrinhBayToBoi()
        {
            if (View.ID <= 0)
                return;

            var toBoi = ToBoiBiaCung.DocTheoId(View.ID);
            View.ID = toBoi.ID;
            View.Ten = toBoi.Ten;
            
            View.DoDayCm = toBoi.DoDayCm;
            View.GiaMuaTheoTam = toBoi.GiaMuaTo;                     
            
            View.ThuTu = toBoi.ThuTu;
           
            
        }
     
        public string Luu()
        {
            var kq = "";
            var toBoiBC = new ToBoiBiaCung();
            toBoiBC.ID = View.ID;
            toBoiBC.Ten = View.Ten;
            toBoiBC.DoDayCm = View.DoDayCm;

            toBoiBC.GiaMuaTo = View.GiaMuaTheoTam;
            
            toBoiBC.ThuTu = View.ThuTu;
           
            switch (View.TinhTrangForm)
            {
                case FormStateS.Edit:                                     
                    kq = ToBoiBiaCung.Sua(toBoiBC);
                    break;
                case FormStateS.New:
                    kq = ToBoiBiaCung.Them(toBoiBC);
                    break;

            }
            return kq;
        }
    }
}
