using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;

namespace TinhGiaInClient.View
{
    public interface IViewSoSanhGiaInNhanh
    {

        string TenNhaInA { get; set; }
        string TenNhaInB { get; set; }
        
        string DaySoLuongTrangA4 { get; }
              
        //Thêm mới
        int IdNiemYetChonA { get; set; }
        string DienGiaiNiemYetA { get; set; }
        int IdNiemYetChonB { get; set; }
        string DienGiaiNiemYetB { get; set; }
        string LoaiBangGiaNiemYetA { get; set; }
        string LoaiBangGiaNiemYetB { get; set; }
       
       
    }
}
