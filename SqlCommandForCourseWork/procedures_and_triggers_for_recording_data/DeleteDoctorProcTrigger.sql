USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'DeleteDoctorProc')
DROP PROCEDURE DeleteDoctorProc;
GO

CREATE PROCEDURE DeleteDoctorProc
    @id_doctor CHAR(36)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- �������� ��������� �����
        IF NOT EXISTS (SELECT 1 FROM Doctor WHERE id_doctor = @id_doctor)
        BEGIN
            RAISERROR('˳��� � �������� ID �� ���������', 16, 1);
            RETURN;
        END
        
        -- ��������� ���'������ ������ � Action_ISPS (���� ���������)
        DELETE FROM Action_ISPS WHERE id_doctor = @id_doctor;
        
        -- ��������� �����
        DELETE FROM Doctor WHERE id_doctor = @id_doctor;
        
        -- ��������, �� ���� �������� �����
        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR('�� ������� �������� �����', 16, 1);
        END
        
        COMMIT TRANSACTION;
        
        SELECT 'Success' AS Result;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
            
        SELECT 
            'Error' AS Result,
            ERROR_MESSAGE() AS ErrorMessage,
            ERROR_NUMBER() AS ErrorNumber;
    END CATCH
END;
GO