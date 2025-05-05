USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateActionProc')
DROP PROCEDURE UpdateActionProc;
GO

CREATE PROCEDURE UpdateActionProc
    @id_doctor CHAR(36),
    @id_episode CHAR(36),
    @id_medical_card CHAR(36),
    @new_description_action NVARCHAR(MAX),
    @new_data_time DATE,
    @new_id_procedure CHAR(36) = NULL,
    @new_id_medication CHAR(36) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- ��������� 䳿
        UPDATE Action_ISPS
        SET 
            description_action = @new_description_action,
            data_time = @new_data_time,
            id_procedure = @new_id_procedure,
            id_medication = @new_id_medication
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