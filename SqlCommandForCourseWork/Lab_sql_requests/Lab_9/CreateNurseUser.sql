USE master;
GO

-- Створюємо логін Customer, якщо нема
IF NOT EXISTS (SELECT name FROM sys.server_principals WHERE name = 'Nurse')
    CREATE LOGIN Nurse WITH PASSWORD = '1234';
GO

USE Helsi;
GO

-- Видаляємо користувача Customer, якщо існує
IF EXISTS (SELECT name FROM sys.database_principals WHERE name = 'Nurse')
    DROP USER Nurse;
GO

-- Створюємо користувача Customer з логіном Nurse
CREATE USER Nurse FROM LOGIN Nurse;
GO

-- Додаємо Nurse тільки до ролі читача (тільки SELECT)
ALTER ROLE db_datareader ADD MEMBER Nurse;
GO

-- Додаємо права тільки на виконання конкретної процедури
GRANT EXECUTE ON SCHEMA::dbo TO Nurse;
GO


