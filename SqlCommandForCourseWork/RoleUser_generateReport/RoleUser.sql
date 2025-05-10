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

    -- ����������, �� ���� ����������
    IF EXISTS (SELECT 1 FROM Users WHERE Username = @Username)
    BEGIN
        -- ��������� ���� �����������
        SELECT 
            Username,
            Roleuser
        FROM Users
        WHERE Username = @Username;
    END
    ELSE
    BEGIN
        -- ���� ����������� ���� � ��������� NULL ����
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
--    Roleuser NVARCHAR(50) -- ���������: 'admin', 'user'
--);

delete from Users
go

insert into Users(Id,Username,Roleuser)
values 
('1','sa','admin'),
('2','AdminDatabase','admin'),
('3','Customer','user')

go