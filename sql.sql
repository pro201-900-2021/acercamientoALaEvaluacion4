CREATE DATABASE EVA4
Go

USE EVA4
Go

Create table rol(
	id int primary key identity,
	nombre varchar(255)
	)
	Go

CREATE TABLE tipo_requerimiento(
	id int primary key identity,
	nombre varchar(255)
	)
	go

CREATE TABLE requerimiento(
	id int primary key identity,
	descripcion varchar(1000),
	idTipo int,
	responsable int
	)
	go

CREATE TABLE usuario(
	id int primary key identity,
	nombreUsuario varchar(255),
	passw varchar(255),
	nombre varchar(255),
	apellido varchar(255),
	idRol int
	)
	Go

select * from rol;
select * from tipo_requerimiento;
select * from requerimiento;
select * from usuario;

insert into rol values('Administrador')
insert into rol values('Usuario')

insert into usuario values ('admin', 'admin', 'Administrador', 'Account', 1)
insert into usuario values ('user1', '123456', 'John', 'Doe', 2)
insert into usuario values ('user2', '123456', 'Ben', 'Brereton', 2)

insert into tipo_requerimiento values('Base de Datos')
insert into tipo_requerimiento values('Sistemas')
insert into tipo_requerimiento values('Servidores')

SELECT * FROM usuario WHERE nombreUsuario = 'user1' AND passw = '123456'

