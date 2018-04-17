CREATE DATABASE QL_COFFEE
GO

--Group
--NguyenVanPhuc/LamTranQuocDat/QuocTrung
--Create date 28/01/2018
--DESIGN BY NGUYENVANPHUC

--ACCOUNT
--LOAIDICHVU
--DICHVU
--BAN
--KHUVUC
--BILL
--BILLINFO


USE QL_COFFEE
GO

CREATE TABLE PDT_ACCOUNT
(
	idAccount INT IDENTITY PRIMARY KEY,
	useName NCHAR(16) NOT NULL,
	passWork NCHAR(12) NOT NULL,
	sex int DEFAULT 0,--0:NAM;1:NU
	permission int DEFAULT -1,-- -1:STAFF,0:ADMIN
	describeAccount NVARCHAR(MAX) DEFAULT N'ĐÂY LÀ MÔ TẢ OR GHI CHÚ'
)
GO

CREATE TABLE PDT_CATEGORYFOOD
(
	idCategory INT IDENTITY PRIMARY KEY,
	categoryName NVARCHAR(50 )NOT NULL,
	describeCategoryFood NVARCHAR(MAX) DEFAULT N'ĐÂY LÀ MÔ TẢ OR GHI CHÚ'
)
GO

CREATE TABLE PDT_FOOD
(
	idFood INT IDENTITY PRIMARY KEY,
	foodName NVARCHAR(50) NOT NULL,
	donViTinh NVARCHAR(20) NOT NULL,
	gia FLOAT NOT NULL,
	describeFood NVARCHAR(MAX) DEFAULT N'ĐÂY LÀ MÔ TẢ OR GHI CHÚ',
	
	idCategoryFood INT NOT NULL,

	FOREIGN KEY (idCategoryFood) REFERENCES PDT_CATEGORYFOOD(idCategory)

)

CREATE TABLE PDT_KHUVUC
(
	idKhuVuc INT IDENTITY PRIMARY KEY,
	khuVucName NVARCHAR(50) NOT NULL,
	describeKhuVuc NVARCHAR(MAX) DEFAULT N'ĐÂY LÀ MÔ TẢ OR GHI CHÚ'
)
GO

CREATE TABLE PDT_TABLE
(
	idTable INT IDENTITY PRIMARY KEY,
	tableName NVARCHAR(50) NOT NULL,
	tableStatus INT NOT NULL DEFAULT -1,-- -1 bàn trống, 1 bàn có người
	describeTable NVARCHAR(MAX) DEFAULT 'ĐÂY LÀ MÔ TẢ OR GHI CHÚ',

	idKhuVuc INT NOT NULL,

	FOREIGN KEY (idKhuVuc) REFERENCES PDT_KHUVUC(idKhuVuc)
)
GO


CREATE TABLE PDT_BILL
(
	idBill INT IDENTITY PRIMARY KEY,
	billDataCheckIn DATETIME NOT NULL,
	billDateCheckOut DATE,
	billNameAccount NVARCHAR(50) DEFAULT 'NULL',	
	billStatus INT NOT NULL DEFAULT -1,--1: da thanh toan, 0 chua thanh toan
	billTotal FLOAT DEFAULT 0,

	idTable INT NOT NULL,

	FOREIGN KEY (idTable) REFERENCES PDT_TABLE(idTable)
)
GO

CREATE TABLE PDT_BILLINFO
(
	idBillInfo INT IDENTITY PRIMARY KEY,
	billInfoCount INT NOT NULL DEFAULT 0,

	idBill INT NOT NULL,
	idFood INT NOT NULL,

	FOREIGN KEY (idBill) REFERENCES PDT_Bill(idBill),
	FOREIGN KEY (idFood) REFERENCES PDT_FOOD(idFood) 
)
GO

USE QL_COFFEE
GO

CREATE TRIGGER UTG_UPDATEBILL
ON PDT_BILL FOR INSERT,UPDATE,DELETE
AS
BEGIN
	DECLARE @IDTABLE INT
	SELECT @IDTABLE=idTable FROM INSERTED
	UPDATE PDT_TABLE SET tableStatus=1 WHERE idTable=@IDTABLE
END
GO
--Update by NguyenVanPhuc
--Date 12/02/2018
--------------------
CREATE TRIGGER UTG_UPDATEBILLDELETE
ON PDT_BILL FOR INSERT,UPDATE,DELETE
AS
BEGIN
	DECLARE @IDTABLE INT
	SELECT @IDTABLE=idTable FROM DELETED
	UPDATE PDT_TABLE SET tableStatus=-1 WHERE idTable=@IDTABLE
END
GO
--Update by NguyenVanPhuc
--Date 12/02/2018
--------------------------
--Update by NguyenVanPhuc
--Date 10/02/2018

CREATE PROC USP_INSERTBILLINFO
@idBill INT, @idFood INT ,@countBillInfo INT
AS
BEGIN

	--UPDATE 10/02/2018
	--CHẶN LỖI
	DECLARE @countExitBill int =-1

	SELECT @countExitBill=COUNT(*)
	FROM PDT_BILL
	WHERE idBill=@idBill

	IF(@countExitBill<1)
	BEGIN
		PRINT N'bàn chưa được mở, không thể thêm món! '
		RETURN
	END
	-----------------
	DECLARE @isExitFood INT
	DECLARE @countFood INT =0

	SELECT @isExitFood =idFood,@countFood=billInfoCount 
	FROM PDT_BILLINFO
	WHERE idBill=@idBill AND idFood=@idFood

	--UPDATE 07/03/2018
	--Ràng buộc số lượng
	IF(@countFood+@countBillInfo<=0)
	BEGIN
		PRINT N'Số lượng món ăn không thể nhỏ hơn không'
		RETURN
	END

	IF(@isExitFood>0)
	BEGIN
		UPDATE PDT_BILLINFO 
		SET billInfoCount =@countBillInfo+@countFood
		WHERE idBill=@idBill AND idFood=@idFood
	END

	ELSE
	BEGIN
		INSERT INTO PDT_BILLINFO(idBill,idFood,billInfoCount)
		VALUES (@idBill,@idFood,@countBillInfo)
	END

END
GO