USE Helsi;
GO

-- ��������� ������� ��������� ���� �
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertActionProc')
DROP PROCEDURE InsertActionProc;
GO

-- ��������� ��������� ��� ��������
CREATE PROCEDURE InsertActionProc
    @id_doctor CHAR(36),
    @id_episode CHAR(36),
    @id_medical_card CHAR(36),
    @description_action NVARCHAR(MAX),
    @data_time DATE,
    @id_procedure CHAR(36) = NULL,
    @id_medication CHAR(36) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO Action_ISPS (
        id_doctor,
        id_episode,
        id_medical_card,
        description_action,
        data_time,
        id_procedure,
        id_medication
    )
    VALUES (
        @id_doctor,
        @id_episode,
        @id_medical_card,
        @description_action,
        @data_time,
        @id_procedure,
        @id_medication
    );
END;
GO

-- ��������� ������ ���� ����
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_PreventDuplicateActionInsert')
DROP TRIGGER trg_PreventDuplicateActionInsert;
GO

-- ��������� ������, ���� �������� �������� ������ � ������ � id_doctor, id_episode, id_medical_card
CREATE TRIGGER trg_PreventDuplicateActionInsert
ON Action_ISPS
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- ����������, �� ��� ���� ���� ���������
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Action_ISPS a
          ON i.id_doctor = a.id_doctor
         AND i.id_episode = a.id_episode
         AND i.id_medical_card = a.id_medical_card
    )
    BEGIN
        RAISERROR('ĳ� � ����� ������, ������� � �������� ������� ��� ����.', 16, 1);
        RETURN;
    END

    -- ���� ���� ��������� ���� � �������� �������
    INSERT INTO Action_ISPS (
        id_doctor,
        id_episode,
        id_medical_card,
        description_action,
        data_time,
        id_procedure,
        id_medication
    )
    SELECT
        id_doctor,
        id_episode,
        id_medical_card,
        description_action,
        data_time,
        id_procedure,
        id_medication
    FROM inserted;
END;
GO
