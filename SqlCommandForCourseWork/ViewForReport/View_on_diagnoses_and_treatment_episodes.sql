USE Helsi;
GO

-- Видалення, якщо існує
IF OBJECT_ID('View_on_diagnoses_and_treatment_episodes', 'V') IS NOT NULL
    DROP VIEW View_on_diagnoses_and_treatment_episodes;
GO

CREATE VIEW View_on_diagnoses_and_treatment_episodes AS
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
