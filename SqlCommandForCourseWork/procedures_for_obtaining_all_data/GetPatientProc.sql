--use Helsi;


--insert into Patient(id_patient, full_name,date_of_birth,phone_number,address_patient)
-- values ('1','Іванов Іван Іванович','2025-04-05','0960849073','Київ')

USE Helsi;
GO

IF EXISTS (SELECT name FROM sys.objects WHERE name = 'GetAllPatientsProc' AND type = 'P')
    DROP PROCEDURE GetAllPatientsProc;
GO

CREATE PROCEDURE GetAllPatientsProc
    @SearchName NVARCHAR(100) = '' -- параметр з дефолтним значенням
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM Patient
    WHERE (@SearchName = '' OR full_name LIKE '%' + @SearchName + '%')
    ORDER BY full_name DESC;
END;
GO
