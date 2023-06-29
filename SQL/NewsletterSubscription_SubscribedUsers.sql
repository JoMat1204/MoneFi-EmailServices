ALTER PROC [dbo].[NewsLetterSubscriptions_SelectAll_Subscribed]

AS

BEGIN

SELECT [Email]
      ,[IsSubscribed]
      ,[DateCreated]
      ,[DateModified]
  FROM [dbo].[NewsLetterSubscriptions]
  Where [IsSubscribed] = 1
END
