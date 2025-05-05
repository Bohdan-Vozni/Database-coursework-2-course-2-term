USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateEpisodeProc')
DROP PROCEDURE UpdateEpisodeProc;
GO

CREATE PROCEDURE UpdateEpisodeProc
    @id_episode CHAR(36),
    @id_medical_card CHAR(36),
    @diagnosis NVARCHAR(MAX),
    @description_diagnosis NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- �������� ��������� ������
        IF NOT EXISTS (
            SELECT 1 
            FROM Episode 
            WHERE id_episode = @id_episode 
            AND id_medical_card = @id_medical_card
        )
        BEGIN
            RAISERROR('����� � �������� ID �� ��������', 16, 1);
            RETURN;
        END
        
        -- ��������� ����� ������
        UPDATE Episode
        SET 
            diagnosis = @diagnosis,
            description_diagnosis = @description_diagnosis
        WHERE 
            id_episode = @id_episode
            AND id_medical_card = @id_medical_card;
        
        -- ��������, �� ���� �������� �����
        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR('�� ������� ������� �����', 16, 1);
        END
        
        COMMIT TRANSACTION;
        
        SELECT 'Success' AS Result;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
            
        SELECT 
            'Error' AS Result,
            ERROR_MESSAGE() AS ErrorMessage,
            ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END;
GO