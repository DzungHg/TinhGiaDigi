using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;

namespace TinhGiaInClient.Presenter
{
    public class BangGiaGiayPresenter
    {
        IViewBangGiaGiay View;
        public BangGiaGiayPresenter(IViewBangGiaGiay view)
        {
            View = view;
        }
       
        public List<NhaCungCapGiay>NhaCungCapS()
        {
            return NhaCungCapGiay.DanhSachNCC();
        }
        public List<HangKhachHang>HangKhachHangS()
        {
            return HangKhachHang.LayTatCa();
        }
        
        public Dictionary<int, List<string>> GiayTheoDanhMucS()
        {           
            Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
            var giaMuaGiay = 0;//để o cho nhân viên xem
            foreach (GiaGiayNiemYet giaGiay in GiaGiayNiemYet.DocTheoDanhMucGiay_HangKH(View.IdDanhMucGiayChon,
                                View.IdHangKHChon))
            {
                var lst = new List<string>();
                lst.Add(giaGiay.Ten);
                lst.Add(string.Format("{0:0,0.00}đ/tờ", giaMuaGiay));
                lst.Add(string.Format("{0:0,0.00}đ/tờ", giaGiay.GiaBan()));
                lst.Add(giaGiay.TenHangKhachHang());

                dict.Add(giaGiay.ID, lst);
            }

            return dict;
        }
        public List<DanhMucGiay> DanhMucTheoNhaCC()
        {
            return DanhMucGiay.LayTheoNhaCungCap(View.MaNhaCungCapChon);
        }
        public string DienGiaiHangKH()
        {
            return HangKhachHang.LayTheoId(View.IdHangKHChon).DienGiai;
        }
        public Giay GiayChon ()
        {
            Giay giayChon = null;
            if (View.IdGiayChon > 0)
                giayChon = Giay.DocGiayTheoId(View.IdGiayChon);

            return giayChon;
        }
    }
}
