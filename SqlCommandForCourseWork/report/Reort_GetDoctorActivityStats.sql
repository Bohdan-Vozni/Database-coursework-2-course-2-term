USE Helsi;
GO

-- Drop the procedure if it already exists
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetDoctorActivityStats')
DROP PROCEDURE GetDoctorActivityStats;
GO


-- Create the procedure
CREATE PROCEDURE GetDoctorActivityStats
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        "Лікар",
        "Відділення",
        COUNT(DISTINCT id_medical_card) AS "Кількість пацієнтів",
        COUNT(id_procedure) AS "Кількість процедур",
        COUNT(id_medication) AS "Кількість призначень ліків"
    FROM 
        vw_GetDoctorActivityStats
    WHERE 
        data_time BETWEEN DATEADD(month, -1, GETDATE()) AND GETDATE()
    GROUP BY 
        "Лікар", "Відділення"
    ORDER BY 
        COUNT(DISTINCT id_medical_card) DESC;
END;
GO
