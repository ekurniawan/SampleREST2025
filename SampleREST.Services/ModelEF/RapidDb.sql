USE [master]
GO
/****** Object:  Database [RapidDb]    Script Date: 2/19/2025 9:37:27 AM ******/
CREATE DATABASE [RapidDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RapidDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\RapidDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RapidDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\RapidDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [RapidDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RapidDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RapidDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RapidDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RapidDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RapidDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RapidDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [RapidDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RapidDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RapidDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RapidDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RapidDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RapidDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RapidDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RapidDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RapidDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RapidDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RapidDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RapidDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RapidDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RapidDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RapidDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RapidDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RapidDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RapidDb] SET RECOVERY FULL 
GO
ALTER DATABASE [RapidDb] SET  MULTI_USER 
GO
ALTER DATABASE [RapidDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RapidDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RapidDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RapidDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RapidDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RapidDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'RapidDb', N'ON'
GO
ALTER DATABASE [RapidDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [RapidDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [RapidDb]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 2/19/2025 9:37:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2/19/2025 9:37:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ProductName] [nvarchar](255) NOT NULL,
	[Stock] [int] NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ViewProductsWithCategory]    Script Date: 2/19/2025 9:37:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewProductsWithCategory]
AS
SELECT dbo.Products.ProductId, dbo.Products.CategoryId, dbo.Categories.CategoryName, dbo.Products.ProductName, dbo.Products.Stock, dbo.Products.Price
FROM   dbo.Categories INNER JOIN
             dbo.Products ON dbo.Categories.CategoryId = dbo.Products.CategoryId
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 2/19/2025 9:37:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wallets]    Script Date: 2/19/2025 9:37:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wallets](
	[WalletId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[WalletTypeId] [int] NOT NULL,
	[Saldo] [money] NOT NULL,
 CONSTRAINT [PK_Wallets] PRIMARY KEY CLUSTERED 
(
	[WalletId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderHeaders]    Script Date: 2/19/2025 9:37:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderHeaders](
	[OrderHeaderId] [char](8) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[WalletId] [int] NOT NULL,
 CONSTRAINT [PK_OrderHeaders] PRIMARY KEY CLUSTERED 
(
	[OrderHeaderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WalletTypes]    Script Date: 2/19/2025 9:37:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WalletTypes](
	[WalletTypeId] [int] IDENTITY(1,1) NOT NULL,
	[WalletName] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_WalletTypes] PRIMARY KEY CLUSTERED 
(
	[WalletTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ViewOrderHeaderInfo]    Script Date: 2/19/2025 9:37:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewOrderHeaderInfo]
AS
SELECT dbo.OrderHeaders.OrderHeaderId, dbo.Customers.CustomerId, dbo.Customers.CustomerName, dbo.WalletTypes.WalletName, dbo.OrderHeaders.TransactionDate
FROM   dbo.Customers INNER JOIN
             dbo.Wallets ON dbo.Customers.CustomerId = dbo.Wallets.CustomerId INNER JOIN
             dbo.OrderHeaders ON dbo.Wallets.WalletId = dbo.OrderHeaders.WalletId INNER JOIN
             dbo.WalletTypes ON dbo.Wallets.WalletTypeId = dbo.WalletTypes.WalletTypeId
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 2/19/2025 9:37:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[OrderHeaderId] [char](8) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ViewOrderDetail]    Script Date: 2/19/2025 9:37:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewOrderDetail]
AS
SELECT dbo.OrderDetails.OrderDetailId, dbo.OrderDetails.OrderHeaderId, dbo.OrderDetails.ProductId, dbo.Products.ProductName, dbo.OrderDetails.Qty, dbo.OrderDetails.Price
FROM   dbo.OrderDetails INNER JOIN
             dbo.Products ON dbo.OrderDetails.ProductId = dbo.Products.ProductId
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (1, N'Laptop Gaming')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (2, N'Laptop Office')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (3, N'SSD')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (4, N'VRAM')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (6, N'Mouse')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (8, N'Smartphone')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (12, N'SDCard')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (13, N'Flash Disk')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([CustomerId], [CustomerName], [Email]) VALUES (1, N'Scott Guthrie', N'scott@microsoft.com')
INSERT [dbo].[Customers] ([CustomerId], [CustomerName], [Email]) VALUES (2, N'Scott Hanselman', N'hanselman@microsoft.com')
INSERT [dbo].[Customers] ([CustomerId], [CustomerName], [Email]) VALUES (3, N'Beth Messi', N'beth@microsoft.com')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderHeaderId], [ProductId], [Qty], [Price]) VALUES (1, N'INV-0001', 1, 1, 20000000.0000)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderHeaderId], [ProductId], [Qty], [Price]) VALUES (4, N'INV-0001', 3, 1, 22000000.0000)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderHeaderId], [ProductId], [Qty], [Price]) VALUES (5, N'INV-0001', 4, 2, 30000000.0000)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderHeaderId], [ProductId], [Qty], [Price]) VALUES (6, N'INV-0002', 1, 1, 20000000.0000)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderHeaderId], [ProductId], [Qty], [Price]) VALUES (8, N'INV-0002', 5, 1, 500000.0000)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderHeaderId], [ProductId], [Qty], [Price]) VALUES (12, N'INV-0003', 3, 1, 22000000.0000)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderHeaderId], [ProductId], [Qty], [Price]) VALUES (13, N'INV-0003', 5, 2, 500000.0000)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderHeaderId], [ProductId], [Qty], [Price]) VALUES (15, N'INV-0003', 1, 1, 20000000.0000)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderHeaderId], [ProductId], [Qty], [Price]) VALUES (16, N'INV-0006', 4, 2, 30000000.0000)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderHeaderId], [ProductId], [Qty], [Price]) VALUES (17, N'INV-0006', 1, 1, 20000000.0000)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderHeaderId], [ProductId], [Qty], [Price]) VALUES (18, N'INV-0007', 4, 2, 30000000.0000)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderHeaderId], [ProductId], [Qty], [Price]) VALUES (19, N'INV-0007', 1, 1, 20000000.0000)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderHeaderId], [ProductId], [Qty], [Price]) VALUES (20, N'INV-0010', 7, 1, 750000.0000)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderHeaderId], [ProductId], [Qty], [Price]) VALUES (21, N'INV-0010', 6, 1, 500000.0000)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderHeaderId], [ProductId], [Qty], [Price]) VALUES (22, N'INV-0011', 7, 1, 750000.0000)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderHeaderId], [ProductId], [Qty], [Price]) VALUES (23, N'INV-0011', 6, 1, 500000.0000)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderHeaderId], [ProductId], [Qty], [Price]) VALUES (26, N'INV-0012', 6, 1, 500000.0000)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderHeaderId], [ProductId], [Qty], [Price]) VALUES (27, N'INV-0005', 5, 1, 250000.0000)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderHeaderId], [ProductId], [Qty], [Price]) VALUES (28, N'INV-0005', 4, 1, 1500000.0000)
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
INSERT [dbo].[OrderHeaders] ([OrderHeaderId], [TransactionDate], [WalletId]) VALUES (N'INV-0001', CAST(N'2024-06-07T14:26:04.803' AS DateTime), 1)
INSERT [dbo].[OrderHeaders] ([OrderHeaderId], [TransactionDate], [WalletId]) VALUES (N'INV-0002', CAST(N'2024-06-07T14:26:23.130' AS DateTime), 2)
INSERT [dbo].[OrderHeaders] ([OrderHeaderId], [TransactionDate], [WalletId]) VALUES (N'INV-0003', CAST(N'2024-06-07T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[OrderHeaders] ([OrderHeaderId], [TransactionDate], [WalletId]) VALUES (N'INV-0004', CAST(N'2024-06-11T11:59:17.547' AS DateTime), 3)
INSERT [dbo].[OrderHeaders] ([OrderHeaderId], [TransactionDate], [WalletId]) VALUES (N'INV-0005', CAST(N'2024-06-11T11:59:31.647' AS DateTime), 2)
INSERT [dbo].[OrderHeaders] ([OrderHeaderId], [TransactionDate], [WalletId]) VALUES (N'INV-0006', CAST(N'2024-06-11T16:08:57.543' AS DateTime), 1)
INSERT [dbo].[OrderHeaders] ([OrderHeaderId], [TransactionDate], [WalletId]) VALUES (N'INV-0007', CAST(N'2024-06-11T16:14:46.660' AS DateTime), 3)
INSERT [dbo].[OrderHeaders] ([OrderHeaderId], [TransactionDate], [WalletId]) VALUES (N'INV-0008', CAST(N'2024-06-12T10:24:57.687' AS DateTime), 3)
INSERT [dbo].[OrderHeaders] ([OrderHeaderId], [TransactionDate], [WalletId]) VALUES (N'INV-0009', CAST(N'2024-06-12T10:31:11.910' AS DateTime), 3)
INSERT [dbo].[OrderHeaders] ([OrderHeaderId], [TransactionDate], [WalletId]) VALUES (N'INV-0010', CAST(N'2024-06-12T10:33:12.220' AS DateTime), 3)
INSERT [dbo].[OrderHeaders] ([OrderHeaderId], [TransactionDate], [WalletId]) VALUES (N'INV-0011', CAST(N'2024-06-12T10:59:35.007' AS DateTime), 3)
INSERT [dbo].[OrderHeaders] ([OrderHeaderId], [TransactionDate], [WalletId]) VALUES (N'INV-0012', CAST(N'2024-06-12T11:49:32.407' AS DateTime), 3)
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName], [Stock], [Price]) VALUES (1, 1, N'ASUS ROG XX', 6, 20000000.0000)
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName], [Stock], [Price]) VALUES (3, 1, N'Lenovo Legion YY', 8, 22000000.0000)
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName], [Stock], [Price]) VALUES (4, 1, N'Alienware ZZ', 3, 30000000.0000)
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName], [Stock], [Price]) VALUES (5, 2, N'Acer Switch', 5, 15000000.0000)
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName], [Stock], [Price]) VALUES (6, 3, N'SSD Samsung 256 NN', 11, 500000.0000)
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName], [Stock], [Price]) VALUES (7, 3, N'SSD Samsung 512 XX', 12, 750000.0000)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Wallets] ON 

