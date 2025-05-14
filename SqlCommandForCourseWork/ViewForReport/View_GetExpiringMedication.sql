USE Helsi;
GO

-- Drop the view if it exists
IF OBJECT_ID('vw_ExpiringMedications', 'V') IS NOT NULL
    DROP VIEW vw_ExpiringMedications;
GO

-- Create the view
CREATE VIEW vw_ExpiringMedications AS
SELECT 
    name_medication AS "����� ���",
    manufacturer AS "��������",
    expiration_date AS "����� ����������"
FROM 
    Medication;
GO
