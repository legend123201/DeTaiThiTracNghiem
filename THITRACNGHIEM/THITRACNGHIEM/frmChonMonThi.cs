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
    public partial class frmChonMonThi : Form
    {
        public frmChonMonThi()
        {
            InitializeComponent();
        }

        private void gIAOVIEN_DANGKYBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsGV_DK.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmChonMonThi_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIEN_DANGKYTableAdapter.Fill(this.dS.GIAOVIEN_DANGKY);

            bdsGV_DK.Filter = "NGAYTHI = '" + DateTime.Now.ToShortDateString() + "'";

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnBatDauThi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Program.maMH = gvGV_DK.GetRowCellValue(gvGV_DK.FocusedRowHandle, "MAMH").ToString();
            Program.trinhDo = gvGV_DK.GetRowCellValue(gvGV_DK.FocusedRowHandle, "TRINHDO").ToString();
            Program.soCau = gvGV_DK.GetRowCellValue(gvGV_DK.FocusedRowHandle, "SOCAUTHI").ToString();
            Program.ngayThi = gvGV_DK.GetRowCellValue(gvGV_DK.FocusedRowHandle, "NGAYTHI").ToString();
            Program.thoiGian = Int32.Parse(gvGV_DK.GetRowCellValue(gvGV_DK.FocusedRowHandle, "THOIGIAN").ToString());
            Program.lanThi = Int32.Parse(gvGV_DK.GetRowCellValue(gvGV_DK.FocusedRowHandle, "LAN").ToString());

            frmThi f = new frmThi();
            f.Show();
        }

        private void gvGV_DK_Click(object sender, EventArgs e)
        {
            //Program.maMH = gvGV_DK.GetRowCellValue(gvGV_DK.FocusedRowHandle, "MAMH").ToString();
            //Program.trinhDo = gvGV_DK.GetRowCellValue(gvGV_DK.FocusedRowHandle, "TRINHDO").ToString();
            //Program.soCau = gvGV_DK.GetRowCellValue(gvGV_DK.FocusedRowHandle, "SOCAUTHI").ToString();

        }

        private void gcGV_DK_Click(object sender, EventArgs e)
        {

        }
    }
}
