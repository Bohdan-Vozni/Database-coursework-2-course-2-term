use Helsi;
GO


if exists (select name from sys.objects where name = 'InsertPatientProc')
drop procedure InsertPatientProc
GO

create procedure InsertPatientProc
@id_patient char(36) = '',
@full_name varchar(max)  = '',
@date_of_bith date,
@phone_number  varchar(max) = '',
@address_patient varchar(max) = ''

as
begin 

	 INSERT INTO Patient (id_patient, full_name, date_of_birth, phone_number, address_patient)
    VALUES (@id_patient, @full_name, @date_of_bith, @phone_number, @address_patient);

end
GO

USE Helsi;
GO

IF EXISTS (SELECT name FROM sys.triggers WHERE name = 'InsertPatientTrig')
    DROP TRIGGER InsertPatientTrig;
GO

CREATE TRIGGER InsertPatientTrig
ON Patient
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- ����������, �� ��� � ����� �������
    IF EXISTS (
        SELECT 1
        FROM Patient p
        INNER JOIN inserted i
            ON p.full_name = i.full_name
            AND p.date_of_birth = i.date_of_birth
           
    )
    BEGIN
        -- ���� � � �������� �������
        RAISERROR ('������� � ������ ϲ�, ����� ���������� � ������� �������� ��� ����!', 16, 1);
        RETURN;
    END

    -- ���� ������ �������� ���� � ���������� �������
    INSERT INTO Patient (id_patient, full_name, date_of_birth, phone_number, address_patient)
    SELECT id_patient, full_name, date_of_birth, phone_number, address_patient
    FROM inserted;
END
GO
