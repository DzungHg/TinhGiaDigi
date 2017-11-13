using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.View
{
    public interface IViewLietKeTinhGia
    {
        
        int IdTinhGiaChon { get;}
        SapXepTinhGiaS KieuSapXep { get; set; }
        ChieuSapXepS ChieuSapXep { get; set; }
        string NoiDungTinhGia { get; set; }
    }
}
