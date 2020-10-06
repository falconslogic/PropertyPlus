USE [master]
GO
/****** Object:  Database [PropertyManagement]    Script Date: 10/4/2020 6:00:26 PM ******/
CREATE DATABASE [PropertyManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PropertyManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\PropertyManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PropertyManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\PropertyManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PropertyManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PropertyManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PropertyManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PropertyManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PropertyManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PropertyManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PropertyManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [PropertyManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PropertyManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PropertyManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PropertyManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PropertyManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PropertyManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PropertyManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PropertyManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PropertyManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PropertyManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PropertyManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PropertyManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PropertyManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PropertyManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PropertyManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PropertyManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PropertyManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PropertyManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PropertyManagement] SET  MULTI_USER 
GO
ALTER DATABASE [PropertyManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PropertyManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PropertyManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PropertyManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PropertyManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PropertyManagement] SET QUERY_STORE = OFF
GO
USE [PropertyManagement]
GO
/****** Object:  Table [dbo].[Maintenance_Request]    Script Date: 10/4/2020 6:00:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maintenance_Request](
	[MaintenanceID] [int] IDENTITY(1,1) NOT NULL,
	[PropertyID] [int] NOT NULL,
	[Description] [nvarchar](50) NULL,
	[Documents] [nvarchar](50) NULL,
	[Priority] [bit] NULL,
 CONSTRAINT [PK_Maintenance_Request] PRIMARY KEY CLUSTERED 
(
	[MaintenanceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment_History]    Script Date: 10/4/2020 6:00:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_History](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[Total_payments] [int] NULL,
	[Total_paid] [int] NULL,
	[Total_late] [int] NULL,
	[Total_months] [int] NULL,
 CONSTRAINT [PK_Payment_History] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Property]    Script Date: 10/4/2020 6:00:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Property](
	[PropertyID] [int] IDENTITY(1,1) NOT NULL,
	[OwnerID] [int] NOT NULL,
	[LeaserID] [int] NOT NULL,
	[Picture] [image] NULL,
	[Address] [nvarchar](50) NULL,
	[Square_feet] [int] NULL,
	[Bedrooms] [int] NULL,
	[Baths] [float] NULL,
	[Year] [int] NULL,
	[Features] [nvarchar](max) NULL,
	[Monthly_rate] [int] NULL,
	[Utilities] [nvarchar](50) NULL,
	[Contract_time] [nvarchar](50) NULL,
	[PaymentID] [int] NOT NULL,
 CONSTRAINT [PK_Property] PRIMARY KEY CLUSTERED 
(
	[PropertyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Property_Leaser]    Script Date: 10/4/2020 6:00:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Property_Leaser](
	[LeaserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nchar](10) NULL,
	[Zip_code] [int] NULL,
	[Comments] [nvarchar](50) NULL,
	[Phone_number] [nvarchar](50) NULL,
 CONSTRAINT [PK_Property_Leaser] PRIMARY KEY CLUSTERED 
(
	[LeaserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Property_Owner]    Script Date: 10/4/2020 6:00:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Property_Owner](
	[OwnerID] [int] IDENTITY(1,1) NOT NULL,
	[First_name] [nvarchar](50) NULL,
	[Last_name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nchar](10) NULL,
	[Zip_code] [int] NULL,
	[Comments] [nvarchar](50) NULL,
 CONSTRAINT [PK_Property_Owner] PRIMARY KEY CLUSTERED 
(
	[OwnerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Maintenance_Request]  WITH CHECK ADD  CONSTRAINT [FK_Maintenance_Request_Property] FOREIGN KEY([PropertyID])
REFERENCES [dbo].[Property] ([PropertyID])
GO
ALTER TABLE [dbo].[Maintenance_Request] CHECK CONSTRAINT [FK_Maintenance_Request_Property]
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_Payment_History] FOREIGN KEY([PaymentID])
REFERENCES [dbo].[Payment_History] ([PaymentID])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_Payment_History]
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_Property_Leaser] FOREIGN KEY([LeaserID])
REFERENCES [dbo].[Property_Leaser] ([LeaserID])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_Property_Leaser]
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_Property_Owner] FOREIGN KEY([OwnerID])
REFERENCES [dbo].[Property_Owner] ([OwnerID])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_Property_Owner]
GO
USE [master]
GO
ALTER DATABASE [PropertyManagement] SET  READ_WRITE 
GO
