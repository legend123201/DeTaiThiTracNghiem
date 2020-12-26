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
        /*public static string trinhDo = "";*/
        /*private static int lan;*/
        /*private bool isSua = false;*/
        //int vitri;

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
            cmbLan.Items.Add("1");
            cmbLan.Items.Add("2");
            cmbLan.SelectedIndex = 0;

            cmbCoSo.DataSource = Program.bds_dspm;
            cmbCoSo.DisplayMember = "TEN_COSO";
            cmbCoSo.ValueMember = "TEN_SERVER";
            cmbCoSo.SelectedIndex = Program.mCoso;

            if (Program.mGroup == "TRUONG")
                cmbCoSo.Enabled = true;
            else
                cmbCoSo.Enabled = false;
            grcInFor.Enabled = false;
            txtMaLop.Enabled = txtMaMH.Enabled = false;
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

        private void btnChonMH_Leave(object sender, EventArgs e)
        {
            txtMaMH.Text = maMH;
            if (!txtMaMH.Focused)
            {
                txtMaMH.Focus();
            }
        }

        private void btnChonLop_Leave(object sender, EventArgs e)
        {
            txtMaLop.Text = maLop;
            if (!txtMaLop.Focused)
            {
                txtMaLop.Focus();
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "TRUONG" || Program.mGroup == "GIAOVIEN")
            {
                MessageBox.Show("Bạn không có quyền này!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            //vitri = bdsGV_DK.Position;
            bdsGV_DK.AddNew();
            txtMaGV.Text = Program.username;

            txtMaMH.Focus();
            dptNgayThi.EditValue = "";

            grcInFor.Enabled = true;
            gc_GVDK.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnRefresh.Enabled = btnThoat.Enabled = false;
            btnGhi.Enabled = btnHuy.Enabled = true;

            cmbTrinhDo.SelectedIndex = 1; cmbTrinhDo.SelectedIndex = 0;
            cmbLan.SelectedIndex = 1; cmbLan.SelectedIndex = 0;
        }

        private int DateCmp(string date1, string date2) //ktra theo thu tu: nam -> thang -> ngay
        {
            string[] s1 = date1.Split('/'); //format là  mm/dd/yyyy
            string[] s2 = date2.Split('/');
            if (int.Parse(s1[2]) > int.Parse(s2[2]))
            {
                return 1;
            }
            else if (int.Parse(s1[2]) < int.Parse(s2[2]))
            {
                return -1;
            }
            else
            {
                if (int.Parse(s1[0]) > int.Parse(s2[0]))
                {
                    return 1;
                }
                else if (int.Parse(s1[0]) < int.Parse(s2[0]))
                {
                    return -1;
                }
                else
                {
                    if (int.Parse(s1[1]) > int.Parse(s2[1]))
                    {
                        return 1;
                    }
                    else if (int.Parse(s1[1]) < int.Parse(s2[1]))
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*if (spinSoCau.Text.Trim().Contains("."))
            {
                spinSoCau.Text.Trim().Remove(spinSoCau.Text.Trim().Length - 2);
            }

            if (spinThoiGian.Text.Trim().Contains("."))
            {
                spinThoiGian.Text.Trim().Remove(spinThoiGian.Text.Trim().Length - 2);
            }*/
            /*if(txtMaMH.Text == "")
                txtMaMH.Text = maMH;
            if(txtMaLop.Text == "")
                txtMaLop.Text = maLop;
            
            cmbTrinhDo.Text = cmbTrinhDo.SelectedItem.ToString();
            cmbLan.Text = cmbLan.SelectedItem.ToString();
            if (isSua)
            {
                cmbTrinhDo.Text = trinhDo;
                cmbLan.Text = lan.ToString();
            }*/

            if (txtMaMH.Text.Trim().Length == 0)
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
            if (spinSoCau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Số câu thi không được trống!", "Lỗi", MessageBoxButtons.OK);
                spinSoCau.Focus();
                return;
            }
            else if (int.Parse(spinSoCau.Text.Trim()) < 10 || int.Parse(spinSoCau.Text.Trim()) > 100)
            {
                MessageBox.Show("Số câu thi phải >= 10 câu và <= 100 câu!", "Lỗi", MessageBoxButtons.OK);
                spinSoCau.Focus();
                return;
            }

            if (spinThoiGian.Text.Trim().Length == 0)
            {
                MessageBox.Show("Thời gian thi không được trống!", "Lỗi", MessageBoxButtons.OK);
                spinThoiGian.Focus();
                return;
            }
            else if(int.Parse(spinThoiGian.Text.Trim()) < 15 || int.Parse(spinThoiGian.Text.Trim()) > 60)
            {
                MessageBox.Show("Thời gian thi phải >= 15 phút và <= 60 phút!", "Lỗi", MessageBoxButtons.OK);
                spinThoiGian.Focus();
                return;
            }

            //nếu như đã đầy đủ thông tin
            //----ktra tính ngày thi và ngày hiện tại-----start
            string inputDate = dptNgayThi.Text;
            string ngayHienTai = DateTime.Now.ToShortDateString();
            if (DateCmp(inputDate, ngayHienTai) == -1)
            {
                MessageBox.Show("Ngày thi phải lớn hơn hoặc bằng ngày hiện tại!", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            //----ktra ngày thi và ngày hiện tại-----end

            //------ktra thông tin đăng ký------start(đã lập hay chưa, nếu là dky lần 2 thì ktra thêm đã thi lần 1 chưa, ngày lần 2 có lớn hơn ngày lần 1 ko) 
            string sql;
            sql = "EXEC SP_KTLapLichThi N'" + txtMaMH.Text.Trim() + "', N'" + txtMaLop.Text.Trim() + "', " + cmbLan.SelectedItem.ToString().Trim() + ", '" + inputDate + "'";
            int ketQua = Program.ExecSqlNonQuery(sql);
            if (ketQua == 1)
            {
                return;
            }
            //------ktra thông tin đăng ký------end

            try
            {
                sql = "EXEC SP_CHUANBITHI N'" + txtMaMH.Text.Trim() + "', N'" + cmbTrinhDo.Text.Trim() + "', " + spinSoCau.Text.Trim() + "";

                if (Program.ExecSqlNonQuery(sql) == 0)
                {
                    bdsGV_DK.EndEdit();
                    bdsGV_DK.ResetCurrentItem();
                    this.gIAOVIEN_DANGKYTableAdapter.Update(this.dS.GIAOVIEN_DANGKY);

                    grcInFor.Enabled = false;
                    gc_GVDK.Enabled = true;
                    btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                    btnGhi.Enabled = btnHuy.Enabled = false;
                    btnThoat.Enabled = btnRefresh.Enabled = true;
                    /*isSua = false;*/
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi đăng ký thi\n" + ex.Message, "Lỗi", MessageBoxButtons.OK);
            }
        }

        /*private void cmbTrinhDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTrinhDo.SelectedValue != null)
                trinhDo = cmbTrinhDo.SelectedItem.ToString();
        }*/

        /*private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.mGroup == "TRUONG" || Program.mGroup == "GIAOVIEN")
            {
                MessageBox.Show("Bạn không có quyền này!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            isSua = true;
            txtMaGV.Text = Program.username;//sửa lịch thi thì sửa thành mã của gv đang sửa luôn
            *//*maLop = gvGV_DK.GetRowCellValue(gvGV_DK.FocusedRowHandle, "MALOP").ToString().Trim();
            maMH = gvGV_DK.GetRowCellValue(gvGV_DK.FocusedRowHandle, "MAMH").ToString().Trim();
            lan = Int32.Parse(gvGV_DK.GetRowCellValue(gvGV_DK.FocusedRowHandle, "LAN").ToString().Trim());*//*
            string sql = "EXEC SP_KTLichThiDaThi N'" + txtMaMH.Text + "', N'" + txtMaLop.Text + "', " + cmbLan.Text + "";
            if (Program.ExecSqlNonQuery(sql) == 1)
            {
                //MessageBox.Show("Môn này đã thi, không được sửa!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            grcInFor.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnHuy.Enabled = true;
        }*/

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

            string sql = "EXEC SP_KTLichThiDaThi N'" + txtMaMH.Text + "', N'" + txtMaLop.Text + "', " + cmbLan.Text + "";
            int ketQua = Program.ExecSqlNonQuery(sql);
            if (ketQua == 1)
            {
                return;
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
                        MessageBox.Show("Lỗi xóa mục giáo viên đăng ký. Hãy xóa lại!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK);
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
            btnThoat.Enabled = btnRefresh.Enabled = true;
            gc_GVDK.Enabled = true;
            /*isSua = false;*/
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
                cmbTrinhDo.SelectedIndex = 1; cmbTrinhDo.SelectedIndex = 0;
                cmbLan.SelectedIndex = 1; cmbLan.SelectedIndex = 0;
            }
        }



        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIEN_DANGKYTableAdapter.Fill(this.dS.GIAOVIEN_DANGKY);
        }

        /* private void cmbLan_SelectedIndexChanged(object sender, EventArgs e)
         {
             if(cmbLan.SelectedValue != null)
                 lan = Int32.Parse(cmbLan.SelectedItem.ToString());
         }*/

        private void dptNgayThi_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
