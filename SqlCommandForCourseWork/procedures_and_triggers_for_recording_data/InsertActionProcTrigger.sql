USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertActionProc')
DROP PROCEDURE InsertActionProc;
GO

CREATE PROCEDURE InsertActionProc
    @id_doctor CHAR(36),
    @id_episode CHAR(36),
    @id_medical_card CHAR(36),
    @description_action NVARCHAR(MAX),
    @data_time date,
    @id_procedure CHAR(36) = NULL,
    @id_medication CHAR(36) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- ������� ���� 䳿
        INSERT INTO Action_ISPS (
            id_doctor,
            id_episode,
            id_medical_card,
            description_action,
            data_time,
            id_procedure,
            id_medication
        )
        VALUES (
            @id_doctor,
            @id_episode,
            @id_medical_card,
            @description_action,
            @data_time,
            @id_procedure,
            @id_medication
        );
        
        COMMIT TRANSACTION;
        
        -- ��������� ������� ���������
        SELECT 1 AS Result, 'ĳ� ������ ������' AS Message;
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