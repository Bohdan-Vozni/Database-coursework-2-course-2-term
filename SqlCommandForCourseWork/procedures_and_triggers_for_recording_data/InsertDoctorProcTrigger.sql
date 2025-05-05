USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertDoctorProc')
DROP PROCEDURE InsertDoctorProc;
GO

CREATE PROCEDURE InsertDoctorProc
    @id_doctor CHAR(36),
    @id_department CHAR(36),
    @name_doctor NVARCHAR(MAX),
    @specialization NVARCHAR(MAX),
    @phone_number NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Перевірка існування відділення
        IF NOT EXISTS (SELECT 1 FROM Department WHERE id_department = @id_department)
        BEGIN
            RAISERROR('Відділення з вказаним ID не знайдено', 16, 1);
            RETURN;
        END
        
        -- Перевірка унікальності телефону
        IF EXISTS (SELECT 1 FROM Doctor WHERE phone_number = @phone_number)
        BEGIN
            RAISERROR('Лікар з таким номером телефону вже існує', 16, 1);
            RETURN;
        END
        
        -- Додавання нового лікаря
        INSERT INTO Doctor (
            id_doctor,
            id_department,
            name_doctor,
            specialization,
            phone_number
        )
        VALUES (
            @id_doctor,
            @id_department,
            @name_doctor,
            @specialization,
            @phone_number
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