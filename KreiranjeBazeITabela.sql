create database SkolaStranihJezika

use skolaStranihJezika
-- drop table kurs
create table Kurs
(
id int primary key identity(1,1),
naziv nvarchar(50) not null,
brojUcenikaTrenutno int,
brojUcenikaMaks int,
straniJezik nvarchar(50),
AktivanDN char(1)
CONSTRAINT CHK_Kurs CHECK (AKTIVANDN in ('D','N'))
)
--drop table ucenik
create table Ucenik
(
	 id int primary key identity(1,1),
	 ime nvarchar(25) not null,
	 prezime nvarchar(25) not null
)

--drop table pohadja
create table pohadja
(
	id int primary key identity(1,1),
	id_kurs int not null,
	id_ucenik int not null
	foreign key (id_kurs) references Kurs(id),
	foreign key (id_ucenik) references Ucenik(id)
)