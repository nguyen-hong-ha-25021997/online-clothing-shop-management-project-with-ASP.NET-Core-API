USE [DbWebQA]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/16/2021 8:49:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Account]    Script Date: 4/16/2021 8:49:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateModified] [datetime2](7) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 4/16/2021 8:49:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 4/16/2021 8:49:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 4/16/2021 8:49:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 4/16/2021 8:49:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 4/16/2021 8:49:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [int] NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 4/16/2021 8:49:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Category_Id] [int] IDENTITY(1,1) NOT NULL,
	[Category_Name] [nvarchar](max) NULL,
	[Category_Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Category_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Function]    Script Date: 4/16/2021 8:49:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Function](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateModified] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_Function] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 4/16/2021 8:49:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Order_Id] [int] IDENTITY(1,1) NOT NULL,
	[Account_Id] [int] NULL,
	[Order_PurchaseTime] [datetime2](7) NOT NULL DEFAULT (getdate()),
	[Order_DeliveryTime] [datetime2](7) NOT NULL,
	[Order_DeliveryAddress] [nvarchar](max) NULL,
	[Order_DeliveryContact] [nvarchar](max) NULL,
	[Order_Status] [int] NOT NULL,
	[Order_Amount] [int] NOT NULL,
	[PaymentMethod] [nvarchar](max) NULL,
	[CustomerAddress] [nvarchar](max) NULL,
	[CustomerEmail] [nvarchar](max) NULL,
	[CustomerMobile] [nvarchar](max) NULL,
	[CustomerName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Order_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 4/16/2021 8:49:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderDetail_Id] [int] IDENTITY(1,1) NOT NULL,
	[Order_Id] [int] NULL,
	[Product_Id] [int] NULL,
	[OrderDetail_Quantity] [int] NOT NULL,
	[OrderDetail_Amount] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderDetail_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 4/16/2021 8:49:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[AccountId] [int] NOT NULL,
	[FunctionId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[FunctionId] ASC,
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 4/16/2021 8:49:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Product_Id] [int] IDENTITY(1,1) NOT NULL,
	[Category_Id] [int] NULL,
	[Product_Name] [nvarchar](max) NOT NULL,
	[Product_Size] [nvarchar](max) NULL,
	[Product_Image] [nvarchar](max) NULL,
	[Product_Show] [nvarchar](max) NULL,
	[Product_Price] [int] NOT NULL,
	[Product_Note] [nvarchar](max) NULL,
	[StatusPrice] [int] NOT NULL,
	[Product_Style] [nvarchar](max) NULL,
	[Product_Quantity] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Product_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210118144853_18_01', N'5.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210118151857_18_02', N'5.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210414034845_payment', N'5.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210414041524_customerDetail', N'5.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210414094537_product_quantity', N'5.0.2')
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([Id], [DateCreated], [DateModified], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (1, CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL, N'ha', N'HA', N'ha@gmai.com', N'HA@GMAI.COM', 0, N'AQAAAAEAACcQAAAAEG7KUXrXdO3wuwJgVTvQeqjOdNzGo3WBKY10wlvudDnMNQME3bUKcuF5KVgaJju8tw==', N'IR7ZRTWD4BSRPZLQR6CKI64KUQLLWP4I', N'5177d69a-4152-4cfa-a402-11e5511b9f1b', N'000', 0, 0, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Category_Id], [Category_Name], [Category_Quantity]) VALUES (3, N'Váy Body', 5)
INSERT [dbo].[Category] ([Category_Id], [Category_Name], [Category_Quantity]) VALUES (4, N'Phụ Kiện', 0)
INSERT [dbo].[Category] ([Category_Id], [Category_Name], [Category_Quantity]) VALUES (5, N'Váy Xòe', 0)
INSERT [dbo].[Category] ([Category_Id], [Category_Name], [Category_Quantity]) VALUES (6, N'Quần Ngố', 0)
INSERT [dbo].[Category] ([Category_Id], [Category_Name], [Category_Quantity]) VALUES (7, N'Quần Sóc', 0)
INSERT [dbo].[Category] ([Category_Id], [Category_Name], [Category_Quantity]) VALUES (8, N'Quần Jean', 0)
INSERT [dbo].[Category] ([Category_Id], [Category_Name], [Category_Quantity]) VALUES (9, N'Áo Sơ Mi', 0)
INSERT [dbo].[Category] ([Category_Id], [Category_Name], [Category_Quantity]) VALUES (10, N'Áo Phông', 0)
INSERT [dbo].[Category] ([Category_Id], [Category_Name], [Category_Quantity]) VALUES (11, N'Áo Khoác', 0)
INSERT [dbo].[Category] ([Category_Id], [Category_Name], [Category_Quantity]) VALUES (12, N'Áo 2 Dây', 0)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Order_Id], [Account_Id], [Order_PurchaseTime], [Order_DeliveryTime], [Order_DeliveryAddress], [Order_DeliveryContact], [Order_Status], [Order_Amount], [PaymentMethod], [CustomerAddress], [CustomerEmail], [CustomerMobile], [CustomerName]) VALUES (1, NULL, CAST(N'2021-04-14 14:54:03.3900986' AS DateTime2), CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 0, NULL, N'aa', N'a@gmail.com', N'123', N'aa')
INSERT [dbo].[Order] ([Order_Id], [Account_Id], [Order_PurchaseTime], [Order_DeliveryTime], [Order_DeliveryAddress], [Order_DeliveryContact], [Order_Status], [Order_Amount], [PaymentMethod], [CustomerAddress], [CustomerEmail], [CustomerMobile], [CustomerName]) VALUES (2, NULL, CAST(N'2021-04-14 14:54:47.1032697' AS DateTime2), CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 0, NULL, N'aa', N'a@gmail.com', N'123', N'aa')
INSERT [dbo].[Order] ([Order_Id], [Account_Id], [Order_PurchaseTime], [Order_DeliveryTime], [Order_DeliveryAddress], [Order_DeliveryContact], [Order_Status], [Order_Amount], [PaymentMethod], [CustomerAddress], [CustomerEmail], [CustomerMobile], [CustomerName]) VALUES (3, NULL, CAST(N'2021-04-14 14:57:24.5472694' AS DateTime2), CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 0, NULL, N'aaaa', N'hathilan195@gmail.com', N'123', N'aa')
INSERT [dbo].[Order] ([Order_Id], [Account_Id], [Order_PurchaseTime], [Order_DeliveryTime], [Order_DeliveryAddress], [Order_DeliveryContact], [Order_Status], [Order_Amount], [PaymentMethod], [CustomerAddress], [CustomerEmail], [CustomerMobile], [CustomerName]) VALUES (4, NULL, CAST(N'2021-04-14 15:08:53.1267920' AS DateTime2), CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 0, NULL, N'aaaaaa', N'hathilan195@gmail.com', N'1223', N'aaa')
INSERT [dbo].[Order] ([Order_Id], [Account_Id], [Order_PurchaseTime], [Order_DeliveryTime], [Order_DeliveryAddress], [Order_DeliveryContact], [Order_Status], [Order_Amount], [PaymentMethod], [CustomerAddress], [CustomerEmail], [CustomerMobile], [CustomerName]) VALUES (5, NULL, CAST(N'2021-04-14 15:09:06.8404346' AS DateTime2), CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 0, NULL, N'aaaaaa', N'hathilan195@gmail.com', N'1223', N'aaa')
INSERT [dbo].[Order] ([Order_Id], [Account_Id], [Order_PurchaseTime], [Order_DeliveryTime], [Order_DeliveryAddress], [Order_DeliveryContact], [Order_Status], [Order_Amount], [PaymentMethod], [CustomerAddress], [CustomerEmail], [CustomerMobile], [CustomerName]) VALUES (6, NULL, CAST(N'2021-04-14 15:21:29.8621956' AS DateTime2), CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 0, NULL, N'aaaaa', N'hathilan195@gmail.com', N'012', N'aaa')
INSERT [dbo].[Order] ([Order_Id], [Account_Id], [Order_PurchaseTime], [Order_DeliveryTime], [Order_DeliveryAddress], [Order_DeliveryContact], [Order_Status], [Order_Amount], [PaymentMethod], [CustomerAddress], [CustomerEmail], [CustomerMobile], [CustomerName]) VALUES (7, NULL, CAST(N'2021-04-14 15:26:51.1751777' AS DateTime2), CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 0, NULL, N'a', N'hathilan195@gmail.com', N'123', N'aaaaa')
INSERT [dbo].[Order] ([Order_Id], [Account_Id], [Order_PurchaseTime], [Order_DeliveryTime], [Order_DeliveryAddress], [Order_DeliveryContact], [Order_Status], [Order_Amount], [PaymentMethod], [CustomerAddress], [CustomerEmail], [CustomerMobile], [CustomerName]) VALUES (8, NULL, CAST(N'2021-04-14 15:27:39.5401641' AS DateTime2), CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 0, NULL, N'a', N'hathilan195@gmail.com', N'123', N'aaaaa')
INSERT [dbo].[Order] ([Order_Id], [Account_Id], [Order_PurchaseTime], [Order_DeliveryTime], [Order_DeliveryAddress], [Order_DeliveryContact], [Order_Status], [Order_Amount], [PaymentMethod], [CustomerAddress], [CustomerEmail], [CustomerMobile], [CustomerName]) VALUES (9, NULL, CAST(N'2021-04-14 15:36:36.9420822' AS DateTime2), CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 0, NULL, N'a', N'hathilan195@gmail.com', N'123', N'aaaaa')
INSERT [dbo].[Order] ([Order_Id], [Account_Id], [Order_PurchaseTime], [Order_DeliveryTime], [Order_DeliveryAddress], [Order_DeliveryContact], [Order_Status], [Order_Amount], [PaymentMethod], [CustomerAddress], [CustomerEmail], [CustomerMobile], [CustomerName]) VALUES (10, NULL, CAST(N'2021-04-14 15:37:03.6850588' AS DateTime2), CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 0, NULL, N'a', N'hathilan195@gmail.com', N'123', N'aaaaa')
INSERT [dbo].[Order] ([Order_Id], [Account_Id], [Order_PurchaseTime], [Order_DeliveryTime], [Order_DeliveryAddress], [Order_DeliveryContact], [Order_Status], [Order_Amount], [PaymentMethod], [CustomerAddress], [CustomerEmail], [CustomerMobile], [CustomerName]) VALUES (11, NULL, CAST(N'2021-04-14 15:37:18.5341965' AS DateTime2), CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 0, NULL, N'a', N'hathilan195@gmail.com', N'123', N'aaaaa')
INSERT [dbo].[Order] ([Order_Id], [Account_Id], [Order_PurchaseTime], [Order_DeliveryTime], [Order_DeliveryAddress], [Order_DeliveryContact], [Order_Status], [Order_Amount], [PaymentMethod], [CustomerAddress], [CustomerEmail], [CustomerMobile], [CustomerName]) VALUES (12, NULL, CAST(N'2021-04-14 16:04:37.7695812' AS DateTime2), CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 438000, NULL, N'ádas', N'hathilan195@gmail.com', N'123', N'vávs')
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([OrderDetail_Id], [Order_Id], [Product_Id], [OrderDetail_Quantity], [OrderDetail_Amount]) VALUES (1, 1, 16, 1, 0)
INSERT [dbo].[OrderDetail] ([OrderDetail_Id], [Order_Id], [Product_Id], [OrderDetail_Quantity], [OrderDetail_Amount]) VALUES (2, 2, 16, 1, 0)
INSERT [dbo].[OrderDetail] ([OrderDetail_Id], [Order_Id], [Product_Id], [OrderDetail_Quantity], [OrderDetail_Amount]) VALUES (3, 3, 16, 1, 0)
INSERT [dbo].[OrderDetail] ([OrderDetail_Id], [Order_Id], [Product_Id], [OrderDetail_Quantity], [OrderDetail_Amount]) VALUES (4, 4, 16, 1, 0)
INSERT [dbo].[OrderDetail] ([OrderDetail_Id], [Order_Id], [Product_Id], [OrderDetail_Quantity], [OrderDetail_Amount]) VALUES (5, 5, 16, 1, 0)
INSERT [dbo].[OrderDetail] ([OrderDetail_Id], [Order_Id], [Product_Id], [OrderDetail_Quantity], [OrderDetail_Amount]) VALUES (6, 6, 16, 1, 0)
INSERT [dbo].[OrderDetail] ([OrderDetail_Id], [Order_Id], [Product_Id], [OrderDetail_Quantity], [OrderDetail_Amount]) VALUES (7, 7, 16, 1, 0)
INSERT [dbo].[OrderDetail] ([OrderDetail_Id], [Order_Id], [Product_Id], [OrderDetail_Quantity], [OrderDetail_Amount]) VALUES (8, 8, 16, 1, 0)
INSERT [dbo].[OrderDetail] ([OrderDetail_Id], [Order_Id], [Product_Id], [OrderDetail_Quantity], [OrderDetail_Amount]) VALUES (9, 9, 16, 1, 0)
INSERT [dbo].[OrderDetail] ([OrderDetail_Id], [Order_Id], [Product_Id], [OrderDetail_Quantity], [OrderDetail_Amount]) VALUES (10, 10, 16, 1, 0)
INSERT [dbo].[OrderDetail] ([OrderDetail_Id], [Order_Id], [Product_Id], [OrderDetail_Quantity], [OrderDetail_Amount]) VALUES (11, 11, 16, 1, 0)
INSERT [dbo].[OrderDetail] ([OrderDetail_Id], [Order_Id], [Product_Id], [OrderDetail_Quantity], [OrderDetail_Amount]) VALUES (12, 12, 16, 2, 0)
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name], [Product_Size], [Product_Image], [Product_Show], [Product_Price], [Product_Note], [StatusPrice], [Product_Style], [Product_Quantity]) VALUES (4, 3, N'Váy 3.1', N'S         ', N'Resources\Images\Vay1 (2).jpg', N'TN31_01   ', 169000, N'Bán rất chạy ', 0, N'Vay       ', 0)
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name], [Product_Size], [Product_Image], [Product_Show], [Product_Price], [Product_Note], [StatusPrice], [Product_Style], [Product_Quantity]) VALUES (5, 3, N'Váy 3.2', N'M         ', N'Resources\Images\vaybody1.jpg', N'TN31_02   ', 249000, N'Bán Chạy', 0, N'Vay       ', 0)
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name], [Product_Size], [Product_Image], [Product_Show], [Product_Price], [Product_Note], [StatusPrice], [Product_Style], [Product_Quantity]) VALUES (6, 3, N'Váy 3.3', N'M         ', N'Resources\Images\jer_0632_668x1000.jpg', N'TN31_06   ', 99000, N'Sales', 0, N'Vay       ', 0)
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name], [Product_Size], [Product_Image], [Product_Show], [Product_Price], [Product_Note], [StatusPrice], [Product_Style], [Product_Quantity]) VALUES (7, 3, N'Váy 3.4', N'S         ', N'Resources\Images\jer_0720_667x1000.jpg', N'HB_72     ', 199000, N'Bán rất chạy ', 0, N'Vay       ', 0)
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name], [Product_Size], [Product_Image], [Product_Show], [Product_Price], [Product_Note], [StatusPrice], [Product_Style], [Product_Quantity]) VALUES (9, 3, N'Váy 3.5', N'M         ', N'Resources\Images\jer_1768_thumb_399x599.jpg', N'TN_3107   ', 149000, N'Sales', 0, N'Vay       ', 0)
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name], [Product_Size], [Product_Image], [Product_Show], [Product_Price], [Product_Note], [StatusPrice], [Product_Style], [Product_Quantity]) VALUES (11, 4, N'Váy 4.1', N'M         ', N'Resources\Images\vaybody2.jpg', N'TN32_03   ', 150000, N'Sales', 0, N'Vay       ', 0)
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name], [Product_Size], [Product_Image], [Product_Show], [Product_Price], [Product_Note], [StatusPrice], [Product_Style], [Product_Quantity]) VALUES (12, 4, N'Váy 4.2', N'M         ', N'Resources\Images\jer_7442_668x1000.jpg', N'TN21_02   ', 129000, N'Bán rất chạy ', 0, N'Vay       ', 0)
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name], [Product_Size], [Product_Image], [Product_Show], [Product_Price], [Product_Note], [StatusPrice], [Product_Style], [Product_Quantity]) VALUES (13, 4, N'Váy 4.3', N'S         ', N'Resources\Images\váy 4.jpg', N'TN32_01   ', 99000, N'Bán Chạy', 0, N'Vay       ', 0)
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name], [Product_Size], [Product_Image], [Product_Show], [Product_Price], [Product_Note], [StatusPrice], [Product_Style], [Product_Quantity]) VALUES (14, 4, N'Váy 4.4', N'M         ', N'Resources\Images\vayxoe1.jpg', N'TN32_06   ', 49000, N'Sales', 0, N'Vay       ', 0)
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name], [Product_Size], [Product_Image], [Product_Show], [Product_Price], [Product_Note], [StatusPrice], [Product_Style], [Product_Quantity]) VALUES (15, 4, N'Váy  4.5', N'M         ', N'Resources\Images\vayxoe3.jpg', N'TN32_08   ', 149000, N'Bán rất chạy ', 0, N'Vay       ', 0)
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name], [Product_Size], [Product_Image], [Product_Show], [Product_Price], [Product_Note], [StatusPrice], [Product_Style], [Product_Quantity]) VALUES (16, 5, N'Quần 5.1', N'S         ', N'Resources\Images\jer_0765_668x1000.jpg', N'TN_2204   ', 219000, N'Mới', 0, N'Quan      ', 0)
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name], [Product_Size], [Product_Image], [Product_Show], [Product_Price], [Product_Note], [StatusPrice], [Product_Style], [Product_Quantity]) VALUES (18, 6, N'Quần 6.1', N'S         ', N'Resources\Images\quansoc1.jpg', N'TN22_01   ', 190000, N'Mới', 0, N'Quan      ', 0)
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name], [Product_Size], [Product_Image], [Product_Show], [Product_Price], [Product_Note], [StatusPrice], [Product_Style], [Product_Quantity]) VALUES (19, 6, N'Quần 6.2', N'M         ', N'Resources\Images\quansoc2.jpg', N'TN22_02   ', 79000, N'Bán Chạy', 0, N'Quan      ', 0)
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name], [Product_Size], [Product_Image], [Product_Show], [Product_Price], [Product_Note], [StatusPrice], [Product_Style], [Product_Quantity]) VALUES (21, 10, N'Áo 10.1', N'S         ', N'Resources\Images\aophong1.jpg', N'TN27_01   ', 99000, N'Bán Chạy', 0, N'Ao        ', 0)
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name], [Product_Size], [Product_Image], [Product_Show], [Product_Price], [Product_Note], [StatusPrice], [Product_Style], [Product_Quantity]) VALUES (22, 10, N'Áo 10.2', N'S         ', N'Resources\Images\aophong2.jpg', N'TN27_02   ', 190000, N'Mới', 0, N'Ao        ', 0)
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name], [Product_Size], [Product_Image], [Product_Show], [Product_Price], [Product_Note], [StatusPrice], [Product_Style], [Product_Quantity]) VALUES (23, 10, N'Áo 10.3', N'S         ', N'Resources\Images\aophong3.jpg', N'TN27_03   ', 149000, N'Mới', 0, N'Ao        ', 0)
SET IDENTITY_INSERT [dbo].[Product] OFF
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_Function_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Function] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_Function_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_Account_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Account] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_Account_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_Account_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Account] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_Account_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_Account_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Account] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_Account_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_Function_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Function] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_Function_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_Account_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Account] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_Account_UserId]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Account_Account_Id] FOREIGN KEY([Account_Id])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Account_Account_Id]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order_Order_Id] FOREIGN KEY([Order_Id])
REFERENCES [dbo].[Order] ([Order_Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order_Order_Id]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product_Product_Id] FOREIGN KEY([Product_Id])
REFERENCES [dbo].[Product] ([Product_Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product_Product_Id]
GO
ALTER TABLE [dbo].[Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_Account_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Permissions] CHECK CONSTRAINT [FK_Permissions_Account_AccountId]
GO
ALTER TABLE [dbo].[Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_Function_FunctionId] FOREIGN KEY([FunctionId])
REFERENCES [dbo].[Function] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Permissions] CHECK CONSTRAINT [FK_Permissions_Function_FunctionId]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category_Category_Id] FOREIGN KEY([Category_Id])
REFERENCES [dbo].[Category] ([Category_Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category_Category_Id]
GO
