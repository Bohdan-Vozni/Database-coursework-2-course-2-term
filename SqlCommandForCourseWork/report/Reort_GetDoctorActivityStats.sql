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
        "˳���",
        "³�������",
        COUNT(DISTINCT id_medical_card) AS "ʳ������ ��������",
        COUNT(id_procedure) AS "ʳ������ ��������",
        COUNT(id_medication) AS "ʳ������ ���������� ���"
    FROM 
        vw_GetDoctorActivityStats
    WHERE 
        data_time BETWEEN DATEADD(month, -1, GETDATE()) AND GETDATE()
    GROUP BY 
        "˳���", "³�������"
    ORDER BY 
        COUNT(DISTINCT id_medical_card) DESC;
END;
GO
