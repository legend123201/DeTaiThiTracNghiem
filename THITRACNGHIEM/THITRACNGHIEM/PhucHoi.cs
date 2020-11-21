using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THITRACNGHIEM
{
    class PhucHoi
    {
        private Stack<string> myStack = new Stack<string>();
        private string DataTruocKhiSua = "";

        //-----------MÔN HỌC ------------------------
        public string GetDataTruocKhiSua()
        {
            return this.DataTruocKhiSua;
        }
        public void PushStack_ThemMH(string newMaMH)
        {
            myStack.Push("exec [dbo].[SP_PhucHoiThemMH] '"+ newMaMH + "'");
        }
        public void PushStack_XoaMH(string maMH, string tenMH)
        {
            myStack.Push("exec [dbo].[SP_PhucHoiXoaMH] '"+ maMH + "', N'" + tenMH + "'");   
        }
        public void Save_OldMH(string oldMaMH, string oldTenMH)
        {
            DataTruocKhiSua = oldMaMH + "/" + oldTenMH;
        }

        public void PushStack_SuaMH(string newMaMH, string newTenMH)
        {
            string[] arr = DataTruocKhiSua.Split('/');
            //myStack.Push("update[dbo].[MONHOC] set MAMH = '" + arr[0] + "', TENMH = '" + arr[1] + "' where MAMH = '" + newMaMH + "'");
            myStack.Push("exec[dbo].[SP_PhucHoiSuaMH] '" + newMaMH + "', N'" + newTenMH + "', '" + arr[0] + "', N'" + arr[1] + "'");
        }
        
        public string PopStack()
        {
            if(myStack.Count == 0)
            {
                return "Đã phục hồi hết các thao tác, không thể phục hồi được nữa!";
            }
            string sql = myStack.Pop();
            Program.ExecSqlNonQuery(sql);
            return "success";
        }

        //-----------BỘ ĐỀ------------------------
        public void PushStack_ThemBD(int newMaCauHoi)
        {
            myStack.Push("exec [dbo].[SP_PhucHoiThemBD] " + newMaCauHoi.ToString());
        }

        public void PushStack_XoaBD(int maCauHoi, string maGV, string maMH, string trinhDo, string noiDung, string A, string B, string C, string D, string dapAn)
        {
            myStack.Push("exec [dbo].[SP_PhucHoiXoaBD] "+ maCauHoi.ToString() + ", '" + maGV + "', '" + maMH + "', '" + trinhDo + "', N'" + noiDung + "', N'" + A + "', N'" + B + "', N'" + C + "', N'" + D + "', '" + dapAn + "'");
        }

        public void Save_OldBD(int oldMaCauHoi, string oldMaGV, string oldMaMH, string oldTrinhDo, string oldNoiDung, string oldA, string oldB, string oldC, string oldD, string oldDapAn)
        {
            DataTruocKhiSua = oldMaCauHoi.ToString() + "/" + oldMaGV + "/" + oldMaMH + "/" + oldTrinhDo + "/" + oldNoiDung + "/" + oldA + "/" + oldB + "/" + oldC + "/" + oldD + "/" + oldDapAn;
        }

        public void PushStack_SuaBD(int newMaCauHoi)
        {
            string[] arr = DataTruocKhiSua.Split('/');
            myStack.Push("exec[dbo].[SP_PhucHoiSuaBD] " + newMaCauHoi.ToString() + "," + arr[0] + ", '" + arr[1] + "', '" + arr[2] + "', '" + arr[3] + "', N'" + arr[4] + "', N'" + arr[5] + "', N'" + arr[6] + "', N'" + arr[7] + "', N'" + arr[8] + "', '" + arr[9] + "'");
        }

        //-----------KHOA-----------------------
        public void PushStack_ThemKH(string newMaKH)
        {
            myStack.Push("exec [dbo].[SP_PhucHoiThemKH] N'"+ newMaKH + "'");
        }

        public void PushStack_XoaKH(string maKH, string tenKH, string maCS)
        {
            myStack.Push("exec [dbo].[SP_PhucHoiXoaKH] N'" + maKH + "', N'" + tenKH + "', N'" + maCS + "'");
        }

        public void Save_OldKH(string oldMaKH, string oldTenKH, string oldMaCS)
        {
            DataTruocKhiSua = oldMaKH + "/" + oldTenKH + "/" + oldMaCS;
        }

        public void PushStack_SuaKH(string newMaKH, string newTenKH)
        {
            string[] arr = DataTruocKhiSua.Split('/');
            myStack.Push("exec[dbo].[SP_PhucHoiSuaMH] N'" + newMaKH + "', N'" + newTenKH + "', N'" + arr[0] + "', N'" + arr[1] + "', N'" + arr[2] + "'");
        }
    }
}
