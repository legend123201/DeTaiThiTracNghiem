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
        private PhucHoi phucHoi = new PhucHoi();
        private bool isDangThem = false;
        private bool isDangSua = false;
        private bool suaKH = false;
        private int index = 0;
        private string tenKH = "";
        private string maKH = "";
        private DataTable dt = new DataTable();
        
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
            // TODO: This line of code loads data into the 'dS.BODE' table. You can move, or remove it, as needed.
            this.bODETableAdapter.Connection.ConnectionString = Program.connstr;
            this.bODETableAdapter.Fill(this.dS.BODE);
            // TODO: This line of code loads data into the 'dS.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIEN_DANGKYTableAdapter.Fill(this.dS.GIAOVIEN_DANGKY);

            dt = Program.ExecSqlDataTable("SELECT MAKH, TENKH FROM KHOA");
            cmbMaKhoa.DataSource = dt;
            cmbMaKhoa.DisplayMember = "TENKH";
            cmbMaKhoa.ValueMember = "MAKH";
            cmbMaKhoa.SelectedIndex = 0;

            maKH = cmbMaKhoa.SelectedValue.ToString().Trim();
            this.bdsGiaoVien.Filter = "MAKH = '" + maKH + "'";


            cmbCoSo.DataSource = Program.bds_dspm;
            cmbCoSo.DisplayMember = "TEN_COSO";
            cmbCoSo.ValueMember = "TEN_SERVER";
            cmbCoSo.SelectedIndex = Program.mCoso;

            if (Program.mGroup == "TRUONG")
                cmbCoSo.Enabled = true;
            else
                cmbCoSo.Enabled = false;
            gc1.Enabled = false;
            btnGhi.Enabled = btnHuy.Enabled = btnPhucHoi.Enabled = false;
            if (bdsGiaoVien.Count == 0)
                btnXoa.Enabled = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "TRUONG" || Program.mGroup == "GIAOVIEN")
            {
                MessageBox.Show("Bạn không có quyền này!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            isDangThem = true;
            bdsGiaoVien.AddNew();
            txtMaGV.Focus();
            txtMaKH.Text = maKH;
            gc1.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnRefresh.Enabled = btnPhucHoi.Enabled= btnThoat.Enabled =false;
            btnGhi.Enabled = btnHuy.Enabled  = true;
            gcGiaoVien.Enabled = false;
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
            if (txtMaKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mã khoa không được trống!", "Lỗi", MessageBoxButtons.OK);
                txtMaKH.Focus();
                return;
            }
            if (!suaKH)
                txtMaKH.Text = maKH;
            try
            {
                string sql;
                int ketQua;
                if (isDangThem)
                {
                    sql = "exec [dbo].[SP_TrungMaGV] '" + txtMaGV.Text + "'";
                    ketQua = Program.ExecSqlNonQuery(sql);
                    //nếu như chạy sp ko thành công
                    if (ketQua == 1)
                    {
                        txtMaGV.Focus();
                        return;
                    }
                }
                if (isDangThem)
                {
                    phucHoi.PushStack_ThemGV(txtMaGV.Text.Trim());
                }
                else if (isDangSua)
                {
                    phucHoi.PushStack_SuaGV(txtMaGV.Text.Trim());
                }
                bdsGiaoVien.EndEdit();
                bdsGiaoVien.ResetCurrentItem();
                this.gIAOVIENTableAdapter.Update(this.dS.GIAOVIEN);

                gc1.Enabled = false;
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = btnRefresh.Enabled = btnThoat.Enabled= true;
                btnGhi.Enabled = btnHuy.Enabled = false;
                gcGiaoVien.Enabled = true;
                txtMaGV.Enabled = true;
                isDangThem = isDangSua = false;
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
            if (Program.mGroup == "TRUONG" || Program.mGroup == "GIAOVIEN")
            {
                MessageBox.Show("Bạn không được phép xóa!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (bdsGiaoVien.Count == 0)
            {
                MessageBox.Show("Không có giáo viên nào để xóa!\n", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            else if (bds_GVDK.Count != 0)
            {
                MessageBox.Show("Giáo viên đã đăng ký lịch thi, không được xoá!\n", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            else if (bds_BoDe.Count != 0)
            {
                MessageBox.Show("Giáo viên đã có câu hỏi trong bộ đề, không được xoá!\n", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Bạn có thật sự muốn xóa giáo viên này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    maGV = ((DataRowView)bdsGiaoVien[bdsGiaoVien.Position])["MAGV"].ToString();
                    phucHoi.PushStack_XoaGV(maGV, txtHo.Text.Trim(), txtTen.Text.Trim(), txtHocVi.Text.Trim(), txtMaKH.Text.Trim());
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
            isDangSua = true;
            suaKH = true;
            phucHoi.Save_OldGV(txtHo.Text.Trim(), txtTen.Text.Trim(), txtHocVi.Text.Trim(), txtMaKH.Text.Trim());
            txtMaGV.Enabled = false;
            gc1.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnRefresh.Enabled = btnPhucHoi.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnHuy.Enabled = true;
            gcGiaoVien.Enabled = false;
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsGiaoVien.CancelEdit();

            //this.gIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            //this.gIAOVIENTableAdapter.Fill(this.dS.GIAOVIEN);
            gc1.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = btnRefresh.Enabled = true;
            btnGhi.Enabled = btnHuy.Enabled = false;
            gcGiaoVien.Enabled = true;
        }

        private void cmbMaKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbMaKhoa.SelectedValue != null)
            {
                maKH = cmbMaKhoa.SelectedValue.ToString().Trim();
                tenKH = cmbMaKhoa.GetItemText(cmbMaKhoa.SelectedItem);
                index = cmbMaKhoa.SelectedIndex;
            }
            this.bdsGiaoVien.Filter = "MAKH = '" + maKH + "'";
            cmbMaKhoa.Text = tenKH;
            btnXoa.Enabled = false;
            if (bdsGiaoVien.Count != 0)
                btnXoa.Enabled = true;
            return;
        }

        private void gcGiaoVien_Click(object sender, EventArgs e)
        {

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

                this.gIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.gIAOVIENTableAdapter.Fill(this.dS.GIAOVIEN);
                // TODO: This line of code loads data into the 'dS.BODE' table. You can move, or remove it, as needed.
                this.bODETableAdapter.Connection.ConnectionString = Program.connstr;
                this.bODETableAdapter.Fill(this.dS.BODE);
                // TODO: This line of code loads data into the 'dS.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
                this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                this.gIAOVIEN_DANGKYTableAdapter.Fill(this.dS.GIAOVIEN_DANGKY);

                dt = Program.ExecSqlDataTable("SELECT MAKH, TENKH FROM KHOA");
                cmbMaKhoa.DataSource = dt;
                cmbMaKhoa.DisplayMember = "TENKH";
                cmbMaKhoa.ValueMember = "MAKH";
                cmbMaKhoa.SelectedIndex = 0;
                if(cmbMaKhoa.SelectedValue != null)
                {
                    maKH = cmbMaKhoa.SelectedValue.ToString().Trim();
                }
                
                this.bdsGiaoVien.Filter = "MAKH = '" + maKH + "'";
                return;
            }

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string ketQua = phucHoi.PopStack();
            if (ketQua.Equals("success"))
            {
                this.gIAOVIENTableAdapter.Fill(this.dS.GIAOVIEN);
                MessageBox.Show("Phục hồi thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(ketQua, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.gIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIENTableAdapter.Fill(this.dS.GIAOVIEN);

            cmbMaKhoa.DataSource = dt;
            cmbMaKhoa.DisplayMember = "TENKH";
            cmbMaKhoa.ValueMember = "MAKH";
            cmbMaKhoa.SelectedIndex = index;
        }
    }
}
