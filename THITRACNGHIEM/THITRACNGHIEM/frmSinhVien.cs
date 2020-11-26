using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THITRACNGHIEM
{
    public partial class frmSinhVien : Form
    {
        private string maCS = "";
        private string maLop = "";
        private int vitri;
        DataTable dt = new DataTable();
        private PhucHoi phucHoi = new PhucHoi();
        private Boolean isDangThem = false, isDangSua = false;

        public frmSinhVien()
        {
            InitializeComponent();
        }

        private void sINHVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsSinhVien.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;
            

            // TODO: This line of code loads data into the 'dS.SINHVIEN' table. You can move, or remove it, as needed.
            this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);

            // TODO: This line of code loads data into the 'dS.BANGDIEM' table. You can move, or remove it, as needed.
            this.bANGDIEMTableAdapter.Connection.ConnectionString = Program.connstr;
            this.bANGDIEMTableAdapter.Fill(this.dS.BANGDIEM);

            dt = Program.ExecSqlDataTable("SELECT MALOP, TENLOP FROM LOP");
            cmbMaLop.DataSource = dt;
            cmbMaLop.DisplayMember = "TENLOP";
            cmbMaLop.ValueMember = "MALOP";
            cmbMaLop.SelectedIndex = 0;

            this.bdsSinhVien.Filter = "MALOP = '" + cmbMaLop.SelectedValue.ToString() + "'";
            
            cmbCoSo.DataSource = Program.bds_dspm;
            cmbCoSo.DisplayMember = "TEN_COSO";
            cmbCoSo.ValueMember = "TEN_SERVER";
            cmbCoSo.SelectedIndex = Program.mCoso;
            if (Program.mGroup == "TRUONG")
                cmbCoSo.Enabled = true;
            else
                cmbCoSo.Enabled = false;
            groupControl2.Enabled = false;
            btnGhi.Enabled = btnPhuchoi.Enabled = false;
            if (bdsSinhVien.Count == 0)
                btnXoa.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "TRUONG" || Program.mGroup == "GIAOVIEN")
            {
                MessageBox.Show("Bạn không có quyền này!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            isDangThem = true;
            vitri = bdsSinhVien.Position;
            groupControl2.Enabled = true;
            bdsSinhVien.AddNew();
            txtMaSV.Focus();
            dtpNgaySinh.EditValue = "";
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnPhuchoi.Enabled = btnHuy.Enabled = true;
            //gcSinhVien.Enabled = false;
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
               
                this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);

                dt = Program.ExecSqlDataTable("SELECT MALOP, TENLOP FROM LOP");
                cmbMaLop.DataSource = dt;
                cmbMaLop.DisplayMember = "TENLOP";
                cmbMaLop.ValueMember = "MALOP";
                cmbMaLop.SelectedIndex = 0;

                this.bdsSinhVien.Filter = "MALOP = '" + cmbMaLop.SelectedValue.ToString() + "'";

            }
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsSinhVien.RemoveCurrent();
            this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
            groupControl2.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = btnHuy.Enabled = false;
            gcSinhVien.Enabled = true;
        }

        private void cmbMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbMaLop.SelectedValue != null)
            {
                maLop = cmbMaLop.SelectedValue.ToString();
                this.bdsSinhVien.Filter = "MALOP = '" + cmbMaLop.SelectedValue.ToString() + "'";
            }
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(txtMaSV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mã sinh viên không được trống!", "Lỗi", MessageBoxButtons.OK);
                txtMaSV.Focus();
                return;
            }
            if (txtHo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Họ sinh viên không được trống!", "Lỗi", MessageBoxButtons.OK);
                txtHo.Focus();
                return;
            }
            if (txtTen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Tên sinh viên không được trống!", "Lỗi", MessageBoxButtons.OK);
                txtTen.Focus();
                return;
            }
            if (dtpNgaySinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ngày sinh không được trống!", "Lỗi", MessageBoxButtons.OK);
                dtpNgaySinh.Focus();
                return;
            }
            txtMaLop.Text = maLop;
            try
            {
                if (isDangThem)
                {
                    phucHoi.PushStack_ThemSV(txtMaSV.Text);
                    isDangThem = false;
                }
                else if (isDangSua)
                {
                    phucHoi.PushStack_SuaSV(txtMaSV.Text);
                    isDangSua = false;
                }
                bdsSinhVien.EndEdit();
                bdsSinhVien.ResetCurrentItem();
                this.sINHVIENTableAdapter.Update(this.dS.SINHVIEN);

                groupControl2.Enabled = false;
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                btnGhi.Enabled = btnHuy.Enabled = false;
                gcSinhVien.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi sinh viên\n" + ex.Message, "Lỗi", MessageBoxButtons.OK);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Int32 maSV = 0;
            if (Program.mGroup == "TRUONG" || Program.mGroup == "GIAOVIEN")
            {
                MessageBox.Show("Bạn không có quyền này!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            
            if (bdsSinhVien.Count == 0)
            {
                MessageBox.Show("Không có sinh viên để xóa!", "Thông báo", MessageBoxButtons.OK);
                btnXoa.Enabled = false;
            }
            else
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        phucHoi.PushStack_XoaSV(txtMaSV.Text, txtHo.Text, txtTen.Text, dtpNgaySinh.Text, txtDiaChi.Text, cmbMaLop.SelectedIndex.ToString());
                        maSV = int.Parse(((DataRowView)bdsSinhVien[bdsSinhVien.Position])["MASV"].ToString());
                        bdsSinhVien.RemoveCurrent();
                        this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.sINHVIENTableAdapter.Update(this.dS.SINHVIEN);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa sinh viên. Hãy xóa lại!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK);
                        this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
                        bdsSinhVien.Position = bdsSinhVien.Find("MASV", maSV);
                        return;
                    }
                }
            }  
        }

        private void btnPhuchoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string ketQua = phucHoi.PopStack();
            if (ketQua.Equals("success"))
            {
                //update lại dataTable sinh viên
                this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
                MessageBox.Show("Phục hồi thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                btnPhuchoi.Enabled = false;
                MessageBox.Show(ketQua, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "TRUONG" || Program.mGroup == "GIAOVIEN")
            {
                MessageBox.Show("Bạn không có quyền này!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            isDangSua = true;
            phucHoi.Save_OldSV(txtMaSV.Text, txtHo.Text, txtTen.Text, dtpNgaySinh.Text, txtDiaChi.Text, cmbMaLop.SelectedIndex.ToString());
            groupControl2.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnPhuchoi.Enabled = btnHuy.Enabled = true;
        }
    }
}