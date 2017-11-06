using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model.Support;

namespace TinhGiaInClient.Model
{
    public class BaiInDanhThiep
    {
        public BaiInDanhThiep(int idBangGia, string tenBangGia, string kichthuoc, int soLuong, int soMatIn)
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
        static int _prevId = 0;
        public int ID { get; set; }
        public string TieuDe { get; set; }
        public int SoMatIn { get; set; }
               
        public int IdBangGia { get; set; }
        public string TenBangGia { get; set; }
        public string KichThuoc { get; set; }
        public int SoLuongHop { get; set; }
        public GiayDeIn ChonGiayIn { get; set; }

        public string TenGiayIn { get; set; } //Là tên giấy bao gồm
        public GiaTuyChonDanhThiepChon TuyChonSChon = new GiaTuyChonDanhThiepChon();
       
        public string TenTuyChonSChon()
        {
            var kq = "";
            if (this.TuyChonSChon.TuyChonS.Count >0)
            {
                foreach(GiaTuyChonDanhThiep gTCh in this.TuyChonSChon.TuyChonS )
                {
                    kq += gTCh.TenTuyChon + ",";
                }
            }
            return kq;
        }
       
        public decimal GiaTBHop
        {
            get {
                return this.ThanhTien() / this.SoLuongHop;
            }
        }
        public decimal GiaDanhThiepTheoBang()
        {
            decimal kq = 0;
            if (this.IdBangGia > 0)
            {
                var bangGia = BangGiaDanhThiep.DocTheoId(this.IdBangGia);
                return TinhToan.GiaBuoc(bangGia.DaySoLuong, bangGia.DayGia, this.SoLuongHop);
            }
            return kq;
        }
        private decimal TienGiay()
        {
            decimal kq = 0;
            if (this.ChonGiayIn != null)
                kq = ChonGiayIn.ThanhTienGiay;

            return kq;
        }
        private decimal TienTuyChon()
        {
            decimal kq = 0;
            if (this.TuyChonSChon.TuyChonS.Count > 0)
                kq = this.TuyChonSChon.GiaTong() * this.SoLuongHop;

            return kq;
        }
        public decimal ThanhTien()
        {
            decimal kq = 0;
            kq = this.GiaDanhThiepTheoBang() + this.TienGiay() + this.TienTuyChon();

            return kq;
        }   
        #region Tóm tắt bài in
      
        public Dictionary<string, string> TomTat_ChaoKH()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("STT:", this.ID.ToString());
            dict.Add("", string.Format("{0} / {1}", this.TieuDe, this.KichThuoc));
            dict.Add("Số lượng:", string.Format("{0:0,0}", this.SoLuongHop));
            dict.Add("ĐV tính:", "hộp");
            dict.Add("In:", string.Format("{0} mặt ", this.SoMatIn));

            if (this.ChonGiayIn != null)
            {
                this.TenGiayIn = this.ChonGiayIn.TenGiayIn;                
            }
            dict.Add("Giấy:", this.TenGiayIn);

            if (!string.IsNullOrEmpty(this.TenTuyChonSChon()))
                dict.Add("Thêm tùy chọn: ", this.TenTuyChonSChon());
            
            dict.Add("Trị giá: ", string.Format("{0:0,0.00}đ", this.ThanhTien()));
            dict.Add("GiáTB/Hộp: ", string.Format("{0:0,0.00}đ", this.GiaTBHop));
            return dict;
        }
        #endregion
        
    }
}
