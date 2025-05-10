USE Helsi;
GO

-- First drop existing objects if they exist
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertProcedureClientProc')
DROP PROCEDURE InsertProcedureClientProc;
GO


-- Create the insert procedure without checks
CREATE PROCEDURE InsertProcedureClientProc
    @id_procedure CHAR(36),
    @name_procedure NVARCHAR(MAX),
    @description_procedure NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO Procedure_Client (id_procedure, name_procedure, description_procedure)
    VALUES (@id_procedure, @name_procedure, @description_procedure);
END;
GO



IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_PreventDuplicateProcedureClient')
DROP TRIGGER trg_PreventDuplicateProcedureClient;
GO
-- Create the trigger that handles duplicate checking
CREATE TRIGGER trg_PreventDuplicateProcedureClient
ON Procedure_Client
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Check for existing procedures with the same name
    IF EXISTS (
        SELECT 1 
        FROM inserted i
        JOIN Procedure_Client pc ON i.name_procedure = pc.name_procedure
    )
    BEGIN
        RAISERROR('Procedure with this name already exists', 16, 1);
        RETURN;
    END
    
    -- If no duplicates, proceed with insert
    INSERT INTO Procedure_Client (id_procedure, name_procedure, description_procedure)
    SELECT id_procedure, name_procedure, description_procedure
    FROM inserted;
END;
GO