USE [MoneFi]
GO
/****** Object:  StoredProcedure [dbo].[NewsLetterSubscriptions_Update]    Script Date: 6/20/2023 4:58:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[NewsLetterSubscriptions_Update]
@Email nvarchar(50),
@IsSubscribed bit

AS
/*

Declare @IsSubscribed bit = 0,
        @Email nvarchar(50) = '123abc@gmail.com'

 Execute dbo.NewsLetterSubscriptions_Update
						 @Email,
						 @IsSubscribed 

Select * 
From dbo.NewsLetterSubscriptions
Where Email = @Email


*/

BEGIN

IF EXISTS (
        SELECT 1
        FROM [dbo].[NewsLetterSubscriptions]
        WHERE Email = @Email AND IsSubscribed <> @IsSubscribed
    )
    BEGIN
       
        UPDATE [dbo].[NewsLetterSubscriptions]
        SET [IsSubscribed] = @IsSubscribed
        WHERE Email = @Email
    END
    ELSE IF @IsSubscribed = 0
    BEGIN
        RAISERROR('Invalid subscription status. Cannot set IsSubscribed to 0.', 16, 1)
    END

 END