using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInNhapLieu.View;


namespace TinhGiaInNhapLieu.Presenter
{
    public class QuanLyDMGiayPresenter
    {
        IViewQuanLyDMGiay View;
        
        public QuanLyDMGiayPresenter(IViewQuanLyDMGiay view)
        {
            View = view;
           
        }
        public List<string> NhaCungCapS()
        {
            List<string> dict = new  List<string>();
            foreach (NhaCungCap pc in NhaCungCap.DanhSachNCC())
            {
                dict.Add(pc.Ten);
            }
            return dict;
        }
       
        public Dictionary<int, List<string>> DanhMucTheoNCC()
        {
            Dictionary<int, List<string>> dictList = new Dictionary<int,List<string>>();
            List<string> lst;
            
            foreach (DanhMucGiay dmucG in DanhMucGiay.LayTheoNhaCungCap(View.NhaCungCapChon))
            {
                lst = new List<string>();
                lst.Add(dmucG.Ten);
                lst.Add(dmucG.NhaCungCap);
                dictList.Add(dmucG.ID, lst);
            }

            return dictList;
        }
        public void XoaDanhMuc(int paperId)
        {
            ;

        }
       public void SaveNewDanhMucGiay()
       {

       }
              public void SaveEditingPaperCate()
              {

              }
                  
        
    }
}
