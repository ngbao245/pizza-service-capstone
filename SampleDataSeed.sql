USE [PizzaService]
GO

BEGIN TRANSACTION;

-- Check and Delete if any data exists in the OptionItem table
IF EXISTS (SELECT 1 FROM [dbo].[OptionItem])
BEGIN
	DELETE FROM [dbo].[OptionItem];
END
GO

-- Check and Delete if any data exists in the Product table
IF EXISTS (SELECT 1 FROM [dbo].[Product])
BEGIN
	DELETE FROM [dbo].[Product];
END
GO

-- Check and Delete if any data exists in the Table table
IF EXISTS (SELECT 1 FROM [dbo].[Table])
BEGIN
	DELETE FROM [dbo].[Table];
END
GO

-- Check and Delete if any data exists in the Category table
IF EXISTS (SELECT 1 FROM [dbo].[Category])
BEGIN
	DELETE FROM [dbo].[Category];
END
GO

-- Check and Delete if any data exists in the Zone table
IF EXISTS (SELECT 1 FROM [dbo].[Zone])
BEGIN
	DELETE FROM [dbo].[Zone];
END
GO

-- Check and Delete if any data exists in the Option table
IF EXISTS (SELECT 1 FROM [dbo].[Option])
BEGIN
	DELETE FROM [dbo].[Option];
END
GO

-- INSERT DATA

-- Thêm dữ liệu vào bảng Option
INSERT INTO [PizzaService].[dbo].[Option] 
    ([Id], [Name], [Description], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy]) 
VALUES 
    (NEWID(), N'Cỡ Pizza', N'Chọn kích thước pizza', GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), N'Viền Pizza', N'Chọn loại viền', GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), N'Thêm Topping', N'Chọn thêm topping', GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), N'Nước uống', N'Chọn loại nước uống', GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), N'Combo khuyến mãi', N'Chọn combo ưu đãi', GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL);

-- Thêm dữ liệu vào bảng Zone
INSERT INTO [PizzaService].[dbo].[Zone] 
    ([Id], [Name], [Capacity], [Description], [Status], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy]) 
VALUES 
    (NEWID(), N'Khu vực VIP', 10, N'Không gian riêng tư, phục vụ đặc biệt', 1, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), N'Khu vực Gia đình', 20, N'Dành cho nhóm gia đình, không gian ấm cúng', 1, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), N'Khu vực Ban công', 15, N'Không gian ngoài trời, thoáng mát', 0, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), N'Khu vực Quầy bar', 8, N'Gần quầy bar, phù hợp cho nhóm nhỏ', 1, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), N'Khu vực Sân vườn', 25, N'Không gian rộng, nhiều cây xanh', 0, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL);

-- Thêm dữ liệu vào bảng Category
INSERT INTO [PizzaService].[dbo].[Category] 
    ([Id], [Name], [Description], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy]) 
VALUES 
    (NEWID(), N'Pizza', N'Các loại pizza truyền thống và đặc biệt', GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), N'Món ăn kèm', N'Khoai tây chiên, gà rán, salad,...', GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), N'Đồ uống', N'Nước ngọt, bia, cocktail và đồ uống khác', GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), N'Tráng miệng', N'Bánh ngọt, kem, tiramisu,...', GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), N'Combo', N'Các combo tiết kiệm cho gia đình và nhóm', GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL);

-- Chèn dữ liệu vào bảng Table
DECLARE @VipZoneId UNIQUEIDENTIFIER = (SELECT Id FROM [PizzaService].[dbo].[Zone] WHERE [Name] = N'Khu vực VIP');
DECLARE @FamilyZoneId UNIQUEIDENTIFIER = (SELECT Id FROM [PizzaService].[dbo].[Zone] WHERE [Name] = N'Khu vực Gia đình');
DECLARE @BalconyZoneId UNIQUEIDENTIFIER = (SELECT Id FROM [PizzaService].[dbo].[Zone] WHERE [Name] = N'Khu vực Ban công');
DECLARE @BarZoneId UNIQUEIDENTIFIER = (SELECT Id FROM [PizzaService].[dbo].[Zone] WHERE [Name] = N'Khu vực Quầy bar');
DECLARE @GardenZoneId UNIQUEIDENTIFIER = (SELECT Id FROM [PizzaService].[dbo].[Zone] WHERE [Name] = N'Khu vực Sân vườn');
INSERT INTO [PizzaService].[dbo].[Table] 
    ([Id], [Capacity], [ZoneId], [Status], [CurrentOrderId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy], [Code]) 
VALUES 
    (NEWID(), 1, @VipZoneId, 0, NULL, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL, 'A01'),
    (NEWID(), 2, @FamilyZoneId, 1, NULL, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL, 'A02'),
    (NEWID(), 3, @BalconyZoneId, 3, NULL, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL, 'A12'),
    (NEWID(), 4, @BarZoneId, 4, NULL, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL, 'B01'),
    (NEWID(), 5, @GardenZoneId, 5, NULL, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL, 'B02');

