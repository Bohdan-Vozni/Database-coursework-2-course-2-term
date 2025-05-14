-- Drop the procedure if it exists
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'Report_GetMedicationUsageByDepartment')
    DROP PROCEDURE Report_GetMedicationUsageByDepartment;
GO

-- Create the procedure
CREATE PROCEDURE Report_GetMedicationUsageByDepartment
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        "Відділення",
        "Назва ліків",
        COUNT(id_medication) AS "Кількість призначень"
    FROM 
        View_GetMedicationUsageByDepartment
    WHERE 
        data_time BETWEEN DATEADD(month, -3, GETDATE()) AND GETDATE()
    GROUP BY 
        "Відділення", "Назва ліків"
    ORDER BY 
        "Відділення", COUNT(id_medication) DESC;
END;
GO
