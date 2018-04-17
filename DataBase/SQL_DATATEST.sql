USE QL_COFFEE
GO

DECLARE @i INT =0
DECLARE @n INT =10

WHILE(@i <@n)
BEGIN

INSERT INTO PDT_KHUVUC(khuVucName) VALUES ('Khu ' + CAST(@i AS nvarchar(100)))


SET @i+=1
END
GO

DECLARE @I INT= 3
WHILE(@I<60)
BEGIN
	INSERT INTO PDT_TABLE(tableName,tableStatus,idKhuVuc) VALUES ('Bàn '+CAST(@I AS nvarchar(10)),-1,1)
	SET @I=@I+1
END
GO

INSERT INTO PDT_CATEGORYFOOD(categoryName) VALUES (N'COFFFEE')
INSERT INTO PDT_CATEGORYFOOD(categoryName) VALUES (N'NƯỚC PHA CHẾ')
INSERT INTO PDT_CATEGORYFOOD(categoryName) VALUES (N'NƯỚC GIẢI KHÁT')
INSERT INTO PDT_CATEGORYFOOD(categoryName) VALUES (N'THUỐC LÁ')
INSERT INTO PDT_CATEGORYFOOD(categoryName) VALUES (N'ĐỒ ĂN')
GO

INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'Phê đen',N'Ly',10000,1)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'Phê sữa',N'Ly',12000,1)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'FĐSG',N'Ly',15000,1)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'FSSG',N'Ly',17000,1)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'CAPUCHINO',N'Ly',20000,1)


INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'Revai',N'Chai',17000,3)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'String dâu',N'Chai',10000,3)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'String vàng',N'Chai',10000,3)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'Bò húc',N'Chai',15000,3)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'N1',N'Chai',15000,3)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'0 Độ',N'Chai',15000,3)

INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'Cacao',N'Ly',17000,2)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'Nước Chanh',N'Ly',20000,2)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'B52',N'Ly',50000,2)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'Rob Roys',N'Ly',120000,2)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'Cocktail sidecar',N'Ly',90000,2)


INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'Thuốc 3 số',N'Gói',40000,4)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'Thuốc ngựa',N'Gói',26000,4)
INSERT INTO PDT_FOOD(FoodName,donViTinh,gia,idCategoryFood) VALUES (N'Ngựa Điếu',N'Điếu',1200,4)
GO
