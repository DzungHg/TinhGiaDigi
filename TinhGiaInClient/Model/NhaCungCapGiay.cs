using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class NhaCungCapGiay
    {
        public string Ten { get; set; }
        public static List<NhaCungCapGiay> DanhSachNCC()
        {
            //Sắp xếp theo thứ tự
            var nhaCCLogic = new DanhMucGiayLogic();
            List<NhaCungCapGiay > nguon = null;
            try
            {
                nguon = nhaCCLogic.NhaCungCapS().Select(x => new NhaCungCapGiay {
                    Ten = x}).OrderBy(x => x.Ten).ToList();
                
            }
            catch { }
            return nguon;
        }
    }
}
