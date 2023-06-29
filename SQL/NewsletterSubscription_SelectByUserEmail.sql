USE [MoneFi]
GO
/****** Object:  StoredProcedure [dbo].[NewsLetterSubscriptions_Select_ByEmail]    Script Date: 6/20/2023 4:58:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
