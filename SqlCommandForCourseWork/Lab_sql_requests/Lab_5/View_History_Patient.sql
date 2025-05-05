USE Helsi;
GO

IF EXISTS (SELECT name FROM sys.objects WHERE name = 'History_Patient')
DROP VIEW History_Patient;
GO

CREATE VIEW History_Patient AS
SELECT
	p.id_patient,
	pc.name_procedure,
	m.name_medication,
	a.data_time

FROM Patient p, Medical_card mc, Action_ISPS a, Procedure_Client pc, Medication m
WHERE 
    p.id_patient = mc.id_patient
    AND mc.id_medical_card = a.id_medical_card
    AND a.id_procedure = pc.id_procedure
    AND a.id_medication = m.id_medication;
go

--містить історію пацієнта