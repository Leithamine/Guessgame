CREATE DATABASE GuessGameDB;

USE GuessGameDB;

CREATE TABLE Users
(
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50),
    HashedPassword Char(64),

);

CREATE TABLE GameStats
(
    GameStatID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    GameDate Date,
    Score INT
);

CREATE TABLE GameRounds
(
    GameRoundID INT PRIMARY KEY IDENTITY(1,1),
    GameStatID INT FOREIGN KEY REFERENCES GameStats(GameStatID),
    UsedHints INT,
    Tries INT
);


--Game Usage Development per Week
SELECT 
COUNT(gs.GameStatID) as GamesPlayed,
DATEPART(wk, gs.GameDate) as GameWeek
FROM 
    Users u
JOIN 
    GameStats gs ON u.UserID = gs.UserID
WHERE 
    u.UserID = 33
GROUP BY 
    DATEPART(wk, gs.GameDate)
ORDER BY 
    DATEPART(wk, gs.GameDate);

--Score Development per Week
SELECT 
    MAX(gs.Highscore) as HighScore,
    DATEPART(wk, gs.GameDate) as GameWeek
FROM 
    Users u
JOIN 
    GameStats gs ON u.UserID = gs.UserID
WHERE 
    u.UserID = 33
GROUP BY 
    DATEPART(wk, gs.GameDate)
ORDER BY 
    DATEPART(wk, gs.GameDate);

    
--Game Usage Development per Month
SELECT 
COUNT(gs.GameStatID) as GamesPlayed,
DATEPART(mm, gs.GameDate) as GameMonth
FROM 
    Users u
JOIN 
    GameStats gs ON u.UserID = gs.UserID
WHERE 
    u.UserID = 33
GROUP BY 
    DATEPART(mm, gs.GameDate)
ORDER BY 
    DATEPART(mm, gs.GameDate);

--Score Development per Month
SELECT 
    MAX(gs.Highscore) as HighScore,
    DATEPART(mm, gs.GameDate) as GameMonth
FROM 
    Users u
JOIN 
    GameStats gs ON u.UserID = gs.UserID
WHERE 
    u.UserID = 33
GROUP BY 
    DATEPART(mm, gs.GameDate)
ORDER BY 
    DATEPART(mm, gs.GameDate);

--Summe Tries and Hints Per Week

SELECT Sum(Tries) as UsedTries, sum(UsedHints) as UsedHints, DATEPART(wk, GameDate) as GameWeek
FROM GameRounds
JOIN GameStats ON GameRounds.GameStatID = GameStats.GameStatID
WHERE GameStats.UserID = 33
GROUP BY DATEPART(wk, GameDate)
ORDER BY DATEPART(wk, GameDate);

--Summe Tries and Hints Per Month

SELECT 
    Sum(Tries) as AvgTries, 
    sum(UsedHints) as AvgHints, 
    DATEPART(mm, GameDate) as GameWeek
FROM GameRounds
JOIN GameStats ON GameRounds.GameStatID = GameStats.GameStatID
WHERE GameStats.UserID = 33
GROUP BY DATEPART(mm, GameDate)
ORDER BY DATEPART(mm, GameDate);



-- Percentage of All User's Rounds within a Week Weeks View

WITH WeeksData AS (
    SELECT 
        DATEPART(wk, gs.GameDate) as Week,
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
        u.UserID = 33
    GROUP BY 
        DATEPART(wk, gs.GameDate)
)
SELECT 
    Week,
    ROUND((OnlyHints / CAST(TotalRounds AS FLOAT)) * 100, 2) as PercentageOnlyHints,
    ROUND((MoreThanOneTry / CAST(TotalRounds AS FLOAT)) * 100, 2) as PercentageMoreThanOneTry,
    ROUND((BothHintsAndTries / CAST(TotalRounds AS FLOAT)) * 100, 2) as PercentageBothHintsAndTries,
    100.00 - (ROUND((OnlyHints / CAST(TotalRounds AS FLOAT)) * 100, 2) + 
             ROUND((MoreThanOneTry / CAST(TotalRounds AS FLOAT)) * 100, 2) + 
             ROUND((BothHintsAndTries / CAST(TotalRounds AS FLOAT)) * 100, 2)) as PercentageNoHintsOrTries
FROM 
    WeeksData;



    -- Percentage of All User's Rounds within a Month  View

WITH MonthsData AS (
    SELECT 
        DATEPART(mm, gs.GameDate) as Month,
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
        u.UserID = 33
    GROUP BY 
        DATEPART(mm, gs.GameDate)
)
SELECT 
    Month,
    ROUND((OnlyHints / CAST(TotalRounds AS FLOAT)) * 100, 2) as PercentageOnlyHints,
    ROUND((MoreThanOneTry / CAST(TotalRounds AS FLOAT)) * 100, 2) as PercentageMoreThanOneTry,
    ROUND((BothHintsAndTries / CAST(TotalRounds AS FLOAT)) * 100, 2) as PercentageBothHintsAndTries,
    100.00 - (ROUND((OnlyHints / CAST(TotalRounds AS FLOAT)) * 100, 2) + 
             ROUND((MoreThanOneTry / CAST(TotalRounds AS FLOAT)) * 100, 2) + 
             ROUND((BothHintsAndTries / CAST(TotalRounds AS FLOAT)) * 100, 2)) as PercentageNoHintsOrTries
