using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model.Support
{
    public class GiaTuyChonTheNhuaChon: IGiaTuyChonSChon
    {
        public GiaTuyChonTheNhuaChon()
        {
            _tuyChonS = new List<GiaTuyChonTheNhua>();
        }
        private List<GiaTuyChonTheNhua> _tuyChonS;
        public List<GiaTuyChonTheNhua> TuyChonS 
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