-- Chèn dữ liệu vào bảng Product
DECLARE @PizzaCategory UNIQUEIDENTIFIER = (SELECT TOP 1 [Id] FROM [PizzaService].[dbo].[Category] WHERE [Name] = N'Pizza');
DECLARE @SideDishCategory UNIQUEIDENTIFIER = (SELECT TOP 1 [Id] FROM [PizzaService].[dbo].[Category] WHERE [Name] = N'Món ăn kèm');
DECLARE @DrinkCategory UNIQUEIDENTIFIER = (SELECT TOP 1 [Id] FROM [PizzaService].[dbo].[Category] WHERE [Name] = N'Đồ uống');
DECLARE @DessertCategory UNIQUEIDENTIFIER = (SELECT TOP 1 [Id] FROM [PizzaService].[dbo].[Category] WHERE [Name] = N'Tráng miệng');
DECLARE @ComboCategory UNIQUEIDENTIFIER = (SELECT TOP 1 [Id] FROM [PizzaService].[dbo].[Category] WHERE [Name] = N'Combo');
INSERT INTO [PizzaService].[dbo].[Product] 
    ([Id], [Name], [Price], [Description], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy]) 
VALUES 
    (NEWID(), N'Pizza Hải Sản', 25000, N'Pizza hải sản tươi ngon với tôm, mực, và phô mai mozzarella.', @PizzaCategory, 1, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), N'Khoai Tây Chiên', 5000, N'Khoai tây chiên giòn rụm, ăn kèm với sốt chấm đặc biệt.', @SideDishCategory, 0, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), N'Pepsi Lon', 2000, N'Nước giải khát Pepsi lon 330ml, uống mát lạnh.', @DrinkCategory, 1, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), N'Tiramisu', 7000, N'Bánh tiramisu mềm mịn với hương vị cà phê và cacao.', @DessertCategory, 0, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), N'Combo Tiết Kiệm', 35000, N'Combo gồm Pizza, Khoai Tây Chiên và 2 Pepsi.', @ComboCategory, 1, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL);


-- Thêm dữ liệu vào bảng OptionItem
DECLARE @PizzaSizeOption UNIQUEIDENTIFIER = (SELECT TOP 1 [Id] FROM [PizzaService].[dbo].[Option] WHERE [Name] = N'Cỡ Pizza');
DECLARE @PizzaCrustOption UNIQUEIDENTIFIER = (SELECT TOP 1 [Id] FROM [PizzaService].[dbo].[Option] WHERE [Name] = N'Viền Pizza');
DECLARE @ToppingOption UNIQUEIDENTIFIER = (SELECT TOP 1 [Id] FROM [PizzaService].[dbo].[Option] WHERE [Name] = N'Thêm Topping');
DECLARE @DrinkOption UNIQUEIDENTIFIER = (SELECT TOP 1 [Id] FROM [PizzaService].[dbo].[Option] WHERE [Name] = N'Nước uống');
INSERT INTO [PizzaService].[dbo].[OptionItem] 
    ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy]) 
VALUES 
    -- Cỡ Pizza
    (NEWID(), N'Nhỏ (S)', 0, @PizzaSizeOption, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), N'Vừa (M)', 3000, @PizzaSizeOption, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), N'Lớn (L)', 6000, @PizzaSizeOption, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),

    -- Viền Pizza
    (NEWID(), N'Viền Mỏng', 0, @PizzaCrustOption, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), N'Viền Dày', 2000, @PizzaCrustOption, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), N'Viền Phô Mai', 4000, @PizzaCrustOption, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),

    -- Topping
    (NEWID(), N'Tôm', 1500, @ToppingOption, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), N'Bò', 2000, @ToppingOption, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), N'Xúc Xích', 1000, @ToppingOption, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),

    -- Nước uống
    (NEWID(), N'Coca-Cola', 1000, @DrinkOption, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), N'Pepsi', 1000, @DrinkOption, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), N'Sprite', 1000, @DrinkOption, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL);

DECLARE @PizzaProduct UNIQUEIDENTIFIER = (SELECT TOP 1 [Id] FROM [PizzaService].[dbo].[Product] WHERE [Name] = N'Pizza Hải Sản');
DECLARE @SideDishProduct UNIQUEIDENTIFIER = (SELECT TOP 1 [Id] FROM [PizzaService].[dbo].[Product] WHERE [Name] = N'Khoai Tây Chiên');
DECLARE @DrinkProduct UNIQUEIDENTIFIER = (SELECT TOP 1 [Id] FROM [PizzaService].[dbo].[Product] WHERE [Name] = N'Pepsi Lon');
DECLARE @DessertProduct UNIQUEIDENTIFIER = (SELECT TOP 1 [Id] FROM [PizzaService].[dbo].[Product] WHERE [Name] = N'Tiramisu');
DECLARE @ComboProduct UNIQUEIDENTIFIER = (SELECT TOP 1 [Id] FROM [PizzaService].[dbo].[Product] WHERE [Name] = N'Combo Tiết Kiệm');
INSERT INTO [PizzaService].[dbo].[ProductOption]
    ([Id], [ProductId], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy]) 
VALUES
    (NEWID(), @PizzaProduct, @PizzaSizeOption, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), @PizzaProduct, @PizzaCrustOption, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), @PizzaProduct, @ToppingOption, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), @DrinkProduct, @DrinkOption, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    (NEWID(), @ComboProduct, @ToppingOption, GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL);

COMMIT;
GO
