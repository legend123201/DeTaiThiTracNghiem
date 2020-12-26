namespace THITRACNGHIEM
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnLogin = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogout = new DevExpress.XtraBars.BarButtonItem();
            this.btnSinhVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnKhoaLop = new DevExpress.XtraBars.BarButtonItem();
            this.btnKhoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnGiaoVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnMonHoc = new DevExpress.XtraBars.BarButtonItem();
            this.btnBoDe = new DevExpress.XtraBars.BarButtonItem();
            this.btnCBThi = new DevExpress.XtraBars.BarButtonItem();
            this.btnThongTinSV = new DevExpress.XtraBars.BarButtonItem();
            this.btnChonMonThi = new DevExpress.XtraBars.BarButtonItem();
            this.btnTaoTK = new DevExpress.XtraBars.BarButtonItem();
            this.btnXemKQ = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnXemBD = new DevExpress.XtraBars.BarButtonItem();
            this.btnDSDK = new DevExpress.XtraBars.BarButtonItem();
            this.rbbHeThong = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbbDanhMuc = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbbThi = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.sttTrangThai = new System.Windows.Forms.StatusStrip();
            this.lblMa = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTen = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNhom = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.sttTrangThai.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnLogin,
            this.btnLogout,
            this.btnSinhVien,
            this.btnKhoaLop,
            this.btnKhoa,
            this.btnGiaoVien,
            this.btnMonHoc,
            this.btnBoDe,
            this.btnCBThi,
            this.btnThongTinSV,
            this.btnChonMonThi,
            this.btnTaoTK,
            this.btnXemKQ,
            this.barButtonItem1,
            this.btnXemBD,
            this.btnDSDK});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ribbonControl1.MaxItemId = 17;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbbHeThong,
            this.rbbDanhMuc,
            this.rbbThi,
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1294, 193);
            // 
            // btnLogin
            // 
            this.btnLogin.Caption = "Đăng nhập";
            this.btnLogin.Id = 1;
            this.btnLogin.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLogin.ImageOptions.SvgImage")));
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogin_ItemClick);
            // 
            // btnLogout
            // 
            this.btnLogout.Caption = "Đăng xuất";
            this.btnLogout.Id = 2;
            this.btnLogout.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLogout.ImageOptions.SvgImage")));
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogout_ItemClick);
            // 
            // btnSinhVien
            // 
            this.btnSinhVien.Caption = "Sinh viên";
            this.btnSinhVien.Id = 3;
            this.btnSinhVien.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSinhVien.ImageOptions.SvgImage")));
            this.btnSinhVien.Name = "btnSinhVien";
            this.btnSinhVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSinhVien_ItemClick);
            // 
            // btnKhoaLop
            // 
            this.btnKhoaLop.Caption = "Lớp";
            this.btnKhoaLop.Id = 4;
            this.btnKhoaLop.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnKhoaLop.ImageOptions.SvgImage")));
            this.btnKhoaLop.Name = "btnKhoaLop";
            this.btnKhoaLop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKhoaLop_ItemClick);
            // 
            // btnKhoa
            // 
            this.btnKhoa.Caption = "Khoa, Lớp";
            this.btnKhoa.Id = 5;
            this.btnKhoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnKhoa.ImageOptions.SvgImage")));
            this.btnKhoa.Name = "btnKhoa";
            this.btnKhoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKhoa_ItemClick);
            // 
            // btnGiaoVien
            // 
            this.btnGiaoVien.Caption = "Giáo viên";
            this.btnGiaoVien.Id = 6;
            this.btnGiaoVien.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGiaoVien.ImageOptions.SvgImage")));
            this.btnGiaoVien.Name = "btnGiaoVien";
            this.btnGiaoVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGiaoVien_ItemClick);
            // 
            // btnMonHoc
            // 
            this.btnMonHoc.Caption = "Môn học";
            this.btnMonHoc.Id = 7;
            this.btnMonHoc.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnMonHoc.ImageOptions.SvgImage")));
            this.btnMonHoc.Name = "btnMonHoc";
            this.btnMonHoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMonHoc_ItemClick);
            // 
            // btnBoDe
            // 
            this.btnBoDe.Caption = "Bộ đề";
            this.btnBoDe.Id = 8;
            this.btnBoDe.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBoDe.ImageOptions.SvgImage")));
            this.btnBoDe.Name = "btnBoDe";
            this.btnBoDe.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBoDe_ItemClick);
            // 
            // btnCBThi
            // 
            this.btnCBThi.Caption = "Lập lịch thi";
            this.btnCBThi.Id = 9;
            this.btnCBThi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCBThi.ImageOptions.SvgImage")));
            this.btnCBThi.Name = "btnCBThi";
            this.btnCBThi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCBThi_ItemClick);
            // 
            // btnThongTinSV
            // 
            this.btnThongTinSV.Caption = "Thông tin sinh viên";
            this.btnThongTinSV.Id = 10;
            this.btnThongTinSV.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThongTinSV.ImageOptions.SvgImage")));
            this.btnThongTinSV.Name = "btnThongTinSV";
            this.btnThongTinSV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThongTinSV_ItemClick);
            // 
            // btnChonMonThi
            // 
            this.btnChonMonThi.Caption = "Chọn môn thi";
            this.btnChonMonThi.Id = 11;
            this.btnChonMonThi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnChonMonThi.ImageOptions.SvgImage")));
            this.btnChonMonThi.Name = "btnChonMonThi";
            this.btnChonMonThi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChonMonThi_ItemClick);
            // 
            // btnTaoTK
            // 
            this.btnTaoTK.Caption = "Tạo tài khoản";
            this.btnTaoTK.Id = 12;
            this.btnTaoTK.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTaoTK.ImageOptions.SvgImage")));
            this.btnTaoTK.Name = "btnTaoTK";
            this.btnTaoTK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaoTK_ItemClick);
            // 
            // btnXemKQ
            // 
            this.btnXemKQ.Caption = "Xem kết quả";
            this.btnXemKQ.Id = 13;
            this.btnXemKQ.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXemKQ.ImageOptions.SvgImage")));
            this.btnXemKQ.Name = "btnXemKQ";
            this.btnXemKQ.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXemKQ_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Id = 14;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btnXemBD
            // 
            this.btnXemBD.Caption = "Xem bảng điểm";
            this.btnXemBD.Id = 15;
            this.btnXemBD.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXemBD.ImageOptions.SvgImage")));
            this.btnXemBD.Name = "btnXemBD";
            this.btnXemBD.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXemBD_ItemClick);
            // 
            // btnDSDK
            // 
            this.btnDSDK.Caption = "Xem DSĐK Thi";
            this.btnDSDK.Id = 16;
            this.btnDSDK.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDSDK.ImageOptions.SvgImage")));
            this.btnDSDK.Name = "btnDSDK";
            this.btnDSDK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDSDK_ItemClick);
            // 
            // rbbHeThong
            // 
            this.rbbHeThong.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup6});
            this.rbbHeThong.Name = "rbbHeThong";
            this.rbbHeThong.Text = "Hệ Thống";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLogin);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLogout);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnTaoTK);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            // 
            // rbbDanhMuc
            // 
            this.rbbDanhMuc.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.rbbDanhMuc.Name = "rbbDanhMuc";
            this.rbbDanhMuc.Text = "Danh Mục";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnSinhVien);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnKhoa);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnGiaoVien);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnMonHoc);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnBoDe);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnCBThi);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // rbbThi
            // 
            this.rbbThi.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4,
            this.ribbonPageGroup5});
            this.rbbThi.Name = "rbbThi";
            this.rbbThi.Text = "Thi";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnThongTinSV);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnChonMonThi);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup7,
            this.ribbonPageGroup8});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Report";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.btnXemKQ);
            this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.ItemLinks.Add(this.btnXemBD);
            this.ribbonPageGroup8.ItemLinks.Add(this.btnDSDK);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.CloseTabOnMiddleClick = DevExpress.XtraTabbedMdi.CloseTabOnMiddleClick.Never;
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // sttTrangThai
            // 
            this.sttTrangThai.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sttTrangThai.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMa,
            this.lblTen,
            this.lblNhom});
            this.sttTrangThai.Location = new System.Drawing.Point(0, 688);
            this.sttTrangThai.Name = "sttTrangThai";
            this.sttTrangThai.Size = new System.Drawing.Size(1294, 26);
            this.sttTrangThai.TabIndex = 2;
            this.sttTrangThai.Text = "statusStrip1";
            // 
            // lblMa
            // 
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(151, 20);
            this.lblMa.Text = "toolStripStatusLabel1";
            // 
            // lblTen
            // 
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(151, 20);
            this.lblTen.Text = "toolStripStatusLabel1";
            // 
            // lblNhom
            // 
            this.lblNhom.Name = "lblNhom";
            this.lblNhom.Size = new System.Drawing.Size(151, 20);
            this.lblNhom.Text = "toolStripStatusLabel1";
            // 
            // frmMain
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 714);
            this.Controls.Add(this.sttTrangThai);
            this.Controls.Add(this.ribbonControl1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.Text = "THI TRẮC NGHIỆM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.sttTrangThai.ResumeLayout(false);
            this.sttTrangThai.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbbHeThong;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnLogin;
        private DevExpress.XtraBars.BarButtonItem btnLogout;
        private DevExpress.XtraBars.BarButtonItem btnSinhVien;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbbDanhMuc;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private System.Windows.Forms.StatusStrip sttTrangThai;
        private System.Windows.Forms.ToolStripStatusLabel lblTen;
        private System.Windows.Forms.ToolStripStatusLabel lblNhom;
        private System.Windows.Forms.ToolStripStatusLabel lblMa;
        private DevExpress.XtraBars.BarButtonItem btnKhoaLop;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem btnKhoa;
        private DevExpress.XtraBars.BarButtonItem btnGiaoVien;
        private DevExpress.XtraBars.BarButtonItem btnMonHoc;
        private DevExpress.XtraBars.BarButtonItem btnBoDe;
        private DevExpress.XtraBars.BarButtonItem btnCBThi;
        private DevExpress.XtraBars.BarButtonItem btnThongTinSV;
        private DevExpress.XtraBars.BarButtonItem btnChonMonThi;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbbThi;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem btnTaoTK;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem btnXemKQ;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnXemBD;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.BarButtonItem btnDSDK;
    }
}

