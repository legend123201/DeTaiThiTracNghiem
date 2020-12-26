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
            this.ControlBox = false;
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
            btnXemKQ.Enabled = false;
            btnThoat.Enabled = false;
            timer.Start();
        }

        private void rdbDapAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rdbDapAn.SelectedIndex != -1)
            {
                deThi[rdbCauHoi.SelectedIndex + 1].DaChon = rdbDapAn.EditValue.ToString();
                rdbCauHoi.Properties.Items.GetItemByValue(rdbCauHoi.SelectedIndex + 1).Description = rdbCauHoi.EditValue.ToString() + "-" + deThi[rdbCauHoi.SelectedIndex + 1].DaChon;
            }
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
                case "X":
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

        public void RandomNumber(List<int> randLuaChon)
        {
            Random rand = new Random();
            int[] a = new int[4];
            int indexVuaRandom;
            int doDaiMang = 4;
            for (int i = 0; i < doDaiMang; i++)
            {
                a[i] = i;
            }

            while (doDaiMang != 0)
            {
                indexVuaRandom = rand.Next(0, doDaiMang - 1);
                randLuaChon.Add(a[indexVuaRandom]);

                a[indexVuaRandom] = a[doDaiMang - 1];
                doDaiMang--;
            }
        }
        public void tronDapAn(CauHoi c)
        {
            int indexDA = 0;
            switch (c.DapAn)
            {
                case "A":
                    indexDA = 0;
                    break;
                case "B":
                    indexDA = 1;
                    break;
                case "C":
                    indexDA = 2;
                    break;
                case "D":
                    indexDA = 3;
                    break;
            }

            List<int> randLuaChon = new List<int>();
            RandomNumber(randLuaChon);
        

            string[] chTam = new string[4];
            chTam[0] = c.A;
            chTam[1] = c.B;
            chTam[2] = c.C;
            chTam[3] = c.D;

            c.A = chTam[randLuaChon[0]];
            c.B = chTam[randLuaChon[1]];
            c.C = chTam[randLuaChon[2]];
            c.D = chTam[randLuaChon[3]];

            switch (randLuaChon.IndexOf(indexDA))
            {
                case 0:
                    c.DapAn = "A";
                    break;
                case 1:
                    c.DapAn = "B";
                    break;
                case 2:
                    c.DapAn = "C";
                    break;
                case 3:
                    c.DapAn = "D";
                    break;
            }
            randLuaChon.Clear();
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
            c.DaChon = "X";

            tronDapAn(c);
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
            {
                timer.Stop();
                tinhDiem();
                luuVaoBangDiem();
                hienThiTG();
                updateDatagrid();
                lblDiem.Text = "Điểm: " + diem;

                btnXemKQ.Enabled = true;
                btnThoat.Enabled = true;
                btnNopBai.Enabled = false;
                //MessageBox.Show("Điểm của bạn: " + diem, "Điểm", MessageBoxButtons.OK);
            }
                
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
        public bool checkFullDA()
        {
            foreach (KeyValuePair<int, CauHoi> item in deThi)
            {
                if (item.Value.DaChon.Equals("X"))
                {
                    return true;
                }
            }
            return false;
        }

        public void luuVaoBangDiem()
        {

            if (Program.mGroup == "SINHVIEN")
            {
                /*string sql = "";
                sql = "SELECT * FROM BANGDIEM";
                DataTable dt = new DataTable();
                dt = Program.ExecSqlDataTable(sql);
                BindingSource bdsBD = new BindingSource();
                bdsBD.DataSource = dt;
                int IDBD = bdsBD.Count + 1;*/

                string sql = "";
                string strLenh = "EXEC SP_TimIDBangDiem";
                Program.myReader = Program.ExecSqlDataReader(strLenh);
                Program.myReader.Read();
                long IDBD = Program.myReader.GetInt64(0);
                Program.myReader.Close();

                try
                {
                    sql = "INSERT INTO BANGDIEM ( IDBD, MAMH , MASV , LAN , NGAYTHI , DIEM , BAITHI ) "
                        + "VALUES  ( " +
                        "'" + IDBD + "' , -- IDBD - int \n" +
                        "'" + Program.maMH + "' , -- MAMH - char(5) \n" +
                        "'" + Program.username + "' , -- MASV - char(8) \n" +
                        " " + Program.lanThi + " , -- LAN - smallint \n" +
                        "'" + Program.ngayThi + "' , -- NGAYTHI - datetime \n" +
                        " " + diem + " , -- DIEM - float \n" +
                        "N'Test' -- BAITHI - nchar(10) \n" +
                        ")";

                    if (Program.ExecSqlNonQuery(sql) == 0)
                    {
                        sql = "";
                        foreach (KeyValuePair<int, CauHoi> item in deThi)
                        {
                            sql += "INSERT INTO CT_BAITHI ( IDBD, CAUHOI, DACHON, STT, A, B, C, D, DAP_AN ) " +
                                "VALUES  ( " +
                                "" + IDBD + ", -- IDBD - bigint \n" +
                                "" + item.Value.IDCauHoi + ", -- CAUHOI - int \n" +
                                "N'" + item.Value.DaChon + "', -- DACHON - nchar(5) \n" +
                                "" + item.Key + ", -- STT - int \n" +
                                "N'" + item.Value.A + "',\n" +
                                "N'" + item.Value.B + "',\n" +
                                "N'" + item.Value.C + "',\n" +
                                "N'" + item.Value.D + "',\n" +
                                "N'" + item.Value.DapAn + "'" +
                                ") \n\n";
                        }
                        if (Program.ExecSqlNonQuery(sql) == 0)
                            MessageBox.Show("Đã lưu bài thi vào CSDL!", "Thông báo", MessageBoxButtons.OK);
                    }
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show("" + e.Message, "Thông báo", MessageBoxButtons.OK);
                }
            }
            else return;
        }

        private void btnNopBai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(phut != 0 && giay != 0)
            {
                if (MessageBox.Show("Chưa hết thời gian, bạn có chắc nộp bài không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (checkFullDA())
                        if (MessageBox.Show("Chưa chọn hết đáp án, bạn có muốn nộp bài không", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            tinhDiem();
                            luuVaoBangDiem();
                            timer.Stop();
                            phut = 0;
                            giay = 0;
                            hienThiTG();
                            updateDatagrid();
                            lblDiem.Text = "Điểm: " + diem;

                            btnXemKQ.Enabled = true;
                            btnThoat.Enabled = true;
                            btnNopBai.Enabled = false;
                            //MessageBox.Show("Điểm của bạn: " + diem, "Điểm", MessageBoxButtons.OK);
                        }
                        else
                            return;
                    else
                    {
                        tinhDiem();
                        luuVaoBangDiem();
                        timer.Stop();
                        phut = 0;
                        giay = 0;
                        hienThiTG();
                        updateDatagrid();
                        lblDiem.Text = "Điểm: " + diem;

                        btnXemKQ.Enabled = true;
                        btnThoat.Enabled = true;
                        btnNopBai.Enabled = false;
                    }
                }
                else
                    return;
            }
        }

        public void updateDatagrid()
        {
            gvKetQua.Rows.Clear();
            foreach(KeyValuePair<int, CauHoi> item in deThi)
            {
                DataGridViewRow newRow = new DataGridViewRow();

                newRow.CreateCells(gvKetQua);
                newRow.Cells[0].Value = item.Key;
                newRow.Cells[1].Value = item.Value.DaChon;
                newRow.Cells[2].Value = item.Value.DapAn;
                gvKetQua.Rows.Add(newRow);
            }
        }

        private void tabKetQua_Click(object sender, EventArgs e)
        {
            if(phut != 0 && giay != 0)
            {
                MessageBox.Show("Bạn chưa thi xong!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnXemKQ_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (phut != 0 && giay != 0)
            {
                MessageBox.Show("Bạn chưa thi xong!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            tbcMain.SelectedIndex = 1;
        }

        private void frmThi_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
