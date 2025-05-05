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
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        ---- �������� ��������� �� ���'���� ������ � Action_ISPS
        --DELETE FROM Action_ISPS 
        --WHERE id_episode = @id_episode 
        --AND id_medical_card = @id_medical_card;
        
        -- ���� ��������� ��� �����
        DELETE FROM Episode 
        WHERE id_episode = @id_episode 
        AND id_medical_card = @id_medical_card;
        
        -- ����������, �� ���� ���� ��������
        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR('����� � ��������� ID �� ��������', 16, 1);
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