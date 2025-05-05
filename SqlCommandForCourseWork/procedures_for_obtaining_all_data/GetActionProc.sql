USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetAllActionProc')
DROP PROCEDURE GetAllActionProc;
GO

CREATE PROCEDURE GetAllActionProc
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        a.id_doctor,
		d.name_doctor AS doctor_name,
        d.specialization AS doctor_specialization,

        a.id_episode,
		e.diagnosis,

        a.id_medical_card,

        a.description_action,
        a.data_time AS action_date,
        a.id_procedure,
        a.id_medication,
        -- Інформація про лікаря
       
        -- Інформація про відділення
        --dep.name_department AS department_name,
        -- Інформація про пацієнта
        ---p.full_name AS patient_name,
        -- Інформація про процедуру (якщо є)
        pc.name_procedure AS 'прроцедура що проводилася',
        -- Інформація про ліки (якщо є)
        m.name_medication AS medication_name
        --m.manufacturer AS medication_manufacturer
    FROM 
        Action_ISPS a
    LEFT JOIN 
        Doctor d ON a.id_doctor = d.id_doctor
    LEFT JOIN 
        Department dep ON d.id_department = dep.id_department
    LEFT JOIN 
        Episode e ON a.id_episode = e.id_episode AND a.id_medical_card = e.id_medical_card
    LEFT JOIN 
        Medical_card mc ON e.id_medical_card = mc.id_medical_card
    LEFT JOIN 
        Patient p ON mc.id_patient = p.id_patient
    LEFT JOIN 
        Procedure_Client pc ON a.id_procedure = pc.id_procedure
    LEFT JOIN 
        Medication m ON a.id_medication = m.id_medication
    ORDER BY 
        a.data_time DESC;
END;
GO