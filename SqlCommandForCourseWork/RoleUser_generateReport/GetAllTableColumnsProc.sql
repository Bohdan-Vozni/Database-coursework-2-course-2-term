USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetAllTableColumnsProc')
DROP PROCEDURE GetAllTableColumnsProc;
GO

CREATE PROCEDURE GetAllTableColumnsProc
AS
BEGIN
    SET NOCOUNT ON;

    -- Тимчасові таблиці для PK і FK
    CREATE TABLE #PKColumns (
        TableName NVARCHAR(128),
        ColumnName NVARCHAR(128)
    );

    INSERT INTO #PKColumns (TableName, ColumnName)
    SELECT
        KU.TABLE_NAME,
        KU.COLUMN_NAME
    FROM
        INFORMATION_SCHEMA.TABLE_CONSTRAINTS TC
    INNER JOIN
        INFORMATION_SCHEMA.KEY_COLUMN_USAGE KU
        ON TC.CONSTRAINT_NAME = KU.CONSTRAINT_NAME
    WHERE
        TC.CONSTRAINT_TYPE = 'PRIMARY KEY';

    CREATE TABLE #FKColumns (
        TableName NVARCHAR(128),
        ColumnName NVARCHAR(128)
    );

    INSERT INTO #FKColumns (TableName, ColumnName)
    SELECT
        OBJECT_NAME(fk.parent_object_id) AS TableName,
        COL_NAME(fk.parent_object_id, fk.parent_column_id) AS ColumnName
    FROM
        sys.foreign_key_columns fk;

    -- Таблиця зі зрозумілими назвами (сюди додаємо свої назви)
    CREATE TABLE #ColumnDisplayNames (
        TableName NVARCHAR(128),
        ColumnName NVARCHAR(128),
        DisplayName NVARCHAR(256)
    );

    INSERT INTO #ColumnDisplayNames (TableName, ColumnName, DisplayName)
    VALUES
        ('Action_ISPS', 'id_doctor', 'дія ISPS — ідентифікатор доктора'),
        ('Action_ISPS', 'id_episode', 'дія ISPS — ідентифікатор епізоду'),
        ('Action_ISPS', 'id_procedure', 'дія ISPS — ідентифікатор процедури'),
        ('Doctor', 'id_doctor', 'ідентифікатор доктора'),
        ('Doctor', 'id_department', 'ідентифікатор відділення');
        -- >>> ТУТ можеш додати інші колонки (за потреби)

    -- Основний запит
    SELECT
        t.name AS 'Назва таблиці',
        c.name  AS 'Назва поля',
        --ISNULL(map.DisplayName, c.name) AS DisplayName,
        --ty.name AS DataType,
        --c.max_length AS MaxLength,
        c.is_nullable AS 'Чи обовязково повинні бути дані'
        --CASE 
        --    WHEN pk.ColumnName IS NOT NULL THEN 'PK'
        --    WHEN fk.ColumnName IS NOT NULL THEN 'FK'
        --    ELSE '' 
        --END AS KeyType
    FROM 
        sys.tables t
    INNER JOIN 
        sys.columns c ON t.object_id = c.object_id
    INNER JOIN 
        sys.types ty ON c.user_type_id = ty.user_type_id
    LEFT JOIN 
        #PKColumns pk ON pk.TableName = t.name AND pk.ColumnName = c.name
    LEFT JOIN 
        #FKColumns fk ON fk.TableName = t.name AND fk.ColumnName = c.name
    LEFT JOIN 
        #ColumnDisplayNames map ON map.TableName = t.name AND map.ColumnName = c.name
    WHERE 
        t.name <> 'Users'
    ORDER BY 
        t.name, c.column_id;

    -- Очистка тимчасових таблиць
    DROP TABLE #PKColumns;
    DROP TABLE #FKColumns;
    DROP TABLE #ColumnDisplayNames;
END;
GO
