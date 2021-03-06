USE [TN_CSDLPT]
GO

/****** Object:  StoredProcedure [dbo].[SP_XemKetQua]    Script Date: 12/15/2020 17:18:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_XemKetQua]
	@MASV NCHAR(8),
	@MAMH NCHAR(5),
	@LAN SMALLINT,
	@NGAYTHI DATETIME
AS
BEGIN
	SELECT STT, BODE.CAUHOI, NOIDUNG, A, B, C, D, DAP_AN, DACHON 
	FROM dbo.CT_BAITHI JOIN dbo.BODE 
	ON BODE.CAUHOI = CT_BAITHI.CAUHOI 
	WHERE IDBD IN (SELECT IDBD FROM dbo.BANGDIEM WHERE MASV = @MASV AND MAMH = @MAMH AND LAN = @LAN AND NGAYTHI = @NGAYTHI)
	ORDER BY STT
END	
GO

