using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TinhGiaInClient.Model
{
    public static class DanhSachBangGia
    {
        public static List<BangGiaBase> DanhSachS()
        {
            var lst = new List<BangGiaBase>();
            //
            foreach(BangGiaLuyTien bg in BangGiaLuyTien.DocTatCa())
            {
                lst.Add(bg);

            }
            //Bảng giá tiếp
            foreach (BangGiaTheoBuoc bg in BangGiaTheoBuoc.DocTatCa())
            {
                lst.Add(bg);

            }
            return lst;
        }
        public static BangGiaBase DocTheoIDvaLoai(int id, string loai)
        {
            BangGiaBase bg = null;
            bg = DanhSachBangGia.DanhSachS().Where(x => x.ID == id && x.LoaiBangGia == loai.Trim()).SingleOrDefault();
            return bg;
        }
        
    }
}
