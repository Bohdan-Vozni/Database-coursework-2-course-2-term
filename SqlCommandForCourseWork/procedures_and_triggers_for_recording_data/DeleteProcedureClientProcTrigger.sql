USE Helsi;
GO

-- Видаляємо існуючі об'єкти, якщо вони є
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'DeleteProcedureClientProc')
DROP PROCEDURE DeleteProcedureClientProc;
GO

-- Створюємо процедуру видалення без перевірок
CREATE PROCEDURE DeleteProcedureClientProc
    @id_procedure CHAR(36)
AS
BEGIN
    SET NOCOUNT ON;
    
    DELETE FROM Procedure_Client 
    WHERE id_procedure = @id_procedure;
END;
GO

-- Видаляємо тригер, якщо він існує
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_PreventProcedureClientDeleteIfReferenced')
DROP TRIGGER trg_PreventProcedureClientDeleteIfReferenced;
GO

-- Створюємо тригер, який перевіряє наявність залежностей в таблиці Action_ISPS
CREATE TRIGGER trg_PreventProcedureClientDeleteIfReferenced
ON Procedure_Client
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Перевірка чи процедура використовується в таблиці Action_ISPS
    IF EXISTS (
        SELECT 1 
        FROM deleted d
        JOIN Action_ISPS a ON d.id_procedure = a.id_procedure
    )
    BEGIN
        RAISERROR('Неможливо видалити процедуру, оскільки існують дії, пов’язані з цією процедурою. Спочатку видаліть ці дії.', 16, 1);
        RETURN;
    END
    
    -- Якщо немає пов’язаних записів — безпечно видалити
    DELETE FROM Procedure_Client
    WHERE id_procedure IN (SELECT id_procedure FROM deleted);
END;
GO
