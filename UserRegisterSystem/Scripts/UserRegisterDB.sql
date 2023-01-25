USE [master]
GO
/****** Object:  Database [UserRegister]    Script Date: 24/1/2023 20:28:06 ******/
CREATE DATABASE [UserRegister]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UserRegister', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\UserRegister.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UserRegister_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\UserRegister_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UserRegister] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UserRegister].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UserRegister] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UserRegister] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UserRegister] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UserRegister] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UserRegister] SET ARITHABORT OFF 
GO
ALTER DATABASE [UserRegister] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UserRegister] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UserRegister] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UserRegister] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UserRegister] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UserRegister] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UserRegister] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UserRegister] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UserRegister] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UserRegister] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UserRegister] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UserRegister] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UserRegister] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UserRegister] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UserRegister] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UserRegister] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UserRegister] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UserRegister] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UserRegister] SET  MULTI_USER 
GO
ALTER DATABASE [UserRegister] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UserRegister] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UserRegister] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UserRegister] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [UserRegister] SET DELAYED_DURABILITY = DISABLED 
GO
USE [UserRegister]
GO
/****** Object:  Table [dbo].[RoleTable]    Script Date: 24/1/2023 20:28:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nchar](10) NOT NULL,
 CONSTRAINT [PK_RoleTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserTable]    Script Date: 24/1/2023 20:28:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nchar](20) NOT NULL,
	[UserName] [nchar](20) NOT NULL,
	[Password] [nchar](10) NOT NULL,
	[ImagenPerfil] [nchar](300) NOT NULL,
	[IdRole] [int] NOT NULL,
 CONSTRAINT [PK_UserTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 24/1/2023 20:28:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InsertUser]
@Email nvarchar(20),
@UserName nvarchar(20),
@Password nvarchar(10),
@ImagenPerfil nvarchar(300),
@IdRole int 
as
insert into UserTable values (@Email, @UserName, @Password, @ImagenPerfil, @IdRole)
GO
/****** Object:  StoredProcedure [dbo].[ListUser]    Script Date: 24/1/2023 20:28:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ListUser] as
SELECT U.Id as UserId, Email, UserName, Password, ImagenPerfil, R.Id as RoleId, R.RoleName as RoleName from UserTable U, RoleTable R where U.IdRole = R.Id

GO
/****** Object:  StoredProcedure [dbo].[RecoveryUserPass]    Script Date: 24/1/2023 20:28:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RecoveryUserPass]
(
	@Password nvarchar(10),
	@Email nvarchar(20)
) as update UserTable set Password = @Password where Email = @Email
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 24/1/2023 20:28:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UpdateUser](@Email nvarchar(20), @UserName nvarchar(20), @Password nvarchar(10), @ImagenPerfil nvarchar(300), @IdRole int) as 
update UserTable set Email = @Email, UserName = @UserName, Password = @Password, ImagenPerfil = @ImagenPerfil, IdRole = @IdRole


GO
USE [master]
GO
ALTER DATABASE [UserRegister] SET  READ_WRITE 
GO
