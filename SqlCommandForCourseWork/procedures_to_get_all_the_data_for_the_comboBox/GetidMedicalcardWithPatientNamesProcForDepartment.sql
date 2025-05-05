USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetMedicalCardsWithPatientNamesProc')
DROP PROCEDURE GetMedicalCardsWithPatientNamesProc;
GO

CREATE PROCEDURE GetMedicalCardsWithPatientNamesProc
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        mc.id_medical_card,
        p.full_name
    FROM 
        Medical_card mc
    INNER JOIN 
        Patient p ON mc.id_patient = p.id_patient
    ORDER BY 
        p.full_name;
END;
GO