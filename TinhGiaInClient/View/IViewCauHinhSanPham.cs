using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Common.Enum;


namespace TinhGiaInClient.View
{
    public interface IViewCauHinhSanPham
    {       
        int IdCauHinhSP { get; set; }
        
        float KhoCatRong { get; set; }
        float KhoCatCao { get; set; }
        float TranLeTren { get; set; }
        float TranLeDuoi { get; set; }
        float TranLeTrong { get; set; }
        float TranLeNgoai { get; set; }
        float LeTren { get; set; }
        float LeDuoi { get; set; }
        float LeTrong { get; set; }
        float LeNgoai { get; set; }
        
        int SoLuong { get; set; }
        string DonViTinh { get; set; }
        int IdBaiIn { get; set; }
        string ThongTinBaiIn { get; set; }
        //Thêm về máy in
        int IdToInChon { get; set; }
        PhuongPhapInS PhuongPhapIn { get; set; }
        string TenPhuongPhapIn { get; }
        string KhoInChon { get; }
        FormStateS TinhTrangForm { get; set; }
       
    }
}
