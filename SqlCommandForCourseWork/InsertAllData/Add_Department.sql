USE Helsi;
GO

BEGIN TRANSACTION;
delete from Department;

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('1', '������������ ��������', '³������� ��� �������� ��������� ����������� �� ������� �������� ������� ��������');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('2', 'ճ������� ��������', '³������� ��� ���������� �������� �� ���������� ��������');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('3', '����������� ��������', '³������� ��� �������� �������-�������� �����������');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('4', '����������� ��������', '³������� ��� �������� ����������� ������� �������, ��������� �������� �� ���� �������');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('5', '���������� ��������', '³������� ��� �������� ���� �� ����������� ��� �� ������');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('6', '����������-����������� ��������', '³������� ��� ������� �������� ����� �� ��� ��������, ������ �� �������� ������������ �����������');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('7', '���������� ��������', '³������� ��� �������� ����������� �����������, ��������� ���������� �� ����������');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('8', '���������� ��������', '³������� ��� �������� ����������� ������ �� ����������� ������');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('9', '�������������� ��������', '³������� ��� �������� �������� � �������� �� ����������');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('10', '����������� �������� (���������� ����ﳿ)', '³������� ��� ������������ ��������� ���������� �� ���������� ������� ��������');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('11', '���������������� ��������', '³������� ��� �������� ����������� ���, ����� �� ����');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('12', '�������������� ��������', '³������� ��� �������� ����������� ����');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('13', '������������� ��������', '³������� ��� �������� ������ �����������');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('14', '����������� ��������', '³������� ��� �������� ����������� �����, ��������� ����');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('15', '���������� ��������', '³������� ��� ���������� ���������� �� ��������� ��������, ���, ��� �� ����� ������ ����������');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('16', '������������ ��������', '³������� ��� �������� ��������� ������� �� ������� ������������ ��������');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('17', '������������������ ��������', '³������� ��� �������� ����������� ��������-��������� ������');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('18', '������������� ��������', '³������� ��� �������� ������ �� �����');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('19', '��������������� ��������', '³������� ��� �������� ����������� ���������� �������, ����� �� ����� �� ��������� ������� ��������� ������');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('20', 'ճ�������������� ��������', '³������� ��� ���������� ��������ﳿ �������� � ������������ ��������������');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('21', '��������� ��������', '³������� ��� ������� ���������� �������� ��������� �� ����������� ������ �����������');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('22', '������������� ��������', '³������� ��� �������� ����������� ���� �� ��������� ����');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('23', 'Գ�������������� ��������', '³������� ��� ���������� �� ���������� ������� �������� �� ��������� ��������ﳿ');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('24', '������������� ��������', '³������� ��� ���������� ����������� �������� �� ���������� ��������');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('25', '����������� ��������', '³������� ��� ���������� ������ �� ��������� ����, ���� �� ����� ��������� ������');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('26', '������-��������� ��������', '³������� ��� ������� ��������� �������� ��������� � ��������� �������������� �� ����������');

COMMIT;
