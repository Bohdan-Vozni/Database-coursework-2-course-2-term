USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetAllMedicalCardProc')
    DROP PROCEDURE GetAllMedicalCardProc;
GO

CREATE PROCEDURE GetAllMedicalCardProc
    @PatientName NVARCHAR(100) = ''
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        mc.id_medical_card,
        mc.id_patient,
        p.full_name,
        mc.declaration_doctor,
        mc.date_created,
        mc.status_card
    FROM 
        Medical_card mc
    INNER JOIN 
        Patient p ON mc.id_patient = p.id_patient
    WHERE
        @PatientName = '' OR p.full_name LIKE '%' + @PatientName + '%'
    ORDER BY 
        mc.date_created DESC;
END;
GO




---- ��������� 4 �������� �������� ������ �� ������� Medical_card
--INSERT INTO Medical_card (id_medical_card, id_patient, declaration_doctor, date_created, status_card)
--VALUES
--    -- ����� ������� ������
--    ('550e8400-e29b-41d4-a716-446655440000', '30e08917-8ed5-4a28-ba31-20bc59459ac0', 
--     'ĳ�����: ��². ����������: ������� �����, ������� ���, �����������.', 
--     '2023-01-15', '�������'),
     
--    -- ����� ������� ������
--    ('550e8400-e29b-41d4-a716-446655440002', '30e08917-8ed5-4a28-ba31-20bc59459ac0', 
--     'ĳ�����: ó�������. ����������: �������� �����, �������� 5 ��.', 
--     '2023-02-20', '�������'),
     
--    -- ����� ������� ������
--    ('550e8400-e29b-41d4-a716-446655440004', '30e08917-8ed5-4a28-ba31-20bc59459ac0', 
--     'ĳ�����: �������� ����� 2 ����. ����������: 䳺��, �������� 500 ��.', 
--     '2023-03-10', '�������'),
     
--    -- �������� ������� ������
--    ('550e8400-e29b-41d4-a716-446655440006', '30e08917-8ed5-4a28-ba31-20bc59459ac0', 
--     'ĳ�����: ���������� ����. ����������: ����������� ���������.', 
--     '2023-04-05', '�������');
