USE Helsi;
GO

-- Видаляємо тригер, якщо існує
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_PreventMedicationDeleteIfReferenced')
DROP TRIGGER trg_PreventMedicationDeleteIfReferenced;
GO

-- Створюємо тригер, який блокує видалення, якщо є пов’язані записи
CREATE TRIGGER trg_PreventMedicationDeleteIfReferenced
ON Medication
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Перевіряємо чи медикамент використовується у діях (Action_ISPS)
    IF EXISTS (
        SELECT 1 
        FROM Action_ISPS a
        INNER JOIN deleted d ON a.id_medication = d.id_medication
    )
    BEGIN
        RAISERROR('Неможливо видалити медикамент, оскільки існують дії, пов’язані з цим медикаментом. Спочатку видаліть їх.', 16, 1);
        RETURN;
    END

    -- Якщо немає пов’язаних записів — безпечно видалити медикамент
    DELETE FROM Medication
    WHERE id_medication IN (SELECT id_medication FROM deleted);
END;
GO
