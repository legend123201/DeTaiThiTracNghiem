using DevExpress.XtraEditors.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace THITRACNGHIEM
{
    public partial class frmThi : Form
    {
        
        Dictionary<int, CauHoi> deThi = new Dictionary<int, CauHoi>();
        BindingSource bdsDethi;

        int phut;
        int giay;
        double diem = 0.0;
        double diemMoiCau = 0.0;

        public frmThi()
        {
            InitializeComponent();

            setThoiGian();

            DataTable dt = new DataTable();
            try
            {
                string sql = "EXEC SP_THI '" + Program.maMH + "', '" + Program.trinhDo + "', " + Program.soCau + "";
                
                dt = Program.ExecSqlDataTable(sql);
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e.Message, "Lỗi", MessageBoxButtons.OK);
                return;
            }
            bdsDethi = new BindingSource();
            bdsDethi.DataSource = dt;
            for(int i = 1; i <= bdsDethi.Count; i++)
            {
                rdbCauHoi.Properties.Items.Add(new RadioGroupItem(i, "" + i));
                deThi.Add(i, LayCauHoiTuBDS(i - 1));
            }
            rdbCauHoi.SelectedIndex = 0;
            diemMoiCau = 10.0 / Double.Parse(Program.soCau);
            timer.Start();
        }

        private void rdbDapAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rdbDapAn.SelectedIndex != -1)
                deThi[rdbCauHoi.SelectedIndex + 1].DaChon = rdbDapAn.EditValue.ToString();
               
        }

        private void rdbCauHoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            rdbDapAn.Properties.Items.Clear();
            lblCauHoi.Text = "Câu " + rdbCauHoi.EditValue.ToString() + ": " + deThi[rdbCauHoi.SelectedIndex + 1].NoiDUng;
            rdbDapAn.Properties.Items.Add(new RadioGroupItem("A", "A. " + deThi[rdbCauHoi.SelectedIndex + 1].A));
            rdbDapAn.Properties.Items.Add(new RadioGroupItem("B", "B. " + deThi[rdbCauHoi.SelectedIndex + 1].B));
            rdbDapAn.Properties.Items.Add(new RadioGroupItem("C", "C. " + deThi[rdbCauHoi.SelectedIndex + 1].C));
            rdbDapAn.Properties.Items.Add(new RadioGroupItem("D", "D. " + deThi[rdbCauHoi.SelectedIndex + 1].D));
            
            switch (deThi[rdbCauHoi.SelectedIndex + 1].DaChon)
            {
                case "A":
                    rdbDapAn.SelectedIndex = 0;
                    break;
                case "B":
                    rdbDapAn.SelectedIndex = 1;
                    break;
                case "C":
                    rdbDapAn.SelectedIndex = 2;
                    break;
                case "D":
                    rdbDapAn.SelectedIndex = 3;
                    break;
                case "null":
                    rdbDapAn.SelectedIndex = -1;
                    break;
            }
            
            
        }

        public void setThoiGian()
        {
            phut = Program.thoiGian - 1;
            giay = 60;
        }

        public void hienThiTG()
        {
            if (giay < 10)
            {
                if (phut > 10)
                    lblTime.Text = phut + ":0" + giay;
                else
                    lblTime.Text = "0" + phut + ":0" + giay;
            }
            else
            {
                if(giay == 60)
                {
                    if (phut > 10)
                        lblTime.Text = phut + ":00";
                    else
                        lblTime.Text = "0" + phut + ":00";
                }
                else
                {
                    if (phut > 10)
                        lblTime.Text = phut + ":" + giay;
                    else
                        lblTime.Text = "0" + phut + ":" + giay;
                }
            }
        }

        public CauHoi LayCauHoiTuBDS(int vitri)
        {
            CauHoi c = new CauHoi();

            c.IDCauHoi = ((DataRowView)bdsDethi[vitri])["CAUHOI"].ToString().Trim();
            c.MaMH = ((DataRowView)bdsDethi[vitri])["MAMH"].ToString().Trim();
            c.MaGV = ((DataRowView)bdsDethi[vitri])["MAGV"].ToString().Trim();
            c.TrinhDo = ((DataRowView)bdsDethi[vitri])["TRINHDO"].ToString().Trim();
            c.NoiDUng = ((DataRowView)bdsDethi[vitri])["NOIDUNG"].ToString().Trim();
            c.A = ((DataRowView)bdsDethi[vitri])["A"].ToString().Trim();
            c.B = ((DataRowView)bdsDethi[vitri])["B"].ToString().Trim();
            c.C = ((DataRowView)bdsDethi[vitri])["C"].ToString().Trim();
            c.D = ((DataRowView)bdsDethi[vitri])["D"].ToString().Trim();
            c.DapAn = ((DataRowView)bdsDethi[vitri])["DAP_AN"].ToString().Trim();
            c.DaChon = "null";

            return c;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            giay--;
            if(giay == 0)
            {
                phut--;
                giay = 60;
            }
            if (phut == 0 && giay == 0)
                timer.Stop();
            hienThiTG();
        }

        public void tinhDiem()
        {
            foreach(KeyValuePair<int, CauHoi> item in deThi)
            {
                if(item.Value.DaChon == item.Value.DapAn)
                {
                    diem += diemMoiCau;
                }
            }
        }

        public void luuVaoBangDiem()
        {
            string sql = "";
            try
            {
                sql = "INSERT INTO BANGDIEM ( MAMH , MASV , LAN , NGAYTHI , DIEM , BAITHI ) " 
                    + "VALUES  ( " +
                    "'" + Program.maMH + "' , -- MAMH - char(5) \n" +
                    "'" + Program.username + "' , -- MASV - char(8) \n" +
                    " " + Program.lanThi + " , -- LAN - smallint \n" +
                    "'" + Program.ngayThi + "' , -- NGAYTHI - datetime \n" +
                    " " + diem + " , -- DIEM - float \n" +
                    "N'Test' -- BAITHI - nchar(10) \n" +
                    ")";

                if (Program.ExecSqlNonQuery(sql) == 0)
                {
                    MessageBox.Show("Thêm vào bảng điểm thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                sql = "";
                sql = "EXEC SP_TIMBD '" + Program.maMH + "', '" + Program.username + "', " + Program.lanThi + ", '" + Program.ngayThi + "'";
                SqlDataReader reader;
                reader = Program.ExecSqlDataReader(sql);
                if (reader == null) return;
                reader.Read();
                long IDBD; 
                IDBD = reader.GetInt64(0);
                reader.Close();

                sql = "";
                foreach (KeyValuePair<int, CauHoi> item in deThi)
                {
                    sql += "INSERT INTO CT_BAITHI ( IDBD, CAUHOI, DACHON, STT ) " +
                        "VALUES  ( " +
                        "" + IDBD + ", -- IDBD - bigint \n" +
                        "" + item.Value.IDCauHoi + ", -- CAUHOI - int \n" +
                        "N'" + item.Value.DaChon + "', -- DACHON - nchar(5) \n" +
                        "" + item.Key + " -- STT - int \n" +
                        ") \n\n";
                }
                if(Program.ExecSqlNonQuery(sql) == 0)
                    MessageBox.Show("Thêm vào CT_BAITHI thành công!", "Thông báo", MessageBoxButtons.OK);
                
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnNopBai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(phut != 0 && giay != 0)
            {
                if (MessageBox.Show("Chưa hết thời gian, bạn có chắc nộp bài không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    tinhDiem();
                    luuVaoBangDiem();
                    timer.Stop();
                    phut = 0;
                    giay = 0;
                    hienThiTG();
                    MessageBox.Show("Điểm của bạn: " + diem, "Điểm", MessageBoxButtons.OK);
                }
            }
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
