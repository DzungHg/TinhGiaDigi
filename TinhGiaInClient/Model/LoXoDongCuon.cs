using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class LoXoDongCuon
    {
        public int ID { get; set; }
        public string TenVongXoan { get; set; }
        public string KichCoBuoc { get; set; }
        public string MauSac { get; set; }
        public string ChoDoDay { get; set; }
        public int GiaMuaTheoMet { get; set; }
        public int ThuTu { get; set; }
        //==
        #region Các hàm static
        public static List<LoXoDongCuon> DocTatCa()
        {
            var nhuEpKimLogic = new LoXoDongCuonLogic();
            List<LoXoDongCuon> nguon = null;
            try
            {
                nguon = nhuEpKimLogic.DocTatCa().Select(x => new LoXoDongCuon
                {
                    ID = x.ID,
                    TenVongXoan = x.TenVongXoan,
                    KichCoBuoc = x.KichCoBuoc,
                    MauSac = x.MauSac,
                    ChoDoDay = x.ChoDoDay,
                    GiaMuaTheoMet = x.GiaMuaTheoMet,
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }

        public static LoXoDongCuon DocTheoId(int idKhuonEpKim)
        {
            var khuonEpKimLogic = new LoXoDongCuonLogic();
            var khuonEpKim = new LoXoDongCuon();
            try
            {
                var khuonEpKimBDO = khuonEpKimLogic.DocTheoId(idKhuonEpKim);
                //Chuyen
                ChuyenDoiMauTinBDOThanhDTO(khuonEpKimBDO, khuonEpKim);
            }
                catch {
                }
            return khuonEpKim;
        }
        
        #region Thêm sửa xóa

        public static string Them(LoXoDongCuon item)
        {
            var giayLogic = new LoXoDongCuonLogic();
            var itemBDO = new LoXoDongCuonBDO();
            ChuyenDoiMauTinDTOThanhBDO(item, itemBDO);
            return giayLogic.Them(itemBDO);
        }

        public static string Sua(LoXoDongCuon item)
        {
            var giayLogic = new LoXoDongCuonLogic();
            var itemBDO = new LoXoDongCuonBDO();
            ChuyenDoiMauTinDTOThanhBDO(item, itemBDO);
            return giayLogic.Sua(itemBDO);
        }
        public static string Xoa(int idGiay)
        {
            var giayLogic = new LoXoDongCuonLogic();
            
            return giayLogic.Xoa(idGiay);
        }
        #endregion
        //Chuyển đổi
        private static void ChuyenDoiMauTinBDOThanhDTO(LoXoDongCuonBDO loXoDongCuonBDO, LoXoDongCuon loXoDongCuon)
        {
            loXoDongCuon.ID = loXoDongCuonBDO.ID;
            loXoDongCuon.TenVongXoan = loXoDongCuonBDO.TenVongXoan;
            loXoDongCuon.KichCoBuoc = loXoDongCuonBDO.KichCoBuoc;
            loXoDongCuon.MauSac = loXoDongCuonBDO.MauSac;
            loXoDongCuon.ChoDoDay = loXoDongCuonBDO.ChoDoDay;
            loXoDongCuon.GiaMuaTheoMet = loXoDongCuonBDO.GiaMuaTheoMet;
                                 
            loXoDongCuon.ThuTu = loXoDongCuonBDO.ThuTu;
        }
        private static void ChuyenDoiMauTinDTOThanhBDO(LoXoDongCuon nhuEpKim, LoXoDongCuonBDO nhuEpKimBDO)
        {
            nhuEpKimBDO.ID = nhuEpKim.ID;
            nhuEpKimBDO.TenVongXoan = nhuEpKim.TenVongXoan;
            nhuEpKimBDO.KichCoBuoc = nhuEpKim.KichCoBuoc;
            nhuEpKimBDO.MauSac = nhuEpKim.MauSac;
            nhuEpKimBDO.ChoDoDay = nhuEpKim.ChoDoDay;
            nhuEpKimBDO.GiaMuaTheoMet = nhuEpKim.GiaMuaTheoMet;
                      
            nhuEpKimBDO.ThuTu = nhuEpKim.ThuTu;
        }
        #endregion
    }
}
