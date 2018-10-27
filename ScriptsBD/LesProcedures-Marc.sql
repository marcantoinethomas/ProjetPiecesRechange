USE SpareParts
GO
IF OBJECT_ID (N'GetListeEmployes', N'P') IS NOT NULL 
	DROP PROCEDURE GetListeEmployes
GO
CREATE PROCEDURE GetListeEmployes
AS
BEGIN
	SELECT EmployeID ,
		LastName,
		FirstName ,
		Street ,
		NumberApp ,
		City ,
		Province ,
		CodePostal ,
		Employe.TypeEmp,
		Password,
		Email ,
		Employe.Statut
	FROM Employe 
ORDER BY LastName, FirstName
END
GO
IF OBJECT_ID (N'CreerEmploye', N'P') IS NOT NULL 
	DROP PROCEDURE CreerEmploye
GO
CREATE PROCEDURE CreerEmploye
@LastName VARCHAR(50),
@FirstName VARCHAR(50),
@Street VARCHAR(50),
@NumberApp VARCHAR(16),
@City VARCHAR(50),
@Province VARCHAR(50),
@CodePostal VARCHAR(16),
@Email VARCHAR(50),
@Password VARCHAR(50)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Employe WHERE Email= @Email)
		INSERT INTO Employe(LastName, FirstName, Street, NumberApp, City, Province,
		CodePostal, Email, Password)
		VALUES (@LastName, @FirstName, @Street, @NumberApp, @City, @Province,
		@CodePostal, @Email, HASHBYTES('MD5', @Password))
END
GO
EXEC CreerEmploye 'Admin', 'Admin', null, null, null, null, null, 'admin@gmail.com', 'admin'
GO
UPDATE Employe SET Statut = 'ACTIF' , TypeEmp= 'ADMIN' WHERE Email= 'admin@gmail.com'
GO

IF OBJECT_ID (N'UpdateEmploye', N'P') IS NOT NULL 
	DROP PROCEDURE UpdateEmploye
GO
CREATE PROCEDURE UpdateEmploye
@LastName VARCHAR(50),
@FirstName VARCHAR(50),
@Street VARCHAR(50),
@NumberApp VARCHAR(16),
@City VARCHAR(50),
@Province VARCHAR(50),
@CodePostal VARCHAR(16),
@Email VARCHAR(50)
AS
BEGIN
	IF EXISTS (SELECT * FROM Employe WHERE Email= @Email)
		UPDATE Employe SET LastName= @LastName, FirstName= @FirstName, Street= @Street, NumberApp= @NumberApp, City= @City, Province= @Province,
		CodePostal= @CodePostal, Email= @Email 
		WHERE Employe.Email= @Email
END
GO

IF OBJECT_ID (N'DeleteEmploye', N'P') IS NOT NULL 
	DROP PROCEDURE DeleteEmploye
GO
CREATE PROCEDURE DeleteEmploye
@Email VARCHAR(50)
AS
BEGIN
	IF EXISTS (SELECT * FROM Employe WHERE Email= @Email)
		DELETE FROM Employe WHERE Email= @Email
END
GO

IF OBJECT_ID (N'Activeremploye', N'P') IS NOT NULL 
	DROP PROCEDURE Activeremploye
GO
CREATE PROCEDURE Activeremploye
@Email VARCHAR(50),
@Statut VARCHAR(50),
@TypeEmp VARCHAR(50)

AS
BEGIN
	IF EXISTS (SELECT * FROM Employe WHERE Email= @Email)
		UPDATE Employe SET Statut= @Statut, TypeEmp= @TypeEmp
		WHERE Employe.Email= @Email
END
GO

IF OBJECT_ID (N'VerifierLogin', N'P') IS NOT NULL 
	DROP PROCEDURE VerifierLogin
GO
CREATE PROCEDURE VerifierLogin
@Email VARCHAR(50),
@Password VARCHAR(50)
AS
BEGIN

	IF EXISTS (SELECT * FROM Employe WHERE Email= @Email AND Password= HASHBYTES('MD5', @Password))
	BEGIN
		SELECT EmployeID ,
		LastName,
		FirstName ,
		Street ,
		NumberApp ,
		City ,
		Province ,
		CodePostal ,
		Employe.TypeEmp,
		Email ,
		Password,
		Employe.Statut
	FROM Employe 
	WHERE Email= @Email
	END
END
GO

IF OBJECT_ID (N'GetEmployeesOnHold', N'P') IS NOT NULL 
	DROP PROCEDURE GetEmployeesOnHold
GO
CREATE PROCEDURE GetEmployeesOnHold
AS
BEGIN
		SELECT EmployeID ,
		LastName,
		FirstName ,
		Employe.TypeEmp
		Email ,
		Employe.Statut
	FROM Employe 
	WHERE Employe.Statut= 'EN ATTENTE'
	ORDER BY LastName, FirstName
END
GO

IF OBJECT_ID ('T_InsertNewEmploye', 'TR') IS NOT NULL  
   DROP TRIGGER T_InsertNewEmploye;  
GO
CREATE TRIGGER [dbo].[T_InsertNewEmploye] ON [dbo].[Employe] 
  AFTER INSERT
AS 
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON;

  -- Insert statements for trigger here
  UPDATE Employe SET Employe.Password = HASHBYTES('MD5', ins.Password), Employe.Statut= 'EN ATTENTE', Employe.TypeEmp= 'OPERATEUR'  
  FROM Employe E INNER JOIN INSERTED ins ON E.EmployeID = ins.EmployeID
END
