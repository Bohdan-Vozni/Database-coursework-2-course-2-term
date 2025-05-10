USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetTopPatients')
DROP PROCEDURE GetTopPatients;
GO

CREATE PROCEDURE GetTopPatients
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        p.full_name AS "Пацієнт",
        COUNT(a.id_episode) AS "Кількість відвідувань"
    FROM 
        Patient p
    JOIN 
        Medical_card mc ON p.id_patient = mc.id_patient
    JOIN 
        Action_ISPS a ON mc.id_medical_card = a.id_medical_card
    WHERE 
        a.data_time BETWEEN DATEADD(year, -1, GETDATE()) AND GETDATE()
    GROUP BY 
        p.full_name
    ORDER BY 
        COUNT(a.id_episode) DESC;
END;
GO

-- Виклик
EXEC GetTopPatients;
