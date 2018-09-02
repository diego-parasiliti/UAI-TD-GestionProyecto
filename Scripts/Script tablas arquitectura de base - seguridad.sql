CREATE TABLE Usuario
(
	ID INT NOT NULL IDENTITY(1,1),
	Email VARCHAR(50) NOT NULL,
	Clave VARCHAR(50) NOT NULL,
	CONSTRAINT PK_ID_USUARIO PRIMARY KEY (ID),
	CONSTRAINT UQ_ENAUK_USUARIO UNIQUE (Email)
)
GO
CREATE TABLE Patente
(
	ID INT NOT NULL IDENTITY(1,1),
	Accion VARCHAR(50) NOT NULL,
	Formulario VARCHAR(50) NOT NULL,
	CONSTRAINT PK_ID_PATENTE PRIMARY KEY (ID)
)
GO
CREATE TABLE Familia
(
	ID INT NOT NULL IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL,
	CONSTRAINT PK_ID_FAMILIA PRIMARY KEY (ID)
)
GO
CREATE TABLE UsuarioPatente
(
	ID INT NOT NULL IDENTITY(1,1),
	IdUsuario INT NOT NULL,
	IdPatente INT NOT NULL,
	CONSTRAINT PK_ID_USUARIO_PATENTE PRIMARY KEY (IdUsuario, IdPatente),
	CONSTRAINT FK_USUARIO_PATENTE_PATENTE FOREIGN KEY (IdPatente) REFERENCES Patente (ID),
	CONSTRAINT FK_USUARIO_PATENTE_USUARIO FOREIGN KEY (IdUsuario) REFERENCES Usuario (ID)
)
GO
CREATE TABLE UsuarioFamilia
(
	ID INT NOT NULL IDENTITY(1,1),
	IdUsuario INT NOT NULL,
	IdFamilia INT NOT NULL,
	CONSTRAINT PK_ID_USUARIO_FAMILIA PRIMARY KEY (IdUsuario, IdFamilia),
	CONSTRAINT FK_USUARIO_FAMILIA_FAMILIA FOREIGN KEY (IdFamilia) REFERENCES Familia (ID),
	CONSTRAINT FK_USUARIO_FAMILIA_USUARIO FOREIGN KEY (IdUsuario) REFERENCES Usuario (ID)
)
GO
CREATE TABLE FamiliaPatente
(
	ID INT NOT NULL IDENTITY(1,1),
	IdPatente INT NOT NULL,
	IdFamilia INT NOT NULL,
	CONSTRAINT PK_ID_FAMILIA_PATENTE PRIMARY KEY (IdPatente, IdFamilia),
	CONSTRAINT FK_FAMILIA_PATENTE_PATENTE FOREIGN KEY (IdPatente) REFERENCES Patente (ID),
	CONSTRAINT FK_FAMILIA_PATENTE_FAMILIA FOREIGN KEY (IdFamilia) REFERENCES Familia (ID)
)
GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioInsert]
GO

CREATE PROCEDURE [dbo].[UsuarioInsert] (
	@Email varchar(50),
	@Clave varchar(50)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Usuario] (
	[Email],
	[Clave]
) VALUES (
	@Email,
	@Clave
)

SELECT SCOPE_IDENTITY() AS ID
IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);
ELSE
	SELECT SCOPE_IDENTITY() AS ID
GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioUpdate]
GO

CREATE PROCEDURE [dbo].[UsuarioUpdate] (
	@ID int,
	@Email varchar(50),
	@Clave varchar(50)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Usuario]
SET
	[Email] = @Email,
	[Clave] = @Clave
WHERE
	 [ID] = @ID

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioDelete]
GO

CREATE PROCEDURE [dbo].[UsuarioDelete] (
	@ID int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Usuario]
WHERE
	[ID] = @ID


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioSelect]
GO

