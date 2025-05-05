--use Helsi;


--insert into Patient(id_patient, full_name,date_of_birth,phone_number,address_patient)
-- values ('1','Іванов Іван Іванович','2025-04-05','0960849073','Київ')


use Helsi;
GO

if exists ( select name from sys.objects where name = 'GetAllPatientsProc')
	drop procedure GetAllPatientsProc;
go

create procedure GetAllPatientsProc

as
begin 
	select * from Patient
	ORDER BY 
        full_name DESC;
end
go