USE Helsi;
GO

-- Drop the view if it exists
IF OBJECT_ID('View_GetMedicationUsageByDepartment', 'V') IS NOT NULL
    DROP VIEW View_GetMedicationUsageByDepartment;
GO

-- Create the view
CREATE VIEW View_GetMedicationUsageByDepartment AS
SELECT 
    dep.name_department AS "Відділення",
    m.name_medication AS "Назва ліків",
    a.id_medication,
    a.data_time
FROM 
    Action_ISPS a
JOIN 
    Doctor d ON a.id_doctor = d.id_doctor
JOIN 
    Department dep ON d.id_department = dep.id_department
JOIN 
    Medication m ON a.id_medication = m.id_medication;
GO
