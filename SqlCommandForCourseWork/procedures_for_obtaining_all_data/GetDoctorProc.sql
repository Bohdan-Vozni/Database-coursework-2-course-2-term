USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetAllDoctorProc')
    DROP PROCEDURE GetAllDoctorProc;
GO

CREATE PROCEDURE GetAllDoctorProc
    @DoctorName NVARCHAR(100) = ''
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        d.id_doctor,
        d.id_department,
		d.name_doctor AS 'ПІБ Доктора',
        dep.name_department AS 'Назва відділення',     
        d.specialization AS 'Спеціалізація доктора',
        d.phone_number AS 'Номер телефону'
    FROM 
        Doctor d
    INNER JOIN 
        Department dep ON d.id_department = dep.id_department
    WHERE
        @DoctorName = '' OR d.name_doctor LIKE '%' + @DoctorName + '%'
    ORDER BY 
        d.name_doctor;
END;
GO
