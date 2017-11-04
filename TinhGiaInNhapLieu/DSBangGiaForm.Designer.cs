namespace TinhGiaInNhapLieu
{
    partial class DSBangGiaForm
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
            this.lstBangGia = new Telerik.WinControls.UI.RadListView();
            this.lblTieuDe = new Telerik.WinControls.UI.RadLabel();
            this.btnNhan = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.lstBangGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTieuDe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lstBangGia
            // 
            this.lstBangGia.ItemSpacing = -1;
            this.lstBangGia.Location = new System.Drawing.Point(6, 43);
            this.lstBangGia.Name = "lstBangGia";
            this.lstBangGia.ShowGridLines = true;
            this.lstBangGia.Size = new System.Drawing.Size(274, 160);
            this.lstBangGia.TabIndex = 19;
            this.lstBangGia.Text = "radListView1";
            this.lstBangGia.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.lstBangGia.SelectedItemChanged += new System.EventHandler(this.lstBangGia_SelectedItemChanged);
            this.lstBangGia.ColumnCreating += new Telerik.WinControls.UI.ListViewColumnCreatingEventHandler(this.lstBangGia_ColumnCreating);
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.Location = new System.Drawing.Point(91, 12);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(105, 25);
            this.lblTieuDe.TabIndex = 18;
            this.lblTieuDe.Text = "DANH SÁCH";
            // 
            // btnNhan
            // 
            this.btnNhan.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNhan.Location = new System.Drawing.Point(91, 221);
            this.btnNhan.Name = "btnNhan";
            this.btnNhan.Size = new System.Drawing.Size(110, 24);
            this.btnNhan.TabIndex = 20;
            this.btnNhan.Text = "Nhận";
            // 
            // DSBangGiaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 257);
            this.Controls.Add(this.btnNhan);
            this.Controls.Add(this.lstBangGia);
            this.Controls.Add(this.lblTieuDe);
            this.Name = "DSBangGiaForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "DSBangGiaForm";
            this.Load += new System.EventHandler(this.DSBangGiaForm_Load);
            this.Resize += new System.EventHandler(this.DSBangGiaForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.lstBangGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTieuDe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadListView lstBangGia;
        private Telerik.WinControls.UI.RadLabel lblTieuDe;
        private Telerik.WinControls.UI.RadButton btnNhan;
    }
}
