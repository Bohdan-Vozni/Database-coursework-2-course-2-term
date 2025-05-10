USE Helsi;
GO

-- First drop existing objects if they exist
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateDepartmentProc')
DROP PROCEDURE UpdateDepartmentProc;
GO

-- Create the update procedure without checks
CREATE PROCEDURE UpdateDepartmentProc
    @id_department CHAR(36),
    @name_department NVARCHAR(MAX),
    @description_department NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE Department 
    SET 
        name_department = @name_department,
        description_department = @description_department
    WHERE 
        id_department = @id_department;
END;
GO



IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_PreventDuplicateDepartmentUpdate')
DROP TRIGGER trg_PreventDuplicateDepartmentUpdate;
GO

-- Create the trigger that handles duplicate checking for updates
CREATE TRIGGER trg_PreventDuplicateDepartmentUpdate
ON Department
INSTEAD OF UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Check if the update would create a duplicate name (excluding the current record being updated)
    IF EXISTS (
        SELECT 1 
        FROM inserted i
        JOIN Department d ON i.name_department = d.name_department
        WHERE d.id_department <> i.id_department  -- Exclude the current record
    )
    BEGIN
        RAISERROR('Another department with this name already exists', 16, 1);
        RETURN;
    END
    
    -- If no duplicates, proceed with update
    UPDATE d
    SET 
        d.name_department = i.name_department,
        d.description_department = i.description_department
    FROM 
        Department d
    INNER JOIN 
        inserted i ON d.id_department = i.id_department;
END;
GO

