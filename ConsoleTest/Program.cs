using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;
using TinhGiaInClient.Model;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*//var toChayDigi = new ToChayDigiDAO();
            
            var hangKhachHang = new HangKhachHangDAO();
            //Console.WriteLine("{0}", toChayDigi.LayTatCa().Count());
            Console.WriteLine("Tỉ lệ chênh lệch {0}", hangKhachHang.LayTheoId(3).LoiNhuanChenhLech);
            Console.ReadLine();
             */
            /*
            var dongCuonDAO = new DongCuonDAO();
            var dongCuon = DongCuon.DocTheoId(7);//Keo pur
            //var soLuongS = dongCuon.DaySoLuong.Split(';');
            var soLuong = int.Parse(Console.ReadLine());
               // Console.WriteLine("Tỉ lệ lợi lấy ra {0}", TinhToanThanhPham.MucLoiNhuan(dongCuon.DaySoLuong, dongCuon.DayLoiNhuan,
                 //   int.Parse(soLuong)));

            var giaDongCuon = new GiaDongCuon(soLuong, 0, "v", dongCuon);

                Console.WriteLine("Chi phí {0}", giaDongCuon.ChiPhi());
           
            */
            //Thử tờ chạy => KQ: Tốt
            /*
            var iD = Console.ReadLine();
            var toChayDigi = new ToChayDigiDAO();
            Console.WriteLine("BHR là {0}", toChayDigi.LayTheoId(int.Parse(iD)).ClickA4BonMau);
            Console.ReadLine();
             */ 
            //Kiểm tra đóng cuốn lò xo
            var soLuong = int.Parse(Console.ReadLine());
            var mayDongLoXo = DongCuonLoXo.DocTheoId(2);//Máy CN
            var loXo = LoXoDongCuon.DocTheoId(1);
            var giaCuonLoXo = new GiaDongCuonLoXo(soLuong, 30, mayDongLoXo, loXo, 0);
            var dongCuon = DongCuon.DocTheoId(7);//Keo pur
            //var soLuongS = dongCuon.DaySoLuong.Split(';');
            
            // Console.WriteLine("Tỉ lệ lợi lấy ra {0}", TinhToanThanhPham.MucLoiNhuan(dongCuon.DaySoLuong, dongCuon.DayLoiNhuan,
            //   int.Parse(soLuong)));

            var giaDongCuon = new GiaDongCuon(soLuong, 0, "v", dongCuon);

            Console.WriteLine("Giá lô {0}, giá TB: {1}/cuón", giaCuonLoXo.ThanhTienSales(), giaCuonLoXo.GiaTBTrenDonVi());
            Console.ReadLine();
        }
    }
}
