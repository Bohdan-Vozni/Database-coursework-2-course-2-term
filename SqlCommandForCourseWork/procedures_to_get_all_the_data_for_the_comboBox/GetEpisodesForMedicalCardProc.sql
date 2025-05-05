USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetEpisodesForMedicalCardProc')
DROP PROCEDURE GetEpisodesForMedicalCardProc;
GO

CREATE PROCEDURE GetEpisodesForMedicalCardProc
    @MedicalCardId CHAR(36)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        id_episode AS EpisodeId,
        diagnosis AS Diagnosis
    FROM 
        Episode
    WHERE 
        id_medical_card = @MedicalCardId
    ORDER BY 
        diagnosis;
END;
GO