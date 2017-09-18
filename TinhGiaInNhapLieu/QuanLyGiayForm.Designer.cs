namespace TinhGiaInNhapLieu
{
    partial class QuanLyGiayForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTieuDeForm = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.splitCont2 = new System.Windows.Forms.SplitContainer();
            this.lbxDanhMucGiay = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnQuanLyDanhMuc = new System.Windows.Forms.Button();
            this.cboNhaCC = new System.Windows.Forms.ComboBox();
            this.lvwGiay = new System.Windows.Forms.ListView();
            this.cmu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmuThemGiay = new System.Windows.Forms.ToolStripMenuItem();
            this.cmuSuaGiay = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmuXoaGiay = new System.Windows.Forms.ToolStripMenuItem();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmuNhanDoiGiay = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCont2)).BeginInit();
            this.splitCont2.Panel1.SuspendLayout();
            this.splitCont2.Panel2.SuspendLayout();
            this.splitCont2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.cmu.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblTieuDeForm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(641, 31);
            this.panel1.TabIndex = 0;
            // 
            // lblTieuDeForm
            // 
            this.lblTieuDeForm.AutoSize = true;
            this.lblTieuDeForm.Location = new System.Drawing.Point(271, 8);
            this.lblTieuDeForm.Name = "lblTieuDeForm";
            this.lblTieuDeForm.Size = new System.Drawing.Size(86, 13);
            this.lblTieuDeForm.TabIndex = 1;
            this.lblTieuDeForm.Text = "CHUẨN BỊ GIẤY";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnNhan);
            this.panel2.Controls.Add(this.btnHuy);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 340);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(641, 38);
            this.panel2.TabIndex = 1;
            // 
            // btnNhan
            // 
            this.btnNhan.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNhan.Location = new System.Drawing.Point(360, 5);
            this.btnNhan.Name = "btnNhan";
            this.btnNhan.Size = new System.Drawing.Size(75, 23);
            this.btnNhan.TabIndex = 1;
            this.btnNhan.Text = "Nhận";
            this.btnNhan.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Location = new System.Drawing.Point(75, 5);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 0;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // splitCont2
            // 
            this.splitCont2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCont2.Location = new System.Drawing.Point(0, 31);
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
            this.splitCont2.Size = new System.Drawing.Size(641, 309);
            this.splitCont2.SplitterDistance = 209;
            this.splitCont2.TabIndex = 2;
            // 
            // lbxDanhMucGiay
            // 
            this.lbxDanhMucGiay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxDanhMucGiay.FormattingEnabled = true;
            this.lbxDanhMucGiay.Location = new System.Drawing.Point(0, 39);
            this.lbxDanhMucGiay.Name = "lbxDanhMucGiay";
            this.lbxDanhMucGiay.Size = new System.Drawing.Size(209, 270);
            this.lbxDanhMucGiay.TabIndex = 1;
            this.lbxDanhMucGiay.SelectedIndexChanged += new System.EventHandler(this.lbxDanhMucGiay_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnQuanLyDanhMuc);
            this.panel3.Controls.Add(this.cboNhaCC);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(209, 39);
            this.panel3.TabIndex = 0;
            // 
            // btnQuanLyDanhMuc
            // 
            this.btnQuanLyDanhMuc.Location = new System.Drawing.Point(3, 8);
            this.btnQuanLyDanhMuc.Name = "btnQuanLyDanhMuc";
            this.btnQuanLyDanhMuc.Size = new System.Drawing.Size(53, 23);
            this.btnQuanLyDanhMuc.TabIndex = 3;
            this.btnQuanLyDanhMuc.Text = "NCC...";
            this.btnQuanLyDanhMuc.UseVisualStyleBackColor = true;
            this.btnQuanLyDanhMuc.Click += new System.EventHandler(this.btnQuanLyDanhMuc_Click);
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
            // lvwGiay
            // 
            this.lvwGiay.ContextMenuStrip = this.cmu;
            this.lvwGiay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwGiay.Location = new System.Drawing.Point(0, 39);
            this.lvwGiay.Name = "lvwGiay";
            this.lvwGiay.Size = new System.Drawing.Size(428, 270);
            this.lvwGiay.TabIndex = 2;
            this.lvwGiay.UseCompatibleStateImageBehavior = false;
            this.lvwGiay.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwGiay_MouseDoubleClick);
            // 
            // cmu
            // 
            this.cmu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmuThemGiay,
            this.cmuSuaGiay,
            this.toolStripMenuItem1,
            this.cmuNhanDoiGiay,
            this.toolStripMenuItem2,
            this.cmuXoaGiay});
            this.cmu.Name = "cmu";
            this.cmu.Size = new System.Drawing.Size(153, 126);
            this.cmu.Opening += new System.ComponentModel.CancelEventHandler(this.cmu_Opening);
            // 
            // cmuThemGiay
            // 
            this.cmuThemGiay.Name = "cmuThemGiay";
            this.cmuThemGiay.Size = new System.Drawing.Size(152, 22);
            this.cmuThemGiay.Text = "Thêm Giấy";
            this.cmuThemGiay.Click += new System.EventHandler(this.cmuThemGiay_Click);
            // 
            // cmuSuaGiay
            // 
            this.cmuSuaGiay.Name = "cmuSuaGiay";
            this.cmuSuaGiay.Size = new System.Drawing.Size(152, 22);
            this.cmuSuaGiay.Text = "Sửa Giấy";
            this.cmuSuaGiay.Click += new System.EventHandler(this.cmuSuaGiay_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // cmuXoaGiay
            // 
            this.cmuXoaGiay.Name = "cmuXoaGiay";
            this.cmuXoaGiay.Size = new System.Drawing.Size(152, 22);
            this.cmuXoaGiay.Text = "Xóa Giấy";
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
            this.label3.Location = new System.Drawing.Point(158, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giấy theo Danh mục";
            // 
            // cmuNhanDoiGiay
            // 
            this.cmuNhanDoiGiay.Name = "cmuNhanDoiGiay";
            this.cmuNhanDoiGiay.Size = new System.Drawing.Size(152, 22);
            this.cmuNhanDoiGiay.Text = "Nhân đôi Giấy";
            this.cmuNhanDoiGiay.Click += new System.EventHandler(this.cmuNhanDoiGiay_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // QuanLyGiayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 378);
            this.Controls.Add(this.splitCont2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "QuanLyGiayForm";
            this.Text = "ChuanBiGiayForm";
            this.Load += new System.EventHandler(this.ChuanBiGiayForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitCont2.Panel1.ResumeLayout(false);
            this.splitCont2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitCont2)).EndInit();
            this.splitCont2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.cmu.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTieuDeForm;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNhan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.SplitContainer splitCont2;
        private System.Windows.Forms.ListBox lbxDanhMucGiay;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cboNhaCC;
        private System.Windows.Forms.ListView lvwGiay;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnQuanLyDanhMuc;
        private System.Windows.Forms.ContextMenuStrip cmu;
        private System.Windows.Forms.ToolStripMenuItem cmuThemGiay;
        private System.Windows.Forms.ToolStripMenuItem cmuSuaGiay;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cmuXoaGiay;
        private System.Windows.Forms.ToolStripMenuItem cmuNhanDoiGiay;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;

    }
}