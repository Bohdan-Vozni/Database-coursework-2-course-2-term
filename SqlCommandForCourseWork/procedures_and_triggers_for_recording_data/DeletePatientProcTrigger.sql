USE Helsi;
GO

IF EXISTS (SELECT name FROM sys.objects WHERE name = 'DeletePatientProc' AND type = 'P')
DROP PROCEDURE DeletePatientProc;
GO

CREATE PROCEDURE DeletePatientProc
    @id_patient CHAR(36)
AS
BEGIN
    DELETE FROM Patient
    WHERE id_patient = @id_patient;
END
GO
