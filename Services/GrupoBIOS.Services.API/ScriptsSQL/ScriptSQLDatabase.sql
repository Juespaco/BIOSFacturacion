USE [master]
GO
/****** Object:  Database [FacturacionAlmacenamiento]    Script Date: 29/03/2025 1:15:20 a. m. ******/
CREATE DATABASE [FacturacionAlmacenamiento]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FacturacionAlmacenamiento', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\FacturacionAlmacenamiento.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FacturacionAlmacenamiento_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\FacturacionAlmacenamiento_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FacturacionAlmacenamiento].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET ARITHABORT OFF 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET  MULTI_USER 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET QUERY_STORE = ON
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [FacturacionAlmacenamiento]
GO
/****** Object:  Table [dbo].[CentroOperativo]    Script Date: 29/03/2025 1:15:21 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CentroOperativo](
	[IDCentroOperativo] [int] IDENTITY(1,1) NOT NULL,
	[IDCompania] [int] NULL,
	[IDSiesaCO] [int] NULL,
	[NombreCO] [nvarchar](250) NULL,
	[ReferenciadeCobro] [nvarchar](250) NULL,
	[PrefijodeFacturacion] [nvarchar](50) NULL,
	[MotivodeFacturacion] [nvarchar](500) NULL,
	[BodegaEspeciales] [nvarchar](250) NULL,
	[CorreoEnvioReporte] [nvarchar](250) NULL,
	[FechaInicialCorte] [datetime] NULL,
	[FechaPrimerCobro] [datetime] NULL,
	[FechaSegundoCobro] [datetime] NULL,
	[FechaCobroPNC] [datetime] NULL,
	[DefinicioPrimerCobro] [int] NULL,
	[DefinicioSegundoCobro] [int] NULL,
	[CobroPNC] [int] NULL,
	[Estado] [bit] NULL,
	[FechadeCreacion] [datetime] NOT NULL,
	[CreadoPor] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_CentroOperativo] PRIMARY KEY CLUSTERED 
(
	[IDCentroOperativo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clase]    Script Date: 29/03/2025 1:15:21 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clase](
	[IDClase] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](250) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Estado] [bit] NOT NULL,
	[FechadeCreacion] [datetime] NOT NULL,
	[CreadoPor] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Clase] PRIMARY KEY CLUSTERED 
(
	[IDClase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compania]    Script Date: 29/03/2025 1:15:21 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compania](
	[IDCompania] [int] IDENTITY(1,1) NOT NULL,
	[NombreCompania] [nvarchar](250) NOT NULL,
	[IDSiesa] [int] NOT NULL,
	[NombreBD] [nvarchar](250) NOT NULL,
	[NombreConexionBD] [nvarchar](500) NOT NULL,
	[UrlWebServiceSiesa] [nvarchar](max) NOT NULL,
	[UsuarioWebService] [nvarchar](250) NOT NULL,
	[ClaveWebService] [nvarchar](500) NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechadeCreacion] [datetime] NOT NULL,
	[CreadoPor] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Compania] PRIMARY KEY CLUSTERED 
(
	[IDCompania] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InfoPersonal]    Script Date: 29/03/2025 1:15:21 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InfoPersonal](
	[IDInfoPersonal] [int] IDENTITY(1,1) NOT NULL,
	[IDUsuario] [int] NOT NULL,
	[IDParametroTipoDocumento] [int] NOT NULL,
	[Documento] [nvarchar](50) NOT NULL,
	[Nombres] [nvarchar](250) NOT NULL,
	[Apellidos] [nvarchar](150) NOT NULL,
	[Direccion] [nvarchar](250) NOT NULL,
	[Telefono] [nvarchar](50) NOT NULL,
	[Correo] [nvarchar](250) NOT NULL,
	[IDParametroGenero] [int] NOT NULL,
	[FechadeCreacion] [datetime] NOT NULL,
	[CreadoPor] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_InfoPersonal] PRIMARY KEY CLUSTERED 
(
	[IDInfoPersonal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modulo]    Script Date: 29/03/2025 1:15:21 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modulo](
	[IDModulo] [int] IDENTITY(1,1) NOT NULL,
	[Modulo] [nvarchar](150) NULL,
	[Observacion] [nvarchar](max) NULL,
	[FechadeCreacion] [datetime] NULL,
	[CreadoPor] [nvarchar](150) NULL,
 CONSTRAINT [PK_Modulo] PRIMARY KEY CLUSTERED 
(
	[IDModulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parametro]    Script Date: 29/03/2025 1:15:21 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parametro](
	[IDParametro] [int] IDENTITY(1,1) NOT NULL,
	[IDClase] [int] NOT NULL,
	[Nombre] [nvarchar](250) NULL,
	[Descripcion] [nvarchar](250) NULL,
	[FechadeCreacion] [datetime] NOT NULL,
	[CreadoPor] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Parametro] PRIMARY KEY CLUSTERED 
(
	[IDParametro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 29/03/2025 1:15:21 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[IDRol] [int] IDENTITY(1,1) NOT NULL,
	[Rol] [nvarchar](150) NOT NULL,
	[Descripcion] [nvarchar](500) NULL,
	[Estado] [bit] NOT NULL,
	[FechadeCreacion] [datetime] NOT NULL,
	[CreadoPor] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[IDRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleporModulo]    Script Date: 29/03/2025 1:15:21 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleporModulo](
	[IDRolxModulo] [int] IDENTITY(1,1) NOT NULL,
	[IDRol] [int] NOT NULL,
	[IDModulo] [int] NOT NULL,
	[Descripcion] [nvarchar](250) NULL,
	[Estado] [bit] NOT NULL,
	[FechadeCreacion] [datetime] NULL,
	[CreadoPor] [nvarchar](150) NULL,
 CONSTRAINT [PK_RoleporModulo] PRIMARY KEY CLUSTERED 
(
	[IDRolxModulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 29/03/2025 1:15:21 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IDUsuario] [int] IDENTITY(1,1) NOT NULL,
	[IDRol] [int] NOT NULL,
	[IDCompania] [int] NOT NULL,
	[IDCentroOperativo] [int] NOT NULL,
	[FechaExpiracionRol] [date] NULL,
	[NombredeUsuario] [nvarchar](250) NOT NULL,
	[Contrasena] [nvarchar](max) NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechadeCreacion] [datetime] NOT NULL,
	[CreadoPor] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IDUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[InfoPersonal]  WITH CHECK ADD  CONSTRAINT [FK_InfoPersonal_Parametro] FOREIGN KEY([IDParametroTipoDocumento])
REFERENCES [dbo].[Parametro] ([IDParametro])
GO
ALTER TABLE [dbo].[InfoPersonal] CHECK CONSTRAINT [FK_InfoPersonal_Parametro]
GO
ALTER TABLE [dbo].[InfoPersonal]  WITH CHECK ADD  CONSTRAINT [FK_InfoPersonal_Parametro1] FOREIGN KEY([IDParametroGenero])
REFERENCES [dbo].[Parametro] ([IDParametro])
GO
ALTER TABLE [dbo].[InfoPersonal] CHECK CONSTRAINT [FK_InfoPersonal_Parametro1]
GO
ALTER TABLE [dbo].[InfoPersonal]  WITH CHECK ADD  CONSTRAINT [FK_InfoPersonal_Usuario] FOREIGN KEY([IDUsuario])
REFERENCES [dbo].[Usuario] ([IDUsuario])
GO
ALTER TABLE [dbo].[InfoPersonal] CHECK CONSTRAINT [FK_InfoPersonal_Usuario]
GO
ALTER TABLE [dbo].[Parametro]  WITH CHECK ADD  CONSTRAINT [FK_Parametro_Clase] FOREIGN KEY([IDClase])
REFERENCES [dbo].[Clase] ([IDClase])
GO
ALTER TABLE [dbo].[Parametro] CHECK CONSTRAINT [FK_Parametro_Clase]
GO
ALTER TABLE [dbo].[RoleporModulo]  WITH CHECK ADD  CONSTRAINT [FK_RoleporModulo_Modulo] FOREIGN KEY([IDModulo])
REFERENCES [dbo].[Modulo] ([IDModulo])
GO
ALTER TABLE [dbo].[RoleporModulo] CHECK CONSTRAINT [FK_RoleporModulo_Modulo]
GO
ALTER TABLE [dbo].[RoleporModulo]  WITH CHECK ADD  CONSTRAINT [FK_RoleporModulo_Role] FOREIGN KEY([IDRol])
REFERENCES [dbo].[Role] ([IDRol])
GO
ALTER TABLE [dbo].[RoleporModulo] CHECK CONSTRAINT [FK_RoleporModulo_Role]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_CentroOperativo] FOREIGN KEY([IDCentroOperativo])
REFERENCES [dbo].[CentroOperativo] ([IDCentroOperativo])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_CentroOperativo]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Compania] FOREIGN KEY([IDCompania])
REFERENCES [dbo].[Compania] ([IDCompania])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Compania]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Role] FOREIGN KEY([IDRol])
REFERENCES [dbo].[Role] ([IDRol])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Role]
GO
/****** Object:  StoredProcedure [dbo].[uspGetUsuarioAll]    Script Date: 29/03/2025 1:15:21 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetUsuarioAll]
AS
	SELECT IDUsuario
	,IDRol
	,IDCompania
	,IDCentroOperativo
	,FechaExpiracionRol
	,NombredeUsuario
	,Contrasena
	,Estado
	,FechadeCreacion
	,CreadoPor FROM Usuario
GO
USE [master]
GO
ALTER DATABASE [FacturacionAlmacenamiento] SET  READ_WRITE 
GO
