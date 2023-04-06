create trigger puanarttir11
on tbl3
after insert
as
declare @p int
declare @k int
select @p=Scorea,@k=Category from inserted
update tbl2 set puan=puan+@p where Id=@k