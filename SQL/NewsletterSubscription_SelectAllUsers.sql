ALTER PROC [dbo].[NewsLetterSubscriptions_SelectAll]
    @PageIndex int,
    @PageSize int,
    @All bit = null
	
AS
/*
Declare @PageIndex int = 0 , @PageSize int = 100, @All bit = 1
Execute dbo.NewsLetterSubscriptions_SelectAll
@PageIndex , @PageSize , @All 

Declare @PageIndex int = 0
Declare @PageSize int = 100
Declare @All bit = 1

EXEC dbo.NewsLetterSubscriptions_SelectAll @PageIndex, @PageSize, @All

-- Test case where @All = 0
    Declare @PageIndex int = 0
Declare @PageSize int = 100
declare @All bit = 0

EXEC dbo.NewsLetterSubscriptions_SelectAll @PageIndex, @PageSize, @All

-- Test case where @All = NULL (Show unsubscribed)
DECLARE @PageIndex int = 0;
DECLARE @PageSize int = 100;
DECLARE @All bit = NULL;

EXEC dbo.NewsLetterSubscriptions_SelectAll @PageIndex, @PageSize, @All
*/
BEGIN
    
    DECLARE @offSet int = @PageIndex * @PageSize
    
    IF @All = 1
    BEGIN
        SELECT [Email]
            ,[IsSubscribed]
            ,[DateCreated]
            ,[DateModified]
            , TotalCount = COUNT(1) OVER()
        FROM [dbo].[NewsLetterSubscriptions]
        WHERE [IsSubscribed] = 1
        ORDER BY [Email]
        OFFSET @offSet ROWS
        FETCH NEXT @PageSize ROWS ONLY
    END
    ELSE IF @All = 0
    BEGIN
        SELECT [Email]
            ,[IsSubscribed]
            ,[DateCreated]
            ,[DateModified]
            , TotalCount = COUNT(1) OVER()
        FROM [dbo].[NewsLetterSubscriptions]
		--WHERE [IsSubscribed] = 0
        ORDER BY [Email]
        OFFSET @offSet ROWS
        FETCH NEXT @PageSize ROWS ONLY
    END
    ELSE IF @All IS NULL -- Show unsubscribed
    BEGIN
        SELECT [Email]
            ,[IsSubscribed]
            ,[DateCreated]
            ,[DateModified]
            , TotalCount = COUNT(1) OVER()
        FROM [dbo].[NewsLetterSubscriptions]
        WHERE [IsSubscribed] = 0
        ORDER BY [Email]
        OFFSET @offSet ROWS
        FETCH NEXT @PageSize ROWS ONLY
    END
END