CREATE PROCEDURE [dbo].[UsuarioSelect] (
	@ID int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[ID],
	[Email],
	[Clave]
FROM
	[Usuario]
WHERE
	[ID] = @ID


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioSelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioSelectAll]
GO

CREATE PROCEDURE [dbo].[UsuarioSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[ID],
	[Email],
	[Clave]
FROM
	[Usuario]


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PatenteInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[PatenteInsert]
GO

CREATE PROCEDURE [dbo].[PatenteInsert] (
	@Accion varchar(50),
	@Formulario varchar(50)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Patente] (
	[Accion],
	[Formulario]
) VALUES (
	@Accion,
	@Formulario
)

SELECT SCOPE_IDENTITY() AS ID
IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);
ELSE
	SELECT SCOPE_IDENTITY() AS ID
GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PatenteUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[PatenteUpdate]
GO

CREATE PROCEDURE [dbo].[PatenteUpdate] (
	@ID int,
	@Accion varchar(50),
	@Formulario varchar(50)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Patente]
SET
	[Accion] = @Accion,
	[Formulario] = @Formulario
WHERE
	 [ID] = @ID

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PatenteDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[PatenteDelete]
GO

CREATE PROCEDURE [dbo].[PatenteDelete] (
	@ID int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Patente]
WHERE
	[ID] = @ID


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PatenteSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[PatenteSelect]
GO

CREATE PROCEDURE [dbo].[PatenteSelect] (
	@ID int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[ID],
	[Accion],
	[Formulario]
FROM
	[Patente]
WHERE
	[ID] = @ID


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PatenteSelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[PatenteSelectAll]
GO

CREATE PROCEDURE [dbo].[PatenteSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[ID],
	[Accion],
	[Formulario]
FROM
	[Patente]


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FamiliaInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[FamiliaInsert]
GO

CREATE PROCEDURE [dbo].[FamiliaInsert] (
	@Nombre varchar(50)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Familia] (
	[Nombre]
) VALUES (
	@Nombre
)

SELECT SCOPE_IDENTITY() AS ID
IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);
ELSE
	SELECT SCOPE_IDENTITY() AS ID
GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FamiliaUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[FamiliaUpdate]
GO

CREATE PROCEDURE [dbo].[FamiliaUpdate] (
	@ID int,
	@Nombre varchar(50)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Familia]
SET
	[Nombre] = @Nombre
WHERE
	 [ID] = @ID

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FamiliaDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[FamiliaDelete]
GO

CREATE PROCEDURE [dbo].[FamiliaDelete] (
	@ID int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Familia]
WHERE
	[ID] = @ID


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FamiliaSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[FamiliaSelect]
GO

CREATE PROCEDURE [dbo].[FamiliaSelect] (
	@ID int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[ID],
	[Nombre]
FROM
	[Familia]
WHERE
	[ID] = @ID


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FamiliaSelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[FamiliaSelectAll]
GO

CREATE PROCEDURE [dbo].[FamiliaSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[ID],
	[Nombre]
FROM
	[Familia]


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioFamiliaInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioFamiliaInsert]
GO

CREATE PROCEDURE [dbo].[UsuarioFamiliaInsert] (
	@IdUsuario int,
	@IdFamilia int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [UsuarioFamilia] (
	[IdUsuario],
	[IdFamilia]
) VALUES (
	@IdUsuario,
	@IdFamilia
)

SELECT SCOPE_IDENTITY() AS ID
IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);
ELSE
	SELECT SCOPE_IDENTITY() AS ID
GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioFamiliaUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioFamiliaUpdate]
GO


/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioFamiliaDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioFamiliaDelete]
GO

CREATE PROCEDURE [dbo].[UsuarioFamiliaDelete] (
	@IdUsuario int,
	@IdFamilia int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[UsuarioFamilia]
WHERE
	[IdUsuario] = @IdUsuario
	AND [IdFamilia] = @IdFamilia


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioFamiliaDeleteByIdFamilia]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioFamiliaDeleteByIdFamilia]
GO

