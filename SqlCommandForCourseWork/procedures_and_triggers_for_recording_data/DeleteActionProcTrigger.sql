USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'DeleteActionProc')
DROP PROCEDURE DeleteActionProc;
GO

CREATE PROCEDURE DeleteActionProc
    @id_doctor CHAR(36),
    @id_episode CHAR(36),
    @id_medical_card CHAR(36)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- ��������� 䳿
        DELETE FROM Action_ISPS
        WHERE 
            id_doctor = @id_doctor AND
            id_episode = @id_episode AND
            id_medical_card = @id_medical_card;
        
        -- ��������, �� ���� �������� �����
        IF @@ROWCOUNT = 0
        BEGIN
            SELECT 0 AS Result, 'ĳ� �� �������� ��� ���������' AS Message;
        END
        ELSE
        BEGIN
            SELECT 1 AS Result, 'ĳ� ������ ��������' AS Message;
        END
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
            
        -- ��������� ����������� ��� �������
        SELECT 0 AS Result, 
               '������� ��� �������� 䳿: ' + ERROR_MESSAGE() AS Message;
    END CATCH
END;
GO