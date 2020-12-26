namespace THITRACNGHIEM
{
    partial class frmThi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThi));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnNopBai = new DevExpress.XtraBars.BarButtonItem();
            this.btnXemKQ = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gcNoiDung = new DevExpress.XtraEditors.GroupControl();
            this.lblTime = new System.Windows.Forms.Label();
            this.rdbCauHoi = new DevExpress.XtraEditors.RadioGroup();
            this.rdbDapAn = new DevExpress.XtraEditors.RadioGroup();
            this.lblCauHoi = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tabNoiDung = new System.Windows.Forms.TabPage();
            this.tabKetQua = new System.Windows.Forms.TabPage();
            this.lblDiem = new System.Windows.Forms.Label();
            this.gvKetQua = new System.Windows.Forms.DataGridView();
            this.colCauHoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDaChon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDapAn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcNoiDung)).BeginInit();
            this.gcNoiDung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdbCauHoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdbDapAn.Properties)).BeginInit();
            this.tbcMain.SuspendLayout();
            this.tabNoiDung.SuspendLayout();
            this.tabKetQua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvKetQua)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnNopBai,
            this.btnThoat,
            this.btnXemKQ,
            this.barStaticItem1});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 4;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNopBai),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnXemKQ),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThoat)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnNopBai
            // 
            this.btnNopBai.Caption = "Nộp bài";
            this.btnNopBai.Id = 0;
            this.btnNopBai.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNopBai.ImageOptions.SvgImage")));
            this.btnNopBai.Name = "btnNopBai";
            this.btnNopBai.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnNopBai.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNopBai_ItemClick);
            // 
            // btnXemKQ
            // 
            this.btnXemKQ.Caption = "Xem kết quả";
            this.btnXemKQ.Id = 2;
            this.btnXemKQ.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXemKQ.ImageOptions.SvgImage")));
            this.btnXemKQ.Name = "btnXemKQ";
            this.btnXemKQ.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnXemKQ.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXemKQ_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 1;
            this.btnThoat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThoat.ImageOptions.SvgImage")));
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Time";
            this.barStaticItem1.Id = 3;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1292, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 537);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1292, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 507);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1292, 30);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 507);
            // 
            // gcNoiDung
            // 
            this.gcNoiDung.Controls.Add(this.lblTime);
            this.gcNoiDung.Controls.Add(this.rdbCauHoi);
            this.gcNoiDung.Controls.Add(this.rdbDapAn);
            this.gcNoiDung.Controls.Add(this.lblCauHoi);
            this.gcNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcNoiDung.Location = new System.Drawing.Point(3, 3);
            this.gcNoiDung.Name = "gcNoiDung";
            this.gcNoiDung.Size = new System.Drawing.Size(1278, 472);
            this.gcNoiDung.TabIndex = 5;
            this.gcNoiDung.Text = "Nội dung";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(1194, 3);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(50, 21);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "00:00";
            // 
            // rdbCauHoi
            // 
            this.rdbCauHoi.AllowDrop = true;
            this.rdbCauHoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbCauHoi.Location = new System.Drawing.Point(2, 405);
            this.rdbCauHoi.MenuManager = this.barManager1;
            this.rdbCauHoi.Name = "rdbCauHoi";
            this.rdbCauHoi.Properties.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rdbCauHoi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.rdbCauHoi.Properties.Appearance.Options.UseBackColor = true;
            this.rdbCauHoi.Properties.Appearance.Options.UseFont = true;
            this.rdbCauHoi.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.rdbCauHoi.Size = new System.Drawing.Size(1274, 65);
            this.rdbCauHoi.TabIndex = 2;
            this.rdbCauHoi.SelectedIndexChanged += new System.EventHandler(this.rdbCauHoi_SelectedIndexChanged);
            // 
            // rdbDapAn
            // 
            this.rdbDapAn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbDapAn.Location = new System.Drawing.Point(5, 260);
            this.rdbDapAn.MenuManager = this.barManager1;
            this.rdbDapAn.Name = "rdbDapAn";
            this.rdbDapAn.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rdbDapAn.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.rdbDapAn.Properties.Appearance.Options.UseBackColor = true;
            this.rdbDapAn.Properties.Appearance.Options.UseFont = true;
            this.rdbDapAn.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rdbDapAn.Size = new System.Drawing.Size(1268, 139);
            this.rdbDapAn.TabIndex = 1;
            this.rdbDapAn.SelectedIndexChanged += new System.EventHandler(this.rdbDapAn_SelectedIndexChanged);
            // 
            // lblCauHoi
            // 
            this.lblCauHoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCauHoi.AutoSize = true;
            this.lblCauHoi.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblCauHoi.Location = new System.Drawing.Point(12, 43);
            this.lblCauHoi.Name = "lblCauHoi";
            this.lblCauHoi.Size = new System.Drawing.Size(68, 24);
            this.lblCauHoi.TabIndex = 0;
            this.lblCauHoi.Text = "Câu 1:";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tabNoiDung);
            this.tbcMain.Controls.Add(this.tabKetQua);
            this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMain.Location = new System.Drawing.Point(0, 30);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(1292, 507);
            this.tbcMain.TabIndex = 4;
            // 
            // tabNoiDung
            // 
            this.tabNoiDung.Controls.Add(this.gcNoiDung);
            this.tabNoiDung.Location = new System.Drawing.Point(4, 25);
            this.tabNoiDung.Name = "tabNoiDung";
            this.tabNoiDung.Padding = new System.Windows.Forms.Padding(3);
            this.tabNoiDung.Size = new System.Drawing.Size(1284, 478);
            this.tabNoiDung.TabIndex = 0;
            this.tabNoiDung.Text = "Thi";
            this.tabNoiDung.UseVisualStyleBackColor = true;
            // 
            // tabKetQua
            // 
            this.tabKetQua.Controls.Add(this.lblDiem);
            this.tabKetQua.Controls.Add(this.gvKetQua);
            this.tabKetQua.Location = new System.Drawing.Point(4, 25);
            this.tabKetQua.Name = "tabKetQua";
            this.tabKetQua.Padding = new System.Windows.Forms.Padding(3);
            this.tabKetQua.Size = new System.Drawing.Size(1284, 478);
            this.tabKetQua.TabIndex = 1;
            this.tabKetQua.Text = "Kết quả";
            this.tabKetQua.UseVisualStyleBackColor = true;
            this.tabKetQua.Click += new System.EventHandler(this.tabKetQua_Click);
            // 
            // lblDiem
            // 
            this.lblDiem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiem.AutoSize = true;
            this.lblDiem.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiem.Location = new System.Drawing.Point(593, 198);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(138, 49);
            this.lblDiem.TabIndex = 1;
            this.lblDiem.Text = "Điểm: ";
            // 
            // gvKetQua
            // 
            this.gvKetQua.AllowUserToAddRows = false;
            this.gvKetQua.AllowUserToDeleteRows = false;
            this.gvKetQua.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvKetQua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCauHoi,
            this.colDaChon,
            this.colDapAn});
            this.gvKetQua.Location = new System.Drawing.Point(3, 3);
            this.gvKetQua.Name = "gvKetQua";
            this.gvKetQua.ReadOnly = true;
            this.gvKetQua.RowHeadersWidth = 51;
            this.gvKetQua.RowTemplate.Height = 24;
            this.gvKetQua.Size = new System.Drawing.Size(428, 448);
            this.gvKetQua.TabIndex = 0;
            // 
            // colCauHoi
            // 
            this.colCauHoi.HeaderText = "Câu";
            this.colCauHoi.MinimumWidth = 6;
            this.colCauHoi.Name = "colCauHoi";
            this.colCauHoi.ReadOnly = true;
            this.colCauHoi.Width = 125;
            // 
            // colDaChon
            // 
            this.colDaChon.HeaderText = "Đã chọn";
            this.colDaChon.MinimumWidth = 6;
            this.colDaChon.Name = "colDaChon";
            this.colDaChon.ReadOnly = true;
            this.colDaChon.Width = 125;
            // 
            // colDapAn
            // 
            this.colDapAn.HeaderText = "Đáp án";
            this.colDapAn.MinimumWidth = 6;
            this.colDapAn.Name = "colDapAn";
            this.colDapAn.ReadOnly = true;
            this.colDapAn.Width = 125;
            // 
            // frmThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 564);
            this.Controls.Add(this.tbcMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmThi";
            this.Text = "Thi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmThi_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcNoiDung)).EndInit();
            this.gcNoiDung.ResumeLayout(false);
            this.gcNoiDung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdbCauHoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdbDapAn.Properties)).EndInit();
            this.tbcMain.ResumeLayout(false);
            this.tabNoiDung.ResumeLayout(false);
            this.tabKetQua.ResumeLayout(false);
            this.tabKetQua.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvKetQua)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnNopBai;
        private DevExpress.XtraBars.BarButtonItem btnXemKQ;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.GroupControl gcNoiDung;
        private DevExpress.XtraEditors.RadioGroup rdbDapAn;
        private System.Windows.Forms.Label lblCauHoi;
        private DevExpress.XtraEditors.RadioGroup rdbCauHoi;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tabNoiDung;
        private System.Windows.Forms.TabPage tabKetQua;
        private System.Windows.Forms.Label lblDiem;
        private System.Windows.Forms.DataGridView gvKetQua;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCauHoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDaChon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDapAn;
    }
}