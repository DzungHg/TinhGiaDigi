using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInClient.View;

namespace TinhGiaInClient.Presenter
{
    public class TinhGiaPresenter
    {
        IViewTinhGiaIn View;
        TinhGiaIn tinhGia;
        public TinhGiaPresenter(IViewTinhGiaIn view)
        {
            View = view;
            tinhGia = new TinhGiaIn();
        }
        public void NoiDungBanDau()
        {           
            View.NgayTinhGia = DateTime.Today;
            View.TenKhachHang = "Tên KH";
            View.LienHe = "Liên hệ";
            View.So = string.Format("{0}/{1}-{2}-{3}", "__", View.NgayTinhGia.Year - 2000,
                      View.NgayTinhGia.Month, View.NgayTinhGia.Day);
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
        public int IdHangKH()
        {
            return this.HangKhachHangS().FirstOrDefault(x => x.Value == View.TenHangKH).Key;
        }
        public string DienGiaiHangKH() //
        {
            return HangKhachHang.LayTheoId(this.IdHangKH()).DienGiai;
        }

        //phần không lưu data
        #region Phần Bài in: thêm sửa, xóa bài in
        
        public List<KetQuaBaiIn> DanhSachBaiIn()
        {
            return tinhGia.KetQuaBaiInS;
        }
            
        public void Them_BaiIn(BaiIn baiIn)
        {
            this.DanhSachBaiIn.Add(baiIn);
        }
        public void Sua_BaiIn(BaiIn baiIn)
        {
            var baiInSua = this.DanhSachBaiIn.Find(x => x.ID == baiIn.ID);
            baiInSua.TieuDe = baiIn.TieuDe;
            baiInSua.DienGiai = baiIn.DienGiai;
            baiInSua.SoLuong = baiIn.SoLuong;
            baiInSua.DonVi = baiIn.DonVi;
            baiInSua.IdHangKH = baiIn.IdHangKH;
            baiInSua.TenHangKH = baiIn.TenHangKH;
            baiInSua.GiayDeInIn = baiIn.GiayDeInIn;
            baiInSua.CauHinhSP = baiIn.CauHinhSP;
            baiInSua.GiaInS = baiIn.GiaInS;
            baiInSua.ThanhPhamS = baiIn.ThanhPhamS;            
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
        public Dictionary<int, List<string>> BaiInS()
        {
            Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
            foreach (BaiIn bIn in this.DanhSachBaiIn)
            {
                var lst = new List<string>();
                lst.Add(bIn.TieuDe);
                lst.Add(bIn.DienGiai);
                lst.Add(bIn.SoLuong.ToString());
                lst.Add(bIn.DonVi);
                if (bIn.CoCauHinh)
                    lst.Add("Có");
                else lst.Add("Chưa");
                if (bIn.CoGiayIn)
                    lst.Add("Có");
                else lst.Add("Chưa");
                lst.Add(bIn.SoLuongGiaInKemTheo().ToString());
                lst.Add(bIn.SoLuongThanhPhamKem().ToString());

                dict.Add(bIn.ID, lst);//hoàn tất tại đây
            }
            return dict;
        }
        public List<string> TomTatBaiIn_ChaoKH()
        {
            List<string> lst = new List<string>();
            if (View.IdBaiInChon > 0)
            {
                foreach (KeyValuePair<string, string> kvp in
                    this.DocBaiInTheoID(View.IdBaiInChon).TomTat_ChaoKH())
                {
                    lst.Add(kvp.Key + " " + kvp.Value);
                }
            }
            return lst;
        }


        #endregion
        #region phần Tính giá
        
        public string LuuTinhGia()
        {
            var result = "";
            var tinhGiaIn = new TinhGiaIn();
            tinhGiaIn.Ngay = View.NgayTinhGia;
            tinhGiaIn.So = View.So;
            tinhGiaIn.TenKhachHang = View.TenKhachHang;
            tinhGiaIn.LienHe = View.LienHe;
            tinhGiaIn.YeuCau = View.YeuCau;
            tinhGiaIn.TenNhanVien = View.TenNhanVien;
            foreach (string str in tinhGiaIn.TaoNoiDungChaoGia())
            {
                tinhGiaIn.NoiDungChaoGia += '\r' + '\n';
            }

            switch (View.TinhTrangForm)
            {
                case (int)Enumss.FormState.New:
                    
                    result = TinhGiaIn.Them(tinhGiaIn);
                    break;
                case (int)Enumss.FormState.Edit:

                    result = TinhGiaIn.Sua(tinhGiaIn);
                    break;
            }
            return result;
        }
        #endregion
       

        public string TrinhBayNoiDungBaiIn()
        {
            string result = "";
           /* foreach (string str in tinhGiaIn.TaoNoiDungChaoGia())
            {
                result += str + '\r' + '\n';
            }*/
            return result;
        }
    }
}
