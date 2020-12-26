using DevExpress.Utils.Extensions;
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
    public partial class frmMonHoc : Form
    {
        PhucHoi phucHoi = new PhucHoi();
        Boolean isDangThem = false, isDangSua = false;
        public frmMonHoc()
        {
            InitializeComponent();
        }

        private void mONHOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bds_MonHoc.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        
        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.dS.MONHOC);

            // TODO: This line of code loads data into the 'dS.BODE' table. You can move, or remove it, as needed.
            this.bODETableAdapter.Connection.ConnectionString = Program.connstr;
            this.bODETableAdapter.Fill(this.dS.BODE);
            // TODO: This line of code loads data into the 'dS.BANGDIEM' table. You can move, or remove it, as needed.
            this.bANGDIEMTableAdapter.Connection.ConnectionString = Program.connstr;
            this.bANGDIEMTableAdapter.Fill(this.dS.BANGDIEM);
            // TODO: This line of code loads data into the 'dS.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIEN_DANGKYTableAdapter.Fill(this.dS.GIAOVIEN_DANGKY);

            groupBox1.Enabled = false;
            btnGhi.Enabled = btnHuy.Enabled = false;

            if (Program.mGroup != "COSO")
            {
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnPhucHoi.Enabled = btnHuy.Enabled = btnGhi.Enabled = false;
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                isDangThem = true;
                bds_MonHoc.AddNew();
                
                gc_MonHoc.Enabled = false;      
                groupBox1.Enabled = true;
                
                txtMaMH.Focus();
                txtMaMH.Enabled = true;
                
                btnGhi.Enabled = btnHuy.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnPhucHoi.Enabled = btnThoat.Enabled = btnRefresh.Enabled =  false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm môn học " + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMaMH.Text = txtMaMH.Text.Trim();
            txtTenMH.Text= txtTenMH.Text.Trim();
            if (txtMaMH.Text.Equals(""))
            {
                MessageBox.Show("Mã môn học không được để trống ", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (txtTenMH.Text.Equals(""))
            {
                MessageBox.Show("Tên môn học không được để trống ", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            //nếu như tất cả đều ko rỗng
            try
            {
                string sql;
                int ketQua;
                if (isDangThem)
                {
                    sql = "exec [dbo].[SP_TrungMaMH] '" + txtMaMH.Text + "'";
                    ketQua = Program.ExecSqlNonQuery(sql);
                    //nếu như chạy sp ko thành công
                    if (ketQua == 1)
                    {
                        txtMaMH.Focus();
                        return;
                    }

                    sql = "exec [dbo].[SP_TrungTenMH] '" + txtTenMH.Text + "'";
                    ketQua = Program.ExecSqlNonQuery(sql);
                    //nếu như chạy sp ko thành công
                    if (ketQua == 1)
                    {
                        txtMaMH.Focus();
                        return;
                    }
                }
                //isDangSua = true
                else if(isDangSua)
                {
                    string oldTenMH = phucHoi.GetDataTruocKhiSua();

                    if (txtTenMH.Text != oldTenMH)
                    {
                        sql = "exec [dbo].[SP_TrungTenMH] '" + txtTenMH.Text + "'";
                        ketQua = Program.ExecSqlNonQuery(sql);
                        //nếu như chạy sp ko thành công
                        if (ketQua == 1)
                        {
                            txtMaMH.Focus();
                            return;
                        }
                    }
                }

                // nếu như không trùng gì hết
                if (isDangThem)
                {
                    phucHoi.PushStack_ThemMH(txtMaMH.Text);
                    isDangThem = false;
                }
                else if (isDangSua)
                {
                    phucHoi.PushStack_SuaMH(txtMaMH.Text, txtTenMH.Text);
                    isDangSua = false;
                }
                bds_MonHoc.EndEdit();
                bds_MonHoc.ResetCurrentItem(); 
                this.mONHOCTableAdapter.Update(this.dS.MONHOC);
              
                gc_MonHoc.Enabled = true;
                groupBox1.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnPhucHoi.Enabled = btnRefresh.Enabled = btnThoat.Enabled = true;
                btnGhi.Enabled = btnHuy.Enabled = false;
            }
            catch(Exception ex) {
                MessageBox.Show("Thao tác lỗi!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                
            }
            //MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bds_MonHoc.Count == 0)
            {
                MessageBox.Show("Không có môn học để xóa!", "THÔNG BÁO", MessageBoxButtons.OK);
            }
            else if (bds_BoDe.Count != 0)
            {
                MessageBox.Show("Môn học đã có câu hỏi trong bộ đề, không thể xoá!", "THÔNG BÁO", MessageBoxButtons.OK);
            }
            else if (bds_GVDK.Count != 0)
            {
                MessageBox.Show("Môn học đã có giáo viên đăng ký thi, không thể xoá!", "THÔNG BÁO", MessageBoxButtons.OK);
            }
            else if (bds_BangDiem.Count != 0)
            {
                MessageBox.Show("Môn học đã có bảng điểm, không thể xoá!", "THÔNG BÁO", MessageBoxButtons.OK);
            }
            else
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa môn học này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        phucHoi.PushStack_XoaMH(txtMaMH.Text, txtTenMH.Text);
                        bds_MonHoc.RemoveCurrent();
                        this.mONHOCTableAdapter.Update(this.dS.MONHOC);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thao tác xoá bị lỗi!\n" + ex.Message, "THÔNG BÁO", MessageBoxButtons.OK);
                    }


                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isDangSua = true;
            txtMaMH.Enabled = false;
            txtTenMH.Text = txtTenMH.Text.Trim();
            phucHoi.Save_OldMH(txtTenMH.Text);
            gc_MonHoc.Enabled = false;
            groupBox1.Enabled = true;
            btnGhi.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnPhucHoi.Enabled = btnThoat.Enabled = btnRefresh.Enabled = false;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           string ketQua = phucHoi.PopStack();
            if (ketQua.Equals("success"))
            {
                //update lại dataTable Môn học
                this.mONHOCTableAdapter.Fill(this.dS.MONHOC);
                this.bODETableAdapter.Fill(this.dS.BODE);
                MessageBox.Show("Phục hồi thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(ketQua, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;            
            this.mONHOCTableAdapter.Fill(this.dS.MONHOC);

            // TODO: This line of code loads data into the 'dS.BODE' table. You can move, or remove it, as needed.            
            this.bODETableAdapter.Fill(this.dS.BODE);
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //MessageBox.Show("Không có môn học để xóa!", "THÔNG BÁO", MessageBoxButtons.YesNo,);
            try
            {
               
                bds_MonHoc.CancelEdit();
                if (isDangThem)
                {
                    bds_MonHoc.RemoveCurrent();
                }
                isDangThem = isDangSua = false;
                gc_MonHoc.Enabled = true;
                groupBox1.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnPhucHoi.Enabled = btnThoat.Enabled = btnRefresh.Enabled = true;
                btnGhi.Enabled = btnHuy.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Thao tác huỷ bị lỗi!\n" + ex.Message, "THÔNG BÁO", MessageBoxButtons.OK);
            }
            
        }
    }
}
