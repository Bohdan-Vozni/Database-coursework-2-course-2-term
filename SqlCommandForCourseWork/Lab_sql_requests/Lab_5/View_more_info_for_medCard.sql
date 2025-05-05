use Helsi;
go

if exists (select name from sys.objects where name = 'more_info_for_medCard')
drop view  more_info_for_medCard;
go

create view more_info_for_medCard as
select 
	mc.id_medical_card,
	mc.date_created,
	p.full_name

FROM Medical_card mc, Patient p
WHERE mc.id_patient = p.id_patient;
go

--містить інформацію про пацієнта, його медичну картку, дати створення та статус картки.