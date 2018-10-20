USE SpareParts
GO
IF OBJECT_ID (N'GetListeEmployes', N'P') IS NOT NULL 
	DROP PROCEDURE GetListeEmployes
GO
CREATE PROCEDURE GetListeEmployes
AS
BEGIN
	SELECT employeID ,
		nomEmp,
		prenomEmp ,
		rue ,
		noApp ,
		ville ,
		province ,
		codePostal ,
		Employe.typeEmpID,
		descripType= TypeEmploye.description,
		courriel ,
		motDePasse,
		Employe.statut,
		descripStatut= StatutEmploye.description 
	FROM Employe 
	INNER JOIN StatutEmploye ON Employe.statut= StatutEmploye.statutID
	INNER JOIN TypeEmploye ON Employe.typeEmpID= TypeEmploye.typeEmpID
ORDER BY nomEmp, prenomEmp
END
GO

<<<<<<< HEAD
IF OBJECT_ID (N'CreerEmploye', N'P') IS NOT NULL 
	DROP PROCEDURE CreerEmploye
GO
CREATE PROCEDURE CreerEmploye
@nomEmp VARCHAR(50),
@prenomEmp VARCHAR(50),
@rue VARCHAR(50),
@noApp VARCHAR(16),
@ville VARCHAR(50),
@province VARCHAR(50),
@codePostal VARCHAR(16),
@typeEmpID int,
@courriel VARCHAR(50),
@motDePasse VARCHAR(50)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Employe WHERE courriel= @courriel)
		INSERT INTO Employe(nomEmp, prenomEmp, rue, noApp, ville, province,
		codePostal, typeEmpID, courriel, motDePasse)
		VALUES (@nomEmp, @prenomEmp, @rue, @noApp, @ville, @province,
		@codePostal, @typeEmpID, @courriel, @motDePasse)
END
GO
EXEC CreerEmploye 'Admin', 'Admin', null, null,null, null, null, 1, 'admin@gmail.com', 'admin'
GO
UPDATE Employe SET statut = 'A' WHERE courriel= 'admin@gmail.com'
GO
=======

CREATE PROCEDURE [dbo].[InsertPart]
	@NamePart varchar(50),
	@PricePart varchar(50),
	@Photo varchar(50)
AS
Begin
	insert into Piece (nom,prix,photo) values (@NamePart,@PricePart,@Photo)
End
>>>>>>> 5056d7b6bebd1ccf01be1d2ecf45911917adc418
