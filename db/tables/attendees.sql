DROP TABLE IF EXISTS dbo.Attendees;
CREATE TABLE dbo.Attendees
(
    AttendeeId INT IDENTITY PRIMARY KEY,
    Email VARCHAR(100) NOT NULL,
    Phone VARCHAR(100) NOT NULL,
    [FirstName] VARCHAR(100) NULL,
    [LastName] VARCHAR(100) NOT NULL,
    Guest VARCHAR(100) NOT NULL,
    Speaker VARCHAR(100) NOT NULL,
    Guest VARCHAR(100) NOT NULL,
    FOREIGN KEY (Event_Id) REFERENCES Events(EventId) ON DELETE CASCADE ON UPDATE CASCADE
) 
GO

INSERT INTO dbo.Attendees
    (EventName, EventDate, [Location], Capacity)
VALUES
    (1, 'Wedding', '2023-04-08', 'A Friend wedding', 'Nyeri', 100)


SELECT *
FROM dbo.Attendees