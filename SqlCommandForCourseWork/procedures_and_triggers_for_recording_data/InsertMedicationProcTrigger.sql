USE Helsi;
GO

-- First drop existing objects if they exist
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertMedicationProc')
DROP PROCEDURE InsertMedicationProc;
GO


-- Create the insert procedure without checks
CREATE PROCEDURE InsertMedicationProc
    @id_medication CHAR(36),
    @name_medication NVARCHAR(MAX),
    @manufacturer NVARCHAR(MAX),
    @description_medication NVARCHAR(MAX) = NULL,
    @expiration_date DATE
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO Medication (
        id_medication,
        name_medication,
        manufacturer,
        description_medication,
        expiration_date
    )
    VALUES (
        @id_medication,
        @name_medication,
        @manufacturer,
        @description_medication,
        @expiration_date
    );
END;
GO


USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_PreventDuplicateMedication')
DROP TRIGGER trg_PreventDuplicateMedication;
GO

CREATE TRIGGER trg_PreventDuplicateMedication
ON Medication
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Check 1: Verify expiration date is in the future
    IF EXISTS (
        SELECT 1 
        FROM inserted 
        WHERE expiration_date <= GETDATE()
    )
    BEGIN
        RAISERROR('Срок придатності медикаменту має бути більшим за поточну дату', 16, 1);
        RETURN;
    END
    
    -- Check 2: Verify medication with same name and manufacturer doesn't exist
    IF EXISTS (
        SELECT 1 
        FROM inserted i
        JOIN Medication m ON 
            i.name_medication = m.name_medication AND
            i.manufacturer = m.manufacturer
    )
    BEGIN
        RAISERROR('Медикамент з такою назвою і виробником вже існує', 16, 1);
        RETURN;
    END
    
    -- If all checks passed, proceed with insert
    INSERT INTO Medication (
        id_medication,
        name_medication,
        manufacturer,
        description_medication,
        expiration_date
    )
    SELECT 
        id_medication,
        name_medication,
        manufacturer,
        description_medication,
        expiration_date
    FROM inserted;
END;
GO