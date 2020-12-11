﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace THITRACNGHIEM
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
            rbbDanhMuc.Visible = false;
            rbbThi.Visible = false;
        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void btnLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmDangNhap));
            if (frm != null)
                frm.Activate();
            else
            {
                frmDangNhap f = new frmDangNhap();
                f.MdiParent = this;
                f.f = this;
                f.Show();
            }
        }

        public void hienThiMenu()
        {
            lblMa.Text = "Mã: " + Program.username;
            lblTen.Text = "Tên: " + Program.mHoten;
            lblNhom.Text = "Nhóm: " + Program.mGroup;
            if (Program.isSinhVien)
            {
                rbbThi.Visible = true;
                rbbDanhMuc.Visible = false;
            }
            else
            {
                rbbThi.Visible = true;
                rbbDanhMuc.Visible = true;
            }
        }

        private void btnSinhVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Program.mHoten.Equals("") || Program.mGroup.Equals(""))
            {
                MessageBox.Show("Vui lòng đăng nhập trước!", "Lỗi!", MessageBoxButtons.OK);
                return;
            }
            Form frm = this.CheckExists(typeof(frmSinhVien));
            if (frm != null)
                frm.Activate();
            else
            {
                frmSinhVien f = new frmSinhVien();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnLogout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Program.mHoten.Trim().Length == 0 || Program.mGroup.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa đăng nhập!", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            Form frmSV = this.CheckExists(typeof(frmSinhVien));
            if (frmSV != null)
                frmSV.Close();
            Form frmLop = this.CheckExists(typeof(frmLop));
            if (frmLop != null)
                frmLop.Close();
            Form frmKhoa = this.CheckExists(typeof(frmKhoa));
            if (frmKhoa != null)
                frmKhoa.Close();
            Form frmGV = this.CheckExists(typeof(frmGiaoVien));
            if (frmGV != null)
                frmGV.Close();
            Form frmMH = this.CheckExists(typeof(frmMonHoc));
            if (frmMH != null)
                frmMH.Close();
            Form frmBD = this.CheckExists(typeof(frmBoDe));
            if (frmBD != null)
                frmBD.Close();
            Form frmCBThi = this.CheckExists(typeof(frmChuanBiThi));
            if (frmCBThi != null)
                frmCBThi.Close();

            Program.myReader = null;
            Program.username = "";
            Program.mlogin = "";
            Program.password = "";
            Program.mloginDN = "";
            Program.passwordDN = "";
            Program.mGroup = "";
            Program.mHoten = "";
            Program.mCoso = 0;
            MessageBox.Show("Đăng xuất thành công!", "Thông báo", MessageBoxButtons.OK);
            return;
        }

        private void btnKhoaLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mHoten.Equals("") || Program.mGroup.Equals(""))
            {
                MessageBox.Show("Vui lòng đăng nhập trước!", "Lỗi!", MessageBoxButtons.OK);
                return;
            }
            Form frm = this.CheckExists(typeof(frmLop));
            if (frm != null)
                frm.Activate();
            else
            {
                frmLop f = new frmLop();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnKhoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mHoten.Equals("") || Program.mGroup.Equals(""))
            {
                MessageBox.Show("Vui lòng đăng nhập trước!", "Lỗi!", MessageBoxButtons.OK);
                return;
            }
            Form frm = this.CheckExists(typeof(frmKhoa));
            if (frm != null)
                frm.Activate();
            else
            {
                frmKhoa f = new frmKhoa();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnGiaoVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mHoten.Equals("") || Program.mGroup.Equals(""))
            {
                MessageBox.Show("Vui lòng đăng nhập trước!", "Lỗi!", MessageBoxButtons.OK);
                return;
            }
            Form frm = this.CheckExists(typeof(frmGiaoVien));
            if (frm != null)
                frm.Activate();
            else
            {
                frmGiaoVien f = new frmGiaoVien();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnMonHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mHoten.Equals("") || Program.mGroup.Equals(""))
            {
                MessageBox.Show("Vui lòng đăng nhập trước!", "Lỗi!", MessageBoxButtons.OK);
                return;
            }
            Form frm = this.CheckExists(typeof(frmMonHoc));
            if (frm != null)
                frm.Activate();
            else
            {
                frmMonHoc f = new frmMonHoc();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnBoDe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mHoten.Equals("") || Program.mGroup.Equals(""))
            {
                MessageBox.Show("Vui lòng đăng nhập trước!", "Lỗi!", MessageBoxButtons.OK);
                return;
            }
            Form frm = this.CheckExists(typeof(frmBoDe));
            if (frm != null)
                frm.Activate();
            else
            {
                frmBoDe f = new frmBoDe();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnCBThi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mHoten.Equals("") || Program.mGroup.Equals(""))
            {
                MessageBox.Show("Vui lòng đăng nhập trước!", "Lỗi!", MessageBoxButtons.OK);
                return;
            }
            Form frm = this.CheckExists(typeof(frmChuanBiThi));
            if (frm != null)
                frm.Activate();
            else
            {
                frmChuanBiThi f = new frmChuanBiThi();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnThongTinSV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mHoten.Equals("") || Program.mGroup.Equals(""))
            {
                MessageBox.Show("Vui lòng đăng nhập trước!", "Lỗi!", MessageBoxButtons.OK);
                return;
            }
            Form frm = this.CheckExists(typeof(frmThongTinSV));
            if (frm != null)
                frm.Activate();
            else
            {
                frmThongTinSV f = new frmThongTinSV();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnChonMonThi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mHoten.Equals("") || Program.mGroup.Equals(""))
            {
                MessageBox.Show("Vui lòng đăng nhập trước!", "Lỗi!", MessageBoxButtons.OK);
                return;
            }
            Form frm = this.CheckExists(typeof(frmChonMonThi));
            if (frm != null)
                frm.Activate();
            else
            {
                frmChonMonThi f = new frmChonMonThi();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void inDSGV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmInDSGV));
            if (frm != null)
                frm.Activate();
            else
            {
                frmInDSGV f = new frmInDSGV();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}
