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
    public partial class frmXemBangDiem : Form
    {
        private string maLop;
        private string maMH;
        private int lan;
        public frmXemBangDiem()
        {
            InitializeComponent();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsLop.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmXemBangDiem_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.dS.MONHOC);
            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);

            grcHienThi.Visible = false;

            cmbLan.Items.Add("1");
            cmbLan.Items.Add("2");
            cmbLan.SelectedIndex = 0;


        }

        private void btnChonLop_Click(object sender, EventArgs e)
        {
            grcHienThi.Visible = true;
            gcLop.Visible = true;
            gcMonHoc.Visible = false;
            gcLop.Dock = DockStyle.Fill;
        }

        private void btnChonMH_Click(object sender, EventArgs e)
        {
            grcHienThi.Visible = true;
            gcMonHoc.Visible = true;
            gcLop.Visible = false;
            gcMonHoc.Dock = DockStyle.Fill;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            maLop = gvLop.GetRowCellValue(gvLop.FocusedRowHandle, "MALOP").ToString().Trim();
            maMH = gvMonHoc.GetRowCellValue(gvMonHoc.FocusedRowHandle, "MAMH").ToString().Trim();
            lan = Int32.Parse(cmbLan.SelectedItem.ToString());

            string sql = "EXEC SP_KTBangDiemNULL '" + maMH + "', " + lan + ", '" + maLop + "'";
            if(Program.ExecSqlNonQuery(sql) == 0)
            {
                rptXemBangDiem rpt = new rptXemBangDiem(maMH, lan, maLop);
                rpt.lblTenLop.Text = txtTenLop.Text;
                rpt.lblMonHoc.Text = txtMonHoc.Text;
                rpt.lblLanThi.Text = lan.ToString();

                ReportPrintTool print = new ReportPrintTool(rpt);
                print.ShowPreviewDialog();
                grcHienThi.Visible = false;
            }
            
        }

        private void gcLop_Click(object sender, EventArgs e)
        {
            txtTenLop.Text = gvLop.GetRowCellValue(gvLop.FocusedRowHandle, "TENLOP").ToString();
        }

        private void gcMonHoc_Click(object sender, EventArgs e)
        {
            txtMonHoc.Text = gvMonHoc.GetRowCellValue(gvMonHoc.FocusedRowHandle, "TENMH").ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
