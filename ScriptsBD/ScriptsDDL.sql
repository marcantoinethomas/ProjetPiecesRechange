USE master
GO
IF EXISTS (SELECT name FROM master.sys.databases WHERE name = N'SpareParts')
	DROP DATABASE SpareParts
GO
CREATE DATABASE SpareParts
GO
USE SpareParts
GO
IF OBJECT_ID (N'Adresse', N'U') IS NOT NULL 
	DROP TABLE Adresse
GO
CREATE TABLE Adresse(
adresseID int IDENTITY(1, 1) PRIMARY KEY,
rue VARCHAR(50),
noApp VARCHAR(16),
ville VARCHAR(50),
province VARCHAR(50),
codePostal VARCHAR(16)
)
GO
IF OBJECT_ID (N'TypeEmploye', N'U') IS NOT NULL 
	DROP TABLE TypeEmploye
GO
CREATE TABLE TypeEmploye(
typeEmpID int IDENTITY(1, 1) PRIMARY KEY,
description VARCHAR(50) NOT NULL
)
GO
INSERT INTO TypeEmploye (description) VALUES ('ADMIN')
INSERT INTO TypeEmploye (description) VALUES ('OPERATEUR')
INSERT INTO TypeEmploye (description) VALUES ('GESTIONNAIRE')
GO
IF OBJECT_ID (N'Employe', N'U') IS NOT NULL 
	DROP TABLE Employe
GO
CREATE TABLE Employe(
employeID int IDENTITY(1, 1) PRIMARY KEY,
nomEmp VARCHAR(50) NOT NULL,
prenomEmp VARCHAR(50) NOT NULL,
rue VARCHAR(50),
noApp VARCHAR(16),
ville VARCHAR(50),
province VARCHAR(50),
codePostal VARCHAR(16),
typeEmpID int,
courriel VARCHAR(50),
motDePasse VARCHAR(50),
statut Char(1)DEFAULT 'H',
CONSTRAINT typeEmpID_FK FOREIGN KEY(typeEmpID) REFERENCES TypeEmploye(typeEmpID)
)
GO
IF OBJECT_ID (N'StatutEmploye', N'U') IS NOT NULL 
	DROP TABLE StatutEmploye
GO
CREATE TABLE StatutEmploye(
statutID Char(1) PRIMARY KEY,
description VARCHAR(50) NOT NULL
)
GO
INSERT INTO StatutEmploye(statutID, description) VALUES ('H', 'En attente')
INSERT INTO StatutEmploye(statutID, description) VALUES ('A','Actif')
INSERT INTO StatutEmploye(statutID, description) VALUES ('I', 'Inactif')
GO

IF OBJECT_ID (N'Piece', N'U') IS NOT NULL 
	DROP TABLE Piece
GO
CREATE TABLE Piece(
pieceId int IDENTITY(1, 1) PRIMARY KEY,
nom  VARCHAR(50) not null,
prix money ,
photo image
)
GO
IF OBJECT_ID (N'Machine', N'U') IS NOT NULL 
	DROP TABLE Machine
GO
CREATE TABLE Machine(
machineId int PRIMARY KEY,
categorie VARCHAR(50),
machineName VARCHAR(50)
)
GO
IF OBJECT_ID (N'MachinePiece', N'U') IS NOT NULL 
	DROP TABLE MachinePiece
GO
CREATE TABLE MachinePiece(
machineId int,
pieceId int,
CONSTRAINT machine_Piece_ID_PK PRIMARY KEY (machineId, pieceId),
CONSTRAINT machinePId_FK FOREIGN KEY(machineId) REFERENCES Machine(machineId),
CONSTRAINT piecePId_FK FOREIGN KEY(pieceId) REFERENCES Piece(pieceId)
)
GO
IF OBJECT_ID (N'Fournisseur', N'U') IS NOT NULL 
	DROP TABLE Fournisseur
GO
CREATE TABLE Fournisseur(
fournisseurId int IDENTITY(1, 1) PRIMARY KEY,
nom VARCHAR(50) not null,
adresseID int ,
telephone VARCHAR(20), 
categorie VARCHAR(50),
CONSTRAINT adress_Four_ID_FK FOREIGN KEY(adresseID) REFERENCES Adresse(adresseID)
)
GO
IF OBJECT_ID (N'Demande', N'U') IS NOT NULL 
	DROP TABLE Demande
GO
CREATE TABLE Demande(
demandeId int IDENTITY(1, 1) PRIMARY KEY,
employeID int,
pieceId int ,
machineId int ,
machinePartId int ,
demandeDate DateTime ,
demandeStatut  VARCHAR(20),
pieceQuantite int,
CONSTRAINT Demande_Piece_ID_FK FOREIGN KEY(pieceId) REFERENCES Piece(pieceId),
CONSTRAINT Demande_Machine_ID_FK FOREIGN KEY(machineId) REFERENCES Machine(machineId),
CONSTRAINT Demande_Employe_ID_FK FOREIGN KEY(employeID) REFERENCES Employe(employeID)
)
GO
IF OBJECT_ID (N'Commande', N'U') IS NOT NULL 
	DROP TABLE Commande
GO
CREATE TABLE Commande(
commandeId int IDENTITY(1, 1) PRIMARY KEY,
employeID int,
pieceId int ,
fournisseurId int,
commandeDate DateTime ,
demandeStatut  VARCHAR(20),
CONSTRAINT Commande_Piece_ID_FK FOREIGN KEY(pieceId) REFERENCES Piece(pieceId),
CONSTRAINT Commande_Employe_ID_FK FOREIGN KEY(employeID) REFERENCES Employe(employeID),
CONSTRAINT Commande_Fournisseur_ID_FK FOREIGN KEY(fournisseurId) REFERENCES Fournisseur(fournisseurId)
)
GO
IF OBJECT_ID (N'LoginLogs', N'U') IS NOT NULL 
	DROP TABLE LoginLogs
GO
CREATE TABLE LoginLogs(
logId int IDENTITY(1, 1) PRIMARY KEY,
employeID int ,
loginDate DATETime DEFAULT getDate()

)
GO
IF OBJECT_ID (N'MessageError', N'U') IS NOT NULL 
	DROP TABLE MessageError
GO
CREATE TABLE MessageError(
messageErrorId int IDENTITY(1, 1) PRIMARY KEY,
employeID int ,
messageErrorDate DateTime DEFAULT getDate(),
message VARCHAR(200),
velocite VARCHAR(20),
CONSTRAINT MessageError_Employe_ID_FK FOREIGN KEY(employeID) REFERENCES Employe(employeID)
)
GO



