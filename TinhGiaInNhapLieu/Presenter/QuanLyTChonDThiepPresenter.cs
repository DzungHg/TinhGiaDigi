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
    public class QuanLyTChonDThiepPresenter
    {
        IViewQuanLyTChonDThiep View;
        public QuanLyTChonDThiepPresenter(IViewQuanLyTChonDThiep view)
        {
            View = view;
        }
        public List<BangGiaDanhThiep> BangGiaS()
        {
            return BangGiaDanhThiep.DocTatCa();
        }
        public string MoToBangGia()
        {
            var kq = "";
            if (View.IdBangGiaChon > 0)
            {
                kq = BangGiaDanhThiep.DocTheoId(View.IdBangGiaChon).MoTa;
            }
            return kq;
        }
        public List<TuyChonDanhThiep> TuyChonS()
        {
            return TuyChonDanhThiep.DocTatCa();
        }
        public List<GiaTuyChonDanhThiep> GiaTuyChonSTheoBangGia()
        {//
            return GiaTuyChonDanhThiep.DocTheoIdBangGia(View.IdBangGiaChon);
        }
        public List<int>IdTuyChonSCoTrongGiaTheoBangGia()
        {
            List<int> lst = null;
            lst = GiaTuyChonDanhThiep.DocTatCa().Where(x => x.IdBangGiaDanhThiep == View.IdBangGiaChon).Select(x => x.IdTuyChonDanhThiep).ToList(); 
            return lst;

        }
        public int GiaTheoId(int idBangGia, int idTuyChon)
        {
            var kq = 0;
            if (idBangGia > 0 && idTuyChon > 0)
            {
                kq = GiaTuyChonDanhThiep.DocTheoId(idBangGia, idTuyChon).GiaBan;
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
                var giaTuyChon = GiaTuyChonDanhThiep.DocTheoId(View.IdBangGiaChon, id);
                
                if (giaTuyChon.IdBangGiaDanhThiep == 0 && giaTuyChon.IdTuyChonDanhThiep == 0)
                {
                
                    giaTuyChon = new GiaTuyChonDanhThiep
                    {
                        IdBangGiaDanhThiep = View.IdBangGiaChon,
                        IdTuyChonDanhThiep = id,
                        GiaBan = 0
                    };
                    thongDiep = GiaTuyChonDanhThiep.Them(giaTuyChon);
                    
                }
            }
        }
        public void CapNhatGiaTuyChon(ref string thongDiep, GiaTuyChonDanhThiep giaTuyChon)
        {
            thongDiep = GiaTuyChonDanhThiep.Sua(giaTuyChon);

        }
       
    }
}
