USE [TN_CSDLPT]
GO

/****** Object:  StoredProcedure [dbo].[SP_TrungMaMH]    Script Date: 11/21/2020 10:30:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[SP_TrungMaMH](@MAMH char(5))
as

begin
	if exists(SELECT MAMH FROM  dbo.MONHOC WHERE MAMH =@MAMH)
   		raiserror ('Mã môn học đã tồn tại!',16,1)
end
GO

