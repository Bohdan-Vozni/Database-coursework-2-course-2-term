USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateActionProc')
DROP PROCEDURE UpdateActionProc;
GO

CREATE PROCEDURE UpdateActionProc
    @id_doctor CHAR(36),
    @id_episode CHAR(36),
    @id_medical_card CHAR(36),
    @new_description_action NVARCHAR(MAX),
    @new_data_time DATE,
    @new_id_procedure CHAR(36) = NULL,
    @new_id_medication CHAR(36) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Оновлення дії
        UPDATE Action_ISPS
        SET 
            description_action = @new_description_action,
            data_time = @new_data_time,
            id_procedure = @new_id_procedure,
            id_medication = @new_id_medication
        WHERE 
            id_doctor = @id_doctor AND
            id_episode = @id_episode AND
            id_medical_card = @id_medical_card;
        
        -- Перевірка, чи було оновлено запис
        IF @@ROWCOUNT = 0
        BEGIN
            SELECT 0 AS Result, 'Дію не знайдено для оновлення' AS Message;
        END
        ELSE
        BEGIN
            SELECT 1 AS Result, 'Дію успішно оновлено' AS Message;
        END
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
            
        -- Повертаємо повідомлення про помилку
        SELECT 0 AS Result, 
               'Помилка при оновленні дії: ' + ERROR_MESSAGE() AS Message;
    END CATCH
END;
GO