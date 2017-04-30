USE [Emprendimientos]
GO
/****** Object:  StoredProcedure [dbo].[Alta_Usuario]    Script Date: 30/04/2017 18:51:02 ******/
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
/****** Object:  StoredProcedure [dbo].[Buscar_Usuario]    Script Date: 30/04/2017 18:51:02 ******/
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
/****** Object:  Table [dbo].[Emprendimiento]    Script Date: 30/04/2017 18:51:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emprendimiento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](50) NULL,
	[Descripcion] [nvarchar](200) NULL,
	[PuntajeFinal] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Evaluacion]    Script Date: 30/04/2017 18:51:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evaluacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Evaluador] [int] NULL,
	[Emprendimiento] [int] NULL,
	[Puntaje] [int] NULL,
	[Justificacion] [nvarchar](200) NULL,
	[Fecha] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Evaluador]    Script Date: 30/04/2017 18:51:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evaluador](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Persona] [int] NULL,
	[Telefono] [nvarchar](50) NULL,
	[Calificacion] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persona]    Script Date: 30/04/2017 18:51:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [int] NULL,
	[Cedula] [nvarchar](8) NULL,
	[Nombre] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Emprendimiento] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 30/04/2017 18:51:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Rol] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Evaluacion]  WITH CHECK ADD  CONSTRAINT [FK_EvaluacionEmprendimiento] FOREIGN KEY([Emprendimiento])
REFERENCES [dbo].[Emprendimiento] ([Id])
GO
ALTER TABLE [dbo].[Evaluacion] CHECK CONSTRAINT [FK_EvaluacionEmprendimiento]
GO
ALTER TABLE [dbo].[Evaluacion]  WITH CHECK ADD  CONSTRAINT [FK_EvaluacionEvaluador] FOREIGN KEY([Evaluador])
REFERENCES [dbo].[Evaluador] ([Id])
GO
ALTER TABLE [dbo].[Evaluacion] CHECK CONSTRAINT [FK_EvaluacionEvaluador]
GO
ALTER TABLE [dbo].[Evaluador]  WITH CHECK ADD  CONSTRAINT [FK_Evaluador] FOREIGN KEY([Persona])
REFERENCES [dbo].[Persona] ([Id])
GO
ALTER TABLE [dbo].[Evaluador] CHECK CONSTRAINT [FK_Evaluador]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [Fk_Persona] FOREIGN KEY([Usuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [Fk_Persona]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_PersonaEmprendimiento] FOREIGN KEY([Emprendimiento])
REFERENCES [dbo].[Emprendimiento] ([Id])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_PersonaEmprendimiento]
GO
