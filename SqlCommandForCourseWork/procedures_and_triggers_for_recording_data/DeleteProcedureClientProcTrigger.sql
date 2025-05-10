USE Helsi;
GO

-- ��������� ������� ��'����, ���� ���� �
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'DeleteProcedureClientProc')
DROP PROCEDURE DeleteProcedureClientProc;
GO

-- ��������� ��������� ��������� ��� ��������
CREATE PROCEDURE DeleteProcedureClientProc
    @id_procedure CHAR(36)
AS
BEGIN
    SET NOCOUNT ON;
    
    DELETE FROM Procedure_Client 
    WHERE id_procedure = @id_procedure;
END;
GO

-- ��������� ������, ���� �� ����
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_PreventProcedureClientDeleteIfReferenced')
DROP TRIGGER trg_PreventProcedureClientDeleteIfReferenced;
GO

-- ��������� ������, ���� �������� �������� ����������� � ������� Action_ISPS
CREATE TRIGGER trg_PreventProcedureClientDeleteIfReferenced
ON Procedure_Client
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- �������� �� ��������� ��������������� � ������� Action_ISPS
    IF EXISTS (
        SELECT 1 
        FROM deleted d
        JOIN Action_ISPS a ON d.id_procedure = a.id_procedure
    )
    BEGIN
        RAISERROR('��������� �������� ���������, ������� ������� 䳿, ������� � ���� ����������. �������� ������� �� 䳿.', 16, 1);
        RETURN;
    END
    
    -- ���� ���� ��������� ������ � �������� ��������
    DELETE FROM Procedure_Client
    WHERE id_procedure IN (SELECT id_procedure FROM deleted);
END;
GO
