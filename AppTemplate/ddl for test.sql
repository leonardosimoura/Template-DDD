CREATE TABLE Usuario
(
IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
Nome varchar(150) not null,
Email  varchar(150) not null,
Senha  varchar(150) not null
)
GO
CREATE TABLE UsuarioTeste
(
IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
Nome varchar(150) not null,
Email  varchar(150) not null,
Senha  varchar(150) not null
)
GO
CREATE PROCEDURE AddUsuario
@Name varchar(150) ,
@Email  varchar(150) ,
@Password  varchar(150)
AS
INSERT INTO Usuario
VALUES(@Name,@Email,@Password);
GO
CREATE PROCEDURE AddUsuarioTeste
@Name varchar(150) ,
@Email  varchar(150) ,
@Password  varchar(150)
AS
INSERT INTO UsuarioTeste
VALUES(@Name,@Email,@Password);
GO
CREATE PROCEDURE GetAllUsuario
AS
SELECT * FROM Usuario;
GO
CREATE PROCEDURE GetAllUsuarioTeste
AS
SELECT * FROM UsuarioTeste;
GO