USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateDoctorProc')
DROP PROCEDURE UpdateDoctorProc;
GO

CREATE PROCEDURE UpdateDoctorProc
    @id_doctor CHAR(36),
    @id_department CHAR(36),
    @name_doctor NVARCHAR(MAX),
    @specialization NVARCHAR(MAX),
    @phone_number NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        -- ��������� ����� �������
        UPDATE Doctor SET
            id_department = @id_department,
            name_doctor = @name_doctor,
            specialization = @specialization,
            phone_number = @phone_number
        WHERE 
            id_doctor = @id_doctor;
        
        -- ��������, �� ���� �������� �����
        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR('������ � �������� ID �� ���������', 16, 1);
        END
        ELSE
        BEGIN
            SELECT 'Success' AS Result, '��� ������� ������ ��������' AS Message;
        END
    END TRY
    BEGIN CATCH
        SELECT 
            'Error' AS Result,
            ERROR_MESSAGE() AS ErrorMessage,
            ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END;
GO

IF EXISTS (SELECT name FROM sys.triggers WHERE name = 'UpdateDoctorTrig')
    DROP TRIGGER UpdateDoctorTrig;
GO

CREATE TRIGGER UpdateDoctorTrig
ON Doctor
INSTEAD OF UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- ���������� ���������� �������� (��� ��������� �������)
    IF EXISTS (
        SELECT 1
        FROM Doctor d
        INNER JOIN inserted i ON d.phone_number = i.phone_number AND d.id_doctor <> i.id_doctor
    )
    BEGIN
        RAISERROR('������ � ����� ������� �������� ��� ����!', 16, 1);
        RETURN;
    END

    -- ���������� ��������� ��������
    IF EXISTS (
        SELECT 1
        FROM inserted i
        WHERE NOT EXISTS (SELECT 1 FROM Department WHERE id_department = i.id_department)
    )
    BEGIN
        RAISERROR('������� �������� �� ����!', 16, 1);
        RETURN;
    END

    -- ���� �� �������� ������� - �������� ���������
    UPDATE d SET
        d.id_department = i.id_department,
        d.name_doctor = i.name_doctor,
        d.specialization = i.specialization,
        d.phone_number = i.phone_number
    FROM 
        Doctor d
    INNER JOIN 
        inserted i ON d.id_doctor = i.id_doctor;
END
GO