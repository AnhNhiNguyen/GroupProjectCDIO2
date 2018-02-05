USE QL_COFFEE_CS414BIS_PDT
--câu lệnh add record vào bảng
DECLARE @i INT =0
DECLARE @n INT =10

WHILE(@i <@n)
BEGIN

INSERT INTO PDT_KHUVUC(khuVucName) VALUES ('Khu ' + CAST(@i AS nvarchar(100)))


SET @i+=1
END
GO
--------------------------
SELECT * FROM PDT_CATEGORYFOOD
----------------------------
INSERT INTO PDT_CATEGORYFOOD(categoryName) VALUES (N'COFFFEE')
INSERT INTO PDT_CATEGORYFOOD(categoryName) VALUES (N'NƯỚC PHA CHẾ')
INSERT INTO PDT_CATEGORYFOOD(categoryName) VALUES (N'NƯỚC GIẢI KHÁT')
INSERT INTO PDT_CATEGORYFOOD(categoryName) VALUES (N'THUỐC LÁ')
INSERT INTO PDT_CATEGORYFOOD(categoryName) VALUES (N'ĐỒ ĂN')
----------------------------
SELECT * FROM PDT_FOOD
---------------------
SELECT * FROM PDT_FOOD WHERE idCategoryFood=1
---------------------
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'Phê đen',N'Chai',70000,1)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'Phê sữa',N'Chai',70000,1)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'ĐỒ ĂN',N'Chai',70000,1)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'ĐỒ ĂN',N'Chai',70000,1)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'ĐỒ ĂN',N'Chai',70000,1)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'ĐỒ ĂN',N'Chai',70000,1)

INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'Revai',N'Chai',70000,3)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'String dâu',N'Chai',70000,3)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'String vàng',N'Chai',70000,3)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'Bò húc',N'Chai',70000,3)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'N1',N'Chai',70000,3)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'ĐỒ ĂN',N'Chai',70000,3)

INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'Cacao nóng',N'Chai',70000,2)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'Cacao đá',N'Chai',70000,2)


INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'Thuốc 3 số',N'Chai',70000,4)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'Thuốc ngựa',N'Chai',70000,4)
---------------------
USE QL_COFFEE_CS414BIS_PDT
SELECT FoodName,donViTinh,gia FROM PDT_FOOD WHERE idCategoryFood=1
--------------------------------
SELECT * FROM PDT_BILL WHERE idTable=2
--------------------------------

INSERT INTO PDT_BILL(status,billDataCheckIn,billDateCheckOut,idTable) VALUES (-1,GETDATE(),GETDATE(),2)



------------------
SELECT * FROM PDT_BILLINFO WHERE idBill=4

INSERT INTO PDT_BILLINFO(billInfoCount,idBill,idFood) VALUES (1,4,8)
-------------------------------------
SELECT * FROM PDT_BILL

INSERT INTO PDT_BILL(status,billDataCheckIn,billDateCheckOut,idTable) VALUES (-1,GETDATE(),GETDATE(),2)
--------------------------
SELECT idBill FROM PDT_BILL WHERE idTable=4
 
