namespace TinhGiaInClient
{
    partial class ThanhPhamForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabCtrl01 = new System.Windows.Forms.TabControl();
            this.tabCanPhu = new System.Windows.Forms.TabPage();
            this.lblCanPhu_GiaTB = new System.Windows.Forms.Label();
            this.lblCanPhu_ThanhTien = new System.Windows.Forms.Label();
            this.lblCanPhu_DonViTinh = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoLuong_CanPhu = new System.Windows.Forms.TextBox();
            this.lbxCanPhu = new System.Windows.Forms.ListBox();
            this.tabCanGap = new System.Windows.Forms.TabPage();
            this.lbxCanGap = new System.Windows.Forms.ListBox();
            this.lblGiaTB_CanGap = new System.Windows.Forms.Label();
            this.lblThanhTien_CanGap = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSoLuong_CanGap = new System.Windows.Forms.TextBox();
            this.tabDongCuon = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSoLuong_DongCuon = new System.Windows.Forms.TextBox();
            this.lbxDongCuon = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.panel11.SuspendLayout();
            this.tabCtrl01.SuspendLayout();
            this.tabCanPhu.SuspendLayout();
            this.tabCanGap.SuspendLayout();
            this.tabDongCuon.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 34);
            this.panel1.TabIndex = 94;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÀNH PHẨM";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.btnOK);
            this.panel11.Controls.Add(this.btnCancel);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(0, 282);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(514, 34);
            this.panel11.TabIndex = 95;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(277, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "Nhận";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(163, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tabCtrl01
            // 
            this.tabCtrl01.Controls.Add(this.tabCanPhu);
            this.tabCtrl01.Controls.Add(this.tabCanGap);
            this.tabCtrl01.Controls.Add(this.tabDongCuon);
            this.tabCtrl01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrl01.Location = new System.Drawing.Point(0, 34);
            this.tabCtrl01.Name = "tabCtrl01";
            this.tabCtrl01.SelectedIndex = 0;
            this.tabCtrl01.Size = new System.Drawing.Size(514, 248);
            this.tabCtrl01.TabIndex = 96;
            // 
            // tabCanPhu
            // 
            this.tabCanPhu.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabCanPhu.Controls.Add(this.lblCanPhu_GiaTB);
            this.tabCanPhu.Controls.Add(this.lblCanPhu_ThanhTien);
            this.tabCanPhu.Controls.Add(this.lblCanPhu_DonViTinh);
            this.tabCanPhu.Controls.Add(this.label2);
            this.tabCanPhu.Controls.Add(this.txtSoLuong_CanPhu);
            this.tabCanPhu.Controls.Add(this.lbxCanPhu);
            this.tabCanPhu.Location = new System.Drawing.Point(4, 22);
            this.tabCanPhu.Name = "tabCanPhu";
            this.tabCanPhu.Size = new System.Drawing.Size(506, 222);
            this.tabCanPhu.TabIndex = 4;
            this.tabCanPhu.Text = "Cán phủ";
            // 
            // lblCanPhu_GiaTB
            // 
            this.lblCanPhu_GiaTB.AutoSize = true;
            this.lblCanPhu_GiaTB.Location = new System.Drawing.Point(158, 92);
            this.lblCanPhu_GiaTB.Name = "lblCanPhu_GiaTB";
            this.lblCanPhu_GiaTB.Size = new System.Drawing.Size(60, 13);
            this.lblCanPhu_GiaTB.TabIndex = 5;
            this.lblCanPhu_GiaTB.Text = "Giá TB/ĐV";
            // 
            // lblCanPhu_ThanhTien
            // 
            this.lblCanPhu_ThanhTien.AutoSize = true;
            this.lblCanPhu_ThanhTien.Location = new System.Drawing.Point(158, 65);
            this.lblCanPhu_ThanhTien.Name = "lblCanPhu_ThanhTien";
            this.lblCanPhu_ThanhTien.Size = new System.Drawing.Size(58, 13);
            this.lblCanPhu_ThanhTien.TabIndex = 4;
            this.lblCanPhu_ThanhTien.Text = "Thành tiền";
            // 
            // lblCanPhu_DonViTinh
            // 
            this.lblCanPhu_DonViTinh.AutoSize = true;
            this.lblCanPhu_DonViTinh.Location = new System.Drawing.Point(272, 34);
            this.lblCanPhu_DonViTinh.Name = "lblCanPhu_DonViTinh";
            this.lblCanPhu_DonViTinh.Size = new System.Drawing.Size(29, 13);
            this.lblCanPhu_DonViTinh.TabIndex = 3;
            this.lblCanPhu_DonViTinh.Text = "DVT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nhập số lượng";
            // 
            // txtSoLuong_CanPhu
            // 
            this.txtSoLuong_CanPhu.Location = new System.Drawing.Point(159, 31);
            this.txtSoLuong_CanPhu.Name = "txtSoLuong_CanPhu";
            this.txtSoLuong_CanPhu.Size = new System.Drawing.Size(100, 20);
            this.txtSoLuong_CanPhu.TabIndex = 1;
            this.txtSoLuong_CanPhu.TextChanged += new System.EventHandler(this.txtSoLuong_CanPhu_TextChanged);
            // 
            // lbxCanPhu
            // 
            this.lbxCanPhu.FormattingEnabled = true;
            this.lbxCanPhu.Location = new System.Drawing.Point(8, 15);
            this.lbxCanPhu.Name = "lbxCanPhu";
            this.lbxCanPhu.Size = new System.Drawing.Size(120, 186);
            this.lbxCanPhu.TabIndex = 0;
            // 
            // tabCanGap
            // 
            this.tabCanGap.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabCanGap.Controls.Add(this.lbxCanGap);
            this.tabCanGap.Controls.Add(this.lblGiaTB_CanGap);
            this.tabCanGap.Controls.Add(this.lblThanhTien_CanGap);
            this.tabCanGap.Controls.Add(this.label9);
            this.tabCanGap.Controls.Add(this.label10);
            this.tabCanGap.Controls.Add(this.txtSoLuong_CanGap);
            this.tabCanGap.Location = new System.Drawing.Point(4, 22);
            this.tabCanGap.Name = "tabCanGap";
            this.tabCanGap.Padding = new System.Windows.Forms.Padding(3);
            this.tabCanGap.Size = new System.Drawing.Size(506, 222);
            this.tabCanGap.TabIndex = 3;
            this.tabCanGap.Text = "Cấn gấp";
            // 
            // lbxCanGap
            // 
            this.lbxCanGap.FormattingEnabled = true;
            this.lbxCanGap.Location = new System.Drawing.Point(8, 24);
            this.lbxCanGap.Name = "lbxCanGap";
            this.lbxCanGap.Size = new System.Drawing.Size(120, 186);
            this.lbxCanGap.TabIndex = 17;
            // 
            // lblGiaTB_CanGap
            // 
            this.lblGiaTB_CanGap.AutoSize = true;
            this.lblGiaTB_CanGap.Location = new System.Drawing.Point(157, 101);
            this.lblGiaTB_CanGap.Name = "lblGiaTB_CanGap";
            this.lblGiaTB_CanGap.Size = new System.Drawing.Size(60, 13);
            this.lblGiaTB_CanGap.TabIndex = 16;
            this.lblGiaTB_CanGap.Text = "Giá TB/ĐV";
            // 
            // lblThanhTien_CanGap
            // 
            this.lblThanhTien_CanGap.AutoSize = true;
            this.lblThanhTien_CanGap.Location = new System.Drawing.Point(157, 74);
            this.lblThanhTien_CanGap.Name = "lblThanhTien_CanGap";
            this.lblThanhTien_CanGap.Size = new System.Drawing.Size(58, 13);
            this.lblThanhTien_CanGap.TabIndex = 15;
            this.lblThanhTien_CanGap.Text = "Thành tiền";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(271, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "DVT";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(155, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Nhập số lượng";
            // 
            // txtSoLuong_CanGap
            // 
            this.txtSoLuong_CanGap.Location = new System.Drawing.Point(158, 40);
            this.txtSoLuong_CanGap.Name = "txtSoLuong_CanGap";
            this.txtSoLuong_CanGap.Size = new System.Drawing.Size(100, 20);
            this.txtSoLuong_CanGap.TabIndex = 12;
            // 
            // tabDongCuon
            // 
            this.tabDongCuon.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabDongCuon.Controls.Add(this.label3);
            this.tabDongCuon.Controls.Add(this.label4);
            this.tabDongCuon.Controls.Add(this.label5);
            this.tabDongCuon.Controls.Add(this.label6);
            this.tabDongCuon.Controls.Add(this.txtSoLuong_DongCuon);
            this.tabDongCuon.Controls.Add(this.lbxDongCuon);
            this.tabDongCuon.Location = new System.Drawing.Point(4, 22);
            this.tabDongCuon.Name = "tabDongCuon";
            this.tabDongCuon.Size = new System.Drawing.Size(506, 222);
            this.tabDongCuon.TabIndex = 5;
            this.tabDongCuon.Text = "Đóng cuốn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Giá TB/ĐV";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Thành tiền";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(272, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "DVT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(156, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Nhập số lượng";
            // 
            // txtSoLuong_DongCuon
            // 
            this.txtSoLuong_DongCuon.Location = new System.Drawing.Point(159, 32);
            this.txtSoLuong_DongCuon.Name = "txtSoLuong_DongCuon";
            this.txtSoLuong_DongCuon.Size = new System.Drawing.Size(100, 20);
            this.txtSoLuong_DongCuon.TabIndex = 7;
            // 
            // lbxDongCuon
            // 
            this.lbxDongCuon.FormattingEnabled = true;
            this.lbxDongCuon.Location = new System.Drawing.Point(8, 16);
            this.lbxDongCuon.Name = "lbxDongCuon";
            this.lbxDongCuon.Size = new System.Drawing.Size(120, 186);
            this.lbxDongCuon.TabIndex = 6;
            // 
            // ThanhPhamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 316);
            this.Controls.Add(this.tabCtrl01);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel1);
            this.Name = "ThanhPhamForm";
            this.Text = "ThanhPhamForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.tabCtrl01.ResumeLayout(false);
            this.tabCanPhu.ResumeLayout(false);
            this.tabCanPhu.PerformLayout();
            this.tabCanGap.ResumeLayout(false);
            this.tabCanGap.PerformLayout();
            this.tabDongCuon.ResumeLayout(false);
            this.tabDongCuon.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TabControl tabCtrl01;
        private System.Windows.Forms.TabPage tabCanPhu;
        private System.Windows.Forms.TabPage tabCanGap;
        private System.Windows.Forms.TabPage tabDongCuon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCanPhu_GiaTB;
        private System.Windows.Forms.Label lblCanPhu_ThanhTien;
        private System.Windows.Forms.Label lblCanPhu_DonViTinh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoLuong_CanPhu;
        private System.Windows.Forms.ListBox lbxCanPhu;
        private System.Windows.Forms.Label lblGiaTB_CanGap;
        private System.Windows.Forms.Label lblThanhTien_CanGap;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSoLuong_CanGap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSoLuong_DongCuon;
        private System.Windows.Forms.ListBox lbxDongCuon;
        private System.Windows.Forms.ListBox lbxCanGap;
    }
}