using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewPaper
    {
        int PaperId { get; set; }
        string PaperCode { get; set; }
        string PaperName { get; set; }
        int Substance { get; set; }
        float ShortDim { get; set; }
        float LongDim { get; set; }
        decimal UnitPrice { get; set; }
        int ProfiMarginSet { get; set; }
        int CateId { get; set; }
        string CategoryName { get; set; }
        //--
        
    }
}
