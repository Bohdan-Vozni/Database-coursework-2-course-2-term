USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetIdDepartmentWithNameProc')
DROP PROCEDURE GetIdDepartmentWithNameProc;
GO

CREATE PROCEDURE GetIdDepartmentWithNameProc
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        id_department AS idDepartment,  -- Аліас як у властивості класу
        name_department AS nameDepartment
    FROM 
        Department
    ORDER BY 
        name_department;
END;
GO