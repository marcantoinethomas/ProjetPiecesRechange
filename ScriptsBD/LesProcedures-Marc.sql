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
@courriel VARCHAR(50),
@motDePasse VARCHAR(50)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Employe WHERE courriel= @courriel)
		INSERT INTO Employe(nomEmp, prenomEmp, rue, noApp, ville, province,
		codePostal, courriel, motDePasse)
		VALUES (@nomEmp, @prenomEmp, @rue, @noApp, @ville, @province,
		@codePostal, @courriel, HASHBYTES('MD5', @motDePasse))
END
GO
EXEC CreerEmploye 'Admin', 'Admin', null, null, null, null, null, 'admin@gmail.com', 'admin'
GO
UPDATE Employe SET statut = 'A' , typeEmpID= 1 WHERE courriel= 'admin@gmail.com'
GO

IF OBJECT_ID (N'VerifierLogin', N'P') IS NOT NULL 
	DROP PROCEDURE VerifierLogin
GO
CREATE PROCEDURE VerifierLogin
@courriel VARCHAR(50),
@motDePasse VARCHAR(50)
AS
BEGIN

	IF EXISTS (SELECT * FROM Employe WHERE courriel= @courriel AND motDePasse= HASHBYTES('MD5', @motDePasse))
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
	WHERE courriel= @courriel
	END
END
GO

/*
exec VerifierLogin @courriel=N'admin@gmail.com',@motDePasse=N'admin'
*/
