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
        
        public string PopStack_MH()
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
        public void Save_OldBD(int oldMaCauHoi, string oldMaGV, string MaMH, string TrinhDo, string NoiDung, string A, string B, string C, string D, string DapAn)
        {
            DataTruocKhiSua = oldMaCauHoi.ToString() + "/" + oldMaGV + "/" + MaMH + "/" + TrinhDo + "/" + NoiDung + "/" + A + "/" + B + "/" + C + "/" + D + "/" + DapAn;
        }
    }
}
