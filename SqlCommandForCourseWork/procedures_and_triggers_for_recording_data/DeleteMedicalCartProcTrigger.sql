use Helsi;
GO

if exists ( select name from sys.objects where name = 'DeleteMedicalCardProc')
	drop procedure DeleteMedicalCardProc;
go

CREATE PROCEDURE DeleteMedicalCardProc
    @id_medical_card CHAR(36)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- ��������� ������� ������
        DELETE FROM Medical_card
        WHERE id_medical_card = @id_medical_card;
        
        -- ����������, �� ���� �������� ���� � ���� �����
        IF @@ROWCOUNT = 0
        BEGIN
            RAISERROR('������� ������ � �������� ID �� ��������', 16, 1);
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