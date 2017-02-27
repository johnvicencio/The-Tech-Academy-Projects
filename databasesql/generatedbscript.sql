USE [master]
GO
/****** Object:  Database [Library]    Script Date: 2/26/17 7:31:32 PM ******/
CREATE DATABASE [Library]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Library', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Library.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Library_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Library_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Library] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Library].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Library] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Library] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Library] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Library] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Library] SET ARITHABORT OFF 
GO
ALTER DATABASE [Library] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Library] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Library] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Library] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Library] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Library] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Library] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Library] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Library] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Library] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Library] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Library] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Library] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Library] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Library] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Library] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Library] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Library] SET RECOVERY FULL 
GO
ALTER DATABASE [Library] SET  MULTI_USER 
GO
ALTER DATABASE [Library] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Library] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Library] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Library] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Library] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Library', N'ON'
GO
ALTER DATABASE [Library] SET QUERY_STORE = OFF
GO
USE [Library]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Library]
GO
/****** Object:  User [john]    Script Date: 2/26/17 7:31:32 PM ******/
CREATE USER [john] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [john]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 2/26/17 7:31:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](200) NULL,
	[PublisherName] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Book_Authors]    Script Date: 2/26/17 7:31:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book_Authors](
	[BookId] [int] NOT NULL,
	[AuthorName] [varchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Book_Copies]    Script Date: 2/26/17 7:31:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book_Copies](
	[BookId] [int] NOT NULL,
	[BranchId] [int] NOT NULL,
	[No_Of_Copies] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Book_Loans]    Script Date: 2/26/17 7:31:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book_Loans](
	[BookId] [int] NOT NULL,
	[BranchId] [int] NOT NULL,
	[CardNo] [int] NOT NULL,
	[DateOut] [datetime] NULL,
	[DueDate] [date] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Borrower]    Script Date: 2/26/17 7:31:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Borrower](
	[CardNo] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
	[Address] [varchar](255) NULL,
	[Phone] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CardNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Library_Branch]    Script Date: 2/26/17 7:31:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Library_Branch](
	[BranchId] [int] IDENTITY(1,1) NOT NULL,
	[BranchName] [varchar](200) NULL,
	[Address] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[BranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Publisher]    Script Date: 2/26/17 7:31:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publisher](
	[Name] [varchar](200) NOT NULL,
	[Address] [varchar](255) NULL,
	[Phone] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Book_Authors]  WITH CHECK ADD  CONSTRAINT [fk_Book_Authors_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([BookId])
GO
ALTER TABLE [dbo].[Book_Authors] CHECK CONSTRAINT [fk_Book_Authors_BookId]
GO
ALTER TABLE [dbo].[Book_Copies]  WITH CHECK ADD  CONSTRAINT [fk_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([BookId])
GO
ALTER TABLE [dbo].[Book_Copies] CHECK CONSTRAINT [fk_BookId]
GO
ALTER TABLE [dbo].[Book_Copies]  WITH CHECK ADD  CONSTRAINT [fk_BranchId] FOREIGN KEY([BranchId])
REFERENCES [dbo].[Library_Branch] ([BranchId])
GO
ALTER TABLE [dbo].[Book_Copies] CHECK CONSTRAINT [fk_BranchId]
GO
/****** Object:  StoredProcedure [dbo].[spAddBook]    Script Date: 2/26/17 7:31:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAddBook] @BookTitle varchar(255), @Author varchar(50), @AuthorID int, @Publisher varchar(255), @Address varchar(50), @Phone varchar(50) 
AS
INSERT INTO Book VALUES(@BookTitle, @Publisher)
INSERT INTO Book_Authors VALUES(@AuthorID, @Author)
INSERT INTO Publisher VALUES(@Publisher, @Address, @Phone)

GO
USE [master]
GO
ALTER DATABASE [Library] SET  READ_WRITE 
GO
