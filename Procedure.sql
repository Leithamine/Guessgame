Use GuessGameDB;
go
----------------------------------------------------------------------------------------------
-- Erstellt eine gespeicherte Prozedur mit dem Namen DailyGameUsageMonths
-- und nimmt drei Parameter: UserID, Monat und Jahr
CREATE PROCEDURE DailyGameUsageMonths @UserID INT, @month INT, @year INT
AS
BEGIN
    -- Wählt die Anzahl von gespielten Runden, den Wochentag und das Datum
    SELECT 
        COUNT(gs.GameStatID) as PlayedRounds,  -- Zählt die Anzahl der gespielten Runden
        DATENAME(WEEKDAY, gs.GameDate) as DayOfWeek,  -- Holt den Wochentag des Spieldatums
        gs.GameDate as Date  -- Holt das Spieldatum
    FROM 
        Users u  
    JOIN 
        GameStats gs ON u.UserID = gs.UserID  -- Verbindet Users mit GameStats über UserID
    WHERE 
    -- Filtert nach UserID Monat und Jahr
        u.UserID = @UserID  
        AND DATEPART(mm, gs.GameDate) = @month  
        AND DATEPART(yyyy, gs.GameDate) = @year 
    GROUP BY 
     -- Gruppiert nach Wochentag und Spieldatum
        DATENAME(WEEKDAY, gs.GameDate), 
        gs.GameDate
    ORDER BY 
        gs.GameDate  -- Sortiert nach Spieldatum
END;

EXEC DailyGameUsageMonths 41, 9, 2023;
GO
--------------------------------------------------------------------------------------------
-- Erstellt eine gespeicherte Prozedur mit dem Namen MonthlyGameUsage
-- und nimmt zwei Parameter: UserID und Jahr
CREATE PROCEDURE MonthlyGameUsage @UserID INT, @year INT
AS
BEGIN
    -- Wählt die Anzahl der gespielten Spiele und den Monat
    SELECT 
        COUNT(gs.GameStatID) as GamesPlayed,  -- Zählt die Anzahl der gespielten Spiele
        DATENAME(MONTH, gs.GameDate) as GameMonth  -- Holt den Monat des Spieldatums
    FROM 
        Users u
    JOIN 
        GameStats gs ON u.UserID = gs.UserID  -- Verbindet Users mit GameStats über UserID
    WHERE 
        u.UserID = @UserID  -- Filtert nach dem UserID und Jahr
        AND DATEPART(yyyy, gs.GameDate) = @year
    GROUP BY 
        DATENAME(MONTH, gs.GameDate),  -- Gruppiert nach Monat und auch nach Monatsnummer
        DATEPART(mm, gs.GameDate),
        DATEPART(mm, gs.GameDate);  -- Sortiert nach Monatsnummer
END;

    EXEC MonthlyGameUsage 33, 2023;
GO

--------------------------------------------------------------------------------------------
CREATE PROCEDURE MonthlyScoreDevelopment @UserID INT, @month INT, @year INT
AS
BEGIN
    SELECT 
        MAX(gs.Highscore) as HighScore,
        DATENAME(WEEKDAY, MIN(gs.GameDate)) as StartDayOfWeek,
        MIN(gs.GameDate) as WeekStartDate
    FROM 
        Users u
    JOIN 
        GameStats gs ON u.UserID = gs.UserID
    WHERE 
        u.UserID = @UserID
        AND DATEPART(mm, gs.GameDate) = @month
        AND DATEPART(yyyy, gs.GameDate) = @year
    GROUP BY 
        DATEPART(wk, gs.GameDate)
    ORDER BY 
        DATEPART(wk, gs.GameDate);
END;

    EXEC MonthlyScoreDevelopment 33, 9, 2023;
GO

----------------------------------------------------------------------------------
CREATE PROCEDURE YearlyScoreDevelopment @UserID INT, @year INT
AS
SELECT 
    MAX(gs.Highscore) as HighScore,
    DATENAME(MONTH, gs.GameDate) as GameMonth
FROM 
    Users u
JOIN 
    GameStats gs ON u.UserID = gs.UserID
WHERE 
    u.UserID = @UserID
    AND DATEPART(yyyy, gs.GameDate) = @year
GROUP BY 
    DATENAME(MONTH, gs.GameDate),
    DATEPART(mm, gs.GameDate)
ORDER BY 
    DATEPART(mm, gs.GameDate);

        EXEC YearlyScoreDevelopment 33, 2023;

GO

