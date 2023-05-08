USE [VinylShop]
GO

DECLARE @userProfile TABLE (Id INT,
    Bio NVARCHAR(MAX),
    Location NVARCHAR(255),
    Birthday DATE,
    Gender INT,
    UserId INT)

DECLARE @i INT = 1
WHILE @i <= 1000
BEGIN
    DECLARE @userId INT = @i

    INSERT INTO @userProfile
        (Id, Bio, Location, Birthday, Gender, UserId)
    VALUES
        (@i, 'Bio ' + CAST(@i AS NVARCHAR(10)), 'Location ' + CAST(@i AS NVARCHAR(10)), DATEADD(day, -FLOOR(RAND()*(365*80-365*18+1))+365*18, GETDATE()), FLOOR(RAND()*(2-0+1))+0, @userId)

    SET @i = @i + 1
END

INSERT INTO UserProfiles
    (Id, Bio, Location, Birthday, Gender, UserId)
SELECT Id, Bio, Location, Birthday, Gender, UserId
FROM @userProfile
