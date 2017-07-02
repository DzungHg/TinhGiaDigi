using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInClient;
using TinhGiaInNhapLieu.View;

namespace TinhGiaInNhapLieu.Presenter
{
    public class QuanLyTChonThNhuaPresenter
    {
        IViewQuanLyTChonThNhua View;
        public QuanLyTChonThNhuaPresenter(IViewQuanLyTChonThNhua view)
        {
            View = view;
        }
        public List<BangGiaTheNhua> BangGiaS()
        {
            return BangGiaTheNhua.DocTatCa();
        }
        public string MoToBangGia()
        {
            var kq = "";
            if (View.IdBangGiaChon > 0)
            {
                kq = BangGiaTheNhua.DocTheoId(View.IdBangGiaChon).MoTa;
            }
            return kq;
        }
        public List<TuyChonTheNhua> TuyChonS()
        {
            return TuyChonTheNhua.DocTatCa();
        }
        public List<GiaTuyChonTheNhua> GiaTuyChonSTheoBangGia()
        {//
            return GiaTuyChonTheNhua.DocTheoIdBangGia(View.IdBangGiaChon);
        }
        public List<int>IdTuyChonSCoTrongGiaTheoBangGia()
        {
            List<int> lst = null;
            lst = GiaTuyChonTheNhua.DocTatCa().Where(x => x.IdBangGiaTheNhua == View.IdBangGiaChon).Select(x => x.IdTuyChonTheNhua).ToList(); 
            return lst;

        }
        public int GiaTheoId(int idBangGia, int idTuyChon)
        {
            var kq = 0;
            if (idBangGia > 0 && idTuyChon > 0)
            {
                kq = GiaTuyChonTheNhua.DocTheoId(idBangGia, idTuyChon).GiaBan;
            }
                return kq;
        }
        public void LuuThemMoiTuyChon(ref string thongDiep, List<int> danhSachIdTuyChon)
        {
            if (danhSachIdTuyChon.Count <= 0)
                return;
            //Kiểm tra id nào chưa có theo Bảng này thì thêm mới vô không thôi
            //GiaTuyChonDanhThiep giaTuyChon = null;
            thongDiep = "?";
            foreach (int id in danhSachIdTuyChon)
            {
                var giaTuyChon = GiaTuyChonTheNhua.DocTheoId(View.IdBangGiaChon, id);

                if (giaTuyChon.IdBangGiaTheNhua == 0 && giaTuyChon.IdTuyChonTheNhua == 0)
                {

                    giaTuyChon = new GiaTuyChonTheNhua
                    {
                        IdBangGiaTheNhua = View.IdBangGiaChon,
                        IdTuyChonTheNhua = id,
                        GiaBan = 0
                    };
                    thongDiep = GiaTuyChonTheNhua.Them(giaTuyChon);
                    
                }
            }
        }
        public void CapNhatGiaTuyChon(ref string thongDiep, GiaTuyChonTheNhua giaTuyChon)
        {
            thongDiep = GiaTuyChonTheNhua.Sua(giaTuyChon);

        }
       
    }
}
