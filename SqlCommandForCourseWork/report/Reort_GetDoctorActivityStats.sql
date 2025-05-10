USE Helsi;
GO

-- Drop the procedure if it already exists
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetDoctorActivityStats')
DROP PROCEDURE GetDoctorActivityStats;
GO

-- Create the stored procedure
CREATE PROCEDURE GetDoctorActivityStats
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        d.name_doctor AS "˳���",
        dep.name_department AS "³�������",
        COUNT(DISTINCT a.id_medical_card) AS "ʳ������ ��������",
        COUNT(a.id_procedure) AS "ʳ������ ��������",
        COUNT(a.id_medication) AS "ʳ������ ���������� ���"
    FROM 
        Doctor d
    JOIN 
        Department dep ON d.id_department = dep.id_department
    LEFT JOIN 
        Action_ISPS a ON d.id_doctor = a.id_doctor
    WHERE 
        a.data_time BETWEEN DATEADD(month, -1, GETDATE()) AND GETDATE()
    GROUP BY 
        d.name_doctor, dep.name_department
    ORDER BY 
        COUNT(DISTINCT a.id_medical_card) DESC;
END;
GO

-- Example of how to execute the procedure
EXEC GetDoctorActivityStats;