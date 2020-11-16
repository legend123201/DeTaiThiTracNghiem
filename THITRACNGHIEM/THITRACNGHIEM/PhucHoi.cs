using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THITRACNGHIEM
{
    class PhucHoi
    {
        Stack<string> myStack = new Stack<string>();
        string MHTruocKhiSua = "";
        public void PushStack_ThemMH(string newMaMH)
        {
            myStack.Push("delete dbo.MONHOC where MAMH = '" + newMaMH + "'");
        }
        public void PushStack_XoaMH(string maMH, string tenMH)
        {
            myStack.Push("insert into [dbo].[MONHOC] ( MAMH, TENMH ) values ('" + maMH + "', N'" + tenMH + "')");   
        }
        public void Save_OldMH(string oldMaMH, string oldTenMH)
        {
            MHTruocKhiSua = oldMaMH + "/" + oldTenMH;
        }

        public void PushStack_SuaMH(string newMaMH)
        {
            string[] arr = MHTruocKhiSua.Split('/');
            myStack.Push("update[dbo].[MONHOC] set MAMH = '" + arr[0] + "', TENMH = '" + arr[1] + "' where MAMH = '" + newMaMH + "'");      
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
    }
}
