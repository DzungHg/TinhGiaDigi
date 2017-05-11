namespace TinhGiaInClient
{
    partial class ClientMainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuQuote = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTinhGiaMoi = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuQuote_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHienThiLietKeTinhGia = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindows_Cascade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindows_TileV = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindows_TileH = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindows_MiniAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAbout_SW = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBangGiaGiay = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuQuote,
            this.mnuView,
            this.mnuWindows,
            this.mnuAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // mnuQuote
            // 
            this.mnuQuote.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTinhGiaMoi,
            this.toolStripMenuItem2,
            this.mnuQuote_Exit});
            this.mnuQuote.Name = "mnuQuote";
            this.mnuQuote.Size = new System.Drawing.Size(66, 20);
            this.mnuQuote.Text = "Chào giá";
            // 
            // mnuTinhGiaMoi
            // 
            this.mnuTinhGiaMoi.Name = "mnuTinhGiaMoi";
            this.mnuTinhGiaMoi.Size = new System.Drawing.Size(141, 22);
            this.mnuTinhGiaMoi.Text = "Tính giá Mới";
            this.mnuTinhGiaMoi.Click += new System.EventHandler(this.mnuFlatProdEst_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(138, 6);
            // 
            // mnuQuote_Exit
            // 
            this.mnuQuote_Exit.Name = "mnuQuote_Exit";
            this.mnuQuote_Exit.Size = new System.Drawing.Size(141, 22);
            this.mnuQuote_Exit.Text = "Thoát";
            this.mnuQuote_Exit.Click += new System.EventHandler(this.mnuQuote_Exit_Click);
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHienThiLietKeTinhGia,
            this.toolStripMenuItem1,
            this.mnuBangGiaGiay});
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(61, 20);
            this.mnuView.Text = "Hiển thị";
            // 
            // mnuHienThiLietKeTinhGia
            // 
            this.mnuHienThiLietKeTinhGia.Name = "mnuHienThiLietKeTinhGia";
            this.mnuHienThiLietKeTinhGia.Size = new System.Drawing.Size(175, 22);
            this.mnuHienThiLietKeTinhGia.Text = "Danh sách Tính giá";
            this.mnuHienThiLietKeTinhGia.Click += new System.EventHandler(this.mnuView_QuoteBrowser_Click);
            // 
            // mnuWindows
            // 
            this.mnuWindows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuWindows_Cascade,
            this.mnuWindows_TileV,
            this.mnuWindows_TileH,
            this.mnuWindows_MiniAll});
            this.mnuWindows.Name = "mnuWindows";
            this.mnuWindows.Size = new System.Drawing.Size(55, 20);
            this.mnuWindows.Text = "Cửa sổ";
            // 
            // mnuWindows_Cascade
            // 
            this.mnuWindows_Cascade.Name = "mnuWindows_Cascade";
            this.mnuWindows_Cascade.Size = new System.Drawing.Size(151, 22);
            this.mnuWindows_Cascade.Text = "Cascade";
            this.mnuWindows_Cascade.Click += new System.EventHandler(this.mnuWindows_Cascade_Click);
            // 
            // mnuWindows_TileV
            // 
            this.mnuWindows_TileV.Name = "mnuWindows_TileV";
            this.mnuWindows_TileV.Size = new System.Drawing.Size(151, 22);
            this.mnuWindows_TileV.Text = "Tile Vertical";
            this.mnuWindows_TileV.Click += new System.EventHandler(this.mnuWindows_TileV_Click);
            // 
            // mnuWindows_TileH
            // 
            this.mnuWindows_TileH.Name = "mnuWindows_TileH";
            this.mnuWindows_TileH.Size = new System.Drawing.Size(151, 22);
            this.mnuWindows_TileH.Text = "Tile Horizontal";
            this.mnuWindows_TileH.Click += new System.EventHandler(this.mnuWindows_TileH_Click);
            // 
            // mnuWindows_MiniAll
            // 
            this.mnuWindows_MiniAll.Name = "mnuWindows_MiniAll";
            this.mnuWindows_MiniAll.Size = new System.Drawing.Size(151, 22);
            this.mnuWindows_MiniAll.Text = "Minimall All";
            this.mnuWindows_MiniAll.Click += new System.EventHandler(this.mnuWindows_MiniAll_Click);
            // 
            // mnuAbout
            // 
            this.mnuAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.mnuAbout_SW});
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(71, 20);
            this.mnuAbout.Text = "Thông tin";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(129, 6);
            // 
            // mnuAbout_SW
            // 
            this.mnuAbout_SW.Name = "mnuAbout_SW";
            this.mnuAbout_SW.Size = new System.Drawing.Size(132, 22);
            this.mnuAbout_SW.Text = "Phần mềm";
            this.mnuAbout_SW.Click += new System.EventHandler(this.mnuAbout_SW_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 6);
            // 
            // mnuBangGiaGiay
            // 
            this.mnuBangGiaGiay.Name = "mnuBangGiaGiay";
            this.mnuBangGiaGiay.Size = new System.Drawing.Size(175, 22);
            this.mnuBangGiaGiay.Text = "Bảng giá Giấy";
            this.mnuBangGiaGiay.Click += new System.EventHandler(this.mnuBangGiaGiay_Click);
            // 
            // ClientMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ClientMainForm";
            this.Text = "Dự tính giá in";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuQuote;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuQuote_Exit;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuHienThiLietKeTinhGia;
        private System.Windows.Forms.ToolStripMenuItem mnuWindows;
        private System.Windows.Forms.ToolStripMenuItem mnuWindows_Cascade;
        private System.Windows.Forms.ToolStripMenuItem mnuWindows_TileV;
        private System.Windows.Forms.ToolStripMenuItem mnuWindows_TileH;
        private System.Windows.Forms.ToolStripMenuItem mnuWindows_MiniAll;
        private System.Windows.Forms.ToolStripMenuItem mnuTinhGiaMoi;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout_SW;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuBangGiaGiay;
    }
}

