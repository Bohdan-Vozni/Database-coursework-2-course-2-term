USE Helsi;
GO

IF EXISTS (SELECT name FROM sys.objects WHERE name = 'InsertMedicalCardProc' AND type = 'P')
DROP PROCEDURE InsertMedicalCardProc;
GO

USE Helsi;
GO

IF EXISTS (SELECT name FROM sys.objects WHERE name = 'InsertMedicalCardProc' AND type = 'P')
DROP PROCEDURE InsertMedicalCardProc;
GO

CREATE PROCEDURE InsertMedicalCardProc
    @id_medical_card CHAR(36),
    @id_patient CHAR(36),
    @declaration_doctor NVARCHAR(MAX),
    @date_created DATE,
    @status_card NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO Medical_card (
        id_medical_card,
        id_patient,
        declaration_doctor,
        date_created,
        status_card
    )
    VALUES (
        @id_medical_card,
        @id_patient,
        @declaration_doctor,
        @date_created,
        @status_card
    );
END;
GO


-- ��������� ������ ���� ����
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_PreventDuplicateMedicalCardPerPatient')
DROP TRIGGER trg_PreventDuplicateMedicalCardPerPatient;
GO

-- ��������� ������ ��� �������� ���������� ������ �� ��������
CREATE TRIGGER trg_PreventDuplicateMedicalCardPerPatient
ON Medical_card
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- ��������: �� ��� ���� ������� ������ ��� ��������
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Medical_card m ON i.id_patient = m.id_patient
    )
    BEGIN
        RAISERROR('� ����� �������� ��� � ������� ������.', 16, 1);
        RETURN;
    END

    -- ���� ��� ������ � �������� �������
    INSERT INTO Medical_card (id_medical_card, id_patient, declaration_doctor, date_created, status_card)
    SELECT id_medical_card, id_patient, declaration_doctor, date_created, status_card
    FROM inserted;
END;
GO
