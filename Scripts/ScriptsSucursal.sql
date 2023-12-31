USE [TestDB]
GO
/****** Object:  Table [dbo].[TBL_MONEDAS]    Script Date: 27/10/2023 2:56:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_MONEDAS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_SUCURSALES]    Script Date: 27/10/2023 2:56:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_SUCURSALES](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](250) NULL,
	[Descripcion] [varchar](250) NULL,
	[Direccion] [varchar](250) NULL,
	[Identificacion] [varchar](50) NULL,
	[FechaCreacion] [datetime] NULL,
	[IdMoneda] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TBL_MONEDAS] ON 

INSERT [dbo].[TBL_MONEDAS] ([ID], [Nombre]) VALUES (1, N'Dolar')
INSERT [dbo].[TBL_MONEDAS] ([ID], [Nombre]) VALUES (2, N'Euro')
INSERT [dbo].[TBL_MONEDAS] ([ID], [Nombre]) VALUES (3, N'Peso')
INSERT [dbo].[TBL_MONEDAS] ([ID], [Nombre]) VALUES (4, N'Yen')
SET IDENTITY_INSERT [dbo].[TBL_MONEDAS] OFF
GO
SET IDENTITY_INSERT [dbo].[TBL_SUCURSALES] ON 

INSERT [dbo].[TBL_SUCURSALES] ([Codigo], [Nombre], [Descripcion], [Direccion], [Identificacion], [FechaCreacion], [IdMoneda]) VALUES (1, N'OFICINA CENTRAL (VENECIA)', N'Esta sede es de venecia actualizada', N'carrera 68D #39F – 51', N'1022', CAST(N'2023-06-24T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[TBL_SUCURSALES] ([Codigo], [Nombre], [Descripcion], [Direccion], [Identificacion], [FechaCreacion], [IdMoneda]) VALUES (2, N'OFICINA CENTRAL (FONTIBON)', N'Esta sede es de Fontibon actualizada', N'carrera 78D #49F – 61', N'1023', CAST(N'2023-06-24T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[TBL_SUCURSALES] ([Codigo], [Nombre], [Descripcion], [Direccion], [Identificacion], [FechaCreacion], [IdMoneda]) VALUES (3, N'OFICINA CENTRAL (SUBA)', N'Esta sede es de Suba actualizada', N'carrera 88D #49F – 71', N'1024', CAST(N'2023-06-24T00:00:00.000' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[TBL_SUCURSALES] OFF
GO
ALTER TABLE [dbo].[TBL_SUCURSALES]  WITH CHECK ADD FOREIGN KEY([IdMoneda])
REFERENCES [dbo].[TBL_MONEDAS] ([ID])
GO
/****** Object:  StoredProcedure [dbo].[PA_ACTUALIZAR_SUCURSAL]    Script Date: 27/10/2023 2:56:09 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================================
-- Author:		Joan Andres Rincon Garcia 	
-- Create date: 2023-10-27
-- Description:	Actualizar sucursal por codigo
-- =============================================================

CREATE PROCEDURE [dbo].[PA_ACTUALIZAR_SUCURSAL]
	@Codigo INT,
	@Nombre VARCHAR(250),
	@Descripcion VARCHAR(250),
	@Direccion VARCHAR(250),
	@Identificacion VARCHAR(50),
	@FechaCreacion DATETIME,
	@IdMoneda INT
AS
BEGIN
	UPDATE TBL_SUCURSALES 
		SET 
			Nombre = @Nombre,
			Descripcion = @Descripcion,
			Direccion = @Direccion,
			Identificacion = @Identificacion,
			FechaCreacion = @FechaCreacion,
			IdMoneda = @IdMoneda
		WHERE Codigo = @Codigo
END

GO
/****** Object:  StoredProcedure [dbo].[PA_BUSCAR_SUCURSAL_POR_CODIGO]    Script Date: 27/10/2023 2:56:09 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================================
-- Author:		Joan Andres Rincon Garcia 	
-- Create date: 2023-10-27
-- Description:	Consultar sucursal por codigo
-- =============================================================

CREATE PROCEDURE [dbo].[PA_BUSCAR_SUCURSAL_POR_CODIGO]
	@Codigo INT
AS
BEGIN
	SELECT * FROM TBL_SUCURSALES WHERE Codigo = @Codigo
END

GO
/****** Object:  StoredProcedure [dbo].[PA_CREAR_SUSCURSAL]    Script Date: 27/10/2023 2:56:09 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================================
-- Author:		Joan Andres Rincon Garcia 	
-- Create date: 2023-10-27
-- Description:	Crear un nuevo registro en la TBL_SUCURSAL
-- =============================================================

CREATE PROCEDURE [dbo].[PA_CREAR_SUSCURSAL]
	@Nombre VARCHAR(250),
	@Descripcion VARCHAR(250),
	@Direccion VARCHAR(250),
	@Identificacion VARCHAR(50),
	@FechaCreacion DATETIME,
	@IdMoneda INT
AS
BEGIN
	INSERT INTO TBL_SUCURSALES (Nombre,Descripcion,Direccion,Identificacion,FechaCreacion,IdMoneda)
		VALUES
			(@Nombre, @Descripcion, @Direccion, @Identificacion,@FechaCreacion,@IdMoneda)
	SELECT SCOPE_IDENTITY();
END

GO
/****** Object:  StoredProcedure [dbo].[PA_ELIMINAR_SUCURSAL]    Script Date: 27/10/2023 2:56:09 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================================
-- Author:		Joan Andres Rincon Garcia 	
-- Create date: 2023-10-27
-- Description:	Eliminar un registro de la TBL_SUCURSALES
-- =============================================================

CREATE PROCEDURE [dbo].[PA_ELIMINAR_SUCURSAL]
	@Codigo INT
AS
BEGIN
	DELETE TBL_SUCURSALES WHERE Codigo = @Codigo
END
GO
/****** Object:  StoredProcedure [dbo].[PA_LISTAR_SUCURSALES]    Script Date: 27/10/2023 2:56:09 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================================
-- Author:		Joan Andres Rincon Garcia 	
-- Create date: 2023-10-27
-- Description:	Consultar todas las sucursales
-- =============================================================

CREATE PROCEDURE [dbo].[PA_LISTAR_SUCURSALES]

AS
BEGIN
	SELECT Codigo,
	S.Nombre,
	Descripcion,
	Direccion,
	Identificacion,
	FechaCreacion,
	M.Nombre Moneda
	FROM TBL_SUCURSALES S INNER JOIN TBL_MONEDAS M ON S.IdMoneda = M.ID
END

GO
