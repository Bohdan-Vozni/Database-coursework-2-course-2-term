USE master;
GO

-- Створюємо логін Customer, якщо нема
IF NOT EXISTS (SELECT name FROM sys.server_principals WHERE name = 'Customer')
    CREATE LOGIN Customer WITH PASSWORD = '1234';
GO

USE Helsi;
GO

-- Видаляємо користувача Customer, якщо існує
IF EXISTS (SELECT name FROM sys.database_principals WHERE name = 'Customer')
    DROP USER Customer;
GO

-- Створюємо користувача Customer з логіном Customer
CREATE USER Customer FROM LOGIN Customer;
GO

-- Додаємо Customer тільки до ролі читача (тільки SELECT)
ALTER ROLE db_datareader ADD MEMBER Customer;
GO

-- Додаємо права тільки на виконання конкретної процедури
GRANT EXECUTE ON SCHEMA::dbo TO Customer;
GO


