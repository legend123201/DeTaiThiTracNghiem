using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace THITRACNGHIEM
{
    public partial class rptDSDKThi : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDSDKThi(string ngay1, string ngay2)
        {
            InitializeComponent();
            this.sqlDataSource2.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource2.Queries[0].Parameters[0].Value = ngay1;
            this.sqlDataSource2.Queries[0].Parameters[1].Value = ngay2;
            this.sqlDataSource2.Fill();

        }

    }
}
