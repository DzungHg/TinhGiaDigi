using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInNhapLieu.View;

namespace TinhGiaInNhapLieu.Presenter
{
    public class DanhMucGiayPresenter
    {
        IViewDanhMucGiay View;
        
        public DanhMucGiayPresenter(IViewDanhMucGiay view)
        {
            View = view;
        
        }
        public List<string> NhaCungCapS()
        {
            List<string> lst = new List<string>();
            foreach (NhaCungCapGiay pc in NhaCungCapGiay.DanhSachNCC())
            {
                lst.Add(pc.Ten);
            }
            return lst;
        }
         public void ThemDanhMucGiay()
        {
            var  dmGiay = new DanhMucGiay();
            dmGiay.NhaCungCap = View.TenNhaCungCapChon;
            dmGiay.Ten = View.TenDanhMuc;
            dmGiay.ThuTu = View.ThuTu;
            DanhMucGiay.Them(dmGiay);
           
        }
        
        public void SuaDanhMucGiay()
        {            
            var  dmGiay = new DanhMucGiay();
            dmGiay.ID = View.IdDanhMucgiay;
            dmGiay.NhaCungCap = View.TenNhaCungCapChon;
            dmGiay.Ten = View.TenDanhMuc;
            dmGiay.ThuTu = View.ThuTu;
            DanhMucGiay.Sua(dmGiay);

            
        }
                  
    }
    
}