-------------------------------------------------------------------------------------------------
CREATE PROCEDURE WeeklyTriesAndHintsSummary @UserID INT, @month INT, @year INT
AS
BEGIN
    SELECT 
        SUM(gr.Tries) as TotalTries,
        SUM(gr.UsedHints) as TotalHints,
        DATENAME(WEEKDAY, MIN(gs.GameDate)) as StartDayOfWeek,
        DATEPART(wk, gs.GameDate) as GameWeek,
        MIN(gs.GameDate) as WeekStartDate,
        MAX(gs.GameDate) as WeekEndDate
    FROM 
        GameRounds gr
    JOIN 
        GameStats gs ON gr.GameStatID = gs.GameStatID
    WHERE 
        gs.UserID = @UserID
        AND DATEPART(mm, gs.GameDate) = @month
        AND DATEPART(yyyy, gs.GameDate) = @year
    GROUP BY 
        DATEPART(wk, gs.GameDate)
    ORDER BY 
        DATEPART(wk, gs.GameDate);
END;

EXEC WeeklyTriesAndHintsSummary 33, 9, 2023;
GO


-----------------------------------------------------------------------------------------
CREATE PROCEDURE MonthlyTriesAndHintsSummary @UserID INT, @year INT
AS
SELECT 
    SUM(gr.Tries) as TotalTries,
    SUM(gr.UsedHints) as TotalHints,
    DATENAME(MONTH, gs.GameDate) as GameMonth
FROM 
    GameRounds gr
JOIN 
    GameStats gs ON gr.GameStatID = gs.GameStatID
WHERE 
    gs.UserID = @UserID
    AND DATEPART(yyyy, gs.GameDate) = @year
GROUP BY 
    DATENAME(MONTH, gs.GameDate),
    DATEPART(mm, gs.GameDate)
ORDER BY 
    DATEPART(mm, gs.GameDate);

    EXEC MonthlyTriesAndHintsSummary 33,2023;
GO

-----------------------------------------------------------------------------------------
CREATE PROCEDURE GetWeeklyStats @UserID INT, @Year INT, @Month INT
AS
BEGIN
    WITH WeeksData AS (
        SELECT 
            DATEPART(wk, gs.GameDate) as Week,
            MIN(gs.GameDate) as WeekStartDate,
            DATENAME(dw, MIN(gs.GameDate)) as WeekStartDay,
            COUNT(*) as TotalRounds,
            SUM(CASE WHEN gr.UsedHints > 0 AND gr.Tries = 0 THEN 1.0 ELSE 0.0 END) as OnlyHints,
            SUM(CASE WHEN gr.Tries > 0 and gr.UsedHints = 0 THEN 1.0 ELSE 0.0 END) as MoreThanOneTry,
            SUM(CASE WHEN gr.UsedHints = 0 AND gr.Tries = 0 THEN 1.0 ELSE 0.0 END) as NoHintsOrTries,
            SUM(CASE WHEN gr.UsedHints > 0 AND gr.Tries > 0 THEN 1.0 ELSE 0.0 END) as BothHintsAndTries
        FROM 
            Users u
        JOIN 
            GameStats gs ON u.UserID = gs.UserID
        JOIN 
            GameRounds gr ON gs.GameStatID = gr.GameStatID
        WHERE 
            u.UserID = @UserID AND YEAR(gs.GameDate) = @Year AND MONTH(gs.GameDate) = @Month
        GROUP BY 
            DATEPART(wk, gs.GameDate)
    )
    SELECT 
        Week,
        WeekStartDate,
        WeekStartDay,
        ROUND((OnlyHints / CAST(TotalRounds AS FLOAT)) * 100, 2) as PercentageOnlyHints,
        ROUND((MoreThanOneTry / CAST(TotalRounds AS FLOAT)) * 100, 2) as PercentageMoreThanOneTry,
        ROUND((BothHintsAndTries / CAST(TotalRounds AS FLOAT)) * 100, 2) as PercentageBothHintsAndTries,
        100.00 - (ROUND((OnlyHints / CAST(TotalRounds AS FLOAT)) * 100, 2) + 
                 ROUND((MoreThanOneTry / CAST(TotalRounds AS FLOAT)) * 100, 2) + 
                 ROUND((BothHintsAndTries / CAST(TotalRounds AS FLOAT)) * 100, 2)) as PercentageNoHintsOrTries
    FROM 
        WeeksData;
END

