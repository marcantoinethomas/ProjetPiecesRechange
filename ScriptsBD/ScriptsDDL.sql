USE master
GO
IF EXISTS (SELECT name FROM master.sys.databases WHERE name = N'SpareParts')
	DROP DATABASE SpareParts
GO
CREATE DATABASE SpareParts
GO
USE SpareParts
GO
IF OBJECT_ID (N'Employe', N'U') IS NOT NULL 
	DROP TABLE Employe
GO
CREATE TABLE Employe(
EmployeID int IDENTITY(1, 1) PRIMARY KEY,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Street VARCHAR(50),
NumberApp VARCHAR(16),
City VARCHAR(50),
Province VARCHAR(50),
CodePostal VARCHAR(16),
TypeEmp VARCHAR(50) DEFAULT 'OPERATEUR',
Password VARCHAR(50),
Email VARCHAR(50),
Statut VARCHAR(20)DEFAULT 'EN ATTENTE'
)
GO
IF OBJECT_ID (N'Machine', N'U') IS NOT NULL 
	DROP TABLE Machine
GO
CREATE TABLE Machine(
machineID int IDENTITY(1, 1) PRIMARY KEY,
categorie VARCHAR(50),
machineName VARCHAR(50)
)
GO
IF OBJECT_ID (N'Piece', N'U') IS NOT NULL 
	DROP TABLE Piece
GO
CREATE TABLE Piece(
pieceID int IDENTITY(1, 1) PRIMARY KEY,
machineID int,
nom  VARCHAR(50) not null,
prix money ,
photo VARCHAR(50),
CONSTRAINT Piece_Machine_ID_FK FOREIGN KEY(machineID) REFERENCES Machine(machineID)
)
GO
IF OBJECT_ID (N'Fournisseur', N'U') IS NOT NULL 
	DROP TABLE Fournisseur
GO
CREATE TABLE Fournisseur(
fournisseurID int IDENTITY(1, 1) PRIMARY KEY,
nom VARCHAR(50) not null,
telephone VARCHAR(20), 
categorie VARCHAR(50),
Street VARCHAR(50),
NumberApp VARCHAR(16),
City VARCHAR(50),
Province VARCHAR(50),
CodePostal VARCHAR(16)
)
GO
IF OBJECT_ID (N'Demande', N'U') IS NOT NULL 
	DROP TABLE Demande
GO
CREATE TABLE Demande(
demandeID int IDENTITY(1, 1) PRIMARY KEY,
EmployeID int,
pieceID int ,
machineID int ,
machinePartID int ,
demandeDate DateTime ,
demandeStatut  VARCHAR(20),
pieceQuantite int,
CONSTRAINT Demande_Piece_ID_FK FOREIGN KEY(pieceID) REFERENCES Piece(pieceID),
CONSTRAINT Demande_Machine_ID_FK FOREIGN KEY(machineID) REFERENCES Machine(machineID),
CONSTRAINT Demande_Employe_ID_FK FOREIGN KEY(EmployeID) REFERENCES Employe(EmployeID)
)
GO
IF OBJECT_ID (N'Commande', N'U') IS NOT NULL 
	DROP TABLE Commande
GO
CREATE TABLE Commande(
commandeID int IDENTITY(1, 1) PRIMARY KEY,
EmployeID int,
pieceID int ,
fournisseurID int,
commandeDate DateTime ,
demandeStatut  VARCHAR(20),
CONSTRAINT Commande_Piece_ID_FK FOREIGN KEY(pieceID) REFERENCES Piece(pieceID),
CONSTRAINT Commande_Employe_ID_FK FOREIGN KEY(EmployeID) REFERENCES Employe(EmployeID),
CONSTRAINT Commande_Fournisseur_ID_FK FOREIGN KEY(fournisseurID) REFERENCES Fournisseur(fournisseurID)
)
GO
IF OBJECT_ID (N'LoginLogs', N'U') IS NOT NULL 
	DROP TABLE LoginLogs
GO
CREATE TABLE LoginLogs(
logID int IDENTITY(1, 1) PRIMARY KEY,
EmployeID int ,
loginDate DATETime DEFAULT getDate()

)
GO
IF OBJECT_ID (N'MessageError', N'U') IS NOT NULL 
	DROP TABLE MessageError
GO
CREATE TABLE MessageError(
messageErrorID int IDENTITY(1, 1) PRIMARY KEY,
EmployeID int ,
messageErrorDate DateTime DEFAULT getDate(),
message VARCHAR(200),
velocite VARCHAR(20),
CONSTRAINT MessageError_Employe_ID_FK FOREIGN KEY(EmployeID) REFERENCES Employe(EmployeID)
)
GO











