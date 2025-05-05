USE Helsi;
GO

IF EXISTS (SELECT name FROM sys.objects WHERE name = 'UpdatePatientProc' AND type = 'P')
DROP PROCEDURE UpdatePatientProc;
GO

CREATE PROCEDURE UpdatePatientProc
    @id_patient CHAR(36),
    @full_name VARCHAR(MAX),
    @date_of_bith DATE,
    @phone_number VARCHAR(MAX),
    @address_patient VARCHAR(MAX)
AS
BEGIN
    -- ѕерев≥рка чи Ї ≥нший пац≥Їнт з таким самим ≥м'€м ≥ датою народженн€
    IF EXISTS (
        SELECT 1
        FROM Patient
        WHERE full_name = @full_name
          AND date_of_birth = @date_of_bith
          
    )
    BEGIN
        PRINT 'ќновленн€ не виконано: ≥снуЇ ≥нший пац≥Їнт з таким самим ≥м''€м та датою народженн€.';
        RETURN;
    END

    -- якщо перев≥рка пройдена Ч оновлюЇмо
    UPDATE Patient
    SET 
        full_name = @full_name,
        date_of_birth = @date_of_bith,
        phone_number = @phone_number,
        address_patient = @address_patient
    WHERE id_patient = @id_patient;
END
GO
