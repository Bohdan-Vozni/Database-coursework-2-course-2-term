USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'DeleteActionProc')
DROP PROCEDURE DeleteActionProc;
GO

CREATE PROCEDURE DeleteActionProc
    @id_doctor CHAR(36),
    @id_episode CHAR(36),
    @id_medical_card CHAR(36)
AS
BEGIN
    SET NOCOUNT ON;
    
    DELETE FROM Action_ISPS
    WHERE 
        id_doctor = @id_doctor AND
        id_episode = @id_episode AND
        id_medical_card = @id_medical_card;
END;
GO
