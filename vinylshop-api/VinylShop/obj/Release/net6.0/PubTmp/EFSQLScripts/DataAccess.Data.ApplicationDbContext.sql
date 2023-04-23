IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230306172550_initMigration')
BEGIN
    CREATE TABLE [Artists] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        [Age] int NULL,
        [RecordLabelId] int NULL,
        CONSTRAINT [PK_Artists] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230306172550_initMigration')
BEGIN
    CREATE TABLE [Bands] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [StartDate] datetime2 NULL,
        [RecordLabelId] int NULL,
        CONSTRAINT [PK_Bands] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230306172550_initMigration')
BEGIN
    CREATE TABLE [Contracts] (
        [Id] int NOT NULL IDENTITY,
        [ArtistId] int NOT NULL,
        [BandId] int NULL,
        [RecordLabelId] int NULL,
        CONSTRAINT [PK_Contracts] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230306172550_initMigration')
BEGIN
    CREATE TABLE [RecordLabels] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [Gendre] int NULL,
        [ArtistId] int NOT NULL,
        [BandId] int NULL,
        CONSTRAINT [PK_RecordLabels] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230306172550_initMigration')
BEGIN
    CREATE TABLE [Shops] (
        [Id] int NOT NULL IDENTITY,
        [Town] nvarchar(max) NULL,
        [Address] nvarchar(max) NULL,
        [VinylId] int NOT NULL,
        CONSTRAINT [PK_Shops] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230306172550_initMigration')
BEGIN
    CREATE TABLE [Songs] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Lyrics] nvarchar(max) NULL,
        [RealiseDate] datetime2 NULL,
        [BandId] int NULL,
        [ArtistId] int NULL,
        CONSTRAINT [PK_Songs] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230306172550_initMigration')
BEGIN
    CREATE TABLE [Vinyls] (
        [Id] int NOT NULL IDENTITY,
        [Edition] nvarchar(max) NULL,
        [SongId] int NOT NULL,
        CONSTRAINT [PK_Vinyls] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230306172550_initMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230306172550_initMigration', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230306181935_goodMigration')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[RecordLabels]') AND [c].[name] = N'ArtistId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [RecordLabels] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [RecordLabels] DROP COLUMN [ArtistId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230306181935_goodMigration')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[RecordLabels]') AND [c].[name] = N'BandId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [RecordLabels] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [RecordLabels] DROP COLUMN [BandId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230306181935_goodMigration')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bands]') AND [c].[name] = N'RecordLabelId');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Bands] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Bands] DROP COLUMN [RecordLabelId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230306181935_goodMigration')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Artists]') AND [c].[name] = N'RecordLabelId');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Artists] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Artists] DROP COLUMN [RecordLabelId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230306181935_goodMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230306181935_goodMigration', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230307065548_stockAndForeignKeyMigration')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Shops]') AND [c].[name] = N'VinylId');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Shops] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Shops] DROP COLUMN [VinylId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230307065548_stockAndForeignKeyMigration')
BEGIN
    CREATE TABLE [Stocks] (
        [Id] int NOT NULL IDENTITY,
        [AvailableVinyls] int NOT NULL,
        [VinylId] int NOT NULL,
        [ShopId] int NOT NULL,
        CONSTRAINT [PK_Stocks] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230307065548_stockAndForeignKeyMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230307065548_stockAndForeignKeyMigration', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311140606_HopeThereAreRelationships')
BEGIN
    CREATE INDEX [IX_Vinyls_SongId] ON [Vinyls] ([SongId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311140606_HopeThereAreRelationships')
BEGIN
    CREATE INDEX [IX_Stocks_ShopId] ON [Stocks] ([ShopId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311140606_HopeThereAreRelationships')
BEGIN
    CREATE INDEX [IX_Stocks_VinylId] ON [Stocks] ([VinylId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311140606_HopeThereAreRelationships')
BEGIN
    CREATE INDEX [IX_Songs_ArtistId] ON [Songs] ([ArtistId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311140606_HopeThereAreRelationships')
BEGIN
    CREATE INDEX [IX_Songs_BandId] ON [Songs] ([BandId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311140606_HopeThereAreRelationships')
BEGIN
    CREATE INDEX [IX_Contracts_ArtistId] ON [Contracts] ([ArtistId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311140606_HopeThereAreRelationships')
BEGIN
    CREATE INDEX [IX_Contracts_BandId] ON [Contracts] ([BandId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311140606_HopeThereAreRelationships')
BEGIN
    CREATE INDEX [IX_Contracts_RecordLabelId] ON [Contracts] ([RecordLabelId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311140606_HopeThereAreRelationships')
BEGIN
    ALTER TABLE [Contracts] ADD CONSTRAINT [FK_Contracts_Artists_ArtistId] FOREIGN KEY ([ArtistId]) REFERENCES [Artists] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311140606_HopeThereAreRelationships')
BEGIN
    ALTER TABLE [Contracts] ADD CONSTRAINT [FK_Contracts_Bands_BandId] FOREIGN KEY ([BandId]) REFERENCES [Bands] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311140606_HopeThereAreRelationships')
BEGIN
    ALTER TABLE [Contracts] ADD CONSTRAINT [FK_Contracts_RecordLabels_RecordLabelId] FOREIGN KEY ([RecordLabelId]) REFERENCES [RecordLabels] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311140606_HopeThereAreRelationships')
BEGIN
    ALTER TABLE [Songs] ADD CONSTRAINT [FK_Songs_Artists_ArtistId] FOREIGN KEY ([ArtistId]) REFERENCES [Artists] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311140606_HopeThereAreRelationships')
BEGIN
    ALTER TABLE [Songs] ADD CONSTRAINT [FK_Songs_Bands_BandId] FOREIGN KEY ([BandId]) REFERENCES [Bands] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311140606_HopeThereAreRelationships')
BEGIN
    ALTER TABLE [Stocks] ADD CONSTRAINT [FK_Stocks_Shops_ShopId] FOREIGN KEY ([ShopId]) REFERENCES [Shops] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311140606_HopeThereAreRelationships')
BEGIN
    ALTER TABLE [Stocks] ADD CONSTRAINT [FK_Stocks_Vinyls_VinylId] FOREIGN KEY ([VinylId]) REFERENCES [Vinyls] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311140606_HopeThereAreRelationships')
BEGIN
    ALTER TABLE [Vinyls] ADD CONSTRAINT [FK_Vinyls_Songs_SongId] FOREIGN KEY ([SongId]) REFERENCES [Songs] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311140606_HopeThereAreRelationships')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230311140606_HopeThereAreRelationships', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311203658_newFieldsToContractEntity')
BEGIN
    ALTER TABLE [Contracts] ADD [Duration] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311203658_newFieldsToContractEntity')
BEGIN
    ALTER TABLE [Contracts] ADD [StartDate] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311203658_newFieldsToContractEntity')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230311203658_newFieldsToContractEntity', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230313170254_stokEntityModified')
BEGIN
    ALTER TABLE [Stocks] ADD [Price] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230313170254_stokEntityModified')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230313170254_stokEntityModified', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230314064806_addAttributesToEntities')
BEGIN
    ALTER TABLE [Vinyls] ADD [Condition] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230314064806_addAttributesToEntities')
BEGIN
    ALTER TABLE [Vinyls] ADD [Durablility] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230314064806_addAttributesToEntities')
BEGIN
    ALTER TABLE [Vinyls] ADD [Groove] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230314064806_addAttributesToEntities')
BEGIN
    ALTER TABLE [Vinyls] ADD [Material] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230314064806_addAttributesToEntities')
BEGIN
    ALTER TABLE [Vinyls] ADD [Size] bigint NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230314064806_addAttributesToEntities')
BEGIN
    ALTER TABLE [Vinyls] ADD [Speed] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230314064806_addAttributesToEntities')
BEGIN
    ALTER TABLE [Bands] ADD [NumberOfAwards] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230314064806_addAttributesToEntities')
BEGIN
    ALTER TABLE [Bands] ADD [NumberOfMembers] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230314064806_addAttributesToEntities')
BEGIN
    ALTER TABLE [Artists] ADD [ActiveYears] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230314064806_addAttributesToEntities')
BEGIN
    ALTER TABLE [Artists] ADD [Nationality] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230314064806_addAttributesToEntities')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230314064806_addAttributesToEntities', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317143506_changeSongToAlbum')
BEGIN
    CREATE TABLE [Vinyls] (
        [Id] int NOT NULL IDENTITY,
        [Edition] nvarchar(max) NULL,
        [AlbumId] int NOT NULL,
        CONSTRAINT [PK_Vinyls] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317143506_changeSongToAlbum')
BEGIN
    ALTER TABLE [Vinyls] ADD [Condition] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317143506_changeSongToAlbum')
BEGIN
    ALTER TABLE [Vinyls] ADD [Durablility] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317143506_changeSongToAlbum')
BEGIN
    ALTER TABLE [Vinyls] ADD [Groove] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317143506_changeSongToAlbum')
BEGIN
    ALTER TABLE [Vinyls] ADD [Material] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317143506_changeSongToAlbum')
BEGIN
    ALTER TABLE [Vinyls] ADD [Size] bigint NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317143506_changeSongToAlbum')
BEGIN
    ALTER TABLE [Vinyls] ADD [Speed] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317143506_changeSongToAlbum')
BEGIN
    CREATE TABLE [Albums] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Lyrics] nvarchar(max) NULL,
        [RealiseDate] datetime2 NULL,
        [BandId] int NULL,
        [ArtistId] int NULL,
        CONSTRAINT [PK_Albums] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Albums_Artists_ArtistId] FOREIGN KEY ([ArtistId]) REFERENCES [Artists] ([Id]),
        CONSTRAINT [FK_Albums_Bands_BandId] FOREIGN KEY ([BandId]) REFERENCES [Bands] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317143506_changeSongToAlbum')
BEGIN
    CREATE INDEX [IX_Albums_ArtistId] ON [Albums] ([ArtistId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317143506_changeSongToAlbum')
BEGIN
    CREATE INDEX [IX_Albums_BandId] ON [Albums] ([BandId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317143506_changeSongToAlbum')
BEGIN
    ALTER TABLE [Vinyls] ADD CONSTRAINT [FK_Vinyls_Albums_AlbumId] FOREIGN KEY ([AlbumId]) REFERENCES [Albums] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317143506_changeSongToAlbum')
BEGIN
    CREATE TABLE [Stocks] (
        [Id] int NOT NULL IDENTITY,
        [AvailableVinyls] int NOT NULL,
        [VinylId] int NOT NULL,
        [ShopId] int NOT NULL,
        CONSTRAINT [PK_Stocks] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317143506_changeSongToAlbum')
BEGIN
    CREATE INDEX [IX_Stocks_ShopId] ON [Stocks] ([ShopId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317143506_changeSongToAlbum')
BEGIN
    CREATE INDEX [IX_Stocks_VinylId] ON [Stocks] ([VinylId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317143506_changeSongToAlbum')
BEGIN
    ALTER TABLE [Stocks] ADD [Price] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230317143506_changeSongToAlbum')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230317143506_changeSongToAlbum', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230319133104_deletedShopAndStocks')
BEGIN
    DROP TABLE [Stocks];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230319133104_deletedShopAndStocks')
BEGIN
    DROP TABLE [Shops];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230319133104_deletedShopAndStocks')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230319133104_deletedShopAndStocks', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230319133529_addShopAndStocksBack')
BEGIN
    CREATE TABLE [Shops] (
        [Id] int NOT NULL IDENTITY,
        [Town] nvarchar(max) NULL,
        [Address] nvarchar(max) NULL,
        CONSTRAINT [PK_Shops] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230319133529_addShopAndStocksBack')
BEGIN
    CREATE TABLE [Stocks] (
        [Id] int NOT NULL IDENTITY,
        [AvailableVinyls] int NOT NULL,
        [Price] int NOT NULL,
        [ShopId] int NOT NULL,
        [VinylId] int NOT NULL,
        CONSTRAINT [PK_Stocks] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Stocks_Shops_ShopId] FOREIGN KEY ([ShopId]) REFERENCES [Shops] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Stocks_Vinyls_VinylId] FOREIGN KEY ([VinylId]) REFERENCES [Vinyls] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230319133529_addShopAndStocksBack')
BEGIN
    CREATE INDEX [IX_Stocks_ShopId] ON [Stocks] ([ShopId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230319133529_addShopAndStocksBack')
BEGIN
    CREATE INDEX [IX_Stocks_VinylId] ON [Stocks] ([VinylId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230319133529_addShopAndStocksBack')
BEGIN
    ALTER TABLE [Stocks] ADD CONSTRAINT [FK_Stocks_Shops_ShopId] FOREIGN KEY ([ShopId]) REFERENCES [Shops] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230319133529_addShopAndStocksBack')
BEGIN
    ALTER TABLE [Stocks] ADD CONSTRAINT [FK_Stocks_Vinyls_VinylId] FOREIGN KEY ([VinylId]) REFERENCES [Vinyls] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230319133529_addShopAndStocksBack')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230319133529_addShopAndStocksBack', N'7.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230327230929_validatorDataMigration')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Shops]') AND [c].[name] = N'Address');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Shops] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Shops] ALTER COLUMN [Address] nvarchar(100) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230327230929_validatorDataMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230327230929_validatorDataMigration', N'7.0.3');
END;
GO

COMMIT;
GO