CREATE PROCEDURE [dbo].[UsuarioFamiliaDeleteByIdFamilia] (
	@IdFamilia int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[UsuarioFamilia]
WHERE
	[IdFamilia] = @IdFamilia


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioFamiliaDeleteByIdUsuario]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioFamiliaDeleteByIdUsuario]
GO

CREATE PROCEDURE [dbo].[UsuarioFamiliaDeleteByIdUsuario] (
	@IdUsuario int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[UsuarioFamilia]
WHERE
	[IdUsuario] = @IdUsuario


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioFamiliaSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioFamiliaSelect]
GO

CREATE PROCEDURE [dbo].[UsuarioFamiliaSelect] (
	@IdUsuario int,
	@IdFamilia int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[ID],
	[IdUsuario],
	[IdFamilia]
FROM
	[UsuarioFamilia]
WHERE
	[IdUsuario] = @IdUsuario
	AND [IdFamilia] = @IdFamilia


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioFamiliaSelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioFamiliaSelectAll]
GO

CREATE PROCEDURE [dbo].[UsuarioFamiliaSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[ID],
	[IdUsuario],
	[IdFamilia]
FROM
	[UsuarioFamilia]


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioFamiliaSelectByIdFamilia]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioFamiliaSelectByIdFamilia]
GO

CREATE PROCEDURE [dbo].[UsuarioFamiliaSelectByIdFamilia] (
	@IdFamilia int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[ID],
	[IdUsuario],
	[IdFamilia]
FROM
	[UsuarioFamilia]
WHERE
	[IdFamilia] = @IdFamilia


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioFamiliaSelectByIdUsuario]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioFamiliaSelectByIdUsuario]
GO

CREATE PROCEDURE [dbo].[UsuarioFamiliaSelectByIdUsuario] (
	@IdUsuario int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[ID],
	[IdUsuario],
	[IdFamilia]
FROM
	[UsuarioFamilia]
WHERE
	[IdUsuario] = @IdUsuario


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FamiliaPatenteInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[FamiliaPatenteInsert]
GO

CREATE PROCEDURE [dbo].[FamiliaPatenteInsert] (
	@IdPatente int,
	@IdFamilia int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [FamiliaPatente] (
	[IdPatente],
	[IdFamilia]
) VALUES (
	@IdPatente,
	@IdFamilia
)

SELECT SCOPE_IDENTITY() AS ID
IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);
ELSE
	SELECT SCOPE_IDENTITY() AS ID
GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FamiliaPatenteUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[FamiliaPatenteUpdate]
GO

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FamiliaPatenteDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[FamiliaPatenteDelete]
GO

CREATE PROCEDURE [dbo].[FamiliaPatenteDelete] (
	@IdPatente int,
	@IdFamilia int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[FamiliaPatente]
WHERE
	[IdPatente] = @IdPatente
	AND [IdFamilia] = @IdFamilia


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FamiliaPatenteDeleteByIdFamilia]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[FamiliaPatenteDeleteByIdFamilia]
GO

CREATE PROCEDURE [dbo].[FamiliaPatenteDeleteByIdFamilia] (
	@IdFamilia int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[FamiliaPatente]
WHERE
	[IdFamilia] = @IdFamilia


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FamiliaPatenteDeleteByIdPatente]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[FamiliaPatenteDeleteByIdPatente]
GO

CREATE PROCEDURE [dbo].[FamiliaPatenteDeleteByIdPatente] (
	@IdPatente int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[FamiliaPatente]
WHERE
	[IdPatente] = @IdPatente


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FamiliaPatenteSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[FamiliaPatenteSelect]
GO

CREATE PROCEDURE [dbo].[FamiliaPatenteSelect] (
	@IdPatente int,
	@IdFamilia int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[ID],
	[IdPatente],
	[IdFamilia]
FROM
	[FamiliaPatente]
WHERE
	[IdPatente] = @IdPatente
	AND [IdFamilia] = @IdFamilia


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FamiliaPatenteSelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[FamiliaPatenteSelectAll]
GO

CREATE PROCEDURE [dbo].[FamiliaPatenteSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[ID],
	[IdPatente],
	[IdFamilia]
FROM
	[FamiliaPatente]


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FamiliaPatenteSelectByIdFamilia]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[FamiliaPatenteSelectByIdFamilia]
GO

CREATE PROCEDURE [dbo].[FamiliaPatenteSelectByIdFamilia] (
	@IdFamilia int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[ID],
	[IdPatente],
	[IdFamilia]
FROM
	[FamiliaPatente]
WHERE
	[IdFamilia] = @IdFamilia


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FamiliaPatenteSelectByIdPatente]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[FamiliaPatenteSelectByIdPatente]
GO

CREATE PROCEDURE [dbo].[FamiliaPatenteSelectByIdPatente] (
	@IdPatente int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[ID],
	[IdPatente],
	[IdFamilia]
FROM
	[FamiliaPatente]
WHERE
	[IdPatente] = @IdPatente


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioPatenteInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioPatenteInsert]
GO

CREATE PROCEDURE [dbo].[UsuarioPatenteInsert] (
	@IdUsuario int,
	@IdPatente int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [UsuarioPatente] (
	[IdUsuario],
	[IdPatente]
) VALUES (
	@IdUsuario,
	@IdPatente
)

SELECT SCOPE_IDENTITY() AS ID
IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);
ELSE
	SELECT SCOPE_IDENTITY() AS ID
GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioPatenteUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioPatenteUpdate]
GO


/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioPatenteDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioPatenteDelete]
GO

CREATE PROCEDURE [dbo].[UsuarioPatenteDelete] (
	@IdUsuario int,
	@IdPatente int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[UsuarioPatente]
WHERE
	[IdUsuario] = @IdUsuario
	AND [IdPatente] = @IdPatente


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioPatenteDeleteByIdUsuario]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioPatenteDeleteByIdUsuario]
GO

