USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetIdProcedureWithNameProc')
DROP PROCEDURE GetIdProcedureWithNameProc;
GO

CREATE PROCEDURE GetIdProcedureWithNameProc
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        id_procedure AS ProcedureId,
        name_procedure AS ProcedureName
    FROM 
        Procedure_Client
    ORDER BY 
        name_procedure;
END;
GO