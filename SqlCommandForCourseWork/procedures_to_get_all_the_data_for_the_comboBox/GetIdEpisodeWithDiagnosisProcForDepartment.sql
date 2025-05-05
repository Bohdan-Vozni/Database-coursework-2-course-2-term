--USE Helsi;
--GO

--IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetIdEpisodeWithDiaagnosisProc')
--DROP PROCEDURE GetIdEpisodeWithDiaagnosisProc;
--GO

--CREATE PROCEDURE GetIdEpisodeWithDiaagnosisProc
--AS
--BEGIN
--    SET NOCOUNT ON;
    
--    SELECT 
--        id_episode AS EpisodeId,
--        diagnosis AS Diagnosis
--    FROM 
--        Episode
--    ORDER BY 
--        diagnosis;
--END;
--GO

USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetIdEpisodeWithDiaagnosisProc')
DROP PROCEDURE GetIdEpisodeWithDiaagnosisProc;
GO

CREATE PROCEDURE GetIdEpisodeWithDiaagnosisProc
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        e.id_episode AS EpisodeId,
        e.diagnosis AS Diagnosis,
        e.id_medical_card AS MedicalCardId,
        mc.date_created AS CardDateCreated,
        p.full_name AS PatientName
    FROM 
        Episode e
    INNER JOIN 
        Medical_card mc ON e.id_medical_card = mc.id_medical_card
    INNER JOIN
        Patient p ON mc.id_patient = p.id_patient
    ORDER BY 
        e.diagnosis;
END;
GO