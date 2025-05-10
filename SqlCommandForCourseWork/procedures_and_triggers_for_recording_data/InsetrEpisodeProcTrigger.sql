USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertEpisodeProc')
DROP PROCEDURE InsertEpisodeProc;
GO

CREATE PROCEDURE InsertEpisodeProc
    @id_episode CHAR(36),
    @id_medical_card CHAR(36),
    @diagnosis NVARCHAR(MAX),
    @description_diagnosis NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO Episode (
        id_episode,
        id_medical_card,
        diagnosis,
        description_diagnosis
    )
    VALUES (
        @id_episode,
        @id_medical_card,
        @diagnosis,
        @description_diagnosis
    );
END;
GO


-- ��������� ������ ���� ����
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_PreventInsertEpisodeWithoutMedicalCard')
DROP TRIGGER trg_PreventInsertEpisodeWithoutMedicalCard;
GO

CREATE TRIGGER trg_PreventInsertEpisodeWithoutMedicalCard
ON Episode
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- �������� �� �� �������� ������ ����� ������� ������� ������
    IF EXISTS (
        SELECT 1
        FROM inserted i
        LEFT JOIN Medical_card m ON i.id_medical_card = m.id_medical_card
        WHERE m.id_medical_card IS NULL
    )
    BEGIN
        RAISERROR('�� ������� ������ �����: ������� ������ � ����� ID �� ����.', 16, 1);
        RETURN;
    END

    -- ���� �������� ��������, �������� �������
    INSERT INTO Episode (id_episode, id_medical_card, diagnosis, description_diagnosis)
    SELECT id_episode, id_medical_card, diagnosis, description_diagnosis
    FROM inserted;
END;
GO
