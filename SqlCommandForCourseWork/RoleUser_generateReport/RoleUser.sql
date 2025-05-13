USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'CheckLoginPermissions')
DROP PROCEDURE CheckLoginPermissions;
GO

CREATE PROCEDURE CheckLoginPermissions
    @Username NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    -- ѕерев≥р€Їмо, чи ≥снуЇ користувач
    IF EXISTS (SELECT 1 FROM Users WHERE Username = @Username)
    BEGIN
        -- ѕовертаЇмо роль користувача
        SELECT 
            Username,
            Roleuser
        FROM Users
        WHERE Username = @Username;
    END
    ELSE
    BEGIN
        -- якщо користувача нема Ч повертаЇмо NULL роль
        SELECT 
            @Username AS Username,
            '' AS Roleuser;
    END
END
GO

--CREATE TABLE Users (
--    Id char(36) PRIMARY KEY,
--    Username NVARCHAR(100),
--    PasswordHash NVARCHAR(200),
--    Roleuser NVARCHAR(50) -- наприклад: 'admin', 'user'
--);

delete from Users
go

insert into Users(Id,Username,Roleuser)
values 
('1','sa','MainDoctor'),
('2','MainDoctor','MainDoctor'),
('3','Doctor','Doctor'),
('4','Nurse','Nurse')

go