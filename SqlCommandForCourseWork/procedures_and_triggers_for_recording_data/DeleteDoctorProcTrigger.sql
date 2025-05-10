USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'DeleteDoctorProc')
DROP PROCEDURE DeleteDoctorProc;
GO

CREATE PROCEDURE DeleteDoctorProc
    @id_doctor CHAR(36)
AS
BEGIN
    
        DELETE FROM Doctor WHERE id_doctor = @id_doctor;
        
        
END;
GO

IF EXISTS (SELECT name FROM sys.triggers WHERE name = 'TRG_Prevent_Delete_Doctor_If_Linked')
    DROP TRIGGER TRG_Prevent_Delete_Doctor_If_Linked;
GO

CREATE TRIGGER TRG_Prevent_Delete_Doctor_If_Linked
ON Doctor
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Перевіряємо чи є записи Action_ISPS, що ссилаються на доктора
    IF EXISTS (
        SELECT 1
        FROM Action_ISPS A
        INNER JOIN deleted D ON A.id_doctor = D.id_doctor
    )
    BEGIN
        RAISERROR('Неможливо видалити лікаря, оскільки існують пов’язані дії. Спочатку видаліть їх.', 16, 1);
        RETURN;
    END

    -- Якщо немає пов’язаних записів — безпечно видалити лікаря
    DELETE FROM Doctor
    WHERE id_doctor IN (SELECT id_doctor FROM deleted);
END
GO