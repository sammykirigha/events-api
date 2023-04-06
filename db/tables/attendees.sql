DROP TABLE IF EXISTS dbo.Attendees;
CREATE TABLE dbo.Attendees
(
    AttendeeId INT IDENTITY PRIMARY KEY,
    Email VARCHAR(100) NOT NULL,
    Phone VARCHAR(100) NOT NULL,
    [FirstName] VARCHAR(100) NULL,
    [LastName] VARCHAR(100) NOT NULL,
    Speaker VARCHAR(100) NOT NULL,
) 
GO

INSERT INTO dbo.Attendees
    (Email, Phone, [FirstName], LastName, Speaker )
VALUES
    ('sammy@gmail.com', '098765768', 'Samuel', 'Kirigha', 'Yes')


SELECT *
FROM dbo.Attendees