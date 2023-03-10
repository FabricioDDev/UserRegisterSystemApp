USE [UserRegisterDB]
GO
/****** Object:  Table [dbo].[RoleTable]    Script Date: 5/3/2023 10:20:59 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTable]    Script Date: 5/3/2023 10:21:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nchar](30) NULL,
	[UserName] [nchar](30) NULL,
	[Password] [nchar](30) NULL,
	[IdRole] [int] NOT NULL,
 CONSTRAINT [PK_UserTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[ExistUser]    Script Date: 5/3/2023 10:21:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[ExistUser] 
@Email nchar(20),
@UserName nchar(20)
as
select COUNT(*) as Exist from UserTable where Email = @Email or UserName = @UserName;
GO
/****** Object:  StoredProcedure [dbo].[ListUser]    Script Date: 5/3/2023 10:21:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ListUser] as
SELECT U.Id as UserId, Email, UserName, Password, R.Id as RoleId, R.RoleName as RoleName from UserTable U, RoleTable R where U.IdRole = R.Id
GO
/****** Object:  StoredProcedure [dbo].[LogIn]    Script Date: 5/3/2023 10:21:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[LogIn]
@UserName nchar(30),
@Pass nchar(30)
as
select U.Id as UserId, Email, UserName, Password, R.Id as RoleId, RoleName
from UserTable U, RoleTable R
where R.Id = U.IdRole and UserName = @UserName and Password = @Pass
GO
/****** Object:  StoredProcedure [dbo].[RecoveryUserPass]    Script Date: 5/3/2023 10:21:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RecoveryUserPass]
(
	@Password nvarchar(30),
	@Email nvarchar(30)
) as update UserTable set Password = @Password where Email = @Email
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 5/3/2023 10:21:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateUser](@Email nvarchar(30), @UserName nvarchar(30), @Password nvarchar(30), @IdRole int) as 
update UserTable set Email = @Email, UserName = @UserName, Password = @Password, IdRole = @IdRole


GO
