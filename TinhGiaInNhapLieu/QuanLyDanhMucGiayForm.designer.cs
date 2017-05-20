namespace TinhGiaInNhapLieu
{
    partial class QuanLyDanhMucGiayForm
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
            this.components = new System.ComponentModel.Container();
            this.lvwDanhMucGiay = new System.Windows.Forms.ListView();
            this.cmnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuThemDM = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuSuaDM = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuXoaDM = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbxNhaCungCap = new System.Windows.Forms.ListBox();
            this.lblThongTin = new System.Windows.Forms.Label();
            this.cmnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwDanhMucGiay
            // 
            this.lvwDanhMucGiay.ContextMenuStrip = this.cmnu;
            this.lvwDanhMucGiay.GridLines = true;
            this.lvwDanhMucGiay.Location = new System.Drawing.Point(138, 67);
            this.lvwDanhMucGiay.MultiSelect = false;
            this.lvwDanhMucGiay.Name = "lvwDanhMucGiay";
            this.lvwDanhMucGiay.Size = new System.Drawing.Size(274, 173);
            this.lvwDanhMucGiay.TabIndex = 0;
            this.lvwDanhMucGiay.UseCompatibleStateImageBehavior = false;
            this.lvwDanhMucGiay.View = System.Windows.Forms.View.Details;
            // 
            // cmnu
            // 
            this.cmnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuThemDM,
            this.cmnuSuaDM,
            this.cmnuXoaDM});
            this.cmnu.Name = "cmnu";
            this.cmnu.Size = new System.Drawing.Size(164, 92);
            // 
            // cmnuThemDM
            // 
            this.cmnuThemDM.Name = "cmnuThemDM";
            this.cmnuThemDM.Size = new System.Drawing.Size(163, 22);
            this.cmnuThemDM.Text = "Thêm Danh mục";
            this.cmnuThemDM.Click += new System.EventHandler(this.cmnuThemDM_Click);
            // 
            // cmnuSuaDM
            // 
            this.cmnuSuaDM.Name = "cmnuSuaDM";
            this.cmnuSuaDM.Size = new System.Drawing.Size(163, 22);
            this.cmnuSuaDM.Text = "Sửa Danh mục";
            this.cmnuSuaDM.Click += new System.EventHandler(this.cmnuSuaDM_Click);
            // 
            // cmnuXoaDM
            // 
            this.cmnuXoaDM.Name = "cmnuXoaDM";
            this.cmnuXoaDM.Size = new System.Drawing.Size(163, 22);
            this.cmnuXoaDM.Text = "Xóa Danh mục";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(177, 264);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "NCC và DANH MỤC GIẤY";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nhà cung cấp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Danh mục giấy theo NCC";
            // 
            // lbxNhaCungCap
            // 
            this.lbxNhaCungCap.FormattingEnabled = true;
            this.lbxNhaCungCap.Location = new System.Drawing.Point(12, 67);
            this.lbxNhaCungCap.Name = "lbxNhaCungCap";
            this.lbxNhaCungCap.Size = new System.Drawing.Size(120, 173);
            this.lbxNhaCungCap.TabIndex = 5;
            this.lbxNhaCungCap.SelectedIndexChanged += new System.EventHandler(this.lbxNhaCungCap_SelectedIndexChanged);
            // 
            // lblThongTin
            // 
            this.lblThongTin.AutoSize = true;
            this.lblThongTin.Location = new System.Drawing.Point(135, 243);
            this.lblThongTin.Name = "lblThongTin";
            this.lblThongTin.Size = new System.Drawing.Size(13, 13);
            this.lblThongTin.TabIndex = 9;
            this.lblThongTin.Text = "..";
            // 
            // QuanLyDanhMucGiayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 299);
            this.Controls.Add(this.lblThongTin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxNhaCungCap);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwDanhMucGiay);
            this.Name = "QuanLyDanhMucGiayForm";
            this.Text = "PaperCateManForm";
            this.Load += new System.EventHandler(this.PaperCateManForm_Load);
            this.cmnu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwDanhMucGiay;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbxNhaCungCap;
        private System.Windows.Forms.ContextMenuStrip cmnu;
        private System.Windows.Forms.ToolStripMenuItem cmnuThemDM;
        private System.Windows.Forms.ToolStripMenuItem cmnuSuaDM;
        private System.Windows.Forms.ToolStripMenuItem cmnuXoaDM;
        private System.Windows.Forms.Label lblThongTin;
    }
}