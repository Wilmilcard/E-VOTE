print '----------------------------'
print '-- CREACION BASE DE DATOS --'
print '----------------------------'

USE master

IF (EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = N'EVOTE' OR name = N'EVOTE')))
BEGIN
	DROP DATABASE EVOTE
	PRINT ''
	PRINT '¡BASE DE DATOS INVENTARIO ANTERIOR BORRADA!'
	PRINT ''
END


IF (NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = N'EVOTE' OR name = N'EVOTE')))
BEGIN
	CREATE DATABASE EVOTE
	PRINT ''
	PRINT '¡BASE DE DATOS INVENTARIO CREADA!'
	PRINT ''
END
GO

USE EVOTE
PRINT '-------------------'
PRINT 'CREACION DE TABLAS'
PRINT '-------------------'

print ''
print '-- Secundarias --'
print ''

IF OBJECT_ID(N'dbo.TipoDoc', N'U') IS NULL
BEGIN
	CREATE TABLE TipoDoc
	(
		Id INT IDENTITY(101,1) PRIMARY KEY,
		Nombre VARCHAR(30),
		Codigo VARCHAR(3)
	)
    PRINT 'Tabla TipoDoc'
END

IF OBJECT_ID(N'dbo.TipoPropuesta', N'U') IS NULL
BEGIN
	CREATE TABLE TipoPropuesta
	(
		Id INT IDENTITY(101,1) PRIMARY KEY,
		Nombre VARCHAR(30)
	)
    PRINT 'Tabla TipoPropuesta'
END

print ''
print '-- Principales --'
print ''

IF OBJECT_ID(N'dbo.Candidato', N'U') IS NULL
BEGIN
	CREATE TABLE Candidato
	(
		Id INT IDENTITY(10001,1) PRIMARY KEY,
		Nombre VARCHAR(50),
		Apellido VARCHAR(50),
		Nacimiento DATE,
		Email VARCHAR(50),
		fk_TipoDoc VARCHAR(3),
		Identificacion VARCHAR(15),
		Foto VARCHAR(50)
	)
    PRINT 'Tabla Candidato'
END

IF OBJECT_ID(N'dbo.Postulacion', N'U') IS NULL
BEGIN
	CREATE TABLE Postulacion
	(
		Id INT IDENTITY(101,1) PRIMARY KEY,
		Propuesta VARCHAR(150),
		fk_Candidato INT,
		fk_TipoPropuesta INT
	)
    PRINT 'Tabla Postulacion'
END

IF OBJECT_ID(N'dbo.Sufragante', N'U') IS NULL
BEGIN
	CREATE TABLE Sufragante
	(
		Id INT IDENTITY(101,1) PRIMARY KEY,
		Nombre VARCHAR(50),
		Apellido VARCHAR(50),
		sexo VARCHAR(1),
		Nacimiento DATE,
		Email VARCHAR(50),
		Fk_TipoDoc VARCHAR(3),
		Identificacion VARCHAR(15),
		Ya_Voto BIT
	)
    PRINT 'Tabla Sufragante'
END

IF OBJECT_ID(N'dbo.Eleccion', N'U') IS NULL
BEGIN
	CREATE TABLE Eleccion
	(
		fk_TipoPropuesta INT,
		fk_Sufragante INT
	)
    PRINT 'Tabla Eleccion'
END

IF OBJECT_ID(N'dbo.Votacion', N'U') IS NULL
BEGIN
	CREATE TABLE Votacion
	(
		Id INT IDENTITY(101,1) PRIMARY KEY,
		Votante_Id INT,
		Postulacion_Id INT,
		Voto INT,
		Inicio DATE,
		FIN DATE
	)
    PRINT 'Tabla Votacion'
END
GO

PRINT ''
PRINT '-------------------------'
PRINT 'CREACION DE LLAVES UNICAS'
PRINT '-------------------------'
PRINT ''

ALTER TABLE TipoDoc
ADD UNIQUE (Codigo)
PRINT 'TipoDoc_Codigo'
GO

PRINT ''
PRINT '--------------------'
PRINT 'CREACION DE FORANEAS'
PRINT '--------------------'
PRINT ''

ALTER TABLE Candidato
ADD CONSTRAINT Fk_Candidato_TipoDoc
FOREIGN KEY (fk_TipoDoc) REFERENCES TipoDoc(Codigo);
PRINT 'Fk_Candidato_TipoDoc'

ALTER TABLE Postulacion
ADD CONSTRAINT Fk_Postulacion_Candidato
FOREIGN KEY (fk_Candidato) REFERENCES Candidato(Id);
PRINT 'Fk_Postulacion_Candidato'

