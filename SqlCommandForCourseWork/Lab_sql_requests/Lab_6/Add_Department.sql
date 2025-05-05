USE Helsi;
GO

BEGIN TRANSACTION;
delete from Department;

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('1', 'Терапевтичне відділення', 'Відділення для лікування загальних захворювань та надання первинної медичної допомоги');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('2', 'Хірургічне відділення', 'Відділення для проведення операцій та хірургічних втручань');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('3', 'Кардіологічне відділення', 'Відділення для лікування серцево-судинних захворювань');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('4', 'Неврологічне відділення', 'Відділення для лікування захворювань нервової системи, включаючи інсульти та інші розлади');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('5', 'Педіатричне відділення', 'Відділення для лікування дітей від немовлячого віку до підлітків');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('6', 'Акушерсько-гінекологічне відділення', 'Відділення для надання допомоги жінкам під час вагітності, пологів та лікування гінекологічних захворювань');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('7', 'Онкологічне відділення', 'Відділення для лікування онкологічних захворювань, включаючи хіміотерапію та радіотерапію');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('8', 'Інфекційне відділення', 'Відділення для лікування інфекційних хвороб та карантинних заходів');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('9', 'Травматологічне відділення', 'Відділення для лікування пацієнтів з травмами та переломами');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('10', 'Реанімаційне відділення (Інтенсивної терапії)', 'Відділення для забезпечення постійного моніторингу та інтенсивної медичної допомоги');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('11', 'Отоларингологічне відділення', 'Відділення для лікування захворювань вух, горла та носа');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('12', 'Офтальмологічне відділення', 'Відділення для лікування захворювань очей');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('13', 'Дерматологічне відділення', 'Відділення для лікування шкірних захворювань');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('14', 'Нефрологічне відділення', 'Відділення для лікування захворювань нирок, включаючи діаліз');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('15', 'Радіологічне відділення', 'Відділення для проведення діагностики за допомогою рентгену, УЗД, МРТ та інших методів візуалізації');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('16', 'Психіатричне відділення', 'Відділення для лікування психічних розладів та надання психіатричної допомоги');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('17', 'Гастроентерологічне відділення', 'Відділення для лікування захворювань шлунково-кишкового тракту');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('18', 'Аллергологічне відділення', 'Відділення для лікування алергій та астми');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('19', 'Ендокринологічне відділення', 'Відділення для лікування захворювань ендокринної системи, таких як діабет та порушення функції щитовидної залози');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('20', 'Хіміотерапевтичне відділення', 'Відділення для проведення хіміотерапії пацієнтів з онкологічними захворюваннями');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('21', 'Паліативне відділення', 'Відділення для надання підтримуючої допомоги пацієнтам на термінальних стадіях захворювань');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('22', 'Стоматологічне відділення', 'Відділення для лікування захворювань зубів та порожнини рота');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('23', 'Фізіотерапевтичне відділення', 'Відділення для реабілітації та відновлення функцій організму за допомогою фізіотерапії');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('24', 'Косметологічне відділення', 'Відділення для проведення косметичних процедур та естетичних втручань');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('25', 'Лабораторне відділення', 'Відділення для проведення аналізів та досліджень крові, сечі та інших біологічних зразків');

INSERT INTO Department (id_department, name_department, description_department)
VALUES ('26', 'Медико-соціальне відділення', 'Відділення для надання соціальної підтримки пацієнтам з хронічними захворюваннями та інвалідністю');

COMMIT;
