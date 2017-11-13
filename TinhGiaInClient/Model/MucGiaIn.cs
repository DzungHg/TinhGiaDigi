using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.Model
{
    public class MucGiaIn
    {
        static int _prevId = 0;
        public int ID { get; set; }
        public int IdBaiIn { get; set; }
        public int IdHangKhachHang { get; set; }    
        public PhuongPhapInS PhuongPhapIn { get; set; }
        public int SoMatIn { get; set; }        
        public int IdMayIn { get; set; }
        public int IdNiemYetGiaInNhanh { get; set; }
        public bool ChoTinhGopTrang { get; set; }
        public int SoToChay { get; set; }
        public int SoTrangIn { get; set; }
        public decimal TienIn { get; set; }
        public string GiaTBTrangInfo { get; set; }
        decimal _giaTBTrang = 0;
        public decimal GiaTBTrang
        {
            get {
                if (this.SoTrangIn > 0)
                    _giaTBTrang = this.TienIn / SoTrangIn;
                return _giaTBTrang;
            }
        }
        public MucGiaIn(PhuongPhapInS phuongPhapIn, int soTrangIn, int idBaiIn, int idMayInOrToIn,
            decimal tienIn, string giaTBTrang, int idHangKH, int soToChay, int soMatIn)
        {
            
            this.PhuongPhapIn = phuongPhapIn;
            this.SoTrangIn = soTrangIn;
            this.TienIn = tienIn;
            this.IdBaiIn = idBaiIn;            
            this.GiaTBTrangInfo = giaTBTrang;
            this.IdMayIn = idMayInOrToIn;
            this.IdHangKhachHang = idHangKH;
            this.SoToChay = soToChay;
            this.SoMatIn = soMatIn;
            
            //Tạo Id mới tăng dần
            _prevId += 1;
            this.ID = _prevId;
            
        }
        string _dienGiaiMayIn;
        public string DienGiaiMayIn 
        {
            get {
                if (this.IdMayIn >0 && this.PhuongPhapIn > 0)
                {
                    switch (this.PhuongPhapIn)
                    {
                        case PhuongPhapInS.Toner:
                            _dienGiaiMayIn = ToInMayDigi.DocTheoId(IdMayIn).Ten;
                            break;
                        case PhuongPhapInS.Offset:
                            _dienGiaiMayIn = OffsetGiaCong.DocTheoId(IdMayIn).Ten;
                            break;
                    }
                }
                return _dienGiaiMayIn;
                }
            set { _dienGiaiMayIn = value; }
        }

        string _tenPhuongPhapIn = "Chưa In";
        public string TenPhuongPhapIn
        {
            get
            {

                switch (this.PhuongPhapIn)
                {
                    case PhuongPhapInS.Toner:
                        _tenPhuongPhapIn = "KTS";
                        break;
                    case PhuongPhapInS.Offset:
                        _tenPhuongPhapIn = "Offset";
                        break;
                    case PhuongPhapInS.KhongIn:
                        _tenPhuongPhapIn = "Không In";
                        break;
                    default:
                        _tenPhuongPhapIn = "Chưa In";
                        break;
                }

                return _tenPhuongPhapIn;
            }
            set { _tenPhuongPhapIn = value; }
        }
    }
}
