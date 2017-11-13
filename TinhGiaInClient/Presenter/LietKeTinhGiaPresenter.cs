using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInClient.View;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.Presenter
{
    public class LietKeTinhGiaPresenter
    {
        IViewLietKeTinhGia View;
        public LietKeTinhGiaPresenter(IViewLietKeTinhGia view)
        {
            View = view;

        }        
        public Dictionary<int, List<string>> TinhGiaS()
        {
            Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
            List<KetQuaTinhGiaIn> nguon = null;
            switch (View.KieuSapXep)
            {
                case SapXepTinhGiaS.TheoNgay:
                    nguon = KetQuaTinhGiaIn.DocTatCaSX_Ngay(View.ChieuSapXep);
                    break;
                case SapXepTinhGiaS.TheoNhanVien:
                    nguon = KetQuaTinhGiaIn.DocTatCaSX_NhanVien(View.ChieuSapXep);
                    break;
                case SapXepTinhGiaS.TheoTieuDe:
                    nguon = KetQuaTinhGiaIn.DocTatCaSX_TieuDe(View.ChieuSapXep);
                    break;
                default:
                    nguon = KetQuaTinhGiaIn.DocTatCa();
                    break;

            }
            foreach (KetQuaTinhGiaIn tgi in nguon)
            {
                var lst = new List<string>();
                
                lst.Add(tgi.NgayTinhGia.ToShortDateString());                
                lst.Add(tgi.TieuDe);
                lst.Add(tgi.TenNguoiDung);
                lst.Add(tgi.TenKhachHang);
                dict.Add(tgi.ID, lst);
            }
            return dict;
        }
        public string DocNoiDungTinhGia()
        {
            var result = "";
            if (View.IdTinhGiaChon > 0)
            {
                result = KetQuaTinhGiaIn.DocTheoId(View.IdTinhGiaChon).NoiDungChaoGia;                
                  
            }                
            return result;
        }
        public string NoiDungToanBoChaoGia_KH()
        {
            var result = "";
            if (View.IdTinhGiaChon > 0)
            {
                var mauTinTG = KetQuaTinhGiaIn.DocTheoId(View.IdTinhGiaChon);
                result = string.Format("TÍNH GIÁ ID {0}" + '\r' + '\n', mauTinTG.ID)
                    + string.Format("Ngày: {0:d/M/yyyy}" + '\r' + '\n', mauTinTG.NgayTinhGia)
                    + string.Format("Khách hàng: 0" + '\r' + '\n', mauTinTG.TieuDe)
                   
                    + string.Format("Bán hàng: {0}" + '\r' + '\n', mauTinTG.TenNguoiDung)
                    + mauTinTG.NoiDungChaoGia;
            }
            return result;
        }
    }
}
