namespace TinhGiaInClient
{
    partial class BangGiaGiayForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDienGiaiHangKH = new System.Windows.Forms.TextBox();
            this.cboHangKhachHang = new System.Windows.Forms.ComboBox();
            this.lblTieuDeForm = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.splitCont2 = new System.Windows.Forms.SplitContainer();
            this.lbxDanhMucGiay = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cboNhaCC = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvwGiay = new System.Windows.Forms.ListView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCont2)).BeginInit();
            this.splitCont2.Panel1.SuspendLayout();
            this.splitCont2.Panel2.SuspendLayout();
            this.splitCont2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtDienGiaiHangKH);
            this.panel1.Controls.Add(this.cboHangKhachHang);
            this.panel1.Controls.Add(this.lblTieuDeForm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(641, 50);
            this.panel1.TabIndex = 0;
            // 
            // txtDienGiaiHangKH
            // 
            this.txtDienGiaiHangKH.Location = new System.Drawing.Point(242, 3);
            this.txtDienGiaiHangKH.Multiline = true;
            this.txtDienGiaiHangKH.Name = "txtDienGiaiHangKH";
            this.txtDienGiaiHangKH.ReadOnly = true;
            this.txtDienGiaiHangKH.Size = new System.Drawing.Size(205, 40);
            this.txtDienGiaiHangKH.TabIndex = 6;
            // 
            // cboHangKhachHang
            // 
            this.cboHangKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHangKhachHang.FormattingEnabled = true;
            this.cboHangKhachHang.Location = new System.Drawing.Point(85, 16);
            this.cboHangKhachHang.Name = "cboHangKhachHang";
            this.cboHangKhachHang.Size = new System.Drawing.Size(135, 21);
            this.cboHangKhachHang.TabIndex = 5;
            this.cboHangKhachHang.SelectedIndexChanged += new System.EventHandler(this.cboHangKhachHang_SelectedIndexChanged);
            // 
            // lblTieuDeForm
            // 
            this.lblTieuDeForm.AutoSize = true;
            this.lblTieuDeForm.Location = new System.Drawing.Point(9, 19);
            this.lblTieuDeForm.Name = "lblTieuDeForm";
            this.lblTieuDeForm.Size = new System.Drawing.Size(54, 13);
            this.lblTieuDeForm.TabIndex = 1;
            this.lblTieuDeForm.Text = "Hạng KH:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnNhan);
            this.panel2.Controls.Add(this.btnHuy);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 404);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(641, 40);
            this.panel2.TabIndex = 1;
            // 
            // btnNhan
            // 
            this.btnNhan.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNhan.Location = new System.Drawing.Point(381, 5);
            this.btnNhan.Name = "btnNhan";
            this.btnNhan.Size = new System.Drawing.Size(75, 23);
            this.btnNhan.TabIndex = 1;
            this.btnNhan.Text = "Nhận";
            this.btnNhan.UseVisualStyleBackColor = true;
            this.btnNhan.Click += new System.EventHandler(this.btnNhan_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Location = new System.Drawing.Point(76, 5);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 0;
            this.btnHuy.Text = "Đóng";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // splitCont2
            // 
            this.splitCont2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCont2.Location = new System.Drawing.Point(0, 50);
            this.splitCont2.Name = "splitCont2";
            // 
            // splitCont2.Panel1
            // 
            this.splitCont2.Panel1.Controls.Add(this.lbxDanhMucGiay);
            this.splitCont2.Panel1.Controls.Add(this.panel3);
            // 
            // splitCont2.Panel2
            // 
            this.splitCont2.Panel2.Controls.Add(this.lvwGiay);
            this.splitCont2.Panel2.Controls.Add(this.panel4);
            this.splitCont2.Size = new System.Drawing.Size(641, 354);
            this.splitCont2.SplitterDistance = 209;
            this.splitCont2.TabIndex = 2;
            // 
            // lbxDanhMucGiay
            // 
            this.lbxDanhMucGiay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxDanhMucGiay.FormattingEnabled = true;
            this.lbxDanhMucGiay.Location = new System.Drawing.Point(0, 39);
            this.lbxDanhMucGiay.Name = "lbxDanhMucGiay";
            this.lbxDanhMucGiay.Size = new System.Drawing.Size(209, 315);
            this.lbxDanhMucGiay.TabIndex = 1;
            this.lbxDanhMucGiay.SelectedIndexChanged += new System.EventHandler(this.lbxDanhMucGiay_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cboNhaCC);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(209, 39);
            this.panel3.TabIndex = 0;
            // 
            // cboNhaCC
            // 
            this.cboNhaCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhaCC.FormattingEnabled = true;
            this.cboNhaCC.Location = new System.Drawing.Point(62, 8);
            this.cboNhaCC.Name = "cboNhaCC";
            this.cboNhaCC.Size = new System.Drawing.Size(135, 21);
            this.cboNhaCC.TabIndex = 1;
            this.cboNhaCC.SelectedIndexChanged += new System.EventHandler(this.cboNhaCC_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhà CC:";
            // 
            // lvwGiay
            // 
            this.lvwGiay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwGiay.Location = new System.Drawing.Point(0, 39);
            this.lvwGiay.Name = "lvwGiay";
            this.lvwGiay.Size = new System.Drawing.Size(428, 315);
            this.lvwGiay.TabIndex = 2;
            this.lvwGiay.UseCompatibleStateImageBehavior = false;
            this.lvwGiay.SelectedIndexChanged += new System.EventHandler(this.lvwGiay_SelectedIndexChanged_1);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(428, 39);
            this.panel4.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giấy theo Danh mục và giá bán theo Hạng  KH";
            // 
            // BangGiaGiayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 444);
            this.Controls.Add(this.splitCont2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "BangGiaGiayForm";
            this.Text = "Bảng giá Giấy";
            this.Load += new System.EventHandler(this.ChuanBiGiayForm_Load);
            this.Resize += new System.EventHandler(this.BangGiaGiayForm_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitCont2.Panel1.ResumeLayout(false);
            this.splitCont2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitCont2)).EndInit();
            this.splitCont2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTieuDeForm;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.SplitContainer splitCont2;
        private System.Windows.Forms.ListBox lbxDanhMucGiay;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cboNhaCC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvwGiay;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboHangKhachHang;
        private System.Windows.Forms.TextBox txtDienGiaiHangKH;
        private System.Windows.Forms.Button btnNhan;

    }
}