FROM 
    MonthsData;


    -- Percentage of All User's Rounds within a Lifetime View
    WITH LifetimeData AS (
    SELECT 
        COUNT(*) as TotalRounds,  -- Total number of rounds played
        SUM(CASE WHEN gr.UsedHints > 0 AND gr.Tries = 0 THEN 1.0 ELSE 0.0 END) as OnlyHints,  -- Rounds where only hints were used
        SUM(CASE WHEN gr.Tries > 0 and gr.UsedHints = 0 THEN 1.0 ELSE 0.0 END) as MoreThanOneTry,  -- Rounds where multiple tries were used without hints
        SUM(CASE WHEN gr.UsedHints = 0 AND gr.Tries = 0 THEN 1.0 ELSE 0.0 END) as NoHintsOrTries,  -- Rounds where neither hints nor tries were used
        SUM(CASE WHEN gr.UsedHints > 0 AND gr.Tries > 0 THEN 1.0 ELSE 0.0 END) as BothHintsAndTries  -- Rounds where both hints and tries were used
    FROM 
        Users u
    JOIN 
        GameStats gs ON u.UserID = gs.UserID
    JOIN 
        GameRounds gr ON gs.GameStatID = gr.GameStatID
    WHERE 
        u.UserID = 33  -- Filtering data for a specific user
)
-- Calculating the percentages based on the aggregated data
SELECT 
    ROUND((OnlyHints / CAST(TotalRounds AS FLOAT)) * 100, 2) as PercentageOnlyHints,
    ROUND((MoreThanOneTry / CAST(TotalRounds AS FLOAT)) * 100, 2) as PercentageMoreThanOneTry,
    ROUND((BothHintsAndTries / CAST(TotalRounds AS FLOAT)) * 100, 2) as PercentageBothHintsAndTries,
    100.00 - (ROUND((OnlyHints / CAST(TotalRounds AS FLOAT)) * 100, 2) + 
             ROUND((MoreThanOneTry / CAST(TotalRounds AS FLOAT)) * 100, 2) + 
             ROUND((BothHintsAndTries / CAST(TotalRounds AS FLOAT)) * 100, 2)) as PercentageNoHintsOrTries
FROM 
    LifetimeData;



SELECT Sum(Tries) as AvgTries, sum(UsedHints) as AvgHints, DATEPART(wk, GameDate) as GameWeek
                            FROM GameRounds JOIN GameStats ON GameRounds.GameStatID = GameStats.GameStatID
                            WHERE GameStats.UserID = 33
                            GROUP BY DATEPART(wk, GameDate)
                            ORDER BY DATEPART(wk, GameDate)



Alter table Users
Alter Column HashedPassword CHAR(64);

Alter Table GameStats
Add GameDate DATE;

Alter Table GameStats
Drop Column PlayedRounds;

Alter Table Users
Drop Column Highscore;

Alter Table GameStats
Add Highscore int;

SELECT U.* , Max(G.HighScore) FROM Users AS U
Inner Join GameStats AS G 
ON U.UserID = G.UserID

SELECT Max(G.Highscore) AS Highscore FROM Users AS U Inner Join GameStats AS G ON G.UserID = 31;


Select * from GameRounds;
select * from GameStats WHERE UserID= 33;
Select * from Users;


SELECT 
    AVG(gr.Tries) as AvgTries,
    AVG(gr.UsedHints) as AvgHints
FROM GameRounds as gr join GameStats as gs 
on
gr.GameStatID = gs.GameStatID join Users as u
on gs.UserID = 33;




SELECT u.UserID, u.Username, AVG(Gr.Tries) as AverageTries
FROM Users u
JOIN GameStats Gs ON u.UserID = Gs.UserID
JOIN GameRounds Gr ON Gs.GameStatID = Gr.GameStatID
GROUP BY u.UserID, u.Username;


SELECT UserID, AVG(Tries) as AvgTries, GameDate
FROM GameStats  JOIN GameRounds ON GameStats.GameStatID = GameRounds.GameStatID
GROUP BY UserID, GameDate
ORDER BY GameDate;

SELECT GameStatID, COUNT(*) as NumberOfRounds
FROM GameRounds
GROUP BY GameStatID;

SELECT GameDate, Highscore FROM GameStats WHERE UserID = 35 ORDER BY GameDate ASC

Delete from Users;
Delete From GameStats;
DELETE FROM GameRounds;



SELECT 
    U.UserID, 
    U.Username, 
    GS.GameStatID, 
    COUNT(GR.GameRoundID) AS RoundsPerGame 
FROM 
    Users U
JOIN 
    GameStats GS ON U.UserID = GS.UserID
JOIN 
    GameRounds GR ON GS.GameStatID = GR.GameStatID
WHERE 
    U.UserID = 33
GROUP BY 
    U.UserID, U.Username, GS.GameStatID
ORDER BY 
    GS.GameStatID;






insert into Users (Username, HashedPassword, Highscore) values ('admin', 'admin', 10);


SELECT 
    AVG(gr.Tries) as AvgTries,
    AVG(gr.UsedHints) as AvgHints

FROM 
    Users u
JOIN 
    GameStats gs ON u.UserID = gs.UserID
JOIN 
    GameRounds gr ON gs.GameStatID = gr.GameStatID
WHERE 
    u.UserID = 34
GROUP BY 
    DATEPART(wk, gs.GameDate)
ORDER BY 
    DATEPART(wk, gs.GameDate);






----------------------------------------

