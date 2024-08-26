CREATE DATABASE [TP07 - PreguntadORT]

USE [TP07 - PreguntadORT]

GO
CREATE TABLE [dbo].[Categorias](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Foto] [varchar](max) NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dificultades](
	[IdDificultad] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Dificultades] PRIMARY KEY CLUSTERED 
(
	[IdDificultad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preguntas](
	[IdPregunta] [int] IDENTITY(1,1) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[IdDificultad] [int] NOT NULL,
	[Enunciado] [varchar](50) NOT NULL,
	[Foto] [varchar](max) NULL,
 CONSTRAINT [PK_Preguntas] PRIMARY KEY CLUSTERED 
(
	[IdPregunta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Respuestas](
	[IdRespuesta] [int] IDENTITY(1,1) NOT NULL,
	[IdPregunta] [int] NOT NULL,
	[Opcion] [int] NOT NULL,
	[Contenido] [varchar](max) NOT NULL,
	[Correcta] [bit] NOT NULL,
	[Foto] [varchar](max) NULL,
 CONSTRAINT [PK_Respuestas] PRIMARY KEY CLUSTERED 
(
	[IdRespuesta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([IdCategoria], [Nombre], [Foto]) VALUES (1, N'Historia', NULL)
INSERT [dbo].[Categorias] ([IdCategoria], [Nombre], [Foto]) VALUES (2, N'Ciencia', NULL)
INSERT [dbo].[Categorias] ([IdCategoria], [Nombre], [Foto]) VALUES (3, N'Geografía', NULL)
INSERT [dbo].[Categorias] ([IdCategoria], [Nombre], [Foto]) VALUES (4, N'Arte', NULL)
INSERT [dbo].[Categorias] ([IdCategoria], [Nombre], [Foto]) VALUES (5, N'Deportes', NULL)
SET IDENTITY_INSERT [dbo].[Categorias] OFF
GO
SET IDENTITY_INSERT [dbo].[Dificultades] ON 

INSERT [dbo].[Dificultades] ([IdDificultad], [Nombre]) VALUES (1, N'Fácil')
INSERT [dbo].[Dificultades] ([IdDificultad], [Nombre]) VALUES (2, N'Medio')
INSERT [dbo].[Dificultades] ([IdDificultad], [Nombre]) VALUES (3, N'Difícil')
SET IDENTITY_INSERT [dbo].[Dificultades] OFF
GO
SET IDENTITY_INSERT [dbo].[Preguntas] ON 

INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (13, 1, 1, N'¿Quién descubrió América?', NULL)
INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (14, 2, 2, N'¿Cuál es la fórmula del agua?', NULL)
INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (15, 3, 1, N'¿Cuál es la capital de Francia?', NULL)
INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (16, 4, 1, N'¿Quién pintó La Mona Lisa?', NULL)
INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (17, 5, 3, N'¿Quién ganó la Copa Mundial de la FIFA 2018?', NULL)
SET IDENTITY_INSERT [dbo].[Preguntas] OFF
GO
SET IDENTITY_INSERT [dbo].[Respuestas] ON 

INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (3, 13, 1, N'Cristóbal Colón', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (4, 13, 2, N'Amerigo Vespucci', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (5, 14, 1, N'H2O', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (6, 14, 2, N'CO2', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (7, 15, 1, N'París', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (8, 15, 2, N'Londres', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (9, 16, 1, N'Leonardo da Vinci', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (10, 16, 2, N'Vincent van Gogh', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (11, 17, 1, N'Francia', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (12, 17, 2, N'Croacia', 0, NULL)
SET IDENTITY_INSERT [dbo].[Respuestas] OFF
GO
ALTER TABLE [dbo].[Preguntas]  WITH CHECK ADD  CONSTRAINT [FK_Preguntas_Categorias] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorias] ([IdCategoria])
GO
ALTER TABLE [dbo].[Preguntas] CHECK CONSTRAINT [FK_Preguntas_Categorias]
GO
ALTER TABLE [dbo].[Preguntas]  WITH CHECK ADD  CONSTRAINT [FK_Preguntas_Dificultades] FOREIGN KEY([IdDificultad])
REFERENCES [dbo].[Dificultades] ([IdDificultad])
GO
ALTER TABLE [dbo].[Preguntas] CHECK CONSTRAINT [FK_Preguntas_Dificultades]
GO
ALTER TABLE [dbo].[Respuestas]  WITH CHECK ADD  CONSTRAINT [FK_Respuestas_Preguntas] FOREIGN KEY([IdPregunta])
REFERENCES [dbo].[Preguntas] ([IdPregunta])
GO
ALTER TABLE [dbo].[Respuestas] CHECK CONSTRAINT [FK_Respuestas_Preguntas]
GO
ALTER TABLE [dbo].[Respuestas]  WITH CHECK ADD  CONSTRAINT [FK_Respuestas_Preguntas1] FOREIGN KEY([IdPregunta])
REFERENCES [dbo].[Preguntas] ([IdPregunta])
GO
ALTER TABLE [dbo].[Respuestas] CHECK CONSTRAINT [FK_Respuestas_Preguntas1]
GO
USE [master]
GO
ALTER DATABASE [TP07 - PreguntadORT] SET  READ_WRITE 
GO