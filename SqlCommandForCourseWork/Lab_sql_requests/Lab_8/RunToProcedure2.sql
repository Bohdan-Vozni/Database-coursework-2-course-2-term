use Helsi
go

--INSERT INTO Department (id_department, name_department, description_department)
--VALUES ('2x', 'ճ�����', '2 ������'); -- ������ RAISERROR
--go

--Exec ShowToNumber @value1 = 20 ;
--Exec selectData_Medication @value_manufacturer = 'GSK';
Exec proc_UpdateInfoDepartment @ID = '1', @valueName = '������������ ��������' ,@valueDescription ='³������� ��� �������� ��������� ����������� �� ������� �������� ������� ��������.';

--Exec AddNewMedication @name_medication ='����������� 1',@manufacturer = '������� 1', @expiration_date ='2029-03-19', @description_medication = '³� �����������'