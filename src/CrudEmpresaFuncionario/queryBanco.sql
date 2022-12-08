USE [master]
GO
/** Object:  Database [crudMVC]    Script Date: 29/10/2021 08:24:09 **/
CREATE DATABASE [crudMVC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'crudMVC', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\crudMVC.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'crudMVC_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\crudMVC_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [crudMVC] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [crudMVC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [crudMVC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [crudMVC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [crudMVC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [crudMVC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [crudMVC] SET ARITHABORT OFF 
GO
ALTER DATABASE [crudMVC] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [crudMVC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [crudMVC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [crudMVC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [crudMVC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [crudMVC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [crudMVC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [crudMVC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [crudMVC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [crudMVC] SET  DISABLE_BROKER 
GO
ALTER DATABASE [crudMVC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [crudMVC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [crudMVC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [crudMVC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [crudMVC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [crudMVC] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [crudMVC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [crudMVC] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [crudMVC] SET  MULTI_USER 
GO
ALTER DATABASE [crudMVC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [crudMVC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [crudMVC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [crudMVC] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [crudMVC] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [crudMVC] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [crudMVC] SET QUERY_STORE = OFF
GO
USE [crudMVC]
GO
/** Object:  Table [dbo].[Empresa]    Script Date: 29/10/2021 08:24:09 **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](200) NOT NULL,
	[Telefone] [nvarchar](50) NOT NULL,
	[Endereco] [nvarchar](100) NOT NULL,
	[Bairro] [nvarchar](50) NOT NULL,
	[Cidade] [nvarchar](50) NOT NULL,
	[Numero] [nvarchar](50) NOT NULL,
	[Complemento] [nvarchar](50) NULL,
	[CEP] [nvarchar](50) NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/** Object:  Table [dbo].[Funcionario]    Script Date: 29/10/2021 08:24:09 **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcionario](
	[Nome] [nvarchar](200) NOT NULL,
	[Cargo] [nvarchar](50) NULL,
	[Salario] [decimal](18, 2) NOT NULL,
	[Id_Empresa] [int] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Funcionario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Funcionario]  WITH CHECK ADD  CONSTRAINT [FK_Funcionario_Empresa] FOREIGN KEY([Id_Empresa])
REFERENCES [dbo].[Empresa] ([Id])
GO
ALTER TABLE [dbo].[Funcionario] CHECK CONSTRAINT [FK_Funcionario_Empresa]
GO
USE [master]
GO
ALTER DATABASE [crudMVC] SET  READ_WRITE 
GO