using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TinhGiaInClient.Model;
using TinhGiaInClient.View;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.Presenter
{
    public class BaiInPresenter
    {
        IViewBaiIn View;
        BaiIn MucBaiIn;
        public BaiInPresenter(IViewBaiIn view, BaiIn baiIn)
        {
            View = view;
            MucBaiIn = baiIn;
            //Dữ liệu
            View.ID = this.MucBaiIn.ID;
            View.TieuDe = this.MucBaiIn.TieuDe;
            View.DienGiai = this.MucBaiIn.DienGiai;
            View.SoLuong = this.MucBaiIn.SoLuong;
            View.DonViTinh = this.MucBaiIn.DonVi;
            View.IdHangKhachHang = this.MucBaiIn.IdHangKH;

            
            
            
        }
        
        public string TenHangKhachHang()
        {
            return HangKhachHang.LayTheoId(View.IdHangKhachHang).Ten;

        }
      
       
        public void TrinhBayBaiIn()
        {

        }
        
      

        #region Phần giá In
        public List<MucGiaIn> GiaInS()
        {
            return MucBaiIn.GiaInS;
        }
        public Dictionary<int, List<string>> TrinhBayGiaInS()
        {
            var dict = new Dictionary<int, List<string>>();
            var donViTrang = "";
            var phuongPhapIn = "";
            foreach (MucGiaIn giaIn in this.GiaInS())
            {
                var lst = new List<string>();
                lst.Add(giaIn.IdBaiIn.ToString());
                
                
                switch (giaIn.PhuongPhapIn)
                {
                    case PhuongPhapInS.Toner:
                        donViTrang = "A4";
                        phuongPhapIn = "KTS";
                        break;
                    case PhuongPhapInS.Offset:
                        donViTrang = "mặt";
                        phuongPhapIn = "Offset";
                        break;
                    default:
                        donViTrang = "?";
                        phuongPhapIn = "?";
                        break;
                }
                lst.Add(phuongPhapIn);
                lst.Add(giaIn.DienGiaiMayIn);
                lst.Add(string.Format("{0:0,0} {1}", giaIn.SoTrangIn, donViTrang));
                lst.Add(string.Format("{0:0,0.00}đ/{1}", giaIn.GiaTBTrang, donViTrang));
                lst.Add(string.Format("{0:0,0.00}đ", giaIn.TienIn));
                dict.Add(giaIn.ID, lst);

            }
            return dict;
        }
        public void ThemGiaIn(MucGiaIn giaIn)
        {
            MucBaiIn.Them_GiaIn(giaIn);
        }
        public void SuaGiaIn(MucGiaIn giaIn)
        {
            MucBaiIn.Sua_GiaIn(giaIn);
        }
        public void XoaGiaIn(int idGiaIn)
        {            
            var giaIn = MucBaiIn.DocGiaInTheoID(idGiaIn);
            MucBaiIn.Xoa_GiaIn(giaIn);
        }
        public void XoaHetGiaIn()
        {
            MucBaiIn.XoaTatCa_GiaIn();
        }
        public MucGiaIn LayGiaInTheoId(int idGiaIn)
        {
            return MucBaiIn.DocGiaInTheoID(idGiaIn);
        }
        #endregion


        #region Cấu hình sản phẩm
        public void GanCHSPVoBaiIn(CauHinhSanPham cauHinhSP)
        {
            MucBaiIn.CauHinhSP = cauHinhSP;
        }
       /* public void CapNhatCHSPVoBaiIn(CauHinhSanPham cauHinhSP)
        {
            var item = baiIn.CauHinhSP;
            if (item != null)
            {
                item.IDCauHinh = cauHinhSP.IDCauHinh;
                item.KhoCatRong = cauHinhSP.KhoCatRong;
                item.KhoCatCao = cauHinhSP.KhoCatCao;
                item.TranLeTren = cauHinhSP.TranLeTren;
                item.TranLeDuoi = cauHinhSP.TranLeDuoi;
                item.TranLeTrong = cauHinhSP.TranLeTrong;
                item.TranLeNgoai = cauHinhSP.TranLeNgoai;
                item.LeTren = cauHinhSP.LeTren;
                item.LeDuoi = cauHinhSP.LeDuoi;
                item.LeTrong = cauHinhSP.LeTrong;
                item.LeNgoai = cauHinhSP.LeNgoai;
                item.IdBaiIn = cauHinhSP.IdBaiIn;
                item.IdMayIn = cauHinhSP.IdMayIn;
                item.PhuongPhapIn = cauHinhSP.PhuongPhapIn;

            }

        }*/
        public CauHinhSanPham LayCauHinhSPTheoBaiIn()
        {
            return MucBaiIn.CauHinhSP;
        }
        public void XoaCauHinhSanPham()
        {
            MucBaiIn.CauHinhSP = null;
        }
        public string TomTatCauHinhSP()
        {
            var result = "";
            var cHSP = this.DocBaiIn().CauHinhSP;
            if (cHSP != null)
            {
                result = cHSP.ThongTinCauHinh;
            }
            return result;
        }
        #endregion

        #region Giấy in
        public void GanGiayDeIn(GiayDeIn giayDeIn)
        {
            MucBaiIn.GiayDeInIn = giayDeIn;

        }
        /*public void CapNhatGiayDeIn(GiayDeIn giayDeIn)
        {
            baiIn.GiayDeInIn = giayDeIn;
           
        }*/
        public void XoaGiayDeIn()
        {
            MucBaiIn.GiayDeInIn = null;
        }
        public List<string> TomTatGiayDeIn()
        {
            var lst = new List<string>();
            var giayDeIn = MucBaiIn.GiayDeInIn;
            if (giayDeIn != null)
            {
                var giay = Giay.DocGiayTheoId(giayDeIn.IdGiay);
                lst.Add(string.Format("Giấy chọn: {0} ", giay.TenGiay));
                lst.Add(string.Format("Giấy tên theo bài: {0}", giayDeIn.TenGiayIn));
                lst.Add(string.Format("Định lượng: {0}g/m2", giay.DinhLuong));
                lst.Add(string.Format("Khổ tờ chạy {0}", giayDeIn.KhoToChay));
                lst.Add(string.Format("Số con / tờ chạy: {0}", giayDeIn.SoConTrenToChay));
                lst.Add(string.Format("Số lượng tờ chạy tính: {0} tờ", giayDeIn.SoToChayLyThuyet));
                lst.Add(string.Format("Số lượng tờ chạy bù hao: {0} tờ", giayDeIn.SoToChayBuHao));
                lst.Add(string.Format("Số lượng tờ chạy tổng: {0} tờ", giayDeIn.SoToChayTong));
                lst.Add(string.Format("Số lượng tờ lớn: {0} tờ", giayDeIn.SoToLonTong));
                lst.Add(string.Format("Tiền giấy: {0:0,0.00đ}", giayDeIn.ThanhTienGiay));
                var giayKhach = "";
                if (giayDeIn.GiayKhachDua)
                    giayKhach = "Giấy khách";
                else
                    giayKhach = "123in";

                lst.Add(string.Format("Giấy khách đưa? {0}", giayKhach));
            }
            return lst;
        }
        public GiayDeIn LayGiayDeInTheoBaiIn()
        {
            return MucBaiIn.GiayDeInIn;
        }
        #endregion

        #region Phần thành phẩm
        public List<MucThanhPham> ThanhPhamS()
        {
            return MucBaiIn.ThanhPhamS;
        }
        //Trình bày list view
        public Dictionary<int, List<string>> TrinhBayThanhPhamS()
        {
           
            var dict = new Dictionary<int, List<string>>();            
            foreach (MucThanhPham mucThPh in this.ThanhPhamS())
            {
                var lst = new List<string>();               
                               
                lst.Add(mucThPh.TenThanhPham);           
               
               
                lst.Add(string.Format("{0:0,0}", mucThPh.SoLuong));
                lst.Add(mucThPh.DonViTinh);
                lst.Add(string.Format("{0:0,0.00}đ", mucThPh.ThanhTien));

                dict.Add(mucThPh.ID, lst);
            }
            return dict;
        }
        public void ThemThanhPham(MucThanhPham thPham)
        {
            MucBaiIn.Them_ThanhPham(thPham);
        }
        /*public void SuaThanhPham(MucThanhPham thPham)
        {
            baiIn.Sua_ThanhPham(thPham);
        }
         */
        public void XoaThanhPham(MucThanhPham thPham)
        {
            //var thPham = baiIn.DocThanhPhamTheoID(idThanhPham);
            MucBaiIn.Xoa_ThanhPham(thPham);
        }
        public void XoaHetThanhPham()
        {
            MucBaiIn.XoaTatCa_ThanhPham();
        }
        public MucThanhPham LayThanhPhamTheoId(int idThPham)
        {
            return MucBaiIn.DocThanhPhamTheoID(idThPham);
        }
        #endregion

        public List<string> TomTatNoiDungBaiIn_ChaoKH()
        {
            List<string> lst = new List<string>();

            foreach (KeyValuePair<string, string> kvp in this.DocBaiIn().TomTat_ChaoKH())
            {
                lst.Add(string.Format("{0} {1}", kvp.Key, kvp.Value)); 
            }
            return lst;
        }
        private void CapNhatMucBaiIn()
        {
            this.MucBaiIn.ID = View.ID;
            this.MucBaiIn.TieuDe = View.TieuDe;
            this.MucBaiIn.DienGiai = View.DienGiai;
            this.MucBaiIn.SoLuong = View.SoLuong;
            this.MucBaiIn.DonVi = View.DonViTinh;
            this.MucBaiIn.IdHangKH = this.MucBaiIn.IdHangKH;
        }
        public BaiIn DocBaiIn()
        {
            CapNhatMucBaiIn();
            return this.MucBaiIn;
        }
    }

}
