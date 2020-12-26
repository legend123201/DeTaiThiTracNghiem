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
    public partial class frmDSDKThi : Form
    {
        public frmDSDKThi()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            rptDSDKThi rpt = new rptDSDKThi(dptNgay1.Text.Trim(), dptNgay2.Text.Trim());
            rpt.lblCoSo.Text = ((DataRowView)Program.bds_dspm[Program.mCoso])["TEN_COSO"].ToString();
            rpt.lblNgay.Text = "TỪ NGÀY " + Program.FormatDate(dptNgay1.Text.Trim()) + " ĐẾN NGÀY " + Program.FormatDate(dptNgay2.Text.Trim());

            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
