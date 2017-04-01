USE [Emprendimientos]
GO
/****** Object:  StoredProcedure [dbo].[Alta_Usuario]    Script Date: 01/04/2017 19:13:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Alta_Usuario] 
@email as nvarchar(50),
@password as nvarchar(50),
@rol as nvarchar(50)
AS
BEGIN
	Insert into Usuario (Email, [Password], Rol)
	Values  (@email, @password, @rol)
END

GO
/****** Object:  StoredProcedure [dbo].[Buscar_Usuario]    Script Date: 01/04/2017 19:13:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Buscar_Usuario]
@email as nvarchar(50),
@password as nvarchar(50)
AS
BEGIN
	Select * from dbo.Usuario
	where @email = Email and @password = Password
END

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 01/04/2017 19:13:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Rol] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
