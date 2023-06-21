USE [MoneFi]
GO
/****** Object:  StoredProcedure [dbo].[NewsLetterSubscriptions_SelectAll_Subscribed]    Script Date: 6/20/2023 4:58:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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