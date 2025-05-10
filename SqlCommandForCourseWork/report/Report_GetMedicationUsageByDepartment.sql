USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetMedicationUsageByDepartment')
DROP PROCEDURE GetMedicationUsageByDepartment;
GO

CREATE PROCEDURE GetMedicationUsageByDepartment
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        dep.name_department AS "Відділення",
        m.name_medication AS "Назва ліків",
        COUNT(a.id_medication) AS "Кількість призначень"
    FROM 
        Action_ISPS a
    JOIN 
        Doctor d ON a.id_doctor = d.id_doctor
    JOIN 
        Department dep ON d.id_department = dep.id_department
    JOIN 
        Medication m ON a.id_medication = m.id_medication
    WHERE 
        a.data_time BETWEEN DATEADD(month, -3, GETDATE()) AND GETDATE()
    GROUP BY 
        dep.name_department, m.name_medication
    ORDER BY 
        dep.name_department, COUNT(a.id_medication) DESC;
END;
GO

-- Виклик
EXEC GetMedicationUsageByDepartment;
