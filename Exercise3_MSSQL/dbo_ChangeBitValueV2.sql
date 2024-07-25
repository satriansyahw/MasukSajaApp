GO
/****** Object:  StoredProcedure [dbo].[ChangeBitValueV2]    Script Date: 25/07/2024 12:30:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChangeBitValueV2xxx]
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
    SET [' + @Column + '] = CASE WHEN [' + @Column + '] IS NOT NULL THEN 
																	 CASE 
																		WHEN [' + @Column + '] = 1 THEN 0 
																	 ELSE 1 
                                  END  ELSE [' + @Column + '] END
    WHERE [Id] = @Id'
    EXEC sp_executesql @Query, N'@Id INT', @Id
END