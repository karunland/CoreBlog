--create trigger addbloginraytingtable
--on Blogs
--after insert
--as
--declare @thisId int
--select @thisId=Id from inserted
--insert into BlogRatings(BLogId, RatingCount, TotalScore)
--values (@thisId, 0, 0)

Use blogsite;

create trigger addscoreincomment
on Comments
after insert
as
declare @mId int
declare @mScore int
declare @RatingCount int = 1
select @mId=Id, @mScore=Score from inserted
update BlogRatings set TotalScore=TotalScore+@mScore, RatingCount=RatingCount+@RatingCount
where Id=@mId

