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
    public partial class frmChonLop : Form
    {
        public frmChonLop()
        {
            InitializeComponent();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsLop.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmChonLop_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);

        }

        private void gvLop_Click(object sender, EventArgs e)
        {
            frmChuanBiThi.maLop = gvLop.GetRowCellValue(gvLop.FocusedRowHandle, "MALOP").ToString().Trim();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (frmChuanBiThi.maLop == "")
            {
                MessageBox.Show("Chưa chọn lớp!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmChuanBiThi.maLop = "";
            this.Close();
        }
    }
}
