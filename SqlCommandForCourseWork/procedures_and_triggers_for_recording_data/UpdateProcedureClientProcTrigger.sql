USE Helsi;
GO

-- First drop existing objects if they exist
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateProcedureClientProc')
DROP PROCEDURE UpdateProcedureClientProc;
GO


-- Create the update procedure without checks
CREATE PROCEDURE UpdateProcedureClientProc
    @id_procedure CHAR(36),
    @name_procedure NVARCHAR(MAX),
    @description_procedure NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE Procedure_Client 
    SET 
        name_procedure = @name_procedure,
        description_procedure = @description_procedure
    WHERE 
        id_procedure = @id_procedure;
END;
GO


IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_PreventDuplicateProcedureClientUpdate')
DROP TRIGGER trg_PreventDuplicateProcedureClientUpdate;
GO
-- Create the trigger that handles duplicate checking for updates
CREATE TRIGGER trg_PreventDuplicateProcedureClientUpdate
ON Procedure_Client
INSTEAD OF UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Check if the update would create a duplicate procedure name (excluding current record)
    IF EXISTS (
        SELECT 1 
        FROM inserted i
        JOIN Procedure_Client pc ON i.name_procedure = pc.name_procedure
        WHERE pc.id_procedure <> i.id_procedure  -- Exclude the current record
    )
    BEGIN
        RAISERROR('Процедура з такою назвою вже існує', 16, 1);
        RETURN;
    END
    
    -- If no duplicates, proceed with update
    UPDATE pc
    SET 
        pc.name_procedure = i.name_procedure,
        pc.description_procedure = i.description_procedure
    FROM 
        Procedure_Client pc
    INNER JOIN 
        inserted i ON pc.id_procedure = i.id_procedure;
END;
GO