create database Test01

use Test01

create table Class
(
	ID nchar(5) primary key,
	Department nvarchar(100) not null	
)

create table Student
(
	ID nchar(7) primary key,
	Name nvarchar(100) not null,
	classID nchar(5) references Class(ID)
)

insert into Class values ('CTK40',N'Khoa Công nghệ thông tin')
insert into Class values ('AVK40',N'Khoa Ngoại ngữ')
insert into Class values ('LHK40',N'Khoa Luật học')
insert into Class values ('DPK40',N'Khoa Đông phương học')

insert into Student values ('1610207',N'La Quốc Thắng','CTK40')
insert into Student values ('1610134',N'Công Tằng Tôn Nữ','AVK40')
insert into Student values ('1610432',N'Tôn Thất Công Tử','LHK40')
insert into Student values ('1610246',N'Nguyễn Văn Bị','LHK40')
insert into Student values ('1610357',N'Kim Jong-un','DPK40')
insert into Student values ('1610987',N'Tập Cận Bình','DPK40')
insert into Student values ('1610568',N'Donald Trump','AVK40')
insert into Student values ('1610864',N'Barack Obama','LHK40')
insert into Student values ('1610153',N'Nguyễn Tử Quảng','CTK40')
insert into Student values ('1610199',N'Bill Gates','CTK40')

select * from Class
select * from Student