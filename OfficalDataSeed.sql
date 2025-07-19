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
    --------------------------------------------
    -- SEED DỮ LIỆU MỚI
    --------------------------------------------
	-- Example ---------------------------------
	--------------------------------------------
    -- INSERT INTO [PizzaService].[dbo].[Option] 
	-- ([Id], [Name], [Description], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy]) 
	-- VALUES 
    -- (NEWID(), N'Cỡ Pizza', N'Chọn kích thước pizza', GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),
    -- (NEWID(), N'Viền Pizza', N'Chọn loại viền', GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL);
	--------------------------------------------
	-- Code here
	delete from [dbo].[Table]
	delete from Zone
	delete from OptionItem
	delete from [dbo].[Option]
	delete from OrderItemDetail
	delete from OrderItem
	delete from Product
	delete from Category
	delete from ProductSize
	delete from Recipe
	delete from Ingredient


	--Ingredient--------------------------------

	DECLARE @ingMozzarella         UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingRicotta            UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingCreamCheese        UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingParmaHam           UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingTomatoSauce        UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingRocket             UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingWalnut             UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingJalapeno           UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingGouda              UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingCheddar            UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingBlueCheese         UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingFeta               UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingBrie               UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingCamembert          UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingSwiss              UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingProvolone          UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingPecorino           UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingGorgonzola         UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingEmmental           UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingMontereyJack       UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingAsiago             UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingHavarti            UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingColby              UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingEdam               UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingLimburger          UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingPaneer             UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingHalloumi           UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingGruyere            UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingMascarpone         UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingBurrata            UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingQuesoFresco        UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingCotija             UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingTaleggio           UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingRicottaSalata      UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingStinkingBishop     UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingReblochon          UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingCaciocavallo       UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingKasseri            UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingKefalotyri         UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingMimolette          UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingValencay           UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingTommeDeSavoie      UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingPontLeveque        UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingChaource           UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingSalers             UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingBoursin            UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingCrottin            UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingVacherin           UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingMontasio           UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingRaclette           UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingTruffleHoney       UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingMilanoSausage		UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingChorizoSausage		UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingBasil             UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingOregano           UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingRosemary          UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingThyme             UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingParsley           UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingSage              UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingMint              UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingCilantro          UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingDill              UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingChives            UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingStrawberry        UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingBlueberry         UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingApple             UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingPeach             UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingPineapple         UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingMango             UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingKiwi              UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingRaspberry         UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingGrapes            UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingLemon             UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingParmesan        UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingSashimiCaHoi    UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingTomSu           UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingMuc             UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingXotHanNgot      UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingThitGaTeriyaki      UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingHanTayNgot          UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingToiBam              UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingNuocXotTeriyaki     UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingTieuDen             UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingOtDoChuong          UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingThitBoKebab         UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingThitBoLat           UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingHanhTim             UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingBoKho               UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingCarotHam		    UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingKale			    UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingCapers			    UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingOliveSauce		    UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingMushroomButton	    UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingMushroomPortobello  UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingMushroomShiitake    UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingMushroomEnoki       UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingBoLaLot         UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingOtHiem          UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingMoHanh          UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingMamNemSauRieng  UNIQUEIDENTIFIER = NEWID();
	DECLARE @ingHanhPhi         UNIQUEIDENTIFIER = NEWID();

	-- Insert 50 ingredients into the Ingredient table
	INSERT INTO Ingredient 
	   ([Id], [Name], [Description], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	   (@ingMozzarella, N'Mozzarella', N'Phô mai Ý cổ điển', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingRicotta, N'Ricotta', N'Phô mai mềm Ý truyền thống', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingCreamCheese, N'Cream Cheese', N'Phô mai kem mịn', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingParmaHam, N'Parma Ham', N'Thịt nguội Ý Parma được ủ truyền thống', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingTomatoSauce, N'Tomato Sauce', N'Xốt cà chua nấu chậm', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingRocket, N'Rocket', N'Rau rocket tươi mới', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingWalnut, N'Walnut', N'Hạt óc chó giòn bùi tự nhiên', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingJalapeno, N'Jalapeño', N'Ớt Jalapeño cay nhẹ tạo điểm nhấn', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingGouda, N'Gouda', N'Phô mai Gouda Hà Lan thơm ngon', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingCheddar, N'Cheddar', N'Phô mai Cheddar đậm đà, sắc sảo', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingBlueCheese, N'Blue Cheese', N'Phô mai xanh đậm vị, có mùi hăng', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingFeta, N'Feta', N'Phô mai Feta Hy Lạp mặn và tươi', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingBrie, N'Brie', N'Phô mai Brie mềm mịn, béo ngậy', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingCamembert, N'Camembert', N'Phô mai Camembert mềm béo', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingSwiss, N'Swiss Cheese', N'Phô mai Thụy Sĩ có hạt mịn', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingProvolone, N'Provolone', N'Phô mai Provolone mềm, hấp dẫn', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingPecorino, N'Pecorino', N'Phô mai Pecorino đậm đà từ sữa cừu', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingGorgonzola, N'Gorgonzola', N'Phô mai Gorgonzola xanh, thơm đặc trưng', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingEmmental, N'Emmental', N'Phô mai Emmental có lỗ đặc trưng', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingMontereyJack, N'Monterey Jack', N'Phô mai Monterey Jack mịn màng, nhẹ nhàng', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingAsiago, N'Asiago', N'Phô mai Asiago thơm và chua nhẹ', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingHavarti, N'Havarti', N'Phô mai Havarti Đan Mạch béo ngậy', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingColby, N'Colby', N'Phô mai Colby mềm, dễ tan', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingEdam, N'Edam', N'Phô mai Edam nhẹ, ngọt dịu', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingLimburger, N'Limburger', N'Phô mai Limburger đặc trưng mùi mạnh', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingPaneer, N'Paneer', N'Phô mai Paneer Ấn Độ, không chảy nước', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingHalloumi, N'Halloumi', N'Phô mai Halloumi nướng, không tan chảy', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingGruyere, N'Gruyere', N'Phô mai Gruyere Thụy Sĩ, hương vị phong phú', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingMascarpone, N'Mascarpone', N'Phô mai Mascarpone mịn và béo', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingBurrata, N'Burrata', N'Phô mai Burrata mềm mịn, bên ngoài sợi', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingQuesoFresco, N'Queso Fresco', N'Phô mai Queso Fresco Mexico, tươi mát', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingCotija, N'Cotija', N'Phô mai Cotija Mexico, mặn và giòn', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingTaleggio, N'Taleggio', N'Phô mai Taleggio Ý, mềm và thơm', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingRicottaSalata, N'Ricotta Salata', N'Phô mai Ricotta Salata muối mát', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingStinkingBishop, N'Stinking Bishop', N'Phô mai Stinking Bishop, đặc trưng mùi hăng', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingReblochon, N'Reblochon', N'Phô mai Reblochon Pháp, béo và mềm', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingCaciocavallo, N'Caciocavallo', N'Phô mai Caciocavallo, truyền thống Ý', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingKasseri, N'Kasseri', N'Phô mai Kasseri Hy Lạp, sánh mịn', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingKefalotyri, N'Kefalotyri', N'Phô mai Kefalotyri Hy Lạp, cứng và mặn', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingMimolette, N'Mimolette', N'Phô mai Mimolette Pháp, màu cam đặc trưng', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingValencay, N'Valencay', N'Phô mai Valencay Pháp, hình nón độc đáo', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingTommeDeSavoie, N'Tomme de Savoie', N'Phô mai Tomme de Savoie, nồng nàn', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingPontLeveque, N'Pont-l’évêque', N'Phô mai Pont-l’évêque, mềm mại và thơm', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingChaource, N'Chaource', N'Phô mai Chaource Pháp, béo và mịn', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingSalers, N'Salers', N'Phô mai Salers Pháp, hương vị đậm đà', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingBoursin, N'Boursin', N'Phô mai Boursin, kem thảo mộc', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingCrottin, N'Crottin de Chavignol', N'Phô mai Crottin de Chavignol, nhỏ và mạnh mùi', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingVacherin, N'Vacherin', N'Phô mai Vacherin, mịn và béo', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingMontasio, N'Montasio', N'Phô mai Montasio Ý, mềm và béo', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingRaclette, N'Raclette', N'Phô mai Raclette, dùng để nướng chảy', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingMilanoSausage, N'Xúc xích Ý Milano', N'Xúc xích muối khô, thơm béo', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingChorizoSausage, N'Xúc xích cay Chorizo', N'Xúc xích cay kiểu Tây Ban Nha', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingTruffleHoney, N'Trufle Honey', N'Nấm, dùng để nướng chảy', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
		(@ingBasil, N'Basil', N'Rau húng quế tươi mát, đặc trưng của ẩm thực Ý', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingOregano, N'Oregano', N'Rau oregano thơm, được sử dụng trong nhiều món ăn', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingRosemary, N'Rosemary', N'Rau hương thảo với hương thơm mạnh mẽ', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingThyme, N'Thyme', N'Rau thyme nhỏ xíu, tinh tế và thơm ngon', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingParsley, N'Parsley', N'Rau mùi tươi mát, gia vị phổ biến', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingSage, N'Sage', N'Rau xô thơm với hương vị đặc trưng', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingMint, N'Mint', N'Rau bạc hà, mang lại cảm giác mát lạnh tự nhiên', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingCilantro, N'Cilantro', N'Rau ngò rí, thơm phức và độc đáo', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingDill, N'Dill', N'Rau thì là nhẹ nhàng, tươi mới trong mỗi món ăn', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingChives, N'Chives', N'Hành lá nhỏ, mang vị nhẹ và thơm', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingStrawberry, N'Strawberry', N'Dâu tây ngọt, mọng nước, hoàn hảo cho món tráng miệng', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingBlueberry, N'Blueberry', N'Việt quất xanh giàu chất chống oxy hóa, tự nhiên và ngon miệng', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingApple, N'Apple', N'Táo đỏ, giòn và ngọt tự nhiên, bổ dưỡng cho sức khỏe', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingPeach, N'Peach', N'Đào thơm, ngọt mát, hương vị mùa hè tràn đầy sức sống', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingPineapple, N'Pineapple', N'Dứa chua ngọt, mang hương vị nhiệt đới đặc trưng', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingMango, N'Mango', N'Xoài chín, ngọt thơm, là trái cây ưa thích của nhiều người', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingKiwi, N'Kiwi', N'Kiwi xanh, chua ngọt, giàu vitamin C tự nhiên', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingRaspberry, N'Raspberry', N'Mâm xôi đỏ, nhẹ nhàng và tươi mới, rất hấp dẫn', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingGrapes, N'Grapes', N'Nho ngọt, mọng nước với nhiều chủng loại đa dạng', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingLemon, N'Lemon', N'Chanh tươi, chua nhẹ, tạo điểm nhấn cho hầu hết các món ăn', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingParmesan, N'Parmesan', N'Phô mai mặn, dùng rắc', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingSashimiCaHoi, N'Sashimi cá hồi', N'Cá hồi tươi lát mỏng', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingTomSu, N'Tôm sú', N'Tôm tươi bóc vỏ', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingMuc, N'Mực', N'Mực cắt khoanh hấp dẫn', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingXotHanNgot, N'Xốt hành ngọt', N'Xốt làm từ hành tây ngọt thơm', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	     (@ingThitGaTeriyaki, N'Thịt gà Teriyaki', N'Ức gà ướp và nướng xốt Teriyaki', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingHanTayNgot, N'Hành tây ngọt', N'Hành tây cắt lát ngọt dịu', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingToiBam, N'Tỏi băm', N'Tỏi tươi băm nhỏ', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingNuocXotTeriyaki, N'Nước xốt Teriyaki', N'Xốt mặn ngọt kiểu Nhật', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingTieuDen, N'Tiêu đen', N'Tiêu xay thơm cay nhẹ', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingHanhTim, N'Hành tím lai đen', N'Thơm cay nhẹ', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingThitBoKebab, N'Thịt bò Kebab', N'Thịt bò ướp gia vị cay kiểu Trung Đông, nướng lửa than', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingThitBoLat, N'Thịt bò lát', N'Thịt bò ướp gia vị cay kiểu Trung Đông, nướng lửa than', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingBoKho, N'Thịt bò Khi', N'Thịt bò ướp gia vị cay kiểu Trung Đông, nướng lửa than', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingCarotHam, N'Cà Rốt Nấu chảy', N'Cà Rốt Nấu chảy', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingKale, N'Cải Xoăn', N'Cải Xoăn', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingCapers, N'Nụ Bạch Hoa', N'Tôm tươi bóc vỏ', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingOliveSauce, N'Dầu ớt trộn ô liu ', N'Dầu ớt trộn ô liu', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingMushroomEnoki, N' Nấm mập Enoki', N'Nấm mập Enoki', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingMushroomShiitake, N'Nấm to Shiitake', N'Nấm to Shiitake', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingMushroomButton, N'Nấm to hơn', N'Nấm to hơn', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingMushroomPortobello, N'Nấm nhỏ xíu', N'Nấm nhỏ xíu', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingBoLaLot, N'Bò nướng lá lốt', N'Thịt bò băm nướng gói trong lá lốt truyền thống Việt Nam', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingOtHiem, N'Ớt hiểm', N'Ớt hiểm cay nồng tăng hương vị đặc trưng', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingMoHanh, N'Mỡ hành', N'Mỡ hành béo thơm đậm chất Việt', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingMamNemSauRieng, N'Mắm nêm sầu riêng', N'Phiên bản mắm nêm ngọt nhẹ với sầu riêng dậy mùi', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
       (@ingHanhPhi, N'Hành phi', N'Hành tím phi vàng giòn tan thơm lừng', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL) ,
	   (@ingOtDoChuong, N'Ớt đỏ chuông', N'Ớt đỏ tươi thái lát', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	   

	DECLARE @appetizersCategoryId UNIQUEIDENTIFIER = NEWID();
    DECLARE @pizzaCategoryId UNIQUEIDENTIFIER = NEWID();
    DECLARE @pastaCategoryId UNIQUEIDENTIFIER = NEWID();
    DECLARE @dessertCategoryId UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Category ([Id], [Name], [Description], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy]) 
	VALUES
	(@appetizersCategoryId, N'Món khai vị & Salad', N'Danh mục cho Món khai vị & Salad', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@pizzaCategoryId, N'Pizza', N'Danh mục cho Pizza', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@pastaCategoryId, N'Pasta & các món ăn chính', N'Danh mục cho Pasta & các món ăn chính', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@dessertCategoryId, N'Món tráng miệng', N'Danh mục cho Món tráng miệng & các món ăn chính', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);
	
	-- @appetizersCategoryId
	    DECLARE @productId1 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy]) 
	VALUES
	(@productId1, N'Các loại phô mai nhà làm', N'Mô tả đang cập nhật', 109000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/BYO_Assorted-Cheese_L-2-scaled.jpg', NULL, @appetizersCategoryId, 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);
	
	DECLARE @optionId1 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId2 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId3 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId1, N'Chọn loại phô mai', N'Chọn phô mai bạn yêu thích', @productId1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId2, N'Thêm topping đặc biệt', N'Thêm topping cho món ăn của bạn', @productId1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId3, N'Chọn khẩu phần', N'Chọn khẩu phần phù hợp', @productId1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Mozzarella', 0, @optionId1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Camembert', 10000, @optionId1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Burrata', 15000, @optionId1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Hạt óc chó', 8000, @optionId2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Mật ong truffle', 12000, @optionId2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'S (Nhỏ)', 0, @optionId3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 89000, @optionId3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @productId2 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES 
	(@productId2, N'Set thịt nguội và phô mai', N'Mô tả đang cập nhật', 172000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/08/BYO_Cold-Cuts_L-2-scaled.jpg', NULL, @appetizersCategoryId, 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId4 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId5 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId6 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId4, N'Chọn loại thịt nguội', N'Chọn thịt nguội yêu thích', @productId2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId5, N'Thêm phô mai', N'Phô mai thêm vào set', @productId2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId6, N'Chọn khẩu phần', N'Chọn khẩu phần phù hợp', @productId2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Prosciutto', 0, @optionId4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Salami', 5000, @optionId4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Speck', 7000, @optionId4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Brie', 8000, @optionId5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Blue Cheese', 12000, @optionId5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'S (Nhỏ)', 0, @optionId5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 162000, @optionId5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @productId3 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES 
	(@productId3, N'Sushi cá hồi và phô mai Mozzarella', N'Mô tả đang cập nhật', 92000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/4PS_NOV_SOCIAL-6322.jpg', NULL, @appetizersCategoryId, 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId7 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId8 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId7, N'Chọn loại cá', N'Chọn loại cá bạn muốn dùng', @productId3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId8, N'Thêm phô mai', N'Chọn loại phô mai kèm theo', @productId3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Cá hồi Na Uy', 0, @optionId7, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Cá ngừ đại dương', 10000, @optionId7, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Cá bơn Hàn Quốc', 15000, @optionId7, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Mozzarella', 0, @optionId8, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai tươi nhà làm', 8000, @optionId8, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @productId4 UNIQUEIDENTIFIER = NEWID();

	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES 
	(@productId4, N'Thịt nguội cuộn xoài kèm xốt chanh dây', N'Mô tả đang cập nhật', 144000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/Mango-Parma-Ham-Wrap-NEW.jpg', NULL, @appetizersCategoryId, 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId9 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId10 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId9, N'Chọn loại thịt nguội', N'Thêm hương vị theo sở thích', @productId4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId10, N'Thêm xốt đặc biệt', N'Chọn xốt ăn kèm', @productId4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Jambon heo muối', 0, @optionId9, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Salami bò', 10000, @optionId9, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Prosciutto Ý', 15000, @optionId9, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Xốt chanh dây', 0, @optionId10, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Xốt mù tạt mật ong', 10000, @optionId10, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @productId5 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES 
	(@productId5, N'Khoai tây nghiền bỏ lò kèm phô mai Raclette nhà làm', N'Mô tả đang cập nhật', 72000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/20000055_2.jpg', NULL, @appetizersCategoryId, 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId11 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId12 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId11, N'Thêm phô mai', N'Lựa chọn thêm các loại phô mai nhà làm', @productId5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId12, N'Thêm topping đặc biệt', N'Tăng hương vị với các nguyên liệu đặc biệt', @productId5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Phô mai Gruyère', 10000, @optionId11, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Brie', 15000, @optionId11, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Trứng chần', 10000, @optionId12, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nấm truffle đen', 20000, @optionId12, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @productId6 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES 
	(@productId6, N'Súp nghêu hầm', N'Mô tả đang cập nhật', 82000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/20000043_2.jpg', NULL, @appetizersCategoryId, 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId13 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId14 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId15 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId13, N'Chọn độ cay', N'Điều chỉnh độ cay của súp theo sở thích', @productId6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId14, N'Thêm nghêu', N'Chọn thêm nghêu tươi vào súp', @productId6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId15, N'Chọn khẩu phần', N'Tùy chọn khẩu phần ăn', @productId6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Không cay', 0, @optionId13, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Một chút cay', 0, @optionId13, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Siêu cay', 0, @optionId13, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'1 phần nghêu', 50000, @optionId14, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'2 phần nghêu', 100000, @optionId14, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phần nhỏ (1 người)', 0, @optionId15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phần lớn (2 người)', 50000, @optionId15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @productId7 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES 
	(@productId7, N'Súp cà chua thịt viên Ý với phô mai Mascarpone', N'Mô tả đang cập nhật', 82000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/20000045_2.jpg', NULL, @appetizersCategoryId, 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId16 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId17 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId16, N'Chọn phô mai', N'Chọn loại phô mai bạn yêu thích', @productId7, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId17, N'Thêm thịt viên', N'Chọn thêm thịt viên vào súp', @productId7, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Mascarpone', 0, @optionId16, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Mozzarella', 10000, @optionId16, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Parmigiano', 15000, @optionId16, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'1 viên thịt', 15000, @optionId17, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'2 viên thịt', 25000, @optionId17, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @productId8 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES 
	(@productId8, N'Súp bí hạt đậu hữu cơ và trà sữa hoa nhài Hồ Tây', N'Mô tả đang cập nhật', 81000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/20010019_2.jpg', NULL, @appetizersCategoryId, 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId18 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId18, N'Chọn thêm topping', N'Chọn topping cho món ăn của bạn', @productId8, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Nhân bí ngô', 8000, @optionId18, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Hạt sen', 10000, @optionId18, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @productId9 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES 
	(@productId9, N'Khoai tây Đức đút lò với phô mai racette', N'Mô tả đang cập nhật', 123000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/08/4Ps_KAIZENDISHES-SOCIAL-5608.jpg', NULL, @appetizersCategoryId, 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId19 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId20 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId19, N'Chọn loại phô mai', N'Chọn loại phô mai bạn yêu thích', @productId9, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId20, N'Chọn khẩu phần', N'Chọn khẩu phần ăn', @productId9, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Phô mai racette', 0, @optionId19, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai cheddar', 15000, @optionId19, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai mozzarella', 12000, @optionId19, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nhỏ', 0, @optionId20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Lớn', 50000, @optionId20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @productId10 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES 
	(@productId10, N'Gà rán gia vị phương Đông với xốt ớt Jalapeño nhà làm (2 miếng)', N'Mô tả đang cập nhật', 98000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/20010016_2.jpg', NULL, @appetizersCategoryId, 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId21 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId22 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId23 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId21, N'Chọn gia vị', N'Chọn gia vị bạn yêu thích cho món gà', @productId10, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId22, N'Chọn xốt', N'Chọn xốt đi kèm với gà', @productId10, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId23, N'Chọn khẩu phần', N'Tùy chọn khẩu phần ăn', @productId10, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Gia vị phương Đông', 0, @optionId21, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Gia vị cay', 5000, @optionId21, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Gia vị ngọt', 5000, @optionId21, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Xốt ớt Jalapeño', 0, @optionId22, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Xốt BBQ', 10000, @optionId22, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'2 miếng', 0, @optionId23, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'4 miếng', 50000, @optionId23, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @productId11 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES 
	(@productId11, N'Phô mai Fondue', N'Mô tả đang cập nhật', 128000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/20000044_2.jpg', NULL, @appetizersCategoryId, 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId24 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId25 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId26 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId24, N'Chọn loại phô mai', N'Chọn phô mai để làm fondue', @productId11, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId25, N'Chọn bánh mì', N'Chọn loại bánh mì ăn kèm', @productId11, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId26, N'Chọn topping', N'Chọn topping cho phô mai fondue', @productId11, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Mozzarella', 0, @optionId24, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Cheddar', 10000, @optionId24, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Gruyère', 15000, @optionId24, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Bánh mì baguette', 0, @optionId25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Bánh mì ciabatta', 5000, @optionId25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Hạt điều rang muối', 5000, @optionId26, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Ớt chuông', 3000, @optionId26, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nhân nấm', 7000, @optionId26, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @productId12 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES 
	(@productId12, N'Bánh Croquettes với hương vị từ biển và xốt cà chua', N'Mô tả đang cập nhật', 168000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/20010017_2.jpg', NULL, @appetizersCategoryId, 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId27 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId28 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId29 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId27, N'Chọn loại xốt', N'Chọn loại xốt bạn yêu thích', @productId12, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId28, N'Chọn mức độ cay', N'Chọn mức độ cay của xốt', @productId12, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId29, N'Chọn thêm topping', N'Chọn thêm topping cho món bánh croquettes', @productId12, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Xốt cà chua', 0, @optionId27, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Xốt Mayonnaise', 5000, @optionId27, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Không cay', 0, @optionId28, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nhẹ', 5000, @optionId28, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Cay vừa', 10000, @optionId28, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Cay mạnh', 15000, @optionId28, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nhân tôm', 10000, @optionId29, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nhân thịt bò', 15000, @optionId29, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nhân cá ngừ', 12000, @optionId29, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @productId13 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES 
	(@productId13, N'Thịt nguội cuộn lá Rocket và phô mai Ricotta (1 cuộn)', N'Mô tả đang cập nhật', 44000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/PizzaBYO-3.png', NULL, @appetizersCategoryId, 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);
	
	DECLARE @optionId30 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId31 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId30, N'Chọn loại thịt nguội', N'Chọn loại thịt nguội bạn yêu thích', @productId13, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId31, N'Chọn thêm gia vị', N'Chọn gia vị hoặc gia tăng hương vị món ăn', @productId13, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Prosciutto', 10000, @optionId30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Bacon', 15000, @optionId30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Ớt bột', 2000, @optionId31, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Dầu olive', 5000, @optionId31, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @productId14 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES 
	(@productId14, N'Phô mai Camembert kẹp Mascarpone dầu nấm Truffle (1 miếng)', N'Mô tả đang cập nhật', 47000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/20000010_2.jpg', NULL, @appetizersCategoryId, 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @productId15 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES 
	(@productId15, N'Phô mai Burrata kèm lá Rocket và Cà chua Salad', N'Mô tả đang cập nhật', 185000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/20100001_2.jpg', NULL, @appetizersCategoryId, 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId32 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId33 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId32, N'Chọn topping', N'Chọn các topping cho salad', @productId15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId33, N'Chọn khẩu phần', N'Chọn size khẩu phần salad', @productId15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Lá Rocket', 0, @optionId32, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Cà chua', 5000, @optionId32, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Hạt hạnh nhân', 8000, @optionId32, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nhỏ', 0, @optionId33, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Lớn', 50000, @optionId33, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @productId17 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId17, N'Lá Rocket và Cà chua Salad', N'Mô tả đang cập nhật', 81000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/20100002_2.jpg', NULL, @appetizersCategoryId, 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId34 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId35 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId36 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId34, N'Chọn loại phô mai', N'Chọn phô mai bạn yêu thích', @productId17, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId35, N'Chọn topping', N'Chọn các topping cho salad', @productId17, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId36, N'Chọn khẩu phần', N'Chọn size khẩu phần salad', @productId17, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Phô mai Burrata', 10000, @optionId34, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Mozzarella', 20000, @optionId34, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Lá Rocket', 0, @optionId35, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Cà chua', 5000, @optionId35, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Hạt hạnh nhân', 8000, @optionId35, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nhỏ', 0, @optionId36, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Lớn', 50000, @optionId36, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @productId18 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId18, N'Rau cải xoăn hữu cơ với phô mai Lactic nhà làm và các loại hạt ngào đường caramen mặn Salad', N'Mô tả đang cập nhật', 105000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/20110002_2.jpg', NULL, @appetizersCategoryId, 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId37 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId38 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId37, N'Chọn topping', N'Chọn các topping cho salad', @productId18, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId38, N'Chọn khẩu phần', N'Chọn size khẩu phần salad', @productId18, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Hạt hạnh nhân', 8000, @optionId37, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Hạt chia', 5000, @optionId37, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Hạt óc chó', 10000, @optionId37, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nhỏ', 0, @optionId38, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Lớn', 50000, @optionId38, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @productId19 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId19, N'Phô mai Burrata kèm thịt nguội và trái cây nhiệt đới Salad', N'Mô tả đang cập nhật', 129000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/20100005_2.jpg', NULL, @appetizersCategoryId, 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId39 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId40 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId39, N'Chọn topping', N'Chọn các topping cho salad', @productId19, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId40, N'Chọn khẩu phần', N'Tùy chọn khẩu phần ăn', @productId19, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Hạt hạnh nhân', 8000, @optionId39, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Hạt chia', 5000, @optionId39, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Hạt óc chó', 10000, @optionId39, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nhỏ', 0, @optionId40, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Lớn', 109000, @optionId40, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @productId20 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId20, N'Tôm Bơ Salad', N'Mô tả đang cập nhật', 115000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/20100012_2.jpg', NULL, @appetizersCategoryId, 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId41 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId42 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId43 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId41, N'Chọn loại tôm', N'Chọn loại tôm bạn yêu thích', @productId20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId42, N'Chọn loại bơ', N'Chọn loại bơ bạn muốn', @productId20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId43, N'Chọn khẩu phần', N'Tùy chọn khẩu phần ăn', @productId20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Tôm Hùm', 30000, @optionId41, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Tôm sú', 20000, @optionId41, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Bơ Hass', 0, @optionId42, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Bơ Mexico', 10000, @optionId42, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nhỏ', 0, @optionId43, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Lớn', 50000, @optionId43, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @productId21 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId21, N'Tartare Cá hồi bơ kèm rau thơm', N'Mô tả đang cập nhật', 159000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/20000095_2.jpg', NULL, @appetizersCategoryId, 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId44 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId45 UNIQUEIDENTIFIER = NEWID();
	-- Insert Options
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId44, N'Chọn loại cá hồi', N'Chọn loại cá hồi bạn yêu thích', @productId21, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId45, N'Chọn loại bơ', N'Chọn loại bơ bạn muốn', @productId21, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Cá hồi Nhật Bản', 0, @optionId44, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Cá hồi Na Uy', 10000, @optionId44, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Bơ Hass', 0, @optionId45, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Bơ Mexico', 10000, @optionId45, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @productId22 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId22, N'Cá hồi, bơ và phô mai Ricotta Salad', N'Mô tả đang cập nhật', 158000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/20100305_2.jpg', NULL, @appetizersCategoryId, 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId46 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId47 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId48 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId46, N'Chọn loại cá hồi', N'Chọn loại cá hồi bạn yêu thích', @productId22, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId47, N'Chọn loại bơ', N'Chọn loại bơ bạn muốn', @productId22, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId48, N'Chọn loại phô mai', N'Chọn phô mai bạn thích cho salad', @productId22, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Cá hồi Nhật Bản', 0, @optionId46, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Cá hồi Na Uy', 10000, @optionId46, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Bơ Hass', 0, @optionId47, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Bơ Mexico', 10000, @optionId47, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Ricotta', 0, @optionId48, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Mascarpone', 10000, @optionId48, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @productId23 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId23, N'Phô mai Mozzarella nhà làm và cà chua Đà Lạt Salad', N'Mô tả đang cập nhật', 105000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/Anh-man-hinh-2023-07-11-luc-15.39.13.png', NULL, @appetizersCategoryId, 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId49 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId50 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId51 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId49, N'Chọn loại phô mai Mozzarella', N'Chọn loại phô mai Mozzarella bạn thích', @productId23, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId50, N'Chọn cà chua', N'Chọn loại cà chua Đà Lạt bạn yêu thích', @productId23, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId51, N'Chọn gia vị', N'Chọn gia vị thêm vào salad', @productId23, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Mozzarella Tươi', 0, @optionId49, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Mozzarella Cứng', 10000, @optionId49, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Cà chua Đà Lạt đỏ', 0, @optionId50, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Cà chua Đà Lạt vàng', 5000, @optionId50, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Ớt bột', 0, @optionId51, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Gia vị thảo mộc', 5000, @optionId51, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @productId24 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId24, N'Rau xanh với xốt tự chế biến Salad', N'Mô tả đang cập nhật', 85000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/20100008_2.jpg', NULL, @appetizersCategoryId, 0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId52 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId53 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId54 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId52, N'Chọn loại rau', N'Chọn loại rau tươi cho salad của bạn', @productId24, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId53, N'Chọn xốt', N'Chọn xốt tự chế biến cho salad', @productId24, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId54, N'Chọn gia vị', N'Chọn gia vị để thêm vào salad', @productId24, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Rau xà lách', 0, @optionId52, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Rau chân vịt', 0, @optionId52, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Cải xoăn', 5000, @optionId52, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Xốt dầu giấm', 0, @optionId53, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Xốt mè rang', 10000, @optionId53, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Xốt cà chua', 5000, @optionId53, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Ớt bột', 0, @optionId54, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Tỏi phi', 3000, @optionId54, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- @pizzaCategoryId
	DECLARE @productId25 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId25, N'Pizza Tôm sốt tỏi cay', N'Mô tả đang cập nhật', 254000, NULL, 'https://pizza4ps.com/wp-content/uploads/2024/04/BYO_Garlic-Shrimp-Pizza-1.jpg', NULL, @appetizersCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId251 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId252 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId253 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId254 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId251, N'Chọn loại phô mai', N'Chọn phô mai yêu thích cho pizza', @productId25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId252, N'Chọn topping', N'Chọn topping bạn muốn thêm vào pizza', @productId25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId253, N'Chọn kích thước', N'Chọn kích thước pizza', @productId25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId254, N'Chọn đế bánh', N'Chọn loại đế bánh cho pizza của bạn', @productId25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Mozzarella', 0, @optionId251, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai cheddar', 10000, @optionId251, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Parmesan', 15000, @optionId251, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Ớt Jalapeño', 8000, @optionId252, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Hành tây', 5000, @optionId252, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Ngô ngọt', 5000, @optionId252, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'S (Nhỏ)', 0, @optionId253, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'M (Vừa)', 10000, @optionId253, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 20000, @optionId253, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế mỏng', 0, @optionId254, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế dày', 5000, @optionId254, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế không gluten', 10000, @optionId254, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Declare Size IDs
	DECLARE @sizeS25 UNIQUEIDENTIFIER = NEWID();
	DECLARE @sizeM25 UNIQUEIDENTIFIER = NEWID();

	-- Insert Product Sizes (S, M)
	INSERT INTO ProductSize ([Id], [Name], [Diameter], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@sizeS25, N'S (Nhỏ)', 20.0, N'Cỡ nhỏ phù hợp cá nhân', @productId25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@sizeM25, N'M (Vừa)', 25.0, N'Cỡ vừa cho 1-2 người', @productId25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size S
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeS25, @ingMozzarella, N'Mozzarella', 1, 40, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS25, @ingCheddar, N'Cheddar', 1, 20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS25, @ingParmesan, N'Parmesan', 1, 10, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS25, @ingTomSu, N'Tôm sú', 5, 6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS25, @ingToiBam, N'Tỏi băm', 1, 5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS25, @ingOtDoChuong, N'Ớt đỏ chuông', 6, 6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS25, @ingJalapeno, N'Ớt Jalapeño', 6, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS25, @ingHanTayNgot, N'Hành tây ngọt', 1, 10, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS25, @ingTomatoSauce, N'Xốt cà chua', 3, 3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size M
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeM25, @ingMozzarella, N'Mozzarella', 1, 50, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM25, @ingCheddar, N'Cheddar', 1, 25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM25, @ingParmesan, N'Parmesan', 1, 15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM25, @ingTomSu, N'Tôm sú', 5, 8, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM25, @ingToiBam, N'Tỏi băm', 1, 6.5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM25, @ingOtDoChuong, N'Ớt đỏ chuông', 6, 8, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM25, @ingJalapeno, N'Ớt Jalapeño', 6, 5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM25, @ingHanTayNgot, N'Hành tây ngọt', 1, 15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM25, @ingTomatoSauce, N'Xốt cà chua', 3, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	DECLARE @productId26 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId26, N'Phô mai Burrata thịt nguội', N'Mô tả đang cập nhật', 298000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/PizzaBYO-1.png', NULL, @appetizersCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId261 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId262 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId263 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId264 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId261, N'Chọn loại phô mai', N'Chọn loại phô mai thích hợp cho món ăn', @productId26, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId262, N'Chọn topping', N'Chọn topping bạn muốn thêm vào món ăn', @productId26, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId263, N'Chọn kích thước', N'Chọn kích thước pizza', @productId26, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId264, N'Chọn đế bánh', N'Chọn loại đế bánh cho pizza của bạn', @productId26, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL); -- Đế bánh option

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Mozzarella', 0, @optionId261, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Ricotta', 12000, @optionId261, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Cream Cheese', 10000, @optionId261, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Ớt Jalapeño', 8000, @optionId262, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Hạt óc chó', 10000, @optionId262, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Mật ong truffle', 15000, @optionId262, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'S (Nhỏ)', 0, @optionId263, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'M (Vừa)', 10000, @optionId263, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 20000, @optionId263, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế mỏng', 0, @optionId264, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế dày', 5000, @optionId264, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế không gluten', 10000, @optionId264, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Declare Size IDs
	DECLARE @sizeS26 UNIQUEIDENTIFIER = NEWID();
	DECLARE @sizeM26 UNIQUEIDENTIFIER = NEWID();

	-- Insert Product Sizes
	INSERT INTO ProductSize ([Id], [Name], [Diameter], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@sizeS26, N'S (Nhỏ)', 20.0, N'Cỡ nhỏ phù hợp cá nhân', @productId26, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@sizeM26, N'M (Vừa)', 25.0, N'Cỡ vừa cho 1-2 người', @productId26, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size S
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeS26, @ingBurrata, N'Burrata', 1, 50, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS26, @ingMozzarella, N'Mozzarella', 1, 30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS26, @ingRicotta, N'Ricotta', 1, 20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS26, @ingCreamCheese, N'Cream Cheese', 1, 15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS26, @ingParmaHam, N'Thịt nguội Parma', 1, 40, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS26, @ingWalnut, N'Hạt óc chó', 1, 8, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS26, @ingTruffleHoney, N'Mật ong truffle', 3, 2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS26, @ingJalapeno, N'Ớt Jalapeño', 6, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS26, @ingTomatoSauce, N'Xốt cà chua', 3, 2.5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size M
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeM26, @ingBurrata, N'Burrata', 1, 60, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM26, @ingMozzarella, N'Mozzarella', 1, 40, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM26, @ingRicotta, N'Ricotta', 1, 25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM26, @ingCreamCheese, N'Cream Cheese', 1, 20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM26, @ingParmaHam, N'Thịt nguội Parma', 1, 50, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM26, @ingWalnut, N'Hạt óc chó', 1, 10, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM26, @ingTruffleHoney, N'Mật ong truffle', 3, 3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM26, @ingJalapeno, N'Ớt Jalapeño', 6, 5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM26, @ingTomatoSauce, N'Xốt cà chua', 3, 3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	DECLARE @productId27 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId27, N'Pizza Thịt nguội Ý Parma và rau rocket với xốt cà chua', N'Mô tả đang cập nhật', 331000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/Extra-Parma-Ham-Margherita-4.jpg', NULL, @appetizersCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId271 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId272 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId273 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId274 UNIQUEIDENTIFIER = NEWID(); 
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId271, N'Chọn loại phô mai', N'Chọn loại phô mai phù hợp cho pizza của bạn', @productId27, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId272, N'Chọn topping', N'Chọn topping thêm vào pizza của bạn', @productId27, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId273, N'Chọn kích thước', N'Chọn kích thước pizza', @productId27, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId274, N'Chọn đế bánh', N'Chọn loại đế bánh cho pizza của bạn', @productId27, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Mozzarella', 0, @optionId271, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Ricotta', 12000, @optionId271, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Cream Cheese', 10000, @optionId271, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Hạt óc chó', 10000, @optionId272, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Ớt Jalapeño', 8000, @optionId272, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'S (Nhỏ)', 0, @optionId273, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'M (Vừa)', 10000, @optionId273, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 20000, @optionId273, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế mỏng', 0, @optionId274, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế dày', 5000, @optionId274, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế không gluten', 10000, @optionId274, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Declare Size IDs
	DECLARE @sizeS27 UNIQUEIDENTIFIER = NEWID();
	DECLARE @sizeM27 UNIQUEIDENTIFIER = NEWID();

	-- Insert Product Sizes
	INSERT INTO ProductSize ([Id], [Name], [Diameter], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@sizeS27, N'S (Nhỏ)', 20.0, N'Cỡ nhỏ phù hợp cá nhân', @productId27, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@sizeM27, N'M (Vừa)', 25.0, N'Cỡ vừa cho 1-2 người', @productId27, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size S
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeS27, @ingMozzarella, N'Mozzarella', 1, 40, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS27, @ingRicotta, N'Ricotta', 1, 20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS27, @ingCreamCheese, N'Cream Cheese', 1, 15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS27, @ingParmaHam, N'Thịt nguội Parma', 1, 40, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS27, @ingRocket, N'Rau rocket', 1, 10, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS27, @ingWalnut, N'Hạt óc chó', 1, 5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS27, @ingJalapeno, N'Ớt Jalapeño', 6, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS27, @ingTomatoSauce, N'Xốt cà chua', 3, 3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size M
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeM27, @ingMozzarella, N'Mozzarella', 1, 50, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM27, @ingRicotta, N'Ricotta', 1, 25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM27, @ingCreamCheese, N'Cream Cheese', 1, 20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM27, @ingParmaHam, N'Thịt nguội Parma', 1, 50, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM27, @ingRocket, N'Rau rocket', 1, 15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM27, @ingWalnut, N'Hạt óc chó', 1, 7, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM27, @ingJalapeno, N'Ớt Jalapeño', 6, 5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM27, @ingTomatoSauce, N'Xốt cà chua', 3, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	DECLARE @productId28 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId28, N'Pizza Margherita với xúc xích Ý Milano và xúc xích cay Chorizo', N'Mô tả đang cập nhật', 238000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/Extra-Parma-Ham-Margherita-4.jpg', NULL, @appetizersCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId281 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId282 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId283 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId284 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId281, N'Chọn loại phô mai', N'Chọn loại phô mai phù hợp cho pizza của bạn', @productId28, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId282, N'Chọn topping', N'Chọn topping thêm vào pizza của bạn', @productId28, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId283, N'Chọn kích thước', N'Chọn kích thước pizza', @productId28, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId284, N'Chọn đế bánh', N'Chọn loại đế bánh cho pizza của bạn', @productId28, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Mozzarella', 0, @optionId281, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Ricotta', 12000, @optionId281, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Cream Cheese', 10000, @optionId281, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Xúc xích Ý Milano', 20000, @optionId282, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Xúc xích cay Chorizo', 25000, @optionId282, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'S (Nhỏ)', 0, @optionId283, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'M (Vừa)', 10000, @optionId283, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 20000, @optionId283, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế mỏng', 0, @optionId284, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế dày', 5000, @optionId284, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế không gluten', 10000, @optionId284, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Declare Size IDs
	DECLARE @sizeS28 UNIQUEIDENTIFIER = NEWID();
	DECLARE @sizeM28 UNIQUEIDENTIFIER = NEWID();

	-- Insert Product Sizes
	INSERT INTO ProductSize ([Id], [Name], [Diameter], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@sizeS28, N'S (Nhỏ)', 20.0, N'Cỡ nhỏ phù hợp cá nhân', @productId28, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@sizeM28, N'M (Vừa)', 25.0, N'Cỡ vừa cho 1-2 người', @productId28, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size S
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeS28, @ingMozzarella, N'Mozzarella', 1, 40, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS28, @ingRicotta, N'Ricotta', 1, 15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS28, @ingCreamCheese, N'Cream Cheese', 1, 10, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS28, @ingMilanoSausage, N'Xúc xích Ý Milano', 1, 40, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS28, @ingChorizoSausage, N'Xúc xích cay Chorizo', 1, 30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS28, @ingTomatoSauce, N'Xốt cà chua', 3, 3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS28, @ingOregano, N'Lá oregano', 6, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size M
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeM28, @ingMozzarella, N'Mozzarella', 1, 50, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM28, @ingRicotta, N'Ricotta', 1, 20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM28, @ingCreamCheese, N'Cream Cheese', 1, 15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM28, @ingMilanoSausage, N'Xúc xích Ý Milano', 1, 50, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM28, @ingChorizoSausage, N'Xúc xích cay Chorizo', 1, 40, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM28, @ingTomatoSauce, N'Xốt cà chua', 3, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM28, @ingOregano, N'Lá oregano', 6, 5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	DECLARE @productId29 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId29, N'Pizza Phô mai Burrata Margherita với thịt nguội', N'Mô tả đang cập nhật', 398000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/08/2-APPLY-2-Burrata-Parma-Ham-Margherita-2.jpg', NULL, @appetizersCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId291 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId292 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId293 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId294 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId291, N'Chọn loại phô mai', N'Chọn loại phô mai phù hợp cho pizza của bạn', @productId29, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId292, N'Chọn topping', N'Chọn topping thêm vào pizza của bạn', @productId29, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId293, N'Chọn kích thước', N'Chọn kích thước pizza', @productId29, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId294, N'Chọn đế bánh', N'Chọn loại đế bánh cho pizza của bạn', @productId29, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Phô mai Burrata', 20000, @optionId291, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Mozzarella', 0, @optionId291, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Ricotta', 12000, @optionId291, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Thịt nguội Ý Parma', 25000, @optionId292, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Xúc xích Ý Milano', 20000, @optionId292, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'S (Nhỏ)', 0, @optionId293, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'M (Vừa)', 10000, @optionId293, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 20000, @optionId293, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế mỏng', 0, @optionId294, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế dày', 5000, @optionId294, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế không gluten', 10000, @optionId294, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);
		-- Declare Size IDs
	DECLARE @sizeS29 UNIQUEIDENTIFIER = NEWID();
	DECLARE @sizeM29 UNIQUEIDENTIFIER = NEWID();

	-- Insert Product Sizes
	INSERT INTO ProductSize ([Id], [Name], [Diameter], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@sizeS29, N'S (Nhỏ)', 20.0, N'Cỡ nhỏ phù hợp cá nhân', @productId29, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@sizeM29, N'M (Vừa)', 25.0, N'Cỡ vừa cho 1-2 người', @productId29, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size S
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeS29, @ingBurrata, N'Burrata', 1, 50, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS29, @ingMozzarella, N'Mozzarella', 1, 30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS29, @ingRicotta, N'Ricotta', 1, 20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS29, @ingParmaHam, N'Thịt nguội Ý Parma', 1, 40, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS29, @ingMilanoSausage, N'Xúc xích Ý Milano', 1, 30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS29, @ingTomatoSauce, N'Xốt cà chua', 3, 3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS29, @ingOregano, N'Lá oregano', 6, 3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size M
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeM29, @ingBurrata, N'Burrata', 1, 60, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM29, @ingMozzarella, N'Mozzarella', 1, 40, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM29, @ingRicotta, N'Ricotta', 1, 25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM29, @ingParmaHam, N'Thịt nguội Ý Parma', 1, 50, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM29, @ingMilanoSausage, N'Xúc xích Ý Milano', 1, 40, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM29, @ingTomatoSauce, N'Xốt cà chua', 3, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM29, @ingOregano, N'Lá oregano', 6, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	DECLARE @productId30 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId30, N'Pizza 3 loại phô mai nhà làm', N'Mô tả đang cập nhật', 198000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/10000005_2.jpg', NULL, @appetizersCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId301 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId302 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId303 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId304 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId301, N'Chọn loại phô mai', N'Chọn loại phô mai phù hợp cho pizza của bạn', @productId30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId302, N'Chọn topping', N'Chọn topping thêm vào pizza của bạn', @productId30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId303, N'Chọn kích thước', N'Chọn kích thước pizza', @productId30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId304, N'Chọn đế bánh', N'Chọn loại đế bánh cho pizza của bạn', @productId30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Phô mai Mozzarella', 0, @optionId301, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Ricotta', 15000, @optionId301, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Camembert', 20000, @optionId301, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Thịt nguội Ý Parma', 25000, @optionId302, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Xúc xích Ý Milano', 20000, @optionId302, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'S (Nhỏ)', 0, @optionId303, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'M (Vừa)', 10000, @optionId303, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 20000, @optionId303, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế mỏng', 0, @optionId304, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế dày', 5000, @optionId304, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế không gluten', 10000, @optionId304, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Declare Size IDs
	DECLARE @sizeS30 UNIQUEIDENTIFIER = NEWID();
	DECLARE @sizeM30 UNIQUEIDENTIFIER = NEWID();

	-- Insert Product Sizes
	INSERT INTO ProductSize ([Id], [Name], [Diameter], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@sizeS30, N'S (Nhỏ)', 20.0, N'Cỡ nhỏ phù hợp cá nhân', @productId30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@sizeM30, N'M (Vừa)', 25.0, N'Cỡ vừa cho 1-2 người', @productId30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size S
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeS30, @ingMozzarella, N'Mozzarella', 1, 40, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS30, @ingRicotta, N'Ricotta', 1, 25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS30, @ingCamembert, N'Camembert', 1, 20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS30, @ingTomatoSauce, N'Xốt cà chua', 3, 3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS30, @ingOregano, N'Lá oregano', 6, 3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size M
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeM30, @ingMozzarella, N'Mozzarella', 1, 50, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM30, @ingRicotta, N'Ricotta', 1, 30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM30, @ingCamembert, N'Camembert', 1, 25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM30, @ingTomatoSauce, N'Xốt cà chua', 3, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM30, @ingOregano, N'Lá oregano', 6, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	DECLARE @productId31 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId31, N'Pizza Sò điệp Hokkaido Gratin với xốt Miso ngọt', N'Mô tả đang cập nhật', 420000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/10010008_2.jpg', NULL, @appetizersCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId311 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId312 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId313 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId314 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId311, N'Chọn loại phô mai', N'Chọn loại phô mai phù hợp cho pizza của bạn', @productId31, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId312, N'Chọn topping', N'Chọn topping thêm vào pizza của bạn', @productId31, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId313, N'Chọn kích thước', N'Chọn kích thước pizza', @productId31, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId314, N'Chọn đế bánh', N'Chọn loại đế bánh cho pizza của bạn', @productId31, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);
	
	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Phô mai Mozzarella', 0, @optionId311, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Ricotta', 15000, @optionId311, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Camembert', 20000, @optionId311, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Sò điệp Hokkaido', 50000, @optionId312, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Xúc xích Ý Milano', 20000, @optionId312, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'S (Nhỏ)', 0, @optionId313, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'M (Vừa)', 10000, @optionId313, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 20000, @optionId313, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế mỏng', 0, @optionId314, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế dày', 5000, @optionId314, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế không gluten', 10000, @optionId314, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

		-- Declare Size IDs
	DECLARE @sizeS31 UNIQUEIDENTIFIER = NEWID();
	DECLARE @sizeM31 UNIQUEIDENTIFIER = NEWID();

	-- Insert Product Sizes
	INSERT INTO ProductSize ([Id], [Name], [Diameter], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@sizeS31, N'S (Nhỏ)', 20.0, N'Cỡ nhỏ phù hợp cá nhân', @productId31, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@sizeM31, N'M (Vừa)', 25.0, N'Cỡ vừa cho 1-2 người', @productId31, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size S
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeS31, @ingMozzarella, N'Mozzarella', 1, 40, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS31, @ingRicotta, N'Ricotta', 1, 25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS31, @ingCamembert, N'Camembert', 1, 20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS31, @ingTomSu, N'Sò điệp Hokkaido', 5, 6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS31, @ingMilanoSausage, N'Xúc xích Ý Milano', 1, 30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS31, @ingXotHanNgot, N'Xốt Miso ngọt', 3, 3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS31, @ingOregano, N'Lá oregano', 6, 3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size M
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeM31, @ingMozzarella, N'Mozzarella', 1, 50, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM31, @ingRicotta, N'Ricotta', 1, 30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM31, @ingCamembert, N'Camembert', 1, 25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM31, @ingTomSu, N'Sò điệp Hokkaido', 5, 8, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM31, @ingMilanoSausage, N'Xúc xích Ý Milano', 1, 40, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM31, @ingXotHanNgot, N'Xốt Miso ngọt', 3, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM31, @ingOregano, N'Lá oregano', 6, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	DECLARE @productId32 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId32, N'Pizza Hải sản xốt cà chua cay với phô mai hun khói', N'Mô tả đang cập nhật', 274000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/10000014_2.jpg', NULL, @appetizersCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId321 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId322 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId323 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId324 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId321, N'Chọn loại phô mai', N'Chọn loại phô mai phù hợp cho pizza của bạn', @productId32, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId322, N'Chọn topping', N'Chọn topping thêm vào pizza của bạn', @productId32, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId323, N'Chọn kích thước', N'Chọn kích thước pizza', @productId32, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId324, N'Chọn đế bánh', N'Chọn loại đế bánh cho pizza của bạn', @productId32, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Phô mai Mozzarella', 0, @optionId321, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Hun khói', 15000, @optionId321, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Ricotta', 20000, @optionId321, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Tôm sú', 30000, @optionId322, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nghêu', 20000, @optionId322, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Mực', 25000, @optionId322, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'S (Nhỏ)', 0, @optionId323, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'M (Vừa)', 10000, @optionId323, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 20000, @optionId323, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế mỏng', 0, @optionId324, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế dày', 5000, @optionId324, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế không gluten', 10000, @optionId324, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

		-- Declare Size IDs
	DECLARE @sizeS32 UNIQUEIDENTIFIER = NEWID();
	DECLARE @sizeM32 UNIQUEIDENTIFIER = NEWID();

	-- Insert Product Sizes
	INSERT INTO ProductSize ([Id], [Name], [Diameter], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@sizeS32, N'S (Nhỏ)', 20.0, N'Cỡ nhỏ phù hợp cá nhân', @productId32, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@sizeM32, N'M (Vừa)', 25.0, N'Cỡ vừa cho 1-2 người', @productId32, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size S
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeS32, @ingMozzarella, N'Mozzarella', 1, 35, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS32, @ingRicotta, N'Ricotta', 1, 20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS32, @ingCheddar, N'Phô mai hun khói', 1, 25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS32, @ingTomSu, N'Tôm sú', 5, 6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS32, @ingMuc, N'Mực', 5, 5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS32, @ingTomSu, N'Nghêu', 5, 5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS32, @ingTomatoSauce, N'Xốt cà chua cay', 3, 3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS32, @ingOregano, N'Lá oregano', 6, 3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size M
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeM32, @ingMozzarella, N'Mozzarella', 1, 45, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM32, @ingRicotta, N'Ricotta', 1, 25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM32, @ingCheddar, N'Phô mai hun khói', 1, 30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM32, @ingTomSu, N'Tôm sú', 5, 8, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM32, @ingMuc, N'Mực', 5, 6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM32, @ingTomSu, N'Nghêu', 5, 6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM32, @ingTomatoSauce, N'Xốt cà chua cay', 3, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM32, @ingOregano, N'Lá oregano', 6, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	DECLARE @productId33 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId33, N'Pizza 4 loại phô mai nhà làm', N'Mô tả đang cập nhật', 248000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/10000006_2.jpg', NULL, @appetizersCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId331 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId332 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId333 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId334 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId331, N'Chọn loại phô mai', N'Chọn loại phô mai phù hợp cho pizza của bạn', @productId33, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId332, N'Chọn topping', N'Chọn topping thêm vào pizza của bạn', @productId33, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId333, N'Chọn kích thước', N'Chọn kích thước pizza', @productId33, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId334, N'Chọn đế bánh', N'Chọn loại đế bánh cho pizza của bạn', @productId33, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Phô mai Mozzarella', 0, @optionId331, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Mascarpone', 15000, @optionId331, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Ricotta', 20000, @optionId331, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Parmesan', 25000, @optionId331, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Tôm sú', 30000, @optionId332, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Mực', 25000, @optionId332, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Ngọc trai', 20000, @optionId332, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'S (Nhỏ)', 0, @optionId333, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'M (Vừa)', 10000, @optionId333, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 20000, @optionId333, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế mỏng', 0, @optionId334, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế dày', 5000, @optionId334, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế không gluten', 10000, @optionId334, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Declare Size IDs
	DECLARE @sizeS33 UNIQUEIDENTIFIER = NEWID();
	DECLARE @sizeM33 UNIQUEIDENTIFIER = NEWID();

	-- Insert Product Sizes
	INSERT INTO ProductSize ([Id], [Name], [Diameter], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@sizeS33, N'S (Nhỏ)', 20.0, N'Cỡ nhỏ phù hợp cá nhân', @productId33, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@sizeM33, N'M (Vừa)', 25.0, N'Cỡ vừa cho 1-2 người', @productId33, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size S
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeS33, @ingMozzarella, N'Mozzarella', 1, 35, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS33, @ingRicotta, N'Ricotta', 1, 20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS33, @ingMascarpone, N'Mascarpone', 1, 15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS33, @ingParmesan, N'Parmesan', 1, 10, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS33, @ingOregano, N'Lá oregano', 6, 3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size M
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeM33, @ingMozzarella, N'Mozzarella', 1, 45, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM33, @ingRicotta, N'Ricotta', 1, 25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM33, @ingMascarpone, N'Mascarpone', 1, 20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM33, @ingParmesan, N'Parmesan', 1, 15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM33, @ingOregano, N'Lá oregano', 6, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	DECLARE @productId34 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId34, N'Pizza Sashimi cá hồi kèm phô mai Ricotta và xốt hành', N'Mô tả đang cập nhật', 288000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/10000012_2.jpg', NULL, @appetizersCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId341 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId342 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId343 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId344 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId341, N'Chọn loại phô mai', N'Chọn loại phô mai phù hợp cho pizza của bạn', @productId34, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId342, N'Chọn topping', N'Chọn topping thêm vào pizza của bạn', @productId34, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId343, N'Chọn kích thước', N'Chọn kích thước pizza', @productId34, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId344, N'Chọn đế bánh', N'Chọn loại đế bánh cho pizza của bạn', @productId34, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL); -- Đế bánh option mới cho pizza

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Phô mai Ricotta', 0, @optionId341, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Mozzarella', 15000, @optionId341, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Mascarpone', 20000, @optionId341, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Parmesan', 25000, @optionId341, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Sashimi cá hồi', 35000, @optionId342, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Tôm sú', 30000, @optionId342, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Mực', 25000, @optionId342, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'S (Nhỏ)', 0, @optionId343, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'M (Vừa)', 10000, @optionId343, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 20000, @optionId343, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế mỏng', 0, @optionId344, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế dày', 5000, @optionId344, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế không gluten', 10000, @optionId344, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Declare Size IDs
	DECLARE @sizeS34 UNIQUEIDENTIFIER = NEWID();
	DECLARE @sizeM34 UNIQUEIDENTIFIER = NEWID();

	-- Insert Product Sizes
	INSERT INTO ProductSize ([Id], [Name], [Diameter], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@sizeS34, N'S (Nhỏ)', 20.0, N'Cỡ nhỏ phù hợp cá nhân', @productId34, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@sizeM34, N'M (Vừa)', 25.0, N'Cỡ vừa cho 1-2 người', @productId34, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size S
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeS34, @ingRicotta, N'Ricotta', 1, 25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS34, @ingMozzarella, N'Mozzarella', 1, 20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS34, @ingMascarpone, N'Mascarpone', 1, 15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS34, @ingParmesan, N'Parmesan', 1, 10, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS34, @ingSashimiCaHoi, N'Sashimi cá hồi', 5, 6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS34, @ingXotHanNgot, N'Xốt hành ngọt', 3, 3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS34, @ingOregano, N'Lá oregano', 6, 3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size M
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeM34, @ingRicotta, N'Ricotta', 1, 30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM34, @ingMozzarella, N'Mozzarella', 1, 30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM34, @ingMascarpone, N'Mascarpone', 1, 20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM34, @ingParmesan, N'Parmesan', 1, 15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM34, @ingSashimiCaHoi, N'Sashimi cá hồi', 5, 8, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM34, @ingXotHanNgot, N'Xốt hành ngọt', 3, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM34, @ingOregano, N'Lá oregano', 6, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	DECLARE @productId35 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId35, N'Pizza Cá hồi xốt kem miso', N'Mô tả đang cập nhật', 278000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/10000013_2.jpg', NULL, @appetizersCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId351 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId352 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId353 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId354 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId351, N'Chọn loại phô mai', N'Chọn loại phô mai phù hợp cho pizza của bạn', @productId35, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId352, N'Chọn topping', N'Chọn topping thêm vào pizza của bạn', @productId35, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId353, N'Chọn kích thước', N'Chọn kích thước pizza', @productId35, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId354, N'Chọn đế bánh', N'Chọn loại đế bánh cho pizza của bạn', @productId35, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Phô mai Ricotta', 0, @optionId351, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Mozzarella', 15000, @optionId351, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Mascarpone', 20000, @optionId351, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Parmesan', 25000, @optionId351, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Sashimi cá hồi', 35000, @optionId352, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Tôm sú', 30000, @optionId352, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Mực', 25000, @optionId352, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'S (Nhỏ)', 0, @optionId353, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'M (Vừa)', 10000, @optionId353, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 20000, @optionId353, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế mỏng', 0, @optionId354, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế dày', 5000, @optionId354, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế không gluten', 10000, @optionId354, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

		-- Declare Size IDs
	DECLARE @sizeS35 UNIQUEIDENTIFIER = NEWID();
	DECLARE @sizeM35 UNIQUEIDENTIFIER = NEWID();

	-- Insert Product Sizes
	INSERT INTO ProductSize ([Id], [Name], [Diameter], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@sizeS35, N'S (Nhỏ)', 20.0, N'Cỡ nhỏ phù hợp cá nhân', @productId35, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@sizeM35, N'M (Vừa)', 25.0, N'Cỡ vừa cho 1-2 người', @productId35, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size S
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeS35, @ingRicotta, N'Ricotta', 1, 25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS35, @ingMozzarella, N'Mozzarella', 1, 20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS35, @ingMascarpone, N'Mascarpone', 1, 15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS35, @ingParmesan, N'Parmesan', 1, 10, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS35, @ingSashimiCaHoi, N'Sashimi cá hồi', 5, 6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS35, @ingXotHanNgot, N'Xốt kem miso', 3, 3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS35, @ingOregano, N'Lá oregano', 6, 3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size M
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeM35, @ingRicotta, N'Ricotta', 1, 30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM35, @ingMozzarella, N'Mozzarella', 1, 30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM35, @ingMascarpone, N'Mascarpone', 1, 20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM35, @ingParmesan, N'Parmesan', 1, 15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM35, @ingSashimiCaHoi, N'Sashimi cá hồi', 5, 8, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM35, @ingXotHanNgot, N'Xốt kem miso', 3, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM35, @ingOregano, N'Lá oregano', 6, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	DECLARE @productId36 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId36, N'Pizza Tôm và xốt Mayonnaise', N'Mô tả đang cập nhật', 254000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/10000015_2.jpg', NULL, @appetizersCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId361 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId362 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId363 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId364 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId361, N'Chọn loại phô mai', N'Chọn loại phô mai phù hợp cho pizza của bạn', @productId36, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId362, N'Chọn topping', N'Chọn topping thêm vào pizza của bạn', @productId36, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId363, N'Chọn kích thước', N'Chọn kích thước pizza', @productId36, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId364, N'Chọn đế bánh', N'Chọn loại đế bánh cho pizza của bạn', @productId36, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Phô mai Ricotta', 0, @optionId361, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Mozzarella', 15000, @optionId361, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Mascarpone', 20000, @optionId361, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Parmesan', 25000, @optionId361, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Tôm sú', 30000, @optionId362, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Mực', 25000, @optionId362, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Bò bít tết', 35000, @optionId362, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'S (Nhỏ)', 0, @optionId363, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'M (Vừa)', 10000, @optionId363, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 20000, @optionId363, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế mỏng', 0, @optionId364, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế dày', 5000, @optionId364, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế không gluten', 10000, @optionId364, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Declare Size IDs
	DECLARE @sizeS36 UNIQUEIDENTIFIER = NEWID();
	DECLARE @sizeM36 UNIQUEIDENTIFIER = NEWID();

	-- Insert Product Sizes
	INSERT INTO ProductSize ([Id], [Name], [Diameter], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@sizeS36, N'S (Nhỏ)', 20.0, N'Cỡ nhỏ phù hợp cá nhân', @productId36, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@sizeM36, N'M (Vừa)', 25.0, N'Cỡ vừa cho 1-2 người', @productId36, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size S
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeS36, @ingRicotta, N'Ricotta', 1, 25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS36, @ingMozzarella, N'Mozzarella', 1, 20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS36, @ingMascarpone, N'Mascarpone', 1, 15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS36, @ingParmesan, N'Parmesan', 1, 10, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS36, @ingTomSu, N'Tôm sú', 5, 6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS36, @ingXotHanNgot, N'Xốt mayonnaise', 3, 3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS36, @ingOregano, N'Lá oregano', 6, 3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size M
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeM36, @ingRicotta, N'Ricotta', 1, 30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM36, @ingMozzarella, N'Mozzarella', 1, 30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM36, @ingMascarpone, N'Mascarpone', 1, 20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM36, @ingParmesan, N'Parmesan', 1, 15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM36, @ingTomSu, N'Tôm sú', 5, 8, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM36, @ingXotHanNgot, N'Xốt mayonnaise', 3, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM36, @ingOregano, N'Lá oregano', 6, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	DECLARE @productId37 UNIQUEIDENTIFIER = NEWID();

	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId37, N'Pizza Thịt bò cay kiểu Kebab', N'Mô tả đang cập nhật', 294000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/08/Spicy-Kebab-Pizza.jpg', NULL, @appetizersCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId371 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId372 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId373 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId374 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId371, N'Chọn loại phô mai', N'Chọn loại phô mai phù hợp cho pizza của bạn', @productId37, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId372, N'Chọn topping', N'Chọn topping thêm vào pizza của bạn', @productId37, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId373, N'Chọn kích thước', N'Chọn kích thước pizza', @productId37, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId374, N'Chọn đế bánh', N'Chọn loại đế bánh cho pizza của bạn', @productId37, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL); -- Đế bánh option cho pizza

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Phô mai Ricotta', 0, @optionId371, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Mozzarella', 15000, @optionId371, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Mascarpone', 20000, @optionId371, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Parmesan', 25000, @optionId371, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Thịt bò Kebab', 35000, @optionId372, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Hành tây nướng', 15000, @optionId372, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Ớt xanh', 10000, @optionId372, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'S (Nhỏ)', 0, @optionId373, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'M (Vừa)', 10000, @optionId373, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 20000, @optionId373, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế mỏng', 0, @optionId374, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế dày', 5000, @optionId374, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế không gluten', 10000, @optionId374, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Declare Size IDs
DECLARE @sizeS37 UNIQUEIDENTIFIER = NEWID();
DECLARE @sizeM37 UNIQUEIDENTIFIER = NEWID();

-- Insert Product Sizes
INSERT INTO ProductSize ([Id], [Name], [Diameter], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
VALUES
(@sizeS37, N'S (Nhỏ)', 20.0, N'Cỡ nhỏ phù hợp cá nhân', @productId37, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
(@sizeM37, N'M (Vừa)', 25.0, N'Cỡ vừa cho 1-2 người', @productId37, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

-- Insert Recipe for Size S
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeS37, @ingRicotta, N'Ricotta', 1, 25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS37, @ingMozzarella, N'Mozzarella', 1, 20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS37, @ingMascarpone, N'Mascarpone', 1, 15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS37, @ingParmesan, N'Parmesan', 1, 10, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS37, @ingThitBoKebab, N'Thịt bò Kebab', 1, 35, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS37, @ingHanTayNgot, N'Hành tây nướng', 1, 20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS37, @ingOtDoChuong, N'Ớt xanh', 1, 15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS37, @ingXotHanNgot, N'Xốt cay ngọt', 3, 3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS37, @ingOregano, N'Lá oregano', 6, 3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size M
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeM37, @ingRicotta, N'Ricotta', 1, 30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM37, @ingMozzarella, N'Mozzarella', 1, 30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM37, @ingMascarpone, N'Mascarpone', 1, 20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM37, @ingParmesan, N'Parmesan', 1, 15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM37, @ingThitBoKebab, N'Thịt bò Kebab', 1, 45, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM37, @ingHanTayNgot, N'Hành tây nướng', 1, 25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM37, @ingOtDoChuong, N'Ớt xanh', 1, 20, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM37, @ingXotHanNgot, N'Xốt cay ngọt', 3, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM37, @ingOregano, N'Lá oregano', 6, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	DECLARE @productId38 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId38, N'Pizza Bò với dầu tỏi', N'Mô tả đang cập nhật', 284000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/10000021_2.jpg', NULL, @appetizersCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId381 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId382 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId383 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId384 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId381, N'Chọn loại phô mai', N'Tùy chọn thêm phô mai cho pizza của bạn', @productId38, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId382, N'Thêm topping', N'Chọn thêm topping yêu thích', @productId38, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId383, N'Chọn kích thước', N'Tùy chọn size phù hợp', @productId38, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId384, N'Chọn đế bánh', N'Tùy chọn đế bánh yêu thích', @productId38, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Mozzarella', 0, @optionId381, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Parmesan', 15000, @optionId381, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Ricotta', 15000, @optionId381, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Thịt bò lát', 0, @optionId382, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Dầu tỏi', 0, @optionId382, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Hành tím', 10000, @optionId382, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Ớt chuông', 10000, @optionId382, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'S (Nhỏ)', 0, @optionId383, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'M (Vừa)', 10000, @optionId383, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 20000, @optionId383, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế mỏng', 0, @optionId384, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế dày', 5000, @optionId384, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế không gluten', 10000, @optionId384, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Declare Size IDs
	DECLARE @sizeS38 UNIQUEIDENTIFIER = NEWID();
	DECLARE @sizeM38 UNIQUEIDENTIFIER = NEWID();

	-- Insert Product Sizes
	INSERT INTO ProductSize ([Id], [Name], [Diameter], [Description], [ProductId], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(@sizeS38, N'S (Nhỏ)', 20.0, N'Cỡ nhỏ phù hợp cá nhân', @productId38, GETDATE(), N'Admin', 0),
	(@sizeM38, N'M (Vừa)', 25.0, N'Cỡ vừa cho 1-2 người', @productId38, GETDATE(), N'Admin', 0);

	-- Insert Recipe for Size S
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(NEWID(), @sizeS38, @ingMozzarella, N'Mozzarella', 1, 30, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS38, @ingParmesan, N'Parmesan', 1, 10, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS38, @ingRicotta, N'Ricotta', 1, 20, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS38, @ingThitBoLat, N'Thịt bò lát', 1, 35, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS38, @ingToiBam, N'Dầu tỏi', 3, 3, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS38, @ingHanhTim, N'Hành tím', 1, 10, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS38, @ingOtDoChuong, N'Ớt chuông', 1, 10, GETDATE(), N'Admin', 0);

	-- Insert Recipe for Size M
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(NEWID(), @sizeM38, @ingMozzarella, N'Mozzarella', 1, 40, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM38, @ingParmesan, N'Parmesan', 1, 15, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM38, @ingRicotta, N'Ricotta', 1, 25, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM38, @ingThitBoLat, N'Thịt bò lát', 1, 45, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM38, @ingToiBam, N'Dầu tỏi', 3, 4, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM38, @ingHanhTim, N'Hành tím', 1, 15, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM38, @ingOtDoChuong, N'Ớt chuông', 1, 15, GETDATE(), N'Admin', 0);


	DECLARE @productId40 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId40, N'Pizza Cà ri gà cay', N'Mô tả đang cập nhật', 218000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/08/DSC04135.jpg', NULL, @pizzaCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId401 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId402 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId403 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId401, N'Thêm topping', N'Topping thêm cho pizza của bạn', @productId40, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId402, N'Chọn size', N'Chọn kích thước pizza', @productId40, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId403, N'Chọn đế bánh', N'Chọn loại đế bánh pizza bạn muốn', @productId40, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Phô mai thêm', 15000, @optionId401, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Ớt Jalapeño', 10000, @optionId401, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Hành tím nướng', 8000, @optionId401, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'S (Nhỏ)', 0, @optionId402, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'M (Vừa)', 30000, @optionId402, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 60000, @optionId402, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế mỏng', 0, @optionId403, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế dày', 10000, @optionId403, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế viền phô mai', 20000, @optionId403, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Declare Size IDs
	DECLARE @sizeS40 UNIQUEIDENTIFIER = NEWID();
	DECLARE @sizeM40 UNIQUEIDENTIFIER = NEWID();

	-- Insert Product Sizes
	INSERT INTO ProductSize ([Id], [Name], [Diameter], [Description], [ProductId], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(@sizeS40, N'S (Nhỏ)', 20.0, N'Cỡ nhỏ phù hợp cá nhân', @productId40, GETDATE(), N'Admin', 0),
	(@sizeM40, N'M (Vừa)', 25.0, N'Cỡ vừa cho 1-2 người', @productId40, GETDATE(), N'Admin', 0);

	-- Recipe for Size S
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(NEWID(), @sizeS40, @ingMozzarella, N'Mozzarella', 1, 25, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS40, @ingParmesan, N'Parmesan', 1, 10, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS40, @ingThitGaTeriyaki, N'Thịt gà', 1, 35, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS40, @ingXotHanNgot, N'Xốt cà ri', 3, 3, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS40, @ingHanhTim, N'Hành tím nướng', 1, 10, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS40, @ingJalapeno, N'Ớt Jalapeño', 1, 5, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS40, @ingDill, N'Dill', 6, 2, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS40, @ingSage, N'Sage', 6, 1.5, GETDATE(), N'Admin', 0);

	-- Recipe for Size M
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(NEWID(), @sizeM40, @ingMozzarella, N'Mozzarella', 1, 35, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM40, @ingParmesan, N'Parmesan', 1, 15, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM40, @ingThitGaTeriyaki, N'Thịt gà', 1, 45, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM40, @ingXotHanNgot, N'Xốt cà ri', 3, 4, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM40, @ingHanhTim, N'Hành tím nướng', 1, 15, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM40, @ingJalapeno, N'Ớt Jalapeño', 1, 7, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM40, @ingDill, N'Dill', 6, 3, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM40, @ingSage, N'Sage', 6, 2, GETDATE(), N'Admin', 0);


	DECLARE @productId41 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId41, N'Pizza Phô mai Camembert nhà làm và xốt nấm thịt nguội', N'Mô tả đang cập nhật', 208000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/10000018_2.jpg', NULL, @pizzaCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId411 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId412 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId413 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId411, N'Thêm topping', N'Topping thêm cho pizza của bạn', @productId41, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId412, N'Chọn size', N'Chọn kích thước pizza', @productId41, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId413, N'Chọn đế bánh', N'Chọn loại đế bánh pizza bạn muốn', @productId41, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Nấm Truffle', 20000, @optionId411, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai thêm', 15000, @optionId411, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Thịt nguội thêm', 18000, @optionId411, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'S (Nhỏ)', 0, @optionId412, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'M (Vừa)', 30000, @optionId412, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 60000, @optionId412, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế mỏng', 0, @optionId413, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế dày', 10000, @optionId413, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế viền phô mai', 20000, @optionId411, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Declare Size IDs
	DECLARE @sizeS41 UNIQUEIDENTIFIER = NEWID();
	DECLARE @sizeM41 UNIQUEIDENTIFIER = NEWID();

	-- Insert Product Sizes
	INSERT INTO ProductSize ([Id], [Name], [Diameter], [Description], [ProductId], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(@sizeS41, N'S (Nhỏ)', 20.0, N'Cỡ nhỏ phù hợp cá nhân', @productId41, GETDATE(), N'Admin', 0),
	(@sizeM41, N'M (Vừa)', 25.0, N'Cỡ vừa cho 1-2 người', @productId41, GETDATE(), N'Admin', 0);

	-- Recipe for Size S
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(NEWID(), @sizeS41, @ingMozzarella, N'Mozzarella', 1, 25, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS41, @ingParmesan, N'Parmesan', 1, 10, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS41, @ingCamembert, N'Camembert', 1, 20, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS41, @ingParmaHam, N'Thịt nguội Ý Parma', 1, 30, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS41, @ingTruffleHoney, N'Nấm Truffle', 1, 8, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS41, @ingXotHanNgot, N'Xốt nấm', 3, 3, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS41, @ingThyme, N'Lá thyme', 6, 2, GETDATE(), N'Admin', 0);

	-- Recipe for Size M
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(NEWID(), @sizeM41, @ingMozzarella, N'Mozzarella', 1, 35, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM41, @ingParmesan, N'Parmesan', 1, 15, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM41, @ingCamembert, N'Camembert', 1, 30, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM41, @ingParmaHam, N'Thịt nguội Ý Parma', 1, 40, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM41, @ingTruffleHoney, N'Nấm Truffle', 1, 10, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM41, @ingXotHanNgot, N'Xốt nấm', 3, 4, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM41, @ingThyme, N'Lá thyme', 6, 3, GETDATE(), N'Admin', 0);


	DECLARE @productId42 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId42, N'Pizza gà Teriyaki', N'Mô tả đang cập nhật', 218000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/10000017_2.jpg', NULL, @pizzaCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId421 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId422 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId423 UNIQUEIDENTIFIER = NEWID();

	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId421, N'Thêm topping', N'Topping thêm cho pizza của bạn', @productId42, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId422, N'Chọn size', N'Chọn kích thước pizza', @productId42, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId423, N'Chọn đế bánh', N'Chọn loại đế bánh pizza bạn muốn', @productId42, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Thêm gà Teriyaki', 20000, @optionId421, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Hành tây ngọt', 10000, @optionId421, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai thêm', 15000, @optionId421, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'S (Nhỏ)', 0, @optionId422, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'M (Vừa)', 30000, @optionId422, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 60000, @optionId422, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế mỏng', 0, @optionId423, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế dày', 10000, @optionId423, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế viền phô mai', 20000, @optionId423, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Declare Size IDs
	DECLARE @sizeS42 UNIQUEIDENTIFIER = NEWID();
	DECLARE @sizeM42 UNIQUEIDENTIFIER = NEWID();

	-- Insert Product Sizes
	INSERT INTO ProductSize ([Id], [Name], [Diameter], [Description], [ProductId], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(@sizeS42, N'S (Nhỏ)', 20.0, N'Cỡ nhỏ phù hợp cá nhân', @productId42, GETDATE(), N'Admin', 0),
	(@sizeM42, N'M (Vừa)', 25.0, N'Cỡ vừa cho 1-2 người', @productId42, GETDATE(), N'Admin', 0);

	-- Recipe for Size S
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(NEWID(), @sizeS42, @ingMozzarella, N'Mozzarella', 1, 30, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS42, @ingParmesan, N'Parmesan', 1, 10, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS42, @ingThitGaTeriyaki, N'Thịt gà Teriyaki', 1, 35, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS42, @ingNuocXotTeriyaki, N'Nước xốt Teriyaki', 3, 3.5, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS42, @ingHanTayNgot, N'Hành tây ngọt', 1, 10, GETDATE(), N'Admin', 0);

	-- Recipe for Size M
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(NEWID(), @sizeM42, @ingMozzarella, N'Mozzarella', 1, 40, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM42, @ingParmesan, N'Parmesan', 1, 15, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM42, @ingThitGaTeriyaki, N'Thịt gà Teriyaki', 1, 45, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM42, @ingNuocXotTeriyaki, N'Nước xốt Teriyaki', 3, 4.5, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM42, @ingHanTayNgot, N'Hành tây ngọt', 1, 15, GETDATE(), N'Admin', 0);


	DECLARE @productId43 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId43, N'Pizza Bò kho', N'Mô tả đang cập nhật', 248000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/10010014_2.jpg', NULL, @pizzaCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId431 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId432 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId433 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId431, N'Thêm topping', N'Topping thêm cho pizza của bạn', @productId43, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId432, N'Chọn size', N'Chọn kích thước pizza', @productId43, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId433, N'Chọn đế bánh', N'Chọn loại đế bánh pizza bạn muốn', @productId43, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Thêm thịt bò kho', 20000, @optionId431, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Cà rốt hầm mềm', 10000, @optionId431, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phô mai Mozzarella thêm', 15000, @optionId431, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'S (Nhỏ)', 0, @optionId432, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'M (Vừa)', 30000, @optionId432, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 60000, @optionId432, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế mỏng', 0, @optionId433, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế dày', 10000, @optionId433, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế viền phô mai', 20000, @optionId433, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Declare Size IDs
	DECLARE @sizeS43 UNIQUEIDENTIFIER = NEWID();
	DECLARE @sizeM43 UNIQUEIDENTIFIER = NEWID();

	-- Insert Product Sizes
	INSERT INTO ProductSize ([Id], [Name], [Diameter], [Description], [ProductId], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(@sizeS43, N'S (Nhỏ)', 20.0, N'Cỡ nhỏ phù hợp cá nhân', @productId43, GETDATE(), N'Admin', 0),
	(@sizeM43, N'M (Vừa)', 25.0, N'Cỡ vừa cho 1-2 người', @productId43, GETDATE(), N'Admin', 0);

	-- Recipe for Size S
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(NEWID(), @sizeS43, @ingMozzarella, N'Mozzarella', 1, 30, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS43, @ingBoKho, N'Thịt bò kho', 1, 40, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS43, @ingCarotHam, N'Cà rốt hầm', 1, 20, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS43, @ingXotHanNgot, N'Xốt hành ngọt', 3, 3.5, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS43, @ingParsley, N'Parsley', 6, 2, GETDATE(), N'Admin', 0);

	-- Recipe for Size M
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(NEWID(), @sizeM43, @ingMozzarella, N'Mozzarella', 1, 40, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM43, @ingBoKho, N'Thịt bò kho', 1, 55, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM43, @ingCarotHam, N'Cà rốt hầm', 1, 25, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM43, @ingXotHanNgot, N'Xốt hành ngọt', 3, 4.5, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM43, @ingParsley, N'Parsley', 6, 3, GETDATE(), N'Admin', 0);


	DECLARE @productId44 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId44, N'Pizza rau cải xoăn kèm phô mai Ricotta chanh nhà làm với xốt ô liu và nụ bạch hoa', N'Mô tả đang cập nhật', 188000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/10004067_2.jpg', NULL, @pizzaCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId441 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId442 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId443 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId441, N'Thêm topping', N'Topping thêm cho pizza của bạn', @productId44, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId442, N'Chọn size', N'Chọn kích thước pizza', @productId44, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId443, N'Chọn đế bánh', N'Chọn loại đế bánh pizza bạn muốn', @productId44, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Thêm phô mai Ricotta chanh', 15000, @optionId441, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Thêm cải xoăn', 10000, @optionId441, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nụ bạch hoa thêm', 10000, @optionId441, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'S (Nhỏ)', 0, @optionId442, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'M (Vừa)', 30000, @optionId442, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 60000, @optionId442, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế mỏng', 0, @optionId443, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế dày', 10000, @optionId443, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế viền phô mai', 20000, @optionId443, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Declare Size IDs
	DECLARE @sizeS44 UNIQUEIDENTIFIER = NEWID();
	DECLARE @sizeM44 UNIQUEIDENTIFIER = NEWID();

	-- Insert Product Sizes
	INSERT INTO ProductSize ([Id], [Name], [Diameter], [Description], [ProductId], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(@sizeS44, N'S (Nhỏ)', 20.0, N'Cỡ nhỏ phù hợp cá nhân', @productId44, GETDATE(), N'Admin', 0),
	(@sizeM44, N'M (Vừa)', 25.0, N'Cỡ vừa cho 1-2 người', @productId44, GETDATE(), N'Admin', 0);

	-- Recipe for Size S
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(NEWID(), @sizeS44, @ingRicotta, N'Phô mai Ricotta chanh', 1, 35, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS44, @ingKale, N'Cải xoăn', 1, 20, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS44, @ingCapers, N'Nụ bạch hoa', 1, 10, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS44, @ingOliveSauce, N'Xốt ô liu', 3, 3, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS44, @ingDill, N'Dill', 6, 2, GETDATE(), N'Admin', 0);

	-- Recipe for Size M
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(NEWID(), @sizeM44, @ingRicotta, N'Phô mai Ricotta chanh', 1, 45, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM44, @ingKale, N'Cải xoăn', 1, 30, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM44, @ingCapers, N'Nụ bạch hoa', 1, 15, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM44, @ingOliveSauce, N'Xốt ô liu', 3, 4, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM44, @ingDill, N'Dill', 6, 2.5, GETDATE(), N'Admin', 0);


	DECLARE @productId45 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId45, N'Pizza 5 loại phô mai nhà làm', N'Mô tả đang cập nhật', 298000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/10000007_2.jpg', NULL, @pizzaCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);
	DECLARE @optionId451 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId452 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId453 UNIQUEIDENTIFIER = NEWID();

	-- Insert Options
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(@optionId451, N'Thêm phô mai', N'Thêm các loại phô mai thượng hạng cho pizza của bạn', @productId45, GETDATE(), N'Admin', 0),
	(@optionId452, N'Chọn size', N'Chọn kích thước pizza', @productId45, GETDATE(), N'Admin', 0),
	(@optionId453, N'Chọn đế bánh', N'Chọn loại đế bánh pizza bạn muốn', @productId45, GETDATE(), N'Admin', 0);

	-- Insert OptionItems
	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(NEWID(), N'Thêm Crottin de Chavignol', 15000, @optionId451, GETDATE(), N'Admin', 0),
	(NEWID(), N'Thêm Vacherin', 14000, @optionId451, GETDATE(), N'Admin', 0),
	(NEWID(), N'Thêm Montasio', 13000, @optionId451, GETDATE(), N'Admin', 0),
	(NEWID(), N'Thêm Raclette', 16000, @optionId451, GETDATE(), N'Admin', 0),
	(NEWID(), N'Thêm phô mai Mozzarella', 10000, @optionId451, GETDATE(), N'Admin', 0), -- still keeping one familiar classic

	-- Size Options
	(NEWID(), N'S (Nhỏ)', 0, @optionId452, GETDATE(), N'Admin', 0),
	(NEWID(), N'M (Vừa)', 30000, @optionId452, GETDATE(), N'Admin', 0),
	(NEWID(), N'L (Lớn)', 60000, @optionId452, GETDATE(), N'Admin', 0),

	-- Crust Options
	(NEWID(), N'Đế mỏng', 0, @optionId453, GETDATE(), N'Admin', 0),
	(NEWID(), N'Đế dày', 10000, @optionId453, GETDATE(), N'Admin', 0),
	(NEWID(), N'Đế viền phô mai', 20000, @optionId453, GETDATE(), N'Admin', 0);
	-- Declare ProductSize IDs
	DECLARE @sizeS45 UNIQUEIDENTIFIER = NEWID();
	DECLARE @sizeM45 UNIQUEIDENTIFIER = NEWID();

	-- Insert ProductSizes
	INSERT INTO ProductSize ([Id], [Name], [Diameter], [Description], [ProductId], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(@sizeS45, N'S (Nhỏ)', 20.0, N'Cỡ nhỏ phù hợp cá nhân', @productId45, GETDATE(), N'Admin', 0),
	(@sizeM45, N'M (Vừa)', 25.0, N'Cỡ vừa cho 1-2 người', @productId45, GETDATE(), N'Admin', 0);

	-- Insert Recipes for Size S
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(NEWID(), @sizeS45, @ingMozzarella, N'Mozzarella', 1, 25, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS45, @ingCrottin, N'Crottin de Chavignol', 1, 20, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS45, @ingVacherin, N'Vacherin', 1, 20, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS45, @ingMontasio, N'Montasio', 1, 20, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeS45, @ingRaclette, N'Raclette', 1, 25, GETDATE(), N'Admin', 0);

	-- Insert Recipes for Size M
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(NEWID(), @sizeM45, @ingMozzarella, N'Mozzarella', 1, 35, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM45, @ingCrottin, N'Crottin de Chavignol', 1, 30, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM45, @ingVacherin, N'Vacherin', 1, 30, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM45, @ingMontasio, N'Montasio', 1, 30, GETDATE(), N'Admin', 0),
	(NEWID(), @sizeM45, @ingRaclette, N'Raclette', 1, 35, GETDATE(), N'Admin', 0);


	DECLARE @productId46 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId46, N'Pizza 4 loại nấm', N'Mô tả đang cập nhật', 198000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/10000024_2.jpg', NULL, @pizzaCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId461 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId462 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId463 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId461, N'Thêm topping', N'Topping thêm cho pizza của bạn', @productId46, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId462, N'Chọn size', N'Chọn kích thước pizza', @productId46, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId463, N'Chọn đế bánh', N'Chọn loại đế bánh pizza bạn muốn', @productId46, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Đế bánh
	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Nấm Button', 10000, @optionId463, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nấm Portobello', 15000, @optionId463, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nấm Shiitake', 12000, @optionId463, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nấm Enoki', 10000, @optionId463, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'S (Nhỏ)', 0, @optionId462, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'M (Vừa)', 30000, @optionId462, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 60000, @optionId462, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế mỏng', 0, @optionId463, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế dày', 10000, @optionId463, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế viền phô mai', 20000, @optionId463, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	-- Declare ProductSize IDs
	DECLARE @sizeS46 UNIQUEIDENTIFIER = NEWID();
	DECLARE @sizeM46 UNIQUEIDENTIFIER = NEWID();

	-- Insert ProductSizes
	INSERT INTO ProductSize ([Id], [Name], [Diameter], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@sizeS46, N'S (Nhỏ)', 20.0, N'Cỡ nhỏ phù hợp cá nhân', @productId46, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@sizeM46, N'M (Vừa)', 25.0, N'Cỡ vừa cho 1-2 người', @productId46, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size S
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeS46, @ingMozzarella, N'Mozzarella', 1, 30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS46, @ingTomatoSauce, N'Xốt cà chua', 3, 2.0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS46, @ingMushroomButton, N'Nấm Button', 1, 15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS46, @ingMushroomPortobello, N'Nấm Portobello', 1, 10, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS46, @ingMushroomShiitake, N'Nấm Shiitake', 1, 10, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS46, @ingMushroomEnoki, N'Nấm Enoki', 1, 8, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Insert Recipe for Size M
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeM46, @ingMozzarella, N'Mozzarella', 1, 45, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM46, @ingTomatoSauce, N'Xốt cà chua', 3, 3.0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM46, @ingMushroomButton, N'Nấm Button', 1, 25, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM46, @ingMushroomPortobello, N'Nấm Portobello', 1, 15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM46, @ingMushroomShiitake, N'Nấm Shiitake', 1, 15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM46, @ingMushroomEnoki, N'Nấm Enoki', 1, 12, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	DECLARE @productId49 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId49, N'Pizza Margherita đậm vị Việt Nam', N'Mô tả đang cập nhật', 180000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/10000053_2.jpg', NULL, @pizzaCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId491 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId492 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId493 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId491, N'Thêm topping', N'Topping thêm cho pizza của bạn', @productId49, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId492, N'Chọn size', N'Chọn kích thước pizza', @productId49, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId493, N'Chọn đế bánh', N'Chọn loại đế bánh pizza bạn muốn', @productId49, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Thêm phô mai Mozzarella', 12000, @optionId491, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Thêm húng quế tươi', 5000, @optionId491, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Thêm cà chua bi', 8000, @optionId491, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'S (Nhỏ)', 0, @optionId492, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'M (Vừa)', 30000, @optionId492, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 60000, @optionId492, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế mỏng', 0, @optionId493, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế dày', 10000, @optionId493, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế viền phô mai', 20000, @optionId493, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Declare ProductSize IDs
	DECLARE @sizeS49 UNIQUEIDENTIFIER = NEWID();
	DECLARE @sizeM49 UNIQUEIDENTIFIER = NEWID();

	-- Insert ProductSizes
	INSERT INTO ProductSize ([Id], [Name], [Diameter], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@sizeS49, N'S (Nhỏ)', 20.0, N'Cỡ nhỏ phù hợp cá nhân', @productId49, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@sizeM49, N'M (Vừa)', 25.0, N'Cỡ vừa cho 1-2 người', @productId49, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Recipe for Size S
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeS49, @ingMozzarella, N'Mozzarella', 1, 30, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS49, @ingTomatoSauce, N'Xốt cà chua', 3, 2.0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS49, @ingBasil, N'Húng quế', 1, 5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS49, @ingParmesan, N'Parmesan', 1, 10, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS49, @ingCreamCheese, N'Cream Cheese', 1, 5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS49, @ingToiBam, N'Tỏi băm', 1, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS49, @ingRicotta, N'Ricotta', 1, 10, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS49, @ingOregano, N'Oregano', 1, 2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS49, @ingBlueCheese, N'Blue Cheese', 1, 4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeS49, @ingDill, N'Dill', 1, 2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Recipe for Size M
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), @sizeM49, @ingMozzarella, N'Mozzarella', 1, 45, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM49, @ingTomatoSauce, N'Xốt cà chua', 3, 3.0, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM49, @ingBasil, N'Húng quế', 1, 7, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM49, @ingParmesan, N'Parmesan', 1, 15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM49, @ingCreamCheese, N'Cream Cheese', 1, 7, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM49, @ingToiBam, N'Tỏi băm', 1, 6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM49, @ingRicotta, N'Ricotta', 1, 15, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM49, @ingOregano, N'Oregano', 1, 3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM49, @ingBlueCheese, N'Blue Cheese', 1, 6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), @sizeM49, @ingDill, N'Dill', 1, 3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @productId50 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId50, N'Pizza Bò nướng lá lốt', N'Hương vị Việt Nam độc đáo kết hợp trên nền pizza hiện đại', 265000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/10000011_2.jpg', NULL, @pizzaCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Options
	DECLARE @optionId501 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId502 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId503 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId501, N'Thêm topping', N'Thêm hương vị Việt yêu thích', @productId50, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId502, N'Chọn size', N'Chọn kích thước pizza', @productId50, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId503, N'Chọn đế bánh', N'Tùy chọn đế phù hợp với khẩu vị', @productId50, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- OptionItems
	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Thêm mắm nêm', 10000, @optionId501, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Thêm mỡ hành', 8000, @optionId501, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Hành phi thêm', 5000, @optionId501, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'S (Nhỏ)', 0, @optionId502, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'M (Vừa)', 20000, @optionId502, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế mỏng', 0, @optionId503, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Đế dày', 10000, @optionId503, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- ProductSize

	DECLARE @productSizeIdS UNIQUEIDENTIFIER = NEWID();
	DECLARE @productSizeIdM UNIQUEIDENTIFIER = NEWID();

	INSERT INTO ProductSize ([Id], [Name], [Diameter], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productSizeIdS, 'S', 22, N'Pizza cỡ nhỏ', @productId50, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@productSizeIdM, 'M', 28, N'Pizza cỡ vừa', @productId50, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	-- Recipe for Size S
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(NEWID(), @productSizeIdS, @ingBoLaLot, N'Lá lốt', 5, 1, GETDATE(), N'Admin', 0),         -- Piece
	(NEWID(), @productSizeIdS, @ingMoHanh, N'Mỡ hành', 4, 1, GETDATE(), N'Admin', 0),         -- Tablespoon
	(NEWID(), @productSizeIdS, @ingOtHiem, N'Ớt hiểm', 5, 3, GETDATE(), N'Admin', 0),         -- Piece
	(NEWID(), @productSizeIdS, @ingMamNemSauRieng, N'Mắm nêm sầu riêng', 6, 1, GETDATE(), N'Admin', 0), -- Teaspoon
	(NEWID(), @productSizeIdS, @ingHanhPhi, N'Hành phi', 4, 1, GETDATE(), N'Admin', 0);       -- Tablespoon

	-- Recipe for Size M
	INSERT INTO Recipe ([Id], [ProductSizeId], [IngredientId], [IngredientName], [Unit], [Quantity], [CreatedDate], [CreatedBy], [IsDeleted])
	VALUES
	(NEWID(), @productSizeIdM, @ingBoLaLot, N'Lá lốt', 5, 2, GETDATE(), N'Admin', 0),
	(NEWID(), @productSizeIdM, @ingMoHanh, N'Mỡ hành', 4, 1.5, GETDATE(), N'Admin', 0),
	(NEWID(), @productSizeIdM, @ingOtHiem, N'Ớt hiểm', 5, 5, GETDATE(), N'Admin', 0),
	(NEWID(), @productSizeIdM, @ingMamNemSauRieng, N'Mắm nêm sầu riêng', 6, 1.5, GETDATE(), N'Admin', 0),
	(NEWID(), @productSizeIdM, @ingHanhPhi, N'Hành phi', 4, 1.5, GETDATE(), N'Admin', 0);

		-- Create new category for Drinks
	DECLARE @drinkCategoryId UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Category ([Id], [Name], [Description], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@drinkCategoryId, N'Thức uống', N'Danh mục cho các loại đồ uống', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Drink 1: Trà Vải Hồng Trà
	DECLARE @productIdD1 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productIdD1, N'Trà Vải Hồng Trà', N'Trà đen đậm vị kết hợp với vải tươi mát lạnh', 58000, NULL, NULL, NULL, @drinkCategoryId, 2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionIdD11 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionIdD12 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionIdD11, N'Chọn lượng đá', N'Tùy chỉnh lượng đá trong ly', @productIdD1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionIdD12, N'Chọn lượng đường', N'Tùy chỉnh độ ngọt của thức uống', @productIdD1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Ít đá', 0, @optionIdD11, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Vừa đá', 0, @optionIdD11, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nhiều đá', 0, @optionIdD11, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Không đường', 0, @optionIdD12, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Ít đường', 0, @optionIdD12, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Vừa ngọt', 0, @optionIdD12, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Drink 2: Soda Chanh Dây
	DECLARE @productIdD2 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productIdD2, N'Soda Chanh Dây', N'Soda tươi kết hợp vị chanh dây chua ngọt tự nhiên', 52000, NULL, 'https://www.pjscoffee.com/uploads/green-tea-mojito.png', NULL, @drinkCategoryId, 2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionIdD21 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionIdD21, N'Topping thêm', N'Thêm topping cho thức uống của bạn', @productIdD2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Thêm trân châu trắng', 8000, @optionIdD21, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Thêm thạch nha đam', 7000, @optionIdD21, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Thêm thạch trái cây', 9000, @optionIdD21, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Drink 3: Cold Brew Cà Phê Cam Sả
DECLARE @productIdD3 UNIQUEIDENTIFIER = NEWID();
INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
VALUES
(@productIdD3, N'Cold Brew Cà Phê Cam Sả', N'Cà phê Cold Brew ủ lạnh cùng cam tươi và sả thơm dịu', 65000, NULL, 'https://www.pjscoffee.com/uploads/peach-palmer-tea_112900.png', NULL, @drinkCategoryId, 2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

DECLARE @optionIdD31 UNIQUEIDENTIFIER = NEWID();
DECLARE @optionIdD32 UNIQUEIDENTIFIER = NEWID();
INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
VALUES
(@optionIdD31, N'Độ đậm cà phê', N'Tùy chọn độ mạnh của cà phê', @productIdD3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
(@optionIdD32, N'Thêm topping', N'Topping thêm vào thức uống của bạn', @productIdD3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
VALUES
(NEWID(), N'Vừa', 0, @optionIdD31, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
(NEWID(), N'Đậm', 0, @optionIdD31, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
(NEWID(), N'Rất đậm', 5000, @optionIdD31, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
(NEWID(), N'Thêm lát cam', 5000, @optionIdD32, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
(NEWID(), N'Thêm sả tươi', 3000, @optionIdD32, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Drink 4: Matcha Sữa Đậu Nành
	DECLARE @productIdD4 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productIdD4, N'Matcha Sữa Đậu Nành', N'Matcha Nhật Bản kết hợp với sữa đậu nành nguyên chất', 62000, NULL, NULL, NULL, @drinkCategoryId, 2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionIdD41 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionIdD42 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionIdD41, N'Loại sữa', N'Chọn loại sữa cho món Matcha', @productIdD4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionIdD42, N'Độ ngọt', N'Chọn độ ngọt yêu thích', @productIdD4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Sữa đậu nành nguyên chất', 0, @optionIdD41, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Sữa hạnh nhân', 8000, @optionIdD41, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Không đường', 0, @optionIdD42, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Ít ngọt', 0, @optionIdD42, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Ngọt vừa', 0, @optionIdD42, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Pasta 1: Mì Ý bò bằm sốt cà chua
	DECLARE @productIdP1 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productIdP1, N'Mì Ý bò bằm sốt cà chua', N'Mì Ý truyền thống với sốt cà chua và thịt bò bằm', 168000, NULL, 'https://static.wixstatic.com/media/af2956_7d34fa50218148a8b46870e72084ebad~mv2.jpg/v1/fill/w_232,h_232,usm_1.20_1.00_0.01/file.webp', NULL, @pastaCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);
	-- Option: Loại mì
	DECLARE @optionId_PastaType UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_PastaType, N'Loại mì', N'Chọn loại mì yêu thích', @productIdP1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'Spaghetti', 0, @optionId_PastaType, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Penne', 0, @optionId_PastaType, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Fettuccine', 0, @optionId_PastaType, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Khẩu phần
	DECLARE @optionId_Portion UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_Portion, N'Khẩu phần', N'Chọn khẩu phần phù hợp', @productIdP1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 người', 0, @optionId_Portion, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Gia đình', 65000, @optionId_Portion, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Món ăn kèm
	DECLARE @optionId_SideDish UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_SideDish, N'Món ăn kèm', N'Tùy chọn món ăn kèm với món chính', @productIdP1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 1);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'Không thêm món kèm', 0, @optionId_SideDish, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Bánh mì bơ tỏi', 18000, @optionId_SideDish, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Salad trộn nhỏ', 25000, @optionId_SideDish, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);



	-- Pasta 2: Pasta kem nấm và phô mai
	DECLARE @productIdP2 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productIdP2, N'Pasta kem nấm và phô mai', N'Món ăn chay với sốt kem nấm béo nhẹ và phô mai Parmesan', 178000, NULL, 'https://static.wixstatic.com/media/af2956_f180c93e3d8f441792f99b9ba90076bc~mv2.jpg/v1/fill/w_232,h_232,usm_1.20_1.00_0.01/file.webp', NULL, @pastaCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

		-- Option: Loại mì
	DECLARE @optionId_PastaType_P2 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_PastaType_P2, N'Loại mì', N'Chọn loại mì phù hợp với món sốt kem nấm', @productIdP2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'Spaghetti', 0, @optionId_PastaType_P2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Fettuccine', 0, @optionId_PastaType_P2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Tagliatelle', 0, @optionId_PastaType_P2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Khẩu phần
	DECLARE @optionId_Portion_P2 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_Portion_P2, N'Khẩu phần', N'Chọn khẩu phần theo nhu cầu', @productIdP2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 người', 0, @optionId_Portion_P2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Gia đình', 68000, @optionId_Portion_P2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Món ăn kèm
	DECLARE @optionId_SideDish_P2 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_SideDish_P2, N'Món ăn kèm', N'Chọn thêm món phụ nếu bạn muốn', @productIdP2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 1);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'Không thêm món kèm', 0, @optionId_SideDish_P2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Bánh mì bơ tỏi', 18000, @optionId_SideDish_P2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Salad trộn nhỏ', 25000, @optionId_SideDish_P2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	-- Pasta 3: Pasta gà Teriyaki xốt tiêu đen
	DECLARE @productIdP3 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productIdP3, N'Pasta gà Teriyaki xốt tiêu đen', N'Sự kết hợp giữa hương vị Á - Âu: gà Teriyaki và sốt tiêu đen', 185000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/20000057_2.jpg', NULL, @pastaCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);
		-- Option: Loại mì
	DECLARE @optionId_PastaType_P3 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_PastaType_P3, N'Loại mì', N'Chọn loại mì phù hợp với món Teriyaki', @productIdP3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'Spaghetti', 0, @optionId_PastaType_P3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Fettuccine', 0, @optionId_PastaType_P3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Udon', 0, @optionId_PastaType_P3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Khẩu phần
	DECLARE @optionId_Portion_P3 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_Portion_P3, N'Khẩu phần', N'Chọn khẩu phần theo nhu cầu', @productIdP3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 người', 0, @optionId_Portion_P3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Gia đình', 70000, @optionId_Portion_P3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Mức độ cay
	DECLARE @optionId_SpiceLevel_P3 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_SpiceLevel_P3, N'Mức độ cay', N'Tùy chỉnh độ cay theo khẩu vị', @productIdP3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'Không cay', 0, @optionId_SpiceLevel_P3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Cay vừa', 0, @optionId_SpiceLevel_P3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Cay nhiều', 0, @optionId_SpiceLevel_P3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);



	-- Pasta 4: Mì Ý chay rau củ Đà Lạt
	DECLARE @productIdP4 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productIdP4, N'Mì Ý chay rau củ Đà Lạt', N'Mì Ý với rau củ tươi từ Đà Lạt và sốt cà chua đặc biệt', 158000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/20200016_2.jpg', NULL, @pastaCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Loại mì
	DECLARE @optionId_PastaType_P4 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_PastaType_P4, N'Loại mì', N'Chọn loại mì phù hợp với rau củ Đà Lạt', @productIdP4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'Spaghetti', 0, @optionId_PastaType_P4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Penne', 0, @optionId_PastaType_P4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Fusilli', 0, @optionId_PastaType_P4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Khẩu phần
	DECLARE @optionId_Portion_P4 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_Portion_P4, N'Khẩu phần', N'Chọn khẩu phần theo nhu cầu', @productIdP4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 người', 0, @optionId_Portion_P4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Gia đình', 60000, @optionId_Portion_P4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Món ăn kèm
	DECLARE @optionId_SideDish_P4 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_SideDish_P4, N'Món ăn kèm', N'Tùy chọn món phụ kèm theo món chay', @productIdP4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 1);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'Không thêm món kèm', 0, @optionId_SideDish_P4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Bánh mì bơ tỏi', 18000, @optionId_SideDish_P4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Salad trộn nhỏ', 25000, @optionId_SideDish_P4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	-- Pasta 5: Pasta Tôm Sốt Cay Kiểu Cajun
	DECLARE @productIdP5 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productIdP5, N'Pasta Tôm Sốt Cay Kiểu Cajun', N'Tôm tươi xào sốt cay Cajun, đậm đà và hấp dẫn', 198000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/20200001_2.jpg', NULL, @pastaCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Loại mì
	DECLARE @optionId_PastaType_P5 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_PastaType_P5, N'Loại mì', N'Chọn loại mì phù hợp với sốt Cajun', @productIdP5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'Fettuccine', 0, @optionId_PastaType_P5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Penne', 0, @optionId_PastaType_P5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Linguine', 0, @optionId_PastaType_P5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Khẩu phần
	DECLARE @optionId_Portion_P5 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_Portion_P5, N'Khẩu phần', N'Chọn khẩu phần theo nhu cầu', @productIdP5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 người', 0, @optionId_Portion_P5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Gia đình', 75000, @optionId_Portion_P5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Mức độ cay
	DECLARE @optionId_SpiceLevel_P5 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_SpiceLevel_P5, N'Mức độ cay', N'Chọn độ cay phù hợp với khẩu vị', @productIdP5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'Ít cay', 0, @optionId_SpiceLevel_P5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Cay vừa', 0, @optionId_SpiceLevel_P5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Cay nhiều', 0, @optionId_SpiceLevel_P5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Pasta 6: Mì Ý Xốt Pesto Rau Húng Quế
	DECLARE @productIdP6 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productIdP6, N'Mì Ý Xốt Pesto Rau Húng Quế', N'Sốt pesto tươi kết hợp với phô mai Parmesan và hạt thông', 175000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/20200003_2.jpg', NULL, @pastaCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	-- Option: Loại mì
	DECLARE @optionId_PastaType_P6 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_PastaType_P6, N'Loại mì', N'Chọn loại mì yêu thích cùng sốt pesto', @productIdP6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'Spaghetti', 0, @optionId_PastaType_P6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Fusilli', 0, @optionId_PastaType_P6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Linguine', 0, @optionId_PastaType_P6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Khẩu phần
	DECLARE @optionId_Portion_P6 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_Portion_P6, N'Khẩu phần', N'Chọn khẩu phần theo nhu cầu', @productIdP6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 người', 0, @optionId_Portion_P6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Gia đình', 68000, @optionId_Portion_P6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Món ăn kèm
	DECLARE @optionId_SideDish_P6 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_SideDish_P6, N'Món ăn kèm', N'Tùy chọn món phụ kèm theo món pesto', @productIdP6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 1);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'Không thêm món kèm', 0, @optionId_SideDish_P6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Bánh mì bơ tỏi', 18000, @optionId_SideDish_P6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Salad trộn nhỏ', 25000, @optionId_SideDish_P6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Pasta 7: Pasta Hải Sản Xốt Kem Chanh
	DECLARE @productIdP7 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productIdP7, N'Pasta Hải Sản Xốt Kem Chanh', N'Tôm, mực và nghêu hòa quyện cùng sốt kem chanh tươi', 215000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/20200015_2.jpg', NULL, @pastaCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Loại mì
	DECLARE @optionId_PastaType_P7 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_PastaType_P7, N'Loại mì', N'Chọn loại mì phù hợp với sốt kem chanh', @productIdP7, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'Spaghetti', 0, @optionId_PastaType_P7, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Tagliatelle', 0, @optionId_PastaType_P7, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Fettuccine', 0, @optionId_PastaType_P7, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Khẩu phần
	DECLARE @optionId_Portion_P7 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_Portion_P7, N'Khẩu phần', N'Chọn khẩu phần theo nhu cầu', @productIdP7, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 người', 0, @optionId_Portion_P7, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Gia đình', 72000, @optionId_Portion_P7, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Món ăn kèm
	DECLARE @optionId_SideDish_P7 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_SideDish_P7, N'Món ăn kèm', N'Tùy chọn món phụ kèm theo món hải sản', @productIdP7, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 1);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'Không thêm món kèm', 0, @optionId_SideDish_P7, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Bánh mì bơ tỏi', 18000, @optionId_SideDish_P7, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Salad trộn nhỏ', 25000, @optionId_SideDish_P7, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	-- Pasta 8: Mì Ý Sốt Cà Chua Nướng & Phô Mai Burrata
	DECLARE @productIdP8 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productIdP8, N'Mì Ý Sốt Cà Chua Nướng & Phô Mai Burrata', N'Cà chua nướng thơm lừng cùng Burrata béo ngậy tan chảy', 205000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/08/Smoked-Burrata-Bolo-5.jpg', NULL, @pastaCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Loại mì
	DECLARE @optionId_PastaType_P8 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_PastaType_P8, N'Loại mì', N'Thử nghiệm các loại mì độc đáo cùng Burrata', @productIdP8, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'Conchiglie (vỏ sò)', 0, @optionId_PastaType_P8, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Orecchiette (tai nhỏ)', 0, @optionId_PastaType_P8, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Trofie (xoắn)', 0, @optionId_PastaType_P8, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Khẩu phần
	DECLARE @optionId_Portion_P8 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_Portion_P8, N'Khẩu phần', N'Chọn khẩu phần theo nhu cầu', @productIdP8, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 người', 0, @optionId_Portion_P8, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Gia đình', 72000, @optionId_Portion_P8, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Món ăn kèm
	DECLARE @optionId_SideDish_P8 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_SideDish_P8, N'Món ăn kèm', N'Tùy chọn món phụ kèm theo Burrata', @productIdP8, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 1);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'Không thêm món kèm', 0, @optionId_SideDish_P8, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Bánh mì bơ tỏi', 18000, @optionId_SideDish_P8, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Salad trộn nhỏ', 25000, @optionId_SideDish_P8, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

-- Pasta: Bò Hun Khói Kiểu Texas & Sốt Kem Tỏi Đen
	DECLARE @productIdPastaHeavy UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType],
						 [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productIdPastaHeavy, 
	 N'Pasta Bò Hun Khói Kiểu Texas & Sốt Kem Tỏi Đen', 
	 N'Bò hun khói kiểu Texas kết hợp với sốt kem tỏi đen đậm đà, phủ phô mai Parmesan và hành phi.', 
	 198000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/20210013_2.jpg', NULL, @pastaCategoryId, 1, 
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	 -- Option: Loại mì
	DECLARE @optionId_PastaType_Heavy UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_PastaType_Heavy, N'Loại mì', N'Chọn loại mì phù hợp với sốt kem tỏi đen', @productIdPastaHeavy, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	-- Option Items: Pasta Type
	INSERT INTO OptionItem VALUES
	(NEWID(), N'Rigatoni', 0, @optionId_PastaType_Heavy, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Pappardelle', 5000, @optionId_PastaType_Heavy, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Fusilli', 0, @optionId_PastaType_Heavy, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Khẩu phần
	DECLARE @optionId_Portion_Heavy UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_Portion_Heavy, N'Khẩu phần', N'Chọn khẩu phần theo nhu cầu', @productIdPastaHeavy, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	-- Option Items: Portion Size
	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 người', 0, @optionId_Portion_Heavy, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'2 người', 60000, @optionId_Portion_Heavy, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Gia đình', 120000, @optionId_Portion_Heavy, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Mức độ cay
	DECLARE @optionId_Spice_Heavy UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_Spice_Heavy, N'Mức độ cay', N'Lựa chọn độ cay theo khẩu vị', @productIdPastaHeavy, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	-- Option Items: Spice Levels
	INSERT INTO OptionItem VALUES
	(NEWID(), N'Không cay', 0, @optionId_Spice_Heavy, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Cay nhẹ', 0, @optionId_Spice_Heavy, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Cay vừa', 0, @optionId_Spice_Heavy, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Cay nhiều', 0, @optionId_Spice_Heavy, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Topping thêm
	DECLARE @optionId_Toppings_Heavy UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_Toppings_Heavy, N'Topping thêm', N'Tùy chọn thêm topping để tăng hương vị', @productIdPastaHeavy, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 1);

	-- Option Items: Extra Toppings
	INSERT INTO OptionItem VALUES
	(NEWID(), N'Phô mai Parmesan thêm', 15000, @optionId_Toppings_Heavy, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Thịt xông khói giòn', 20000, @optionId_Toppings_Heavy, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Hành phi giòn', 10000, @optionId_Toppings_Heavy, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Ớt Jalapeño', 10000, @optionId_Toppings_Heavy, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nấm xào bơ tỏi', 15000, @optionId_Toppings_Heavy, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Món ăn kèm
	DECLARE @optionId_SideDish_Heavy UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_SideDish_Heavy, N'Món ăn kèm', N'Tùy chọn món phụ kèm theo pasta', @productIdPastaHeavy, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 1);

	-- Option Items: Side Dishes
	INSERT INTO OptionItem VALUES
	(NEWID(), N'Không thêm món kèm', 0, @optionId_SideDish_Heavy, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Bánh mì bơ tỏi', 18000, @optionId_SideDish_Heavy, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Salad rocket & cà chua bi', 35000, @optionId_SideDish_Heavy, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Khoai tây đút lò phô mai', 38000, @optionId_SideDish_Heavy, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


		-- Trà Đào Cam Sả (Drink)
	DECLARE @productId_TraDao UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType], 
						 [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId_TraDao, N'Trà Đào Cam Sả', N'Trà đào cam sả tươi mát, giải nhiệt hoàn hảo', 49000, NULL, 'https://minio.thecoffeehouse.com/image/admin/1737356708_tra-den-macchiato_400x400.png', NULL, @drinkCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Options for Trà Đào Cam Sả
	DECLARE @optionId_Size UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId_Ice UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId_Sugar UNIQUEIDENTIFIER = NEWID();

	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId_Size, N'Chọn size', N'Chọn kích cỡ phù hợp với bạn', @productId_TraDao, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId_Ice, N'Chọn đá', N'Điều chỉnh lượng đá theo ý thích', @productId_TraDao, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId_Sugar, N'Chọn độ ngọt', N'Tùy chỉnh độ ngọt phù hợp khẩu vị', @productId_TraDao, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option Items for Size
	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'S (Nhỏ)', 0, @optionId_Size, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'M (Vừa)', 5000, @optionId_Size, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 10000, @optionId_Size, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option Items for Ice
	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Không đá', 0, @optionId_Ice, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Ít đá', 0, @optionId_Ice, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nhiều đá', 0, @optionId_Ice, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option Items for Sugar
	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'0% đường', 0, @optionId_Sugar, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'50% đường', 0, @optionId_Sugar, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'100% đường', 0, @optionId_Sugar, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Nước Ép Dứa Bạc Hà (Drink)
	DECLARE @productId_PineappleMint UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType],
						 [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId_PineappleMint, N'Nước Ép Dứa Bạc Hà', N'Nước ép dứa tươi mát kết hợp với bạc hà sảng khoái', 55000, NULL, 'https://minio.thecoffeehouse.com/image/admin/1737355612_tx-latte_400x400.png', NULL, @drinkCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Options for Nước Ép Dứa Bạc Hà
	DECLARE @optionId_Size2 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId_Ice2 UNIQUEIDENTIFIER = NEWID();

	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId_Size2, N'Chọn size', N'Chọn kích thước phù hợp', @productId_PineappleMint, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId_Ice2, N'Chọn lượng đá', N'Chọn theo sở thích của bạn', @productId_PineappleMint, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option Items for Size
	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'M (Vừa)', 0, @optionId_Size2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 7000, @optionId_Size2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option Items for Ice
	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Không đá', 0, @optionId_Ice2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Ít đá', 0, @optionId_Ice2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Bình thường', 0, @optionId_Ice2, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Soda Việt Quất (Drink)
	DECLARE @productId_BlueberrySoda UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType],
						 [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId_BlueberrySoda, N'Soda Việt Quất', N'Nước soda mát lạnh kết hợp hương vị việt quất ngọt ngào', 59000, NULL, 'https://cdn.prod.website-files.com/63ec4e0b737eeedb47aa6170/64834a50e7f134164e1b4aff_Untitled%20design%20(49)-p-500.png', NULL, @drinkCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Options for Soda Việt Quất
	DECLARE @optionId_Size3 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId_Ice3 UNIQUEIDENTIFIER = NEWID();

	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId_Size3, N'Chọn size', N'Chọn dung tích phù hợp', @productId_BlueberrySoda, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId_Ice3, N'Chọn đá', N'Điều chỉnh lượng đá', @productId_BlueberrySoda, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option Items for Size
	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'M (Vừa)', 0, @optionId_Size3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 7000, @optionId_Size3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option Items for Ice
	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Không đá', 0, @optionId_Ice3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Ít đá', 0, @optionId_Ice3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nhiều đá', 0, @optionId_Ice3, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Trà Cam Mật Ong (Drink)
	DECLARE @productId_HoneyLemonTea UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType],
						 [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId_HoneyLemonTea, N'Trà Cam Mật Ong', N'Trà cam thơm mát hòa quyện cùng mật ong dịu ngọt', 53000, NULL, 'https://cdn.prod.website-files.com/63ec4e0b737eeedb47aa6170/64834a50e7f134164e1b4aff_Untitled%20design%20(49)-p-500.png', NULL, @drinkCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Options for Trà Cam Mật Ong
	DECLARE @optionId_Size4 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId_Ice4 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId_Sugar4 UNIQUEIDENTIFIER = NEWID();

	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId_Size4, N'Chọn size', N'Chọn kích cỡ phù hợp', @productId_HoneyLemonTea, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId_Ice4, N'Chọn đá', N'Tùy chỉnh lượng đá', @productId_HoneyLemonTea, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId_Sugar4, N'Chọn độ ngọt', N'Lựa chọn mức đường', @productId_HoneyLemonTea, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option Items for Size
	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'M (Vừa)', 0, @optionId_Size4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 8000, @optionId_Size4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option Items for Ice
	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Không đá', 0, @optionId_Ice4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Ít đá', 0, @optionId_Ice4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Bình thường', 0, @optionId_Ice4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option Items for Sugar
	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'25% đường', 0, @optionId_Sugar4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'50% đường', 0, @optionId_Sugar4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'100% đường', 0, @optionId_Sugar4, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Soda Chanh Dây (Drink)
	DECLARE @productId_PassionSoda UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType],
						 [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId_PassionSoda, N'Soda Chanh Dây', N'Soda chanh dây chua ngọt, có ga, mát lạnh sảng khoái', 57000, NULL, 'https://cdn.prod.website-files.com/63ec4e0b737eeedb47aa6170/648342cf7cc61c603f81ff46_Green%20Jasmin%20Iced%20Tea-p-500.png', NULL, @drinkCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Options for Soda Chanh Dây
	DECLARE @optionId_Size5 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId_Ice5 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId_Sugar5 UNIQUEIDENTIFIER = NEWID();

	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId_Size5, N'Chọn size', N'Chọn dung tích ly phù hợp', @productId_PassionSoda, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId_Ice5, N'Chọn lượng đá', N'Tùy chỉnh lượng đá cho đồ uống', @productId_PassionSoda, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId_Sugar5, N'Chọn độ ngọt', N'Lựa chọn độ ngọt mong muốn', @productId_PassionSoda, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option Items for Size
	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'M (Vừa)', 0, @optionId_Size5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 7000, @optionId_Size5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option Items for Ice
	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Không đá', 0, @optionId_Ice5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Ít đá', 0, @optionId_Ice5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Bình thường', 0, @optionId_Ice5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option Items for Sugar
	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'25% đường', 0, @optionId_Sugar5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'50% đường', 0, @optionId_Sugar5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'100% đường', 0, @optionId_Sugar5, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Soda Táo Quế (Drink)
	DECLARE @productId_AppleCinnamonSoda UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType],
						 [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId_AppleCinnamonSoda, N'Soda Táo Quế', N'Sự kết hợp giữa vị táo ngọt và hương quế nhẹ nhàng trong ly soda có ga mát lạnh', 60000, NULL, 'https://cdn.prod.website-files.com/63ec4e0b737eeedb47aa6170/648342ece4318572bd84cfef_Mango%20Passion%20Fruit%20Iced%20Tea-p-500.png', NULL, @drinkCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Options for Soda Táo Quế
	DECLARE @optionId_Size6 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId_Ice6 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId_Sugar6 UNIQUEIDENTIFIER = NEWID();

	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId_Size6, N'Chọn size', N'Chọn kích thước ly', @productId_AppleCinnamonSoda, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId_Ice6, N'Chọn đá', N'Tùy chỉnh đá theo khẩu vị', @productId_AppleCinnamonSoda, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId_Sugar6, N'Chọn độ ngọt', N'Điều chỉnh độ ngọt', @productId_AppleCinnamonSoda, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option Items for Size
	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'M (Vừa)', 0, @optionId_Size6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 8000, @optionId_Size6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option Items for Ice
	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Không đá', 0, @optionId_Ice6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Ít đá', 0, @optionId_Ice6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nhiều đá', 0, @optionId_Ice6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option Items for Sugar
	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'25% đường', 0, @optionId_Sugar6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'50% đường', 0, @optionId_Sugar6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'100% đường', 0, @optionId_Sugar6, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Matcha Latte (Drink)
	DECLARE @productId_MatchaLatte UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType],
						 [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId_MatchaLatte, N'Matcha Latte', N'Matcha Nhật Bản thơm dịu hòa quyện cùng sữa, mang đến vị thanh mát, béo nhẹ', 62000, NULL, 'https://cdn.prod.website-files.com/63ec4e0b737eeedb47aa6170/63ec529dc182117bea82bbb0_Ice%20Matcha%20Latte-p-500.jpg', NULL, @drinkCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Options for Matcha Latte
	DECLARE @optionId_Size7 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId_Ice7 UNIQUEIDENTIFIER = NEWID();
	DECLARE @optionId_MilkType UNIQUEIDENTIFIER = NEWID();

	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId_Size7, N'Chọn size', N'Chọn kích cỡ ly', @productId_MatchaLatte, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId_Ice7, N'Chọn đá', N'Chọn mức đá mong muốn', @productId_MatchaLatte, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(@optionId_MilkType, N'Loại sữa', N'Chọn loại sữa phù hợp với chế độ dinh dưỡng của bạn', @productId_MatchaLatte, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option Items for Size
	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'M (Vừa)', 0, @optionId_Size7, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'L (Lớn)', 8000, @optionId_Size7, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option Items for Ice
	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Không đá', 0, @optionId_Ice7, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Ít đá', 0, @optionId_Ice7, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nhiều đá', 0, @optionId_Ice7, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option Items for Milk Type
	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'Sữa tươi nguyên kem', 0, @optionId_MilkType, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Sữa hạt óc chó', 10000, @optionId_MilkType, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Sữa hạt hạnh nhân', 10000, @optionId_MilkType, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Sữa yến mạch', 12000, @optionId_MilkType, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Sữa đậu nành', 8000, @optionId_MilkType, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Moët & Chandon Brut
	DECLARE @productId_Moet UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product ([Id], [Name], [Description], [Price], [Image], [ImageUrl], [ImagePublicId], [CategoryId], [ProductType],
						 [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@productId_Moet, N'Moët & Chandon Brut', N'Champagne cổ điển với hương vị tinh tế và thanh lịch', 290000, NULL, 'https://www.noburestaurants.com/assets/article-media-files/Nobu-Wine.jpg', NULL, @drinkCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId_Moet UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] ([Id], [Name], [Description], [ProductId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(@optionId_Moet, N'Chọn khẩu phần', N'Chọn giữa 1 ly hoặc nguyên chai', @productId_Moet, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	INSERT INTO OptionItem ([Id], [Name], [AdditionalPrice], [OptionId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy])
	VALUES
	(NEWID(), N'1 shot', 0, @optionId_Moet, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nguyên chai', 1900000, @optionId_Moet, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @productId_Veuve UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product VALUES
	(@productId_Veuve, N'Veuve Clicquot Yellow Label', N'Sự cân bằng tuyệt hảo giữa sự sống động và chiều sâu', 310000, NULL, NULL, NULL, @drinkCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId_Veuve UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_Veuve, N'Chọn khẩu phần', N'Chọn giữa 1 ly hoặc nguyên chai', @productId_Veuve, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 shot', 0, @optionId_Veuve, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nguyên chai', 2100000, @optionId_Veuve, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	DECLARE @productId_Dom UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product VALUES
	(@productId_Dom, N'Dom Pérignon Vintage', N'Vị champagne biểu tượng với hương vị sang trọng, sâu lắng', 490000, NULL, NULL, NULL, @drinkCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId_Dom UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_Dom, N'Chọn khẩu phần', N'Chọn giữa 1 ly hoặc nguyên chai', @productId_Dom, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 shot', 0, @optionId_Dom, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nguyên chai', 6500000, @optionId_Dom, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	DECLARE @productId_Perrier UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product VALUES
	(@productId_Perrier, N'Perrier-Jouët Grand Brut', N'Sự kết hợp của sự mềm mại và hương hoa tươi mới', 270000, NULL, NULL, NULL, @drinkCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId_Perrier UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_Perrier, N'Chọn khẩu phần', N'Chọn giữa 1 ly hoặc nguyên chai', @productId_Perrier, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 shot', 0, @optionId_Perrier, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nguyên chai', 1850000, @optionId_Perrier, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	DECLARE @productId_Ruinart UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product VALUES
	(@productId_Ruinart, N'Ruinart Blanc de Blancs', N'Champagne từ nho Chardonnay 100%, thanh lịch và tươi sáng', 340000, NULL, NULL, NULL, @drinkCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId_Ruinart UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_Ruinart, N'Chọn khẩu phần', N'Chọn giữa 1 ly hoặc nguyên chai', @productId_Ruinart, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 shot', 0, @optionId_Ruinart, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nguyên chai', 3100000, @optionId_Ruinart, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Trà Hoa Cúc Mật Ong
	DECLARE @productId_Chamomile UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product VALUES
	(@productId_Chamomile, N'Trà Hoa Cúc Mật Ong', N'Trà hoa cúc dịu nhẹ kết hợp cùng mật ong thanh mát, giúp thư giãn tinh thần', 45000, NULL, NULL, NULL, @drinkCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId_Chamomile UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_Chamomile, N'Chọn khẩu phần', N'Chọn giữa 1 ly hoặc nguyên ấm', @productId_Chamomile, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 khẩu phần', 0, @optionId_Chamomile, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nguyên ấm', 120000, @optionId_Chamomile, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Trà Gừng Tươi
	DECLARE @productId_GingerTea UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product VALUES
	(@productId_GingerTea, N'Trà Gừng Tươi', N'Trà gừng ấm nóng, tốt cho sức khỏe và làm ấm cơ thể', 42000, NULL, NULL, NULL, @drinkCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId_GingerTea UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_GingerTea, N'Chọn khẩu phần', N'Chọn giữa 1 ly hoặc nguyên ấm', @productId_GingerTea, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 khẩu phần', 0, @optionId_GingerTea, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nguyên ấm', 100000, @optionId_GingerTea, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Trà Đào Hoa Hồng
	DECLARE @productId_PeachRoseTea UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product VALUES
	(@productId_PeachRoseTea, N'Trà Đào Hoa Hồng', N'Sự kết hợp giữa hương đào ngọt ngào và cánh hoa hồng thơm nhẹ', 49000, NULL, NULL, NULL, @drinkCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId_PeachRoseTea UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_PeachRoseTea, N'Chọn khẩu phần', N'Chọn giữa 1 ly hoặc nguyên ấm', @productId_PeachRoseTea, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 khẩu phần', 0, @optionId_PeachRoseTea, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nguyên ấm', 130000, @optionId_PeachRoseTea, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Trà Sen Tây Hồ
	DECLARE @productId_LotusTea UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product VALUES
	(@productId_LotusTea, N'Trà Sen Tây Hồ', N'Trà xanh ướp sen Tây Hồ truyền thống, thanh tao và tinh khiết', 49000, NULL, NULL, NULL, @drinkCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId_LotusTea UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_LotusTea, N'Chọn khẩu phần', N'Chọn giữa 1 ly hoặc nguyên ấm', @productId_LotusTea, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 khẩu phần', 0, @optionId_LotusTea, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nguyên ấm', 140000, @optionId_LotusTea, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	-- Trà Ô Long Mật Ong
	DECLARE @productId_Oolong UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product VALUES
	(@productId_Oolong, N'Trà Ô Long Mật Ong', N'Trà ô long thanh mát hòa quyện cùng vị ngọt tự nhiên của mật ong', 47000, NULL, NULL, NULL, @drinkCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId_Oolong UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_Oolong, N'Chọn khẩu phần', N'Chọn giữa 1 ly hoặc nguyên ấm', @productId_Oolong, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 khẩu phần', 0, @optionId_Oolong, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nguyên ấm', 125000, @optionId_Oolong, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	-- Trà Táo Quế Nóng
	DECLARE @productId_AppleCinnamonTea UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product VALUES
	(@productId_AppleCinnamonTea, N'Trà Táo Quế Nóng', N'Trà táo quế nóng, thơm dịu, hoàn hảo cho những ngày se lạnh', 52000, NULL, NULL, NULL, @drinkCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId_AppleCinnamonTea UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_AppleCinnamonTea, N'Chọn khẩu phần', N'Chọn giữa 1 ly hoặc nguyên ấm', @productId_AppleCinnamonTea, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 khẩu phần', 0, @optionId_AppleCinnamonTea, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nguyên ấm', 135000, @optionId_AppleCinnamonTea, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Bánh Phô Mai Nhật Bản
	DECLARE @productId_JapanCheesecake UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product VALUES
	(@productId_JapanCheesecake, N'Bánh Phô Mai Nhật Bản', N'Bánh phô mai Nhật mềm mịn, nhẹ và tan ngay trong miệng', 58000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/Double-Cheese-Cake_STY-2-scaled-e1713111064854.jpg', NULL, @dessertCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Chọn khẩu phần
	DECLARE @optionId_JapanCheesecake UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_JapanCheesecake, N'Chọn khẩu phần', N'Chọn giữa 1 lát hoặc nguyên bánh', @productId_JapanCheesecake, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	-- Option Items
	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 lát', 0, @optionId_JapanCheesecake, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nguyên bánh', 320000, @optionId_JapanCheesecake, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Bánh Sô-cô-la Lava
	DECLARE @productId_ChocolateLava UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product VALUES
	(@productId_ChocolateLava, N'Bánh Sô-cô-la Lava', N'Bánh sô-cô-la mềm ấm, nhân tan chảy, ăn kèm kem lạnh là tuyệt vời', 62000, NULL, 'https://dessertgallery.com/cdn/shop/files/Mom_sChocolateCake_6inch-medium.jpg?v=1724605926&width=832', NULL, @dessertCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId_ChocolateLava UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_ChocolateLava, N'Chọn khẩu phần', N'Chọn giữa 1 phần hoặc nguyên bánh', @productId_ChocolateLava, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 lát', 0, @optionId_ChocolateLava, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nguyên bánh', 350000, @optionId_ChocolateLava, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	-- Bánh Dâu Kem Tươi
	DECLARE @productId_StrawberryCream UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product VALUES
	(@productId_StrawberryCream, N'Bánh Dâu Kem Tươi', N'Bánh bông lan mềm mịn với kem tươi và dâu tây tươi ngọt', 59000, NULL, 'https://dessertgallery.com/cdn/shop/files/LemonBlueberryCake_6inch-medium.jpg?v=1724605704&width=832', NULL, @dessertCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId_StrawberryCream UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_StrawberryCream, N'Chọn khẩu phần', N'Chọn giữa 1 lát hoặc nguyên bánh', @productId_StrawberryCream, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 lát', 0, @optionId_StrawberryCream, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nguyên bánh', 300000, @optionId_StrawberryCream, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Flan Caramel Nướng
	DECLARE @productId_CaramelFlan UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product VALUES
	(@productId_CaramelFlan, N'Flan Caramel Nướng', N'Bánh flan thơm béo với lớp caramel nướng đậm vị truyền thống', 45000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/30000303_2.jpg', NULL, @dessertCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId_CaramelFlan UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_CaramelFlan, N'Chọn khẩu phần', N'Chọn giữa 1 phần hoặc nguyên khay', @productId_CaramelFlan, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 khẩu phần', 0, @optionId_CaramelFlan, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nguyên khay', 240000, @optionId_CaramelFlan, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Tiramisu Cà Phê Ý
	DECLARE @productId_Tiramisu UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product VALUES
	(@productId_Tiramisu, N'Tiramisu Cà Phê Ý', N'Lớp bánh quy mềm ngấm cà phê espresso, xen lẫn kem mascarpone béo ngậy', 65000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/Kaizen-Tiramisu-scaled.jpg', NULL, @dessertCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId_Tiramisu UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_Tiramisu, N'Chọn khẩu phần', N'Chọn giữa 1 phần hoặc nguyên bánh', @productId_Tiramisu, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 khẩu phần', 0, @optionId_Tiramisu, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nguyên bánh', 390000, @optionId_Tiramisu, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Bánh Chuối Nướng
	DECLARE @productId_BananaCake UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product VALUES
	(@productId_BananaCake, N'Bánh Chuối Nướng', N'Bánh chuối truyền thống thơm bùi, ăn nóng hay lạnh đều ngon', 48000, NULL, 'https://dessertgallery.com/cdn/shop/files/RamadanMubarakCake_yellow.jpg?v=1739030513&width=832', NULL, @dessertCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId_BananaCake UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_BananaCake, N'Chọn khẩu phần', N'Chọn giữa 1 lát hoặc nguyên bánh', @productId_BananaCake, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 lát', 0, @optionId_BananaCake, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nguyên bánh', 270000, @optionId_BananaCake, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Bánh Dừa Nướng Giòn
	DECLARE @productId_CoconutCrisp UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product VALUES
	(@productId_CoconutCrisp, N'Bánh Dừa Nướng Giòn', N'Dừa tươi nướng giòn thơm, vị ngọt dịu và béo nhẹ đặc trưng', 40000, NULL, 'https://cdn.prod.website-files.com/649249d29a20bd6bc3deac48/65eba1161acef3a841275749_Milk%20Cream%20Bread%201.png', NULL, @dessertCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	DECLARE @optionId_CoconutCrisp UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_CoconutCrisp, N'Chọn khẩu phần', N'Chọn giữa 1 phần hoặc nguyên khay', @productId_CoconutCrisp, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 khẩu phần', 0, @optionId_CoconutCrisp, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Nguyên khay', 220000, @optionId_CoconutCrisp, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Panna Cotta Vani
	DECLARE @productId_PannaCotta UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product VALUES
	(@productId_PannaCotta, N'Panna Cotta Vani', N'Món tráng miệng kiểu Ý, mềm mịn vị vani, ăn kèm sốt dâu', 49000, NULL, NULL, NULL, @dessertCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	 -- Brownie Sô-cô-la
	DECLARE @productId_Brownie UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product VALUES
	(@productId_Brownie, N'Brownie Sô-cô-la', N'Bánh brownie đặc sánh, đậm vị cacao, nướng vừa tới, ăn kèm hạnh nhân giòn', 45000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/30000006_2.jpg', NULL, @dessertCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	 -- Cupcake Red Velvet
	DECLARE @productId_RedVelvet UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product VALUES
	(@productId_RedVelvet, N'Cupcake Red Velvet', N'Bánh cupcake đỏ đặc trưng, mềm mịn với kem phô mai béo nhẹ', 52000, NULL, 'https://cdn.prod.website-files.com/649249d29a20bd6bc3deac48/649249d29a20bd6bc3deadf1_Screenshot%25202023-05-15%2520at%252012.29.13%2520PM-p-500.png', NULL, @dessertCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	 -- Chanh Dây Mousse
	DECLARE @productId_PassionMousse UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product VALUES
	(@productId_PassionMousse, N'Chanh Dây Mousse', N'Lớp mousse chanh dây chua ngọt dịu nhẹ, phủ lớp jelly trong veo', 48000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/30000031_2.jpg', NULL, @dessertCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	 -- Rau Câu Dừa Tươi
	DECLARE @productId_CoconutJelly UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product VALUES
	(@productId_CoconutJelly, N'Rau Câu Dừa Tươi', N'Lớp rau câu trong suốt kết hợp nước dừa và cơm dừa non, thanh mát và tự nhiên', 39000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/Pudding_684x684_200924.png', NULL, @dessertCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	 -- Kem Viên Tự Chọn
	DECLARE @productId_IceCream UNIQUEIDENTIFIER = NEWID();
	INSERT INTO Product VALUES
	(@productId_IceCream, N'Kem Viên Tự Chọn', N'Tự do chọn số lượng viên, hương vị và topping yêu thích của bạn', 45000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/07/30000304_2.jpg', NULL, @dessertCategoryId, 0,
	 GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Số lượng viên
	DECLARE @optionId_ScoopQty UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_ScoopQty, N'Số lượng viên', N'Chọn số viên kem bạn muốn', @productId_IceCream, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 0);

	-- Option Items for Quantity
	INSERT INTO OptionItem VALUES
	(NEWID(), N'1 viên', 0, @optionId_ScoopQty, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'2 viên', 10000, @optionId_ScoopQty, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'3 viên', 20000, @optionId_ScoopQty, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Topping
	DECLARE @optionId_Toppings UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_Toppings, N'Topping', N'Tùy chọn thêm topping yêu thích', @productId_IceCream, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 1);

	-- Option Items for Topping
	INSERT INTO OptionItem VALUES
	(NEWID(), N'Hạt điều rang', 5000, @optionId_Toppings, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Chocolate chips', 5000, @optionId_Toppings, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Sốt caramel', 5000, @optionId_Toppings, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Sốt sô-cô-la', 5000, @optionId_Toppings, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Dừa sấy', 5000, @optionId_Toppings, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Kẹo marshmallow mini', 5000, @optionId_Toppings, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

	-- Option: Hương vị kem
	DECLARE @optionId_Flavours UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Option] VALUES
	(@optionId_Flavours, N'Hương vị kem', N'Chọn hương vị yêu thích cho từng viên kem', @productId_IceCream, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL, 1);

	-- Option Items for Flavours
	INSERT INTO OptionItem VALUES
	(NEWID(), N'Vani', 0, @optionId_Flavours, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Sô-cô-la', 0, @optionId_Flavours, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Dâu tây', 0, @optionId_Flavours, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Trà xanh', 0, @optionId_Flavours, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Xoài', 0, @optionId_Flavours, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Dừa', 0, @optionId_Flavours, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Phúc bồn tử', 0, @optionId_Flavours, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Việt quất', 0, @optionId_Flavours, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Cà phê', 0, @optionId_Flavours, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	(NEWID(), N'Bạc hà sô-cô-la', 0, @optionId_Flavours, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);


	-- ZONE 1
	DECLARE @zoneId1 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Zone] (
		[Id], [Name], [Description], [Type],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@zoneId1, N'  A', N'Khu vực A', 0,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- ZONE 2
	DECLARE @zoneId2 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Zone] (
		[Id], [Name], [Description], [Type],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@zoneId2, N'  B', N'Khu vực B', 0,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- ZONE 3
	DECLARE @zoneId3 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Zone] (
		[Id], [Name], [Description], [Type],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@zoneId3, N'  C', N'Khu vực C', 0,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- Zone 4
		DECLARE @zoneId4 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Zone] (
		[Id], [Name], [Description], [Type],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@zoneId4, N'  D', N'Khu Vực D', 1,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

		-- Zone 5
		DECLARE @zoneId5 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Zone] (
		[Id], [Name], [Description], [Type],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@zoneId5, N' Workshop', N'Khu vực Workshop', 2,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);
			-- Zone 6
		DECLARE @zoneId6 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Zone] (
		[Id], [Name], [Description], [Type],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@zoneId6, N' Workshop', N'Khu Vực Workshop', 1,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);



	-- TABLES for ZONE 1
	DECLARE @tableId1 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Table] (
		[Id], [Code], [Capacity], [Status], [CurrentOrderId], [ZoneId],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@tableId1, N' A01', 4, 0, NULL, @zoneId1,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	DECLARE @tableId2 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Table] (
		[Id], [Code], [Capacity], [Status], [CurrentOrderId], [ZoneId],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@tableId2, N' A02', 4, 0, NULL, @zoneId1,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- TABLES for ZONE 2
	DECLARE @tableId3 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Table] (
		[Id], [Code], [Capacity], [Status], [CurrentOrderId], [ZoneId],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@tableId3, N' B01', 4, 0, NULL, @zoneId2,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	DECLARE @tableId4 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Table] (
		[Id], [Code], [Capacity], [Status], [CurrentOrderId], [ZoneId],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@tableId4, N' B02', 4, 0, NULL, @zoneId2,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- TABLES for ZONE 3
	DECLARE @tableId5 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Table] (
		[Id], [Code], [Capacity], [Status], [CurrentOrderId], [ZoneId],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@tableId5, N' C01', 4, 0, NULL, @zoneId3,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	DECLARE @tableId6 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Table] (
		[Id], [Code], [Capacity], [Status], [CurrentOrderId], [ZoneId],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@tableId6, N' C02', 4, 0, NULL, @zoneId3,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

		DECLARE @tableId7 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Table] (
		[Id], [Code], [Capacity], [Status], [CurrentOrderId], [ZoneId],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@tableId7, N' D01', 4, 0, NULL, @zoneId4,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

		DECLARE @tableId8 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Table] (
		[Id], [Code], [Capacity], [Status], [CurrentOrderId], [ZoneId],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@tableId8, N' D02', 5, 0, NULL, @zoneId4,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

		DECLARE @tableId9 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Table] (
		[Id], [Code], [Capacity], [Status], [CurrentOrderId], [ZoneId],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@tableId9, N' D03', 5, 0, NULL, @zoneId4,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

		DECLARE @tableId10 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Table] (
		[Id], [Code], [Capacity], [Status], [CurrentOrderId], [ZoneId],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@tableId10, N' D04', 2, 0, NULL, @zoneId4,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);


		DECLARE @tableId11 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Table] (
		[Id], [Code], [Capacity], [Status], [CurrentOrderId], [ZoneId],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@tableId11, N' D05', 6, 0, NULL, @zoneId4,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);


		DECLARE @tableId12 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Table] (
		[Id], [Code], [Capacity], [Status], [CurrentOrderId], [ZoneId],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@tableId12, N' D06', 8, 0, NULL, @zoneId4,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);


		DECLARE @tableId13 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Table] (
		[Id], [Code], [Capacity], [Status], [CurrentOrderId], [ZoneId],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@tableId13, N' D07', 8, 0, NULL, @zoneId4,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

			DECLARE @tableId14 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Table] (
		[Id], [Code], [Capacity], [Status], [CurrentOrderId], [ZoneId],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@tableId14, N' W03', 10, 0, NULL, @zoneId5,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

			DECLARE @tableId15 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Table] (
		[Id], [Code], [Capacity], [Status], [CurrentOrderId], [ZoneId],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@tableId15, N' W04', 4, 0, NULL, @zoneId5,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);
	-- WORKSHOP 1
	DECLARE @workshopId1 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Workshop] (
		[Id], [Name], [Header], [Description], [Location], [Organizer], [HotLineContact],
		[WorkshopDate], [StartRegisterDate], [EndRegisterDate], [TotalFee],
		[MaxRegister], [MaxPizzaPerRegister], [MaxParticipantPerRegister], [WorkshopStatus],
		[totalRegisteredParticipant], [ZoneId], [ZoneName],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopId1, 
		N'Pizza Lovers Unite',
		N'Slice, Bake, Enjoy!',
		N'Pizza Lovers Unite - Slice, Bake, Enjoy!',
		N'Sẽ được cập nhật', N'Sẽ được cập nhật', N'Sẽ được cập nhật',
		DATEADD(DAY, 5, GETDATE()), DATEADD(DAY, 1, GETDATE()), DATEADD(DAY, 3, GETDATE()), 265000,
		3, 6, 2, 0,
		0, @zoneId5, N'Workshop',
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP FOOD DETAIL 1
	DECLARE @workshopFoodDetailId1 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [WorkshopFoodDetail] (
		[Id], [WorkshopId], [ProductId], [Name], [Price],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopFoodDetailId1,
		@workshopId1,
		@productId46,
		N'Pizza 4 loại nấm',
		185000,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);
	-- WORKSHOP FOOD DETAIL 2
	DECLARE @workshopFoodDetailId2 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [WorkshopFoodDetail] (
		[Id], [WorkshopId], [ProductId], [Name], [Price],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopFoodDetailId2,
		@workshopId1,
		@productId38,
		N'Pizza Bò với dầu tỏi',
		190000,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP FOOD DETAIL 3
	DECLARE @workshopFoodDetailId3 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [WorkshopFoodDetail] (
		[Id], [WorkshopId], [ProductId], [Name], [Price],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopFoodDetailId3,
		@workshopId1,
		@productId29,
		N'Pizza Phô mai Burrata Margherita với thịt nguội',
		198000,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP 2
	DECLARE @workshopId2 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Workshop] (
		[Id], [Name], [Header], [Description], [Location], [Organizer], [HotLineContact],
		[WorkshopDate], [StartRegisterDate], [EndRegisterDate], [TotalFee],
		[MaxRegister], [MaxPizzaPerRegister], [MaxParticipantPerRegister], [WorkshopStatus],
		[totalRegisteredParticipant], [ZoneId], [ZoneName],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopId2, 
		N'Pizza & Chill',
		N'Bake it ''til you make it!',
		N'Pizza & Chill - Bake it ''til you make it!',
		N'Sẽ được cập nhật', N'Sẽ được cập nhật', N'Sẽ được cập nhật',
		DATEADD(DAY, 5, GETDATE()), DATEADD(DAY, 1, GETDATE()), DATEADD(DAY, 3, GETDATE()), 225000,
		2, 4, 2, 0,
		0, @zoneId5, N'Workshop',
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP FOOD DETAIL 1 for WORKSHOP 2
	DECLARE @workshopFoodDetailId4 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [WorkshopFoodDetail] (
		[Id], [WorkshopId], [ProductId], [Name], [Price],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopFoodDetailId4,
		@workshopId2,
		@productId43,
		N'Pizza Bò kho',
		175000,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP FOOD DETAIL 2 for WORKSHOP 2
	DECLARE @workshopFoodDetailId5 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [WorkshopFoodDetail] (
		[Id], [WorkshopId], [ProductId], [Name], [Price],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopFoodDetailId5,
		@workshopId2,
		@productId34,
		N'Pizza Sashimi cá hồi kèm phô mai Ricotta và xốt hành',
		195000,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP FOOD DETAIL 3 for WORKSHOP 2
	DECLARE @workshopFoodDetailId6 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [WorkshopFoodDetail] (
		[Id], [WorkshopId], [ProductId], [Name], [Price],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopFoodDetailId6,
		@workshopId2,
		@productId27,
		N'Pizza Thịt nguội Ý Parma và rau rocket với xốt cà chua',
		180000,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP 3
	DECLARE @workshopId3 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Workshop] (
		[Id], [Name], [Header], [Description], [Location], [Organizer], [HotLineContact],
		[WorkshopDate], [StartRegisterDate], [EndRegisterDate], [TotalFee],
		[MaxRegister], [MaxPizzaPerRegister], [MaxParticipantPerRegister], [WorkshopStatus],
		[totalRegisteredParticipant], [ZoneId], [ZoneName],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopId3, 
		N'Pizza Craft Night',
		N'Shape. Sauce. Share.',
		N'Pizza Craft Night - Shape. Sauce. Share.',
		N'Sẽ được cập nhật', N'Sẽ được cập nhật', N'Sẽ được cập nhật',
		DATEADD(DAY, 5, GETDATE()), DATEADD(DAY, 1, GETDATE()), DATEADD(DAY, 3, GETDATE()), 295000,
		4, 8, 2, 0,
		0, @zoneId5, N'Workshop',
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP FOOD DETAIL 1 for WORKSHOP 3
	DECLARE @workshopFoodDetailId7 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [WorkshopFoodDetail] (
		[Id], [WorkshopId], [ProductId], [Name], [Price],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopFoodDetailId7,
		@workshopId3,
		@productId30,
		N'Pizza 3 loại phô mai nhà làm',
		200000,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP FOOD DETAIL 2 for WORKSHOP 3
	DECLARE @workshopFoodDetailId8 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [WorkshopFoodDetail] (
		[Id], [WorkshopId], [ProductId], [Name], [Price],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopFoodDetailId8,
		@workshopId3,
		@productId36,
		N'Pizza Tôm và xốt Mayonnaise',
		185000,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP FOOD DETAIL 3 for WORKSHOP 3
	DECLARE @workshopFoodDetailId9 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [WorkshopFoodDetail] (
		[Id], [WorkshopId], [ProductId], [Name], [Price],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopFoodDetailId9,
		@workshopId3,
		@productId28,
		N'Pizza Margherita với xúc xích Ý Milano và xúc xích cay Chorizo',
		200000,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP 4
	DECLARE @workshopId4 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Workshop] (
		[Id], [Name], [Header], [Description], [Location], [Organizer], [HotLineContact],
		[WorkshopDate], [StartRegisterDate], [EndRegisterDate], [TotalFee],
		[MaxRegister], [MaxPizzaPerRegister], [MaxParticipantPerRegister], [WorkshopStatus],
		[totalRegisteredParticipant], [ZoneId], [ZoneName],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopId4, 
		N'Family Pizza Day',
		N'Fun, Flour & Family!',
		N'Family Pizza Day - Fun, Flour & Family!',
		N'Sẽ được cập nhật', N'Sẽ được cập nhật', N'Sẽ được cập nhật',
		DATEADD(DAY, 5, GETDATE()), DATEADD(DAY, 1, GETDATE()), DATEADD(DAY, 3, GETDATE()), 210000,
		2, 4, 2, 0,
		0, @zoneId5, N'Workshop',
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP FOOD DETAIL 1 for WORKSHOP 4
	DECLARE @workshopFoodDetailId10 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [WorkshopFoodDetail] (
		[Id], [WorkshopId], [ProductId], [Name], [Price],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopFoodDetailId10,
		@workshopId4,
		@productId45,
		N'Pizza 5 loại phô mai nhà làm',
		180000,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP FOOD DETAIL 2 for WORKSHOP 4
	DECLARE @workshopFoodDetailId11 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [WorkshopFoodDetail] (
		[Id], [WorkshopId], [ProductId], [Name], [Price],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopFoodDetailId11,
		@workshopId4,
		@productId40,
		N'Pizza Cà ri gà cay',
		200000,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP FOOD DETAIL 3 for WORKSHOP 4
	DECLARE @workshopFoodDetailId12 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [WorkshopFoodDetail] (
		[Id], [WorkshopId], [ProductId], [Name], [Price],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopFoodDetailId12,
		@workshopId4,
		@productId32,
		N'Pizza Hải sản xốt cà chua cay với phô mai hun khói',
		190000,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP 5
	DECLARE @workshopId5 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Workshop] (
		[Id], [Name], [Header], [Description], [Location], [Organizer], [HotLineContact],
		[WorkshopDate], [StartRegisterDate], [EndRegisterDate], [TotalFee],
		[MaxRegister], [MaxPizzaPerRegister], [MaxParticipantPerRegister], [WorkshopStatus],
		[totalRegisteredParticipant], [ZoneId], [ZoneName],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopId5, 
		N'Pizza Pro Class',
		N'From Dough to Wow!',
		N'Pizza Pro Class - From Dough to Wow!',
		N'Sẽ được cập nhật', N'Sẽ được cập nhật', N'Sẽ được cập nhật',
		DATEADD(DAY, 5, GETDATE()), DATEADD(DAY, 1, GETDATE()), DATEADD(DAY, 3, GETDATE()), 275000,
		3, 6, 2, 0,
		0, @zoneId5, N'Workshop',
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP FOOD DETAIL 1 for WORKSHOP 5
	DECLARE @workshopFoodDetailId13 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [WorkshopFoodDetail] (
		[Id], [WorkshopId], [ProductId], [Name], [Price],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopFoodDetailId13,
		@workshopId5,
		@productId35,
		N'Pizza Cá hồi xốt kem miso',
		195000,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP FOOD DETAIL 2 for WORKSHOP 5
	DECLARE @workshopFoodDetailId14 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [WorkshopFoodDetail] (
		[Id], [WorkshopId], [ProductId], [Name], [Price],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopFoodDetailId14,
		@workshopId5,
		@productId41,
		N'Pizza Phô mai Camembert nhà làm và xốt nấm thịt nguội',
		190000,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP FOOD DETAIL 3 for WORKSHOP 5
	DECLARE @workshopFoodDetailId15 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [WorkshopFoodDetail] (
		[Id], [WorkshopId], [ProductId], [Name], [Price],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopFoodDetailId15,
		@workshopId5,
		@productId27,
		N'Pizza Thịt nguội Ý Parma và rau rocket với xốt cà chua',
		178000,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);


	-- WORKSHOP 6
	DECLARE @workshopId6 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Workshop] (
		[Id], [Name], [Header], [Description], [Location], [Organizer], [HotLineContact],
		[WorkshopDate], [StartRegisterDate], [EndRegisterDate], [TotalFee],
		[MaxRegister], [MaxPizzaPerRegister], [MaxParticipantPerRegister], [WorkshopStatus],
		[totalRegisteredParticipant], [ZoneId], [ZoneName],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopId6, 
		N'Artisan Pizza Lab',
		N'Create. Bake. Celebrate.',
		N'Artisan Pizza Lab - Create. Bake. Celebrate.',
		N'Sẽ được cập nhật', N'Sẽ được cập nhật', N'Sẽ được cập nhật',
		DATEADD(DAY, 5, GETDATE()), DATEADD(DAY, 1, GETDATE()), DATEADD(DAY, 3, GETDATE()), 250000,
		3, 6, 2, 0,
		0, @zoneId5, N'Workshop',
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP FOOD DETAIL 1 for WORKSHOP 6
	DECLARE @workshopFoodDetailId16 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [WorkshopFoodDetail] (
		[Id], [WorkshopId], [ProductId], [Name], [Price],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopFoodDetailId16,
		@workshopId6,
		@productId44,
		N'Pizza rau cải xoăn kèm phô mai Ricotta chanh nhà làm với xốt ô liu và nụ bạch hoa',
		200000,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP 7
	DECLARE @workshopId7 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Workshop] (
		[Id], [Name], [Header], [Description], [Location], [Organizer], [HotLineContact],
		[WorkshopDate], [StartRegisterDate], [EndRegisterDate], [TotalFee],
		[MaxRegister], [MaxPizzaPerRegister], [MaxParticipantPerRegister], [WorkshopStatus],
		[totalRegisteredParticipant], [ZoneId], [ZoneName],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopId7, 
		N'Kids Pizza Party',
		N'Little Hands, Big Pizzas!',
		N'Kids Pizza Party - Little Hands, Big Pizzas!',
		N'Sẽ được cập nhật', N'Sẽ được cập nhật', N'Sẽ được cập nhật',
		DATEADD(DAY, 5, GETDATE()), DATEADD(DAY, 1, GETDATE()), DATEADD(DAY, 3, GETDATE()), 220000,
		2, 4, 2, 0,
		0, @zoneId5, N'Workshop',
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP FOOD DETAIL 1 for WORKSHOP 7
	DECLARE @workshopFoodDetailId17 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [WorkshopFoodDetail] (
		[Id], [WorkshopId], [ProductId], [Name], [Price],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopFoodDetailId17,
		@workshopId7,
		@productId37,
		N'Pizza Thịt bò cay kiểu Kebab',
		175000,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP FOOD DETAIL 2 for WORKSHOP 7
	DECLARE @workshopFoodDetailId18 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [WorkshopFoodDetail] (
		[Id], [WorkshopId], [ProductId], [Name], [Price],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopFoodDetailId18,
		@workshopId7,
		@productId37,
		N'Pizza Thịt bò cay kiểu Kebab',
		180000,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP FOOD DETAIL 3 for WORKSHOP 7
	DECLARE @workshopFoodDetailId19 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [WorkshopFoodDetail] (
		[Id], [WorkshopId], [ProductId], [Name], [Price],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopFoodDetailId19,
		@workshopId7,
		@productId37,
		N'Pizza Thịt bò cay kiểu Kebab',
		170000,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP 8
	DECLARE @workshopId8 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Workshop] (
		[Id], [Name], [Header], [Description], [Location], [Organizer], [HotLineContact],
		[WorkshopDate], [StartRegisterDate], [EndRegisterDate], [TotalFee],
		[MaxRegister], [MaxPizzaPerRegister], [MaxParticipantPerRegister], [WorkshopStatus],
		[totalRegisteredParticipant], [ZoneId], [ZoneName],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopId8, 
		N'Evening Pizza Escape',
		N'Unwind. Slice. Repeat.',
		N'Evening Pizza Escape - Unwind. Slice. Repeat.',
		N'Sẽ được cập nhật', N'Sẽ được cập nhật', N'Sẽ được cập nhật',
		DATEADD(DAY, 5, GETDATE()), DATEADD(DAY, 1, GETDATE()), DATEADD(DAY, 3, GETDATE()), 240000,
		3, 6, 2, 0,
		0, @zoneId5, N'Workshop',
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP FOOD DETAIL 1 for WORKSHOP 8
	DECLARE @workshopFoodDetailId20 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [WorkshopFoodDetail] (
		[Id], [WorkshopId], [ProductId], [Name], [Price],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopFoodDetailId20,
		@workshopId8,
		@productId37,
		N'Pizza Thịt bò cay kiểu Kebab',
		185000,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP 9
	DECLARE @workshopId9 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Workshop] (
		[Id], [Name], [Header], [Description], [Location], [Organizer], [HotLineContact],
		[WorkshopDate], [StartRegisterDate], [EndRegisterDate], [TotalFee],
		[MaxRegister], [MaxPizzaPerRegister], [MaxParticipantPerRegister], [WorkshopStatus],
		[totalRegisteredParticipant], [ZoneId], [ZoneName],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopId9, 
		N'Pizza Masters Session',
		N'Master the Crust, Own the Oven',
		N'Pizza Masters Session - Master the Crust, Own the Oven',
		N'Sẽ được cập nhật', N'Sẽ được cập nhật', N'Sẽ được cập nhật',
		DATEADD(DAY, 5, GETDATE()), DATEADD(DAY, 1, GETDATE()), DATEADD(DAY, 3, GETDATE()), 285000,
		4, 8, 2, 0,
		0, @zoneId3, N'Zone 3',
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP FOOD DETAIL 1 for WORKSHOP 9
	DECLARE @workshopFoodDetailId21 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [WorkshopFoodDetail] (
		[Id], [WorkshopId], [ProductId], [Name], [Price],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopFoodDetailId21,
		@workshopId9,
		@productId32,
		N'Pizza Hải sản xốt cà chua cay với phô mai hun khói',
		190000,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP 10
	DECLARE @workshopId10 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [Workshop] (
		[Id], [Name], [Header], [Description], [Location], [Organizer], [HotLineContact],
		[WorkshopDate], [StartRegisterDate], [EndRegisterDate], [TotalFee],
		[MaxRegister], [MaxPizzaPerRegister], [MaxParticipantPerRegister], [WorkshopStatus],
		[totalRegisteredParticipant], [ZoneId], [ZoneName],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopId10, 
		N'Late Night Pizza Jam',
		N'Knead. Top. Groove.',
		N'Late Night Pizza Jam - Knead. Top. Groove.',
		N'Sẽ được cập nhật', N'Sẽ được cập nhật', N'Sẽ được cập nhật',
		DATEADD(DAY, 5, GETDATE()), DATEADD(DAY, 1, GETDATE()), DATEADD(DAY, 3, GETDATE()), 230000,
		3, 6, 2, 0,
		0, @zoneId6, N'Workshop',
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

	-- WORKSHOP FOOD DETAIL 1 for WORKSHOP 10
	DECLARE @workshopFoodDetailId22 UNIQUEIDENTIFIER = NEWID();
	INSERT INTO [WorkshopFoodDetail] (
		[Id], [WorkshopId], [ProductId], [Name], [Price],
		[CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy],
		[IsDeleted], [DeletedAt], [DeletedBy]
	)
	VALUES (
		@workshopFoodDetailId22,
		@workshopId10,
		@productId32,
		N'Pizza Hải sản xốt cà chua cay với phô mai hun khói',
		195000,
		GETDATE(), NULL, N'Admin', NULL,
		0, NULL, NULL
	);

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
	(NEWID(), N'Nguyễn Văn An', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '58162CDE-E9ED-498D-26F5-08DD759A0482'),
	(NEWID(), N'Lê Thị Hoa', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '9F251669-2B22-4D5D-26F6-08DD759A0482'),
	(NEWID(), N'Trần Minh Tuấn', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '44249BB9-490E-4475-26F7-08DD759A0482'),
	(NEWID(), N'Phạm Thị Hương', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'FA4090B7-1798-4BF6-26F8-08DD759A0482'),
	(NEWID(), N'Võ Thành Nhân', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '97E200FD-18C3-4A83-26F9-08DD759A0482'),
	(NEWID(), N'Đỗ Thị Mai', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '47EF30F4-D765-4B50-26FA-08DD759A0482'),
	(NEWID(), N'Hoàng Văn Dũng', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '07E4FE0B-9E81-4207-26FB-08DD759A0482'),
	(NEWID(), N'Bùi Thị Lan', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'F5805027-0058-4D29-26FC-08DD759A0482'),
	(NEWID(), N'Tạ Minh Quân', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '8088AF31-A752-4061-26FD-08DD759A0482'),
	(NEWID(), N'Ngô Thị Kim', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '8E20D6DF-1440-4D5E-26FE-08DD759A0482'),
	(NEWID(), N'Huỳnh Văn Hòa', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '8ACA2EF4-E611-4CD1-26FF-08DD759A0482'),
	(NEWID(), N'Cao Thị Tuyết', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '0CA7A9B7-2DE2-4988-2700-08DD759A0482'),
	(NEWID(), N'Đinh Minh Khang', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '461D0957-AA4D-4A05-2701-08DD759A0482'),
	(NEWID(), N'Mai Thị Lệ', '', '', 0, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'A301A7C0-C7E0-4FA9-2702-08DD759A0482'),

	--Staff PartTime
	(NEWID(), N'Trương Thị Ngọc', '', '', 1, 0, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '8E8FFC7F-3EAA-4EA2-2703-08DD759A0482'),
	(NEWID(), N'Lý Văn Khôi', '', '', 1, 0, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '3263F3B7-026F-45F9-2704-08DD759A0482'),
	(NEWID(), N'Huỳnh Thị Bích', '', '', 1, 0, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '35651B8B-BC39-42BD-2705-08DD759A0482'),
	(NEWID(), N'Nguyễn Minh Phúc', '', '', 1, 0, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '4DB79B84-DA2B-44C5-2706-08DD759A0482'),
	(NEWID(), N'Phan Thị Thảo', '', '', 1, 0, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '195810B5-0028-4629-DB36-08DD75BBA155'),
	(NEWID(), N'Vũ Đức Huy', '', '', 1, 0, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '44BA2CF7-060A-4DC0-DB37-08DD75BBA155'),


	--Chef FullTime
	(NEWID(), N'Nguyễn Văn Cường', '', '', 2, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '185A6348-240C-4999-2709-08DD759A0482'),
	(NEWID(), N'Trần Thị Mỹ Duyên', '', '', 2, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '5BCB3726-81B3-4CE2-270A-08DD759A0482'),
	(NEWID(), N'Phạm Minh Khoa', '', '', 2, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '8B0C94CA-1A98-4BA4-270B-08DD759A0482'),
	(NEWID(), N'Lê Thị Tuyết Mai', '', '', 2, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '90C673BF-F3FF-4137-270C-08DD759A0482'),
	(NEWID(), N'Đoàn Văn Tài', '', '', 2, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '34871E55-F0DB-4BC8-270D-08DD759A0482'),
	(NEWID(), N'Bùi Thị Thanh Tâm', '', '', 2, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '56138E89-3841-4038-270E-08DD759A0482'),
	(NEWID(), N'Võ Hữu Lộc', '', '', 2, 1, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '2B891D0C-4E2A-4952-270F-08DD759A0482'),


	--Chef PartTime
	(NEWID(), N'Tống Thị Nguyệt', '', '', 2, 0, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '073CC470-FBDA-445A-2710-08DD759A0482'),
	(NEWID(), N'Kiều Văn Lâm', '', '', 2, 0, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, '25B0D6DF-6FF8-4B9B-2711-08DD759A0482'),
	(NEWID(), N'Đặng Thị Hồng Nhung', '', '', 2, 0, GETDATE(), NULL, 'Admin', NULL, 0, NULL, NULL, 'A435ED4D-DBA9-44CA-2712-08DD759A0482');

	--INSERT INTO AdditionalFee 
	--([Id], [Name], [Description], [Value], [OrderId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [IsDeleted], [DeletedAt], [DeletedBy]) 
	--VALUES 
	--(NEWID(), N'Phí Workshop', N'Phí phụ thu khi tham gia workshop', 20000.00,  GETDATE(), NULL, 'undefined', NULL, 0, NULL, NULL),

    COMMIT;
    PRINT N'INSERT DATA SUCCESS.';
END TRY
BEGIN CATCH
    ROLLBACK;
    PRINT N'ERROR: ' + ERROR_MESSAGE();
END CATCH;
GO
