use Helsi;
GO

if exists ( select name from sys.objects where name = 'InsertMedicalCardProc')
	drop procedure InsertMedicalCardProc;
go


CREATE PROCEDURE InsertMedicalCardProc
    @id_medical_card CHAR(36),
    @id_patient CHAR(36),
    @declaration_doctor NVARCHAR(MAX),
    @date_created DATE,
    @status_card NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Вставка нової медичної картки
        INSERT INTO Medical_card (
            id_medical_card,
            id_patient,
            declaration_doctor,
            date_created,
            status_card
        )
        VALUES (
            @id_medical_card,
            @id_patient,
            @declaration_doctor,
            @date_created,
            @status_card
        );
        
        COMMIT TRANSACTION;
        
        -- Повертаємо успішний результат
        SELECT 'Success' AS Result;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
            
        -- Повертаємо повідомлення про помилку
        SELECT 
            'Error' AS Result,
            ERROR_MESSAGE() AS ErrorMessage,
            ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END;
GO