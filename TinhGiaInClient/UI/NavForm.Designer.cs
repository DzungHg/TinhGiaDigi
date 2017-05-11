namespace TinhGiaInClient.UI
{
    partial class NavForm
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
            this.radLayoutControl1 = new Telerik.WinControls.UI.RadLayoutControl();
            this.btnThem = new Telerik.WinControls.UI.RadButton();
            this.layoutControlItem1 = new Telerik.WinControls.UI.LayoutControlItem();
            this.btnKeQuaChaoGia = new Telerik.WinControls.UI.RadButton();
            this.layoutControlItem2 = new Telerik.WinControls.UI.LayoutControlItem();
            this.btnBangGiaGiay = new Telerik.WinControls.UI.RadButton();
            this.layoutControlItem3 = new Telerik.WinControls.UI.LayoutControlItem();
            this.btnThoat = new Telerik.WinControls.UI.RadButton();
            this.layoutControlItem4 = new Telerik.WinControls.UI.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.radLayoutControl1)).BeginInit();
            this.radLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnThem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKeQuaChaoGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBangGiaGiay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnThoat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLayoutControl1
            // 
            this.radLayoutControl1.Controls.Add(this.btnThem);
            this.radLayoutControl1.Controls.Add(this.btnKeQuaChaoGia);
            this.radLayoutControl1.Controls.Add(this.btnBangGiaGiay);
            this.radLayoutControl1.Controls.Add(this.btnThoat);
            this.radLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLayoutControl1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.radLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.radLayoutControl1.Name = "radLayoutControl1";
            this.radLayoutControl1.Size = new System.Drawing.Size(573, 92);
            this.radLayoutControl1.TabIndex = 0;
            this.radLayoutControl1.Text = "radLayoutControl1";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(3, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(132, 86);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AssociatedControl = this.btnThem;
            this.layoutControlItem1.Bounds = new System.Drawing.Rectangle(0, 0, 138, 92);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Text = "radButton1";
            // 
            // btnKeQuaChaoGia
            // 
            this.btnKeQuaChaoGia.Location = new System.Drawing.Point(141, 3);
            this.btnKeQuaChaoGia.Name = "btnKeQuaChaoGia";
            this.btnKeQuaChaoGia.Size = new System.Drawing.Size(139, 86);
            this.btnKeQuaChaoGia.TabIndex = 4;
            this.btnKeQuaChaoGia.Text = "Kết quả Chào giá";
            this.btnKeQuaChaoGia.Click += new System.EventHandler(this.btnKeQuaChaoGia_Click);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AssociatedControl = this.btnKeQuaChaoGia;
            this.layoutControlItem2.Bounds = new System.Drawing.Rectangle(138, 0, 145, 92);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Text = "layoutControlItem2";
            // 
            // btnBangGiaGiay
            // 
            this.btnBangGiaGiay.Location = new System.Drawing.Point(286, 3);
            this.btnBangGiaGiay.Name = "btnBangGiaGiay";
            this.btnBangGiaGiay.Size = new System.Drawing.Size(146, 86);
            this.btnBangGiaGiay.TabIndex = 5;
            this.btnBangGiaGiay.Text = "Bảng giá Giấy";
            this.btnBangGiaGiay.Click += new System.EventHandler(this.btnBangGiaGiay_Click);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AssociatedControl = this.btnBangGiaGiay;
            this.layoutControlItem3.Bounds = new System.Drawing.Rectangle(283, 0, 152, 92);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Text = "layoutControlItem3";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(438, 3);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(132, 86);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AssociatedControl = this.btnThoat;
            this.layoutControlItem4.Bounds = new System.Drawing.Rectangle(435, 0, 138, 92);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Text = "layoutControlItem4";
            // 
            // NavForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 92);
            this.Controls.Add(this.radLayoutControl1);
            this.Name = "NavForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "NavForm";
            ((System.ComponentModel.ISupportInitialize)(this.radLayoutControl1)).EndInit();
            this.radLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnThem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKeQuaChaoGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBangGiaGiay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnThoat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadLayoutControl radLayoutControl1;
        private Telerik.WinControls.UI.RadButton btnThem;
        private Telerik.WinControls.UI.RadButton btnKeQuaChaoGia;
        private Telerik.WinControls.UI.LayoutControlItem layoutControlItem1;
        private Telerik.WinControls.UI.LayoutControlItem layoutControlItem2;
        private Telerik.WinControls.UI.RadButton btnBangGiaGiay;
        private Telerik.WinControls.UI.LayoutControlItem layoutControlItem3;
        private Telerik.WinControls.UI.RadButton btnThoat;
        private Telerik.WinControls.UI.LayoutControlItem layoutControlItem4;
    }
}
