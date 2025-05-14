USE Helsi;
GO



-- Drop the procedure if it exists
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetExpiringMedicationsFromView')
    DROP PROCEDURE GetExpiringMedicationsFromView;
GO

-- Create the procedure
CREATE PROCEDURE GetExpiringMedicationsFromView
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        "����� ���",
        "��������",
        "����� ����������",
        DATEDIFF(day, GETDATE(), "����� ����������") AS "���������� ���"
    FROM 
        vw_ExpiringMedications
    WHERE 
        "����� ����������" BETWEEN GETDATE() AND DATEADD(month, 3, GETDATE())
    ORDER BY 
        "����� ����������";
END;
GO
