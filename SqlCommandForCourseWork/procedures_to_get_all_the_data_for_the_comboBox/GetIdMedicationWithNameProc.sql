USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetIdMedicationWithNameProc')
DROP PROCEDURE GetIdMedicationWithNameProc;
GO

CREATE PROCEDURE GetIdMedicationWithNameProc
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        id_medication AS MedicationId,
        name_medication AS MedicationName,
        manufacturer AS Manufacturer
    FROM 
        Medication
    ORDER BY 
        name_medication;
END;
GO