USE Helsi;
GO

-- Drop the view if it exists
IF OBJECT_ID('vw_GetDoctorActivityStats', 'V') IS NOT NULL
    DROP VIEW vw_GetDoctorActivityStats;
GO

-- Create the view
CREATE VIEW vw_GetDoctorActivityStats AS
SELECT 
    d.name_doctor AS "Лікар",
    dep.name_department AS "Відділення",
    a.id_medical_card,
    a.id_procedure,
    a.id_medication,
    a.data_time
FROM 
    Doctor d
JOIN 
    Department dep ON d.id_department = dep.id_department
LEFT JOIN 
    Action_ISPS a ON d.id_doctor = a.id_doctor;
GO
