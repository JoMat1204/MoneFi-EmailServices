USE [MoneFi]
GO
/****** Object:  StoredProcedure [dbo].[NewsletterSubscriptions_Insert]    Script Date: 6/20/2023 4:57:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[NewsletterSubscriptions_Insert]
@Email nvarchar(50),
@IsSubscribed bit


AS
/*
Declare

@Email nvarchar(50) = 'testemail123456@gmail.com',
@IsSubscribed bit = 1

Execute dbo.NewsLetterSubscriptions_Insert
@Email,
@IsSubscribed

Select * 
From dbo.NewsLetterSubscriptions
*/

BEGIN

INSERT INTO [dbo].[NewsLetterSubscriptions]
           ([Email]
           ,[IsSubscribed])
     VALUES
           (@Email,
           @IsSubscribed)

END
