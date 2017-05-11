using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInNhapLieu.View;

namespace TinhGiaInNhapLieu.Presenter
{
    public class PaperCategoryPresenter
    {
        IViewDanhMucGiay View;
        
        public PaperCategoryPresenter(IViewDanhMucGiay view)
        {
            View = view;
        
        }
        public void DisplayAPaperCate(int paperCateId)
        {
            View.CategoryId = (PaperCateBLL.GetRecord(paperCateId)).CategoryId;
            View.CategoryName = (PaperCateBLL.GetRecord(paperCateId)).CategoryName;
        }
        public void AddNewPaperCate()
        {
            View.CategoryId = 0;
            View.CategoryName = "mới";
        }
        public void SaveNewPaperCate()
        {
            PaperCateBLL.InsertRecord(Mapper.FromDataTransferObject(View));
        }
        public void SaveEditingPaperCate()
        {
            PaperCateBLL.UpdateRecord(Mapper.FromDataTransferObject(View));
        }
    }
    
}
