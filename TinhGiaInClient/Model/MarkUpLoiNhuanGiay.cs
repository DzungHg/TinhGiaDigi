using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class MarkUpLoiNhuanGiay
    {
        public int IdDanhMucGiay { get; set; }
        public int IdHangKhachHang { get; set; }
        public string TenHangKhachHang { get; set; }//Chỉ để view
        public int TiLeLoiNhuanTrenDoanhThu { get; set; }
        //Static

        
        public static List<MarkUpLoiNhuanGiay> LayTatCa()
        {
            List<MarkUpLoiNhuanGiay> lst = null;
            MarkUpLoiNhuanGiayLogic markUpLNGLogic = new MarkUpLoiNhuanGiayLogic();
            try
            {
                 lst = markUpLNGLogic.LayTatCa().Select(x => new MarkUpLoiNhuanGiay
                {
                    IdDanhMucGiay = x.IdDanhMucGiay,
                    IdHangKhachHang = x.IdHangKhachHang,
                    TiLeLoiNhuanTrenDoanhThu = x.TiLeLoiNhuanTrenDoanhThu
                }).ToList();
                
            }
            catch { }
            return lst;
        }
        public static MarkUpLoiNhuanGiay LayTheoId(int idDanhMucGiay, int idHangKH)
        {
            MarkUpLoiNhuanGiay item = null;
            MarkUpLoiNhuanGiayLogic markUpLNGLogic = new MarkUpLoiNhuanGiayLogic();
            try
            {
                item = new MarkUpLoiNhuanGiay();
                var itemBDO = markUpLNGLogic.LayTheoId(idDanhMucGiay, idHangKH);
                ChuyenDoiGiayBDOThanhDTO(itemBDO, item);

            }
            catch { }
            return item;
        }
        public static List<MarkUpLoiNhuanGiay> LayTheoIdDanhMucGiay(int iD)
        {
            List<MarkUpLoiNhuanGiay> lst = null;
            MarkUpLoiNhuanGiayLogic markUpLNGLogic = new MarkUpLoiNhuanGiayLogic();
            try
            {
                lst = markUpLNGLogic.LayTheoIdDanhMucGiay(iD).Select(x => new MarkUpLoiNhuanGiay
                {
                    IdDanhMucGiay = x.IdDanhMucGiay,
                    IdHangKhachHang = x.IdHangKhachHang,
                    TenHangKhachHang = x.TenHangKhachHang,
                    TiLeLoiNhuanTrenDoanhThu = x.TiLeLoiNhuanTrenDoanhThu
                }).ToList();

            }
            catch { }
            return lst;
        }
        #region THêm, sửa xóa
        public static void Them(MarkUpLoiNhuanGiay item)
        {
            MarkUpLoiNhuanGiayLogic markUpLNGLogic = new MarkUpLoiNhuanGiayLogic();
            var itemBDO = new MarkUpLoiNhuanGiayBDO();
            ChuyenDoiGiayDTOThanhBDO(item, itemBDO);
            markUpLNGLogic.Them(itemBDO);
        }

        public static void Sua(MarkUpLoiNhuanGiay item)
        {
            MarkUpLoiNhuanGiayLogic markUpLNGLogic = new MarkUpLoiNhuanGiayLogic();
            var itemBDO = new MarkUpLoiNhuanGiayBDO();
            ChuyenDoiGiayDTOThanhBDO(item, itemBDO);
            markUpLNGLogic.Sua(itemBDO);
        }

        #endregion
        //Chuyển đổi
        private static void ChuyenDoiGiayBDOThanhDTO(MarkUpLoiNhuanGiayBDO giayBDO, MarkUpLoiNhuanGiay giayDTO)
        {
            giayDTO.IdDanhMucGiay = giayBDO.IdDanhMucGiay;
            giayDTO.IdHangKhachHang = giayBDO.IdHangKhachHang;            
            giayDTO.TiLeLoiNhuanTrenDoanhThu = giayBDO.TiLeLoiNhuanTrenDoanhThu;
        }
         private static void ChuyenDoiGiayDTOThanhBDO(MarkUpLoiNhuanGiay giayDTO, MarkUpLoiNhuanGiayBDO giayBDO)
        {
            giayBDO.IdDanhMucGiay = giayDTO.IdDanhMucGiay;
            giayBDO.IdHangKhachHang = giayDTO.IdHangKhachHang;            
            giayBDO.TiLeLoiNhuanTrenDoanhThu = giayDTO.TiLeLoiNhuanTrenDoanhThu;
        }
    }
}
