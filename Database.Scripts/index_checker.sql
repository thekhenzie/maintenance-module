SELECT
    sys.indexes.name AS IndexName,
    sys.tables.name AS TableName,
    REPLACE((
        SELECT sys.columns.name + CASE WHEN is_descending_key = 1 THEN ' DESC' ELSE '' END AS [data()]
        FROM sys.index_columns
        INNER JOIN sys.columns ON sys.index_columns.object_id = sys.columns.object_id AND sys.index_columns.column_id = sys.columns.column_id
        WHERE sys.index_columns.object_id = sys.indexes.object_id AND sys.index_columns.index_id = sys.indexes.index_id AND sys.index_columns.is_included_column = 0
        ORDER BY sys.index_columns.key_ordinal
        FOR XML PATH('')
    ), ' ', ', ') AS KeyColumns,
    REPLACE((
        SELECT sys.columns.name AS [data()]
        FROM sys.index_columns
        INNER JOIN sys.columns ON sys.index_columns.object_id = sys.columns.object_id AND sys.index_columns.column_id = sys.columns.column_id
        WHERE sys.index_columns.object_id = sys.indexes.object_id AND sys.index_columns.index_id = sys.indexes.index_id AND sys.index_columns.is_included_column = 1
        ORDER BY sys.index_columns.index_column_id
        FOR XML PATH('')
    ), ' ', ', ') AS IncludedColumns,
    sys.dm_db_index_usage_stats.user_updates,
    sys.dm_db_index_usage_stats.user_seeks,
    sys.dm_db_index_usage_stats.user_scans,
    sys.dm_db_index_usage_stats.user_lookups,
    sys.dm_db_index_usage_stats.user_seeks + sys.dm_db_index_usage_stats.user_scans + sys.dm_db_index_usage_stats.user_lookups AS total_usage
	, *
FROM sys.indexes
LEFT JOIN sys.tables ON sys.indexes.object_id = sys.tables.object_id
LEFT JOIN sys.dm_db_index_usage_stats ON sys.indexes.object_id = sys.dm_db_index_usage_stats.object_id AND sys.indexes.index_id = sys.dm_db_index_usage_stats.index_id
WHERE sys.indexes.type <> 0 AND sys.tables.is_ms_shipped = 0
and is_unique = 1
and sys.indexes.name like 'IX%'