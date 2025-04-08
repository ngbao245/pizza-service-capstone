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
	   (@ingCarotHam, N'Bé Cà Rốt Đảm Đang', N'Thịt bò ướp gia vị cay kiểu Trung Đông, nướng lửa than', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingKale, N'Cải nè', N'Cá hồi tươi lát mỏng', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingCapers, N'Nụ Bạch Hoa', N'Tôm tươi bóc vỏ', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingOliveSauce, N'Dầu ớt trộn ô liu ', N'Mực cắt khoanh hấp dẫn', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingMushroomEnoki, N' Nấm mập', N'Mực cắt khoanh hấp dẫn', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingMushroomShiitake, N'Nấm to', N'Mực cắt khoanh hấp dẫn', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingMushroomButton, N'Nấm to hơn', N'Mực cắt khoanh hấp dẫn', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
	   (@ingMushroomPortobello, N'Nấm nhỏ xíu', N'Mực cắt khoanh hấp dẫn', GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL),
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
	(@productId40, N'Pizza Cà ri gà cay xé quần', N'Mô tả đang cập nhật', 218000, NULL, 'https://pizza4ps.com/wp-content/uploads/2023/08/DSC04135.jpg', NULL, @pizzaCategoryId, 1, GETDATE(), NULL, N'Admin', NULL, 0, NULL, NULL);

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
