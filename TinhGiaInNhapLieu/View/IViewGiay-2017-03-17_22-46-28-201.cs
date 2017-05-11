using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInNhapLieu.View
{
    public interface IViewGiay
    {
        ID	int	Unchecked
Ma_giay_ncc	nvarchar(50)	Checked
Ma_giay_tu_dat	nvarchar(50)	Checked
Ten_giay	nvarchar(100)	Checked
Dien_giai	nvarchar(500)	Checked
Dinh_luong	int	Checked
Kho_giay	nvarchar(50)	Checked
Chieu_ngan	float	Checked
Chieu_dai	float	Checked
Gia_mua	int	Checked
Markup_1	int	Checked
Markup_2	int	Checked
Markup_3	int	Checked
ID_DANH_MUC_GIAY	int	Checked
Thu_tu	int	Checked
Ton_kho	bit	Checked
        int Id { get; set; }
        string MaNhaCungCap { get; set; }
         string MaNhaTuDat { get; set; }
        string TenGiay { get; set; }
         string DienGiai { get; set; }
        int DinhLuong { get; set; }
        float ShortDim { get; set; }
        float LongDim { get; set; }
        decimal UnitPrice { get; set; }
        int ProfiMarginSet { get; set; }
        int CateId { get; set; }
        string CategoryName { get; set; }
        //--
        
    }
}
