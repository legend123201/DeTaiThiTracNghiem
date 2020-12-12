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
        public frmXemKetQua()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmXemKetQua_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Program.ExecSqlDataTable("SELECT MASV FROM SINHVIEN");
            cmbSV.DataSource = dt;
            cmbSV.DisplayMember = "MASV";
            cmbSV.ValueMember = "MASV";
            cmbSV.SelectedIndex = 0;

            dt = Program.ExecSqlDataTable("SELECT MAMH, TENMH FROM MONHOC");
            cmbMH.DataSource = dt;
            cmbMH.DisplayMember = "TENMH";
            cmbMH.ValueMember = "MAMH";
            cmbMH.SelectedIndex = 0;

            cmbLan.Items.Add("1");
            cmbLan.Items.Add("2");
            cmbLan.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            rptXemKetQua rp = new rptXemKetQua(cmbSV.Text, cmbMH.SelectedValue.ToString(), int.Parse(cmbLan.Text));
            ReportPrintTool print = new ReportPrintTool(rp);
            print.ShowPreviewDialog();
        }
    }
}
