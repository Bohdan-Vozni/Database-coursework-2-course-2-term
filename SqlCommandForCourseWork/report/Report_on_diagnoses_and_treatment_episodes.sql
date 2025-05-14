USE Helsi;
GO

-- Drop the procedure if it exists
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetPatientDiagnosisInfo')
    DROP PROCEDURE GetPatientDiagnosisInfo;
GO

CREATE PROCEDURE GetPatientDiagnosisInfo
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * 
    FROM View_on_diagnoses_and_treatment_episodes
    ORDER BY "Діагноз", "Пацієнт";
END;
