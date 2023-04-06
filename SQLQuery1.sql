alter Trigger TestArttir
on tbl2
after Insert
as

update tbl1 set Sum=Sum+1