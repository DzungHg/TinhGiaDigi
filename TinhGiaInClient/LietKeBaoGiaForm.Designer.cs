namespace TinhGiaInClient
{
    partial class LietKeTinhGiaForm
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
            this.pnlBottomMain = new System.Windows.Forms.Panel();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlHeaderNoiDung = new System.Windows.Forms.Panel();
            this.lblTieuDeNoiDung = new System.Windows.Forms.Label();
            this.grbSapXep = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSapXepTheo = new System.Windows.Forms.ComboBox();
            this.rdbXuoi = new System.Windows.Forms.RadioButton();
            this.rdbNguoc = new System.Windows.Forms.RadioButton();
            this.splitCont = new System.Windows.Forms.SplitContainer();
            this.lvwTinhGia = new System.Windows.Forms.ListView();
            this.pnlHeaderDanhSachTinhGia = new System.Windows.Forms.Panel();
            this.btnCopyTinhGia = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtNoiDungTinhGia = new System.Windows.Forms.TextBox();
            this.pnlBottomMain.SuspendLayout();
            this.pnlHeaderNoiDung.SuspendLayout();
            this.grbSapXep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCont)).BeginInit();
            this.splitCont.Panel1.SuspendLayout();
            this.splitCont.Panel2.SuspendLayout();
            this.splitCont.SuspendLayout();
            this.pnlHeaderDanhSachTinhGia.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottomMain
            // 
            this.pnlBottomMain.Controls.Add(this.btnDong);
            this.pnlBottomMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomMain.Location = new System.Drawing.Point(0, 432);
            this.pnlBottomMain.Name = "pnlBottomMain";
            this.pnlBottomMain.Size = new System.Drawing.Size(746, 38);
            this.pnlBottomMain.TabIndex = 3;
            // 
            // btnDong
            // 
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Location = new System.Drawing.Point(311, 7);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // pnlHeaderNoiDung
            // 
            this.pnlHeaderNoiDung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeaderNoiDung.Controls.Add(this.lblTieuDeNoiDung);
            this.pnlHeaderNoiDung.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderNoiDung.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderNoiDung.Name = "pnlHeaderNoiDung";
            this.pnlHeaderNoiDung.Size = new System.Drawing.Size(194, 33);
            this.pnlHeaderNoiDung.TabIndex = 4;
            // 
            // lblTieuDeNoiDung
            // 
            this.lblTieuDeNoiDung.AutoSize = true;
            this.lblTieuDeNoiDung.Location = new System.Drawing.Point(49, 9);
            this.lblTieuDeNoiDung.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTieuDeNoiDung.Name = "lblTieuDeNoiDung";
            this.lblTieuDeNoiDung.Size = new System.Drawing.Size(89, 13);
            this.lblTieuDeNoiDung.TabIndex = 0;
            this.lblTieuDeNoiDung.Text = "Nội dung tính giá";
            // 
            // grbSapXep
            // 
            this.grbSapXep.Controls.Add(this.label1);
            this.grbSapXep.Controls.Add(this.cboSapXepTheo);
            this.grbSapXep.Controls.Add(this.rdbXuoi);
            this.grbSapXep.Controls.Add(this.rdbNguoc);
            this.grbSapXep.Location = new System.Drawing.Point(3, 3);
            this.grbSapXep.Name = "grbSapXep";
            this.grbSapXep.Size = new System.Drawing.Size(300, 53);
            this.grbSapXep.TabIndex = 3;
            this.grbSapXep.TabStop = false;
            this.grbSapXep.Text = "Sắp xếp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Theo";
            // 
            // cboSapXepTheo
            // 
            this.cboSapXepTheo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSapXepTheo.DropDownWidth = 112;
            this.cboSapXepTheo.FormattingEnabled = true;
            this.cboSapXepTheo.Items.AddRange(new object[] {
            "Không",
            "Ngày",
            "Nhân viên",
            "Tiêu đề"});
            this.cboSapXepTheo.Location = new System.Drawing.Point(50, 19);
            this.cboSapXepTheo.Margin = new System.Windows.Forms.Padding(2);
            this.cboSapXepTheo.Name = "cboSapXepTheo";
            this.cboSapXepTheo.Size = new System.Drawing.Size(111, 21);
            this.cboSapXepTheo.TabIndex = 5;
            // 
            // rdbXuoi
            // 
            this.rdbXuoi.AutoSize = true;
            this.rdbXuoi.Checked = true;
            this.rdbXuoi.Location = new System.Drawing.Point(175, 20);
            this.rdbXuoi.Name = "rdbXuoi";
            this.rdbXuoi.Size = new System.Drawing.Size(46, 17);
            this.rdbXuoi.TabIndex = 3;
            this.rdbXuoi.TabStop = true;
            this.rdbXuoi.Text = "Xuôi";
            this.rdbXuoi.UseVisualStyleBackColor = true;
            // 
            // rdbNguoc
            // 
            this.rdbNguoc.AutoSize = true;
            this.rdbNguoc.Location = new System.Drawing.Point(238, 20);
            this.rdbNguoc.Name = "rdbNguoc";
            this.rdbNguoc.Size = new System.Drawing.Size(57, 17);
            this.rdbNguoc.TabIndex = 0;
            this.rdbNguoc.Text = "Ngược";
            this.rdbNguoc.UseVisualStyleBackColor = true;
            // 
            // splitCont
            // 
            this.splitCont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCont.Location = new System.Drawing.Point(0, 0);
            this.splitCont.Margin = new System.Windows.Forms.Padding(2);
            this.splitCont.Name = "splitCont";
            // 
            // splitCont.Panel1
            // 
            this.splitCont.Panel1.Controls.Add(this.lvwTinhGia);
            this.splitCont.Panel1.Controls.Add(this.pnlHeaderDanhSachTinhGia);
            // 
            // splitCont.Panel2
            // 
            this.splitCont.Panel2.Controls.Add(this.txtNoiDungTinhGia);
            this.splitCont.Panel2.Controls.Add(this.pnlHeaderNoiDung);
            this.splitCont.Size = new System.Drawing.Size(746, 432);
            this.splitCont.SplitterDistance = 550;
            this.splitCont.SplitterWidth = 2;
            this.splitCont.TabIndex = 6;
            // 
            // lvwTinhGia
            // 
            this.lvwTinhGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwTinhGia.GridLines = true;
            this.lvwTinhGia.Location = new System.Drawing.Point(0, 66);
            this.lvwTinhGia.MultiSelect = false;
            this.lvwTinhGia.Name = "lvwTinhGia";
            this.lvwTinhGia.Size = new System.Drawing.Size(550, 366);
            this.lvwTinhGia.TabIndex = 8;
            this.lvwTinhGia.UseCompatibleStateImageBehavior = false;
            this.lvwTinhGia.View = System.Windows.Forms.View.Details;
            this.lvwTinhGia.SelectedIndexChanged += new System.EventHandler(this.lvwTinhGia_SelectedIndexChanged);
            // 
            // pnlHeaderDanhSachTinhGia
            // 
            this.pnlHeaderDanhSachTinhGia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeaderDanhSachTinhGia.Controls.Add(this.btnCopyTinhGia);
            this.pnlHeaderDanhSachTinhGia.Controls.Add(this.btnRefresh);
            this.pnlHeaderDanhSachTinhGia.Controls.Add(this.grbSapXep);
            this.pnlHeaderDanhSachTinhGia.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderDanhSachTinhGia.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderDanhSachTinhGia.Name = "pnlHeaderDanhSachTinhGia";
            this.pnlHeaderDanhSachTinhGia.Size = new System.Drawing.Size(550, 66);
            this.pnlHeaderDanhSachTinhGia.TabIndex = 7;
            // 
            // btnCopyTinhGia
            // 
            this.btnCopyTinhGia.Location = new System.Drawing.Point(421, 23);
            this.btnCopyTinhGia.Name = "btnCopyTinhGia";
            this.btnCopyTinhGia.Size = new System.Drawing.Size(93, 23);
            this.btnCopyTinhGia.TabIndex = 5;
            this.btnCopyTinhGia.Text = "Copy Tính giá";
            this.btnCopyTinhGia.UseVisualStyleBackColor = true;
            this.btnCopyTinhGia.Click += new System.EventHandler(this.btnCopyTinhGia_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(322, 23);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(93, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refesh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnThemTinhGia_Click);
            // 
            // txtNoiDungTinhGia
            // 
            this.txtNoiDungTinhGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNoiDungTinhGia.Location = new System.Drawing.Point(0, 33);
            this.txtNoiDungTinhGia.Margin = new System.Windows.Forms.Padding(2);
            this.txtNoiDungTinhGia.Multiline = true;
            this.txtNoiDungTinhGia.Name = "txtNoiDungTinhGia";
            this.txtNoiDungTinhGia.ReadOnly = true;
            this.txtNoiDungTinhGia.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNoiDungTinhGia.Size = new System.Drawing.Size(194, 399);
            this.txtNoiDungTinhGia.TabIndex = 5;
            // 
            // LietKeTinhGiaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 470);
            this.Controls.Add(this.splitCont);
            this.Controls.Add(this.pnlBottomMain);
            this.Name = "LietKeTinhGiaForm";
            this.Text = "Danh sách Tính giá";
            this.Load += new System.EventHandler(this.LietKeTinhGiaForm_Load);
            this.Resize += new System.EventHandler(this.LietKeTinhGiaForm_Resize);
            this.pnlBottomMain.ResumeLayout(false);
            this.pnlHeaderNoiDung.ResumeLayout(false);
            this.pnlHeaderNoiDung.PerformLayout();
            this.grbSapXep.ResumeLayout(false);
            this.grbSapXep.PerformLayout();
            this.splitCont.Panel1.ResumeLayout(false);
            this.splitCont.Panel2.ResumeLayout(false);
            this.splitCont.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCont)).EndInit();
            this.splitCont.ResumeLayout(false);
            this.pnlHeaderDanhSachTinhGia.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottomMain;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Panel pnlHeaderNoiDung;
        private System.Windows.Forms.GroupBox grbSapXep;
        private System.Windows.Forms.RadioButton rdbNguoc;
        private System.Windows.Forms.RadioButton rdbXuoi;
        private System.Windows.Forms.Label lblTieuDeNoiDung;
        private System.Windows.Forms.SplitContainer splitCont;
        private System.Windows.Forms.TextBox txtNoiDungTinhGia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSapXepTheo;
        private System.Windows.Forms.Panel pnlHeaderDanhSachTinhGia;
        private System.Windows.Forms.ListView lvwTinhGia;
        private System.Windows.Forms.Button btnCopyTinhGia;
        private System.Windows.Forms.Button btnRefresh;
    }
}