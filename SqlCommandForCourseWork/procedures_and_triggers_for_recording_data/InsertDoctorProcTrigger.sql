USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertDoctorProc')
DROP PROCEDURE InsertDoctorProc;
GO

CREATE PROCEDURE InsertDoctorProc
    @id_doctor CHAR(36),
    @id_department CHAR(36),
    @name_doctor NVARCHAR(MAX),
    @specialization NVARCHAR(MAX),
    @phone_number NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO Doctor (
        id_doctor,
        id_department,
        name_doctor,
        specialization,
        phone_number
    )
    VALUES (
        @id_doctor,
        @id_department,
        @name_doctor,
        @specialization,
        @phone_number
    );
END;
GO


-- Видаляємо тригер якщо існує
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_PreventInvalidDoctorInsert')
DROP TRIGGER trg_PreventInvalidDoctorInsert;
GO

CREATE TRIGGER trg_PreventInvalidDoctorInsert
ON Doctor
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Перевірка чи всі вставлені записи мають існуюче відділення
    IF EXISTS (
        SELECT 1
        FROM inserted i
        LEFT JOIN Department d ON i.id_department = d.id_department
        WHERE d.id_department IS NULL
    )
    BEGIN
        RAISERROR('Не вдалося додати лікаря: відділення з таким ID не існує.', 16, 1);
        RETURN;
    END

    -- Перевірка чи номер телефону вже існує
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Doctor d ON i.phone_number = d.phone_number
    )
    BEGIN
        RAISERROR('Не вдалося додати лікаря: лікар з таким номером телефону вже існує.', 16, 1);
        RETURN;
    END

    -- Якщо все гаразд — вставка
    INSERT INTO Doctor (id_doctor, id_department, name_doctor, specialization, phone_number)
    SELECT id_doctor, id_department, name_doctor, specialization, phone_number
    FROM inserted;
END;
GO
