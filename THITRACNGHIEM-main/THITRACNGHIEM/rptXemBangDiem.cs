using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace THITRACNGHIEM
{
    public partial class rptXemBangDiem : DevExpress.XtraReports.UI.XtraReport
    {
        public rptXemBangDiem(string maMH, int lan, string maLop)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = maMH;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = lan;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = maLop;
            this.sqlDataSource1.Fill();
        }

    }
}
