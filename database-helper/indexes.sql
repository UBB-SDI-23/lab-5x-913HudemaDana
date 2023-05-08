use [VinylShop]
GO

CREATE INDEX idx_Vinyl_Size ON Vinyls (Size);

CREATE INDEX idx_Vinyl_AlbumId ON Vinyls (AlbumId);

CREATE INDEX idx_Album_ArtistId ON Albums (ArtistId);

CREATE INDEX idx_Album_RealiseDate ON Albums (RealiseDate);

CREATE INDEX idx_Artist_ActiveYears 
ON Artists (ActiveYears);

CREATE INDEX idx_stock_available_vinyls ON Stocks(AvailableVinyls);

CREATE INDEX idx_stock_shop_id ON Stocks(ShopId);

CREATE INDEX idx_stock_vinyl_id ON Stocks(VinylId);

CREATE INDEX idx_stock_ShopVinyl ON Stocks (ShopId, VinylId);

CREATE INDEX idx_shop_address ON Shops(Address);
GO
