using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public interface IThanhPham
    {
        decimal ChiPhi(int soLuong);
        decimal ThanhTienCoBan(int soLuong);

    }
}
