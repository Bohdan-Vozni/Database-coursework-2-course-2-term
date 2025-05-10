USE Helsi;
GO

-- Drop the procedure if it already exists
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetPatientDiagnosisInfo')
DROP PROCEDURE GetPatientDiagnosisInfo;
GO

-- Create the stored procedure
CREATE PROCEDURE GetPatientDiagnosisInfo
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        p.full_name AS "Пацієнт",
        e.diagnosis AS "Діагноз",
        e.description_diagnosis AS "Опис діагнозу",
        --e.id_episode AS "Номер епізоду",
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
        Department dep ON d.id_department = dep.id_department
    ORDER BY 
        e.diagnosis, p.full_name;
END;
GO

---- Example of how to execute the procedure
EXEC GetPatientDiagnosisInfo;