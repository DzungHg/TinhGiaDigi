using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.Model.Booklet
{
    public class MonDongCuon
    {

        public int ID
        {
            get;
            set;
        }
        public int IdGoc { get; set; }
        public KieuDongCuonS KieuDongCuon { get; set; }
      
        public string Ten { get; set; }
        public bool BiaDon { get; set; }
        public bool RuotDon { get; set; }

        public static List<MonDongCuon> DocTatCa()
        {
            //Sắp xếp theo thứ tự
            int i = 0;
            List<MonDongCuon> lst = new List<MonDongCuon>();
            MonDongCuon monDC;
            foreach (DongCuon dc in DongCuon.DocTatCa())
            {
                i += 1;//Tạo ID
                monDC = new MonDongCuon{
                    ID = i,
                    IdGoc = dc.ID,
                    Ten = dc.Ten,
                    BiaDon = dc.BiaToDon,
                    RuotDon = dc.RuotToDon,
                    KieuDongCuon = KieuDongCuonS.KimKeoNep //Chỉ đại diện
                };
                

                lst.Add(monDC);

            }

            //Tiếp lò xo
         
            foreach (DongCuonLoXo dcLX in DongCuonLoXo.DocTatCa())
            {
                i += 1;//Tạo ID
                monDC = new MonDongCuon
                {
                    ID = i,
                    IdGoc = dcLX.ID,
                    Ten = dcLX.Ten,
                    BiaDon = dcLX.BiaToDon,
                    RuotDon = dcLX.RuotToDon,
                    KieuDongCuon = KieuDongCuonS.LoXo //Đúng
                };
                lst.Add(monDC);

            }
            //Tiếp Đóng mở phẳng

            foreach (DongCuonMoPhang dcMP in DongCuonMoPhang.DocTatCa())
            {
                i += 1;//Tạo ID
                monDC = new MonDongCuon
                {
                    ID = i,
                    IdGoc = dcMP.ID,
                    Ten = dcMP.Ten,
                    BiaDon = dcMP.BiaToDon,
                    RuotDon = dcMP.RuotToDon,
                    KieuDongCuon = KieuDongCuonS.MoPhang //Đúng
                };
                lst.Add(monDC);

            }
            return lst;
        
        }
        public static MonDongCuon DocTheoId(int iD)
        {
            var mon = MonDongCuon.DocTatCa().FirstOrDefault(x => x.ID == iD);

            return mon;
        }
        
    }
   
}
