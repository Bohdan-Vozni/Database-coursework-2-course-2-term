USE Helsi;
GO



-- Drop the procedure if it exists
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetExpiringMedicationsFromView')
    DROP PROCEDURE GetExpiringMedicationsFromView;
GO

-- Create the procedure
CREATE PROCEDURE GetExpiringMedicationsFromView
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        "Назва ліків",
        "Виробник",
        "Термін придатності",
        DATEDIFF(day, GETDATE(), "Термін придатності") AS "Залишилось днів"
    FROM 
        vw_ExpiringMedications
    WHERE 
        "Термін придатності" BETWEEN GETDATE() AND DATEADD(month, 3, GETDATE())
    ORDER BY 
        "Термін придатності";
END;
GO
