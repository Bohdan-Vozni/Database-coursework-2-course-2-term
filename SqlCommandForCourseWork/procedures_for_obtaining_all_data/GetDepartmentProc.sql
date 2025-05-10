USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetAllDepartmentProc')
    DROP PROCEDURE GetAllDepartmentProc;
GO

CREATE PROCEDURE GetAllDepartmentProc
    @DepartmentName NVARCHAR(100) = ''
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        id_department,
        name_department AS 'Назва відділення',
        description_department AS 'Опис відділення'
    FROM 
        Department
    WHERE
        @DepartmentName = '' OR name_department LIKE '%' + @DepartmentName + '%'
	ORDER BY 
        name_department;
END;
GO
