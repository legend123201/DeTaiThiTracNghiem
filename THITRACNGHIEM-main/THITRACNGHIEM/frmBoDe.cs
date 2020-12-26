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
    public partial class frmBoDe : Form
    {
        PhucHoi phucHoi = new PhucHoi();
        Boolean isDangThem = false, isDangSua = false;
        public frmBoDe()
        {
            InitializeComponent();
        }

        private void bODEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bds_BoDe.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);
        }

        private void frmBoDe_Load(object sender, EventArgs e)
        {
            
            dS.EnforceConstraints = false;
            this.bODETableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'dS.BODE' table. You can move, or remove it, as needed.
            this.bODETableAdapter.Fill(this.dS.BODE);
            // TODO: This line of code loads data into the 'dS.CT_BAITHI' table. You can move, or remove it, as needed.
            this.cT_BAITHITableAdapter.Connection.ConnectionString = Program.connstr;
            this.cT_BAITHITableAdapter.Fill(this.dS.CT_BAITHI);

            cmb_TrinhDo.Items.Add("A");
            cmb_TrinhDo.Items.Add("B");
            cmb_TrinhDo.Items.Add("C");

            cmb_DapAn.Items.Add("A");
            cmb_DapAn.Items.Add("B");
            cmb_DapAn.Items.Add("C");
            cmb_DapAn.Items.Add("D");

            groupBox1.Enabled = false;

            if (Program.mGroup == "TRUONG")
            {
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnHuy.Enabled = btnGhi.Enabled = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          
            if (bds_BoDe.Count == 0)
            {
                MessageBox.Show("Không có câu hỏi để xóa!", "THÔNG BÁO", MessageBoxButtons.OK);
                return;
            }
            if(bds_CTBT.Count != 0)
            {
                MessageBox.Show("Câu hỏi đã có trong chi tiết bài thi, không được xoá!", "THÔNG BÁO", MessageBoxButtons.OK);
                return;
            }
            if(Program.mGroup == "GIAOVIEN")
            {
                if(Program.username != txtMaGV.Text.Trim())
                {
                    MessageBox.Show("Bạn không được hiệu chỉnh câu hỏi của người khác!", "THÔNG BÁO", MessageBoxButtons.OK);
                    return;
                }
            }
           
            if (MessageBox.Show("Bạn có thật sự muốn xoá câu hỏi này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    bds_BoDe.RemoveCurrent();
                    /*this.mONHOCTableAdapter.Update(this.dS.MONHOC);*/
                    this.bODETableAdapter.Update(this.dS.BODE);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thao tác xoá bị lỗi!\n" + ex.Message, "THÔNG BÁO", MessageBoxButtons.OK);
                }
            }         
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "GIAOVIEN")
            {
                if (Program.username != txtMaGV.Text.Trim())
                {
                    MessageBox.Show("Bạn không được hiệu chỉnh câu hỏi của người khác!", "THÔNG BÁO", MessageBoxButtons.OK);
                    return;
                }
            }
            isDangSua = true;
            
            txtMaGV.Text = txtMaGV.Text.Trim();
            txtMaMH.Text = txtMaMH.Text.Trim();
            txtNoiDung.Text = txtNoiDung.Text.Trim();
            txtA.Text = txtA.Text.Trim();
            txtB.Text = txtB.Text.Trim();
            txtC.Text = txtC.Text.Trim();
            txtD.Text = txtD.Text.Trim();
            
            txtCauHoi.Enabled = false;
            gc_BoDe.Enabled = false;
            groupBox1.Enabled = true;
            btnGhi.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnThoat.Enabled = false;
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {            
                bds_BoDe.CancelEdit();
                if (isDangThem)
                {
                    bds_BoDe.RemoveCurrent();
                }
                isDangThem = isDangSua = false;
                gc_BoDe.Enabled = true;
                groupBox1.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled  = btnThoat.Enabled = true;
                btnGhi.Enabled = btnHuy.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thao tác huỷ bị lỗi!\n" + ex.Message, "THÔNG BÁO", MessageBoxButtons.OK);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {           
            txtMaGV.Text = txtMaGV.Text.Trim();
            txtMaMH.Text = txtMaMH.Text.Trim();
            txtNoiDung.Text = txtNoiDung.Text.Trim();
            txtA.Text = txtA.Text.Trim();
            txtB.Text = txtB.Text.Trim();
            txtC.Text = txtC.Text.Trim();
            txtD.Text = txtD.Text.Trim();

            if (txtMaGV.Text.Equals(""))
            {
                MessageBox.Show("Mã giáo viên không được để trống ", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (txtMaMH.Text.Equals(""))
            {
                MessageBox.Show("Mã môn học không được để trống ", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (txtNoiDung.Text.Equals(""))
            {
                MessageBox.Show("Nội dung câu hỏi không được để trống ", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (txtA.Text.Equals(""))
            {
                MessageBox.Show("Nội dung câu A không được để trống ", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (txtB.Text.Equals(""))
            {
                MessageBox.Show("Nội dung câu B không được để trống ", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (txtC.Text.Equals(""))
            {
                MessageBox.Show("Nội dung câu C không được để trống ", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (txtD.Text.Equals(""))
            {
                MessageBox.Show("Nội dung câu D không được để trống ", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            //nếu như tất cả đều ko rỗng
            try
            {
                string sql;
                int ketQua;
                sql = "exec [dbo].[SP_TonTaiMaMH] '" + txtMaMH.Text + "'";
                ketQua = Program.ExecSqlNonQuery(sql);
                //nếu như chạy sp ko thành công
                if (ketQua == 1)
                {
                    txtMaMH.Focus();
                    return;
                }

                //nếu như tồn tại mã môn
                //nếu đang thêm thì tìm mã câu hỏi và thêm vào txtCauHoi trước khi kết thúc quá trình thêm
                if (isDangThem)
                {
                    string strLenh = "EXEC SP_TimMaBoDe";
                    Program.myReader = Program.ExecSqlDataReader(strLenh);
                    Program.myReader.Read();
                    txtCauHoi.Text = Program.myReader.GetInt32(0).ToString();
                    Program.myReader.Close();
                }

                isDangThem = isDangSua = false;
                bds_BoDe.EndEdit();
                bds_BoDe.ResetCurrentItem(); 
                //this.mONHOCTableAdapter.Update(this.dS.MONHOC);
                this.bODETableAdapter.Update(this.dS.BODE);

                gc_BoDe.Enabled = true;
                groupBox1.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnThoat.Enabled = true;
                btnGhi.Enabled = btnHuy.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thao tác lỗi!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);

            }
            MessageBox.Show("Thao tác thành công!", "Thông báo", MessageBoxButtons.OK);
        }

        

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                isDangThem = true;
                bds_BoDe.AddNew();

                gc_BoDe.Enabled = false;
                groupBox1.Enabled = true;

                txtMaGV.Text = Program.username;
                txtCauHoi.Enabled = txtMaGV.Enabled = false;
                cmb_TrinhDo.SelectedIndex = 1; cmb_TrinhDo.SelectedIndex = 0;
                cmb_DapAn.SelectedIndex = 1; cmb_DapAn.SelectedIndex = 0;
                txtNoiDung.Focus();

                btnGhi.Enabled = btnHuy.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnThoat.Enabled =false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm câu hỏi bộ đề! \n " + ex.Message, "", MessageBoxButtons.OK);
            }
        }
    }
}
