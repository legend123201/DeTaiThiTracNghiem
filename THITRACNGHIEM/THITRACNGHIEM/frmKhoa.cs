using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THITRACNGHIEM
{
    public partial class frmKhoa : Form
    {
        BindingSource bdsCoSo = new BindingSource();
        public frmKhoa()
        {
            InitializeComponent();
        }

        private void kHOABindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKhoa.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmKhoa_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.KHOA' table. You can move, or remove it, as needed.
            this.kHOATableAdapter.Connection.ConnectionString = Program.connstr;
            this.kHOATableAdapter.Fill(this.dS.KHOA);
            
            
            DataTable dt = new DataTable();
            dt = Program.ExecSqlDataTable("SELECT MACS, TENCS FROM COSO");
            bdsCoSo.DataSource = dt;
            txtMaCS.Text = ((DataRowView)bdsCoSo[bdsCoSo.Position])["MACS"].ToString();

            cmbCoSo.DataSource = Program.bds_dspm;
            cmbCoSo.DisplayMember = "TEN_COSO";
            cmbCoSo.ValueMember = "TEN_SERVER";
            cmbCoSo.SelectedIndex = Program.mCoso;
            if (Program.mGroup == "TRUONG")
                cmbCoSo.Enabled = true;
            else
                cmbCoSo.Enabled = false;

            gc2.Enabled = false;
            btnGhi.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void cmbCoSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCoSo.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
            Program.servername = cmbCoSo.SelectedValue.ToString();
            if (cmbCoSo.SelectedIndex != Program.mCoso)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }
            if (Program.KetNoi() == 0)
                MessageBox.Show("Lỗi kết nối tới cơ sở mới!", "Lỗi", MessageBoxButtons.OK);
            else
            {

                this.kHOATableAdapter.Connection.ConnectionString = Program.connstr;
                this.kHOATableAdapter.Fill(this.dS.KHOA);
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "TRUONG" || Program.mGroup == "GIAOVIEN")
            {
                MessageBox.Show("Bạn không có quyền này!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            gc2.Enabled = true;
            bdsKhoa.AddNew();
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnHuy.Enabled = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String maKH = "";
            if (Program.mGroup == "TRUONG")
            {
                MessageBox.Show("Bạn không được phép xóa!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa lớp này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    maKH = ((DataRowView)bdsKhoa[bdsKhoa.Position])["MAKH"].ToString();
                    bdsKhoa.RemoveCurrent();
                    this.kHOATableAdapter.Connection.ConnectionString = Program.connstr;
                    this.kHOATableAdapter.Update(this.dS.KHOA);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa lớp. Hãy xóa lại!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK);
                    this.kHOATableAdapter.Fill(this.dS.KHOA);
                    bdsKhoa.Position = bdsKhoa.Find("MAKH", maKH);
                    return;
                }
            }
            if (bdsKhoa.Count == 0)
                btnXoa.Enabled = false;
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsKhoa.RemoveCurrent();
            //bdsKhoa.CancelEdit();
            this.kHOATableAdapter.Connection.ConnectionString = Program.connstr;
            this.kHOATableAdapter.Fill(this.dS.KHOA);
            gc2.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = btnHuy.Enabled = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mã khoa không được trống!", "Lỗi", MessageBoxButtons.OK);
                txtMaKH.Focus();
                return;
            }
            if (txtTenKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Tên khoa không được trống!", "Lỗi", MessageBoxButtons.OK);
                txtTenKH.Focus();
                return;
            }
            txtMaCS.Text = ((DataRowView)bdsCoSo[bdsCoSo.Position])["MACS"].ToString();
            try
            {

                bdsKhoa.EndEdit();
                bdsKhoa.ResetCurrentItem();
                this.kHOATableAdapter.Update(this.dS.KHOA);

                gc2.Enabled = false;
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                btnGhi.Enabled = btnHuy.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi khoa\n" + ex.Message, "Lỗi", MessageBoxButtons.OK);
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "TRUONG" || Program.mGroup == "GIAOVIEN")
            {
                MessageBox.Show("Bạn không có quyền này!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            gc2.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnHuy.Enabled = true;
        }

        private void cmbMaCS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
