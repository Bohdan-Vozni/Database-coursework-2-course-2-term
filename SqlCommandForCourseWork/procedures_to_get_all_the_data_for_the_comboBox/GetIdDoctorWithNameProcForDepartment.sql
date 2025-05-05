USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetIdDoctorWithNameProc')
DROP PROCEDURE GetIdDoctorWithNameProc;
GO

CREATE PROCEDURE GetIdDoctorWithNameProc
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        id_doctor AS DoctorId,
        name_doctor AS DoctorName
    FROM 
        Doctor
    ORDER BY 
        name_doctor;
END;
GO