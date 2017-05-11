using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class ChaoGiaIn
    {
        static int _lastId = 0;
        public int ID { get; set; }
        public string SoChaoGia { get; set; }
        public string TenKhachHang { get; set; }
        public DateTime NgayChaoGia { get; set; }
        List<BaiIn> _dsBaiIn;
        public List<BaiIn> DanhSachBaiIn
        {
            get { return _dsBaiIn; }
            set { _dsBaiIn = value; }
        }
        public ChaoGiaIn(DateTime ngayChaoGia, string soChaoGia, string tenKhachHang)
        {
            this.NgayChaoGia = ngayChaoGia;
            this.TenKhachHang = tenKhachHang;
            this.SoChaoGia = soChaoGia;

            _dsBaiIn = new List<BaiIn>();
            //---
            _lastId += 1;
            this.ID = _lastId;
        }

        #region thêm sửa, xóa bài in
        public void Them_BaiIn(BaiIn baiIn)
        {
            this.DanhSachBaiIn.Add(baiIn);
        }
        public void Sua_BaiIn(BaiIn baiIn)
        {
            var giaInSua = this.DanhSachBaiIn.Find(x => x.ID == baiIn.ID);
            giaInSua.IdBaiIn = baiIn.IdBaiIn;
            giaInSua.KieuIn = baiIn.KieuIn;
            giaInSua.LoaiBangGia = baiIn.LoaiBangGia;
            giaInSua.SoTrangA4 = baiIn.SoTrangA4;
            giaInSua.TenBangGiaChon = baiIn.TenBangGiaChon;
            giaInSua.TenToInDigiChon = baiIn.TenToInDigiChon;
            giaInSua.TienIn = baiIn.TienIn;

        }
        public void Xoa_BaiIn(BaiIn baiIn)
        {
            this.DanhSachBaiIn.Remove(baiIn);
        }
        public BaiIn DocBaiInTheoID(int idBaiIn)
        {
            return this.DanhSachBaiIn.Find(x => x.ID == idBaiIn);
        }
        public void XoaTatCa_BaiIn()
        {
            this.DanhSachBaiIn.Clear();
        }
        
    }
}
