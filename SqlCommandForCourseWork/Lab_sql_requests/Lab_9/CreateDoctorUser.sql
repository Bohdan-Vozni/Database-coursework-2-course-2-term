IF NOT EXISTS (SELECT name FROM sys.server_principals WHERE name = 'Doctor')
    CREATE LOGIN Doctor WITH PASSWORD = '1234';

USE Helsi;

IF EXISTS (SELECT name FROM sys.database_principals WHERE name = 'Doctor')
    DROP USER Doctor;

CREATE USER Doctor FOR LOGIN Doctor;

ALTER ROLE db_datareader ADD MEMBER Doctor;
ALTER ROLE db_datawriter ADD MEMBER Doctor;
Grant execute to Doctor;