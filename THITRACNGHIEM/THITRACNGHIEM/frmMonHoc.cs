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
    public partial class frmMonHoc : Form
    {
        public frmMonHoc()
        {
            InitializeComponent();
        }

        private void mONHOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bds_MonHoc.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Fill(this.dS.MONHOC);

            groupBox1.Enabled = false;
            
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bds_MonHoc.AddNew();
                //gcMH.Enabled = false;
                gc_MonHoc.Enabled = false;
                //edtTenMH.Enabled = edtMaMH.Enabled = true;
                groupBox1.Enabled = true;
                txtMaMH.Focus();
                //edtMaMH.Focus();
                //btnThemMH.Enabled = btnSuaMH.Enabled = btnTaiLaiMH.Enabled = btnXoaMH.Enabled = btnTim.Enabled = edtTim.Enabled = false;
                //checkThem = true;
                //checkSave = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm môn học " + ex.Message, "", MessageBoxButtons.OK);
            }
        }
    }
}
