using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TinhGiaInNhapLieu.View;
using TinhGiaInClient.Model;

namespace TinhGiaInNhapLieu.Presenter
{
    public class GiayPresenter
    {
        IViewGiay View;
        
       
        public GiayPresenter(IViewGiay view)
        {
            View = view;
        }
        public void AddNewPaper()
        {
            View.Id = 0;
            View.DinhLuong = 0;
            View.UnitPrice = 250;
            View.ChieuNgan = 32;
            View.LongDim = 47;
            View.ProfiMarginSet = 0;
            View.CategoryName = " ";
        }
        public void DisplayAPaper(int paperId)
        {
            PaperModel ppM = Mapper.FromDataTransferObject(PaperBLL.GetPaper(paperId));
            
            View.Id = ppM.PaperId;
            View.MaNhaCungCap = ppM.PaperCode;
            View.TenGiay = ppM.PaperName;
            View.DinhLuong = ppM.Substance;
            View.ChieuNgan = ppM.ShortDim;
            View.LongDim = ppM.LongDim;
            View.UnitPrice = ppM.UnitPrice;
            View.ProfiMarginSet = ppM.ProfitMarginSet;
            View.CateId = ppM.CategoryId;
            View.CategoryName = (PaperCateBLL.GetRecord(ppM.CategoryId)).CategoryName;
        }
        
        public IList<PaperCategory> DisplayAllPaperCates()
        {
            return PaperCateBLL.GetAllRecord();
        }
        public string PaperCategoryNameById(int cateId)
        {
            return (PaperCateBLL.GetRecord(cateId)).CategoryName;
        }
        public void SaveNewPaper()
        {
            PaperBLL.InsertPaper(Mapper.FromDataTransferObject(View));
        }
        public void SaveEditingPaper()
        {
            PaperBLL.UpdatePaper(Mapper.FromDataTransferObject(View));
        }
    }
}
