using DevExpress.XtraReports.UI;
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
    public partial class frmXemKetQua : Form
    {
        private string maLop;
        private string maSV;
        private string maMH;
        private int lan;

        public frmXemKetQua()
        {
            InitializeComponent();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsLop.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmXemKetQua_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);
            // TODO: This line of code loads data into the 'dS.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.dS.MONHOC);
            // TODO: This line of code loads data into the 'dS.SINHVIEN' table. You can move, or remove it, as needed.
            this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
            

            grcHienThi.Visible = false;

            cmbLan.Items.Add("1");
            cmbLan.Items.Add("2");
            cmbLan.SelectedIndex = 0;

            if(Program.mGroup == "SINHVIEN")
            {
                btnChonLop.Enabled = btnChonSV.Enabled = txtLop.Enabled = txtHoTen.Enabled = false;
                txtLop.Text = Program.maLopSV;
                txtHoTen.Text = Program.mHoten;
            }
        }

        private void btnChonLop_Click(object sender, EventArgs e)
        {
            grcHienThi.Visible = true;
            gcLop.Visible = true;
            gcSinhVIen.Visible = gcMonHoc.Visible = false;
            gcLop.Dock = DockStyle.Fill;
            maLop = gvLop.GetRowCellValue(gvLop.FocusedRowHandle, "MALOP").ToString().Trim();
        }

        private void btnChonSV_Click(object sender, EventArgs e)
        {
            grcHienThi.Visible = true;
            gcSinhVIen.Visible = true;
            gcLop.Visible = gcMonHoc.Visible = false;
            gcSinhVIen.Dock = DockStyle.Fill;

            bdsSinhVien.Filter = "MALOP = '" + maLop + "'";
        }

        private void btnChonMH_Click(object sender, EventArgs e)
        {
            grcHienThi.Visible = true;
            gcMonHoc.Visible = true;
            gcLop.Visible = gcSinhVIen.Visible = false;
            gcMonHoc.Dock = DockStyle.Fill;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if(Program.mGroup == "SINHVIEN")
            {
                maLop = Program.maLopSV;
                maSV = Program.username;
                maMH = gvMonHoc.GetRowCellValue(gvMonHoc.FocusedRowHandle, "MAMH").ToString().Trim();
                lan = Int32.Parse(cmbLan.SelectedItem.ToString());
            }
            else
            {
                maLop = gvLop.GetRowCellValue(gvLop.FocusedRowHandle, "MALOP").ToString().Trim();
                maSV = gvSinhVIen.GetRowCellValue(gvSinhVIen.FocusedRowHandle, "MASV").ToString().Trim();
                maMH = gvMonHoc.GetRowCellValue(gvMonHoc.FocusedRowHandle, "MAMH").ToString().Trim();
                lan = Int32.Parse(cmbLan.SelectedItem.ToString());
            }
            // kiem tra ma lop cua sv
            string sql = "EXEC SP_KTMaLop '" + maLop + "'";
            if(Program.ExecSqlNonQuery(sql) == 0)
            {
                sql = "EXEC SP_KTKetQuaNULL '" + maSV + "', '" + maMH + "', " + lan + "";
                if(Program.ExecSqlNonQuery(sql) == 0)
                {
                    rptXemKetQua rpt = new rptXemKetQua(maSV, maMH, lan);
                    rpt.lblLop.Text = txtLop.Text;
                    rpt.lblHoTen.Text = txtHoTen.Text;
                    rpt.lblMon.Text = txtMonHoc.Text;
                    rpt.lblLan.Text = lan.ToString();

                    string strLenh = "EXEC SP_LayNgayThi '" + maSV + "', '" + maMH + "', " + lan + "";
                    Program.myReader = Program.ExecSqlDataReader(strLenh);
                    Program.myReader.Read();
                    rpt.lblNgay.Text = Program.myReader.GetString(0);
                    Program.myReader.Close();
                    

                    ReportPrintTool print = new ReportPrintTool(rpt);
                    print.ShowPreviewDialog();
                    grcHienThi.Visible = false;
                }
                
            }
        }

        private void gcLop_Click(object sender, EventArgs e)
        {
            if(bdsLop.Count > 0)
                txtLop.Text = gvLop.GetRowCellValue(gvLop.FocusedRowHandle, "TENLOP").ToString();
        }

        private void gcSinhVIen_Click(object sender, EventArgs e)
        {
            if (bdsSinhVien.Count > 0)
                txtHoTen.Text = gvSinhVIen.GetRowCellValue(gvSinhVIen.FocusedRowHandle, "HO").ToString() + " " + gvSinhVIen.GetRowCellValue(gvSinhVIen.FocusedRowHandle, "TEN").ToString();
        }

        private void gcMonHoc_Click(object sender, EventArgs e)
        {
            if (bdsMonHoc.Count > 0)
                txtMonHoc.Text = gvMonHoc.GetRowCellValue(gvMonHoc.FocusedRowHandle, "TENMH").ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
