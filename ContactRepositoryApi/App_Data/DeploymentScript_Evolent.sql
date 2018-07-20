-- DB CREATION
IF EXISTS (SELECT name FROM master.sys.databases WHERE name = N'ContactDB')
BEGIN
	DROP DATABASE ContactDB
END

-- CREATE DB
GO
CREATE DATABASE ContactDB

Go
-- TABLE CREATION
USE ContactDB
IF OBJECT_ID (N'[dbo].[Contact]', N'U') IS NOT NULL 
BEGIN
	DROP TABLE [dbo].[Contact]
END

Go
USE ContactDB
CREATE TABLE [dbo].[Contact](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](255) NOT NULL,
	[LastName] [varchar](255) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[PhoneNumber] [varchar](12) NOT NULL,
	[ContactStatus] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

-- end of create table script
GO

-- start of sps
-- GETALL 
USE ContactDB
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'[dbo].[sp_Contact_GetAllContacts]')
                    AND type IN ( N'P', N'PC' ) )
BEGIN
	DROP PROCEDURE [dbo].[sp_Contact_GetAllContacts]
END

GO

CREATE PROCEDURE [dbo].[sp_Contact_GetAllContacts]
AS
BEGIN
SELECT * FROM [dbo].[Contact]
END
GO

-- GET/ID
USE ContactDB
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'[dbo].[sp_Contact_GetContactByID]')
                    AND type IN ( N'P', N'PC' ) )
BEGIN
	DROP PROCEDURE [dbo].[sp_Contact_GetContactByID]
END

GO

CREATE PROCEDURE [dbo].[sp_Contact_GetContactByID]
(
@ContactID INT
)
AS
BEGIN
	SELECT * FROM [dbo].[Contact]
	WHERE ID=@ContactID
END
GO

-- INSERT
USE ContactDB
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'[dbo].[sp_Contact_InsertContact]')
                    AND type IN ( N'P', N'PC' ) )
BEGIN
	DROP PROCEDURE [dbo].[sp_Contact_InsertContact]
END

GO

CREATE PROCEDURE [dbo].[sp_Contact_InsertContact]
(
@FirstName VARCHAR(255),
@LastName VARCHAR(255),
@Email VARCHAR(255),
@PhoneNumer VARCHAR(12),
@ContactStatus BIT
)
AS
BEGIN
	INSERT INTO [dbo].[Contact]([FirstName]
      ,[LastName]
      ,[Email]
	  ,[PhoneNumber]
      ,[ContactStatus])
	VALUES (@FirstName,@LastName,@Email,@PhoneNumer,@ContactStatus)
	SELECT scope_identity() 
END
GO

-- REMOVE
USE ContactDB
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'[dbo].[sp_Contact_RemoveContact]')
                    AND type IN ( N'P', N'PC' ) )
BEGIN
	DROP PROCEDURE [dbo].[sp_Contact_RemoveContact]
END

GO

CREATE PROCEDURE [dbo].[sp_Contact_RemoveContact]
(
@ContactID INT
)
AS
BEGIN
	DELETE [dbo].[Contact]
	WHERE [ID]=@ContactID
END
GO

-- UPDATE
USE ContactDB
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'[dbo].[sp_Contact_UpdateContact]')
                    AND type IN ( N'P', N'PC' ) )
BEGIN
	DROP PROCEDURE [dbo].[sp_Contact_UpdateContact]
END

GO

CREATE PROCEDURE [dbo].[sp_Contact_UpdateContact]
(
@ContactID INT,
@FirstName VARCHAR(255),
@LastName VARCHAR(255),
@Email VARCHAR(255),
@PhoneNumer VARCHAR(12),
@ContactStatus BIT
)
AS
BEGIN
	UPDATE [dbo].[Contact] 
	SET	[FirstName]=@FirstName
      ,[LastName]=@LastName
      ,[Email]=@Email
	  ,[PhoneNumber]=@PhoneNumer
      ,[ContactStatus]=@ContactStatus
	WHERE [ID]=@ContactID
END

GO





