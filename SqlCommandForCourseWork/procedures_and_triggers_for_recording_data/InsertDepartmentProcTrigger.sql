USE Helsi;
GO

-- First drop the procedure if it exists
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertDepartmentProc')
DROP PROCEDURE InsertDepartmentProc;
GO

-- Create the insert procedure without checks
CREATE PROCEDURE InsertDepartmentProc
    @id_department CHAR(36),
    @name_department NVARCHAR(MAX),
    @description_department NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO Department (id_department, name_department, description_department)
    VALUES (@id_department, @name_department, @description_department);
END;
GO



-- Then drop the trigger if it exists
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_PreventDuplicateDepartment')
DROP TRIGGER trg_PreventDuplicateDepartment;
GO
-- Create the trigger that handles duplicate checking
CREATE TRIGGER trg_PreventDuplicateDepartment
ON Department
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Check for existing departments with the same name
    IF EXISTS (
        SELECT 1 
        FROM inserted i
        JOIN Department d ON i.name_department = d.name_department
    )
    BEGIN
        RAISERROR('Department with this name already exists', 16, 1);
        RETURN;
    END
    
    -- If no duplicates, proceed with insert
    INSERT INTO Department (id_department, name_department, description_department)
    SELECT id_department, name_department, description_department
    FROM inserted;
END;
GO