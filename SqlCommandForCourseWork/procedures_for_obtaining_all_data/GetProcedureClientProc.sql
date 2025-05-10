USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetProcedureClientProc')
    DROP PROCEDURE GetProcedureClientProc;
GO

CREATE PROCEDURE GetProcedureClientProc
    @ProcedureName NVARCHAR(100) = ''
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        SELECT 
            id_procedure,
            name_procedure AS 'Назва процедури',
            description_procedure AS 'Опис процедури'
        FROM 
            Procedure_Client
        WHERE
            @ProcedureName = '' OR name_procedure LIKE '%' + @ProcedureName + '%'
        ORDER BY 
            name_procedure;
    END TRY
    BEGIN CATCH
        SELECT 
            ERROR_NUMBER() AS ErrorNumber,
            ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
GO
