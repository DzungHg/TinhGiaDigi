using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Presenter
{
    public static class HoTro
    {
        public Dictionary<string, string> TrinhBayBangGiaLuyTien(string khoangSoLuong, string khoangGia, string donViTinh)
        {
            Dictionary<string, string> st_dict = new Dictionary<string, string>();


            if (!string.IsNullOrEmpty(khoangSoLuong) && !string.IsNullOrEmpty(khoangGia))
            {
                //Khai báo
                int i;
                //Tạo bản dãy
                var tmp_st_arrKey = khoangSoLuong.Split(';');//Tạo bản dãy
                var tmp_st_arrGia = khoangGia.Split(';');
                int soDauTien = 1;
                //Biến đổi số lượng
                var soLuongTam = 0;
                for (i = 0; i < tmp_st_arrKey.Length - 1; i++)
                {
                    soLuongTam += int.Parse(tmp_st_arrKey[i + 1]) - int.Parse(tmp_st_arrKey[i]);
                    tmp_st_arrKey[i] = string.Format("{0} - {1} " + donViTinh, soDauTien, soLuongTam);
                    soDauTien = soLuongTam + 1;

                }
                //Biến đổi tiếp key của Dict

                for (i = 0; i < tmp_st_arrKey.Length; i++)
                {
                    st_dict.Add(tmp_st_arrKey[i], tmp_st_arrGia[i]);
                }
            }
           
            return st_dict;
        }
         public Dictionary<string, string> TrinhBayBangGiaBuoc(string khoangSoLuong, string khoangGia, string donViTinh)
        {
            var dict = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(khoangSoLuong) && !string.IsNullOrEmpty(khoangGia))
            {

                //Tạo bản dãy
                var arrKey = khoangSoLuong.Split(';');//Tạo bản dãy
                var arrValue = khoangGia.Split(';');
            }

            return dict;
        }
    }
}
