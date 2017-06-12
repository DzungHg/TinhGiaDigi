﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInClient.Model.Booklet;
using TinhGiaInClient.View;
namespace TinhGiaInClient.Presenter
{
    public class InSachDigiPresenter
    {
        IViewInSachDigi View;
        GiaInSachDigi GiaSach;
        public InSachDigiPresenter(IViewInSachDigi view, GiaInSachDigi giaInSach)
        {
            View = view;
            this.GiaSach = giaInSach;

            //
            View.ID = this.GiaSach.ID;
            View.TieuDe = this.GiaSach.TieuDe;
            View.SachRong = this.GiaSach.QuiCachSach.ChieuRong;
            View.SachCao = this.GiaSach.QuiCachSach.ChieuCao;
            View.GayDay = this.GiaSach.QuiCachSach.GayDay;
            View.KieuDongCuon = this.GiaSach.QuiCachSach.KieuDongCuon;
            View.SoTrangBia = this.GiaSach.QuiCachSach.SoTrangBia;
            View.SoTrangRuot = this.GiaSach.QuiCachSach.SoTrangRuot;
            View.SoCuon = this.GiaSach.SoCuon;
            View.Bia = this.GiaSach.InBia;
            View.Ruot = this.GiaSach.InRuot;

        }
        public List<MonDongCuon> MonDongCuonS()
        {
            return MonDongCuon.DocTatCa();
        }
        public MonDongCuon DocTheoID()
        {
            return MonDongCuon.DocTheoId(View.IdMonDongCuonChon);
        }
        public int TongSoTrang()
        {
            return this.GiaSach.TongSoTrang;
        }
        private void CapNhatGiaSach()
        {
            this.GiaSach.ID = View.ID;
            this.GiaSach.TieuDe = View.TieuDe;
            this.GiaSach.QuiCachSach.ChieuRong = View.SachRong;
            this.GiaSach.QuiCachSach.ChieuCao = View.SachCao;
            this.GiaSach.QuiCachSach.GayDay = View.GayDay;
            this.GiaSach.QuiCachSach.KieuDongCuon = View.KieuDongCuon;
            this.GiaSach.QuiCachSach.SoTrangBia = View.SoTrangBia;
            this.GiaSach.QuiCachSach.SoTrangRuot = View.SoTrangRuot;
            //Cập nhật bìa
            this.GiaSach.InBia = View.Bia;
            this.GiaSach.InRuot = View.Ruot;
            //Cập nhật thành phẩm

            this.GiaSach.SoCuon = View.SoCuon;
        }
        public GiaInSachDigi DocGiaSachDigi()
        {
            CapNhatGiaSach();
            return this.GiaSach;
        }
    }
}
