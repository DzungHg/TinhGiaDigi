﻿namespace TinhGiaInClient
{
    partial class TinhGiaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblIdTinhGia = new System.Windows.Forms.Label();
            this.txtDienGiaiHangKH = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboHangKH = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.txtTieuDeTinhGia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnXoaSachBaiIn = new System.Windows.Forms.Button();
            this.lvwBaiIn = new System.Windows.Forms.ListView();
            this.btnXoaBaiIn = new System.Windows.Forms.Button();
            this.btnThemBaiIn = new System.Windows.Forms.Button();
            this.txtTomTatBaiIn = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.tabCtrl01 = new System.Windows.Forms.TabControl();
            this.tabDanhThiep = new System.Windows.Forms.TabPage();
            this.lvwDanhThiep = new System.Windows.Forms.ListView();
            this.tabInTheoBai = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            this.tabCtrl01.SuspendLayout();
            this.tabDanhThiep.SuspendLayout();
            this.tabInTheoBai.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblIdTinhGia);
            this.groupBox1.Controls.Add(this.txtDienGiaiHangKH);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboHangKH);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTenNV);
            this.groupBox1.Controls.Add(this.dtpNgay);
            this.groupBox1.Controls.Add(this.txtTieuDeTinhGia);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(781, 136);
            this.groupBox1.TabIndex = 195;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tính giá, thông tin tổng quát";
            // 
            // lblIdTinhGia
            // 
            this.lblIdTinhGia.AutoSize = true;
            this.lblIdTinhGia.Location = new System.Drawing.Point(24, 25);
            this.lblIdTinhGia.Name = "lblIdTinhGia";
            this.lblIdTinhGia.Size = new System.Drawing.Size(18, 13);
            this.lblIdTinhGia.TabIndex = 233;
            this.lblIdTinhGia.Text = "ID";
            // 
            // txtDienGiaiHangKH
            // 
            this.txtDienGiaiHangKH.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDienGiaiHangKH.ForeColor = System.Drawing.Color.Black;
            this.txtDienGiaiHangKH.Location = new System.Drawing.Point(397, 52);
            this.txtDienGiaiHangKH.Multiline = true;
            this.txtDienGiaiHangKH.Name = "txtDienGiaiHangKH";
            this.txtDienGiaiHangKH.ReadOnly = true;
            this.txtDienGiaiHangKH.Size = new System.Drawing.Size(205, 34);
            this.txtDienGiaiHangKH.TabIndex = 214;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(333, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 232;
            this.label5.Text = "Hạng KH:";
            // 
            // cboHangKH
            // 
            this.cboHangKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHangKH.FormattingEnabled = true;
            this.cboHangKH.Location = new System.Drawing.Point(397, 25);
            this.cboHangKH.Name = "cboHangKH";
            this.cboHangKH.Size = new System.Drawing.Size(106, 21);
            this.cboHangKH.TabIndex = 231;
            this.cboHangKH.SelectedIndexChanged += new System.EventHandler(this.cboHangKH_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 204;
            this.label3.Text = "Nhân viên";
            // 
            // txtTenNV
            // 
            this.txtTenNV.Enabled = false;
            this.txtTenNV.Location = new System.Drawing.Point(88, 74);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(205, 20);
            this.txtTenNV.TabIndex = 199;
            // 
            // dtpNgay
            // 
            this.dtpNgay.Location = new System.Drawing.Point(88, 19);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(205, 20);
            this.dtpNgay.TabIndex = 194;
            // 
            // txtTieuDeTinhGia
            // 
            this.txtTieuDeTinhGia.Location = new System.Drawing.Point(88, 47);
            this.txtTieuDeTinhGia.Name = "txtTieuDeTinhGia";
            this.txtTieuDeTinhGia.Size = new System.Drawing.Size(205, 20);
            this.txtTieuDeTinhGia.TabIndex = 196;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 202;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 200;
            this.label10.Text = "Tiêu đề";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(541, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 194;
            this.label4.Text = "Tóm tắt";
            // 
            // btnXoaSachBaiIn
            // 
            this.btnXoaSachBaiIn.Location = new System.Drawing.Point(181, 194);
            this.btnXoaSachBaiIn.Name = "btnXoaSachBaiIn";
            this.btnXoaSachBaiIn.Size = new System.Drawing.Size(75, 23);
            this.btnXoaSachBaiIn.TabIndex = 9;
            this.btnXoaSachBaiIn.Text = "Xóa sạch";
            this.btnXoaSachBaiIn.UseVisualStyleBackColor = true;
            this.btnXoaSachBaiIn.Click += new System.EventHandler(this.btnXoaSachBaiIn_Click);
            // 
            // lvwBaiIn
            // 
            this.lvwBaiIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwBaiIn.FullRowSelect = true;
            this.lvwBaiIn.GridLines = true;
            this.lvwBaiIn.Location = new System.Drawing.Point(0, 0);
            this.lvwBaiIn.MultiSelect = false;
            this.lvwBaiIn.Name = "lvwBaiIn";
            this.lvwBaiIn.Size = new System.Drawing.Size(517, 213);
            this.lvwBaiIn.TabIndex = 10;
            this.lvwBaiIn.UseCompatibleStateImageBehavior = false;
            this.lvwBaiIn.SelectedIndexChanged += new System.EventHandler(this.lvwBaiIn_SelectedIndexChanged);
            // 
            // btnXoaBaiIn
            // 
            this.btnXoaBaiIn.Location = new System.Drawing.Point(100, 194);
            this.btnXoaBaiIn.Name = "btnXoaBaiIn";
            this.btnXoaBaiIn.Size = new System.Drawing.Size(75, 23);
            this.btnXoaBaiIn.TabIndex = 8;
            this.btnXoaBaiIn.Text = "Xóa";
            this.btnXoaBaiIn.UseVisualStyleBackColor = true;
            this.btnXoaBaiIn.Click += new System.EventHandler(this.btnXoaBaiIn_Click);
            // 
            // btnThemBaiIn
            // 
            this.btnThemBaiIn.Location = new System.Drawing.Point(15, 194);
            this.btnThemBaiIn.Name = "btnThemBaiIn";
            this.btnThemBaiIn.Size = new System.Drawing.Size(75, 23);
            this.btnThemBaiIn.TabIndex = 6;
            this.btnThemBaiIn.Text = "Thêm";
            this.btnThemBaiIn.UseVisualStyleBackColor = true;
            this.btnThemBaiIn.Click += new System.EventHandler(this.btnThemBaiIn_Click);
            // 
            // txtTomTatBaiIn
            // 
            this.txtTomTatBaiIn.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTomTatBaiIn.ForeColor = System.Drawing.Color.Black;
            this.txtTomTatBaiIn.Location = new System.Drawing.Point(541, 245);
            this.txtTomTatBaiIn.Multiline = true;
            this.txtTomTatBaiIn.Name = "txtTomTatBaiIn";
            this.txtTomTatBaiIn.ReadOnly = true;
            this.txtTomTatBaiIn.Size = new System.Drawing.Size(250, 213);
            this.txtTomTatBaiIn.TabIndex = 212;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(305, 471);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 67;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLuu.Location = new System.Drawing.Point(409, 471);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 66;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // tabCtrl01
            // 
            this.tabCtrl01.Controls.Add(this.tabDanhThiep);
            this.tabCtrl01.Controls.Add(this.tabInTheoBai);
            this.tabCtrl01.Location = new System.Drawing.Point(10, 223);
            this.tabCtrl01.Name = "tabCtrl01";
            this.tabCtrl01.SelectedIndex = 0;
            this.tabCtrl01.Size = new System.Drawing.Size(525, 239);
            this.tabCtrl01.TabIndex = 213;
            // 
            // tabDanhThiep
            // 
            this.tabDanhThiep.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabDanhThiep.Controls.Add(this.lvwDanhThiep);
            this.tabDanhThiep.Location = new System.Drawing.Point(4, 22);
            this.tabDanhThiep.Name = "tabDanhThiep";
            this.tabDanhThiep.Padding = new System.Windows.Forms.Padding(3);
            this.tabDanhThiep.Size = new System.Drawing.Size(517, 213);
            this.tabDanhThiep.TabIndex = 0;
            this.tabDanhThiep.Text = "Danh Thiếp";
            // 
            // lvwDanhThiep
            // 
            this.lvwDanhThiep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwDanhThiep.FullRowSelect = true;
            this.lvwDanhThiep.GridLines = true;
            this.lvwDanhThiep.Location = new System.Drawing.Point(3, 3);
            this.lvwDanhThiep.MultiSelect = false;
            this.lvwDanhThiep.Name = "lvwDanhThiep";
            this.lvwDanhThiep.Size = new System.Drawing.Size(511, 207);
            this.lvwDanhThiep.TabIndex = 11;
            this.lvwDanhThiep.UseCompatibleStateImageBehavior = false;
            // 
            // tabInTheoBai
            // 
            this.tabInTheoBai.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabInTheoBai.Controls.Add(this.lvwBaiIn);
            this.tabInTheoBai.Location = new System.Drawing.Point(4, 22);
            this.tabInTheoBai.Name = "tabInTheoBai";
            this.tabInTheoBai.Size = new System.Drawing.Size(517, 213);
            this.tabInTheoBai.TabIndex = 11;
            this.tabInTheoBai.Text = "In theo bài";
            // 
            // TinhGiaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 506);
            this.Controls.Add(this.tabCtrl01);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtTomTatBaiIn);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnXoaSachBaiIn);
            this.Controls.Add(this.btnXoaBaiIn);
            this.Controls.Add(this.btnThemBaiIn);
            this.Name = "TinhGiaForm";
            this.Text = "Tính giá Nhanh";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TinhGiaForm_FormClosing);
            this.Load += new System.EventHandler(this.TinhGiaForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabCtrl01.ResumeLayout(false);
            this.tabDanhThiep.ResumeLayout(false);
            this.tabInTheoBai.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoaSachBaiIn;
        private System.Windows.Forms.Button btnXoaBaiIn;
        private System.Windows.Forms.Button btnThemBaiIn;
        private System.Windows.Forms.ListView lvwBaiIn;
        private System.Windows.Forms.TextBox txtTomTatBaiIn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.TextBox txtTieuDeTinhGia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabCtrl01;
        private System.Windows.Forms.TabPage tabDanhThiep;
        private System.Windows.Forms.ListView lvwDanhThiep;
        private System.Windows.Forms.TabPage tabInTheoBai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboHangKH;
        private System.Windows.Forms.TextBox txtDienGiaiHangKH;
        private System.Windows.Forms.Label lblIdTinhGia;

    }
}

