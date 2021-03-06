USE [master]
GO
/****** Object:  Database [Resumamos]    Script Date: 25/10/2020 18:29:55 ******/
CREATE DATABASE [Resumamos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Resumamos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Resumamos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Resumamos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Resumamos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Resumamos] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Resumamos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Resumamos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Resumamos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Resumamos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Resumamos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Resumamos] SET ARITHABORT OFF 
GO
ALTER DATABASE [Resumamos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Resumamos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Resumamos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Resumamos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Resumamos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Resumamos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Resumamos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Resumamos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Resumamos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Resumamos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Resumamos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Resumamos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Resumamos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Resumamos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Resumamos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Resumamos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Resumamos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Resumamos] SET RECOVERY FULL 
GO
ALTER DATABASE [Resumamos] SET  MULTI_USER 
GO
ALTER DATABASE [Resumamos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Resumamos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Resumamos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Resumamos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Resumamos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Resumamos] SET QUERY_STORE = OFF
GO
USE [Resumamos]
GO
/****** Object:  Table [dbo].[Ano]    Script Date: 25/10/2020 18:29:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ano](
	[ano] [int] NOT NULL,
	[escri] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carrito]    Script Date: 25/10/2020 18:29:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrito](
	[FkLibro] [int] NOT NULL,
	[FkUsuario] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comentarios]    Script Date: 25/10/2020 18:29:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comentarios](
	[IdComentario] [int] IDENTITY(1,1) NOT NULL,
	[Contenido] [varchar](max) NOT NULL,
	[FkUsuario] [int] NOT NULL,
	[FkResumen] [int] NOT NULL,
	[Fecha] [date] NULL,
 CONSTRAINT [PK_Comentarios] PRIMARY KEY CLUSTERED 
(
	[IdComentario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Denuncias]    Script Date: 25/10/2020 18:29:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Denuncias](
	[IdDenuncia] [int] IDENTITY(1,1) NOT NULL,
	[FkUsuario] [int] NOT NULL,
	[FkTipoDeDenuncia] [int] NOT NULL,
	[FkResumen] [int] NOT NULL,
 CONSTRAINT [PK_Denuncias] PRIMARY KEY CLUSTERED 
(
	[IdDenuncia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Escuelas]    Script Date: 25/10/2020 18:29:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Escuelas](
	[IdEscuela] [int] IDENTITY(1,1) NOT NULL,
	[NombreEscuela] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GuardadoLi]    Script Date: 25/10/2020 18:29:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GuardadoLi](
	[FkLibro] [int] NOT NULL,
	[FkUsuario] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guardados]    Script Date: 25/10/2020 18:29:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guardados](
	[FkResumen] [int] NOT NULL,
	[FkUsuario] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libros]    Script Date: 25/10/2020 18:29:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libros](
	[IdLibro] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Precio] [float] NOT NULL,
	[FkVendedor] [int] NOT NULL,
	[FkMateria] [int] NOT NULL,
	[Editorial] [varchar](100) NOT NULL,
	[Lugar] [varchar](100) NOT NULL,
	[NombreImagen] [varchar](100) NOT NULL,
	[FkAno] [int] NOT NULL,
	[Aprobado] [bit] NOT NULL,
	[Division] [varchar](100) NOT NULL,
	[FkEscuela] [int] NOT NULL,
	[FkComprador] [int] NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[Telefono] [int] NOT NULL,
 CONSTRAINT [PK_Libros] PRIMARY KEY CLUSTERED 
(
	[IdLibro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materias]    Script Date: 25/10/2020 18:29:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materias](
	[IdMateria] [int] IDENTITY(1,1) NOT NULL,
	[NombreMateria] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Materias] PRIMARY KEY CLUSTERED 
(
	[IdMateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preguntas]    Script Date: 25/10/2020 18:29:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preguntas](
	[IdPregunta] [int] IDENTITY(1,1) NOT NULL,
	[FkUsuario] [int] NOT NULL,
	[Contenido] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Preguntas] PRIMARY KEY CLUSTERED 
(
	[IdPregunta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Respuestas]    Script Date: 25/10/2020 18:29:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Respuestas](
	[IdRespuesta] [int] NOT NULL,
	[FkPregunta] [int] IDENTITY(1,1) NOT NULL,
	[Respuesta] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Respuestas] PRIMARY KEY CLUSTERED 
(
	[IdRespuesta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resumenes]    Script Date: 25/10/2020 18:29:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resumenes](
	[IdResumen] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[FkMateria] [int] NOT NULL,
	[FkUsuario] [int] NOT NULL,
	[Puntuacion] [int] NOT NULL,
	[Anio] [int] NOT NULL,
	[Archivo] [varchar](max) NOT NULL,
	[FkEscuela] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Aprobado] [bit] NOT NULL,
	[Descripcion] [varchar](max) NULL,
 CONSTRAINT [PK_Resumenes] PRIMARY KEY CLUSTERED 
(
	[IdResumen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 25/10/2020 18:29:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[IdTag] [int] IDENTITY(1,1) NOT NULL,
	[Tag] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[IdTag] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TagsXResumen]    Script Date: 25/10/2020 18:29:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagsXResumen](
	[FkTag] [int] NOT NULL,
	[FkResumen] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposDeDenuncia]    Script Date: 25/10/2020 18:29:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposDeDenuncia](
	[IdTipoDenuncia] [int] IDENTITY(1,1) NOT NULL,
	[TipoDenuncia] [varchar](max) NOT NULL,
 CONSTRAINT [PK_TiposDeDenuncia] PRIMARY KEY CLUSTERED 
(
	[IdTipoDenuncia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 25/10/2020 18:29:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Contrasena] [varchar](max) NOT NULL,
	[Mail] [varchar](50) NOT NULL,
	[Admin] [bit] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[PuntuacionUs] [float] NOT NULL,
	[FkEscuela] [int] NULL,
	[Creditos] [int] NOT NULL,
	[FotoPerfil] [varchar](max) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VotosXUsuario]    Script Date: 25/10/2020 18:29:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VotosXUsuario](
	[FkResumen] [int] NOT NULL,
	[FkUsuario] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Ano] ([ano], [escri]) VALUES (7, N'7mo grado')
INSERT [dbo].[Ano] ([ano], [escri]) VALUES (1, N'1ro año')
INSERT [dbo].[Ano] ([ano], [escri]) VALUES (2, N'2do año')
INSERT [dbo].[Ano] ([ano], [escri]) VALUES (3, N'3ro año')
INSERT [dbo].[Ano] ([ano], [escri]) VALUES (4, N'4to año')
INSERT [dbo].[Ano] ([ano], [escri]) VALUES (5, N'5to año')
SET IDENTITY_INSERT [dbo].[Comentarios] ON 

INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (1, N'Boquita campeon', 6, 2, CAST(N'2020-03-14' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (2, N'Hola me llamo kryss', 5, 7, CAST(N'2020-06-12' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (3, N'Hola me llamo kryss', 5, 7, CAST(N'2020-06-12' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (4, N'Hola', 5, 8, CAST(N'2020-06-12' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (5, N'Hola, este resumen es muy bueno, la verdad es q me re sirivio para la prueba de lengua. diego etlis hizo una prueba muy dificil y gracias a ustedes la pude pasar', 5, 7, CAST(N'2020-06-12' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (6, N'Buenardo Silva', 5, 15, CAST(N'2020-06-12' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (7, N'Es el mas capito', 5, 45, CAST(N'2020-06-12' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (8, N'Este resumen me re sirvio', 5, 5, CAST(N'2020-06-13' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (9, N'Este resumen es muy bueno', 5, 1061, CAST(N'2020-06-19' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (10, N'vrdsx', 7, 1061, CAST(N'2020-06-19' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (11, N'cami fist la mas capita', 5, 1062, CAST(N'2020-06-20' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (12, N'edcs', 5, 1062, CAST(N'2020-06-20' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (1009, N'cx ', 5, 1059, CAST(N'2020-06-26' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (1010, N'Resumen excelente!!! Me sirvio muchisimo', 5, 1058, CAST(N'2020-07-03' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (1011, N'Hola
', 5, 1058, CAST(N'2020-07-03' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (1012, N'Gran resumen, gracias a esto aprobe fisica de 4to año.', 5, 1053, CAST(N'2020-07-03' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (1013, N'Me sirvio cuando me la lleve con flor pelaez
', 15, 1059, CAST(N'2020-07-04' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (1014, N'aaaa', 5, 1059, CAST(N'2020-07-16' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (1015, N'Excelente', 5, 1053, CAST(N'2001-01-01' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (1016, N'Muy bueno', 5, 1058, CAST(N'2001-01-01' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (1017, N'Malaso', 5, 1058, CAST(N'2020-08-19' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (1018, N'aaaa', -1, 1059, CAST(N'2020-08-22' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (1019, N'es muy malo horrible', 22, 1058, CAST(N'2020-10-03' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (1020, N'es muy malo horrible', 3, 1057, CAST(N'2020-10-03' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (1021, N'es muy malo horrible', 3, 1057, CAST(N'2020-10-03' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (1022, N'hola', 3, 1057, CAST(N'2020-10-10' AS Date))
INSERT [dbo].[Comentarios] ([IdComentario], [Contenido], [FkUsuario], [FkResumen], [Fecha]) VALUES (1023, N'es muy malo horrible', 3, 1057, CAST(N'2020-10-14' AS Date))
SET IDENTITY_INSERT [dbo].[Comentarios] OFF
SET IDENTITY_INSERT [dbo].[Denuncias] ON 

INSERT [dbo].[Denuncias] ([IdDenuncia], [FkUsuario], [FkTipoDeDenuncia], [FkResumen]) VALUES (4, -1, 1, 1058)
SET IDENTITY_INSERT [dbo].[Denuncias] OFF
SET IDENTITY_INSERT [dbo].[Escuelas] ON 

INSERT [dbo].[Escuelas] ([IdEscuela], [NombreEscuela]) VALUES (1, N'ORT')
INSERT [dbo].[Escuelas] ([IdEscuela], [NombreEscuela]) VALUES (2, N'Martin Buber')
INSERT [dbo].[Escuelas] ([IdEscuela], [NombreEscuela]) VALUES (3, N'Sholem Aleijem')
SET IDENTITY_INSERT [dbo].[Escuelas] OFF
INSERT [dbo].[GuardadoLi] ([FkLibro], [FkUsuario]) VALUES (2, 3)
INSERT [dbo].[Guardados] ([FkResumen], [FkUsuario]) VALUES (-1, -1)
INSERT [dbo].[Guardados] ([FkResumen], [FkUsuario]) VALUES (-1, -1)
INSERT [dbo].[Guardados] ([FkResumen], [FkUsuario]) VALUES (1061, 7)
INSERT [dbo].[Guardados] ([FkResumen], [FkUsuario]) VALUES (1057, 5)
INSERT [dbo].[Guardados] ([FkResumen], [FkUsuario]) VALUES (1058, 5)
INSERT [dbo].[Guardados] ([FkResumen], [FkUsuario]) VALUES (1059, 15)
INSERT [dbo].[Guardados] ([FkResumen], [FkUsuario]) VALUES (1058, 21)
INSERT [dbo].[Guardados] ([FkResumen], [FkUsuario]) VALUES (1057, 3)
SET IDENTITY_INSERT [dbo].[Libros] ON 

INSERT [dbo].[Libros] ([IdLibro], [Nombre], [Precio], [FkVendedor], [FkMateria], [Editorial], [Lugar], [NombreImagen], [FkAno], [Aprobado], [Division], [FkEscuela], [FkComprador], [Descripcion], [Telefono]) VALUES (3, N'El guardian entre el centeno', 400, 10, 6, N'Santillana', N'Villa Crespo', N'Katche el constructor.jpg', 3, 1, N'3IA', 3, -1, N'vedsvrfd', 0)
INSERT [dbo].[Libros] ([IdLibro], [Nombre], [Precio], [FkVendedor], [FkMateria], [Editorial], [Lugar], [NombreImagen], [FkAno], [Aprobado], [Division], [FkEscuela], [FkComprador], [Descripcion], [Telefono]) VALUES (4, N'Geografia 1', 250, 4, 6, N'Atlantida', N'Palermo', N'Katche el constructor.jpg', 1, 1, N'1A', 1, -1, N'vefdsc', 0)
INSERT [dbo].[Libros] ([IdLibro], [Nombre], [Precio], [FkVendedor], [FkMateria], [Editorial], [Lugar], [NombreImagen], [FkAno], [Aprobado], [Division], [FkEscuela], [FkComprador], [Descripcion], [Telefono]) VALUES (5, N'Mi Libro luna de pluton', 127, 4, 5, N'Luneta', N'La concha de tu hermana', N'Katche el constructor.jpg', 2, 1, N'5IA', 3, -1, N'Mi libro', 2653)
INSERT [dbo].[Libros] ([IdLibro], [Nombre], [Precio], [FkVendedor], [FkMateria], [Editorial], [Lugar], [NombreImagen], [FkAno], [Aprobado], [Division], [FkEscuela], [FkComprador], [Descripcion], [Telefono]) VALUES (6, N'Juan ', 521, 4, 2, N'Luneta', N'En la casa de tu vieja', N'Katche el constructor.jpg', 3, 1, N'5IA', 2, -1, N'YYYYYYYYYYY', 1520)
INSERT [dbo].[Libros] ([IdLibro], [Nombre], [Precio], [FkVendedor], [FkMateria], [Editorial], [Lugar], [NombreImagen], [FkAno], [Aprobado], [Division], [FkEscuela], [FkComprador], [Descripcion], [Telefono]) VALUES (7, N'Libro de prueba 1', 150, 5, 10, N'Nose', N'La concha de tu madre', N'Katche el constructor.jpg', 4, 1, N'4kc', 2, -1, N'EHDN ,c', 1587621456)
INSERT [dbo].[Libros] ([IdLibro], [Nombre], [Precio], [FkVendedor], [FkMateria], [Editorial], [Lugar], [NombreImagen], [FkAno], [Aprobado], [Division], [FkEscuela], [FkComprador], [Descripcion], [Telefono]) VALUES (8, N'Matias', 1, 3, 12, N'aaaa', N'a', N'bethilel.jpg', 2, 1, N'3a', 3, -1, N'aaaaaaaa', 12344)
SET IDENTITY_INSERT [dbo].[Libros] OFF
SET IDENTITY_INSERT [dbo].[Materias] ON 

INSERT [dbo].[Materias] ([IdMateria], [NombreMateria]) VALUES (1, N'Matemática')
INSERT [dbo].[Materias] ([IdMateria], [NombreMateria]) VALUES (2, N'Lengua')
INSERT [dbo].[Materias] ([IdMateria], [NombreMateria]) VALUES (3, N'Historia')
INSERT [dbo].[Materias] ([IdMateria], [NombreMateria]) VALUES (4, N'Historia Judía')
INSERT [dbo].[Materias] ([IdMateria], [NombreMateria]) VALUES (5, N'Física')
INSERT [dbo].[Materias] ([IdMateria], [NombreMateria]) VALUES (6, N'Cultura Judaica')
INSERT [dbo].[Materias] ([IdMateria], [NombreMateria]) VALUES (7, N'Economía')
INSERT [dbo].[Materias] ([IdMateria], [NombreMateria]) VALUES (8, N'Programacion')
INSERT [dbo].[Materias] ([IdMateria], [NombreMateria]) VALUES (9, N'Etica')
INSERT [dbo].[Materias] ([IdMateria], [NombreMateria]) VALUES (10, N'Biologia')
INSERT [dbo].[Materias] ([IdMateria], [NombreMateria]) VALUES (11, N'Geografia')
INSERT [dbo].[Materias] ([IdMateria], [NombreMateria]) VALUES (12, N'Ingles')
INSERT [dbo].[Materias] ([IdMateria], [NombreMateria]) VALUES (13, N'Quimica')
INSERT [dbo].[Materias] ([IdMateria], [NombreMateria]) VALUES (14, N'Fisico-quimica')
INSERT [dbo].[Materias] ([IdMateria], [NombreMateria]) VALUES (15, N'Arte')
INSERT [dbo].[Materias] ([IdMateria], [NombreMateria]) VALUES (16, N'Tecnologia')
INSERT [dbo].[Materias] ([IdMateria], [NombreMateria]) VALUES (17, N'Informatica')
INSERT [dbo].[Materias] ([IdMateria], [NombreMateria]) VALUES (18, N'Gestion')
INSERT [dbo].[Materias] ([IdMateria], [NombreMateria]) VALUES (19, N'Construcciones')
INSERT [dbo].[Materias] ([IdMateria], [NombreMateria]) VALUES (20, N'Produccion musical')
INSERT [dbo].[Materias] ([IdMateria], [NombreMateria]) VALUES (21, N'Electronica')
INSERT [dbo].[Materias] ([IdMateria], [NombreMateria]) VALUES (22, N'Quimica ')
INSERT [dbo].[Materias] ([IdMateria], [NombreMateria]) VALUES (1011, N'TI')
SET IDENTITY_INSERT [dbo].[Materias] OFF
SET IDENTITY_INSERT [dbo].[Resumenes] ON 

INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela], [Fecha], [Aprobado], [Descripcion]) VALUES (1046, N'Palitos chinos', 1, 5, 5, 7, N'WBS Final.jpg', 1, CAST(N'2020-06-17' AS Date), 1, N'')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela], [Fecha], [Aprobado], [Descripcion]) VALUES (1048, N'El guardian entre el centeno', 2, 3, 6, 7, N'index.html', 1, CAST(N'2020-06-17' AS Date), 1, N'')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela], [Fecha], [Aprobado], [Descripcion]) VALUES (1049, N'Sistema endocrino', 10, 5, 2, 2, N'A y Z.docx', 2, CAST(N'2020-06-17' AS Date), 1, N'Con las explicacion de las profes de todos los cursos, ya que es una mezcla entre todos los resumenes')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela], [Fecha], [Aprobado], [Descripcion]) VALUES (1050, N'Eclesiastes Resumen', 6, 5, 3, 7, N'TP4.iml', 1, CAST(N'2020-06-17' AS Date), 1, N'')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela], [Fecha], [Aprobado], [Descripcion]) VALUES (1051, N'2da Guerra mundial', 3, 2, 8, 4, N'Ejer0bis Repaso.jpg', 2, CAST(N'2020-06-17' AS Date), 1, N'Puede llegar a servir para los chicos de ORT, ya que el profesor es jorge Wozniak ')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela], [Fecha], [Aprobado], [Descripcion]) VALUES (1053, N'Colisiones', 5, 6, 15, 3, N'TP HJ Bendayan-Kryss-Serrano-Mikowski.docx', 1, CAST(N'2020-06-17' AS Date), 1, N'Colisiones simples y complejas')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela], [Fecha], [Aprobado], [Descripcion]) VALUES (1054, N'Ejemplos de consultas SQL', 7, 3, 4, 3, N'bd1.sql', 2, CAST(N'2020-06-17' AS Date), 1, N'')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela], [Fecha], [Aprobado], [Descripcion]) VALUES (1055, N'Resumen etica', 9, 2, 12, 3, N'TP Filosofia Bendayan&Bursztyn.docx', 3, CAST(N'2020-06-17' AS Date), 1, N'')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela], [Fecha], [Aprobado], [Descripcion]) VALUES (1056, N'Cuarta Alia ', 4, 7, 8, 5, N'TP HJ Bendayan-Kryss-Serrano-Mikowski.docx', 1, CAST(N'2020-06-17' AS Date), 1, N'Cuarta Alia explicado by Maurito Enbe')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela], [Fecha], [Aprobado], [Descripcion]) VALUES (1059, N'Funcion cuadratica', 1, 4, 17, 5, N'Diego.jpg', 3, CAST(N'2020-06-17' AS Date), 1, N'Explicacion de vertice')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela], [Fecha], [Aprobado], [Descripcion]) VALUES (1060, N'Resumen programacion ', 8, 5, 7, 4, N'MaradonaEnfermera.jpg', 1, CAST(N'2020-06-17' AS Date), 1, N'Contiene ASP.NET MVC con Helpers')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela], [Fecha], [Aprobado], [Descripcion]) VALUES (1061, N'Funcion polinomica', 1, 5, 1, 4, N'Trabajo práctico 5-Bendayan.docx', 1, CAST(N'2020-06-19' AS Date), 1, N'Contiene como hacer para obtener....')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela], [Fecha], [Aprobado], [Descripcion]) VALUES (2056, N'Producto Berretin', 1, 5, 0, 7, N'IMG-3502.jpg', 1, CAST(N'0001-01-01' AS Date), 1, N'El mejor producto de la tierra')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela], [Fecha], [Aprobado], [Descripcion]) VALUES (2058, N'Prueba99', 1, 5, 0, 7, N'Writing penpal.docx', 1, CAST(N'0001-01-01' AS Date), 1, N'bvfds')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela], [Fecha], [Aprobado], [Descripcion]) VALUES (3056, N'Prueba 1026', 6, 5, 0, 7, N'Braian entrada.mp4', 2, CAST(N'2020-09-04' AS Date), 1, N'El mejor resumen')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela], [Fecha], [Aprobado], [Descripcion]) VALUES (3057, N'Prueba 8100', 6, 5, 2, 5, N'bd1.sql', 2, CAST(N'2020-09-04' AS Date), 1, N'Fafa')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela], [Fecha], [Aprobado], [Descripcion]) VALUES (3059, N'julian', 1, 3, 0, 7, N'Thumbnail25d0a8b7.png', 1, CAST(N'2020-10-10' AS Date), 1, N'')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela], [Fecha], [Aprobado], [Descripcion]) VALUES (3060, N'Matias', 1, 5, 0, 7, N'PrimeraPublicacion3.jpg', 1, CAST(N'2020-10-10' AS Date), 1, N'.')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela], [Fecha], [Aprobado], [Descripcion]) VALUES (3061, N'Funcion polinomica', 1, 3, 0, 7, N'ppt final.pptx', 1, CAST(N'0001-01-01' AS Date), 1, N'puto')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela], [Fecha], [Aprobado], [Descripcion]) VALUES (3062, N'Matias', 15, 3, 0, 7, N'38a7a2de-3735-4c8b-b7c3-c131398504ec.jpg', 3, CAST(N'0001-01-01' AS Date), 0, N'aaaaaa')
SET IDENTITY_INSERT [dbo].[Resumenes] OFF
SET IDENTITY_INSERT [dbo].[Tags] ON 

INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1, N'Funciones')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (2, N'Analisis sintactico')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (3, N'Present Perfect')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (4, N'Atomos')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1003, N'lengua')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1004, N'hola')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1005, N'pablo')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1007, N'Wilder')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1008, N'juan')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1009, N'pedro')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1010, N'julian')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1011, N'martin')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1012, N'matematica')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1013, N'reproduccion asexual')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1014, N'setembrini')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1015, N'animales')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1016, N'plantas')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1017, N'')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1018, N'cred')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1019, N'frc')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1020, N'alan')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1021, N'mile')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1022, N'ricardo')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1023, N'ernesto')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1024, N'probar')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1025, N'flor pelaez')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1026, N' raiz')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1027, N' ordenada')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1028, N'Etlis')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1029, N' Guardian')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1030, N' Resumen')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1031, N'endocrino')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1032, N'alisa')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1033, N' berman')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1034, N'guerra')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1035, N' jorgito')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1036, N' alfajor')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1037, N' wozniak')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1038, N'colision')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1039, N' fisica')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1040, N'alia')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1041, N' enbe')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1042, N'Dani Kohen')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1043, N'repaso')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1044, N'vertice')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1045, N' canonica')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1046, N' polinomica')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1047, N'helpers')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1048, N'multiplicar')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1049, N' dividir')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (1050, N' Leo')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (2025, N'chau')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (2026, N' gol')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (2027, N'penal')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (2028, N'para')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (2029, N'boca')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (2030, N'china')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (2031, N'Leo')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (2032, N'tagnuevo')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (2033, N'holatodobien')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (2034, N'pedrito')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (2035, N'holacomo')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (2036, N'aa')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (2037, N'juli')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (2038, N'ventura')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (2039, N'pablodiego')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (2040, N'aspnet')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (2041, N'c#')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (2042, N'c++')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (2043, N'asp')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (2044, N'funcion')
INSERT [dbo].[Tags] ([IdTag], [Tag]) VALUES (2045, N'polinomios')
SET IDENTITY_INSERT [dbo].[Tags] OFF
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1, 2)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1, 1)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1, 3)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2, 2)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (3, 4)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (3, 8)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (3, 7)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (4, 5)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (4, 17)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (8, 1)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1003, 2)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1004, -1)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1003, -1)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1003, 23)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1008, 24)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1005, 25)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1008, 26)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1009, 26)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1010, 26)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1005, 27)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1003, 27)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1011, 27)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1004, 32)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1013, 38)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1014, 38)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1015, 38)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1016, 38)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1017, 39)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1017, 40)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1018, 41)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1019, 41)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1020, 42)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1021, 43)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1008, 43)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1009, 43)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1022, 43)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1023, 43)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1005, 44)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1024, 44)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1007, 45)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1012, 46)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1025, 1046)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1026, 1046)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1027, 1046)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1007, 1047)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1028, 1048)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1029, 1048)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1030, 1048)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1031, 1049)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1032, 1050)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1033, 1050)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1034, 1051)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1035, 1051)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1036, 1051)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1037, 1051)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1017, 1052)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1038, 1053)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1039, 1053)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1017, 1054)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1017, 1055)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1040, 1056)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1041, 1056)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1042, 1057)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1043, 1058)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1044, 1059)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1045, 1059)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1046, 1059)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1047, 1060)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1048, 1061)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1049, 1061)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1050, 1061)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1007, 1062)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1024, 2046)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1008, 2047)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1009, 2047)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1004, 2048)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2025, 2048)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1004, 2049)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2026, 2049)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2027, 2050)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2028, 2050)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2029, 2050)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1003, 1046)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2030, 1046)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1020, 2051)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2031, 2051)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1020, 2052)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2031, 2052)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2032, 2053)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2033, 2054)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2034, 2055)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2025, 2055)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2030, -1)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2035, -1)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1007, -1)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2036, -1)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1012, -1)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1005, -1)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (4, 1)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1007, -1)
GO
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1012, 15)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1012, 16)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1003, 18)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1012, 18)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1003, 31)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1012, 31)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1007, 36)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (1007, 37)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2037, 3058)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2038, 3058)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2037, 3059)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2038, 3059)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2041, -1)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2042, -1)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2043, -1)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2044, -1)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2045, -1)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2039, 3060)
INSERT [dbo].[TagsXResumen] ([FkTag], [FkResumen]) VALUES (2040, 3060)
SET IDENTITY_INSERT [dbo].[TiposDeDenuncia] ON 

INSERT [dbo].[TiposDeDenuncia] ([IdTipoDenuncia], [TipoDenuncia]) VALUES (1, N'Falso contenido')
INSERT [dbo].[TiposDeDenuncia] ([IdTipoDenuncia], [TipoDenuncia]) VALUES (2, N'No es apropiado')
INSERT [dbo].[TiposDeDenuncia] ([IdTipoDenuncia], [TipoDenuncia]) VALUES (3, N'Es spam')
INSERT [dbo].[TiposDeDenuncia] ([IdTipoDenuncia], [TipoDenuncia]) VALUES (4, N'No me gusta')
INSERT [dbo].[TiposDeDenuncia] ([IdTipoDenuncia], [TipoDenuncia]) VALUES (5, N'Simbolos que incitan al odio')
INSERT [dbo].[TiposDeDenuncia] ([IdTipoDenuncia], [TipoDenuncia]) VALUES (6, N'Contiene desnudos o actividad sexual')
SET IDENTITY_INSERT [dbo].[TiposDeDenuncia] OFF
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs], [FkEscuela], [Creditos], [FotoPerfil]) VALUES (1, N'Mono', N'Juan123', N'tumama@gmail.com', 0, N'Mono', N'Relojero', 2, 2, 100, NULL)
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs], [FkEscuela], [Creditos], [FotoPerfil]) VALUES (2, N'AlberBendayan', N'Alber123', N'alberbendayan@gmail.com', 1, N'Alberto', N'Bendayan', 8, 2, 100, NULL)
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs], [FkEscuela], [Creditos], [FotoPerfil]) VALUES (3, N'AgusKryss', N'Agus123', N'aguskryss@gmail.com', 1, N'Agustin', N'Kryss', 5, 1, 100, NULL)
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs], [FkEscuela], [Creditos], [FotoPerfil]) VALUES (4, N'agus', N'agushola', N'agushola@gmail.com', 0, N'Agus', N'Hola', 2, 2, 100, NULL)
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs], [FkEscuela], [Creditos], [FotoPerfil]) VALUES (5, N'Admin', N'Admin123', N'admin@gmail.com', 1, N'Administrador', N'Administrador', 2, 1, 100, N'MaradonaEnfermera.jpg')
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs], [FkEscuela], [Creditos], [FotoPerfil]) VALUES (6, N'User', N'User123', N'user@gmail.com', 0, N'User', N'User', 6, 1, 100, NULL)
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs], [FkEscuela], [Creditos], [FotoPerfil]) VALUES (7, N'alberbenda', N'111111111', N'alber@gmail.com', 0, N'Alber', N'Benda', 7, 1, 100, NULL)
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs], [FkEscuela], [Creditos], [FotoPerfil]) VALUES (8, N'alberbenda', N'111111111', N'alber@gmail.com', 0, N'alner', N'bendaaa', 10, 1, 100, NULL)
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs], [FkEscuela], [Creditos], [FotoPerfil]) VALUES (9, N'alberbenda', N'aaaaaa', N'alber@gmail.com', 0, N'hola', N'holaaa', 6, 1, 100, NULL)
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs], [FkEscuela], [Creditos], [FotoPerfil]) VALUES (10, N'Mono', N'1', N'tumama@gmail.com', 1, N'Mono', N'Relojero', 1, 2, 1, N'tumamaentanga.png')
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs], [FkEscuela], [Creditos], [FotoPerfil]) VALUES (11, N'aaaaaa', N'aaaaaa', N'aa', 1, N'aaaaaa', N'aaaaaa', 0, 1, 1, NULL)
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs], [FkEscuela], [Creditos], [FotoPerfil]) VALUES (12, N'alberbenda', N'alber1234', N'dsxcz', 0, N'Juan', N'Perez rodriguez', 0, 4, 0, N'ASMG9919.JPG')
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs], [FkEscuela], [Creditos], [FotoPerfil]) VALUES (13, N'juanjuan', N'juanjuan', N'juanjuan@gmail.com', 0, N'Juan', N'juan', 0, 2, 0, N'')
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs], [FkEscuela], [Creditos], [FotoPerfil]) VALUES (14, N'LKristal123', N'Leo12345', N'Lkristal@gmail.com', 0, N'Leonardo', N'Kristal', 0, 1, 0, N'Diego.jpg')
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs], [FkEscuela], [Creditos], [FotoPerfil]) VALUES (15, N'alanb10', N'Alan123', N'alanrockb@gmail.com', 0, N'Alan', N'Bursztyn', 0, 2, 0, N'SNDI1683.JPG')
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs], [FkEscuela], [Creditos], [FotoPerfil]) VALUES (16, N'melib123', N'Meli1234', N'meliboro12345@gmail.com', 0, N'Meli', N'Boro', 0, 1, 0, N'frkeld.jpg')
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs], [FkEscuela], [Creditos], [FotoPerfil]) VALUES (17, N'tuhermana', N'Pene.123', N'Hermanito@gmail.com', 0, N'Hermana', N'Hermano', 0, 1, 0, N'Arbol de Soluciones.jpg')
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs], [FkEscuela], [Creditos], [FotoPerfil]) VALUES (18, N'jrodri123', N'Juan.123', N'juanrodri@gmail.com', 0, N'Juancito', N'Perez', 0, 1, 0, N'Jimmy.png')
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs], [FkEscuela], [Creditos], [FotoPerfil]) VALUES (19, N'LKristal123', N'Leo123', N'Lkristal@gmail.com', 0, N'Leo', N'Kristal', 0, 2, 0, N'buitre.jpeg')
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs], [FkEscuela], [Creditos], [FotoPerfil]) VALUES (20, N'jordebfjkcd', N'aaaaaa111', N'vedcsx', 0, N'Producto Berretin', N'fercsd', 0, 1, 0, N'')
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs], [FkEscuela], [Creditos], [FotoPerfil]) VALUES (21, N'ykussi123', N'Yaz123', N'yazkussi@gmail.com', 0, N'Yazmin', N'Kussi', 0, 1, 0, N'Don Julio.jpg')
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs], [FkEscuela], [Creditos], [FotoPerfil]) VALUES (22, N'Matikryss123', N'12345678', N'matikryss@gmail.com', 0, N'Matias', N'Kryss', 0, 3, 0, N'')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
INSERT [dbo].[VotosXUsuario] ([FkResumen], [FkUsuario]) VALUES (1061, 5)
INSERT [dbo].[VotosXUsuario] ([FkResumen], [FkUsuario]) VALUES (1, 2)
INSERT [dbo].[VotosXUsuario] ([FkResumen], [FkUsuario]) VALUES (2, 1)
INSERT [dbo].[VotosXUsuario] ([FkResumen], [FkUsuario]) VALUES (1062, 5)
INSERT [dbo].[VotosXUsuario] ([FkResumen], [FkUsuario]) VALUES (1059, 15)
INSERT [dbo].[VotosXUsuario] ([FkResumen], [FkUsuario]) VALUES (2052, 5)
INSERT [dbo].[VotosXUsuario] ([FkResumen], [FkUsuario]) VALUES (1053, 5)
INSERT [dbo].[VotosXUsuario] ([FkResumen], [FkUsuario]) VALUES (1058, 21)
INSERT [dbo].[VotosXUsuario] ([FkResumen], [FkUsuario]) VALUES (1052, 5)
INSERT [dbo].[VotosXUsuario] ([FkResumen], [FkUsuario]) VALUES (1057, 3)
USE [master]
GO
ALTER DATABASE [Resumamos] SET  READ_WRITE 
GO
