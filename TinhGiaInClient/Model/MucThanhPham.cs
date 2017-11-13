using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.Model
{
    public class MucThanhPham
    {
        private static int _lastId = 0;
        public int ID
        {
            get;
            set;
        }
        public int IdBaiIn { get; set; }
        public LoaiThanhPhamS LoaiThanhPham { get; set; }
        public int IdThanhPhamChon { get; set; }
        public string TenThanhPham { get; set; }       
        public int IdHangKhachHang { get; set; }
        public int TyLeMarkUp { get; set; }   
        public int SoLuong { get; set; }
        public string DonViTinh { get; set; }
        public decimal ThanhTien { get; set; }
        public MucThanhPham()
        {
            _lastId += 1;
            this.ID = _lastId;
           
        }
    }
}
