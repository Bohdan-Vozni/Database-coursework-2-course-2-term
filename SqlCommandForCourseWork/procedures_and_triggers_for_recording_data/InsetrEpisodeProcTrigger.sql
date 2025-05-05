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
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Перевірка існування медичної картки
        IF NOT EXISTS (SELECT 1 FROM Medical_card WHERE id_medical_card = @id_medical_card)
        BEGIN
            RAISERROR('Медична картка з вказаним ID не знайдена', 16, 1);
            RETURN;
        END
        
        -- Додавання нового епізоду
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