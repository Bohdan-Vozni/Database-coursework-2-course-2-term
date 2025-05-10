USE Helsi;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetInfoForGenerateReport')
DROP PROCEDURE GetInfoForGenerateReport;
GO

CREATE PROCEDURE GetInfoForGenerateReport
    @ReportData NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Create a temporary table to hold the report parameters
    CREATE TABLE #ReportParams (
        TableName NVARCHAR(128),
        ColumnName NVARCHAR(128),
        IsNullable BIT
    );
    
    -- Parse the JSON input into the temporary table
    INSERT INTO #ReportParams (TableName, ColumnName, IsNullable)
    SELECT 
        TableName,
        ColumnName,
        IsNullable
    FROM OPENJSON(@ReportData)
    WITH (
        TableName NVARCHAR(128) '$.TableName',
        ColumnName NVARCHAR(128) '$.ColumnName',
        IsNullable BIT '$.IsNullable'
    );
    
    -- Build dynamic SQL based on the selected tables and columns
    DECLARE @SQL NVARCHAR(MAX) = '';
    DECLARE @JoinClause NVARCHAR(MAX) = '';
    DECLARE @WhereClause NVARCHAR(MAX) = '';
    
    -- Determine the main table (we'll use the first one in the list)
    DECLARE @MainTable NVARCHAR(128);
    SELECT TOP 1 @MainTable = TableName FROM #ReportParams;
    
    -- Build SELECT clause
    SELECT @SQL = @SQL + 
        CASE WHEN @SQL = '' THEN 'SELECT ' ELSE ', ' END + 
        '[' + rp.TableName + '].[' + rp.ColumnName + '] AS [' + rp.TableName + '.' + rp.ColumnName + ']'
    FROM #ReportParams rp;
    
    -- Build FROM clause
    SET @SQL = @SQL + ' FROM [' + @MainTable + ']';
    
    -- Build JOIN clauses for other tables
    SELECT @JoinClause = @JoinClause + 
        CASE 
            -- For Doctor table
            WHEN rp.TableName = 'Doctor' AND EXISTS (SELECT 1 FROM #ReportParams WHERE TableName = 'Action_ISPS') THEN 
                ' INNER JOIN [Doctor] ON [Action_ISPS].[id_doctor] = [Doctor].[id_doctor]'
            -- Add more join conditions as needed for your schema
            ELSE ''
        END
    FROM #ReportParams rp
    WHERE rp.TableName <> @MainTable
    GROUP BY rp.TableName;
    
    SET @SQL = @SQL + @JoinClause;
    
    -- Build WHERE clause for non-nullable fields
    SELECT @WhereClause = @WhereClause + 
        CASE 
            WHEN @WhereClause = '' THEN ' WHERE ' ELSE ' AND ' END + 
        '[' + rp.TableName + '].[' + rp.ColumnName + '] IS NOT NULL'
    FROM #ReportParams rp
    WHERE rp.IsNullable = 0;
    
    SET @SQL = @SQL + @WhereClause;
    
    -- Execute the dynamic SQL
    EXEC sp_executesql @SQL;
    
    -- Clean up
    DROP TABLE #ReportParams;
END;
GO