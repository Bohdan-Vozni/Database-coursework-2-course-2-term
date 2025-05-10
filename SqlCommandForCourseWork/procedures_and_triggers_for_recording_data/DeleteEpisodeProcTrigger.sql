USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'DeleteEpisodeProc')
DROP PROCEDURE DeleteEpisodeProc;
GO

CREATE PROCEDURE DeleteEpisodeProc
    @id_episode CHAR(36),
    @id_medical_card CHAR(36)
AS
BEGIN
     DELETE FROM Episode
    WHERE id_medical_card = @id_medical_card and id_episode = @id_episode
END;
GO


IF EXISTS (SELECT name FROM sys.triggers WHERE name = 'TRG_DeleteEpisode_ViaMedicalCard')
    DROP TRIGGER TRG_DeleteEpisode_ViaMedicalCard;
GO

CREATE TRIGGER TRG_DeleteEpisode_ViaMedicalCard
ON Episode
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- ���������� �� � ������ � Action_ISPS, ������� � �������
    IF EXISTS (
        SELECT 1
        FROM Action_ISPS A
        INNER JOIN deleted D 
            ON A.id_episode = D.id_episode
           AND A.id_medical_card = D.id_medical_card
    )
    BEGIN
        RAISERROR('��������� �������� �����, ������� ������� ������� 䳿. �������� ������� ��.', 16, 1);
        RETURN;
    END

    -- ���� ���� ��������� �� � �������� �������� �����
    DELETE E
    FROM Episode E
    INNER JOIN deleted D 
        ON E.id_medical_card = D.id_medical_card
       AND E.id_episode = D.id_episode
END
GO
