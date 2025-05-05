USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'DeleteDoctorProc')
DROP PROCEDURE DeleteDoctorProc;
GO

CREATE PROCEDURE DeleteDoctorProc
    @id_doctor CHAR(36)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Перевірка існування лікаря
        IF NOT EXISTS (SELECT 1 FROM Doctor WHERE id_doctor = @id_doctor)
        BEGIN
            RAISERROR('Лікар з вказаним ID не знайдений', 16, 1);
            RETURN;
        END
        
        -- Видалення пов'язаних записів з Action_ISPS (якщо необхідно)
        DELETE FROM Action_ISPS WHERE id_doctor = @id_doctor;
        
        -- Видалення лікаря
        DELETE FROM Doctor WHERE id_doctor = @id_doctor;
        
        -- Перевірка, чи було видалено запис
        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR('Не вдалося видалити лікаря', 16, 1);
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