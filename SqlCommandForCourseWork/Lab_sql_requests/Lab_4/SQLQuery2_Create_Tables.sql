USE  Helsi;
GO
IF EXISTS (SELECT name FROM sys.objects WHERE  name = 'Action_ISPS')
DROP TABLE Action_ISPS;
GO

IF EXISTS (SELECT name FROM sys.objects WHERE name = 'Procedure_Client')
DROP TABLE Procedure_Client;
GO


IF EXISTS (SELECT name FROM sys.objects WHERE name = 'Medication')
DROP TABLE Medication;
GO

IF EXISTS (SELECT name FROM sys.objects WHERE name = 'Episode')
DROP TABLE Episode;
GO

IF EXISTS ( SELECT name FROM sys.objects WHERE name = 'Medical_card')
DROP TABLE Medical_card;
GO

IF EXISTS ( SELECT name FROM sys.objects WHERE name = 'Patient')
DROP TABLE Patient;
GO

IF EXISTS (SELECT name FROM sys.objects WHERE name = 'Doctor' )
DROP TABLE Doctor;
GO

IF EXISTS (SELECT name FROM sys.objects WHERE name = 'Department')
DROP TABLE Department;
GO



CREATE TABLE Department
(
	id_department CHAR(36) PRIMARY KEY ,
	name_department NVARCHAR(MAX) NOT NULL,
	description_department NVARCHAR(MAX) NOT NULL,
)
GO

CREATE TABLE Doctor 
(
	id_doctor CHAR(36) PRIMARY KEY ,
	id_department CHAR(36) NOT NULL,
	name_doctor NVARCHAR(MAX) NOT NULL,
	specialization NVARCHAR(MAX) NOT NULL,
	phone_number NVARCHAR(MAX) NOT NULL,

	FOREIGN KEY (id_department) REFERENCES Department(id_department)
);

GO

CREATE TABLE Patient 
(
	id_patient CHAR(36) PRIMARY KEY ,
	full_name NVARCHAR(MAX) NOT NULL,
	date_of_birth DATE NOT NULL,
	phone_number NVARCHAR(MAX) NOT NULL,
	address_patient NVARCHAR(MAX) NOT NULL

);
GO

CREATE TABLE Medical_card
(
	id_medical_card CHAR(36) PRIMARY KEY ,
	id_patient CHAR(36) NOT NULL,
	declaration_doctor NVARCHAR(MAX) NOT NULL,
	date_created NVARCHAR(MAX) NOT NULL,
	status_card NVARCHAR(MAX),

	FOREIGN KEY (id_patient) REFERENCES Patient(id_patient)
);
GO

CREATE TABLE Episode
(
	id_episode CHAR(36),
	id_medical_card CHAR(36) NOT NULL,
	diagnosis NVARCHAR(MAX) NOT NULL,
	description_diagnosis NVARCHAR(MAX),

	PRIMARY KEY (id_episode,id_medical_card),
	FOREIGN KEY (id_medical_card) REFERENCES Medical_card(id_medical_card),
);
GO


CREATE TABLE Procedure_Client
(
	id_procedure CHAR(36) PRIMARY KEY,
	name_procedure NVARCHAR(MAX) NOT NULL,
	description_procedure NVARCHAR(MAX)
);
GO

CREATE TABLE Medication
(
	id_medication CHAR(36) PRIMARY KEY NOT NULL,
	name_medication NVARCHAR(MAX) NOT NULL,
	manufacturer NVARCHAR(MAX) NOT NULL,
	description_medication NVARCHAR(MAX),
	expiration_date DATE NOT NULL
);
GO 



CREATE TABLE Action_ISPS
(
	id_doctor CHAR(36),
	id_episode CHAR(36),
	id_medical_card CHAR(36),
	description_action NVARCHAR(MAX),
	data_time DATE NOT NULL,
	id_procedure CHAR(36),
	id_medication CHAR(36),

	PRIMARY KEY (id_doctor,id_episode,id_medical_card),

	FOREIGN KEY (id_doctor) REFERENCES Doctor(id_doctor),
	FOREIGN KEY (id_episode,id_medical_card) REFERENCES Episode(id_episode,id_medical_card),
	FOREIGN KEY (id_procedure) REFERENCES Procedure_Client(id_procedure),
	FOREIGN KEY (id_medication) REFERENCES Medication(id_medication)

);