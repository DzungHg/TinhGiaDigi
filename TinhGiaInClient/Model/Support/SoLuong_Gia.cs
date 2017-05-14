using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model.Support
{
    public struct SoLuong_Gia
    {

        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }
        public decimal Gia
        {
            get { return _gia; }
            set { _gia = value; }
        }
        public decimal GiaTrungBinhDonVi()
        {
            return _gia / _soLuong;
        }
        public SoLuong_Gia(int soLuong, decimal gia)
        {
            _soLuong = soLuong;
            _gia = gia;
        }
        private int _soLuong;
        private decimal _gia;


    }
}
