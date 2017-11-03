using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.View
{
    public interface IViewKhoSanPham
    {


        int IdChon { get; set; }
        float Rong { get; set; }

        float Cao
        {
            get;
            set;

        }


        string TenKho
        {
            get;set;
        
        }

        FormStateS TinhTrangForm { get; set; }
    }
}
