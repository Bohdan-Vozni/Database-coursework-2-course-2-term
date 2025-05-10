USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetAllActionProc')
    DROP PROCEDURE GetAllActionProc;
GO

CREATE PROCEDURE GetAllActionProc
    @PatientName NVARCHAR(100) = ''
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
	      -- Інформація про пацієнта
        p.full_name,
        a.id_doctor,
        d.name_doctor,
        d.specialization ,

        a.id_episode,
        e.diagnosis,

        a.id_medical_card,

        a.description_action ,
        a.data_time ,
        a.id_procedure,
        a.id_medication,

        -- Інформація про процедуру
        pc.name_procedure ,

        -- Інформація про ліки
        m.name_medication ,

        -- Інформація про відділення
        dep.name_department

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
    WHERE
        @PatientName = '' OR p.full_name LIKE '%' + @PatientName + '%'
    ORDER BY 
        a.data_time DESC;
END;
GO
