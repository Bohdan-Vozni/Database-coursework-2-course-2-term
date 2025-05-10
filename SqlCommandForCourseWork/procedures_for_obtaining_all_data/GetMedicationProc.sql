USE Helsi;
GO

-- Спочатку видаляємо процедуру, якщо існує
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetMedicationProc')
    DROP PROCEDURE GetMedicationProc;
GO

-- Створюємо процедуру з параметром пошуку
CREATE PROCEDURE GetMedicationProc
    @MedicationName NVARCHAR(100) = ''
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        id_medication,
        name_medication AS 'Назва медикаменту',
        manufacturer AS 'Виробник',
        description_medication AS 'Опис медикаменту',
        expiration_date AS 'Дата придатності'
    FROM 
        Medication
    WHERE
        @MedicationName = '' OR name_medication LIKE '%' + @MedicationName + '%'
    ORDER BY 
        name_medication;
END;
GO
