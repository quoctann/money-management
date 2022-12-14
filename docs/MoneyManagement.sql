USE [master]
GO
/****** Object:  Database [MoneyManagement]    Script Date: 14-Sep-22 23:59:37 ******/
CREATE DATABASE [MoneyManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MoneyManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MoneyManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MoneyManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MoneyManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MoneyManagement] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MoneyManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MoneyManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MoneyManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MoneyManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MoneyManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MoneyManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [MoneyManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MoneyManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MoneyManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MoneyManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MoneyManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MoneyManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MoneyManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MoneyManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MoneyManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MoneyManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MoneyManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MoneyManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MoneyManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MoneyManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MoneyManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MoneyManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MoneyManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MoneyManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [MoneyManagement] SET  MULTI_USER 
GO
ALTER DATABASE [MoneyManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MoneyManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MoneyManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MoneyManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MoneyManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MoneyManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MoneyManagement', N'ON'
GO
ALTER DATABASE [MoneyManagement] SET QUERY_STORE = OFF
GO
USE [MoneyManagement]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 14-Sep-22 23:59:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](255) NULL,
	[Icon] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
	[InitialBalance] [int] NOT NULL,
	[CurrentBalance] [int] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 14-Sep-22 23:59:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Label] [nvarchar](255) NULL,
	[Icon] [nvarchar](255) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Records]    Script Date: 14-Sep-22 23:59:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Records](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](100) NULL,
	[CategoryId] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Value] [int] NOT NULL,
	[DateOfIssue] [datetime] NULL,
 CONSTRAINT [PK_Records] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAccount]    Script Date: 14-Sep-22 23:59:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
 CONSTRAINT [PK_UserAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCategory]    Script Date: 14-Sep-22 23:59:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_UserCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRecord]    Script Date: 14-Sep-22 23:59:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRecord](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RecordId] [int] NOT NULL,
 CONSTRAINT [PK_UserRecord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 14-Sep-22 23:59:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Fullname] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[IsAdmin] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CurrencyUnit] [nvarchar](20) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_InitialBalance]  DEFAULT ((0)) FOR [InitialBalance]
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_CurrentBalance]  DEFAULT ((0)) FOR [CurrentBalance]
GO
ALTER TABLE [dbo].[Records] ADD  CONSTRAINT [DF_Records_Value]  DEFAULT ((0)) FOR [Value]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Fullname]  DEFAULT (N'User') FOR [Fullname]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsAdmin]  DEFAULT ((0)) FOR [IsAdmin]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CurrencyUnit]  DEFAULT (N'VND') FOR [CurrencyUnit]
GO
ALTER TABLE [dbo].[Records]  WITH CHECK ADD  CONSTRAINT [FK_Records_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[Records] CHECK CONSTRAINT [FK_Records_Accounts]
GO
ALTER TABLE [dbo].[Records]  WITH CHECK ADD  CONSTRAINT [FK_Records_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Records] CHECK CONSTRAINT [FK_Records_Categories]
GO
ALTER TABLE [dbo].[UserAccount]  WITH CHECK ADD  CONSTRAINT [FK_UserAccount_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[UserAccount] CHECK CONSTRAINT [FK_UserAccount_Accounts]
GO
ALTER TABLE [dbo].[UserAccount]  WITH CHECK ADD  CONSTRAINT [FK_UserAccount_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserAccount] CHECK CONSTRAINT [FK_UserAccount_Users]
GO
ALTER TABLE [dbo].[UserCategory]  WITH CHECK ADD  CONSTRAINT [FK_UserCategory_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[UserCategory] CHECK CONSTRAINT [FK_UserCategory_Categories]
GO
ALTER TABLE [dbo].[UserCategory]  WITH CHECK ADD  CONSTRAINT [FK_UserCategory_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserCategory] CHECK CONSTRAINT [FK_UserCategory_Users]
GO
ALTER TABLE [dbo].[UserRecord]  WITH CHECK ADD  CONSTRAINT [FK_UserRecord_Records] FOREIGN KEY([RecordId])
REFERENCES [dbo].[Records] ([Id])
GO
ALTER TABLE [dbo].[UserRecord] CHECK CONSTRAINT [FK_UserRecord_Records]
GO
ALTER TABLE [dbo].[UserRecord]  WITH CHECK ADD  CONSTRAINT [FK_UserRecord_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRecord] CHECK CONSTRAINT [FK_UserRecord_Users]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Junction table for Users and Categories n to n relationship' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserCategory', @level2type=N'CONSTRAINT',@level2name=N'FK_UserCategory_Categories'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Junction table for Users and Categories n to n relationship' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserCategory', @level2type=N'CONSTRAINT',@level2name=N'FK_UserCategory_Users'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Junction table for Users and Records n to n relationship' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRecord', @level2type=N'CONSTRAINT',@level2name=N'FK_UserRecord_Records'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Junction table for Users and Records n to n relationship' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRecord', @level2type=N'CONSTRAINT',@level2name=N'FK_UserRecord_Users'
GO
USE [master]
GO
ALTER DATABASE [MoneyManagement] SET  READ_WRITE 
GO
