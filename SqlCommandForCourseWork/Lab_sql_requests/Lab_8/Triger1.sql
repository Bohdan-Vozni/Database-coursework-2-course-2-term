use Helsi


if object_id ('trg_CheckMedicationExpiration','tr' ) is not null
drop trigger trg_CheckMedicationExpiration
go
create trigger trg_CheckMedicationExpiration
on Medication
after insert
as
begin 

	if exists ( select 1 from inserted where expiration_date < GETDATE() )
		begin 
			RAISERROR('Неможливо додати медикамент з протермінованим терміном дії.', 16, 1)
			rollback TRANSACTION
		end
end
go

if object_id ('trg_UpdateInfoDepartment','tr' ) is not null
drop trigger trg_UpdateInfoDepartment
go
CREATE TRIGGER trg_UpdateInfoDepartment
ON Department
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Department d
            ON i.name_department = d.name_department
        WHERE d.id_department != i.id_department -- не співпадає ID
    )
    BEGIN
        RAISERROR('Неможливо вставити або оновити запис: відділення з такою назвою вже існує.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END
GO



if object_id ('trg_UpdateMedicalCardStatus','tr' ) is not null
drop trigger trg_UpdateMedicalCardStatus
go
create Trigger trg_UpdateMedicalCardStatus
on  Episode
after insert
as 
begin 
	Update Medical_card
	set status_card = 'Активна'
	where id_medical_card  in (select id_medical_card from inserted)
end
go