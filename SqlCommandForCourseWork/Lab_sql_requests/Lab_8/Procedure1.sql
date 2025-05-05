-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
use Helsi
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

if object_id('AddNewMedication','p') is not null
	drop procedure AddNewMedication
go

CREATE PROCEDURE AddNewMedication
    @name_medication nVARCHAR(max),
    @manufacturer nVARCHAR(max),
    @expiration_date DATE,
    @description_medication nVARCHAR(max)
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM Medication
        WHERE name_medication = @name_medication AND manufacturer = @manufacturer
    )
    BEGIN
        RAISERROR('Цей медикамент уже існує.', 16, 1)
        RETURN
    END

    INSERT INTO Medication (id_medication ,name_medication, manufacturer, expiration_date, description_medication)
    VALUES (CAST(NEWID() as char(36)), @name_medication, @manufacturer, @expiration_date, @description_medication)
END
go



if object_id('proc_UpdateInfoDepartment','p') is not null
	drop procedure proc_UpdateInfoDepartment 
go
create procedure proc_UpdateInfoDepartment
	@ID nvarchar(max) = 0,
	@valueName  nvarchar(max) = '',
	@valueDescription nvarchar(max) = ''
as 
begin 

	set nocount on;

	update Department
	set name_department = @valueName,
	description_department = @valueDescription
	Where id_department = @ID


end 
go




if object_id('selectData_Medication','p') is not null 
	drop procedure selectData_Medication
go

create procedure selectData_Medication
	@value_manufacturer nvarchar(max) = ''

as 
begin

	set nocount on;

	select *
	from Medication
	where manufacturer = @value_manufacturer

end
go