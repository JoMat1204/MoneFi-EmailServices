ALTER PROCEDURE [dbo].[NewsLetterSubscriptions_SearchPagination]
    @PageIndex int,
    @PageSize int,
    @Query nvarchar(100),
    @All bit = null
AS
/*
-- Test case with @All = 1 and @Query = ''
DECLARE @PageIndex int = 0;
DECLARE @PageSize int = 100;
DECLARE @Query nvarchar(100) = '';
DECLARE @All bit = 1;

EXEC dbo.NewsLetterSubscriptions_SearchPagination @PageIndex, @PageSize, @Query, @All;

-- Test case with @All = 0 and @Query = ''
DECLARE @PageIndex int = 0;
DECLARE @PageSize int = 100;
DECLARE @Query nvarchar(100) = '';
DECLARE @All bit = 0;

EXEC dbo.NewsLetterSubscriptions_SearchPagination @PageIndex, @PageSize, @Query, @All;
*/
BEGIN

    DECLARE @Offset int = @PageIndex * @PageSize;

    IF @All = 1
    BEGIN
        SELECT [Email]
            ,[IsSubscribed]
            ,[DateCreated]
            ,[DateModified]
            , TotalCount = COUNT(*) OVER()
        FROM [dbo].[NewsLetterSubscriptions]
        WHERE [Email] LIKE '%' + @Query + '%'
        ORDER BY DateCreated DESC
        OFFSET @Offset ROWS
        FETCH NEXT @PageSize ROWS ONLY;
    END
    ELSE IF @All = 0
    BEGIN
        SELECT [Email]
            ,[IsSubscribed]
            ,[DateCreated]
            ,[DateModified]
            , TotalCount = COUNT(*) OVER()
        FROM [dbo].[NewsLetterSubscriptions]
        WHERE [IsSubscribed] = 1
        AND [Email] LIKE '%' + @Query + '%'
        ORDER BY DateCreated DESC
        OFFSET @Offset ROWS
        FETCH NEXT @PageSize ROWS ONLY;
    END
END
