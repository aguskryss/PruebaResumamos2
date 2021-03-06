USE [master]
GO
/****** Object:  Database [ProductosCD]    Script Date: 18/5/2020 21:24:48 ******/
CREATE DATABASE [ProductosCD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProductosCD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ProductosCD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProductosCD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ProductosCD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProductosCD] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProductosCD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProductosCD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProductosCD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProductosCD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProductosCD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProductosCD] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProductosCD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProductosCD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProductosCD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProductosCD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProductosCD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProductosCD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProductosCD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProductosCD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProductosCD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProductosCD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProductosCD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProductosCD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProductosCD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProductosCD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProductosCD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProductosCD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProductosCD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProductosCD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProductosCD] SET  MULTI_USER 
GO
ALTER DATABASE [ProductosCD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProductosCD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProductosCD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProductosCD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProductosCD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProductosCD] SET QUERY_STORE = OFF
GO
USE [ProductosCD]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 18/5/2020 21:24:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Producto] [varchar](max) NOT NULL,
	[Precio] [int] NOT NULL,
	[FkTipoProducto] [int] NOT NULL,
	[NomImagen] [varchar](max) NULL,
	[Destacado] [bit] NOT NULL,
	[Tipo] [varchar](50) NULL,
	[LinkMP] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposProducto]    Script Date: 18/5/2020 21:24:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposProducto](
	[IdTipoProducto] [int] IDENTITY(1,1) NOT NULL,
	[TipoProducto] [varchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (121, N'Armario madera laqueada c/estante de  48 (ancho) X 54 (alto) X 20 (prof.)
', 2400, 1, N'1.jpg', 0, N'A1', N'https://www.mercadopago.com.ar/checkout/v1/redirect?pref_id=213630883-e3cfc18d-eb36-4ae9-8af3-89eaa8e0bf1d')
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (122, N'Armario madera laqueada c/estante de 58 (ancho) X 54 (alto) X 27 (prof.)
', 2800, 1, N'2.jpg', 0, N'A2', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (123, N'Armario madera laqueada c/estante de 70 (alto) X 50 (ancho) X 27 (prof.)
', 3500, 1, N'3.jpg', 0, N'A3', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (124, N'Armario madera laqueada c/estante de 54 (alto) X 70 (ancho) X 27 (prof.)
', 3500, 1, N'4.jpg', 0, N'A4', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (125, N'Botiquin madera laqueada 3 cuerpos c/espejo de 60 (alto) X 60 (ancho)
', 3999, 2, N'5.jpg', 0, N'B1', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (126, N'Botiquin madera laqueada c/puerta modulo y luz de 50 (ancho) x 70 (alto)
', 2650, 2, N'6.jpg', 0, N'B2', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (127, N'Botiquin madera laqueada c/puerta modulo y luz de 60 (ancho) X 70 (alto)
', 3000, 2, N'7.jpg', 0, N'B3', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (128, N'Botiquin madera laqueada c/puerta espejo modulo y luz de 50 (ancho) X 70 (alto)
', 3000, 2, N'8.jpg', 1, N'B4', N'https://www.mercadopago.com.ar/checkout/v1/redirect?pref_id=213630883-a6a52f59-538f-49dc-bcfe-17f3c20ca823')
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (129, N'Botiquin madera laqueada c/puerta espejo modulo y luz de 60 (ancho) X 70 (alto)
', 3300, 2, N'9.jpg', 0, N'B5', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (130, N'Botiquin madera laqueada c/2 modulos puerta espejo y luz de 80 (ancho) X 70 (alto)
', 4400, 2, N'10.jpg', 0, N'B6', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (131, N'Botiquin madera laqueada 3 cuerpos c/estante de 72 (ancho) X 62 (alto)
', 4500, 2, N'11.jpg', 0, N'B7', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (132, N'Botiquin madera laqueada 3 cuerpos c/estante y tapas de 72 (ancho) X 62 (alto)
', 4900, 2, N'12.jpg', 0, N'B8', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (133, N'Tolva madera laqueada c/puertas de 30 (ancho) X 1,60 (alto) X 32 (prof.)
', 4600, 3, N'13.jpg', 0, N'T1', N'https://www.mercadopago.com.ar/checkout/v1/redirect?pref_id=213630883-70c29b85-3a13-4615-b75d-6d1afb264a53')
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (134, N'Tolva madera laqueada c/puertas de 30 (ancho) X 1,80 (alto) X 34 (prof.)
', 6300, 3, N'14.jpg', 1, N'T2', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (135, N'Tolva madera laqueada c/puertas de 40 (ancho) X 1,80 (alto) X 37 (prof.)
', 7100, 3, N'15.jpg', 0, N'T3', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (136, N'Armario de melamina c/estante de 40 (ancho) X 1,60 (alto) X 32 (prof.)
', 2800, 1, N'16.jpg', 0, N'A5', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (137, N'Armario de melamina 2 puertas c/estante de 60 (ancho) X 1,50 (alto) X 32 (prof.)
', 3500, 1, N'17.jpg', 0, N'A6', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (138, N'Armario de melamina 2 puertas c/estante y escobero de 60 (ancho) X 1,50 (alto) X 32 (prof.)
', 3800, 1, N'18.jpg', 0, N'A7', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (139, N'Botiquin madera laqueada 1 cuerpo de 40 (ancho) X 60 (alto)
', 2000, 2, N'19.jpg', 0, N'B9', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (140, N'Armario de 4 cajones de madera laqueada de 21 (ancho) X 80 (alto) X 33 (prof.)
', 2550, 1, N'20.jpg', 1, N'A8', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (141, N'Armario de 4 cajones de madera laqueada de 26 (ancho) X 80 (alto) X 33 (prof.)
', 2800, 1, N'21.jpg', 0, N'A9', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (142, N'Armario de 4 cajones de madera laqueada de 80 (alto) X 32 (ancho) X 33 (prof.) 
', 3000, 1, N'22.jpg', 0, N'A10', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (143, N'Armario de madera laqueada con puerta y cajon de 26 (ancho) X 80 (alto) X 37 (prof.)
', 3100, 1, N'23.jpg', 0, N'A11', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (144, N'Armario de madera laqueada con puerta y cajon de 31 (ancho) X 80 (alto) X 37 (prof.)
', 3250, 1, N'24.jpg', 0, N'A12', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (145, N'Mesa auxiliar con ruedas y estantes de 57 (ancho) X 83 (alto) X 37 (prof.)
', 3600, 4, N'25.jpg', 1, N'M1', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (146, N'Mesa de metal plegable circular de 57 cm (diametro)
', 3300, 4, N'26.jpg', 0, N'M2', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (147, N'Mesa rebatible con alas de 1,10 X 60 (base de formica)
', 3300, 4, N'27.jpg', 0, N'M3', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (148, N'Mesa plegable con base de formica de 60 X 80
', 3300, 4, N'28.jpg', 0, N'M4', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (149, N'Tender de pie de caño de 80cm c/ 8 varillas
', 550, 5, N'29.jpg', 0, N'T4', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (150, N'Tender de pie de caño c/ 11 varillas de 1 metro
', 700, 5, N'30.jpg', 0, N'T5', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (151, N'Tendedero de pie con alas reforzado de caño de 1,40 m X 50 cm
', 1250, 5, N'31.jpg', 1, N'T6', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (152, N'Tendedero de pie con alas de caño y sogas 1,40 m X 50 cm
', 1300, 5, N'32.jpg', 0, N'T7', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (153, N'Asiento universal de inodoro en plastico 
', 450, 6, N'33.jpg', 0, N'G1', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (154, N'Asiento universal de inodoro en plastico reforzado
', 600, 6, N'34.jpg', 0, N'G2', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (155, N'Asiento de inodoro en madera laqueada con herrajes de bronce cromados
', 1400, 6, N'35.jpg', 1, N'G3', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (156, N'Espejo c/marco de madera laqueada de 60cm x 80cm
', 2050, 7, N'36.jpg', 0, N'E1', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (157, N'Espejo triptico c/repisa de madera laqueada
', 2200, 7, N'37.jpg', 0, N'E2', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (158, N'Espejo con base de madera y marco en venecitas 45cm X 55cm
', 1100, 7, N'38.jpg', 1, N'E3', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (159, N'Protector de cortina en PVC blanco c/ojalillos en PVC de 1,80m X 1,80m
', 240, 8, N'45.jpg', 0, N'P1', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (160, N'Cortina de baño en PVC c/visor de 1,80m x 1,80m (color blanco)
', 430, 9, N'40.jpg', 0, N'C1', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (161, N'Cortina de baño en polyester color blanco c/prceso de teflon de 1,80m X 1,80m
', 600, 9, N'41.jpg', 0, N'C2', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (162, N'Cortina de baño en polyester estampado c/proceso de teflon de 1,80m X 1,80m
', 600, 9, N'42.jpg', 0, N'C3', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (163, N'Cortina de baño en polyester estampado c/proceso de teflon de 1,80m X 1,80m
', 600, 9, N'43.jpg', 0, N'C4', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (164, N'Cortina de baño en polyester c/bolados y calados c/proceso de teflon de 1,80m X 1,80m
', 990, 9, N'44.jpg', 0, N'C5', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (165, N'Cortina de baño en polyester de microfibra c/puntillas de 1,80m X 1,80m
', 990, 9, N'45.jpg', 0, N'C6', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (166, N'Cortina de baño c/proceso de teflon de 1,80m X 1,80m
', 600, 9, N'46.jpg', 0, N'C7', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (167, N'Cortina de teflon mapamundi 1,80m x 1,80m
', 750, 9, N'47.jpg', 1, N'C8', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (168, N'Espejo con marco de 56cm X 76cm
', 990, 7, N'48.jpg', 0, N'E4', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (169, N'Cesto acero inoxidable a pedal de 3 Litros
', 550, 10, N'49.jpg', 0, N'X1', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (170, N'Cesto acero inoxidable a pedal de 10 Litros
', 1000, 10, N'50.jpg', 0, N'X2', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (171, N'Cesto acero inoxidable a pedal de 12 Litros
', 1100, 10, N'51.jpg', 0, N'X3', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (172, N'Alfombra de seguridad c/ventosas de 33cm x 97cm (color cristal)
', 490, 11, N'45.jpg', 0, N'L1', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (173, N'Alfombra de seguridad c/ventosas "piedras grandes"
', 280, 11, N'45.jpg', 0, N'L2', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (174, N'Alfombra de seguridad c/ventosas oval cristal
', 240, 11, N'54.jpg', 0, N'L3', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (175, N'Alfombra para baño antideslizante
', 290, 11, N'55.jpg', 0, N'L4', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (176, N'Cepillo limpia inodoro c/base de acero inoxidable
', 380, 12, N'56.jpg', 0, N'F1', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (177, N'Cepillo limpia inodoro c/base plastica y mango de metal 
', 220, 12, N'57.jpg', 0, N'F2', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (178, N'Tabla de planchar c/manguero y varias posiciones 
', 1700, 13, N'58.jpg', 0, N'T8', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (179, N'Barral extensible para ducha de 1mts a 2mts blanco
', 300, 14, N'59.jpg', 0, N'V1', NULL)
INSERT [dbo].[Productos] ([IdProducto], [Producto], [Precio], [FkTipoProducto], [NomImagen], [Destacado], [Tipo], [LinkMP]) VALUES (180, N'Barral curvo c/soportes blanco de 1mts X 1mts
', 600, 14, N'60.jpg', 0, N'V2', NULL)
SET IDENTITY_INSERT [dbo].[Productos] OFF
SET IDENTITY_INSERT [dbo].[TiposProducto] ON 

INSERT [dbo].[TiposProducto] ([IdTipoProducto], [TipoProducto]) VALUES (1, N'Armarios')
INSERT [dbo].[TiposProducto] ([IdTipoProducto], [TipoProducto]) VALUES (2, N'Botiquines')
INSERT [dbo].[TiposProducto] ([IdTipoProducto], [TipoProducto]) VALUES (3, N'Tolvas')
INSERT [dbo].[TiposProducto] ([IdTipoProducto], [TipoProducto]) VALUES (4, N'Mesas')
INSERT [dbo].[TiposProducto] ([IdTipoProducto], [TipoProducto]) VALUES (5, N'Tenders')
INSERT [dbo].[TiposProducto] ([IdTipoProducto], [TipoProducto]) VALUES (6, N'Asiento para Inhodoros')
INSERT [dbo].[TiposProducto] ([IdTipoProducto], [TipoProducto]) VALUES (7, N'Espejos')
INSERT [dbo].[TiposProducto] ([IdTipoProducto], [TipoProducto]) VALUES (8, N'Protector de cortinas')
INSERT [dbo].[TiposProducto] ([IdTipoProducto], [TipoProducto]) VALUES (9, N'Cortinas de Baño')
INSERT [dbo].[TiposProducto] ([IdTipoProducto], [TipoProducto]) VALUES (10, N'Cestos')
INSERT [dbo].[TiposProducto] ([IdTipoProducto], [TipoProducto]) VALUES (11, N'Alfombras de baño')
INSERT [dbo].[TiposProducto] ([IdTipoProducto], [TipoProducto]) VALUES (12, N'Cepillos')
INSERT [dbo].[TiposProducto] ([IdTipoProducto], [TipoProducto]) VALUES (13, N'Tablas de planchar')
INSERT [dbo].[TiposProducto] ([IdTipoProducto], [TipoProducto]) VALUES (14, N'Barrales')
SET IDENTITY_INSERT [dbo].[TiposProducto] OFF
USE [master]
GO
ALTER DATABASE [ProductosCD] SET  READ_WRITE 
GO
