USE Helsi;
GO

IF EXISTS (SELECT name FROM sys.objects WHERE name = 'View_Patient_Treatments') 
DROP VIEW dbo.View_Patient_Treatments;
GO

CREATE VIEW View_Patient_Treatments AS 
SELECT
    p.id_patient,
    p.full_name,
    (SELECT pr.name_procedure 
     FROM Procedure_Client pr 
     WHERE pr.id_procedure = a.id_procedure) AS name_procedure,
    (SELECT m.name_medication 
     FROM Medication m 
     WHERE m.id_medication = a.id_medication) AS name_medication,
    a.data_time
FROM Patient p, Medical_card mc, Action_ISPS a
WHERE p.id_patient = mc.id_patient
AND mc.id_medical_card = a.id_medical_card;
go

--відображає всі процедури та призначені медикаменти для кожного пацієнта разом із датою проведення.