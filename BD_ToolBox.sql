---Creacion de tablas---
create table TECNICO (Id int identity (1,1) primary key not null, Nombre varchar(50) not null, Cargo varchar(50), Usuario varchar(50)not null,Contraseña varbinary(200)not null, Telefono numeric,Correo varchar(100));
create table COORDINADOR (Id int identity (1,1) primary key not null, Nombre varchar(50) not null,Usuario varchar(50),Contraseña varbinary(200), Telefono numeric, Correo varchar(100));
create table PROYECTO(Id int identity (1,1) primary key not null, Nombre varchar(50),Id_Coord int, Informacion varchar(200));
create table TECN_PROYECTO(Id int identity (1,1) primary Key not null, Id_proy int, Id_tecn int);
create table HERRAMIENTA(Id int identity (1,1) primary key not null, Nombre varchar(50), Descripcion varchar(200));
create table HERRA_PROY(Id int identity (1,1) primary key not null, Id_Proy int, Id_Herr int,Descripcion varchar(200));
create table EQUIPOS(Id int identity (1,1) primary key not null, Serial varchar(30),Tipo varchar(20), Id_Mode int, Id_Proyecto int, Descripcion varchar(200));
create table MARCA (Id int identity (1,1) primary key not null, Nombre varchar(50)not null, Cel_soporte numeric);
create table MODELO(Id int identity (1,1) primary key not null, Modelo varchar(30), Id_Marca int not null, Componentes varchar(500), Descripcion varchar(200));
create table Error_Falla(Id int identity (1,1) primary key not null, Nombre varchar(50), Descripcion varchar(100));
create table Pre_Error(Id int primary key not null, Id_Modelo int, Id_Error Int);
create table Administrador(Id int primary key not null, Usuario varchar(50), Contrasena varbinary(200)not null);
---Creacion de relaciones---
alter table PROYECTO add constraint fk_Coord foreign key (Id_coord) references COORDINADOR(Id);
alter table TECN_PROYECTO add constraint fk_TECN_PROYECTO_proy foreign key (Id_proy) references PROYECTO(Id);
alter table TECN_PROYECTO add constraint fk_TECN_PROYECTO_tecn foreign key (Id_Tecn) references TECNICO(Id);
alter table HERRA_PROY add constraint fk_HERRA_PROY_proy foreign key (Id_proy) references PROYECTO(Id);
alter table HERRA_PROY add constraint fk_HERRA_PROY_herr foreign key (Id_herr) references HERRAMIENTA(ID);
alter table EQUIPOS add constraint fk_EQUIPOS_mode foreign key (Id_mode) references MODELO(Id);
alter table EQUIPOS add constraint fk_EQUIPOS_proy foreign key (Id_Proyecto) references PROYECTO(Id);
alter table MODELO add constraint fk_MODELO_marca foreign key (Id_marca) references MARCA(Id);
alter table Pre_Error add constraint fk_Pre_Error_modelo foreign key (Id_modelo) references MODELO(Id);
alter table Pre_Error add constraint fk_Pre_Error_Error foreign key (Id_Error) references Error_Falla(Id);

---Ingreso de informacion---
Insert into TECNICO values('Carlos Mendez','Tecnico A1', 'cmendez',encryptbypassphrase('key_secret','12345'),3154215412,'cmendez@sonda.com');
Insert into TECNICO values('Eduardo Martinez','Tecnico A1', 'EMartinez',encryptbypassphrase('key_secret','Bo12345'),3154215412,'EMartinez@sonda.com');
Select * from TECNICO;
Insert into COORDINADOR values('Luis Gonzalez', 'lgonzalez',encryptbypassphrase('key_secret','L12345'),3152024151,'lgonzalez@sonda.com');
select * from COORDINADOR;
Insert into Administrador values(1,'AdminTool',encryptbypassphrase('key_secret','Adm1n0212'));
Insert into PROYECTO(Nombre,Informacion) values ('Ecopetrol','Uno de los proyectos más grandes que tiene sonda en el pais');
Insert into PROYECTO(Nombre,Informacion) values ('Compensar','Caja de compensación y EPS');
select * from PROYECTO;
UPDATE PROYECTO SET Id_Coord = '500'
INSERT INTO TECN_PROYECTO VALUES ('1','4'),('1','5'); 
SELECT * FROM TECN_PROYECTO;
Select TEC.Id,TEC.Nombre,Cargo,Usuario,convert (varchar(50),DECRYPTBYPASSPHRASE('key_secret', Contrasena))as Contrasena,Telefono,Correo,PRO.Nombre
from TECNICO AS TEC JOIN TECN_PROYECTO AS TB ON TEC.Id=TB.Id_tecn JOIN PROYECTO AS PRO ON PRO.Id=TB.Id_proy;
SELECT * from MODELO
SELECT * from Marca
SELECT * from EQUIPOS
SELECT EQ.Serial, M.Modelo,M.Componentes,MAR.Nombre AS Marca, EQ.Estado FROM EQUIPOS AS EQ JOIN MODELO AS M ON EQ.Id_Mode=M.Id JOIN MARCA AS MAR ON M.Id_Marca=MAR.Id
Select*from HERRAMIENTA
Select * from Error_Falla

Select * from Pre_Error