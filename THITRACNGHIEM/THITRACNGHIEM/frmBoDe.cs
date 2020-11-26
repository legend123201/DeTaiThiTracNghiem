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

            cmb_TrinhDo.Items.Add("A");
            cmb_TrinhDo.Items.Add("B");
            cmb_TrinhDo.Items.Add("C");

            cmb_DapAn.Items.Add("A");
            cmb_DapAn.Items.Add("B");
            cmb_DapAn.Items.Add("C");
            cmb_DapAn.Items.Add("D");

            groupBox1.Enabled = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bds_BoDe.Count == 0)
            {
                MessageBox.Show("Không có câu hỏi để xóa!", "THÔNG BÁO", MessageBoxButtons.OK);
            }
            /*else if (bds_BoDe.Count != 0)
            {
                MessageBox.Show("Môn học đã có câu hỏi trong bộ đề, không thể xoá!", "THÔNG BÁO", MessageBoxButtons.OK);
            }*/
            else
            {
                if (MessageBox.Show("Bạn có thật sự muốn câu hỏi này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        
                        phucHoi.PushStack_XoaBD(int.Parse(spinMaCauHoi.Text), txtMaGV.Text, txtMaMH.Text, cmb_TrinhDo.Text, txtNoiDung.Text, txtA.Text, txtB.Text, txtC.Text, txtD.Text, cmb_DapAn.Text);
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
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isDangSua = true;
            /*txtMaMH.Text = txtMaMH.Text.Trim();
            txtTenMH.Text = txtTenMH.Text.Trim();
            phucHoi.Save_OldMH(txtMaMH.Text, txtTenMH.Text);*/

            spinMaCauHoi.Text = spinMaCauHoi.Text.Trim();
            txtMaGV.Text = txtMaGV.Text.Trim();
            txtMaMH.Text = txtMaMH.Text.Trim();
            txtNoiDung.Text = txtNoiDung.Text.Trim();
            txtA.Text = txtA.Text.Trim();
            txtB.Text = txtB.Text.Trim();
            txtC.Text = txtC.Text.Trim();
            txtD.Text = txtD.Text.Trim();
            phucHoi.Save_OldBD(txtMaGV.Text, txtMaMH.Text, cmb_TrinhDo.Text, txtNoiDung.Text, txtA.Text, txtB.Text, txtC.Text, txtD.Text, cmb_DapAn.Text);

            gc_BoDe.Enabled = false;
            groupBox1.Enabled = true;
            btnGhi.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnPhucHoi.Enabled = btnThoat.Enabled = false;
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
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnPhucHoi.Enabled = btnThoat.Enabled = true;
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
            spinMaCauHoi.Text = spinMaCauHoi.Text.Trim();//dòng này vô dụng
            txtNoiDung.Focus();//khi đang focus vào ô spin mã câu hỏi, thì nó tự thêm dấu "." cuối con số, thêm dòng này để nó focus sang dòng khác và làm mất dấu "."
            txtMaGV.Text = txtMaGV.Text.Trim();
            txtMaMH.Text = txtMaMH.Text.Trim();
            txtNoiDung.Text = txtNoiDung.Text.Trim();
            txtA.Text = txtA.Text.Trim();
            txtB.Text = txtB.Text.Trim();
            txtC.Text = txtC.Text.Trim();
            txtD.Text = txtD.Text.Trim();
            if (spinMaCauHoi.Text.Equals(""))
            {
                MessageBox.Show("Mã câu hỏi không được để trống ", "Thông báo", MessageBoxButtons.OK);
                return;
            }

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
                if (isDangThem)
                {
                    sql = "exec [dbo].[SP_TonTaiMaMH] '" + txtMaMH.Text + "'";
                    ketQua = Program.ExecSqlNonQuery(sql);
                    //nếu như chạy sp ko thành công
                    if (ketQua == 1)
                    {
                        txtMaMH.Focus();
                        return;
                    }

                    sql = "exec [dbo].[SP_TrungMaCauHoi] '" + spinMaCauHoi.Text + "'";
                    ketQua = Program.ExecSqlNonQuery(sql);
                    //nếu như chạy sp ko thành công
                    if (ketQua == 1)
                    {
                        txtMaMH.Focus();
                        return;
                    }
                }
                //isDangSua = true
                else
                {
                    string[] oldBD = phucHoi.GetDataTruocKhiSua().Split('/');

                    if (txtMaMH.Text != oldBD[2])
                    {
                        sql = "exec [dbo].[SP_TonTaiMaMH] '" + txtMaMH.Text + "'";
                        ketQua = Program.ExecSqlNonQuery(sql);
                        //nếu như chạy sp ko thành công
                        if (ketQua == 1)
                        {
                            txtMaMH.Focus();
                            return;
                        }
                    }

                    if (spinMaCauHoi.Text != oldBD[0])
                    {
                        sql = "exec [dbo].[SP_TrungMaCauHoi] '" + spinMaCauHoi.Text + "'";
                        ketQua = Program.ExecSqlNonQuery(sql);
                        //nếu như chạy sp ko thành công
                        if (ketQua == 1)
                        {
                            txtMaMH.Focus();
                            return;
                        }
                    }
                }

                //nếu như không trùng gì hết
                if (isDangThem)
                {
                    //làm hàm tự thêm vào csdl, vì cái add new trong đây sẽ tự động thêm mã câu hỏi nhưng sql lại ko cần                 
                    //Program.ExecSqlNonQuery("exec[dbo].[SP_ThemBD] " + "'" + txtMaGV.Text + "', '" + txtMaMH.Text + "', '" + cmb_TrinhDo.Text + "', N'" + txtNoiDung.Text + "', N'" + txtA.Text + "', N'" + txtB.Text + "', N'" + txtC.Text + "', N'" + txtD.Text + "', '" + cmb_DapAn.Text + "'");
                    phucHoi.PushStack_ThemBD(int.Parse(spinMaCauHoi.Text));
                    isDangThem = false;
                }
                else if (isDangSua)
                {
                    phucHoi.PushStack_SuaBD(int.Parse(spinMaCauHoi.Text));
                    isDangSua = false;
                }
                bds_BoDe.EndEdit();
                bds_BoDe.ResetCurrentItem(); //chọn item vừa thêm là vị trí hiện tại đang trỏ tới
                //this.mONHOCTableAdapter.Update(this.dS.MONHOC);
                this.bODETableAdapter.Update(this.dS.BODE);

                gc_BoDe.Enabled = true;
                groupBox1.Enabled = false;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnPhucHoi.Enabled = true;
                btnGhi.Enabled = btnHuy.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thao tác lỗi!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);

            }
            MessageBox.Show("Thao tác thành công!", "Thông báo", MessageBoxButtons.OK);
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string ketQua = phucHoi.PopStack();
            if (ketQua.Equals("success"))
            {
                //update lại dataTable BỘ ĐỀ
                this.bODETableAdapter.Fill(this.dS.BODE);
                //MessageBox.Show("Phục hồi thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(ketQua, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                isDangThem = true;
                bds_BoDe.AddNew();
                
                gc_BoDe.Enabled = false;        
                groupBox1.Enabled = true;

                //if(bds_BoDe.Count == 0)
                //{
                //    spinMaCauHoi.Text = "1";
                //}
                //else
                //{
                //    int maxMaCauHoi = -1;
                //    for(int i = 0; i < bds_BoDe.Count - 1; i++)
                //    {
                //        if(int.Parse(((DataRowView)bds_BoDe[i])["CAUHOI"].ToString()) > maxMaCauHoi)
                //        {
                //            maxMaCauHoi = int.Parse(((DataRowView)bds_BoDe[i])["CAUHOI"].ToString());
                //        }
                //    }
                //    maxMaCauHoi++;
                //    spinMaCauHoi.Text = maxMaCauHoi.ToString();
                //}
                
                txtMaGV.Text = Program.username;
                txtMaGV.Enabled = false;
                cmb_TrinhDo.SelectedIndex = 1; cmb_TrinhDo.SelectedIndex = 0;
                cmb_DapAn.SelectedIndex = 1; cmb_DapAn.SelectedIndex = 0;
                txtNoiDung.Focus();

                btnGhi.Enabled = btnHuy.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnPhucHoi.Enabled = btnThoat.Enabled = false;         
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm câu hỏi bộ đề! \n " + ex.Message, "", MessageBoxButtons.OK);
            }
        }
    }
}
