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
    
    public class QuanLyToLotDCMPPresenter
    {
        IViewQuanLyToLotDCMP View;
        public QuanLyToLotDCMPPresenter(IViewQuanLyToLotDCMP view)
        { 
            View = view;
            
        }
       
    
        public List<ToLotMoPhang> LoXoDongCuonS()
        {

            return ToLotMoPhang.DocTatCa();
           
        }
        public void TrinhBayThemMoi()
        {
            View.ID = 0;
            View.Ten = "";

            View.MaNhaCungCap = "MA NCC";
            View.TenNhaCungCap = "Tên NCC";
                       
            View.ThuTu = 100;
        
        }
        public void TrinhBayToBoi()
        {
            if (View.ID <= 0)
                return;

            var toLotMoPhang = ToLotMoPhang.DocTheoId(View.ID);
            View.ID = toLotMoPhang.ID;
            View.Ten = toLotMoPhang.Ten;

            View.MaNhaCungCap = toLotMoPhang.MaNhaCungCap;
            View.TenNhaCungCap = toLotMoPhang.TenNhaCungCap;
            View.GiaMuaTo = toLotMoPhang.GiaMuaTo;                     
            
            View.ThuTu = toLotMoPhang.ThuTu;
           
            
        }
     
        public string Luu()
        {
            var kq = "";
            var toLotMP = new ToLotMoPhang();
            toLotMP.ID = View.ID;
            toLotMP.Ten = View.Ten;
            toLotMP.MaNhaCungCap = View.MaNhaCungCap;
            toLotMP.TenNhaCungCap = View.TenNhaCungCap;
            toLotMP.GiaMuaTo = View.GiaMuaTo;
            
            toLotMP.ThuTu = View.ThuTu;
           
            switch (View.TinhTrangForm)
            {
                case FormStateS.Edit:                                     
                    kq = ToLotMoPhang.Sua(toLotMP);
                    break;
                case FormStateS.New:
                    kq = ToLotMoPhang.Them(toLotMP);
                    break;

            }
            return kq;
        }
    }
}
