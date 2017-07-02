namespace TinhGiaInNhapLieu
{
    partial class QuanLyTChonThNhuaForm
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
            this.pageView = new Telerik.WinControls.UI.RadPageView();
            this.pagTuyChon = new Telerik.WinControls.UI.RadPageViewPage();
            this.btnCapNhatTuyChon = new Telerik.WinControls.UI.RadButton();
            this.chkListTuyChon = new Telerik.WinControls.UI.RadCheckedListBox();
            this.pagGiaTuyChon = new Telerik.WinControls.UI.RadPageViewPage();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtGiaBan = new Telerik.WinControls.UI.RadTextBox();
            this.btnCapNhatGia = new Telerik.WinControls.UI.RadButton();
            this.lvwGiaTuyChon = new Telerik.WinControls.UI.RadListView();
            this.btnHuy = new Telerik.WinControls.UI.RadButton();
            this.cboBangGia = new Telerik.WinControls.UI.RadDropDownList();
            this.btnNhan = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtDienGiaiBangGia = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).BeginInit();
            this.pageView.SuspendLayout();
            this.pagTuyChon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCapNhatTuyChon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkListTuyChon)).BeginInit();
            this.pagGiaTuyChon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCapNhatGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvwGiaTuyChon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBangGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienGiaiBangGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pageView
            // 
            this.pageView.Controls.Add(this.pagTuyChon);
            this.pageView.Controls.Add(this.pagGiaTuyChon);
            this.pageView.Location = new System.Drawing.Point(5, 102);
            this.pageView.Name = "pageView";
            this.pageView.SelectedPage = this.pagTuyChon;
            this.pageView.Size = new System.Drawing.Size(490, 236);
            this.pageView.TabIndex = 3;
            this.pageView.Text = "pagView";
            this.pageView.SelectedPageChanged += new System.EventHandler(this.pageView_SelectedPageChanged);
            // 
            // pagTuyChon
            // 
            this.pagTuyChon.Controls.Add(this.btnCapNhatTuyChon);
            this.pagTuyChon.Controls.Add(this.chkListTuyChon);
            this.pagTuyChon.ItemSize = new System.Drawing.SizeF(62F, 28F);
            this.pagTuyChon.Location = new System.Drawing.Point(10, 37);
            this.pagTuyChon.Name = "pagTuyChon";
            this.pagTuyChon.Size = new System.Drawing.Size(469, 188);
            this.pagTuyChon.Text = "Tùy chọn";
            // 
            // btnCapNhatTuyChon
            // 
            this.btnCapNhatTuyChon.Location = new System.Drawing.Point(333, 130);
            this.btnCapNhatTuyChon.Name = "btnCapNhatTuyChon";
            this.btnCapNhatTuyChon.Size = new System.Drawing.Size(110, 24);
            this.btnCapNhatTuyChon.TabIndex = 5;
            this.btnCapNhatTuyChon.Text = "Cập nhật";
            this.btnCapNhatTuyChon.Click += new System.EventHandler(this.btnCapNhatTuyChon_Click);
            // 
            // chkListTuyChon
            // 
            this.chkListTuyChon.Location = new System.Drawing.Point(13, 3);
            this.chkListTuyChon.Name = "chkListTuyChon";
            this.chkListTuyChon.Size = new System.Drawing.Size(207, 170);
            this.chkListTuyChon.TabIndex = 0;
            this.chkListTuyChon.Text = "radCheckedListBox1";
            // 
            // pagGiaTuyChon
            // 
            this.pagGiaTuyChon.Controls.Add(this.radLabel1);
            this.pagGiaTuyChon.Controls.Add(this.txtGiaBan);
            this.pagGiaTuyChon.Controls.Add(this.btnCapNhatGia);
            this.pagGiaTuyChon.Controls.Add(this.lvwGiaTuyChon);
            this.pagGiaTuyChon.ItemSize = new System.Drawing.SizeF(79F, 28F);
            this.pagGiaTuyChon.Location = new System.Drawing.Point(10, 37);
            this.pagGiaTuyChon.Name = "pagGiaTuyChon";
            this.pagGiaTuyChon.Size = new System.Drawing.Size(469, 188);
            this.pagGiaTuyChon.Text = "Giá tùy chọn";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(333, 60);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(44, 18);
            this.radLabel1.TabIndex = 8;
            this.radLabel1.Text = "Giá bán";
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(333, 84);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(100, 20);
            this.txtGiaBan.TabIndex = 7;
            // 
            // btnCapNhatGia
            // 
            this.btnCapNhatGia.Location = new System.Drawing.Point(333, 130);
            this.btnCapNhatGia.Name = "btnCapNhatGia";
            this.btnCapNhatGia.Size = new System.Drawing.Size(110, 24);
            this.btnCapNhatGia.TabIndex = 6;
            this.btnCapNhatGia.Text = "Cập nhật Giá";
            this.btnCapNhatGia.Click += new System.EventHandler(this.btnCapNhatGia_Click);
            // 
            // lvwGiaTuyChon
            // 
            this.lvwGiaTuyChon.ItemSpacing = -1;
            this.lvwGiaTuyChon.Location = new System.Drawing.Point(3, 3);
            this.lvwGiaTuyChon.Name = "lvwGiaTuyChon";
            this.lvwGiaTuyChon.ShowGridLines = true;
            this.lvwGiaTuyChon.Size = new System.Drawing.Size(305, 182);
            this.lvwGiaTuyChon.TabIndex = 5;
            this.lvwGiaTuyChon.Text = "radListView1";
            this.lvwGiaTuyChon.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.lvwGiaTuyChon.SelectedItemChanged += new System.EventHandler(this.lvwGiaTuyChon_SelectedItemChanged);
            this.lvwGiaTuyChon.ColumnCreating += new Telerik.WinControls.UI.ListViewColumnCreatingEventHandler(this.lvwGiaTuyChon_ColumnCreating);
            // 
            // btnHuy
            // 
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Location = new System.Drawing.Point(125, 344);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(110, 24);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            // 
            // cboBangGia
            // 
            this.cboBangGia.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboBangGia.Location = new System.Drawing.Point(12, 43);
            this.cboBangGia.Name = "cboBangGia";
            this.cboBangGia.Size = new System.Drawing.Size(190, 20);
            this.cboBangGia.TabIndex = 36;
            this.cboBangGia.Text = "Bảng giá";
            this.cboBangGia.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboBangGia_SelectedIndexChanged);
            // 
            // btnNhan
            // 
            this.btnNhan.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNhan.Location = new System.Drawing.Point(261, 344);
            this.btnNhan.Name = "btnNhan";
            this.btnNhan.Size = new System.Drawing.Size(110, 24);
            this.btnNhan.TabIndex = 5;
            this.btnNhan.Text = "Nhận";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(156, 12);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(183, 25);
            this.radLabel2.TabIndex = 37;
            this.radLabel2.Text = "TÙY CHỌN THẺ NHỰA";
            // 
            // txtDienGiaiBangGia
            // 
            this.txtDienGiaiBangGia.AutoSize = false;
            this.txtDienGiaiBangGia.Location = new System.Drawing.Point(208, 43);
            this.txtDienGiaiBangGia.Multiline = true;
            this.txtDienGiaiBangGia.Name = "txtDienGiaiBangGia";
            this.txtDienGiaiBangGia.ReadOnly = true;
            this.txtDienGiaiBangGia.Size = new System.Drawing.Size(276, 53);
            this.txtDienGiaiBangGia.TabIndex = 38;
            // 
            // QuanLyTuyChonTheNhuaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 375);
            this.Controls.Add(this.txtDienGiaiBangGia);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.btnNhan);
            this.Controls.Add(this.cboBangGia);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.pageView);
            this.Name = "QuanLyTuyChonTheNhuaForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.QuanLyMarkUpLoiNhuanGiayForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pageView)).EndInit();
            this.pageView.ResumeLayout(false);
            this.pagTuyChon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCapNhatTuyChon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkListTuyChon)).EndInit();
            this.pagGiaTuyChon.ResumeLayout(false);
            this.pagGiaTuyChon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCapNhatGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvwGiaTuyChon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBangGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienGiaiBangGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView pageView;
        private Telerik.WinControls.UI.RadPageViewPage pagTuyChon;
        private Telerik.WinControls.UI.RadPageViewPage pagGiaTuyChon;
        private Telerik.WinControls.UI.RadButton btnHuy;
        private Telerik.WinControls.UI.RadDropDownList cboBangGia;
        private Telerik.WinControls.UI.RadButton btnNhan;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadCheckedListBox chkListTuyChon;
        private Telerik.WinControls.UI.RadTextBox txtDienGiaiBangGia;
        private Telerik.WinControls.UI.RadButton btnCapNhatTuyChon;
        private Telerik.WinControls.UI.RadButton btnCapNhatGia;
        private Telerik.WinControls.UI.RadListView lvwGiaTuyChon;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtGiaBan;

    }
}

