USE Helsi;
GO

-- Видаляємо процедуру, якщо існує
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'DeleteDepartmentProc')
DROP PROCEDURE DeleteDepartmentProc;
GO

-- Видаляємо тригер, якщо існує
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_PreventDepartmentDeletion')
DROP TRIGGER trg_PreventDepartmentDeletion;
GO

-- Створюємо процедуру видалення ВІДДІЛЕННЯ
CREATE PROCEDURE DeleteDepartmentProc
    @id_department CHAR(36)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Department 
    WHERE id_department = @id_department;
END;
GO

-- Створюємо тригер, який блокує видалення, якщо є пов’язані лікарі
CREATE TRIGGER trg_PreventDepartmentDeletion
ON Department
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Перевіряємо чи є лікарі в цьому відділенні
    IF EXISTS (
        SELECT 1 
        FROM Doctor d
        INNER JOIN deleted del ON d.id_department = del.id_department
    )
    BEGIN
        RAISERROR('Неможливо видалити відділення, оскільки до нього прикріплені лікарі. Спочатку видаліть або перенесіть лікарів.', 16, 1);
        RETURN;
    END

    -- Якщо немає пов’язаних лікарів — безпечно видалити відділення
    DELETE FROM Department
    WHERE id_department IN (SELECT id_department FROM deleted);
END;
GO