GO
----------------------------------------------------------------------------------------------------------
CREATE PROCEDURE GetMonthlyStats @UserID INT, @Year INT
AS
BEGIN
    WITH MonthsData AS (
        SELECT 
            DATEPART(mm, gs.GameDate) as Month,
            DATENAME(month, MIN(gs.GameDate)) as MonthName,
            COUNT(*) as TotalRounds,
           SUM(CASE WHEN gr.UsedHints > 0 AND gr.Tries = 0 THEN 1.0 ELSE 0.0 END) as OnlyHints,
        SUM(CASE WHEN gr.Tries > 0 and gr.UsedHints = 0 THEN 1.0 ELSE 0.0 END) as MoreThanOneTry,
        SUM(CASE WHEN gr.UsedHints = 0 AND gr.Tries = 0 THEN 1.0 ELSE 0.0 END) as NoHintsOrTries,
        SUM(CASE WHEN gr.UsedHints > 0 AND gr.Tries > 0 THEN 1.0 ELSE 0.0 END) as BothHintsAndTries
    FROM 
        Users u
    JOIN 
        GameStats gs ON u.UserID = gs.UserID
    JOIN 
        GameRounds gr ON gs.GameStatID = gr.GameStatID
    WHERE 
        u.UserID = @UserID and YEAR(gs.GameDate)= @Year
    GROUP BY 
    DATEPART(mm, gs.GameDate)

)
SELECT 
    Month,
    MonthName,
    ROUND((OnlyHints / CAST(TotalRounds AS FLOAT)) * 100, 2) as PercentageOnlyHints,
    ROUND((MoreThanOneTry / CAST(TotalRounds AS FLOAT)) * 100, 2) as PercentageMoreThanOneTry,
    ROUND((BothHintsAndTries / CAST(TotalRounds AS FLOAT)) * 100, 2) as PercentageBothHintsAndTries,
    100.00 - (ROUND((OnlyHints / CAST(TotalRounds AS FLOAT)) * 100, 2) + 
             ROUND((MoreThanOneTry / CAST(TotalRounds AS FLOAT)) * 100, 2) + 
             ROUND((BothHintsAndTries / CAST(TotalRounds AS FLOAT)) * 100, 2)) as PercentageNoHintsOrTries
FROM 
    MonthsData
    order by Month;
END
EXEC GetMonthlyStats 37,2023
GO

----------------------------------------------------------------------------------------------
CREATE PROCEDURE GetLifetimeStats @UserID Int
AS
BEGIN
WITH LifetimeData AS (
    SELECT 
        COUNT(*) as TotalRounds,
        SUM(CASE WHEN gr.UsedHints > 0 AND gr.Tries = 0 THEN 1.0 ELSE 0.0 END) as OnlyHints,  
        SUM(CASE WHEN gr.Tries > 0 and gr.UsedHints = 0 THEN 1.0 ELSE 0.0 END) as MoreThanOneTry,
        SUM(CASE WHEN gr.UsedHints = 0 AND gr.Tries = 0 THEN 1.0 ELSE 0.0 END) as NoHintsOrTries,
        SUM(CASE WHEN gr.UsedHints > 0 AND gr.Tries > 0 THEN 1.0 ELSE 0.0 END) as BothHintsAndTries
    FROM 
        Users u
    JOIN 
        GameStats gs ON u.UserID = gs.UserID
    JOIN 
        GameRounds gr ON gs.GameStatID = gr.GameStatID
    WHERE 
        u.UserID = @UserID
)
SELECT 
    ROUND((OnlyHints / CAST(TotalRounds AS FLOAT)) * 100, 2) as PercentageOnlyHints,
    ROUND((MoreThanOneTry / CAST(TotalRounds AS FLOAT)) * 100, 2) as PercentageMoreThanOneTry,
    ROUND((BothHintsAndTries / CAST(TotalRounds AS FLOAT)) * 100, 2) as PercentageBothHintsAndTries,
    100.00 - (ROUND((OnlyHints / CAST(TotalRounds AS FLOAT)) * 100, 2) + 
             ROUND((MoreThanOneTry / CAST(TotalRounds AS FLOAT)) * 100, 2) + 
             ROUND((BothHintsAndTries / CAST(TotalRounds AS FLOAT)) * 100, 2)) as PercentageNoHintsOrTries
FROM 
    LifetimeData;
END
GO
--------------------------------------------------------------------------------------------------
Create Procedure GetAllYearsPlayed @UserID INT
AS
BEGIN
	SELECT DISTINCT YEAR(GameDate) as Year
	FROM GameStats
	WHERE UserID = @UserID
	ORDER BY YEAR(GameDate) DESC
END

Exec GetAllYearsPlayed 37;
GO
-------------------------------------------------------------------------------------------
CREATE PROCEDURE GetAllMonthsPlayed
    @UserID INT,
    @Year INT
AS
BEGIN
    ;WITH CTE_Months AS (
        SELECT DISTINCT DATENAME(MONTH, GameDate) AS Month, DATEPART(MM, GameDate) AS MonthNumber
        FROM GameStats
        WHERE UserID = @UserID AND YEAR(GameDate) = @Year
    )
    SELECT Month
    FROM CTE_Months
    ORDER BY MonthNumber
