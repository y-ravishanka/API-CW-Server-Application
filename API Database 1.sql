
create database apicw

use apicw

create table citizen 
(
	id int identity(1,1),
	nic varchar(13) not null,
	name varchar(100) not null,
	age int not null,
	address varchar(500) not null,
	latitude varchar(50) not null,
	longtitude varchar(50) not null,
	profession varchar(20) not null,
	email varchar(50) not null,
	affiliation varchar(50) not null,
	password varchar(20) not null,
	staff int default 0,
	active varchar(10) not null,
	primary key (nic)
)

select * from citizen
delete citizen
drop table citizen

create table contact
(
	id int identity(1,1),
	nic varchar(20) not null,
	contact varchar(20) not null,
	primary key (id,nic)
)

select * from contact
delete contact
drop table contact

create table qualification
(
	id int identity(1,1),
	nic varchar(20) not null,
	education varchar(20) not null,
	diploma int default 0,
	degree int default 0,
	certificate int default 0,
	experience int default 0,
	primary key (nic)
)

select * from qualification
delete qualification
drop table qualification

create table diploma
(
	id int identity(1,1),
	nic varchar(20) not null,
	name varchar(100) not null,
	institute varchar(100) not null,
	year int not null,
	primary key (id,nic)
)

select * from diploma
delete diploma
drop table diploma

create table degree
(
	id int identity(1,1),
	nic varchar(20) not null,
	degreetype varchar(20) not null,
	name varchar(100) not null,
	institute varchar(100) not null,
	year int not null,
	primary key (id,nic)
)

select * from degree
delete degree
drop table degree

create table certificate
(
	id int identity(1,1),
	nic varchar(20) not null,
	name varchar(100) not null,
	year int not null,
	primary key (id,nic)
)

select * from certificate
delete certificate
drop table certificate

create table experience
(
	id int identity(1,1),
	nic varchar(20) not null,
	posision varchar(100) not null,
	duration varchar(10) not null,
	organization varchar(100) not null,
	primary key (id,nic)
)

select * from experience
delete experience
drop table experience

create table skills
(
	id int identity(1,1),
	nic varchar(20) not null,
	name varchar(50) not null,
	primary key (id,nic)
)

select * from skills
delete skills
drop table skills

create table complaint
(
	id int identity(1,1),
	nic varchar(20) not null,
	complaint varchar(500) not null,
	reply varchar(500) null,
	staffid int null,
	primary key (id,nic)
)

select * from complaint
delete complaint
drop table complaint