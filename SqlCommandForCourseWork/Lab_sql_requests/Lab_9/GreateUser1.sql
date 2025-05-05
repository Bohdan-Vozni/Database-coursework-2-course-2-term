IF NOT EXISTS (SELECT name FROM sys.server_principals WHERE name = 'AdminDatabase')
    CREATE LOGIN AdminDatabase WITH PASSWORD = '1234';

USE Helsi;

IF EXISTS (SELECT name FROM sys.database_principals WHERE name = 'AdminDatabase')
    DROP USER AdminDatabase;

CREATE USER AdminDatabase FOR LOGIN AdminDatabase;

ALTER ROLE db_datareader ADD MEMBER AdminDatabase;
ALTER ROLE db_datawriter ADD MEMBER AdminDatabase;
Grant execute to AdminDatabase;