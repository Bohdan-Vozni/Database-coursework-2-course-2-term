if exists ( select name from sys.objects where name = 'GetAllEpisodeProc')
	drop procedure GetAllEpisodeProc;
go

CREATE PROCEDURE GetAllEpisodeProc
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        e.id_episode,
        e.id_medical_card,
        p.full_name AS 'Імя пацієнта',
        mc.date_created AS 'дата створення мед картки',
        e.diagnosis  AS 'Діагноз',
        e.description_diagnosis AS 'Опис діагноза'
        --d.name_doctor AS attending_doctor,
        --dep.name_department AS department_name,
        --COUNT(a.id_episode) AS action_count
    FROM 
        Episode e
    INNER JOIN 
        Medical_card mc ON e.id_medical_card = mc.id_medical_card
    INNER JOIN 
        Patient p ON mc.id_patient = p.id_patient
    LEFT JOIN 
        Action_ISPS a ON e.id_episode = a.id_episode AND e.id_medical_card = a.id_medical_card
    LEFT JOIN 
        Doctor d ON a.id_doctor = d.id_doctor
    LEFT JOIN 
        Department dep ON d.id_department = dep.id_department
    GROUP BY 
        e.id_episode,
        e.id_medical_card,
        p.full_name,
        mc.date_created,
        e.diagnosis,
        e.description_diagnosis,
        d.name_doctor,
        dep.name_department
    ORDER BY 
        mc.date_created DESC;
END;
GO