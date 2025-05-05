USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetAllDoctorProc')
DROP PROCEDURE GetAllDoctorProc;
GO

CREATE PROCEDURE GetAllDoctorProc
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        d.id_doctor,
        d.id_department,
        dep.name_department AS '����� ��������',  -- ������ ����� ��������
        d.name_doctor AS 'ϲ� �������',
        d.specialization AS '������������ �������',
        d.phone_number AS '����� ��������'
    FROM 
        Doctor d
    INNER JOIN 
        Department dep ON d.id_department = dep.id_department
    ORDER BY 
        d.name_doctor;
END;
GO