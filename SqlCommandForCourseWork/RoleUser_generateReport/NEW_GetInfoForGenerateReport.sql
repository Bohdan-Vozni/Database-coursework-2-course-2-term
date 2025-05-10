USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetFilteredFullDataReport')
DROP PROCEDURE GetFilteredFullDataReport;
GO

CREATE PROCEDURE GetFilteredFullDataReport
    @PatientName NVARCHAR(100) = NULL,
    @BirthDateStart DATE = NULL,
    @BirthDateEnd DATE = NULL,
    
    @Diagnosis NVARCHAR(200) = NULL,
    
    @DoctorName NVARCHAR(100) = NULL,
    
    @MedicationName NVARCHAR(100) = NULL,
    @Manufacturer NVARCHAR(100) = NULL,
    @MedicationExpirationStart DATE = NULL,
    @MedicationExpirationEnd DATE = NULL,
    
    @ProcedureName NVARCHAR(100) = NULL,
    
    @DepartmentName NVARCHAR(100) = NULL,
    
    @ActionDateStart DATE = NULL,
    @ActionDateEnd DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @SQL NVARCHAR(MAX);
    DECLARE @ParamDef NVARCHAR(MAX);

    SET @SQL = N'SELECT 
                    p.id_patient,
                    p.full_name AS full_name_patient,
                    p.date_of_birth,
                    p.phone_number AS patient_phone,
                    p.address_patient,
                    
                    mc.id_medical_card,
                    mc.declaration_doctor,
                    mc.date_created,
                    mc.status_card,
                    
                    e.id_episode,
                    e.diagnosis,
                    e.description_diagnosis,
                    
                    a.description_action,
                    a.data_time AS action_date,
                    
                    d.id_doctor,
                    d.name_doctor,
                    d.specialization,
                    d.phone_number AS doctor_phone,
                    
                    dep.id_department,
                    dep.name_department,
                    dep.description_department,
                    
                    m.id_medication,
                    m.name_medication,
                    m.manufacturer,
                    m.description_medication,
                    m.expiration_date,
                    
                    pr.id_procedure,
                    pr.name_procedure,
                    pr.description_procedure
                FROM 
                    Patient p
                LEFT JOIN Medical_card mc ON p.id_patient = mc.id_patient
                LEFT JOIN Episode e ON mc.id_medical_card = e.id_medical_card
                LEFT JOIN Action_ISPS a ON e.id_episode = a.id_episode AND e.id_medical_card = a.id_medical_card
                LEFT JOIN Doctor d ON a.id_doctor = d.id_doctor
                LEFT JOIN Department dep ON d.id_department = dep.id_department
                LEFT JOIN Medication m ON a.id_medication = m.id_medication
                LEFT JOIN Procedure_Client pr ON a.id_procedure = pr.id_procedure
                WHERE 1 = 1';

    -- Фільтри
    IF @PatientName IS NOT NULL
        SET @SQL = @SQL + ' AND p.full_name LIKE ''%'' + @PatientName + ''%''';
        
    IF @BirthDateStart IS NOT NULL
        SET @SQL = @SQL + ' AND p.date_of_birth >= @BirthDateStart';
    
    IF @BirthDateEnd IS NOT NULL
        SET @SQL = @SQL + ' AND p.date_of_birth <= @BirthDateEnd';
    
    IF @Diagnosis IS NOT NULL
        SET @SQL = @SQL + ' AND e.diagnosis LIKE ''%'' + @Diagnosis + ''%''';
    
    IF @DoctorName IS NOT NULL
        SET @SQL = @SQL + ' AND d.name_doctor LIKE ''%'' + @DoctorName + ''%''';
    
    IF @MedicationName IS NOT NULL
        SET @SQL = @SQL + ' AND m.name_medication LIKE ''%'' + @MedicationName + ''%''';
    
    IF @Manufacturer IS NOT NULL
        SET @SQL = @SQL + ' AND m.manufacturer LIKE ''%'' + @Manufacturer + ''%''';
    
    IF @MedicationExpirationStart IS NOT NULL
        SET @SQL = @SQL + ' AND m.expiration_date >= @MedicationExpirationStart';
    
    IF @MedicationExpirationEnd IS NOT NULL
        SET @SQL = @SQL + ' AND m.expiration_date <= @MedicationExpirationEnd';
    
    IF @ProcedureName IS NOT NULL
        SET @SQL = @SQL + ' AND pr.name_procedure LIKE ''%'' + @ProcedureName + ''%''';
    
    IF @DepartmentName IS NOT NULL
        SET @SQL = @SQL + ' AND dep.name_department LIKE ''%'' + @DepartmentName + ''%''';
    
    IF @ActionDateStart IS NOT NULL
        SET @SQL = @SQL + ' AND a.data_time >= @ActionDateStart';
    
    IF @ActionDateEnd IS NOT NULL
        SET @SQL = @SQL + ' AND a.data_time <= @ActionDateEnd';

    -- Оголошення параметрів для sp_executesql
    SET @ParamDef = N'
        @PatientName NVARCHAR(100),
        @BirthDateStart DATE,
        @BirthDateEnd DATE,
        @Diagnosis NVARCHAR(200),
        @DoctorName NVARCHAR(100),
        @MedicationName NVARCHAR(100),
        @Manufacturer NVARCHAR(100),
        @MedicationExpirationStart DATE,
        @MedicationExpirationEnd DATE,
        @ProcedureName NVARCHAR(100),
        @DepartmentName NVARCHAR(100),
        @ActionDateStart DATE,
        @ActionDateEnd DATE';

    -- Виконання динамічного SQL
    EXEC sp_executesql 
        @SQL, 
        @ParamDef,
        @PatientName,
        @BirthDateStart,
        @BirthDateEnd,
        @Diagnosis,
        @DoctorName,
        @MedicationName,
        @Manufacturer,
        @MedicationExpirationStart,
        @MedicationExpirationEnd,
        @ProcedureName,
        @DepartmentName,
        @ActionDateStart,
        @ActionDateEnd;

END;
GO

-- Виклик (без параметрів — виведе всі записи)
EXEC GetFilteredFullDataReport;
GO
