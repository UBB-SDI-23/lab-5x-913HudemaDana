
USE [VinylShop]
GO

DECLARE @i int = 1
WHILE (@i <= 1000)
BEGIN
    DECLARE @username varchar(50) = CONCAT('user', @i)
    DECLARE @password varchar(50) = 'password123'
    DECLARE @email varchar(50) = CONCAT(@username, '@example.com')

    INSERT INTO Users
        (Username, Password, Email, Role)
    VALUES
        (@username, @password, @email,
            (SELECT ABS(CAST(NEWID() AS binary(6)) % 4)))

    SET @i = @i + 1
END
