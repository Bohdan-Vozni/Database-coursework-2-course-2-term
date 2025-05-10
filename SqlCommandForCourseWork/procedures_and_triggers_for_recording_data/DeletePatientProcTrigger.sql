USE Helsi;
GO

-- Видаляємо процедуру, якщо існує
IF EXISTS (SELECT name FROM sys.objects WHERE name = 'UpdatePatientProc' AND type = 'P')
DROP PROCEDURE UpdatePatientProc;
GO

-- Створюємо процедуру без перевірок
CREATE PROCEDURE UpdatePatientProc
    @id_patient CHAR(36),
    @full_name VARCHAR(MAX),
    @date_of_bith DATE,
    @phone_number VARCHAR(MAX),
    @address_patient VARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Patient
    SET 
        full_name = @full_name,
        date_of_birth = @date_of_bith,
        phone_number = @phone_number,
        address_patient = @address_patient
    WHERE id_patient = @id_patient;
END;
GO


-- Видаляємо тригер, якщо існує
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_PreventDuplicatePatientOnUpdate')
DROP TRIGGER trg_PreventDuplicatePatientOnUpdate;
GO

-- Створюємо тригер для перевірки дублювання
CREATE TRIGGER trg_PreventDuplicatePatientOnUpdate
ON Patient
INSTEAD OF UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Перевірка чи є інший пацієнт з таким самим ім'ям і датою народження
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Patient p ON i.full_name = p.full_name
                      AND i.date_of_birth = p.date_of_birth
                      AND i.id_patient <> p.id_patient
    )
    BEGIN
        RAISERROR('Оновлення не виконано: існує інший пацієнт з таким самим ім''ям та датою народження.', 16, 1);
        RETURN;
    END

    -- Якщо все гаразд — виконуємо оновлення
    UPDATE Patient
    SET 
        full_name = i.full_name,
        date_of_birth = i.date_of_birth,
        phone_number = i.phone_number,
        address_patient = i.address_patient
    FROM inserted i
    WHERE Patient.id_patient = i.id_patient;
END;
GO
