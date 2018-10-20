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
typeEmpID ,
courriel ,
motDePasse ,
statut 
FROM Employe
ORDER BY nomEmp, prenomEmp
END
GO