namespace TinhGiaInNhapLieu
{
    partial class MarkUpLoiNhuanGiayForm
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
            this.btnNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.splitCont2 = new System.Windows.Forms.SplitContainer();
            this.lbxDanhMucGiay = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cboNhaCC = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvwLoiNhuan = new System.Windows.Forms.ListView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuThem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuSua = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCont2)).BeginInit();
            this.splitCont2.Panel1.SuspendLayout();
            this.splitCont2.Panel2.SuspendLayout();
            this.splitCont2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.cmnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNhan);
            this.panel1.Controls.Add(this.btnHuy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 252);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 38);
            this.panel1.TabIndex = 0;
            // 
            // btnNhan
            // 
            this.btnNhan.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNhan.Location = new System.Drawing.Point(243, 6);
            this.btnNhan.Name = "btnNhan";
            this.btnNhan.Size = new System.Drawing.Size(75, 23);
            this.btnNhan.TabIndex = 3;
            this.btnNhan.Text = "Nhận";
            this.btnNhan.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Location = new System.Drawing.Point(97, 6);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 2;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // splitCont2
            // 
            this.splitCont2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCont2.Location = new System.Drawing.Point(0, 0);
            this.splitCont2.Name = "splitCont2";
            // 
            // splitCont2.Panel1
            // 
            this.splitCont2.Panel1.Controls.Add(this.lbxDanhMucGiay);
            this.splitCont2.Panel1.Controls.Add(this.panel3);
            // 
            // splitCont2.Panel2
            // 
            this.splitCont2.Panel2.Controls.Add(this.lvwLoiNhuan);
            this.splitCont2.Panel2.Controls.Add(this.panel4);
            this.splitCont2.Size = new System.Drawing.Size(499, 252);
            this.splitCont2.SplitterDistance = 223;
            this.splitCont2.TabIndex = 2;
            // 
            // lbxDanhMucGiay
            // 
            this.lbxDanhMucGiay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxDanhMucGiay.FormattingEnabled = true;
            this.lbxDanhMucGiay.Location = new System.Drawing.Point(0, 39);
            this.lbxDanhMucGiay.Name = "lbxDanhMucGiay";
            this.lbxDanhMucGiay.Size = new System.Drawing.Size(223, 213);
            this.lbxDanhMucGiay.TabIndex = 1;
            this.lbxDanhMucGiay.SelectedIndexChanged += new System.EventHandler(this.lbxDanhMucGiay_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cboNhaCC);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(223, 39);
            this.panel3.TabIndex = 0;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhà CC:";
            // 
            // lvwLoiNhuan
            // 
            this.lvwLoiNhuan.ContextMenuStrip = this.cmnu;
            this.lvwLoiNhuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwLoiNhuan.Location = new System.Drawing.Point(0, 39);
            this.lvwLoiNhuan.Name = "lvwLoiNhuan";
            this.lvwLoiNhuan.Size = new System.Drawing.Size(272, 213);
            this.lvwLoiNhuan.TabIndex = 2;
            this.lvwLoiNhuan.UseCompatibleStateImageBehavior = false;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(272, 39);
            this.panel4.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mức lợi nhuận";
            // 
            // cmnu
            // 
            this.cmnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuThem,
            this.cmnuSua,
            this.cmnuXoa});
            this.cmnu.Name = "cmnu";
            this.cmnu.Size = new System.Drawing.Size(153, 92);
            // 
            // cmnuThem
            // 
            this.cmnuThem.Name = "cmnuThem";
            this.cmnuThem.Size = new System.Drawing.Size(152, 22);
            this.cmnuThem.Text = "Thêm";
            this.cmnuThem.Click += new System.EventHandler(this.cmnuThem_Click);
            // 
            // cmnuSua
            // 
            this.cmnuSua.Name = "cmnuSua";
            this.cmnuSua.Size = new System.Drawing.Size(105, 22);
            this.cmnuSua.Text = "Sửa";
            // 
            // cmnuXoa
            // 
            this.cmnuXoa.Name = "cmnuXoa";
            this.cmnuXoa.Size = new System.Drawing.Size(105, 22);
            this.cmnuXoa.Text = "Xóa";
            // 
            // MarkUpLoiNhuanGiayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 290);
            this.Controls.Add(this.splitCont2);
            this.Controls.Add(this.panel1);
            this.Name = "MarkUpLoiNhuanGiayForm";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.splitCont2.Panel1.ResumeLayout(false);
            this.splitCont2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitCont2)).EndInit();
            this.splitCont2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.cmnu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitCont2;
        private System.Windows.Forms.ListBox lbxDanhMucGiay;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cboNhaCC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvwLoiNhuan;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNhan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.ContextMenuStrip cmnu;
        private System.Windows.Forms.ToolStripMenuItem cmnuThem;
        private System.Windows.Forms.ToolStripMenuItem cmnuSua;
        private System.Windows.Forms.ToolStripMenuItem cmnuXoa;

    }
}

