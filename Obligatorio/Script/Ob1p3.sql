USE [Emprendimientos]
GO
/****** Object:  Table [dbo].[Emprendimiento]    Script Date: 02-May-17 19:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emprendimiento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](50) NULL,
	[Descripcion] [nvarchar](200) NULL,
	[PuntajeFinal] [int] NULL,
	[TiempoPrevisto] [int] NULL,
	[Costo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Evaluacion]    Script Date: 02-May-17 19:30:09 ******/
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
/****** Object:  Table [dbo].[Evaluador]    Script Date: 02-May-17 19:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evaluador](
	[IdEvaluador] [int] IDENTITY(1,1) NOT NULL,
	[Persona] [int] NULL,
	[Telefono] [nvarchar](50) NULL,
	[Calificacion] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEvaluador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persona]    Script Date: 02-May-17 19:30:09 ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 02-May-17 19:30:09 ******/
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
SET IDENTITY_INSERT [dbo].[Emprendimiento] ON 

INSERT [dbo].[Emprendimiento] ([Id], [Titulo], [Descripcion], [PuntajeFinal], [TiempoPrevisto], [Costo]) VALUES (1, N'Productos Quimicos', N'venta de productos quimicos a todo puiblico', 7, 15, 13500)
SET IDENTITY_INSERT [dbo].[Emprendimiento] OFF
SET IDENTITY_INSERT [dbo].[Evaluacion] ON 

INSERT [dbo].[Evaluacion] ([Id], [Evaluador], [Emprendimiento], [Puntaje], [Justificacion], [Fecha]) VALUES (1, 1, 1, 1, N'Quedo todo pipi cucu', CAST(N'2017-05-02 17:55:00.037' AS DateTime))
INSERT [dbo].[Evaluacion] ([Id], [Evaluador], [Emprendimiento], [Puntaje], [Justificacion], [Fecha]) VALUES (2, 2, 1, 3, N'Quedo todo pipi cucu', CAST(N'2017-05-02 17:58:48.090' AS DateTime))
INSERT [dbo].[Evaluacion] ([Id], [Evaluador], [Emprendimiento], [Puntaje], [Justificacion], [Fecha]) VALUES (4, 3, 1, 3, N'Quedo todo pipon', CAST(N'2017-05-02 18:25:30.377' AS DateTime))
SET IDENTITY_INSERT [dbo].[Evaluacion] OFF
SET IDENTITY_INSERT [dbo].[Evaluador] ON 

