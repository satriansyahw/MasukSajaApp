GO
/****** Object:  StoredProcedure [dbo].[ChangeBitValueV1]    Script Date: 25/07/2024 12:28:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChangeBitValueV1]
    @Id INT,
    @Column CHAR(1)
AS
BEGIN
    -- Check column name for validation
    IF @Column NOT IN ('A', 'B', 'C', 'D', 'E')
    BEGIN
        RAISERROR('Invalid column name. Valid columns are A, B, C, D, E.', 16, 1)
        RETURN
    END
    DECLARE @Query NVARCHAR(MAX)

    SET @Query = N'
    UPDATE #TEST2
    SET [' + @Column + '] = CASE WHEN [' + @Column + '] IS NOT NULL THEN ~[' + @Column + '] ELSE [' + @Column + '] END
    WHERE [Id] = @Id'
	-- using ~ Not operation,to convert bit value from 0 to 1 and 1 to 0 ( because datatype for columns A,B,C,D,E is BIT)
    EXEC sp_executesql @Query, N'@Id INT', @Id
END