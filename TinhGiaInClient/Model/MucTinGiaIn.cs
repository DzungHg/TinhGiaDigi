using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class MucTinGiaIn
    {
        static int _prevId = 0;
        public int ID { get; set; }
        public int IdBaiIn { get; set; }               
        public int PhuongPhapIn { get; set; }
               
        public int IdMayIn_IdBangGia { get; set; }
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
        public MucTinGiaIn(int phuongPhapIn, int soTrangIn, int idBaiIn, int idMayInOrToIn,
            decimal tienIn, string giaTBTrang)
        {
            
            this.PhuongPhapIn = phuongPhapIn;
            this.SoTrangIn = soTrangIn;
            this.TienIn = tienIn;
            this.IdBaiIn = idBaiIn;            
            this.GiaTBTrangInfo = giaTBTrang;
            this.IdMayIn_IdBangGia = idMayInOrToIn;
            //Tạo Id mới tăng dần
            _prevId += 1;
            this.ID = _prevId;
            
        }
        string _dienGiaiMayIn;
        public string DienGiaiMayIn 
        {
            get {
                if (this.IdMayIn_IdBangGia >0 && this.PhuongPhapIn > 0)
                {
                    switch (this.PhuongPhapIn)
                    {
                        case (int)Enumss.PhuongPhapInS.Toner:
                            _dienGiaiMayIn = ToInMayDigi.DocTheoId(IdMayIn_IdBangGia).Ten;
                            break;
                        case (int)Enumss.PhuongPhapInS.Offset:
                            _dienGiaiMayIn = OffsetGiaCong.DocTheoId(IdMayIn_IdBangGia).Ten;
                            break;
                    }
                }
                return _dienGiaiMayIn;
                }
            set { _dienGiaiMayIn = value; }
        }

        string _tenPhuongPhapIn;
        public string TenPhuongPhapIn
        {
            get
            {
                if (this.PhuongPhapIn > 0)
                {
                    switch (this.PhuongPhapIn)
                    {
                        case (int)Enumss.PhuongPhapInS.Toner:
                            _tenPhuongPhapIn = "KTS";
                            break;
                        case (int)Enumss.PhuongPhapInS.Offset:
                            _tenPhuongPhapIn = "Offset";
                            break;
                    }
                }
                return _tenPhuongPhapIn;
            }
            set { _tenPhuongPhapIn = value; }
        }
    }
}
