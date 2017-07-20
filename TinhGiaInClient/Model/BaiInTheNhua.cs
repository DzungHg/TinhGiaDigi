using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model.Support;

namespace TinhGiaInClient.Model
{
    public class BaiInTheNhua
    {
        public BaiInTheNhua(int  idBangGia, string tenGiayBaoGom,
           string kichthuoc, int soLuong,
            int soMatIn, GiayDeIn giayDeIn = null)
        {
            this.IdBangGia = idBangGia;
            this.TenGiayBaoGom = tenGiayBaoGom;
            this.GiayIn = giayDeIn;
            
            this.SoLuongThe = soLuong;
            this.KichThuoc = kichthuoc;
            this.SoMatIn = soMatIn;  
            //Tạo thùng chứa
           
           
            //Tạo Id mới tăng dần
            _prevId += 1;
            this.ID = _prevId;
        }
        static int _prevId = 0;

       
        public int ID { get; set; }
        public string TieuDe { get; set; }
        public int SoMatIn { get; set; }
        public int IdBangGia { get; set; }              
        public string KichThuoc { get; set; }
        public int SoLuongThe { get; set; }
        public string TenGiayBaoGom { get; set; }
        public GiayDeIn GiayIn { get; set; }
        
        public GiaTuyChonTheNhuaChon TuyChonSChon = new GiaTuyChonTheNhuaChon();
               
        public decimal ThanhTien()
        {
            decimal tienTuyChon = 0;
            decimal tienGiay = 0;
            //Tùy chọn

            if (this.TuyChonSChon.TuyChonS.Count > 0)
                tienTuyChon = this.TuyChonSChon.GiaTong() * this.SoLuongThe;
            //giấy
            if (this.GiayIn != null)
                tienGiay = this.GiayIn.ThanhTienGiay;

            return GiaTheNhuaTheoBang() + tienGiay 
                +  tienTuyChon;

        }        
       
        decimal _giaTBHop = 0;
        public decimal GiaTBThe
        {
            get {
                if (this.SoLuongThe > 0)
                    _giaTBHop = this.ThanhTien() / SoLuongThe;
                return _giaTBHop;
            }
        }
        private decimal GiaTheNhuaTheoBang()
        {
            decimal kq = 0;
            if (this.IdBangGia > 0)
            {
                var bangGia = BangGiaTheNhua.DocTheoId(this.IdBangGia);
                return TinhToan.GiaTheNhua(bangGia.DaySoLuong, bangGia.DayGia, this.SoLuongThe);
            }
            return kq;
        }
        public string TenTuyChonSChon()
        {
            var kq = "";
            if (this.TuyChonSChon.TuyChonS.Count > 0)
            {
                foreach (GiaTuyChonTheNhua gTCh in this.TuyChonSChon.TuyChonS)
                {
                    kq += gTCh.TenTuyChon + ",";
                }
            }
            return kq;
        }
       
        #region Tóm tắt bài in
      
        public Dictionary<string, string> TomTat_ChaoKH()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("ID:", this.ID.ToString());
            dict.Add("", string.Format("{0} / {1}", this.TieuDe, this.KichThuoc)); //
            dict.Add("Số lượng:", string.Format("{0:0,0}", this.SoLuongThe));
            dict.Add("ĐV tính:", "thẻ");
            dict.Add("In:", string.Format("{0} mặt ", (int)this.SoMatIn));
            
            if (this.GiayIn != null)
            {
                this.TenGiayBaoGom = this.GiayIn.TenGiayIn;                
            }
            dict.Add("Giấy:", this.TenGiayBaoGom);

            if (!string.IsNullOrEmpty(this.TenTuyChonSChon()))
                dict.Add("Thêm tùy chọn: ", this.TenTuyChonSChon());
            
            
            dict.Add("Trị giá: ", string.Format("{0:0,0.00}đ", this.ThanhTien()));
            dict.Add("GiáTB/Thẻ: ", string.Format("{0:0,0.00}đ", this.GiaTBThe));
            return dict;
        }
        #endregion
        
    }
}
