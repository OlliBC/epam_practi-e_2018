USE master 
GO 

IF EXISTS(SELECT * FROM sys.databases WHERE name='Skill') 
BEGIN 
DROP DATABASE Skill
END 
GO 

CREATE DATABASE Skill
GO 

USE Skill
GO

CREATE TABLE [User] (
	id_user int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_USER] PRIMARY KEY,
	[Name] varchar(255) NOT NULL,
	[Password] varchar(100) NOT NULL,
	[Role] int NOT NULL
)
GO

CREATE TABLE Skill (
	id_skill int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_SKILL] PRIMARY KEY,
	[Name] varchar(255) NOT NULL,
	Comment varchar(300) NOT NULL
)
GO

CREATE TABLE UserSkill (
	id_user int NOT NULL,
	id_skill int NOT NULL
)
GO

ALTER TABLE [UserSkill] ADD CONSTRAINT [FK_UserSkill_User]
FOREIGN KEY ([id_user]) references [User]([id_user])
on delete cascade
on update cascade
GO

ALTER TABLE [UserSkill] ADD CONSTRAINT [FK_UserSkill_Skill]
FOREIGN KEY ([id_skill]) references [Skill]([id_skill])
on delete cascade
on update cascade
GO

CREATE CLUSTERED INDEX CL_INDEX_UserSkill_COMPOSITE
ON dbo.UserSkill (id_user, id_skill)
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE AddUser
	@NAME varchar(255),
	@PASSWORD varchar(100),
	@ROLE int
AS
BEGIN
	INSERT INTO [dbo].[User]
           ([Name]
           ,[Role]
           ,[Password])
     VALUES
           (@NAME
           ,@ROLE
           ,@PASSWORD)

	SELECT SCOPE_IDENTITY()
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetUsers
AS
BEGIN
	SELECT [id_user]
      ,[Name]
      ,[Role]
  FROM [Skill].[dbo].[User]
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE AddSkill 
	@ID_USER int,
	@NAME varchar(255),
	@COMMENT varchar(300)
AS
BEGIN
	INSERT INTO [dbo].[Skill]
           ([Name]
           ,[Comment])
     VALUES
           (@NAME
           ,@COMMENT)

	INSERT INTO [dbo].[UserSkill]
	([id_skill],
	[id_user])
	VALUES
	((SELECT TOP (1) id_skill FROM [dbo].Skill ORDER BY id_skill DESC),
	@ID_USER)

	SELECT SCOPE_IDENTITY()
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetSkills 
AS
BEGIN
SELECT [id_skill]
      ,[Name]
      ,[Comment]
  FROM [Skill].[dbo].[Skill]
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetUserById
	@ID int
AS
BEGIN
	SELECT [id_user]
      ,[Name]
      ,[Role]
  FROM [Skill].[dbo].[User]
  WHERE id_user = @ID
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetSkillById
	@ID int
AS
BEGIN
	SELECT [id_skill]
      ,[Name]
      ,[Comment]
  FROM [Skill].[dbo].[Skill]
  WHERE id_skill = @ID
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE UpdateUserForUsers
	@ID int,
	@NAME varchar(255)
AS
BEGIN
	UPDATE [dbo].[User]
   SET [Name] = @NAME
 WHERE id_user = @ID
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE UpdateUserForAdmin
	@ID int,
	@ROLE int
AS
BEGIN
	UPDATE [dbo].[User]
   SET [Role] = @ROLE
 WHERE id_user = @ID
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE UpdateSkill
	@ID int,
	@NAME varchar(255),
	@COMMENT varchar(300)
AS
BEGIN
	UPDATE [dbo].[Skill]
   SET [Name] = @NAME
   ,[Comment] = @COMMENT
 WHERE id_skill = @ID
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE DeleteUser
	@ID int
AS
BEGIN
	DELETE FROM [dbo].[User]
      WHERE id_user = @ID
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE DeleteSkill 
	@ID int
AS
BEGIN
	DELETE FROM dbo.Skill
	WHERE id_skill = @ID
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetAllSkillsForUser
	@ID_USER int
AS
BEGIN
	SELECT S.id_skill,
	S.Name,
	S.Comment
	FROM UserSkill as US
	JOIN Skill as S ON US.id_skill = S.id_skill
	WHERE US.id_user = @ID_USER
END
GO