INSERT [dbo].[Evaluador] ([IdEvaluador], [Persona], [Telefono], [Calificacion]) VALUES (1, 1, N'26234923', 15)
INSERT [dbo].[Evaluador] ([IdEvaluador], [Persona], [Telefono], [Calificacion]) VALUES (2, 2, N'26234923', 15)
INSERT [dbo].[Evaluador] ([IdEvaluador], [Persona], [Telefono], [Calificacion]) VALUES (3, 3, N'26234923', 15)
SET IDENTITY_INSERT [dbo].[Evaluador] OFF
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([Id], [Usuario], [Cedula], [Nombre], [Email], [Emprendimiento]) VALUES (1, 2, N'47949083', N'Maximiliano Aloise', N'elpel@gmail.com', NULL)
INSERT [dbo].[Persona] ([Id], [Usuario], [Cedula], [Nombre], [Email], [Emprendimiento]) VALUES (2, 3, N'14488482', N'Francisco Arriola', N'franarrio@gmail.com', NULL)
INSERT [dbo].[Persona] ([Id], [Usuario], [Cedula], [Nombre], [Email], [Emprendimiento]) VALUES (3, 4, N'21477842', N'Juan Carlos', N'jc@gmail.com', NULL)
INSERT [dbo].[Persona] ([Id], [Usuario], [Cedula], [Nombre], [Email], [Emprendimiento]) VALUES (4, 5, N'21148795', N'Carlos Gallinal', N'carlosGallinal@gmail.com', 1)
INSERT [dbo].[Persona] ([Id], [Usuario], [Cedula], [Nombre], [Email], [Emprendimiento]) VALUES (5, 6, N'21148794', N'Pedro Fuentes', N'pedroFuentes@gmail.com', 1)
SET IDENTITY_INSERT [dbo].[Persona] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [Email], [Password], [Rol]) VALUES (1, N'admin', N'1', N'Admin')
INSERT [dbo].[Usuario] ([Id], [Email], [Password], [Rol]) VALUES (2, N'elpel@gmail.com', N'1', N'Evaluador')
INSERT [dbo].[Usuario] ([Id], [Email], [Password], [Rol]) VALUES (3, N'franarrio@gmail.com', N'1', N'Evaluador')
INSERT [dbo].[Usuario] ([Id], [Email], [Password], [Rol]) VALUES (4, N'jc@gmail.com', N'1', N'Evaluador')
INSERT [dbo].[Usuario] ([Id], [Email], [Password], [Rol]) VALUES (5, N'carlosGallinal@gmail.com', N'1', N'Postulante')
INSERT [dbo].[Usuario] ([Id], [Email], [Password], [Rol]) VALUES (6, N'pedroFuentes@gmail.com', N'1', N'Postulante')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UC_Empredimiento]    Script Date: 02-May-17 19:30:09 ******/
ALTER TABLE [dbo].[Emprendimiento] ADD  CONSTRAINT [UC_Empredimiento] UNIQUE NONCLUSTERED 
(
	[Titulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Persona__A9D1053497830E16]    Script Date: 02-May-17 19:30:09 ******/
ALTER TABLE [dbo].[Persona] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Persona__B4ADFE3895E8FF39]    Script Date: 02-May-17 19:30:09 ******/
ALTER TABLE [dbo].[Persona] ADD UNIQUE NONCLUSTERED 
(
	[Cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Evaluacion]  WITH CHECK ADD  CONSTRAINT [FK_EvaluacionEmprendimiento] FOREIGN KEY([Emprendimiento])
REFERENCES [dbo].[Emprendimiento] ([Id])
GO
ALTER TABLE [dbo].[Evaluacion] CHECK CONSTRAINT [FK_EvaluacionEmprendimiento]
GO
ALTER TABLE [dbo].[Evaluacion]  WITH CHECK ADD  CONSTRAINT [FK_EvaluacionEvaluador] FOREIGN KEY([Evaluador])
REFERENCES [dbo].[Evaluador] ([IdEvaluador])
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
/****** Object:  StoredProcedure [dbo].[ActualizarEvaluacion]    Script Date: 02-May-17 19:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarEvaluacion]
@idEvaluacion as int,
@puntaje as int,
@justificacion as nvarchar(200)
AS
BEGIN
	Update Evaluacion set Puntaje = @puntaje, Justificacion = @justificacion, Fecha = GETDATE()
	where id = @idEvaluacion
end
BEGIN
	declare @idEmprendimiento as int = 0;
	set @idEmprendimiento = (select Evaluacion.Emprendimiento from Evaluacion where id = @idEvaluacion)
		if(Select COUNT(Evaluacion.Emprendimiento) from Evaluacion where Emprendimiento = @idEmprendimiento) = 3
			Begin
				Update Emprendimiento set PuntajeFinal = (select SUM(evalua.Puntaje) FROM Evaluacion as evalua 
				where evalua.Emprendimiento = @idEmprendimiento) where Emprendimiento.id = @idEmprendimiento
			END
END

GO
/****** Object:  StoredProcedure [dbo].[Alta_Emprendimiento]    Script Date: 02-May-17 19:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Alta_Emprendimiento]
@titulo as nvarchar(50),
@descripcion as nvarchar(200),
@puntajeFinal as int,
@tiempoPrevisto as int,
@costo as int
AS
BEGIN
	Insert into Emprendimiento (Titulo, Descripcion, PuntajeFinal, TiempoPrevisto, Costo)
	Values  (@titulo, @descripcion, @puntajeFinal, @tiempoPrevisto, @costo)	
	SELECT CAST(SCOPE_IDENTITY() as int)
END


GO
/****** Object:  StoredProcedure [dbo].[Alta_Evaluacion]    Script Date: 02-May-17 19:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Alta_Evaluacion]
@evaluador as int,
@idEmprendimiento as int,
@retorno int OUTPUT
AS
BEGIN
if not Exists(Select e.Id from Evaluacion as e where @evaluador = e.Evaluador and @idEmprendimiento = e.Emprendimiento)
	begin
		if (Select COUNT(e.Emprendimiento) as Resultado from Evaluacion as e where @idEmprendimiento = e.Emprendimiento) < 3
			begin
				Insert into Evaluacion (Evaluador, Emprendimiento)
				values(@evaluador, @idEmprendimiento)
				set  @retorno = 1
				return @retorno
			end
		else
			begin
			set @retorno = -2
				return @retorno
			end
		end
else
	begin
	set @retorno = -3
		return @retorno
	END
END


GO
/****** Object:  StoredProcedure [dbo].[Alta_Persona]    Script Date: 02-May-17 19:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Alta_Persona]
@idUsuario as int,
@cedula as nvarchar(8),
@nombre as nvarchar(50),
@email as nvarchar(50),
@idEmprendimiento as int
AS
BEGIN
	Insert into Persona (Usuario, Cedula, Nombre, Email, Emprendimiento)
	Values  (@idUsuario, @cedula, @nombre, @email, @idEmprendimiento)
END


GO
/****** Object:  StoredProcedure [dbo].[Alta_Usuario]    Script Date: 02-May-17 19:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Alta_Usuario] 
@email as nvarchar(50),
@password as nvarchar(50),
@rol as nvarchar(50)
AS
BEGIN
	Insert into Usuario (Email, [Password], Rol)
	Values  (@email, @password, @rol)
	SELECT CAST(SCOPE_IDENTITY() as int)
END
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Usuario]    Script Date: 02-May-17 19:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Buscar_Usuario]
@email as nvarchar(50),
@password as nvarchar(50)
AS
BEGIN
	Select * from dbo.Usuario
	where @email = Email and @password = Password
END
GO
/****** Object:  StoredProcedure [dbo].[Obtener_Emprendimientos]    Script Date: 02-May-17 19:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Obtener_Emprendimientos]
AS
BEGIN
Select * from Emprendimiento
END


GO
/****** Object:  StoredProcedure [dbo].[Obtener_Evaluadores]    Script Date: 02-May-17 19:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Obtener_Evaluadores]
AS
BEGIN
Select * from Evaluador as e inner join Persona as p on e.Persona = p.Id
END


GO
/****** Object:  StoredProcedure [dbo].[ObtenerEmprendimientoPorEvaluador]    Script Date: 02-May-17 19:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerEmprendimientoPorEvaluador]
@email as nvarchar(50)
AS
BEGIN
	Select emp.Id,Titulo, Descripcion, ev.Id as IdEvaluacion, TiempoPrevisto, Costo from Emprendimiento emp 
								 inner join Evaluacion ev on emp.Id = ev.Emprendimiento 
								 inner join Evaluador eval on ev.Evaluador = eval.IdEvaluador
								 inner join Persona on eval.Persona = Persona.Id
								 inner join Usuario on Persona.Usuario = Usuario.Id
where ev.Puntaje is null and Usuario.Email = @email
END


GO
/****** Object:  StoredProcedure [dbo].[ObtenerEvaluadoresPorEmprendimiento]    Script Date: 02-May-17 19:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerEvaluadoresPorEmprendimiento]
AS
BEGIN
Select  emp.Id, 
		Titulo,
		Descripcion,
		PuntajeFinal,
		TiempoPrevisto,
		Costo,
		Persona.Nombre,
		Evaluador.IdEvaluador,
		ev.Justificacion as Justificacion

	from Emprendimiento emp			
	 
		inner join Evaluacion ev on emp.Id = ev.Emprendimiento
		inner join Evaluador on Evaluador.IdEvaluador = ev.Evaluador
		inner join Persona on Evaluador.Persona = Persona.Id

where Puntaje is not null and Evaluador.Persona = Persona.Id
END


GO
/****** Object:  StoredProcedure [dbo].[ObtenerIntegrantesPorEmprendimiento]    Script Date: 02-May-17 19:30:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Autho,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerIntegrantesPorEmprendimiento]
AS
BEGIN
Select  emp.Id, 
		Titulo,
		Descripcion,
		PuntajeFinal,
		TiempoPrevisto,
		Costo,
		Persona.Nombre
from Emprendimiento emp	inner join Persona on emp.Id = Persona.Emprendimiento
where PuntajeFinal is not null and emp.Id = Persona.Emprendimiento
END


GO
