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
    
    public class QuanLyMayInDigiPresenter
    {
        IViewQuanLyMayInDigi View;
        public QuanLyMayInDigiPresenter(IViewQuanLyMayInDigi view)
        { 
            View = view;
            
        }
        public List<MayInDigi> MayInDigiS()
        {
            return MayInDigi.DocTatCa();
        }
        public void TrinhBayThemMoi()
        {
            View.ID = 0;
            View.Ten = "";
            View.KhoInMin = "";
            View.KhoInMax = "";
            View.ThongTinTocDo = "";
            View.TocDoHieuQua = 0;
            View.BHR = 0;
            View.PhiPhePhamSanSang = 0;
            View.ThoiGianSanSang = 0;
            View.ClickA4_4M = 0;
            View.ClickA4_1M = 0;
            View.ClickA4_6M = 0;
        }
        public void TrinhBayChiTietMayIn()
        {
            if (View.ID <= 0)
                return;

            var mayInDigi = MayInDigi.DocTheoId(View.ID);

            View.Ten = mayInDigi.Ten;
            View.KhoInMin = mayInDigi.KhoInMin;
            View.KhoInMax = mayInDigi.KhoInMax;
            View.ThongTinTocDo = mayInDigi.ThongTinTocDo;
            View.TocDoHieuQua = mayInDigi.TocDoHieuQua;
            View.BHR = mayInDigi.BHR;
            View.PhiPhePhamSanSang = mayInDigi.PhiPhePhamSanSang;
            View.ThoiGianSanSang = mayInDigi.ThoiGianSanSang;
            View.ClickA4_4M = mayInDigi.ClickA4_4M;
            View.ClickA4_1M = mayInDigi.ClickA4_1M;
            View.ClickA4_6M = mayInDigi.ClickA4_6M;
        }
        public void Luu()
        {
            MayInDigi mayInDigi = new MayInDigi();
            mayInDigi.ID = View.ID; 
            mayInDigi.Ten = View.Ten;
            mayInDigi.KhoInMin = View.KhoInMin;
            mayInDigi.KhoInMax = View.KhoInMax;
            mayInDigi.ThongTinTocDo = View.ThongTinTocDo;
            mayInDigi.TocDoHieuQua = View.TocDoHieuQua;
            mayInDigi.BHR = View.BHR;
            mayInDigi.PhiPhePhamSanSang = View.PhiPhePhamSanSang;
            mayInDigi.ThoiGianSanSang = View.ThoiGianSanSang;
            mayInDigi.ClickA4_4M = View.ClickA4_4M;
            mayInDigi.ClickA4_1M = View.ClickA4_1M;
            mayInDigi.ClickA4_6M = View.ClickA4_6M;
            switch (View.TinhTrangForm)
            {
                case FormStateS.Edit:                                     
                    MayInDigi.Sua(mayInDigi);
                    break;
                case FormStateS.New:
                    MayInDigi.Them(mayInDigi);
                    break;

            }
        }
    }
}
