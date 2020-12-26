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
    public partial class frmThongTinSV : Form
    {
        public frmThongTinSV()
        {
            InitializeComponent();
            lblMSV.Text = Program.username;
            lblHo.Text = Program.mHoten;
            lblNgaySinh.Text = Program.FormatDate(Program.ngaySinhSV);
            lblDiaChi.Text = Program.diaChiSV;
            lblMaLop.Text = Program.maLopSV;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
