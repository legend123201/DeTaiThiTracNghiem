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
            // TODO: This line of code loads data into the 'dS.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.dS.MONHOC);

            groupBox1.Enabled = false;
            btnGhi.Enabled = btnHuy.Enabled = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                isDangThem = true;
                bds_MonHoc.AddNew();
                //gcMH.Enabled = false;
                gc_MonHoc.Enabled = false;
                //edtTenMH.Enabled = edtMaMH.Enabled = true;
                groupBox1.Enabled = true;
                //edtMaMH.Focus();
                txtMaMH.Focus();
                //btnThemMH.Enabled = btnSuaMH.Enabled = btnTaiLaiMH.Enabled = btnXoaMH.Enabled = btnTim.Enabled = edtTim.Enabled = false;
                btnGhi.Enabled = btnHuy.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnPhucHoi.Enabled = btnThoat.Enabled =  false;
                //checkThem = true;
                //checkSave = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm môn học " + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaMH.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mã môn học không được để trống ", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (txtTenMH.Text.Trim().Equals(""))
            {
                MessageBox.Show("Tên môn học không được để trống ", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            try
            {
                if (isDangThem)
                {
                    phucHoi.PushStack_ThemMH(txtMaMH.Text);
                }
                else if (isDangSua)
                {
                    phucHoi.PushStack_SuaMH(txtMaMH.Text);
                }
                bds_MonHoc.EndEdit();
                bds_MonHoc.ResetCurrentItem(); //chọn item vừa thêm là vị trí hiện tại đang trỏ tới
                this.mONHOCTableAdapter.Update(this.dS.MONHOC);
              
                gc_MonHoc.Enabled = true;
                groupBox1.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnPhucHoi.Enabled = true;
                btnGhi.Enabled = btnHuy.Enabled = false;
            }
            catch(Exception ex) {
                MessageBox.Show("Thao tác lỗi!", "Thông báo", MessageBoxButtons.OK);
                
            }
            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bds_MonHoc.Count == 0)
            {
                MessageBox.Show("Không có môn học để xóa!", "THÔNG BÁO", MessageBoxButtons.OK);
            }
            else
            {
                phucHoi.PushStack_XoaMH(txtMaMH.Text, txtTenMH.Text);
                bds_MonHoc.RemoveCurrent();
                this.mONHOCTableAdapter.Update(this.dS.MONHOC);
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isDangSua = true;
            phucHoi.Save_OldMH(txtMaMH.Text, txtTenMH.Text);
            gc_MonHoc.Enabled = false;
            groupBox1.Enabled = true;
            btnGhi.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnPhucHoi.Enabled = btnThoat.Enabled = false;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           string ketQua = phucHoi.PopStack_MH();
            if (ketQua.Equals("success"))
            {
                //update lại dataTable Môn học
                this.mONHOCTableAdapter.Fill(this.dS.MONHOC);
            }
            else
            {
                MessageBox.Show(ketQua, "Thông báo", MessageBoxButtons.OK);
            }
            
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //MessageBox.Show("Không có môn học để xóa!", "THÔNG BÁO", MessageBoxButtons.YesNo,);
            isDangThem = isDangSua = false;
            bds_MonHoc.CancelEdit();
            gc_MonHoc.Enabled = true;
            groupBox1.Enabled = false;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnPhucHoi.Enabled = btnThoat.Enabled = true;
            btnGhi.Enabled = btnHuy.Enabled = false;
        }
    }
}
