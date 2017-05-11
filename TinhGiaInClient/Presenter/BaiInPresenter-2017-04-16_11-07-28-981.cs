using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TinhGiaInClient.Model;
using TinhGiaInClient.View;

namespace TinhGiaInClient.Presenter
{
    public class BaiInPresenter
    {
        IViewBaiIn View;
        BaiIn baiIn;
        public BaiInPresenter(IViewBaiIn view)
        {
            View = view;
            baiIn = new BaiIn("");
        }
        public Dictionary<int, string> HangKhachHangS()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            foreach (HangKhachHang hkh in HangKhachHang.LayTatCa())
            {
                dict.Add(hkh.ID, hkh.Ten);
                
            }
            return dict;
        }
        public int IdHangKhachHang()
        {
            return this.HangKhachHangS().FirstOrDefault(x => x.Value == View.TenHangKhachHang).Key;

        }
      
        public string DienGiaiHangKH() //
        {
            return HangKhachHang.LayTheoId(this.IdHangKhachHang()).DienGiai;
        }
        public void TrinhBayBaiIn()
        {
            switch(View.TinhTrangForm)
            {
                case (int)Enumss.FormState.New:
                    View.SoLuong = 10;
                    View.TieuDe = "Bài in";
                    View.DienGiai = "Diễn giải bài in";
                    View.DonViTinh = "??";
                    View.DienGiaiHangKH = this.DienGiaiHangKH();
                    break;
                case (int)Enumss.FormState.Edit:
                    //Không có trong database nên làm sau
                    
                    break;
            }
        }
        
       
        
      

        #region Phần giá In
        public List<GiaIn> GiaInS()
        {
            return baiIn.GiaInS;
        }
        public Dictionary<int, List<string>> TrinhBayGiaInS()
        {
            var dict = new Dictionary<int, List<string>>();
            var donViTrang = "";
            var tenMayIn = "";
            foreach (GiaIn giaIn in this.GiaInS())
            {
                var lst = new List<string>();
                lst.Add(giaIn.IdBaiIn.ToString());
                lst.Add(giaIn.TenBangGiaChon);
                ;
                switch (giaIn.LoaiBangGia)
                {
                    case (int)Enumss.PhuongPhapIn.Toner:
                        donViTrang = "A4";
                        tenMayIn = ToChayDigi.DocTheoId(giaIn.IdMayIn).Ten;
                        break;
                    case (int)Enumss.PhuongPhapIn.Offset:
                        donViTrang = "mặt";
                        tenMayIn = OffsetGiaCong.DocTheoId(giaIn.IdMayIn).Ten;
                        break;
                    default:
                        donViTrang = "?";
                        tenMayIn = "?";
                        break;
                }
                lst.Add(tenMayIn);
                lst.Add(string.Format("{0:0,0} {1}", giaIn.SoTrangIn, donViTrang));
                lst.Add(string.Format("{0:0,0.00}đ/{1}", giaIn.TienIn / giaIn.SoTrangIn, donViTrang));
                lst.Add(string.Format("{0:0,0.00}đ", giaIn.TienIn));
                dict.Add(giaIn.ID, lst);

            }
            return dict;
        }
        public void ThemGiaIn(GiaIn giaIn)
        {
            baiIn.Them_GiaIn(giaIn);
        }
        public void SuaGiaIn(GiaIn giaIn)
        {
            baiIn.Sua_GiaIn(giaIn);
        }
        public void XoaGiaIn(int idGiaIn)
        {            
            var giaIn = baiIn.DocGiaInTheoID(idGiaIn);
            baiIn.Xoa_GiaIn(giaIn);
        }
        public void XoaHetGiaIn()
        {
            baiIn.XoaTatCa_GiaIn();
        }
        public GiaIn LayGiaInTheoId(int idGiaIn)
        {
            return baiIn.DocGiaInTheoID(idGiaIn);
        }
        #endregion


