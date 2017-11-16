using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;

namespace TinhGiaInClient.Common
{
  
    
    public static class Global
    {
        //Hằng bảng giá in
        public const string cBangGiaLuyTien = "BG_LUY_TIEN";
        public const string cBangGiaBuoc = "BG_BUOC";
        public const string cBangGiaGoi = "BG_GOI";
        //Dãy số lượng tính thử mặc định
        public const string cDaySoLuongA4TinhThu = "10;50;80;100;120;130;150;170;200;" +
                                                   "250;300;350;400;450;500;550;600;650;" +
                                                   "700;750;800;850;900;950;1000;1100; " +
                                                   "1200;1300;1400;1500;2000;3000;4000;" +
                                                   "5000;6000;7000;8000;9000;10000;15000;20000";

        public static bool CoTheMoFormNay(string tenForm, string tenNguoiDung, out string thongTin)
        {
            bool kq = true;
            thongTin = "";
            if (string.IsNullOrEmpty(tenNguoiDung.Trim()))
            {
                thongTin = "Tên người dùng chưa đúng!";
                return false;
            }
            //Kiểm tiếp
            var nguoiDung = NguoiDung.DocTheoTenDangNhap(tenNguoiDung.Trim());
            if (nguoiDung.ID == 0)
            {
                thongTin = "Bạn chưa có tài khoản sử dụng";
                return false;
            }
            //Kiểm tra có tên form không
            try
            {
                var danhSachFormS = nguoiDung.FormCoTheMo.ToUpper().Split(';');
                if (danhSachFormS.Contains("*")) //Trường hợp đặc biệt master
                    return true;

                if (!danhSachFormS.Contains(tenForm.ToUpper().Trim()))
                {
                    kq = false;
                }
            }
            catch
            {
                kq = false;
            }

            return kq;

        }

        
       
    }

}
  