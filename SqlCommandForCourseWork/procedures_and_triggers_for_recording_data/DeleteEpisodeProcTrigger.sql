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
        
        ---- Спочатку видаляємо всі пов'язані записи з Action_ISPS
        --DELETE FROM Action_ISPS 
        --WHERE id_episode = @id_episode 
        --AND id_medical_card = @id_medical_card;
        
        -- Потім видаляємо сам епізод
        DELETE FROM Episode 
        WHERE id_episode = @id_episode 
        AND id_medical_card = @id_medical_card;
        
        -- Перевіряємо, чи було щось видалено
        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR('Епізод з вказаними ID не знайдено', 16, 1);
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