USE Helsi;
GO

-- ��������� ���������, ���� ����
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'DeleteDepartmentProc')
DROP PROCEDURE DeleteDepartmentProc;
GO

-- ��������� ������, ���� ����
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_PreventDepartmentDeletion')
DROP TRIGGER trg_PreventDepartmentDeletion;
GO

-- ��������� ��������� ��������� ²�Ĳ�����
CREATE PROCEDURE DeleteDepartmentProc
    @id_department CHAR(36)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Department 
    WHERE id_department = @id_department;
END;
GO

-- ��������� ������, ���� ����� ���������, ���� � ������� ����
CREATE TRIGGER trg_PreventDepartmentDeletion
ON Department
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- ���������� �� � ���� � ����� �������
    IF EXISTS (
        SELECT 1 
        FROM Doctor d
        INNER JOIN deleted del ON d.id_department = del.id_department
    )
    BEGIN
        RAISERROR('��������� �������� ��������, ������� �� ����� ��������� ����. �������� ������� ��� ��������� �����.', 16, 1);
        RETURN;
    END

    -- ���� ���� ��������� ����� � �������� �������� ��������
    DELETE FROM Department
    WHERE id_department IN (SELECT id_department FROM deleted);
END;
GO
