namespace TinhGiaInClient
{
    partial class KhoSanPhamSForm
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
            this.lvwKhoSanPham = new System.Windows.Forms.ListView();
            this.cmnu_Main = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnu_AddNew = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnu_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnu_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmnu_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwKhoSanPham
            // 
            this.lvwKhoSanPham.ContextMenuStrip = this.cmnu_Main;
            this.lvwKhoSanPham.GridLines = true;
            this.lvwKhoSanPham.Location = new System.Drawing.Point(12, 12);
            this.lvwKhoSanPham.MultiSelect = false;
            this.lvwKhoSanPham.Name = "lvwKhoSanPham";
            this.lvwKhoSanPham.Size = new System.Drawing.Size(216, 188);
            this.lvwKhoSanPham.TabIndex = 0;
            this.lvwKhoSanPham.UseCompatibleStateImageBehavior = false;
            this.lvwKhoSanPham.View = System.Windows.Forms.View.Details;
            // 
            // cmnu_Main
            // 
            this.cmnu_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnu_AddNew,
            this.cmnu_Edit,
            this.cmnu_Delete});
            this.cmnu_Main.Name = "cmnu_Main";
            this.cmnu_Main.Size = new System.Drawing.Size(120, 70);
            this.cmnu_Main.Opening += new System.ComponentModel.CancelEventHandler(this.cmnu_Main_Opening);
            // 
            // cmnu_AddNew
            // 
            this.cmnu_AddNew.Name = "cmnu_AddNew";
            this.cmnu_AddNew.Size = new System.Drawing.Size(119, 22);
            this.cmnu_AddNew.Text = "Khổ Mới";
            this.cmnu_AddNew.Click += new System.EventHandler(this.cmnu_AddNew_Click);
            // 
            // cmnu_Edit
            // 
            this.cmnu_Edit.Name = "cmnu_Edit";
            this.cmnu_Edit.Size = new System.Drawing.Size(119, 22);
            this.cmnu_Edit.Text = "Sửa Khổ";
            // 
            // cmnu_Delete
            // 
            this.cmnu_Delete.Name = "cmnu_Delete";
            this.cmnu_Delete.Size = new System.Drawing.Size(119, 22);
            this.cmnu_Delete.Text = "Xóa";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(85, 206);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // KhoSanPhamSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 241);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwKhoSanPham);
            this.Name = "KhoSanPhamSForm";
            this.Text = "Khổ sản phẩm";
            this.Load += new System.EventHandler(this.KhoSanPhamSForm_Load);
            this.cmnu_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwKhoSanPham;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cmnu_Main;
        private System.Windows.Forms.ToolStripMenuItem cmnu_AddNew;
        private System.Windows.Forms.ToolStripMenuItem cmnu_Edit;
        private System.Windows.Forms.ToolStripMenuItem cmnu_Delete;
    }
}