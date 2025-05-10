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


-- ��������� ������ ���� ����
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_PreventInvalidDoctorInsert')
DROP TRIGGER trg_PreventInvalidDoctorInsert;
GO

CREATE TRIGGER trg_PreventInvalidDoctorInsert
ON Doctor
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- �������� �� �� �������� ������ ����� ������� ��������
    IF EXISTS (
        SELECT 1
        FROM inserted i
        LEFT JOIN Department d ON i.id_department = d.id_department
        WHERE d.id_department IS NULL
    )
    BEGIN
        RAISERROR('�� ������� ������ �����: �������� � ����� ID �� ����.', 16, 1);
        RETURN;
    END

    -- �������� �� ����� �������� ��� ����
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Doctor d ON i.phone_number = d.phone_number
    )
    BEGIN
        RAISERROR('�� ������� ������ �����: ���� � ����� ������� �������� ��� ����.', 16, 1);
        RETURN;
    END

    -- ���� ��� ������ � �������
    INSERT INTO Doctor (id_doctor, id_department, name_doctor, specialization, phone_number)
    SELECT id_doctor, id_department, name_doctor, specialization, phone_number
    FROM inserted;
END;
GO
