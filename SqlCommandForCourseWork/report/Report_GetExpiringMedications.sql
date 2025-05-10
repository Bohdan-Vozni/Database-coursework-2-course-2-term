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
        name_medication AS "����� ���",
        manufacturer AS "��������",
        expiration_date AS "����� ����������",
        DATEDIFF(day, GETDATE(), expiration_date) AS "���������� ���"
    FROM 
        Medication
    WHERE 
        expiration_date BETWEEN GETDATE() AND DATEADD(month, 3, GETDATE())
    ORDER BY 
        expiration_date;
END;
GO

