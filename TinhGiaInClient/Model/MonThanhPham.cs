using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.Model
{
    public class DichVuThanhPham
    {

        public int ID
        {
            get;
            set;
        }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public int ID_DV { get; set; }
        public string DonViTinh { get; set; }
        public string DaySoLuongNiemYet { get; set; }
        public LoaiThanhPhamS LoaiThPham { get; set; }
        public DichVuThanhPham(int iD, string ten, int iD_DV, string donViTinh,
            string daySoLuongNiemYet, LoaiThanhPhamS loaiThPh)
        {

            this.ID = iD;
            this.Ten = ten;
            this.ID_DV = iD_DV;
            this.LoaiThPham = loaiThPh;
            this.DonViTinh = donViTinh;
            this.DaySoLuongNiemYet = daySoLuongNiemYet;

        }
    }
    public class MonThanhPham
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string Ma_01 { get; set; }
        public string Ma_02 { get; set; }
        public string Ma_03 { get; set; }
        public string DonViTinh { get; set; }
        public string DaySoLuong { get; set; }
        public int ThuTu { get; set; }

        public static List<MonThanhPham> DocTatCa()
        {
            //Sắp xếp theo thứ tự
            var khoSanPhamLogic = new MonThanhPhamLogic();
            List<MonThanhPham> nguon = null;
            try
            {
                nguon = khoSanPhamLogic.DocTatCa().Select(x => new MonThanhPham
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    Ma_01 = x.Ma_01,
                    Ma_02 = x.Ma_02,
                    Ma_03 = x.Ma_03,
                    DaySoLuong = x.DaySoLuong,
                    DonViTinh = x.DonViTinh,
                    ThuTu = (int)x.ThuTu
                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }
        public static MonThanhPham DocTheoId(int iD)
        {
            var khoSanPhamLogic = new MonThanhPhamLogic();
            MonThanhPhamBDO khoSP_BDO = null;
            MonThanhPham khoSP_DTO = null;
            try
            {
                khoSP_BDO = khoSanPhamLogic.DocTheoId(iD);
                if (khoSP_BDO != null)
                {
                    khoSP_DTO = new MonThanhPham();
                    //Chuyển đổi
                    MonThanhPham.ChuyenBDOThanhDTO(khoSP_BDO, khoSP_DTO);
                }

            }
            catch { }
            return khoSP_DTO;
        }
        //--Hàm Chuyển
        public static void ChuyenBDOThanhDTO(MonThanhPhamBDO monTP_BDO, MonThanhPham monTP_DTO)
        {
            monTP_DTO.ID = monTP_BDO.ID;
            monTP_DTO.Ten = monTP_BDO.Ten;
            monTP_DTO.Ma_01 = monTP_BDO.Ma_01;
            monTP_DTO.Ma_02 = monTP_BDO.Ma_02;
            monTP_DTO.Ma_02 = monTP_BDO.Ma_03;
            monTP_DTO.DaySoLuong = monTP_BDO.DaySoLuong;
            monTP_DTO.DonViTinh = monTP_BDO.DonViTinh;
            monTP_DTO.ThuTu = monTP_BDO.ThuTu;
        }
        #region Làm thêm dịch vụ thành phẩm
        public static List<DichVuThanhPham>DocTatCaDichVuThanhPham()
        {
            var lst = new List<DichVuThanhPham>();
            var i = 0;
            DichVuThanhPham dvTP;
            //Cán phủ
            foreach (CanPhu cp in CanPhu.DocTatCa())
            {
                i += 1;
                dvTP = new DichVuThanhPham(i, cp.Ten, cp.ID, cp.DonViTinh,
                    cp.DaySoLuongNiemYet, LoaiThanhPhamS.CanPhu);
               
                lst.Add(dvTP);
            }
            //Cân gấp
            foreach (CanGap cp in CanGap.DocTatCa())
            {
                i += 1;
                dvTP = dvTP = new DichVuThanhPham(i, cp.Ten, cp.ID, cp.DonViTinh,
                    cp.DaySoLuongNiemYet, LoaiThanhPhamS.CanGap);
                lst.Add(dvTP);
            }
            //Đóng cuốn
            foreach (DongCuon cp in DongCuon.DocTatCa())
            {
                i += 1;
                dvTP = dvTP = new DichVuThanhPham(i, cp.Ten, cp.ID, cp.DonViTinh,
                    cp.DaySoLuongNiemYet, LoaiThanhPhamS.DongCuon);
                lst.Add(dvTP);
            }
            //Ép kim
            foreach (EpKim cp in EpKim.DocTatCa())
            {
                i += 1;
                dvTP = dvTP = new DichVuThanhPham(i, cp.Ten, cp.ID, cp.DonViTinh,
                    cp.DaySoLuongNiemYet, LoaiThanhPhamS.EpKim);
                lst.Add(dvTP);
            }

            return lst.OrderBy(x => x.ID).ToList();
        }
        public static DichVuThanhPham DocDVThanhPhamTheoId(int iDDVTP)
        {
            return MonThanhPham.DocTatCaDichVuThanhPham().FirstOrDefault(x => x.ID == iDDVTP);
        }
        #endregion
    }
   
}
