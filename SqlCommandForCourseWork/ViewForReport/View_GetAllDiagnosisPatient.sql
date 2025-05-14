USE Helsi;
GO

-- Drop the view if it exists
IF OBJECT_ID('vw_AllDiagnosisPatient', 'V') IS NOT NULL
    DROP VIEW vw_AllDiagnosisPatient;
GO

-- Create the view
CREATE VIEW vw_AllDiagnosisPatient AS
SELECT 
    p.full_name AS "Пацієнт",
    e.diagnosis AS "Діагноз",
    e.description_diagnosis AS "Опис діагнозу",
    d.name_doctor AS "Лікар",
    dep.name_department AS "Відділення"
FROM 
    Episode e
JOIN 
    Medical_card mc ON e.id_medical_card = mc.id_medical_card
JOIN 
    Patient p ON mc.id_patient = p.id_patient
JOIN 
    Action_ISPS a ON e.id_episode = a.id_episode AND e.id_medical_card = a.id_medical_card
JOIN 
    Doctor d ON a.id_doctor = d.id_doctor
JOIN 
    Department dep ON d.id_department = dep.id_department;
GO
