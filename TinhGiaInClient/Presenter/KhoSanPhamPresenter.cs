using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInClient.View;


namespace TinhGiaInClient.Presenter
{
    public class KhoSanPhamPresenter
    {
        IViewKhoSanPham View;
        public KhoSanPhamPresenter(IViewKhoSanPham view)
        {
            View = view;
        }
        public Dictionary<int,List<string>> KhoSanPhamS()
        {
            var dict = new Dictionary<int, List<string>>();
            List<string> lst;
            var khoSp = "";
            //điền dữ liệu
            foreach (KhoSanPham kho in KhoSanPham.DocTatCa())
            {
                lst = new List<string>();
                lst.Add(kho.Ten);             
                khoSp = string.Format("{0} x {1}cm", kho.KhoCatRong, kho.KhoCatCao);
                lst.Add(khoSp);
                lst.Add(kho.DienGiai);
                //Add vô
                dict.Add(kho.ID, lst);
            }
            return dict;
        }

        public void CapNhatChiTietKhoSanPham()
        {
            if (View.IdChon > 0)
            {
                var khoSP = KhoSanPham.DocTheoId(View.IdChon);
                View.Rong = khoSP.KhoCatRong;
                View.Cao = khoSP.KhoCatCao;
                View.TenKho = khoSP.Ten;
                View.TranLeTren = khoSP.TranLeTren;
                View.TranLeDuoi = khoSP.TranLeDuoi;
                View.TranLeTrong = khoSP.TranLeTrong;
                View.TranLeNgoai = khoSP.TranLeNgoai;
            }
            else
            {
                View.Rong = 0;
                View.Cao = 0;
                View.TenKho = "";
            }

        }
        public KhoSanPham LayKhoSanPham()
        {
            if (View.IdChon > 0)
            {
                return KhoSanPham.DocTheoId(View.IdChon);
            }
            else
                return null;
        }
    }
}
