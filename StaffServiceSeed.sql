-- ====================================================
-- Author: BaoBiBo
-- Create date: 05/04/2025
-- Description: Data seed template easy to maintain
-- ====================================================

USE [PizzaService]
GO

BEGIN TRY
	BEGIN TRANSACTION;
    --------------------------------------------
    -- XÓA DỮ LIỆU CŨ (theo thứ tự quan hệ khóa)
    --------------------------------------------
	-- Example ---------------------------------
	-- IF EXISTS (SELECT 1 FROM [dbo].[Topping])
    -- BEGIN
    --    DELETE FROM [dbo].[Topping];
    --    PRINT N'Đã xóa dữ liệu bảng Topping.';
    -- END
	--------------------------------------------
	-- Code here

	IF EXISTS (SELECT 1 FROM StaffZone)
	BEGIN
		DELETE FROM StaffZone;
		PRINT N'Đã xóa dữ liệu bảng StaffZone.';
	END

	IF EXISTS (SELECT 1 FROM StaffZoneSchedule)
	BEGIN
		DELETE FROM StaffZoneSchedule;
		PRINT N'Đã xóa dữ liệu bảng StaffZoneSchedule.';
	END

	IF EXISTS (SELECT 1 FROM SwapWorkingSlot)
	BEGIN
		DELETE FROM SwapWorkingSlot;
		PRINT N'Đã xóa dữ liệu bảng SwapWorkingSlot.';
	END

	IF EXISTS (SELECT 1 FROM WorkingSlotRegister)
	BEGIN
		DELETE FROM WorkingSlotRegister;
		PRINT N'Đã xóa dữ liệu bảng WorkingSlotRegister.';
	END
	
	IF EXISTS (SELECT 1 FROM Staff)
	BEGIN
		DELETE FROM Staff;
		PRINT N'Đã xóa dữ liệu bảng Staff.';
	END

	IF EXISTS (SELECT 1 FROM AppUsers)
		BEGIN
		DELETE FROM AppUsers;
		PRINT N'Đã xóa dữ liệu bảng AppUsers.';
	END

	--IF EXISTS (SELECT 1 FROM Zone)
	--	BEGIN
	--	DELETE FROM Zone;
	--	PRINT N'Đã xóa dữ liệu bảng Zone.';
	--END

	-- Xài tạm do vướng FK
	DELETE FROM Zone 
	WHERE [Name] IN (
		N'Khu vực A',
		N'Khu vực B',
		N'Khu vực C',
		N'Khu vực D',
		N'Khu vực E',
		N'Khu vực F',
		N'Khu vực G',
		N'Khu vực bếp nóng',
		N'Khu vực bếp lạnh'
	);


	IF EXISTS (SELECT 1 FROM WorkingSlot)
		BEGIN
		DELETE FROM WorkingSlot;
		PRINT N'Đã xóa dữ liệu bảng WorkingSlot.';
	END

	IF EXISTS (SELECT 1 FROM Shift)
		BEGIN
		DELETE FROM Shift;
		PRINT N'Đã xóa dữ liệu bảng Shift.';
	END

    --------------------------------------------
    -- SEED DỮ LIỆU MỚI
    --------------------------------------------
	-- Example ---------------------------------
	--------------------------------------------
    -- INSERT INTO [PizzaService].[dbo].[Option] 
	-- ([Id], [Name], [Description], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy]) 
	-- VALUES 
    -- (NEWID(), N'Cỡ Pizza', N'Chọn kích thước pizza', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
    -- (NEWID(), N'Viền Pizza', N'Chọn loại viền', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);
	--------------------------------------------
	-- Code here

	-- ZONE SEEDS
	 INSERT INTO Zone 
	 ([Id], [Name], [Description], [Type], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy]) 
	 VALUES 
     (NEWID(), N'Khu vực A', N'Khu vực bàn chính gần quầy bar', 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
     (NEWID(), N'Khu vực B', N'Khu vực bàn trong nhà gần cửa sổ', 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
     (NEWID(), N'Khu vực C', N'Khu vực bàn phía ngoài trời', 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
     (NEWID(), N'Khu vực D', N'Khu vực yên tĩnh dành cho gia đình', 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
     (NEWID(), N'Khu vực E', N'Khu vực bàn đơn và đôi', 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
     (NEWID(), N'Khu vực F', N'Khu vực bàn dành cho khách nhanh, nhóm nhỏ', 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
     (NEWID(), N'Khu vực G', N'Khu vực bàn gần khu vực bếp', 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
     (NEWID(), N'Khu vực bếp nóng', N'Nơi chế biến pizza và món nóng', 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
     (NEWID(), N'Khu vực bếp lạnh', N'Nơi chế biến salad và món lạnh', 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- SHIFT SEEDS
	DECLARE @morningShift UNIQUEIDENTIFIER = NEWID();
	DECLARE @noonShift UNIQUEIDENTIFIER = NEWID();
	DECLARE @eveningShift UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Shift 
	 ([Id], [Name], [Description], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy]) 
	 VALUES 
     (@morningShift, N'Ca sáng', NULL, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
     (@noonShift, N'Ca trưa', NULL, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
     (@eveningShift, N'Ca chiều', NULL, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- WORKING SLOT SEEDS
	DECLARE @MondayId UNIQUEIDENTIFIER = '478fcc2b-4839-4fc2-baff-db273aa9e0b4';
	DECLARE @TuesdayId UNIQUEIDENTIFIER = 'f8dec225-dbb2-4961-9be6-9f11eac723ab';
	DECLARE @WednesdayId UNIQUEIDENTIFIER = '24a0e861-15b0-4d60-ac54-adf5ee0f1ccd';
	DECLARE @ThursdayId UNIQUEIDENTIFIER = '1afe24bd-4d62-480b-a501-692bdd375bcb';
	DECLARE @FridayId UNIQUEIDENTIFIER = '93e1d6e5-b144-4099-be3c-833f7ef87fa3';
	DECLARE @SaturdayId UNIQUEIDENTIFIER = '4c37288c-3a9c-4d6e-9565-4302a5a28669';
	DECLARE @SundayId UNIQUEIDENTIFIER = 'c6f2594b-71f8-46ff-9584-c62c2e02151e';

	DECLARE @ShiftStartMorning TIME = '08:00', @ShiftEndMorning TIME = '12:00';
	DECLARE @ShiftStartNoon TIME = '12:00', @ShiftEndNoon TIME = '17:00';
	DECLARE @ShiftStartEvening TIME = '17:00', @ShiftEndEvening TIME = '22:00';

	DECLARE @DayId UNIQUEIDENTIFIER, @DayName NVARCHAR(50);
	DECLARE day_cursor CURSOR FOR 
	SELECT Id, Name FROM [dbo].[Day] WHERE IsDeleted = 0;
	OPEN day_cursor;
	FETCH NEXT FROM day_cursor INTO @DayId, @DayName;
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
    -- Ca sáng
    INSERT INTO WorkingSlot (Id, ShiftName, DayName, ShiftStart, ShiftEnd, Capacity, DayId, ShiftId, CreatedDate, CreatedBy, IsDeleted)
    VALUES (NEWID(), N'Ca sáng', @DayName, @ShiftStartMorning, @ShiftEndMorning, 3, @DayId, @morningShift, GETDATE(), N'Admin', 0);
    -- Ca trưa
    INSERT INTO WorkingSlot (Id, ShiftName, DayName, ShiftStart, ShiftEnd, Capacity, DayId, ShiftId, CreatedDate, CreatedBy, IsDeleted)
    VALUES (NEWID(), N'Ca trưa', @DayName, @ShiftStartNoon, @ShiftEndNoon, 3, @DayId, @noonShift, GETDATE(), N'Admin', 0);
    -- Ca tối
    INSERT INTO WorkingSlot (Id, ShiftName, DayName, ShiftStart, ShiftEnd, Capacity, DayId, ShiftId, CreatedDate, CreatedBy, IsDeleted)
    VALUES (NEWID(), N'Ca tối', @DayName, @ShiftStartEvening, @ShiftEndEvening, 3, @DayId, @eveningShift, GETDATE(), N'Admin', 0);

    FETCH NEXT FROM day_cursor INTO @DayId, @DayName;
	END
	CLOSE day_cursor;
	DEALLOCATE day_cursor;

	-- APPUSERS SEEDS
	INSERT INTO AppUsers (Id, CreatedDate, ModifiedDate, CreatedBy, ModifiedBy, IsDeleted, DeletedAt, DeletedBy, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount)
	VALUES 
	--Manager
	('3674B44D-225E-4ADF-26F0-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'NhatHao', 'NHATHAO', '', '', 0, 'AQAAAAIAAYagAAAAEC0y9ulbDeQGS1fSV/sW7SIOi8ICExxgCDGn6+hgIZ8zJs++omzXBhSiFg1wdvbqiQ==', 'SYXK74OEKI2SCDPVBASBITBJU2QMO77M', '6dcf593c-ef1a-4e86-97fd-3f05d68cfa50', NULL, 0, 0, NULL, 1, 0),
	('E8EEA46D-4BA6-4C07-26F1-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'HoangBao', 'HOANGBAO', '', '', 0, 'AQAAAAIAAYagAAAAEGegfCz2aZVCuV4ElP3pcUYbn3wAqFoQoS93sWXsY7x0DwsGEkbZ+S7bHENs7vh8ew==', 'RVQ5P2OGDKIMAIOMK3GCBZ3C3NJGP36Y', '06d3582a-6d31-4d51-bf25-6508d17a51c0', NULL, 0, 0, NULL, 1, 0),
	('9AF63A0D-559A-4270-26F2-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'HungHao', 'HUNGHAO', '', '', 0, 'AQAAAAIAAYagAAAAEO/QUAQmkHhVZbg3i9E/ia6B+/FiA0mMFUbRLBhWcbsvcuJBEBlG+Jfc2I4pPndMJA==', 'WYCG4YWGZLYKK2T6JYFHXZLB6DNXOMBE', '343cbb3d-98f7-40c6-a6e2-806dbbe83f56', NULL, 0, 0, NULL, 1, 0),
	('EBD4F98C-0FF5-4127-26F3-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'TruongThanh', 'TRUONGTHANH', '', '', 0, 'AQAAAAIAAYagAAAAELxXUOcrHKrrxv5h89zcsl9mwYPy4LIEUtNUkjZpWGBPhjv8YlweCTHVelpku3kshQ==', 'ORW4DXAR6QMKTVS7Z722DAYGIA6FGUYB', '81e66519-d3c7-4431-9fda-befa8644ffe0', NULL, 0, 0, NULL, 1, 0),
	('EB1A0E6D-3475-4A30-26F4-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'SyQuang', 'SYQUANG', '', '', 0, 'AQAAAAIAAYagAAAAEH+hkizUUmBP1OkgzlHee7M/jcHgjSoT9XR5U8YZeqytYTK/I5IrzGgaVsuA4aLnNQ==', 'KLIHFUFXBL32CSAFXJIYBVF3FII6LKYX', 'c2e13722-7926-4236-93c0-abc56b4e84f6', NULL, 0, 0, NULL, 1, 0),
	
	--Staff FullTime
	('58162CDE-E9ED-498D-26F5-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'StaffFT_1', 'STAFFFT_1', '', '', 0, 'AQAAAAIAAYagAAAAEOuPK76YGqG7sBBcqaciMi4zeYM1XvjOUFfaZYPwi/weib59WJkTHieujGc45dbP9A==', '7IDKI47BNICQAWZJLEATUQ5442XVG4HK', 'd625fb22-1230-4359-98bd-fdd1332edd4f', NULL, 0, 0, NULL, 1, 0),
	('9F251669-2B22-4D5D-26F6-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'StaffFT_2', 'STAFFFT_2', '', '', 0, 'AQAAAAIAAYagAAAAENysnYKsFAksMpYvCad7M2tBRXXXrJ31uuyN5CbxqNEiVlTC1LcVGRjT+CxzIEIWxg==', 'YHD4HDWW7UBAJGKXELLWB7OC67MQXOZ6', '003dda6d-76dd-4ed8-b26f-ff5a8864ecde', NULL, 0, 0, NULL, 1, 0),
	('44249BB9-490E-4475-26F7-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'StaffFT_3', 'STAFFFT_3', '', '', 0, 'AQAAAAIAAYagAAAAEMD/OjupXIIIjAbCHDtY19v4dqKEqyvK/JtlLMJDuaNi+lFYeRx1CDkM2Ya+8OstYw==', 'YFKFKC5DFXHABCWWABR7AE6I4YS6W3VH', '15f63763-2760-4bd8-9d99-5ca16ab0385f', NULL, 0, 0, NULL, 1, 0),
	('FA4090B7-1798-4BF6-26F8-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'StaffFT_4', 'STAFFFT_4', '', '', 0, 'AQAAAAIAAYagAAAAEBhcgCm42viHCBVNpYsILEjXZ4rscoPkd1fGDZphrtEvyTsTH2vIWwZ1tgWcYNcQ3Q==', 'TZ6DVMWEPGDWNTPMTIRLZHVOQ2G5WRVE', '1fc1b978-b928-4185-8184-19b10178e3da', NULL, 0, 0, NULL, 1, 0),
	('97E200FD-18C3-4A83-26F9-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'StaffFT_5', 'STAFFFT_5', '', '', 0, 'AQAAAAIAAYagAAAAEL4MgDHha3kSggen5J3VuxkbWmQrZ7YUy78A9WEcqWEb5OlrErqloOzEZ4OwLdw+kA==', 'YVS54F6HAX6Q5WAVLEO4TXO4FIALQ7GC', '4e13c9da-9500-482b-9339-13e2780b4d58', NULL, 0, 0, NULL, 1, 0),
	('47EF30F4-D765-4B50-26FA-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'StaffFT_6', 'STAFFFT_6', '', '', 0, 'AQAAAAIAAYagAAAAEOhtFsZQNORyXL5kwR/oSjs/v/cGN5P18KKl+i2QOTmeB9ELdiu7LUNoPXOcmYePJA==', 'ULTG4AKY57YRNAFKPN4R3VMDYAMQSQAU', '7b32694a-bbf5-4b80-90f5-274cc3b70225', NULL, 0, 0, NULL, 1, 0),
	('07E4FE0B-9E81-4207-26FB-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'StaffFT_7', 'STAFFFT_7', '', '', 0, 'AQAAAAIAAYagAAAAENAKlI+q2KIR68qTnbZ79+gX/2tKReNWGoMG6fMaKYRiwJd7kv72tEbj7i5h2sAVyA==', 'XPUQHBUZRHJOJONWO42DJZZTNR5C4WWL', 'df9b5510-8191-47fa-805a-58608f2499eb', NULL, 0, 0, NULL, 1, 0),
	('F5805027-0058-4D29-26FC-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'StaffFT_8', 'STAFFFT_8', '', '', 0, 'AQAAAAIAAYagAAAAEHn/I5Mnq+9ml8rGvKtnOwY6VEeAnSBrg7RutY+fWS3etF+rn4d7wXMb7XE3ew5Gug==', 'KEBPNECA5BWUJFDQXPNGVJUJH27L3AO7', '3c44e7f7-c847-4d56-a54f-83216021201a', NULL, 0, 0, NULL, 1, 0),
	('8088AF31-A752-4061-26FD-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'StaffFT_9', 'STAFFFT_9', '', '', 0, 'AQAAAAIAAYagAAAAEFVAgDfxjlKieXxMP8YaYiCMNpB5IEwoxr8HjkhvXQSneXFPZXQDV6QgIMBO/v13vg==', '7W7KOONCHAG2WLN4CZSIJY7OF763BZHN', 'a1a6c817-3e34-42e9-a45a-f4bee7f21cca', NULL, 0, 0, NULL, 1, 0),
	('8E20D6DF-1440-4D5E-26FE-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'StaffFT_10', 'STAFFFT_10', '', '', 0, 'AQAAAAIAAYagAAAAEI+EKJ1pn5oKfJH0pZgD9K+MvefYp6HhYfrFERgfTpuAWQmRNeihvgc6peHE9B/nmA==', 'TKZBTIF5N3B5PMZFPUNCGQ2FARKDDIO4', '791711e2-a9a4-4a7b-a41e-9e80083d7978', NULL, 0, 0, NULL, 1, 0),
	('8ACA2EF4-E611-4CD1-26FF-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'StaffFT_11', 'STAFFFT_11', '', '', 0, 'AQAAAAIAAYagAAAAEBr8Ox+OHkDkXZ6KmwDIjm/GGbOUHnvaf+w/zymrFWX5AJdHulJKlfU75TZ2U1BMXw==', 'MXGTRQ2FBL3CFA44UNTA7C4RZRQOYBAQ', '1afc26d5-a72d-417c-ba5a-c4a3e8472244', NULL, 0, 0, NULL, 1, 0),
	('0CA7A9B7-2DE2-4988-2700-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'StaffFT_12', 'STAFFFT_12', '', '', 0, 'AQAAAAIAAYagAAAAEOGFruz192mid1OLj2eAKb47zQso7xzTxWcJ9UWhl9Ih7PdxoHp6HHj/yA9nQQMikg==', '43FEMEGS7UBY6XQ73S24X3LRAOCZUOCQ', 'bfc0eeaa-97bb-4efe-8789-9a114b1b9c35', NULL, 0, 0, NULL, 1, 0),
	('461D0957-AA4D-4A05-2701-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'StaffFT_13', 'STAFFFT_13', '', '', 0, 'AQAAAAIAAYagAAAAEE53B5/5eSj2t21p2tVyWa4UCmGtBxPmz30o3oxEB7/8YXRN8F7mVF40LRl9pTOHUg==', '6L6U63KJDMGLVVHPMPOORCF63MASCDKP', '52c136f5-478b-4afe-8ede-a0fd8506f030', NULL, 0, 0, NULL, 1, 0),
	('A301A7C0-C7E0-4FA9-2702-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'StaffFT_14', 'STAFFFT_14', '', '', 0, 'AQAAAAIAAYagAAAAEH5LM2D4+jEiGNUFATr7b8/90s8g6VX9kaH5ZDjwkhmk4KpfbKenar08mAQQUvZrxw==', 'YTZ2CTB6N2QXJQK5WOK5Q3WSCMQEOP7A', '5d76b817-08e5-4050-9fb3-5c0fdbde0482', NULL, 0, 0, NULL, 1, 0),
	
	--Staff PartTime
	('8E8FFC7F-3EAA-4EA2-2703-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'StaffPT_1', 'STAFFPT_1', '', '', 0, 'AQAAAAIAAYagAAAAEIeprJSwvxNmTnKocWte4PUrSjEA6cIdaGJWQMgG0AJo48Z0uhPgfNuqUB9Pns5d8A==', 'GRFZFRCFUG5PUVXCRIBOLUKMXJWHLFQB', 'ea6a39d7-b83e-4e90-a6de-913e4996f5d8', NULL, 0, 0, NULL, 1, 0),
	('3263F3B7-026F-45F9-2704-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'StaffPT_2', 'STAFFPT_2', '', '', 0, 'AQAAAAIAAYagAAAAEGQ06h0yCV0P58bGxVYPT0/1Tjt9Lvsx4pMbttHa8dcYutXKtB6o6NSbv+St9VrIlQ==', '3KD66ACTSJPRJ2IPHJVL6TQ3C362NUUX', '5cbdd629-1d64-4bbf-acdb-b9bb92a822e8', NULL, 0, 0, NULL, 1, 0),
	('35651B8B-BC39-42BD-2705-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'StaffPT_3', 'STAFFPT_3', '', '', 0, 'AQAAAAIAAYagAAAAEPAyL38kum+CJslOQSMuLZUvthy4CwFRqrmobRbZpkNjX5tNumLb65AjgJdCXzH34g==', 'VZK6BOXKFAFB5ZHDQUPE2H7TN7ELKKP4', '93a7f2f0-2de5-411a-a82e-1ef297e045df', NULL, 0, 0, NULL, 1, 0),
	('4DB79B84-DA2B-44C5-2706-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'StaffPT_4', 'STAFFPT_4', '', '', 0, 'AQAAAAIAAYagAAAAEFhjTJ2jrXTwWQofqRg3MXVvBYQYq5G+n05qttX4uyYRWlaVSvzwldqksjSmrpkCXQ==', 'MJEBPJDN67CGAC3T2C4364BMPKJT2AIC', 'ad2b6d66-a2c1-4660-8bb7-df3ba33dbd97', NULL, 0, 0, NULL, 1, 0),
	('195810B5-0028-4629-DB36-08DD75BBA155', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'StaffPT_5', 'STAFFPT_5', '', '', 0, 'AQAAAAIAAYagAAAAEL2aZsvHDx6LXe2QCiOCotQudRBzUr6nArfREglCD7ASasKAQ+cIIY2N/xba117eDA==', '4F5D3TLOHX7MCS77JEUVGTJ6OZKYNXS6', '0035ccb5-0c33-452e-b341-ce843cf8a43b', NULL, 0, 0, NULL, 1, 0),
	('44BA2CF7-060A-4DC0-DB37-08DD75BBA155', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'StaffPT_6', 'STAFFPT_6', '', '', 0, 'AQAAAAIAAYagAAAAEP0Mu/2lJmXwQIhnO0uToOkhLM7TEB4xK28dVg2tANhNNePONvjz4MGS44mMo/qAgQ==', 'ZYCHIFNIJWR2XX76LJ5Q6ELCSJ6C37V7', '5d229f74-003e-459c-973d-4e8b88a02f30', NULL, 0, 0, NULL, 1, 0),
	
	--Chef FullTime
	('185A6348-240C-4999-2709-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'ChefFT_1', 'CHEFFT_1', '', '', 0, 'AQAAAAIAAYagAAAAEL1j4J5GNxN33TZ77iGR1+M7kx/4idez4g/nHXbO/3NB62ARFPejRDkVm9kEQ3/Ruw==', 'NVHOTL776N4TTYETNELVDP3WTJWXWGKE', '79e51646-6b1f-4c67-bd4a-4543baeb4d4e', NULL, 0, 0, NULL, 1, 0),
	('5BCB3726-81B3-4CE2-270A-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'ChefFT_2', 'CHEFFT_2', '', '', 0, 'AQAAAAIAAYagAAAAEAjNY4rGzqoZwuwyujhTnQ8VV5RcKv6eRg45zIxf0sec3nMF3zjz0Y+8fkkEfi/zwA==', 'SGZUMZ323ZTRZSNQO52N5KTI2ZFU45KE', '6ad49c4d-9072-4270-9ee8-f2c5736b676b', NULL, 0, 0, NULL, 1, 0),
	('8B0C94CA-1A98-4BA4-270B-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'ChefFT_3', 'CHEFFT_3', '', '', 0, 'AQAAAAIAAYagAAAAEH46+dnWXDoLNMb1JEkj8Fi5iZs1pQXM2jFljRD+FTTucZoCKrlmoDv6/f62hgK70w==', 'C3MREM6I37YYXN462TPRJYXXI3HT6D4J', '9b02fb5a-972c-41f8-87b1-fab1c9e06f49', NULL, 0, 0, NULL, 1, 0),
	('90C673BF-F3FF-4137-270C-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'ChefFT_4', 'CHEFFT_4', '', '', 0, 'AQAAAAIAAYagAAAAEFBqE46EahJPusa0+WGOgabI4ReYkazwy5/2AWJCwv5hHU5Ynn1zWEl68H33zw7srw==', 'VGZFRVGFSN67HMTFRUGFMWJKPJ76IOMN', 'd565c1ee-3034-497f-9011-92fe8b7ffa4c', NULL, 0, 0, NULL, 1, 0),
	('34871E55-F0DB-4BC8-270D-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'ChefFT_5', 'CHEFFT_5', '', '', 0, 'AQAAAAIAAYagAAAAELlksUj5cTWCYWQfvnoHIxpBGvDfr+0rT1EU5G85EJ324+3Q/ym1iiSHNHl9Poki3g==', 'LK7LOSO4NL5TPEP3J534W56A3Q4SBYST', '375ae416-146b-4059-939f-2dc62499e7b4', NULL, 0, 0, NULL, 1, 0),
	('56138E89-3841-4038-270E-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'ChefFT_6', 'CHEFFT_6', '', '', 0, 'AQAAAAIAAYagAAAAEHw7e00x8L+joGVtTvl+rBdP1p8vu1d52L5qCMGAESkvEt9okWC98tZi6IpS4hBOHA==', 'RBC2AORR7EMUXOLOEWPALWAUXL5YWZC4', 'df209190-2ca5-4471-b75f-5b4780c7cb6d', NULL, 0, 0, NULL, 1, 0),
	('2B891D0C-4E2A-4952-270F-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'ChefFT_7', 'CHEFFT_7', '', '', 0, 'AQAAAAIAAYagAAAAEKZDAabGvYqab02Fd6wcHk73INjGH/f8FZ+26c3ByG2jywY9DRW/BwKxDJfj6FFX/Q==', '67JLMLKPRFQGRARKTE33VXWJ7A5CKAII', '15c95255-b4d9-4eef-b1c7-d24b1da9ebd7', NULL, 0, 0, NULL, 1, 0),
	
	--Chef PartTime
	('073CC470-FBDA-445A-2710-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'ChefPT_1', 'CHEFPT_1', '', '', 0, 'AQAAAAIAAYagAAAAEBtnm3NX9Qw70wOUTwoqkRx/zCyE60VgJpwJHf3QouzmwxaflZpXu8Ih4cs1rozVEQ==', 'FRSEOTTAJTTX5C2B6QAKJFFCZ422CXXN', '71674e85-47a1-43ec-8d46-5349afb6f6b3', NULL, 0, 0, NULL, 1, 0),
	('25B0D6DF-6FF8-4B9B-2711-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'ChefPT_2', 'CHEFPT_2', '', '', 0, 'AQAAAAIAAYagAAAAEMlDNAzIeEn5LLjbZDWONZQm9NKn6UU3iSg8fJlzNHJ0wj6BygCYeuaI+efNfB+cmw==', 'WDDEOZZAWZM47AHVQBAJIPNGQLNTMSZJ', '0866ce5e-0324-4bea-a8d5-101b1c0b4bfa', NULL, 0, 0, NULL, 1, 0),
	('A435ED4D-DBA9-44CA-2712-08DD759A0482', GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'ChefPT_3', 'CHEFPT_3', '', '', 0, 'AQAAAAIAAYagAAAAEB7K8e+F86DBqzx6ijQtKVdK3Lsu4ldzANO21Lpsow8GmbUKV0bP7qXk/uByTvRRzg==', '7563KIG2GA4PWMMXZLK3BDK3XCPJPCGK', '988b5262-ab4d-4923-8493-c940554aa8bf', NULL, 0, 0, NULL, 1, 0);

	-- STAFF SEEDS
	INSERT INTO [dbo].[Staff] (Id, FullName, Phone, Email, StaffType, Status, CreatedDate, ModifiedDate, CreatedBy, ModifiedBy, IsDeleted, DeletedAt, DeletedBy, AppUserId) 
	VALUES
	--Manager
	(NEWID(), N'Vũ Nhật Hào', '0379231040', 'haovnse161380@fpt.edu.vn', 1, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '3674B44D-225E-4ADF-26F0-08DD759A0482'),
	(NEWID(), N'Nguyễn Hoàng Bảo', '0934140524', 'baonhse172266@fpt.edu.vn', 1, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'E8EEA46D-4BA6-4C07-26F1-08DD759A0482'),
	(NEWID(), N'Nguyễn Hưng Hảo', '0946000406', 'haonhse172788@fpt.edu.vn', 1, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '9AF63A0D-559A-4270-26F2-08DD759A0482'),
	(NEWID(), N'Tống Trường Thanh', '0967992202', 'thanhttse160320@fpt.edu.vn', 1, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'EBD4F98C-0FF5-4127-26F3-08DD759A0482'),
	(NEWID(), N'Trương Sỹ Quảng', '0888509299', 'quangtsse160326@fpt.edu.vn', 1, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'EB1A0E6D-3475-4A30-26F4-08DD759A0482'),

	--Staff FullTime
	(NEWID(), N'StaffFT_1', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '58162CDE-E9ED-498D-26F5-08DD759A0482'),
	(NEWID(), N'StaffFT_2', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '9F251669-2B22-4D5D-26F6-08DD759A0482'),
	(NEWID(), N'StaffFT_3', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '44249BB9-490E-4475-26F7-08DD759A0482'),
	(NEWID(), N'StaffFT_4', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'FA4090B7-1798-4BF6-26F8-08DD759A0482'),
	(NEWID(), N'StaffFT_5', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '97E200FD-18C3-4A83-26F9-08DD759A0482'),
	(NEWID(), N'StaffFT_6', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '47EF30F4-D765-4B50-26FA-08DD759A0482'),
	(NEWID(), N'StaffFT_7', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '07E4FE0B-9E81-4207-26FB-08DD759A0482'),
	(NEWID(), N'StaffFT_8', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'F5805027-0058-4D29-26FC-08DD759A0482'),
	(NEWID(), N'StaffFT_9', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '8088AF31-A752-4061-26FD-08DD759A0482'),
	(NEWID(), N'StaffFT_10', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '8E20D6DF-1440-4D5E-26FE-08DD759A0482'),
	(NEWID(), N'StaffFT_11', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '8ACA2EF4-E611-4CD1-26FF-08DD759A0482'),
	(NEWID(), N'StaffFT_12', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '0CA7A9B7-2DE2-4988-2700-08DD759A0482'),
	(NEWID(), N'StaffFT_13', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '461D0957-AA4D-4A05-2701-08DD759A0482'),
	(NEWID(), N'StaffFT_14', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'A301A7C0-C7E0-4FA9-2702-08DD759A0482'),

	--Staff PartTime
	(NEWID(), N'StaffPT_1', '', '', 1, 0, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '8E8FFC7F-3EAA-4EA2-2703-08DD759A0482'),
	(NEWID(), N'StaffPT_2', '', '', 1, 0, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '3263F3B7-026F-45F9-2704-08DD759A0482'),
	(NEWID(), N'StaffPT_3', '', '', 1, 0, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '35651B8B-BC39-42BD-2705-08DD759A0482'),
	(NEWID(), N'StaffPT_4', '', '', 1, 0, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '4DB79B84-DA2B-44C5-2706-08DD759A0482'),
	(NEWID(), N'StaffPT_5', '', '', 1, 0, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '195810B5-0028-4629-DB36-08DD75BBA155'),
	(NEWID(), N'StaffPT_6', '', '', 1, 0, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '44BA2CF7-060A-4DC0-DB37-08DD75BBA155'),

	--Chef FullTime
	(NEWID(), N'ChefFT_1', '', '', 2, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '185A6348-240C-4999-2709-08DD759A0482'),
	(NEWID(), N'ChefFT_2', '', '', 2, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '5BCB3726-81B3-4CE2-270A-08DD759A0482'),
	(NEWID(), N'ChefFT_3', '', '', 2, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '8B0C94CA-1A98-4BA4-270B-08DD759A0482'),
	(NEWID(), N'ChefFT_4', '', '', 2, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '90C673BF-F3FF-4137-270C-08DD759A0482'),
	(NEWID(), N'ChefFT_5', '', '', 2, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '34871E55-F0DB-4BC8-270D-08DD759A0482'),
	(NEWID(), N'ChefFT_6', '', '', 2, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '56138E89-3841-4038-270E-08DD759A0482'),
	(NEWID(), N'ChefFT_7', '', '', 2, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '2B891D0C-4E2A-4952-270F-08DD759A0482'),

	--Chef PartTime
	(NEWID(), N'ChefPT_1', '', '', 2, 0, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '073CC470-FBDA-445A-2710-08DD759A0482'),
	(NEWID(), N'ChefPT_2', '', '', 2, 0, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '25B0D6DF-6FF8-4B9B-2711-08DD759A0482'),
	(NEWID(), N'ChefPT_3', '', '', 2, 0, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'A435ED4D-DBA9-44CA-2712-08DD759A0482');

    COMMIT;
    PRINT N'INSERT DATA SUCCESS.';
END TRY
BEGIN CATCH
    ROLLBACK;
    PRINT N'ERROR: ' + ERROR_MESSAGE();
END CATCH;
GO