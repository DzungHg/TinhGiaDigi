﻿namespace TinhGiaInClient.UI
{
    partial class SoSanhGiaInNhanhForm
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
            this.cboNiemYetGiaA = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnTinh = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.lvwTrinhBayBangGiaA = new System.Windows.Forms.ListView();
            this.txtDayTrangA4 = new System.Windows.Forms.TextBox();
            this.cboNiemYetGiaB = new System.Windows.Forms.ComboBox();
            this.lblTenLoaiBangGiaA = new System.Windows.Forms.Label();
            this.txtDienGiaiNYGiaA = new System.Windows.Forms.TextBox();
            this.txtTenNhaInA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTenNhaInB = new System.Windows.Forms.TextBox();
            this.lblTenLoaiBangGiaB = new System.Windows.Forms.Label();
            this.txtDienGiaiNYGiaB = new System.Windows.Forms.TextBox();
            this.lvwTrinhBayBangGiaB = new System.Windows.Forms.ListView();
            this.label9 = new System.Windows.Forms.Label();
            this.lvwKetQua = new System.Windows.Forms.ListView();
            this.btnCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboNiemYetGiaA
            // 
            this.cboNiemYetGiaA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNiemYetGiaA.FormattingEnabled = true;
            this.cboNiemYetGiaA.Location = new System.Drawing.Point(11, 86);
            this.cboNiemYetGiaA.Name = "cboNiemYetGiaA";
            this.cboNiemYetGiaA.Size = new System.Drawing.Size(201, 21);
            this.cboNiemYetGiaA.TabIndex = 2;
            this.cboNiemYetGiaA.SelectedIndexChanged += new System.EventHandler(this.cboBangGia_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 91;
            this.label1.Text = "SO SÁNH GIÁ IN NHANH";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(318, 456);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnTinh
            // 
            this.btnTinh.Location = new System.Drawing.Point(514, 97);
            this.btnTinh.Name = "btnTinh";
            this.btnTinh.Size = new System.Drawing.Size(90, 23);
            this.btnTinh.TabIndex = 5;
            this.btnTinh.Text = "Tính";
            this.btnTinh.UseVisualStyleBackColor = true;
            this.btnTinh.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 98;
            this.label3.Text = "Bảng giá In nhanh";
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Location = new System.Drawing.Point(610, 107);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(44, 13);
            this.lblKetQua.TabIndex = 102;
            this.lblKetQua.Text = "Kết quả";
            // 
            // lvwTrinhBayBangGiaA
            // 
            this.lvwTrinhBayBangGiaA.Location = new System.Drawing.Point(15, 217);
            this.lvwTrinhBayBangGiaA.Name = "lvwTrinhBayBangGiaA";
            this.lvwTrinhBayBangGiaA.Size = new System.Drawing.Size(197, 217);
            this.lvwTrinhBayBangGiaA.TabIndex = 3;
            this.lvwTrinhBayBangGiaA.UseCompatibleStateImageBehavior = false;
            this.lvwTrinhBayBangGiaA.View = System.Windows.Forms.View.Details;
            // 
            // txtDayTrangA4
            // 
            this.txtDayTrangA4.Location = new System.Drawing.Point(426, 126);
            this.txtDayTrangA4.Multiline = true;
            this.txtDayTrangA4.Name = "txtDayTrangA4";
            this.txtDayTrangA4.Size = new System.Drawing.Size(82, 308);
            this.txtDayTrangA4.TabIndex = 111;
            this.txtDayTrangA4.Text = "0";
            // 
            // cboNiemYetGiaB
            // 
            this.cboNiemYetGiaB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNiemYetGiaB.FormattingEnabled = true;
            this.cboNiemYetGiaB.Location = new System.Drawing.Point(219, 86);
            this.cboNiemYetGiaB.Name = "cboNiemYetGiaB";
            this.cboNiemYetGiaB.Size = new System.Drawing.Size(201, 21);
            this.cboNiemYetGiaB.TabIndex = 112;
            // 
            // lblTenLoaiBangGiaA
            // 
            this.lblTenLoaiBangGiaA.AutoSize = true;
            this.lblTenLoaiBangGiaA.Location = new System.Drawing.Point(12, 110);
            this.lblTenLoaiBangGiaA.Name = "lblTenLoaiBangGiaA";
            this.lblTenLoaiBangGiaA.Size = new System.Drawing.Size(63, 13);
            this.lblTenLoaiBangGiaA.TabIndex = 114;
            this.lblTenLoaiBangGiaA.Text = "Tên loại BG";
            // 
            // txtDienGiaiNYGiaA
            // 
            this.txtDienGiaiNYGiaA.Location = new System.Drawing.Point(12, 126);
            this.txtDienGiaiNYGiaA.Multiline = true;
            this.txtDienGiaiNYGiaA.Name = "txtDienGiaiNYGiaA";
            this.txtDienGiaiNYGiaA.ReadOnly = true;
            this.txtDienGiaiNYGiaA.Size = new System.Drawing.Size(200, 76);
            this.txtDienGiaiNYGiaA.TabIndex = 115;
            this.txtDienGiaiNYGiaA.Text = "0";
            // 
            // txtTenNhaInA
            // 
            this.txtTenNhaInA.Location = new System.Drawing.Point(62, 47);
            this.txtTenNhaInA.Name = "txtTenNhaInA";
            this.txtTenNhaInA.Size = new System.Drawing.Size(150, 20);
            this.txtTenNhaInA.TabIndex = 116;
            this.txtTenNhaInA.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 117;
            this.label5.Text = "Nhà in 1";
            // 
            // txtTenNhaInB
            // 
            this.txtTenNhaInB.Location = new System.Drawing.Point(270, 47);
            this.txtTenNhaInB.Name = "txtTenNhaInB";
            this.txtTenNhaInB.Size = new System.Drawing.Size(150, 20);
            this.txtTenNhaInB.TabIndex = 118;
            this.txtTenNhaInB.Text = "0";
            // 
            // lblTenLoaiBangGiaB
            // 
            this.lblTenLoaiBangGiaB.AutoSize = true;
            this.lblTenLoaiBangGiaB.Location = new System.Drawing.Point(237, 110);
            this.lblTenLoaiBangGiaB.Name = "lblTenLoaiBangGiaB";
            this.lblTenLoaiBangGiaB.Size = new System.Drawing.Size(63, 13);
            this.lblTenLoaiBangGiaB.TabIndex = 119;
            this.lblTenLoaiBangGiaB.Text = "Tên loại BG";
            // 
            // txtDienGiaiNYGiaB
            // 
            this.txtDienGiaiNYGiaB.Location = new System.Drawing.Point(220, 126);
            this.txtDienGiaiNYGiaB.Multiline = true;
            this.txtDienGiaiNYGiaB.Name = "txtDienGiaiNYGiaB";
            this.txtDienGiaiNYGiaB.ReadOnly = true;
            this.txtDienGiaiNYGiaB.Size = new System.Drawing.Size(200, 76);
            this.txtDienGiaiNYGiaB.TabIndex = 120;
            this.txtDienGiaiNYGiaB.Text = "0";
            // 
            // lvwTrinhBayBangGiaB
            // 
            this.lvwTrinhBayBangGiaB.Location = new System.Drawing.Point(223, 217);
            this.lvwTrinhBayBangGiaB.Name = "lvwTrinhBayBangGiaB";
            this.lvwTrinhBayBangGiaB.Size = new System.Drawing.Size(197, 217);
            this.lvwTrinhBayBangGiaB.TabIndex = 121;
            this.lvwTrinhBayBangGiaB.UseCompatibleStateImageBehavior = false;
            this.lvwTrinhBayBangGiaB.View = System.Windows.Forms.View.Details;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(423, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 122;
            this.label9.Text = "Dãy số lượng A4";
            // 
            // lvwKetQua
            // 
            this.lvwKetQua.Location = new System.Drawing.Point(514, 126);
            this.lvwKetQua.Name = "lvwKetQua";
            this.lvwKetQua.Size = new System.Drawing.Size(227, 308);
            this.lvwKetQua.TabIndex = 123;
            this.lvwKetQua.UseCompatibleStateImageBehavior = false;
            this.lvwKetQua.View = System.Windows.Forms.View.Details;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(651, 440);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(90, 23);
            this.btnCopy.TabIndex = 125;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // SoSanhGiaInNhanhForm
            // 
            this.AcceptButton = this.btnTinh;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 491);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.lvwKetQua);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lvwTrinhBayBangGiaB);
            this.Controls.Add(this.txtDienGiaiNYGiaB);
            this.Controls.Add(this.lblTenLoaiBangGiaB);
            this.Controls.Add(this.txtTenNhaInB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTenNhaInA);
            this.Controls.Add(this.txtDienGiaiNYGiaA);
            this.Controls.Add(this.lblTenLoaiBangGiaA);
            this.Controls.Add(this.cboNiemYetGiaB);
            this.Controls.Add(this.txtDayTrangA4);
            this.Controls.Add(this.lvwTrinhBayBangGiaA);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnTinh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboNiemYetGiaA);
            this.Name = "SoSanhGiaInNhanhForm";
            this.Text = "TinhGiaInForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GiaInForm_FormClosing);
            this.Load += new System.EventHandler(this.GiaInForm_Load);
            this.Resize += new System.EventHandler(this.SoSanhGiaInNhanhForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboNiemYetGiaA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnTinh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.ListView lvwTrinhBayBangGiaA;
        private System.Windows.Forms.TextBox txtDayTrangA4;
        private System.Windows.Forms.ComboBox cboNiemYetGiaB;
        private System.Windows.Forms.Label lblTenLoaiBangGiaA;
        private System.Windows.Forms.TextBox txtDienGiaiNYGiaA;
        private System.Windows.Forms.TextBox txtTenNhaInA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTenNhaInB;
        private System.Windows.Forms.Label lblTenLoaiBangGiaB;
        private System.Windows.Forms.TextBox txtDienGiaiNYGiaB;
        private System.Windows.Forms.ListView lvwTrinhBayBangGiaB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListView lvwKetQua;
        private System.Windows.Forms.Button btnCopy;
    }
}