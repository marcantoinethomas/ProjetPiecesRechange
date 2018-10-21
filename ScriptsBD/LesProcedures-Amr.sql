


CREATE PROCEDURE [dbo].[InsertPart]
	@NamePart varchar(50),
	@PricePart varchar(50),
	@Photo varchar(50)
AS
Begin
	insert into Piece (nom,prix,photo) values (@NamePart,@PricePart,@Photo)
End


CREATE PROCEDURE [dbo].[InsertMachine]
	@param1 varchar(50),
	@param2 varchar(50)
AS
Begin
	insert into Machine (machineName,categorie) values (@param1,@param2)
End



CREATE PROCEDURE [dbo].[InsertDemande]
	@param1 int ,
	@param2 int,
	@param3 int,
	@param4 int,
	@param5 datetime,
	@param6 varchar(50)



AS
Begin
	insert into Demande (employeID,pieceId,machineId,pieceQuantite,demandeDate,demandeStatut) values (@param1,@param2,@param3,@param4,@param5,@param6)
End
