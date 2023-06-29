ALTER PROC [dbo].[NewsLetterSubscriptions_Select_ByEmail]
@Email nvarchar(50)

AS
/*
Declare @Email nvarchar(50) = 'testemail1@gmail.com'
Execute dbo.NewsLetterSubscriptions_Select_ByEmail @Email 
*/
BEGIN

SELECT [Email]
      ,[IsSubscribed]
      ,[DateCreated]
      ,[DateModified]
  FROM [dbo].[NewsLetterSubscriptions]
  Where Email = @Email
END
