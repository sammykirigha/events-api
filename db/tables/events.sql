DROP TABLE IF EXISTS dbo.Events;
CREATE TABLE dbo.Events
(
    EventId INT IDENTITY PRIMARY KEY,
    EventName VARCHAR(100) NOT NULL,
    EventDate DATE NOT NULL,
    [Description] VARCHAR(100) NULL,
    [Location] VARCHAR(100) NOT NULL,
    Capacity INT NOT NULL,
) 
GO

INSERT INTO dbo.Events
    (EventName, EventDate, [Description], [Location], Capacity)
VALUES
    ('Wedding', '2023-04-08', 'A Friend wedding', 'Nyeri', 100)


SELECT *
FROM dbo.Events