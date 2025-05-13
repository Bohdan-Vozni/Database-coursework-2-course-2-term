IF NOT EXISTS (SELECT name FROM sys.server_principals WHERE name = 'MainDoctor')
    CREATE LOGIN MainDoctor WITH PASSWORD = '1234';

USE Helsi;

IF EXISTS (SELECT name FROM sys.database_principals WHERE name = 'MainDoctor')
    DROP USER MainDoctor;

CREATE USER MainDoctor FOR LOGIN MainDoctor;

ALTER ROLE db_datareader ADD MEMBER MainDoctor;
ALTER ROLE db_datawriter ADD MEMBER MainDoctor;
Grant execute to MainDoctor;