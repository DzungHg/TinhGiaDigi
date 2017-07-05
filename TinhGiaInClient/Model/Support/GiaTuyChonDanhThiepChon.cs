using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model.Support
{
    public class GiaTuyChonDanhThiepChon: IGiaTuyChonSChon
    {
        public GiaTuyChonDanhThiepChon()
        {
            _tuyChonS = new List<GiaTuyChonDanhThiep>();
        }
        private List<GiaTuyChonDanhThiep> _tuyChonS;
        public List<GiaTuyChonDanhThiep> TuyChonS 
        {
            get { return _tuyChonS; }
            set { _tuyChonS = value; }
        }
        public decimal GiaTong()
        {
            return _tuyChonS.Sum(x => x.GiaBan);
        }
    }
}
