


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
	insert into Machine (machineName,categorie) values (@param1,@param2)
RETURN 0

