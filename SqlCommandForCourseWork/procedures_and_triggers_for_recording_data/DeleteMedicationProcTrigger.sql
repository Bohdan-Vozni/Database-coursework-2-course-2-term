USE Helsi;
GO

-- ��������� ������, ���� ����
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_PreventMedicationDeleteIfReferenced')
DROP TRIGGER trg_PreventMedicationDeleteIfReferenced;
GO

-- ��������� ������, ���� ����� ���������, ���� � ������� ������
CREATE TRIGGER trg_PreventMedicationDeleteIfReferenced
ON Medication
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- ���������� �� ���������� ��������������� � ��� (Action_ISPS)
    IF EXISTS (
        SELECT 1 
        FROM Action_ISPS a
        INNER JOIN deleted d ON a.id_medication = d.id_medication
    )
    BEGIN
        RAISERROR('��������� �������� ����������, ������� ������� 䳿, ������� � ��� ������������. �������� ������� ��.', 16, 1);
        RETURN;
    END

    -- ���� ���� ��������� ������ � �������� �������� ����������
    DELETE FROM Medication
    WHERE id_medication IN (SELECT id_medication FROM deleted);
END;
GO
