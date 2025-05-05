use Helsi;
GO

if exists ( select name from sys.objects where name = 'UpdateMedicalCardProc')
	drop procedure UpdateMedicalCardProc;
go

CREATE PROCEDURE UpdateMedicalCardProc
    @id_medical_card CHAR(36),
    @id_patient CHAR(36),
    @declaration_doctor NVARCHAR(MAX),
    @date_created NVARCHAR(MAX),
    @status_card NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Оновлення медичної картки
        UPDATE Medical_card
        SET 
            id_patient = @id_patient,
            declaration_doctor = @declaration_doctor,
            date_created = @date_created,
            status_card = @status_card
        WHERE 
            id_medical_card = @id_medical_card;
        
        -- Перевіряємо, чи було оновлено хоча б один рядок
        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR('Медична картка з вказаним ID не знайдена', 16, 1);
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



IF EXISTS (SELECT name FROM sys.triggers WHERE name = 'trg_CheckMedicalCardExists')
    DROP TRIGGER trg_CheckMedicalCardExists;
GO

CREATE TRIGGER trg_CheckMedicalCardExists
ON Medical_card
INSTEAD OF UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Перевіряємо чи існує така пара id_medical_card + id_patient
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Patient p ON p.id_patient = i.id_patient
        WHERE i.id_medical_card IS NOT NULL
    )
    BEGIN
        -- Якщо існує — виконуємо оновлення
        UPDATE mc
        SET 
            id_patient = i.id_patient,
            declaration_doctor = i.declaration_doctor,
            date_created = i.date_created,
            status_card = i.status_card
        FROM Medical_card mc
        JOIN inserted i ON mc.id_medical_card = i.id_medical_card;
    END
    ELSE
    BEGIN
        RAISERROR('Не знайдено пацієнта для оновлення медичної картки', 16, 1);
    END
END
GO
