using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.Model
{
    public class ThongTinToChay
    {
        public int ID { get; set; }
        public PhuongPhapInS PhuongPhapIn { get; set; }
        public string Ten { get; set; }
        public float Rong { get; set; }
        public float Dai { get; set; }
        public float VungInRongMax { get; set; }
        public float VungInDaiMax { get; set; }
        public float VungInRongMin { get; set; }
        public float VungInDaiMin { get; set; }
        public string CacKhoToChayCoTheIn { get; set; }
        public int ThuTu { get; set; }
        
    }
}
