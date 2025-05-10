USE Helsi;
GO

IF EXISTS (SELECT name FROM sys.objects WHERE name = 'DeletePatientProc' AND type = 'P')
DROP PROCEDURE DeletePatientProc;
GO

CREATE PROCEDURE DeletePatientProc
    @id_patient CHAR(36)
AS
BEGIN
    DELETE FROM Patient
    WHERE id_patient = @id_patient;
END
GO


IF EXISTS (SELECT name FROM sys.triggers WHERE name = 'TRG_Prevent_Delete_Patient_If_Has_MedicalCard')
    DROP TRIGGER TRG_Prevent_Delete_Patient_If_Has_MedicalCard;
GO

CREATE TRIGGER TRG_Prevent_Delete_Patient_If_Has_MedicalCard
ON Patient
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- ���������� �� � ������ ������, ������� � ���������
    IF EXISTS (
        SELECT 1
        FROM Medical_card M
        INNER JOIN deleted D ON M.id_patient = D.id_patient
    )
    BEGIN
        RAISERROR('��������� �������� ��������, ������� ������� ������� ������ ������. �������� ������� ��.', 16, 1);
        RETURN;
    END

    -- ���� ���� ��������� �������� ������ � �������� �������� ��������
    DELETE FROM Patient
    WHERE id_patient IN (SELECT id_patient FROM deleted);
END
GO