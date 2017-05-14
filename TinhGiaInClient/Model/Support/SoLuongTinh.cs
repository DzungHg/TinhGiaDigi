using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model.Support
{

    public struct SoLuongTinh
    {
        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public SoLuongTinh(int iD, int soLuong)
        {
            _soLuong = soLuong;
            _id = iD;
        }
        private int _soLuong;
        private int _id;

    }
}
