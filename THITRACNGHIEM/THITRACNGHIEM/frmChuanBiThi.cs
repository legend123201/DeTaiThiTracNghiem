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
    public partial class frmChuanBiThi : Form
    {
        public static string maMH = "";
        public static string maLop = "";
        int vitri;

        public frmChuanBiThi()
        {
            InitializeComponent();
        }

        private void gIAOVIEN_DANGKYBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsGV_DK.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmChuanBiThi_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIEN_DANGKYTableAdapter.Fill(this.dS.GIAOVIEN_DANGKY);

            cmbTrinhDo.Items.Add("A");
            cmbTrinhDo.Items.Add("B");
            cmbTrinhDo.Items.Add("C");
            cmbTrinhDo.SelectedIndex = 0;

            cmbCoSo.DataSource = Program.bds_dspm;
            cmbCoSo.DisplayMember = "TEN_COSO";
            cmbCoSo.ValueMember = "TEN_SERVER";
            cmbCoSo.SelectedIndex = Program.mCoso;

            if (Program.mGroup == "TRUONG")
                cmbCoSo.Enabled = true;
            else
                cmbCoSo.Enabled = false;
            grcInFor.Enabled = false;
            btnGhi.Enabled = false;
            if (bdsGV_DK.Count == 0)
                btnXoa.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnChonMH_Click(object sender, EventArgs e)
        {
            txtMaMH.Text = "";
            frmChonMH f = new frmChonMH();
            f.Show();
        }

        private void btnChonLop_Click(object sender, EventArgs e)
        {
            txtMaLop.Text = "";
            frmChonLop f = new frmChonLop();
            f.Show();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "TRUONG" || Program.mGroup == "GIAOVIEN")
            {
                MessageBox.Show("Bạn không có quyền này!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            vitri = bdsGV_DK.Position;
            bdsGV_DK.AddNew();
            txtMaGV.Text = Program.username;
            
            txtMaMH.Focus();
            dptNgayThi.EditValue = "";

            grcInFor.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnHuy.Enabled = true;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMaGV.Text = Program.username;
            if(txtMaMH.Text == "")
                txtMaMH.Text = maMH;
            if(txtMaLop.Text == "")
            txtMaLop.Text = maLop;
            cmbTrinhDo.Text = cmbTrinhDo.SelectedIndex.ToString();
            if(txtMaMH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mã môn học không được trống!", "Lỗi", MessageBoxButtons.OK);
                txtMaMH.Focus();
                return;
            }
            if (txtMaLop.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mã lớp không được trống!", "Lỗi", MessageBoxButtons.OK);
                txtMaLop.Focus();
                return;
            }
            if (dptNgayThi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ngày thi không được trống!", "Lỗi", MessageBoxButtons.OK);
                dptNgayThi.Focus();
                return;
            }
            if (spinLan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Lần thi không được trống!", "Lỗi", MessageBoxButtons.OK);
                spinLan.Focus();
                return;
            }
            if (spinSoCau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Số câu thi không được trống!", "Lỗi", MessageBoxButtons.OK);
                spinSoCau.Focus();
                return;
            }
            if (spinThoiGian.Text.Trim().Length == 0)
            {
                MessageBox.Show("Thời gian thi không được trống!", "Lỗi", MessageBoxButtons.OK);
                spinThoiGian.Focus();
                return;
            }
            string sql = "EXEC SP_CHUANBITHI '" + txtMaMH.Text.Trim() + "', '" + cmbTrinhDo.Text.Trim() + "', '" + spinSoCau.Text.Trim() + "'";
            int ketQua = Program.ExecSqlNonQuery(sql);
            if(ketQua == 1)
            {
                return;
            }
            try
            {
                bdsGV_DK.EndEdit();
                bdsGV_DK.ResetCurrentItem();
                this.gIAOVIEN_DANGKYTableAdapter.Update(this.dS.GIAOVIEN_DANGKY);

                grcInFor.Enabled = false;
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                btnGhi.Enabled = btnHuy.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi đăng ký thi\n" + ex.Message, "Lỗi", MessageBoxButtons.OK);
            }
        }

        private void cmbTrinhDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "TRUONG" || Program.mGroup == "GIAOVIEN")
            {
                MessageBox.Show("Bạn không có quyền này!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            grcInFor.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnHuy.Enabled = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "TRUONG" || Program.mGroup == "GIAOVIEN")
            {
                MessageBox.Show("Bạn không có quyền này!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (bdsGV_DK.Count == 0)
            {
                MessageBox.Show("Không có lịch thi để xóa!", "Thông báo", MessageBoxButtons.OK);
                btnXoa.Enabled = false;
            }
            else
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa lịch thi này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        bdsGV_DK.RemoveCurrent();
                        this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.gIAOVIEN_DANGKYTableAdapter.Update(this.dS.GIAOVIEN_DANGKY);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa sinh viên. Hãy xóa lại!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK);
                        this.gIAOVIEN_DANGKYTableAdapter.Fill(this.dS.GIAOVIEN_DANGKY);
                        return;
                    }
                }
            }
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsGV_DK.RemoveCurrent();
            this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIEN_DANGKYTableAdapter.Fill(this.dS.GIAOVIEN_DANGKY);

            grcInFor.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = btnHuy.Enabled = false;
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

                this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                this.gIAOVIEN_DANGKYTableAdapter.Fill(this.dS.GIAOVIEN_DANGKY);
                cmbTrinhDo.SelectedIndex = 0;
            }
        }

        private void txtMaMH_Click(object sender, EventArgs e)
        {
            if (txtMaMH.Text == "")
                txtMaMH.Text = maMH;
            
        }

        private void txtMaLop_Click(object sender, EventArgs e)
        {
            if (txtMaLop.Text == "")
                txtMaLop.Text = maLop;
        }

        private void grcCoSo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
