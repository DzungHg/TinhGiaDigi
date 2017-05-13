using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public interface IGiaThanhPham
    {
        decimal ChiPhi(int soLuong);
        decimal ThanhTienCoBan(int soLuong);
        decimal ThanhTienSales();
        decimal GiaTBTrenDonVi();

    }
}
