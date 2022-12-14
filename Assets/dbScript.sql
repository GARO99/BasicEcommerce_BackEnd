USE [master]
GO
/****** Object:  Database [basicEcommerce]    Script Date: 12/12/2022 4:56:17 a. m. ******/
CREATE DATABASE [basicEcommerce]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'basicEcommerce', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\basicEcommerce.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'basicEcommerce_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\basicEcommerce_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [basicEcommerce].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [basicEcommerce] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [basicEcommerce] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [basicEcommerce] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [basicEcommerce] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [basicEcommerce] SET ARITHABORT OFF 
GO
ALTER DATABASE [basicEcommerce] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [basicEcommerce] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [basicEcommerce] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [basicEcommerce] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [basicEcommerce] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [basicEcommerce] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [basicEcommerce] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [basicEcommerce] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [basicEcommerce] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [basicEcommerce] SET  DISABLE_BROKER 
GO
ALTER DATABASE [basicEcommerce] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [basicEcommerce] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [basicEcommerce] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [basicEcommerce] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [basicEcommerce] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [basicEcommerce] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [basicEcommerce] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [basicEcommerce] SET RECOVERY FULL 
GO
ALTER DATABASE [basicEcommerce] SET  MULTI_USER 
GO
ALTER DATABASE [basicEcommerce] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [basicEcommerce] SET DB_CHAINING OFF 
GO
ALTER DATABASE [basicEcommerce] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [basicEcommerce] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [basicEcommerce] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'basicEcommerce', N'ON'
GO
ALTER DATABASE [basicEcommerce] SET QUERY_STORE = OFF
GO
USE [basicEcommerce]
GO
/****** Object:  Table [dbo].[ApiUser]    Script Date: 12/12/2022 4:56:25 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApiUser](
	[IdApiUser] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdApiUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 12/12/2022 4:56:31 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Idclient] [bigint] IDENTITY(1,1) NOT NULL,
	[IdNumberPerson] [varchar](15) NULL,
	[PhoneNumbre] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[Idclient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 12/12/2022 4:56:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[IdOrder] [bigint] IDENTITY(1,1) NOT NULL,
	[Idclient] [bigint] NULL,
	[Date] [datetime] NULL,
	[TotalAmount] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 12/12/2022 4:56:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[IdOrderDetail] [bigint] IDENTITY(1,1) NOT NULL,
	[IdOrder] [bigint] NULL,
	[IdProduct] [bigint] NULL,
	[Quantity] [int] NULL,
	[Amount] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdOrderDetail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 12/12/2022 4:56:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[IdNumber] [varchar](15) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 12/12/2022 4:56:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[IdProduct] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](50) NULL,
	[Price] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/12/2022 4:56:35 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[IdUser] [bigint] IDENTITY(1,1) NOT NULL,
	[IdNumberPerson] [varchar](15) NULL,
	[email] [varchar](50) NULL,
	[password] [varchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ApiUser] ON 

INSERT [dbo].[ApiUser] ([IdApiUser], [UserName], [Password]) VALUES (1, N'Admin', N'c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f')
SET IDENTITY_INSERT [dbo].[ApiUser] OFF
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([Idclient], [IdNumberPerson], [PhoneNumbre]) VALUES (1, N'123456789', N'3146932054')
INSERT [dbo].[Client] ([Idclient], [IdNumberPerson], [PhoneNumbre]) VALUES (2, N'789456123', N'3139852015')
SET IDENTITY_INSERT [dbo].[Client] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([IdOrder], [Idclient], [Date], [TotalAmount]) VALUES (1, 1, CAST(N'2022-12-12T06:49:52.720' AS DateTime), 11.9000)
INSERT [dbo].[Order] ([IdOrder], [Idclient], [Date], [TotalAmount]) VALUES (6, 2, CAST(N'2022-12-12T06:49:52.720' AS DateTime), 8.4000)
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([IdOrderDetail], [IdOrder], [IdProduct], [Quantity], [Amount]) VALUES (1, 1, 1, 2, 6.9000)
INSERT [dbo].[OrderDetail] ([IdOrderDetail], [IdOrder], [IdProduct], [Quantity], [Amount]) VALUES (2, 1, 3, 1, 5.0000)
INSERT [dbo].[OrderDetail] ([IdOrderDetail], [IdOrder], [IdProduct], [Quantity], [Amount]) VALUES (11, 6, 4, 1, 4.9500)
INSERT [dbo].[OrderDetail] ([IdOrderDetail], [IdOrder], [IdProduct], [Quantity], [Amount]) VALUES (12, 6, 1, 1, 3.4500)
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
INSERT [dbo].[Person] ([IdNumber], [FirstName], [LastName]) VALUES (N'123456789', N'Carlos', N'Leon')
INSERT [dbo].[Person] ([IdNumber], [FirstName], [LastName]) VALUES (N'1234567890', N'Admin', N'Admin')
INSERT [dbo].[Person] ([IdNumber], [FirstName], [LastName]) VALUES (N'159357468', N'Andres', N'Ortega')
INSERT [dbo].[Person] ([IdNumber], [FirstName], [LastName]) VALUES (N'789456123', N'Andrea', N'Martinez')
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([IdProduct], [ProductName], [Price]) VALUES (1, N'Toothpaste Colgate', 3.4500)
INSERT [dbo].[Product] ([IdProduct], [ProductName], [Price]) VALUES (3, N'Milo cereals', 5.0000)
INSERT [dbo].[Product] ([IdProduct], [ProductName], [Price]) VALUES (4, N'Chocapic cereals', 4.9500)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([IdUser], [IdNumberPerson], [email], [password]) VALUES (1, N'1234567890', N'Admin@ecommerce.com', N'c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Client]  WITH CHECK ADD FOREIGN KEY([IdNumberPerson])
REFERENCES [dbo].[Person] ([IdNumber])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([Idclient])
REFERENCES [dbo].[Client] ([Idclient])
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD FOREIGN KEY([IdOrder])
REFERENCES [dbo].[Order] ([IdOrder])
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD FOREIGN KEY([IdProduct])
REFERENCES [dbo].[Product] ([IdProduct])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([IdNumberPerson])
REFERENCES [dbo].[Person] ([IdNumber])
GO
USE [master]
GO
ALTER DATABASE [basicEcommerce] SET  READ_WRITE 
GO
