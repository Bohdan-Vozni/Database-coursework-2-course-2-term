USE Helsi;
GO

-- First drop existing objects if they exist
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateMedicationProc')
DROP PROCEDURE UpdateMedicationProc;
GO


-- Create the update procedure without checks
CREATE PROCEDURE UpdateMedicationProc
    @id_medication CHAR(36),
    @name_medication NVARCHAR(MAX),
    @manufacturer NVARCHAR(MAX),
    @description_medication NVARCHAR(MAX) = NULL,
    @expiration_date DATE
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE Medication 
    SET 
        name_medication = @name_medication,
        manufacturer = @manufacturer,
        description_medication = @description_medication,
        expiration_date = @expiration_date
    WHERE 
        id_medication = @id_medication;
END;
GO



IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_ValidateMedicationUpdate')
DROP TRIGGER trg_ValidateMedicationUpdate;
GO
-- Create the trigger that handles validation for updates
CREATE TRIGGER trg_ValidateMedicationUpdate
ON Medication
INSTEAD OF UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Check if the update would create a duplicate medication name
    IF EXISTS (
        SELECT 1 
        FROM inserted i
        JOIN Medication m ON i.name_medication = m.name_medication
        WHERE m.id_medication <> i.id_medication  -- Exclude the current record
    )
    BEGIN
        RAISERROR('Another medication with this name already exists', 16, 1);
        RETURN;
    END
    
    -- Check if expiration date is in the future
    IF EXISTS (
        SELECT 1 
        FROM inserted 
        WHERE expiration_date <= GETDATE()
    )
    BEGIN
        RAISERROR('Expiration date must be in the future', 16, 1);
        RETURN;
    END
    
    -- If all validations pass, proceed with update
    UPDATE m
    SET 
        m.name_medication = i.name_medication,
        m.manufacturer = i.manufacturer,
        m.description_medication = i.description_medication,
        m.expiration_date = i.expiration_date
    FROM 
        Medication m
    INNER JOIN 
        inserted i ON m.id_medication = i.id_medication;
END;
GO