CREATE PROCEDURE [dbo].[UsuarioPatenteDeleteByIdUsuario] (
	@IdUsuario int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[UsuarioPatente]
WHERE
	[IdUsuario] = @IdUsuario


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioPatenteDeleteByIdPatente]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioPatenteDeleteByIdPatente]
GO

CREATE PROCEDURE [dbo].[UsuarioPatenteDeleteByIdPatente] (
	@IdPatente int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[UsuarioPatente]
WHERE
	[IdPatente] = @IdPatente


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioPatenteSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioPatenteSelect]
GO

CREATE PROCEDURE [dbo].[UsuarioPatenteSelect] (
	@IdUsuario int,
	@IdPatente int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[ID],
	[IdUsuario],
	[IdPatente]
FROM
	[UsuarioPatente]
WHERE
	[IdUsuario] = @IdUsuario
	AND [IdPatente] = @IdPatente


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioPatenteSelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioPatenteSelectAll]
GO

CREATE PROCEDURE [dbo].[UsuarioPatenteSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[ID],
	[IdUsuario],
	[IdPatente]
FROM
	[UsuarioPatente]


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioPatenteSelectByIdUsuario]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioPatenteSelectByIdUsuario]
GO

CREATE PROCEDURE [dbo].[UsuarioPatenteSelectByIdUsuario] (
	@IdUsuario int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[ID],
	[IdUsuario],
	[IdPatente]
FROM
	[UsuarioPatente]
WHERE
	[IdUsuario] = @IdUsuario


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioPatenteSelectByIdPatente]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioPatenteSelectByIdPatente]
GO

CREATE PROCEDURE [dbo].[UsuarioPatenteSelectByIdPatente] (
	@IdPatente int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[ID],
	[IdUsuario],
	[IdPatente]
FROM
	[UsuarioPatente]
WHERE
	[IdPatente] = @IdPatente


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