INSERT [dbo].[Wallets] ([WalletId], [CustomerId], [WalletTypeId], [Saldo]) VALUES (1, 1, 1, 20000000.0000)
INSERT [dbo].[Wallets] ([WalletId], [CustomerId], [WalletTypeId], [Saldo]) VALUES (2, 1, 2, 25000000.0000)
INSERT [dbo].[Wallets] ([WalletId], [CustomerId], [WalletTypeId], [Saldo]) VALUES (3, 2, 1, 500000.0000)
SET IDENTITY_INSERT [dbo].[Wallets] OFF
GO
SET IDENTITY_INSERT [dbo].[WalletTypes] ON 

INSERT [dbo].[WalletTypes] ([WalletTypeId], [WalletName]) VALUES (1, N'GoPay')
INSERT [dbo].[WalletTypes] ([WalletTypeId], [WalletName]) VALUES (2, N'Dana')
INSERT [dbo].[WalletTypes] ([WalletTypeId], [WalletName]) VALUES (3, N'Gopay')
INSERT [dbo].[WalletTypes] ([WalletTypeId], [WalletName]) VALUES (4, N'Ovo')
SET IDENTITY_INSERT [dbo].[WalletTypes] OFF
GO
ALTER TABLE [dbo].[OrderDetails] ADD  CONSTRAINT [DF_OrderDetails_Qty]  DEFAULT ((0)) FOR [Qty]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  CONSTRAINT [DF_OrderDetails_Price]  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[OrderHeaders] ADD  CONSTRAINT [DF_OrderHeaders_TransactionDate]  DEFAULT (getdate()) FOR [TransactionDate]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_Stock]  DEFAULT ((0)) FOR [Stock]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_Price]  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Wallets] ADD  CONSTRAINT [DF_Wallets_Saldo]  DEFAULT ((0)) FOR [Saldo]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_OrderHeaders] FOREIGN KEY([OrderHeaderId])
REFERENCES [dbo].[OrderHeaders] ([OrderHeaderId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_OrderHeaders]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products]
GO
ALTER TABLE [dbo].[OrderHeaders]  WITH CHECK ADD  CONSTRAINT [FK_OrderHeaders_Wallets] FOREIGN KEY([WalletId])
REFERENCES [dbo].[Wallets] ([WalletId])
GO
ALTER TABLE [dbo].[OrderHeaders] CHECK CONSTRAINT [FK_OrderHeaders_Wallets]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories1] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories1]
GO
ALTER TABLE [dbo].[Wallets]  WITH CHECK ADD  CONSTRAINT [FK_Wallets_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[Wallets] CHECK CONSTRAINT [FK_Wallets_Customers]
GO
ALTER TABLE [dbo].[Wallets]  WITH CHECK ADD  CONSTRAINT [FK_Wallets_WalletTypes] FOREIGN KEY([WalletTypeId])
REFERENCES [dbo].[WalletTypes] ([WalletTypeId])
GO
ALTER TABLE [dbo].[Wallets] CHECK CONSTRAINT [FK_Wallets_WalletTypes]
GO
/****** Object:  StoredProcedure [dbo].[sp_deleteCategory]    Script Date: 2/19/2025 9:37:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_deleteCategory]
	@CategoryId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from Categories where CategoryId=@CategoryId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllCategories]    Script Date: 2/19/2025 9:37:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAllCategories]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Categories order by CategoryName asc
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllProducts]    Script Date: 2/19/2025 9:37:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAllProducts]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Products order by ProductName asc
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[11] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "OrderDetails"
            Begin Extent = 
               Top = 7
               Left = 241
               Bottom = 204
               Right = 464
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Products"
            Begin Extent = 
               Top = 10
               Left = 697
               Bottom = 207
               Right = 919
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1430
         Width = 1550
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewOrderDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewOrderDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[52] 4[10] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Customers"
            Begin Extent = 
               Top = 5
               Left = 578
               Bottom = 175
               Right = 806
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Wallets"
            Begin Extent = 
               Top = 18
               Left = 319
               Bottom = 215
               Right = 541
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OrderHeaders"
            Begin Extent = 
               Top = 18
               Left = 16
               Bottom = 188
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WalletTypes"
            Begin Extent = 
               Top = 199
               Left = 593
               Bottom = 342
               Right = 815
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1450
         Width = 1510
         Width = 1580
         Width = 1600
         Width = 1290
         Width = 2120
         Width = 1000
         Width = 1000
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewOrderHeaderInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'     End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewOrderHeaderInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewOrderHeaderInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Categories"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 212
               Right = 280
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Products"
            Begin Extent = 
               Top = 9
               Left = 337
               Bottom = 206
               Right = 559
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewProductsWithCategory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewProductsWithCategory'
GO
USE [master]
GO
ALTER DATABASE [RapidDb] SET  READ_WRITE 
GO
