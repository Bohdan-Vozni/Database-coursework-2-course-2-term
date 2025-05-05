USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'DeleteActionProc')
DROP PROCEDURE DeleteActionProc;
GO

CREATE PROCEDURE DeleteActionProc
    @id_doctor CHAR(36),
    @id_episode CHAR(36),
    @id_medical_card CHAR(36)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Видалення дії
        DELETE FROM Action_ISPS
        WHERE 
            id_doctor = @id_doctor AND
            id_episode = @id_episode AND
            id_medical_card = @id_medical_card;
        
        -- Перевірка, чи було видалено запис
        IF @@ROWCOUNT = 0
        BEGIN
            SELECT 0 AS Result, 'Дію не знайдено для видалення' AS Message;
        END
        ELSE
        BEGIN
            SELECT 1 AS Result, 'Дію успішно видалено' AS Message;
        END
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
            
        -- Повертаємо повідомлення про помилку
        SELECT 0 AS Result, 
               'Помилка при видаленні дії: ' + ERROR_MESSAGE() AS Message;
    END CATCH
END;
GO