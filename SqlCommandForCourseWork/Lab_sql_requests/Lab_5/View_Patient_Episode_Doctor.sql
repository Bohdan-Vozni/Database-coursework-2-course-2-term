use Helsi;
go 

if exists (select name from sys.objects where name = 'Episode_Patient_Doctor' )
drop view Episode_Patient_Doctor;
go

create view Episode_Patient_Doctor as
select 
	e.id_episode,
	e.diagnosis,
	coalesce(e.description_diagnosis, 'NULL') AS description_diagnosis,
	p.full_name,
	d.name_doctor

FROM Episode e, Medical_card mc, Patient p, Action_ISPS a, Doctor d
WHERE e.id_medical_card = mc.id_medical_card
AND mc.id_patient = p.id_patient
AND e.id_episode = a.id_episode
AND a.id_doctor = d.id_doctor;
go

--показує всі епізоди пацієнта і його доктора який лікував