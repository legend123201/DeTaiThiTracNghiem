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
        DataTable dt = new DataTable();
        public frmXemKetQua()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmXemKetQua_Load(object sender, EventArgs e)
        {
           
            dt = Program.ExecSqlDataTable("SELECT TENLOP, MALOP FROM LOP");
            cmbLop.DataSource = dt;
            cmbLop.DisplayMember = "TENLOP";
            cmbLop.ValueMember = "MALOP";
            cmbLop.SelectedIndex = 1; cmbLop.SelectedIndex = 0;

            dt = Program.ExecSqlDataTable("SELECT MAMH, TENMH FROM MONHOC");
            cmbMH.DataSource = dt;
            cmbMH.DisplayMember = "TENMH";
            cmbMH.ValueMember = "MAMH";
            cmbMH.SelectedIndex = 0;

            cmbLan.Items.Add("1");
            cmbLan.Items.Add("2");
            cmbLan.SelectedIndex = 0;

            cmbTrinhDo.Items.Add("A");
            cmbTrinhDo.Items.Add("B");
            cmbTrinhDo.Items.Add("C");
            cmbTrinhDo.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            rptXemKetQua rp = new rptXemKetQua(cmbSV.Text, cmbMH.SelectedValue.ToString(), int.Parse(cmbLan.Text));
            rp.lblTieuDe.Text = "XEM KẾT QUẢ THI";
            rp.lblLop.Text = cmbLop.Text;
            rp.lblHoTen.Text = "a";
            rp.lblMonThi.Text = cmbMH.Text;
            rp.lblNgayThi.Text = "a";
            rp.lblLanThi.Text = cmbLan.Text;
            ReportPrintTool print = new ReportPrintTool(rp);
            print.ShowPreviewDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cmbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLop.SelectedValue != null)
            {
                dt = Program.ExecSqlDataTable("SELECT MASV FROM SINHVIEN WHERE MALOP = '" + cmbLop.SelectedValue.ToString() + "'");
                cmbSV.DataSource = dt;
                cmbSV.DisplayMember = "MASV";
                cmbSV.ValueMember = "MASV";
                //cmbSV.SelectedIndex = 0;
            }
        }
    }
}
