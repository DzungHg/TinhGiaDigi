using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class BaiInDanhThiep
    {
        static int _prevId = 0;
        public int ID { get; set; }
     
        public MotHaiMat SoMatIn { get; set; }
               
        public int IdBangGia { get; set; }
        public string TenBangGia { get; set; }
        public string KichThuoc { get; set; }
        public int SoLuongHop { get; set; }
        public GiayDeIn ChonGiayIn { get; set; }
        public string TenGiayIn { get; set; }
        public decimal TienGiay { get; set; }
        public decimal TienIn { get; set; }
        public decimal ThanhTien
        {
            get { return this.TienGiay + this.TienIn; }
        }        
        decimal _giaTBHop = 0;
        public decimal GiaTBHop
        {
            get {
                if (this.SoLuongHop > 0)
                    _giaTBHop = this.ThanhTien / SoLuongHop;
                return _giaTBHop;
            }
        }
        public BaiInDanhThiep(int idBangGia, string tenBangGia, string kichthuoc, int soLuong, MotHaiMat soMatIn)
        {
            this.IdBangGia = idBangGia;            
            this.SoLuongHop = soLuong;
            this.KichThuoc = kichthuoc;
            this.IdBangGia = idBangGia;
            this.TenBangGia = tenBangGia;
            this.SoMatIn = soMatIn;
            //Tạo Id mới tăng dần
            _prevId += 1;
            this.ID = _prevId;            
        }
        #region Tóm tắt bài in
      
        public Dictionary<string, string> TomTat_ChaoKH()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("STT:", this.ID.ToString());
            dict.Add("Tên", "Danh Thiếp " + this.KichThuoc);
            dict.Add("Số lượng:", string.Format("{0:0,0}", this.SoLuongHop));
            dict.Add("ĐV tính:", "hộp");
            dict.Add("In:", string.Format("{0} mặt ", (int)this.SoMatIn));
            dict.Add("Giấy:", this.TenGiayIn);
            
            dict.Add("Trị giá: ", string.Format("{0:0,0.00}đ", this.ThanhTien));
            return dict;
        }
        #endregion
        
    }
}
