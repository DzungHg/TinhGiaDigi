using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.View
{
    public interface IViewLietKeTinhGia
    {
        
        int IdTinhGiaChon { get;}
        int KieuSapXep { get; set; }
        int IdChieuSapXep { get; set; }
        string NoiDungTinhGia { get; set; }
    }
}
