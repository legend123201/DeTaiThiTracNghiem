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
        private BindingSource bdsCoSo = new BindingSource();
        private string maKH = "";
        private bool isThemKH = false;
        private bool isThemLop = false;
        private bool isDangThem = false;
        private bool isDangSua = false;
        private bool suaKH = false;
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
            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);

            // TODO: This line of code loads data into the 'dS.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIEN_DANGKYTableAdapter.Fill(this.dS.GIAOVIEN_DANGKY);
            // TODO: This line of code loads data into the 'dS.SINHVIEN' table. You can move, or remove it, as needed.
            this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
            // TODO: This line of code loads data into the 'dS.GIAOVIEN' table. You can move, or remove it, as needed.
            this.gIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIENTableAdapter.Fill(this.dS.GIAOVIEN);

            DataTable dt = new DataTable();
            dt = Program.ExecSqlDataTable("SELECT MACS, TENCS FROM COSO");
            bdsCoSo.DataSource = dt;
            txtMaCS.Text = ((DataRowView)bdsCoSo[bdsCoSo.Position])["MACS"].ToString();

            cmbCoSo.DataSource = Program.bds_dspm;
            cmbCoSo.DisplayMember = "TEN_COSO";
            cmbCoSo.ValueMember = "TEN_SERVER";
            cmbCoSo.SelectedIndex = Program.mCoso;

            maKH = ((DataRowView)bdsKhoa[0])["MAKH"].ToString();
            this.bdsLop.Filter = "MAKH = '" + maKH + "'";

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

                // TODO: This line of code loads data into the 'dS.KHOA' table. You can move, or remove it, as needed.
                this.kHOATableAdapter.Connection.ConnectionString = Program.connstr;
                this.kHOATableAdapter.Fill(this.dS.KHOA);
                // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
                this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.lOPTableAdapter.Fill(this.dS.LOP);

                // TODO: This line of code loads data into the 'dS.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
                this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                this.gIAOVIEN_DANGKYTableAdapter.Fill(this.dS.GIAOVIEN_DANGKY);
                // TODO: This line of code loads data into the 'dS.SINHVIEN' table. You can move, or remove it, as needed.
                this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
                // TODO: This line of code loads data into the 'dS.GIAOVIEN' table. You can move, or remove it, as needed.
                this.gIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.gIAOVIENTableAdapter.Fill(this.dS.GIAOVIEN);
                
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvKhoa.IsFocusedView)
            {
                String maKH = "";
                if (Program.mGroup == "TRUONG")
                {
                    MessageBox.Show("Bạn không được phép xóa!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                if(bdsKhoa.Count == 0)
                {
                    MessageBox.Show("Không có khoa nào để xóa!\n", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                else if (bds_GiaoVien.Count != 0)
                {
                    MessageBox.Show("Khoa đã có giáo viên, không được xoá!\n", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                else if (bdsLop.Count != 0)
                {
                    MessageBox.Show("Khoa đã có lớp, không được xoá!\n", "Lỗi", MessageBoxButtons.OK);
                    return;
                }

                if (MessageBox.Show("Bạn có thật sự muốn xóa khoa này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
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
                        MessageBox.Show("Lỗi xóa khoa. Hãy xóa lại!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK);
                        this.kHOATableAdapter.Fill(this.dS.KHOA);
                        bdsKhoa.Position = bdsKhoa.Find("MAKH", maKH);
                        return;
                    }
                }
            }
            else if (gvLop.IsFocusedView)
            {
                String maLop = "";
                if (Program.mGroup == "TRUONG" || Program.mGroup == "GIAOVIEN")
                {
                    MessageBox.Show("Bạn không có quyền này!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                if (bdsLop.Count == 0)
                {
                    MessageBox.Show("Không có lớp nào để xóa!\n", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                else if (bds_SinhVien.Count != 0)
                {
                    MessageBox.Show("Lớp đã có sinh viên, không được xoá!\n", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                else if (bds_GVDK.Count != 0)
                {
                    MessageBox.Show("Lớp đã được giáo viên đăng ký lịch thi, không được xoá!\n", "Lỗi", MessageBoxButtons.OK);
                    return;
                }

                if (MessageBox.Show("Bạn có thật sự muốn xóa lớp này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        maLop = ((DataRowView)bdsLop[bdsLop.Position])["MALOP"].ToString();
                        bdsLop.RemoveCurrent();
                        this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.lOPTableAdapter.Update(this.dS.LOP);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa lớp. Hãy xóa lại!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK);
                        this.lOPTableAdapter.Fill(this.dS.LOP);
                        bdsLop.Position = bdsLop.Find("MALOP", maLop);
                        return;
                    }
                }
               
            }
            if (bdsLop.Count == 0 && bdsKhoa.Count == 0)
                btnXoa.Enabled = false;
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsKhoa.CancelEdit();
            bdsLop.CancelEdit();

            //this.kHOATableAdapter.Connection.ConnectionString = Program.connstr;
            //this.kHOATableAdapter.Fill(this.dS.KHOA);

            //this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            //this.lOPTableAdapter.Fill(this.dS.LOP);
            
            gc2.Enabled = false;
            subThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnHuy.Enabled = false;

            txtMaKH.Enabled = txtTenKH.Enabled = txtMaCS.Enabled = true;
            txtMaLop.Enabled = txtTenLop.Enabled = txtMaKH_Lop.Enabled = true;
            gcKhoa.Enabled = gcLop.Enabled = true;
            isThemKH = isThemLop = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isThemKH)
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
                    string sql;
                    int ketQua;
                    if (isDangThem)
                    {
                        sql = "exec [dbo].[SP_TrungMaKH] '" + txtMaKH.Text + "'";
                        ketQua = Program.ExecSqlNonQuery(sql);
                        //nếu như chạy sp ko thành công
                        if (ketQua == 1)
                        {
                            txtMaKH.Focus();
                            return;
                        }

                        sql = "exec [dbo].[SP_TrungTenKH] '" + txtTenKH.Text + "'";
                        ketQua = Program.ExecSqlNonQuery(sql);
                        //nếu như chạy sp ko thành công
                        if (ketQua == 1)
                        {
                            txtTenKH.Focus();
                            return;
                        }
                    }
                    //isDangSua = true
                    else if (isDangSua)
                    {
                        sql = "exec [dbo].[SP_TrungTenKH] '" + txtTenKH.Text + "'";
                        ketQua = Program.ExecSqlNonQuery(sql);
                        //nếu như chạy sp ko thành công
                        if (ketQua == 1)
                        {
                            txtTenKH.Focus();
                            return;

                        }
                    }

                    bdsKhoa.EndEdit();
                    bdsKhoa.ResetCurrentItem();
                    this.kHOATableAdapter.Update(this.dS.KHOA);
                    isThemKH = isDangSua = isDangThem = false;

                    gc2.Enabled = false;
                    subThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnRefresh.Enabled = btnThoat.Enabled= true;
                    btnGhi.Enabled = btnHuy.Enabled = false;

                    txtMaKH.Enabled = txtTenKH.Enabled = txtMaCS.Enabled = true;
                    txtMaLop.Enabled = txtTenLop.Enabled = txtMaKH_Lop.Enabled = true;
                    gcKhoa.Enabled = gcLop.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi khoa\n" + ex.Message, "Lỗi", MessageBoxButtons.OK);
                }
            }
            else if (isThemLop)
            {
                if (txtMaLop.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Mã lớp không được trống!", "Lỗi", MessageBoxButtons.OK);
                    txtMaLop.Focus();
                    return;
                }
                if (txtTenLop.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Tên lớp không được trống!", "Lỗi", MessageBoxButtons.OK);
                    txtTenLop.Focus();
                    return;
                }
                if (txtMaKH_Lop.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Mã khoa không được trống!", "Lỗi", MessageBoxButtons.OK);
                    txtMaKH_Lop.Focus();
                    return;
                }
                if (!suaKH)
                {
                    txtMaKH_Lop.Text = gvKhoa.GetRowCellValue(gvKhoa.FocusedRowHandle, "MAKH").ToString().Trim();
                }
                try
                {
                    string sql;
                    int ketQua;
                    if (isDangThem)
                    {
                        sql = "exec [dbo].[SP_TrungMaLop] '" + txtMaLop.Text + "'";
                        ketQua = Program.ExecSqlNonQuery(sql);
                        //nếu như chạy sp ko thành công
                        if (ketQua == 1)
                        {
                            txtMaLop.Focus();
                            return;
                        }

                        sql = "exec [dbo].[SP_TrungTenLop] '" + txtTenLop.Text + "'";
                        ketQua = Program.ExecSqlNonQuery(sql);
                        //nếu như chạy sp ko thành công
                        if (ketQua == 1)
                        {
                            txtTenLop.Focus();
                            return;
                        }
                    }
                    //isDangSua = true
                    else if (isDangSua)
                    {
                        sql = "exec [dbo].[SP_TrungTenLop] '" + txtTenLop.Text + "'";
                        ketQua = Program.ExecSqlNonQuery(sql);
                        //nếu như chạy sp ko thành công
                        if (ketQua == 1)
                        {
                            txtTenLop.Focus();
                                return;
                            
                        }
                    }

                    bdsLop.EndEdit();
                    bdsLop.ResetCurrentItem();
                    this.lOPTableAdapter.Update(this.dS.LOP);
                    isThemLop = isDangSua = isDangThem = false;
                    suaKH = false;
                    gc2.Enabled = false;
                    subThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnRefresh.Enabled = true;
                    btnGhi.Enabled = btnHuy.Enabled = false;

                    txtMaKH.Enabled = txtTenKH.Enabled = txtMaCS.Enabled = true;
                    txtMaLop.Enabled = txtTenLop.Enabled = txtMaKH_Lop.Enabled = true;
                    gcKhoa.Enabled = gcLop.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi lớp\n" + ex.Message, "Lỗi", MessageBoxButtons.OK);
                }
            }
            
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "TRUONG" || Program.mGroup == "GIAOVIEN")
            {
                MessageBox.Show("Bạn không có quyền này!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (gvKhoa.IsFocusedView)
            {
                if (gvKhoa.IsEmpty)
                {
                    MessageBox.Show("Không có gì để sửa!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                    
                isThemKH = isDangSua = true;
                gc2.Enabled = true;
                txtMaKH.Focus();

                txtMaKH.Enabled = false;
                subThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnRefresh.Enabled = btnThoat.Enabled =false;
                btnGhi.Enabled = btnHuy.Enabled = true;

                txtMaLop.Enabled = txtTenLop.Enabled = txtMaKH_Lop.Enabled = false;
                gcKhoa.Enabled = gcLop.Enabled = false;
            }
            else if (gvLop.IsFocusedView)
            {
                if (gvLop.IsEmpty)
                {
                    MessageBox.Show("Không có gì để sửa!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                isThemLop = isDangSua = true;
                gc2.Enabled = true;
                txtTenLop.Focus();
                suaKH = true;
                txtMaLop.Enabled = false;
                txtMaKH_Lop.Enabled = true;
                subThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnRefresh.Enabled = btnThoat.Enabled =false;
                btnGhi.Enabled = btnHuy.Enabled = true;

                txtMaKH.Enabled = txtTenKH.Enabled = txtMaCS.Enabled = false;
                gcKhoa.Enabled = gcLop.Enabled = false;
            }
            else
            {
                gc2.Enabled = true;
                subThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnRefresh.Enabled = false;
                btnGhi.Enabled = btnHuy.Enabled = true;
                gcKhoa.Enabled = gcLop.Enabled = false;
                return;
            }
            
        }

        private void cmbMaCS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gcKhoa_Click(object sender, EventArgs e)
        {
            
        }

        private void gvKhoa_Click(object sender, EventArgs e)
        {
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);

            maKH = gvKhoa.GetRowCellValue(gvKhoa.FocusedRowHandle, "MAKH").ToString();
            this.bdsLop.Filter = "MAKH = '" + maKH + "'";
        }

        private void gvKhoa_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            
        }

        private void btnAddKhoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "TRUONG" || Program.mGroup == "GIAOVIEN")
            {
                MessageBox.Show("Bạn không có quyền này!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            isThemKH = isDangThem = true;
            gc2.Enabled = true;
            bdsKhoa.AddNew();
            txtMaKH.Focus();
            txtMaCS.Text = ((DataRowView)bdsCoSo[bdsCoSo.Position])["MACS"].ToString();
            txtMaKH.Enabled = true;
            subThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnRefresh.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnHuy.Enabled = true;

            txtMaLop.Enabled = txtTenLop.Enabled = txtMaKH_Lop.Enabled = false;
            gcKhoa.Enabled = gcLop.Enabled = false;
            
        }

        private void btnAddLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "TRUONG" || Program.mGroup == "GIAOVIEN")
            {
                MessageBox.Show("Bạn không có quyền này!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            isThemLop = isDangThem = true;
            gc2.Enabled = true;
            bdsLop.AddNew();
            txtMaLop.Focus();

            txtMaKH_Lop.Text = gvKhoa.GetRowCellValue(gvKhoa.FocusedRowHandle, "MAKH").ToString().Trim();
            txtMaLop.Enabled = true;
            subThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnRefresh.Enabled = false;
            btnGhi.Enabled = btnHuy.Enabled = true;

            txtMaKH.Enabled = txtTenKH.Enabled = txtMaCS.Enabled = false;
            gcKhoa.Enabled = gcLop.Enabled = false;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.KHOA' table. You can move, or remove it, as needed.
            this.kHOATableAdapter.Connection.ConnectionString = Program.connstr;
            this.kHOATableAdapter.Fill(this.dS.KHOA);
            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);
        }
    }
}
