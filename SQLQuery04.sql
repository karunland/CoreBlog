USE [blogsite]
GO
/****** Object:  Trigger [dbo].[addscoreincomment]    Script Date: 4/9/2023 2:36:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[addscoreincomment] 
ON [dbo].[Comments]
AFTER INSERT
AS
BEGIN
  DECLARE @mId int
  DECLARE @mScore int
  
  SELECT @mId = Id, @mScore = Score FROM inserted
  
  UPDATE BlogRatings SET
    TotalScore = TotalScore + @mScore,
    RatingCount += 1
  WHERE BLogId=@mId
END
