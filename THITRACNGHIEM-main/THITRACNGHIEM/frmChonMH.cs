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
    public partial class frmChonMH : Form
    {
        public frmChonMH()
        {
            InitializeComponent();
        }

        private void mONHOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsMonHoc.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmChonMH_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.dS.MONHOC);

        }

        private void gvMonHoc_Click(object sender, EventArgs e)
        {
            frmChuanBiThi.maMH = gvMonHoc.GetRowCellValue(gvMonHoc.FocusedRowHandle, "MAMH").ToString().Trim();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if(frmChuanBiThi.maMH == "")
            {
                MessageBox.Show("Chưa chọn môn học!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmChuanBiThi.maMH = "";
            this.Close();
        }
    }
}
