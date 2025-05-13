USE master;
GO

-- ��������� ���� Customer, ���� ����
IF NOT EXISTS (SELECT name FROM sys.server_principals WHERE name = 'Nurse')
    CREATE LOGIN Nurse WITH PASSWORD = '1234';
GO

USE Helsi;
GO

-- ��������� ����������� Customer, ���� ����
IF EXISTS (SELECT name FROM sys.database_principals WHERE name = 'Nurse')
    DROP USER Nurse;
GO

-- ��������� ����������� Customer � ������ Nurse
CREATE USER Nurse FROM LOGIN Nurse;
GO

-- ������ Nurse ����� �� ��� ������ (����� SELECT)
ALTER ROLE db_datareader ADD MEMBER Nurse;
GO

-- ������ ����� ����� �� ��������� ��������� ���������
GRANT EXECUTE ON SCHEMA::dbo TO Nurse;
GO


