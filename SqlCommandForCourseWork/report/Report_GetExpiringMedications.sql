USE Helsi;
GO

-- Drop the procedure if it already exists
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetExpiringMedications')
DROP PROCEDURE GetExpiringMedications;
GO

-- Create the stored procedure
CREATE PROCEDURE GetExpiringMedications
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        name_medication AS "Назва ліків",
        manufacturer AS "Виробник",
        expiration_date AS "Термін придатності",
        DATEDIFF(day, GETDATE(), expiration_date) AS "Залишилось днів"
    FROM 
        Medication
    WHERE 
        expiration_date BETWEEN GETDATE() AND DATEADD(month, 3, GETDATE())
    ORDER BY 
        expiration_date;
END;
GO

