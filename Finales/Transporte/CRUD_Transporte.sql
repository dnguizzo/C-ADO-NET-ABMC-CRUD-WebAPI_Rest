create database CRUD_Transporte

use CRUD_Transporte
go

create table TipoCarga
(idTipo int identity(1,1),
 nombreTipo varchar(100),
 constraint PK_TipoCarga primary key(idTipo))

create table Camion
(idCamion int identity(1,1),
 patente varchar(30),
 estado varchar(100),
 pesoMax decimal(12,2),
 constraint PK_Camion primary key(idCamion))

 create table Carga
 (idCarga int identity(1,1),
  peso decimal(12,2),
  idTipo int,
  idCamion int,
  constraint PK_Carga primary key(idCarga),
  constraint FK_Carga_Tipo foreign key(idTipo)
	references TipoCarga(idTipo),
  constraint FK_Carga_Camion foreign key(idCamion)
	references Camion(idCamion))

insert into TipoCarga(nombreTipo)values('Packing')
insert into TipoCarga(nombreTipo)values('Cajas')
insert into TipoCarga(nombreTipo)values('Bidones')

insert into Camion(patente, estado, pesoMax)values('AA156BC', 'Disponible para carga', 3000)
insert into Camion(patente, estado, pesoMax)values('AB567FE', 'En reparación', 5000)
insert into Camion(patente, estado, pesoMax)values('BF489UG', 'En viaje', 6000)

select * from TipoCarga
select * from Camion

insert into Carga(peso, idTipo, idCamion)values(800, 3, 3)
insert into Carga(peso, idTipo, idCamion)values(400, 2, 3)
insert into Carga(peso, idTipo)values(1000, 1)

create procedure sp_proximo
@next int output
as
begin
set @next = (select MAX(idCamion)+1 from Camion)
end

create procedure sp_cargar_tipos
as
select * from TipoCarga


