USE Helsi;
GO

-- �������� ��������� ���������, ���� ����
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetMedicationProc')
    DROP PROCEDURE GetMedicationProc;
GO

-- ��������� ��������� � ���������� ������
CREATE PROCEDURE GetMedicationProc
    @MedicationName NVARCHAR(100) = ''
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        id_medication,
        name_medication ,
        manufacturer ,
        description_medication ,
        expiration_date
    FROM 
        Medication
    WHERE
        @MedicationName = '' OR name_medication LIKE '%' + @MedicationName + '%'
    ORDER BY 
        name_medication;
END;
GO