END
Exec GetAllMonthsPlayed 37, 2023;
Go
-------------------------------------------------------------------------------------------
create Procedure GetGameStatus
@UserID int
AS
Begin
    SELECT COUNT(gs.GameStatID) AS GesamteSpiele FROM GameStats AS gs
    WHERE gs.UserID = @UserID
END

GO

EXEC GetWeeklyStats 33, 2023, 9;
Select * from GameStats where UserID=37 AND YEAR(GameDate) = 2023;
Select * from users;


Go
------------------------------------------------------------------------------
DECLARE @GameStatID INT
DECLARE @GameDate DATE = '20200101'
DECLARE @EndDate DATE = '20201231'
DECLARE @Score INT
DECLARE @MaxPossibleScore INT
DECLARE @UsedHints INT
DECLARE @UsedTries INT
WHILE @GameDate <= @EndDate
BEGIN
    DECLARE @GamesPerDay INT = CAST(RAND(CHECKSUM(NEWID())) * 10 AS INT)
    DECLARE @GameCounter INT = 0

    WHILE @GameCounter <= @GamesPerDay
    BEGIN
        INSERT INTO GameStats(UserID, GameDate, Highscore) VALUES(1, @GameDate, 0)
        SET @GameStatID = SCOPE_IDENTITY()

        SET @MaxPossibleScore = 0
        SET @UsedHints = 0
        SET @UsedTries = 0
        DECLARE @RoundCounter INT = 0
        DECLARE @MaxRounds INT = CAST(RAND(CHECKSUM(NEWID())) * 50 + 1 AS INT)
        WHILE @RoundCounter <= @MaxRounds
        BEGIN
            SET @MaxPossibleScore += 10

            DECLARE @UsedHintsInRound INT = CAST(RAND(CHECKSUM(NEWID())) * 4 AS INT)
            DECLARE @TriesInRound INT = CAST(RAND(CHECKSUM(NEWID())) * 2 AS INT)
            IF @RoundCounter >= 10 AND CAST(RAND(CHECKSUM(NEWID())) * 10 AS INT) = 0
            BEGIN
                SET @TriesInRound = CAST(RAND(CHECKSUM(NEWID())) * 3 AS INT)
            END

            SET @UsedHints += @UsedHintsInRound
            SET @UsedTries += @TriesInRound
            INSERT INTO GameRounds(GameStatID, UsedHints, Tries) VALUES(@GameStatID, @UsedHintsInRound, @TriesInRound)
            IF @TriesInRound = 3
            BEGIN
                BREAK
            END
            SET @RoundCounter = @RoundCounter + 1
        END
        SET @Score = @MaxPossibleScore - @UsedHints - (@UsedTries * 2)
        UPDATE GameStats SET Highscore = @Score WHERE GameStatID = @GameStatID

        SET @GameCounter = @GameCounter + 1
    END
    SET @GameDate = DATEADD(DAY, CAST(RAND(CHECKSUM(NEWID())) * 3 + 1 AS INT), @GameDate)
END
Go
-----------------------------------------------------------------------------------------------------
CREATE TRIGGER TGDeleteUserData
ON Users
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM GameRounds
    WHERE GameStatID IN (
        SELECT GameStatID
        FROM GameStats
        WHERE UserID IN (SELECT UserID FROM deleted)
    );
    DELETE FROM GameStats
    WHERE UserID IN (SELECT UserID FROM deleted);
    DELETE FROM Users
    WHERE UserID IN (SELECT UserID FROM deleted);
END;
GO
-----------------------------------------------------------------------------------------
select * from GameRounds where GameStatID = 3551;

SELECT 
    u.UserID, 
    gs.GameStatID, 
    gs.Highscore,
    COUNT(gr.GameRoundID) AS NumberOfRounds,
    SUM(gr.Tries) AS TotalTries,
    SUM(gr.UsedHints) AS TotalHintsUsed
FROM 
    Users AS u
JOIN 
    GameStats AS gs ON gs.UserID = u.UserID
JOIN 
    GameRounds AS gr ON gs.GameStatID = gr.GameStatID
WHERE 
    u.UserID = 37
GROUP BY 
    u.UserID, gs.GameStatID, gs.Highscore
ORDER BY 
    u.UserID, gs.GameStatID;

--------------------------------------------------------------------------------------

select * from Users as US ;
EXEC GetGameStatus 38;
Select * from GameStats;
Select * From GameRounds;
select * from users;
delete from users;
TRUNCATE TABLE GameStats;
DBCC CHECKIDENT ('GameRounds', RESEED, 0);