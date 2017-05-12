using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TinhGiaInClient.Model;
using TinhGiaInClient.View;

namespace TinhGiaInClient.Presenter
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
        public SoLuong_Gia(int soLuong, decimal gia)
        {
            _soLuong = soLuong;
            _gia = gia;
        }
        private int _soLuong;
        private decimal _gia;
    }
    public class BangGiaThanhPhamPresenter
    {
        IViewBangGiaThanhPham View;
        public BangGiaThanhPhamPresenter(IViewBangGiaThanhPham view)
        {
            View = view;
            
        }
        
        public List<HangKhachHang>HangKhachHangS()
        {
            return HangKhachHang.LayTatCa();
        }
        public string TenHangKhachHang()
        {
            return HangKhachHang.LayTheoId(View.IdHangKHChon).Ten;

        }

        public List<MonThanhPham> MonThanhPhamS()
        {
            return MonThanhPham.DocTatCa();
        }
       
        public void TrinhBayDuLieuThanhPhamTheoMon()
        {
            var monThPh = MonThanhPham.DocTheoId(View.IdMonThanhPham);
            View.DaySoluong = monThPh.DaySoLuong;
            View.DonViTinh = monThPh.DonViTinh;
        }

        public SoLuong_Gia[] SoLuong_GiaS()
        {

            var soLuongS = View.DaySoluong.Split(';');
            var kQSoluong_gia = new SoLuong_Gia[soLuongS.Count()];
            SoLuong_Gia sLG;
            var i = 0;
            foreach (string st in soLuongS)
            {
                sLG = new SoLuong_Gia(int.Parse(st), 0);
                kQSoluong_gia[i] = sLG;
                i++;
            }

            return kQSoluong_gia;
        }
       
    }

}
