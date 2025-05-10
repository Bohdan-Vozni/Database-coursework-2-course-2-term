USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetAllActionProc')
    DROP PROCEDURE GetAllActionProc;
GO

CREATE PROCEDURE GetAllActionProc
    @PatientName NVARCHAR(100) = ''
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
	      -- ���������� ��� ��������
        p.full_name AS '��� ��������',
        a.id_doctor,
        d.name_doctor AS '��� �������',
        d.specialization AS '������������ �������',

        a.id_episode,
        e.diagnosis AS 'ĳ�����',

        a.id_medical_card,

        a.description_action AS '���� 䳿',
        a.data_time AS '���� 䳿',
        a.id_procedure,
        a.id_medication,

        -- ���������� ��� ���������
        pc.name_procedure AS '��������� �� �����������',

        -- ���������� ��� ���
        m.name_medication AS '����� ���',

        -- ���������� ��� ��������
        dep.name_department AS '³�������'

    FROM 
        Action_ISPS a
    LEFT JOIN 
        Doctor d ON a.id_doctor = d.id_doctor
    LEFT JOIN 
        Department dep ON d.id_department = dep.id_department
    LEFT JOIN 
        Episode e ON a.id_episode = e.id_episode AND a.id_medical_card = e.id_medical_card
    LEFT JOIN 
        Medical_card mc ON e.id_medical_card = mc.id_medical_card
    LEFT JOIN 
        Patient p ON mc.id_patient = p.id_patient
    LEFT JOIN 
        Procedure_Client pc ON a.id_procedure = pc.id_procedure
    LEFT JOIN 
        Medication m ON a.id_medication = m.id_medication
    WHERE
        @PatientName = '' OR p.full_name LIKE '%' + @PatientName + '%'
    ORDER BY 
        a.data_time DESC;
END;
GO
