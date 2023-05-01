USE [VinylShop]
GO

-- Drop constraints
ALTER TABLE Albums DROP CONSTRAINT FK_Albums_Artists_ArtistId;
ALTER TABLE Vinyls DROP CONSTRAINT FK_Vinyls_Albums_AlbumId;
ALTER TABLE Stocks DROP CONSTRAINT FK_Stocks_Vinyls_VinylId;
GO

TRUNCATE TABLE Artists
TRUNCATE TABLE Albums
TRUNCATE TABLE Shops
TRUNCATE TABLE Vinyls
TRUNCATE TABLE Stocks
GO

-- BULK INSERT data from CSV files
BULK INSERT Artists
FROM 'E:/Folder3/database-helper/artists.csv'
WITH (FORMAT = 'CSV', FIRSTROW = 1, FIELDTERMINATOR = ',', ROWTERMINATOR = '\n');
GO

BULK INSERT Albums
FROM 'E:/Folder3/database-helper/albums.csv'
WITH (FORMAT = 'CSV', FIRSTROW = 1, FIELDTERMINATOR = ',', ROWTERMINATOR = '\n');
GO

BULK INSERT Shops
FROM 'E:/Folder3/database-helper/shops.csv'
WITH (FORMAT = 'CSV', FIRSTROW = 1, FIELDTERMINATOR = ',', ROWTERMINATOR = '\n');
GO

BULK INSERT Vinyls
FROM 'E:/Folder3/database-helper/vinyls.csv'
WITH (FORMAT = 'CSV', FIRSTROW = 1, FIELDTERMINATOR = ',', ROWTERMINATOR = '\n');
GO

BULK INSERT Stocks
FROM 'E:/Folder3/database-helper/stocks.csv'
WITH (FORMAT = 'CSV', FIRSTROW = 1, FIELDTERMINATOR = ',', ROWTERMINATOR = '\n');
GO

-- Recreate constraints
ALTER TABLE Albums
ADD CONSTRAINT FK_Albums_Artists_ArtistId FOREIGN KEY (ArtistId) REFERENCES Artists (Id);

ALTER TABLE Vinyls
ADD CONSTRAINT FK_Vinyls_Albums_AlbumId FOREIGN KEY (AlbumId) REFERENCES Albums (Id);

ALTER TABLE Stocks
ADD CONSTRAINT FK_Stocks_Vinyls_VinylId FOREIGN KEY (VinylId) REFERENCES Vinyls (Id);
GO

SELECT COUNT(*) AS 'Artists'
FROM Artists
SELECT COUNT(*) AS 'Albums'
FROM Albums
SELECT COUNT(*) AS 'Shops'
FROM Shops
SELECT COUNT(*) AS 'Vinyls'
FROM Vinyls
SELECT COUNT(*) AS 'Stocks'
FROM Stocks