use Helsi
go

--INSERT INTO Department (id_department, name_department, description_department)
--VALUES ('2x', 'Хірургія', '2 поверх'); -- Викине RAISERROR
--go

--Exec ShowToNumber @value1 = 20 ;
--Exec selectData_Medication @value_manufacturer = 'GSK';
Exec proc_UpdateInfoDepartment @ID = '1', @valueName = 'Терапевтичне відділення' ,@valueDescription ='Відділення для лікування загальних захворювань та надання первинної медичної допомоги.';

--Exec AddNewMedication @name_medication ='Парацетамол 1',@manufacturer = 'дарниця 1', @expiration_date ='2029-03-19', @description_medication = 'Від темпаратури'