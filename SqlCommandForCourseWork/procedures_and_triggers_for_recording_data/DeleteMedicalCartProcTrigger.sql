use Helsi;
GO

if exists ( select name from sys.objects where name = 'DeleteMedicalCardProc')
	drop procedure DeleteMedicalCardProc;
go

CREATE PROCEDURE DeleteMedicalCardProc
    @id_medical_card CHAR(36)
AS
BEGIN
    DELETE FROM Medical_card
    WHERE id_medical_card = @id_medical_card;
END;
GO




IF EXISTS (SELECT name FROM sys.triggers WHERE name = 'TRG_Prevent_Delete_MedicalCard_With_Episode')
    DROP TRIGGER TRG_Prevent_Delete_MedicalCard_With_Episode;
GO

CREATE TRIGGER TRG_Prevent_Delete_MedicalCard_With_Episode
ON Medical_card
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Перевіряємо чи є епізоди, які посилаються на медкартку
    IF EXISTS (
        SELECT 1
        FROM Episode E
        INNER JOIN deleted D ON E.id_medical_card = D.id_medical_card
    )
    BEGIN
        RAISERROR('Неможливо видалити медичну картку, оскільки існують пов’язані епізоди. Спочатку видаліть їх.', 16, 1);
        RETURN;
    END

    -- Якщо немає залежних епізодів — безпечно видаляти картку
    DELETE FROM Medical_card
    WHERE id_medical_card IN (SELECT id_medical_card FROM deleted);
END
GO