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


CREATE PROCEDURE [dbo].[InsertPart]
	@NamePart varchar(50),
	@PricePart varchar(50),
	@Photo varchar(50)
AS
Begin
	insert into Piece (nom,prix,photo) values (@NamePart,@PricePart,@Photo)
End
