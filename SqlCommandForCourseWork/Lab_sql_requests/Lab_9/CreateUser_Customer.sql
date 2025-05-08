USE master;
GO

-- ��������� ���� Customer, ���� ����
IF NOT EXISTS (SELECT name FROM sys.server_principals WHERE name = 'Customer')
    CREATE LOGIN Customer WITH PASSWORD = '1234';
GO

USE Helsi;
GO

-- ��������� ����������� Customer, ���� ����
IF EXISTS (SELECT name FROM sys.database_principals WHERE name = 'Customer')
    DROP USER Customer;
GO

-- ��������� ����������� Customer � ������ Customer
CREATE USER Customer FROM LOGIN Customer;
GO

-- ������ Customer ����� �� ��� ������ (����� SELECT)
ALTER ROLE db_datareader ADD MEMBER Customer;
GO

-- ������ ����� ����� �� ��������� ��������� ���������
GRANT EXECUTE ON SCHEMA::dbo TO Customer;
GO


