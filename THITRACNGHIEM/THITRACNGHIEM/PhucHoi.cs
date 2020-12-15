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

        public void PushStack_XoaBD(string maGV, string maMH, string trinhDo, string noiDung, string A, string B, string C, string D, string dapAn)
        {
            myStack.Push("exec [dbo].[SP_PhucHoiXoaBD] '" + maGV + "', '" + maMH + "', '" + trinhDo + "', N'" + noiDung + "', N'" + A + "', N'" + B + "', N'" + C + "', N'" + D + "', '" + dapAn + "'");
            //myStack.Push("exec [dbo].[SP_PhucHoiXoaBD] " + maCauHoi.ToString() + ", '" + maGV + "', '" + maMH + "', '" + trinhDo + "', N'" + noiDung + "', N'" + A + "', N'" + B + "', N'" + C + "', N'" + D + "', '" + dapAn + "'");
        }

        public void Save_OldBD(string oldMaGV, string oldMaMH, string oldTrinhDo, string oldNoiDung, string oldA, string oldB, string oldC, string oldD, string oldDapAn)
        {
            DataTruocKhiSua = oldMaGV + "/" + oldMaMH + "/" + oldTrinhDo + "/" + oldNoiDung + "/" + oldA + "/" + oldB + "/" + oldC + "/" + oldD + "/" + oldDapAn;
        }

        public void PushStack_SuaBD(int MaCauHoi)
        {
            string[] arr = DataTruocKhiSua.Split('/');
            myStack.Push("exec[dbo].[SP_PhucHoiSuaBD] " + MaCauHoi.ToString() + ", '" + arr[0] + "', '" + arr[1] + "', '" + arr[2] + "', N'" + arr[3] + "', N'" + arr[4] + "', N'" + arr[5] + "', N'" + arr[6] + "', N'" + arr[7] + "', '" + arr[8] + "'");
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

        //-----------LOP-----------------------
        public void PushStack_ThemLop(string newMaLop)
        {
            myStack.Push("exec [dbo].[SP_PhucHoiThemKH] '" + newMaLop + "'");
        }

        public void PushStack_XoaLop(string maLop, string tenLop, string maKH)
        {
            myStack.Push("exec [dbo].[SP_PhucHoiXoaKH] '" + maLop + "', N'" + tenLop + "', N'" + maKH + "'");
        }

        public void Save_OldLop(string oldMaLop, string oldTenLop, string oldMaKH)
        {
            DataTruocKhiSua = oldMaLop + "/" + oldTenLop + "/" + oldMaKH;
        }

        public void PushStack_SuaLop(string newMaLop, string newTenLop)
        {
            string[] arr = DataTruocKhiSua.Split('/');
            myStack.Push("exec[dbo].[SP_PhucHoiSuaMH] '" + newMaLop + "', N'" + newTenLop + "', '" + arr[0] + "', N'" + arr[1] + "', N'" + arr[2] + "'");
        }

        // sinh viên
        public void PushStack_ThemSV(string newMaSV)
        {
            myStack.Push("delete dbo.SINHVIEN where MASV = '" + newMaSV + "'");
        }

        public void PushStack_XoaSV(string maSV, string ho, string ten, string ngaySinh, string diaChi, string maLop)
        {
            myStack.Push("insert into [dbo].[SINHVIEN] ( MASV, HO, TEN, NGAYSINH, DIACHI, MALOP ) " +
                "values ('" + maSV + "', N'" + ho + "', N'" + ten + "', '" + ngaySinh + "', N'" + diaChi + "', '" + maLop + "')");
        }

        public void Save_OldSV(string oldMaSV, string oldHo, string oldTen, string oldNgaySinh, string oldDiaChi, string oldMaLop)
        {
            DataTruocKhiSua = oldMaSV + "/" + oldHo + "/" + oldTen + "/" + oldNgaySinh + "/" + oldDiaChi + "/" + oldMaLop;
        }

        public void PushStack_SuaSV(string newMaSV)
        {
            string[] arr = DataTruocKhiSua.Split('/');
            myStack.Push("update [dbo].[SINHVIEN] set MASV = '" + arr[0] + "', HO = '" + arr[1] + "', TEN = '" + arr[2] + "', NGAYSINH = '" + arr[3] + "', DIACHI = '" + arr[4] + "', MALOP = '" + arr[5] + "' where MASV = '" + newMaSV + "'");
        }
    }
}
