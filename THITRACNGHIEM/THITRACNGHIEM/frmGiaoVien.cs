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
    public partial class frmGiaoVien : Form
    {
        public frmGiaoVien()
        {
            InitializeComponent();
        }

        private void gIAOVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsGiaoVien.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmGiaoVien_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.GIAOVIEN' table. You can move, or remove it, as needed.
 
            this.gIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIENTableAdapter.Fill(this.dS.GIAOVIEN);

            BindingSource bdsKhoa = new BindingSource();
            DataTable dt = new DataTable();
            dt = Program.ExecSqlDataTable("SELECT MAKH FROM KHOA");
            bdsKhoa.DataSource = dt;
            cmbMaKhoa.DataSource = bdsKhoa;
            cmbMaKhoa.DisplayMember = "MAKH";
            cmbMaKhoa.ValueMember = "MAKH";
            cmbMaKhoa.SelectedIndex = 0;


            gc1.Enabled = false;
            btnGhi.Enabled = btnHuy.Enabled = btnPhucHoi.Enabled = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "TRUONG" || Program.mGroup == "GIAOVIEN")
            {
                MessageBox.Show("Bạn không có quyền này!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            //cmbMaKhoa.SelectedIndex = 0; cmbMaKhoa.SelectedIndex = 1;
            cmbMaKhoa.Text = cmbMaKhoa.SelectedIndex.ToString();
            gc1.Enabled = true;
            bdsGiaoVien.AddNew();
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnHuy.Enabled = btnPhucHoi.Enabled = true;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaGV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mã GV không được trống!", "Lỗi", MessageBoxButtons.OK);
                txtMaGV.Focus();
                return;
            }
            if (txtHo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Họ không được trống!", "Lỗi", MessageBoxButtons.OK);
                txtHo.Focus();
                return;
            }
            if (txtTen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Tên không được trống!", "Lỗi", MessageBoxButtons.OK);
                txtHo.Focus();
                return;
            }
            if (txtHocVi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Học vị không được trống!", "Lỗi", MessageBoxButtons.OK);
                txtHo.Focus();
                return;
            }
            
            try
            {
                cmbMaKhoa.Text = cmbMaKhoa.SelectedIndex.ToString();

                bdsGiaoVien.EndEdit();
                bdsGiaoVien.ResetCurrentItem();
                this.gIAOVIENTableAdapter.Update(this.dS.GIAOVIEN);

                gc1.Enabled = false;
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                btnGhi.Enabled = btnHuy.Enabled = btnPhucHoi.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi giáo viên\n" + ex.Message, "Lỗi", MessageBoxButtons.OK);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String maGV = "";
            String maKH = "";
            if (Program.mGroup == "TRUONG")
            {
                MessageBox.Show("Bạn không được phép xóa!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            // kiểm tra mã khoa thuộc cơ sở khác
            //try
            //{
                

            //}
            //catch (Exception ex)
            //{

            //}
            if (MessageBox.Show("Bạn có thật sự muốn xóa giáo viên này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    maGV = ((DataRowView)bdsGiaoVien[bdsGiaoVien.Position])["MAGV"].ToString();
                    
                    bdsGiaoVien.RemoveCurrent();
                    this.gIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.gIAOVIENTableAdapter.Update(this.dS.GIAOVIEN);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa giáo viên. Hãy xóa lại!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK);
                    this.gIAOVIENTableAdapter.Fill(this.dS.GIAOVIEN);
                    bdsGiaoVien.Position = bdsGiaoVien.Find("MAGV", maGV);
                    return;
                }
            }
            if (bdsGiaoVien.Count == 0)
                btnXoa.Enabled = false;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "TRUONG" || Program.mGroup == "GIAOVIEN")
            {
                MessageBox.Show("Bạn không có quyền này!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            gc1.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnHuy.Enabled = btnPhucHoi.Enabled = true;
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsGiaoVien.RemoveCurrent();
            this.gIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIENTableAdapter.Fill(this.dS.GIAOVIEN);
            gc1.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = btnHuy.Enabled = btnPhucHoi.Enabled = false;
        }

        private void cmbMaKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
