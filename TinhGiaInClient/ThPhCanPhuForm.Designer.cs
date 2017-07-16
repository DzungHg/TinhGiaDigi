namespace TinhGiaInClient
{
    partial class ThPhCanPhuForm
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblGiaTB = new System.Windows.Forms.Label();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.lblCanPhu_DonViTinh = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.lbxCanPhu = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDonViTinh = new System.Windows.Forms.TextBox();
            this.txtThongTinBoSung = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbHaiMat = new System.Windows.Forms.RadioButton();
            this.rdbMotMat = new System.Windows.Forms.RadioButton();
            this.lblSoMatCan = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(200, 233);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "Nhận";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(86, 233);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblGiaTB
            // 
            this.lblGiaTB.AutoSize = true;
            this.lblGiaTB.Location = new System.Drawing.Point(295, 199);
            this.lblGiaTB.Name = "lblGiaTB";
            this.lblGiaTB.Size = new System.Drawing.Size(60, 13);
            this.lblGiaTB.TabIndex = 101;
            this.lblGiaTB.Text = "Giá TB/ĐV";
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Location = new System.Drawing.Point(197, 199);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(58, 13);
            this.lblThanhTien.TabIndex = 100;
            this.lblThanhTien.Text = "Thành tiền";
            // 
            // lblCanPhu_DonViTinh
            // 
            this.lblCanPhu_DonViTinh.AutoSize = true;
            this.lblCanPhu_DonViTinh.Location = new System.Drawing.Point(182, 175);
            this.lblCanPhu_DonViTinh.Name = "lblCanPhu_DonViTinh";
            this.lblCanPhu_DonViTinh.Size = new System.Drawing.Size(60, 13);
            this.lblCanPhu_DonViTinh.TabIndex = 99;
            this.lblCanPhu_DonViTinh.Text = "Đơn vị tính";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 98;
            this.label2.Text = "Số tờ chạy";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(248, 146);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(59, 20);
            this.txtSoLuong.TabIndex = 3;
            // 
            // lbxCanPhu
            // 
            this.lbxCanPhu.FormattingEnabled = true;
            this.lbxCanPhu.Location = new System.Drawing.Point(12, 53);
            this.lbxCanPhu.Name = "lbxCanPhu";
            this.lbxCanPhu.Size = new System.Drawing.Size(145, 147);
            this.lbxCanPhu.TabIndex = 0;
            this.lbxCanPhu.SelectedIndexChanged += new System.EventHandler(this.ListBoxes_SelectedIndex_Changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 102;
            this.label1.Text = "CÁN PHỦ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 103;
            this.label3.Text = "Danh sách ";
            // 
            // txtDonViTinh
            // 
            this.txtDonViTinh.Location = new System.Drawing.Point(248, 172);
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.ReadOnly = true;
            this.txtDonViTinh.Size = new System.Drawing.Size(34, 20);
            this.txtDonViTinh.TabIndex = 4;
            // 
            // txtThongTinBoSung
            // 
            this.txtThongTinBoSung.Location = new System.Drawing.Point(168, 53);
            this.txtThongTinBoSung.Multiline = true;
            this.txtThongTinBoSung.Name = "txtThongTinBoSung";
            this.txtThongTinBoSung.ReadOnly = true;
            this.txtThongTinBoSung.Size = new System.Drawing.Size(204, 37);
            this.txtThongTinBoSung.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbHaiMat);
            this.groupBox1.Controls.Add(this.rdbMotMat);
            this.groupBox1.Location = new System.Drawing.Point(168, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 44);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cán";
            // 
            // rdbHaiMat
            // 
            this.rdbHaiMat.AutoSize = true;
            this.rdbHaiMat.Location = new System.Drawing.Point(102, 19);
            this.rdbHaiMat.Name = "rdbHaiMat";
            this.rdbHaiMat.Size = new System.Drawing.Size(51, 17);
            this.rdbHaiMat.TabIndex = 1;
            this.rdbHaiMat.TabStop = true;
            this.rdbHaiMat.Text = "2 mặt";
            this.rdbHaiMat.UseVisualStyleBackColor = true;
            // 
            // rdbMotMat
            // 
            this.rdbMotMat.AutoSize = true;
            this.rdbMotMat.Location = new System.Drawing.Point(23, 19);
            this.rdbMotMat.Name = "rdbMotMat";
            this.rdbMotMat.Size = new System.Drawing.Size(51, 17);
            this.rdbMotMat.TabIndex = 0;
            this.rdbMotMat.TabStop = true;
            this.rdbMotMat.Text = "1 mặt";
            this.rdbMotMat.UseVisualStyleBackColor = true;
            // 
            // lblSoMatCan
            // 
            this.lblSoMatCan.AutoSize = true;
            this.lblSoMatCan.Location = new System.Drawing.Point(295, 175);
            this.lblSoMatCan.Name = "lblSoMatCan";
            this.lblSoMatCan.Size = new System.Drawing.Size(24, 13);
            this.lblSoMatCan.TabIndex = 104;
            this.lblSoMatCan.Text = "mặt";
            // 
            // ThPhCanPhuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 270);
            this.Controls.Add(this.lblSoMatCan);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtThongTinBoSung);
            this.Controls.Add(this.lblCanPhu_DonViTinh);
            this.Controls.Add(this.txtDonViTinh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblGiaTB);
            this.Controls.Add(this.lblThanhTien);
            this.Controls.Add(this.lbxCanPhu);
            this.Name = "ThPhCanPhuForm";
            this.Text = "Cán Phủ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThPhCanPhuForm_FormClosing);
            this.Load += new System.EventHandler(this.ThanhPhamForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblGiaTB;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.Label lblCanPhu_DonViTinh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.ListBox lbxCanPhu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDonViTinh;
        private System.Windows.Forms.TextBox txtThongTinBoSung;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbHaiMat;
        private System.Windows.Forms.RadioButton rdbMotMat;
        private System.Windows.Forms.Label lblSoMatCan;
    }
}