        #region Cấu hình sản phẩm
        public void GanCHSPVoBaiIn(CauHinhSanPham cauHinhSP)
        {
            baiIn.CauHinhSP = cauHinhSP;
        }
        public void CapNhatCHSPVoBaiIn(CauHinhSanPham cauHinhSP)
        {
            var item = baiIn.CauHinhSP;
            if (item != null)
            {
                item.IDCauHinh = cauHinhSP.IDCauHinh;
                item.KhoSP.KhoCatRong = cauHinhSP.KhoSP.KhoCatRong;
                item.KhoSP.KhoCatCao = cauHinhSP.KhoSP.KhoCatCao;
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

        }
        public CauHinhSanPham LayCauHinhSPTheoBaiIn()
        {
            return tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).CauHinhSP;
        }
        public void XoaCauHinhSanPham()
        {
            tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).CauHinhSP = null;
        }
        public string TomTatCauHinhSP()
        {
            var result = "";
            var cHSP = tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).CauHinhSP;
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
            tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).GiayDeInIn = giayDeIn;

        }
        public void CapNhatGiayDeIn(GiayDeIn giayDeIn)
        {
            var item = tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).GiayDeInIn;
            if (item != null)
            {
                item.ID = giayDeIn.ID;
                item.GiayChon = giayDeIn.GiayChon;
                item.GiayKhachDua = giayDeIn.GiayKhachDua;
                item.KhoToChay = giayDeIn.KhoToChay;
                item.SoConTrenToChay = giayDeIn.SoConTrenToChay;
                item.SoLuongToChayLyThuyet = giayDeIn.SoLuongToChayLyThuyet;
                item.SoLuongToChayBuHao = giayDeIn.SoLuongToChayBuHao;
                item.SoLuongToLonCan = giayDeIn.SoLuongToLonCan;
                item.TenGiayIn = giayDeIn.TenGiayIn;
                item.IdBaiIn = giayDeIn.IdBaiIn;

            }
        }
        public void XoaGiayDeIn()
        {
            tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).GiayDeInIn = null;
        }
        public List<string> TomTatGiayDeIn()
        {
            var lst = new List<string>();
            var giayDeIn = tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).GiayDeInIn;
            if (giayDeIn != null)
            {
                lst.Add(string.Format("Giấy chọn: {0} ", giayDeIn.GiayChon.TenGiay));
                lst.Add(string.Format("Giấy tên theo bài: {0}", giayDeIn.TenGiayIn));
                lst.Add(string.Format("Định lượng: {0}g/m2", giayDeIn.GiayChon.DinhLuong));
                lst.Add(string.Format("Khổ tờ chạy {0}", giayDeIn.KhoToChay));
                lst.Add(string.Format("Số con / tờ chạy: {0}", giayDeIn.SoConTrenToChay));
                lst.Add(string.Format("Số lượng tờ chạy tính: {0} tờ", giayDeIn.SoLuongToChayLyThuyet));
                lst.Add(string.Format("Số lượng tờ chạy bù hao: {0} tờ", giayDeIn.SoLuongToChayBuHao));
                lst.Add(string.Format("Số lượng tờ chạy tổng: {0} tờ", giayDeIn.SoToChayTong));
                lst.Add(string.Format("Số lượng tờ lớn: {0} tờ", giayDeIn.SoLuongToLonCan));
                lst.Add(string.Format("Tiền giấy: {0:0,0.00đ}", giayDeIn.ThanhTien));
                lst.Add(string.Format("Giấy khách đưa? {0}", giayDeIn.GiayKhachDua));
            }
            return lst;
        }
        public GiayDeIn LayGiayDeInTheoBaiIn()
        {
            return tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).GiayDeInIn;
        }
        #endregion

        #region Phần thành phẩm
        public List<MucThanhPham> ThanhPhamS()
        {
            return tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).ThanhPhamS;
        }
        //Trình bày list view
        public Dictionary<int, List<string>> TrinhBayThanhPhamS()
        {
            var dict = new Dictionary<int, List<string>>();
            var baiIn = this.DocBaiInTheoId(View.IdBaiInChon);
            foreach (MucThanhPham mucThPh in this.ThanhPhamS())
            {
                var lst = new List<string>();
                lst.Add(mucThPh.IdBaiIn.ToString());
                lst.Add(baiIn.TieuDe);
                var tenTP = "";
                switch (mucThPh.LoaiThPh)
                {
                    case (int)Enumss.LoaiThanhPham.CanPhu:
                        tenTP = mucThPh.TenThPhMoRong;
                        break;
                    default:
                        tenTP = mucThPh.TenThPh;
                        break;
                }
                lst.Add(tenTP);
                lst.Add(mucThPh.ThongTinHangKH);
                lst.Add(mucThPh.ThongTinTyLeMarkUp);
                lst.Add(string.Format("{0} {1}", mucThPh.SoLuong, mucThPh.DonViTinh));
                lst.Add(string.Format("{0:0,0.00}đ", mucThPh.ThanhTien));

                dict.Add(mucThPh.ID, lst);
            }
            return dict;
        }
        public void ThemThanhPham(MucThanhPham thPham)
        {
            tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).Them_ThanhPham(thPham);
        }
        public void XoaThanhPham(int idThanhPham)
        {
            var thPham = tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).DocThanhPhamTheoID(idThanhPham);
            tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).Xoa_ThanhPham(thPham);
        }
        public void XoaHetThanhPham()
        {
            tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).XoaTatCa_ThanhPham();
        }
        public MucThanhPham LayThanhPhamTheoId(int idThPham)
        {
            return tinhGiaIn.DocBaiInTheoID(View.IdBaiInChon).DocThanhPhamTheoID(idThPham);
        }
        #endregion
    }

}
