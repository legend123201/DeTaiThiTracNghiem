USE [TN_CSDLPT]
GO

/****** Object:  StoredProcedure [dbo].[SP_TIMSV]    Script Date: 12/5/2020 11:49:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_TIMSV] (@MASV CHAR(8))
AS
BEGIN
SELECT MASV, HO, TEN, NGAYSINH, DIACHI, MALOP FROM dbo.SINHVIEN WHERE MASV = @MASV
END 
GO

