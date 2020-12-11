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
    public partial class frmInDSGV : Form
    {
        public frmInDSGV()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XtraReport2 RP = new XtraReport2();
            RP.label1.Text = "luu";
       
            ReportPrintTool print = new ReportPrintTool(RP);
            print.ShowPreviewDialog();

        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.lOPBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmInDSGV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.LOP1' table. You can move, or remove it, as needed.
            
            dS.EnforceConstraints = false;
            //this.lOPTableAdapter.Connection.ConnectionString = Program.connstr; this.lOP1TableAdapter.Fill(this.dS.LOP1);
            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.


        }
    }
}
