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
    public partial class frmTaoTK : Form
    {
        private string TenGV = "";
        private string user = "";
        public frmTaoTK()
        {
            InitializeComponent();
        }

        private void frmTaoTK_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.GIAOVIEN' table. You can move, or remove it, as needed.
            this.gIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIENTableAdapter.Fill(this.dS.GIAOVIEN);

            if(Program.mGroup == "TRUONG")
            {
                cmbGroup.Items.Add("TRUONG");
            }
            else if (Program.mGroup == "COSO")
            {
                cmbGroup.Items.Add("COSO");
                cmbGroup.Items.Add("GIAOVIEN");
            }
                
            cmbGroup.SelectedIndex = 0;

            grcDSGV.Visible = false;
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            string sql = "EXEC SP_TaoTaiKhoan '" + txtLogin.Text.Trim() + "', '" + txtPassword.Text.Trim() + "', '" + user + "', '" + cmbGroup.SelectedItem.ToString().Trim() + "'";
            if (Program.ExecSqlNonQuery(sql) == 0)
            {
                MessageBox.Show("Tạo tài khoản thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            grcDSGV.Visible = false;
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            grcDSGV.Visible = true;
            TenGV = gvGiaoVien.GetRowCellValue(gvGiaoVien.FocusedRowHandle, "TEN").ToString().Trim();
            user = gvGiaoVien.GetRowCellValue(gvGiaoVien.FocusedRowHandle, "MAGV").ToString().Trim();

        }

        private void btnChon_Leave(object sender, EventArgs e)
        {
            txtUser.Text = TenGV;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gcGiaoVien_Click(object sender, EventArgs e)
        {
            TenGV = gvGiaoVien.GetRowCellValue(gvGiaoVien.FocusedRowHandle, "TEN").ToString();
            user = gvGiaoVien.GetRowCellValue(gvGiaoVien.FocusedRowHandle, "MAGV").ToString();
            txtUser.Text = TenGV;
        }
    }
}
