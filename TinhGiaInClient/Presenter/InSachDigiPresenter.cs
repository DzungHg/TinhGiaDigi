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
        public InSachDigiPresenter(IViewInSachDigi view)
        {
            View = view;
        }
        public List<MonDongCuon> MonDongCuonS()
        {
            return MonDongCuon.DocTatCa();
        }
        public MonDongCuon DocTheoID()
        {
            return MonDongCuon.DocTheoId(View.IdMonDongCuonChon);
        }

    }
}