ALTER TABLE Postulacion
ADD CONSTRAINT Fk_Postulacion_TipoPropuesta
FOREIGN KEY (fk_TipoPropuesta) REFERENCES TipoPropuesta(Id);
PRINT 'Fk_Postulacion_TipoPropuesta'

ALTER TABLE Eleccion
ADD CONSTRAINT Fk_Eleccion_TipoPropuesta
FOREIGN KEY (fk_TipoPropuesta) REFERENCES TipoPropuesta(Id);
PRINT 'Fk_Eleccion_TipoPropuesta'

ALTER TABLE Eleccion
ADD CONSTRAINT Fk_Eleccion_Sufragante
FOREIGN KEY (fk_Sufragante) REFERENCES Sufragante(Id);
PRINT 'Fk_Eleccion_Postulacion'

ALTER TABLE Sufragante
ADD CONSTRAINT Fk_Sufragante_TipoDoc
FOREIGN KEY (Fk_TipoDoc) REFERENCES TipoDoc(Codigo);
PRINT 'Fk_Sufragante_TipoDoc'
GO

PRINT ''
PRINT '-----------------'
PRINT 'CREACION DE INDEX'
PRINT '-----------------'
PRINT ''

PRINT 'Sufragante'
CREATE INDEX idx_sufragante_id ON Sufragante(Id);

PRINT 'Candidato'
CREATE INDEX idx_candidato_id ON Candidato(Id);

PRINT 'Votacion'
CREATE INDEX idx_votacion_id ON Votacion(Id);
GO

PRINT ''
PRINT '--------------'
PRINT 'INSERTAR DATOS'
PRINT '--------------'
PRINT ''

INSERT INTO TipoDoc(Nombre, Codigo) VALUES
('Cedula','CC'),
('Pasaporte','PS'),
('Carnet Extrajeria','CE')
PRINT 'TipoDoc'

INSERT INTO TipoPropuesta(Nombre) VALUES
('Presidencia'),
('Viceprecidencia'),
('Secretaria')
PRINT 'TipoPropuesta'


INSERT INTO Candidato(Nombre,Apellido,Nacimiento,Email,fk_TipoDoc,Identificacion,Foto) VALUES
('Karina','Martinez','1990-05-14','karina.martinez78@gmail.com','CC','1110563230','C:\Users\WILMILCARD\Pictures\B78.jpg'),
('Juan David','Leon Barrera','1994-09-14','juan.leon@hotmail.com','CC','1015896321','C:\Users\WILMILCARD\Pictures\679478.jpg'),
('Juan Camilo','Tobon','1972-06-21','tobon563camilo@yahoo.com.ar','PS','623547854','C:\Users\WILMILCARD\Pictures\679478.jpg'),
('Julieth','Rios','1990-11-10','rios2011@gmail.com','CC','1110621785','C:\Users\WILMILCARD\Pictures\B78.jpg')
PRINT 'Candidato'

INSERT INTO Postulacion(Propuesta,fk_Candidato,fk_TipoPropuesta) VALUES
('Mejorar la salud',10001,101),
('Ampliar el porcentaje de aumento salarial',10002,101),
('Mejorar el empleo en todo el pais',10003,101),
('Mejorar la infraestructura del pais',10004,101),
('Bajar el tiempo de pension',10002,102),
('Estudio gratis en universidades publicas',10003,102),
('El proceso de documentacion sera mas agil',10001,103),
('Mejores sueldos para empleados privados',10003,103),
('Mas recursos en el area contable',10004,103)
PRINT 'Postulacion'

INSERT INTO Sufragante(Nombre,Apellido,sexo,Nacimiento,Email,Fk_TipoDoc,Identificacion,Ya_Voto) VALUES
('Armando','Guzman','M','1993-01-01','armado1993@gmail.com','CC','1110456123',0),
('Daniela','Padilla','F','1999-06-12','dan1999@gmail.com','CC','1110432165',0),
('Juana','Bravo','F','2001-12-24','juanita18@hotmail.com','CC','1015789987',0),
('Valentina','Castro','F','2002-05-12','valen@yahoo.com','CC','1100412321',0),
('Michael','Rodriguez','M','1993-05-08','michael_R@gmail.com','CE','96521478',0)
PRINT 'Sufragante'

INSERT INTO Eleccion(fk_TipoPropuesta,fk_Sufragante) VALUES
(101,101),
(101,101),
(101,103),
(102,101),
(102,102),
(102,105),
(103,101),
(103,102),
(103,103),
(103,104),
(103,105)
PRINT 'Eleccion'

GO