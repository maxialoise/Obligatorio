USE [Emprendimientos]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarEvaluacion]    Script Date: 01/05/2017 23:25:44 ******/
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
END

GO
/****** Object:  StoredProcedure [dbo].[Alta_Emprendimiento]    Script Date: 01/05/2017 23:25:44 ******/
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
/****** Object:  StoredProcedure [dbo].[Alta_Evaluacion]    Script Date: 01/05/2017 23:25:44 ******/
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
				if(Select COUNT(e.Emprendimiento) as Resultado from Evaluacion as e where @idEmprendimiento = e.Emprendimiento) = 3
					begin
						Update Emprendimiento set PuntajeFinal = (select SUM(evalua.Puntaje) FROM Evaluacion as evalua 
						where evalua.Emprendimiento = @idEmprendimiento and Emprendimiento.Id = evalua.Emprendimiento)
					end
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
/****** Object:  StoredProcedure [dbo].[Alta_Persona]    Script Date: 01/05/2017 23:25:44 ******/
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
/****** Object:  StoredProcedure [dbo].[Alta_Usuario]    Script Date: 01/05/2017 23:25:44 ******/
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
	SELECT CAST(SCOPE_IDENTITY() as int)
END

GO
/****** Object:  StoredProcedure [dbo].[Buscar_Usuario]    Script Date: 01/05/2017 23:25:44 ******/
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
/****** Object:  StoredProcedure [dbo].[Obtener_Emprendimientos]    Script Date: 01/05/2017 23:25:44 ******/
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
/****** Object:  StoredProcedure [dbo].[Obtener_Evaluadores]    Script Date: 01/05/2017 23:25:44 ******/
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
/****** Object:  StoredProcedure [dbo].[ObtenerEmprendimientoPorEvaluador]    Script Date: 01/05/2017 23:25:44 ******/
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
/****** Object:  StoredProcedure [dbo].[ObtenerEvaluadoresPorEmprendimiento]    Script Date: 01/05/2017 23:25:44 ******/
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
/****** Object:  StoredProcedure [dbo].[ObtenerIntegrantesPorEmprendimiento]    Script Date: 01/05/2017 23:25:44 ******/
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
/****** Object:  Table [dbo].[Emprendimiento]    Script Date: 01/05/2017 23:25:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_Empredimiento] UNIQUE NONCLUSTERED 
(
	[Titulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Evaluacion]    Script Date: 01/05/2017 23:25:44 ******/
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
/****** Object:  Table [dbo].[Evaluador]    Script Date: 01/05/2017 23:25:44 ******/
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
/****** Object:  Table [dbo].[Persona]    Script Date: 01/05/2017 23:25:44 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 01/05/2017 23:25:44 ******/
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
