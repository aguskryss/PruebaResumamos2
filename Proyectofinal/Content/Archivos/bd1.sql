USE [master]
GO
/****** Object:  Database [Resumamos]    Script Date: 4/19/2020 5:48:39 PM ******/
CREATE DATABASE [Resumamos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Resumamos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Resumamos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Resumamos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Resumamos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Resumamos] SET COMPATIBILITY_LEVEL = 140
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
/****** Object:  Table [dbo].[Escuelas]    Script Date: 4/19/2020 5:48:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Escuelas](
	[IdEscuela] [int] IDENTITY(1,1) NOT NULL,
	[NombreEscuela] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materias]    Script Date: 4/19/2020 5:48:39 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resumenes]    Script Date: 4/19/2020 5:48:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resumenes](
	[IdResumen] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[FkMateria] [int] NOT NULL,
	[FkUsuario] [int] NOT NULL,
	[Puntuacion] [float] NULL,
	[Anio] [int] NOT NULL,
	[Archivo] [varchar](50) NOT NULL,
	[FkEscuela] [nchar](10) NULL,
 CONSTRAINT [PK_Resumenes] PRIMARY KEY CLUSTERED 
(
	[IdResumen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 4/19/2020 5:48:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Contrasena] [varchar](50) NOT NULL,
	[Mail] [varchar](50) NOT NULL,
	[Admin] [bit] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[PuntuacionUs] [float] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Escuelas] ON 

INSERT [dbo].[Escuelas] ([IdEscuela], [NombreEscuela]) VALUES (1, N'ORT')
INSERT [dbo].[Escuelas] ([IdEscuela], [NombreEscuela]) VALUES (2, N'Martin Buber')
INSERT [dbo].[Escuelas] ([IdEscuela], [NombreEscuela]) VALUES (3, N'Sholem Aleijem')
SET IDENTITY_INSERT [dbo].[Escuelas] OFF
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
SET IDENTITY_INSERT [dbo].[Materias] OFF
SET IDENTITY_INSERT [dbo].[Resumenes] ON 

INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela]) VALUES (1, N'Resumen las cruzadas', 4, 2, 4, 4, N'p1.jpg', N'1         ')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela]) VALUES (2, N'Expresiones logaritmicas', 1, 3, 3, 5, N'p2.jpg', N'1         ')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela]) VALUES (3, N'Funcion polinomica', 1, 2, 4, 3, N'p3.jpg', N'2         ')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela]) VALUES (4, N'Finanzas públicas', 7, 3, 5, 2, N'p4.jpg', N'1         ')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela]) VALUES (5, N'Funciones', 1, 2, 4, 2, N'p5.jpg', N'3         ')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela]) VALUES (6, N'Gobiernos Peronistas', 3, 3, 2, 4, N'p6.jpg', N'1         ')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela]) VALUES (7, N'Análisis sintáctico', 2, 2, 6, 1, N'p7.jpg', N'3         ')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela]) VALUES (8, N'Eclesiastes', 6, 3, 5, 4, N'p9.jpg', N'1         ')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela]) VALUES (9, N'Cabecita negra resumen', 2, 2, 4, 3, N'p10.jpg', N'2         ')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela]) VALUES (10, N'Función racional', 6, 3, 6, 2, N'p11.jpg', N'3         ')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela]) VALUES (11, N'Colisiones', 5, 5, 3, 1, N'p12.jpg', N'1         ')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela]) VALUES (12, N'Sistema excretor', 10, 1, 0, 1, N'p13.jpg', N'1         ')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela]) VALUES (13, N'C#', 8, 1, 0, 4, N'p14.jpg', N'1         ')
INSERT [dbo].[Resumenes] ([IdResumen], [Nombre], [FkMateria], [FkUsuario], [Puntuacion], [Anio], [Archivo], [FkEscuela]) VALUES (14, N'Etica', 9, 4, 1, 1, N'p15.jpg', N'2         ')
SET IDENTITY_INSERT [dbo].[Resumenes] OFF
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs]) VALUES (1, N'Juancito', N'Juan123', N'juan@gmail.com', 0, N'Juan', N'Perez', 2)
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs]) VALUES (2, N'AlberBendayan', N'Alber123', N'alberBendayan@gmail.com', 1, N'Alberto', N'Bendayan', 8)
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs]) VALUES (3, N'AgusKryss', N'Agus123', N'agusKryss@gmail.com', 1, N'Agustin', N'Kryss', 5)
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs]) VALUES (4, N'agus', N'agushola', N'agushola@gmail.com', 0, N'Agus', N'Hola', 2)
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs]) VALUES (5, N'Admin', N'Admin123', N'admin@gmail.com', 1, N'Admin', N'Admin', 2)
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs]) VALUES (6, N'User', N'User123', N'user@gmail.com', 0, N'User', N'User', 6)
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs]) VALUES (7, N'alberbenda', N'111111111', N'alber@gmail.com', 0, N'Alber', N'Benda', 7)
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs]) VALUES (8, N'alberbenda', N'111111111', N'alber@gmail.com', 0, N'alner', N'bendaaa', 10)
INSERT [dbo].[Usuarios] ([IdUsuario], [Username], [Contrasena], [Mail], [Admin], [Nombre], [Apellido], [PuntuacionUs]) VALUES (9, N'alberbenda', N'aaaaaa', N'alber@gmail.com', 0, N'hola', N'holaaa', 6)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
USE [master]
GO
ALTER DATABASE [Resumamos] SET  READ_WRITE 
GO
