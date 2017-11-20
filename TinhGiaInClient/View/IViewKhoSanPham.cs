using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Common.Enum;

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

        float TranLeTren
        {
            get;
            set;

        }
        float TranLeDuoi
        {
            get;
            set;

        }
        float TranLeTrong
        {
            get;
            set;

        }
        float TranLeNgoai
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
