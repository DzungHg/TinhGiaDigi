using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInNhapLieu.View;


namespace TinhGiaInNhapLieu.Presenter
{
    public class QuanLyGiayPresenter
    {
        IViewQuanLyGiay View;

        public QuanLyGiayPresenter(IViewQuanLyGiay view)
        {
            View = view;
           
        }
        public List<NhaCungCapGiay> NhaCungCapS()
        {
            return NhaCungCapGiay.DanhSachNCC();
        }
       
        public List<DanhMucGiay> DanhMucTheoNCC()
        {
            return DanhMucGiay.LayTheoNhaCungCap(View.NhaCungCapChon);
        }
        public Dictionary<int, List<string>> GiaySTheoDanhMucGiay()
        {            
            Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
            if (View.IdDanhMucGiayChon > 0)
                foreach (Giay giay in Giay.DocGiayTheoDanhMuc(View.IdDanhMucGiayChon))
                {
                    List<string> lst = new List<string>();
                    lst.Add(giay.TenGiayMoRong);
                    lst.Add(giay.TenGiay);
                    lst.Add(string.Format("{0}g/m2", giay.DinhLuong));                    
                    lst.Add(giay.KhoGiay);
                    lst.Add(string.Format("{0}cm", giay.ChieuNgan));
                    lst.Add(string.Format("{0}cm", giay.ChieuDai));
                    lst.Add(string.Format("{0:0,0.00}đ/tờ", giay.GiaMua));
                    if (giay.KhongCon)
                        lst.Add("Hết hàng");
                    else
                        lst.Add("Còn hàng");

                    if (giay.TonKho)
                        lst.Add("Có");
                    else
                        lst.Add("Không");

                    lst.Add(giay.ThuTu.ToString());

                    dict.Add(giay.ID, lst);
                }
            return dict;
        }
       
        public void XoaGiay(int paperId)
        {
            ;

        }
    
        
    }
}
